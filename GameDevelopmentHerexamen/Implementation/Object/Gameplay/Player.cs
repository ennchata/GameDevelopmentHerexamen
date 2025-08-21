using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Utility;
using GameDevelopmentHerexamen.Implementation.Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Object.Gameplay {
    public class Player : GameObject {
        public int JumpPower { get; set; } = 750;
        public int WalkSpeed { get; set; } = 450;

        private bool shouldJump = false;
        private bool onGround = false;
        private (bool left, bool right) shouldMove = (false, false);

        public Player(UDim2 initialPosition) {
            Position = initialPosition;
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
                shouldJump = true;
            }));
            AddComponent(new KeyInputComponent(Keys.Q, anyHandler: (isDown) => {
                shouldMove.left = isDown;
            }));
            AddComponent(new KeyInputComponent(Keys.D, anyHandler: (isDown) => {
                shouldMove.right = isDown;
            }));
        }

        public override void Update(GameTime gameTime) {
            PhysicsComponent physicsComponent = GetComponent<PhysicsComponent>();
            Vector2 newVelocity = new Vector2(0, physicsComponent.Velocity.Y);
            if (shouldJump) {
                shouldJump = false;
                newVelocity = new Vector2(0, -JumpPower);
            }

            if (shouldMove.left != shouldMove.right) {
                newVelocity += new Vector2(shouldMove.left ? -WalkSpeed : WalkSpeed, 0);
            }
            physicsComponent.Velocity = newVelocity;

            SheetImageComponent sheetImageComponent = GetComponent<SheetImageComponent>();
            if (!onGround) {
                sheetImageComponent.CurrentRectangle = physicsComponent.Velocity.X == 0 ? sheetImageComponent.CurrentRectangle : (physicsComponent.Velocity.X < 0 ? 3 : 4);
            }
            
            base.Update(gameTime);
        }
    }
}
