using GameDevelopmentHerexamen.Framework.Utility;
using GameDevelopmentHerexamen.Implementation.Component;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Object.Gameplay.Projectiles {
    public class TrackingFireball : Projectile {
        private float animationTimer = 0;

        public TrackingFireball(bool leftToRight, bool topToBottom, int velocity, Player playerReference) : base(
                new SheetImageComponent() {
                    AssetReference = "images/FB",
                    CurrentRectangle = 0,
                    SourceRectangles = [
                        new Rectangle(18, 6, 35, 17),
                        new Rectangle(18, 38, 35, 17),
                        new Rectangle(18, 70, 35, 17),
                        new Rectangle(18, 102, 35, 17),
                        new Rectangle(18, 134, 35, 17),
                    ],
                    Color = Color.Lerp(Color.White, Color.Red, 0.5f),
                    Flip = (!leftToRight, false)
                },
                (owner, deltaTime, playerReference) => {
                    Vector2 toPlayer = playerReference.AbsolutePosition - owner.AbsolutePosition;
                    toPlayer.Normalize();
                    Vector2 toPlayerAbsolute = new Vector2(Math.Abs(toPlayer.X), Math.Abs(toPlayer.Y)) * velocity;

                    if (leftToRight) {
                        return new UDim2(
                            0, (int)((toPlayerAbsolute.X) * deltaTime),
                            0, topToBottom ? (int)((toPlayerAbsolute.Y) * deltaTime) : (int)(-(toPlayerAbsolute.Y) * deltaTime)
                        );
                    } else {
                        return new UDim2(
                            0, (int)(-(toPlayerAbsolute.X) * deltaTime),
                            0, topToBottom ? (int)((toPlayerAbsolute.Y) * deltaTime) : (int)(-(toPlayerAbsolute.Y) * deltaTime)
                        );
                    }
                },
                playerReference
                ) {
            Position = new UDim2(
                new UDim(leftToRight ? 0f : 1f, leftToRight ? -36 : 36),
                new UDim(topToBottom ? 0f : 1f, topToBottom ? -18 : 18)
            );
            Size = new UDim2(0, 80, 0, 40);
        }

        public override void Update(GameTime gameTime) {
            animationTimer += gameTime.ElapsedGameTime.Milliseconds / 150f;
            animationTimer %= 5;

            SheetImageComponent sheetImageComponent = GetComponent<SheetImageComponent>();
            sheetImageComponent.CurrentRectangle = (int)Math.Floor(animationTimer);

            base.Update(gameTime);
        }
    }
}
