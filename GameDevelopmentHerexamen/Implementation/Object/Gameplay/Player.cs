using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Object.Component;
using GameDevelopmentHerexamen.Framework.Scene;
using GameDevelopmentHerexamen.Framework.Utility;
using GameDevelopmentHerexamen.Implementation.Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Object.Gameplay {
    public class Player : GameObject {
        public int JumpPower { get; set; } = 825;
        public int WalkSpeed { get; set; } = 450;
        public static int Score { get; set; } = 0;

        private bool shouldJump = false;
        private bool onGround = false;
        private (bool left, bool right) shouldMove = (false, false);
        private float animationTimer = 0;

        public Player(UDim2 initialPosition) {
            Vector2 rawInitialPosition = initialPosition.Resolve(new Vector2(SceneManager.Instance.GraphicsDevice.Viewport.Width, SceneManager.Instance.GraphicsDevice.Viewport.Height));
            Position = new UDim2() + rawInitialPosition;
            Size = new UDim2(0, 16, 0, 32);

            AddComponent(new SheetImageComponent() {
                AssetReference = "images/mario",
                SourceRectangles = [
                    new Rectangle(90, 52, 16, 32),  // 0 walking left
                    new Rectangle(120, 52, 16, 32), // 1
                    new Rectangle(150, 52, 16, 32), // 2
                    new Rectangle(180, 52, 16, 32), // 3 standing still left
                    new Rectangle(209, 52, 16, 32), // 4 standing still right
                    new Rectangle(239, 52, 16, 32), // 5 walking right
                    new Rectangle(269, 52, 16, 32), // 6
                    new Rectangle(299, 52, 16, 32), // 7
                ],
                CurrentRectangle = 0
            });
            AddComponent(new PhysicsComponent());
            AddComponent(new KeyInputComponent(Keys.Z, keyDownHandler: () => {
                if (onGround) {
                    shouldJump = true;
                }
            }));
            AddComponent(new KeyInputComponent(Keys.Q, anyHandler: (isDown) => {
                shouldMove.left = isDown;
            }));
            AddComponent(new KeyInputComponent(Keys.D, anyHandler: (isDown) => {
                shouldMove.right = isDown;
            }));
            AddComponent(new ColliderComponent(
                collisionEnterHandler: (other) => {
                    if (other is Ground) {
                        PhysicsComponent physicsComponent = GetComponent<PhysicsComponent>();
                        if (physicsComponent.Velocity.Y >= 0) {
                            physicsComponent.GravityAffected = false;
                            physicsComponent.Velocity = new Vector2(physicsComponent.Velocity.X, 0);
                            Position = new UDim2(Position.X, new UDim(Position.Y.Scale, other.Bounds.Top - (int)AbsoluteSize.Y + 1));
                            onGround = true;
                        }
                    }
                },
                collisionLeaveHandler: (other) => {
                    if (onGround && other is Ground) {
                        onGround = false;
                        PhysicsComponent physicsComponent = GetComponent<PhysicsComponent>();
                        physicsComponent.GravityAffected = true;
                    }
                }
            ));
            AddComponent(new TextComponent() {
                FontReference = "fonts/roboto14",
                Text = "0",
                TextAnchor = new Vector2(0.5f, 0f),
                TextPosition = new UDim2(0.5f, 0, -1f, 0)
            });
        }

        public override void Update(GameTime gameTime) {
            // handle physics
            PhysicsComponent physicsComponent = GetComponent<PhysicsComponent>();
            Vector2 newVelocity = new Vector2(0, physicsComponent.Velocity.Y);
            if (shouldJump) {
                shouldJump = false;
                onGround = false;
                physicsComponent.GravityAffected = true;
                newVelocity = new Vector2(0, -JumpPower);
            }

            if (shouldMove.left != shouldMove.right) {
                newVelocity += new Vector2(shouldMove.left ? -WalkSpeed : WalkSpeed, 0);
            }
            physicsComponent.Velocity = newVelocity;

            // update sprite
            SheetImageComponent sheetImageComponent = GetComponent<SheetImageComponent>();
            if (shouldMove.left != shouldMove.right) {
                animationTimer += gameTime.ElapsedGameTime.Milliseconds / 150f;
                animationTimer %= 3;

                if (shouldMove.left) {
                    sheetImageComponent.CurrentRectangle = (int)Math.Floor(animationTimer) + 1;
                } else {
                    sheetImageComponent.CurrentRectangle = (int)Math.Floor(animationTimer) + 5;
                }
            } else {
                if (sheetImageComponent.CurrentRectangle <= 3) {
                    sheetImageComponent.CurrentRectangle = 3;
                } else {
                    sheetImageComponent.CurrentRectangle = 4;
                }
            }

            base.Update(gameTime);

            // update score text
            TextComponent textComponent = GetComponent<TextComponent>();
            textComponent.Text = Score.ToString("#,##0").Replace(",", " ");

            // wrap position around if necessary
            if (AbsolutePosition.X > SceneManager.Instance.GraphicsDevice.Viewport.Width + AbsoluteSize.X) {
                Position = new UDim2(new UDim(Position.X.Scale, -(int)AbsoluteSize.X), Position.Y);
            } else if (AbsolutePosition.X < -AbsoluteSize.X) {
                Position = new UDim2(new UDim(Position.X.Scale, (int)(SceneManager.Instance.GraphicsDevice.Viewport.Width + AbsoluteSize.X)), Position.Y);
            }

            if (AbsolutePosition.Y > SceneManager.Instance.GraphicsDevice.Viewport.Height + AbsoluteSize.Y) {
                Position = new UDim2(Position.X, new UDim(Position.Y.Scale, -(int)AbsoluteSize.Y));
            } else if (AbsolutePosition.Y < -AbsoluteSize.Y) {
                Position = new UDim2(Position.X, new UDim(Position.Y.Scale, (int)(SceneManager.Instance.GraphicsDevice.Viewport.Height + AbsoluteSize.Y)));
            }
        }
    }
}
