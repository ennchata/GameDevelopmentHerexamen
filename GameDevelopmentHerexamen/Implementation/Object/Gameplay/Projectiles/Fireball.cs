using GameDevelopmentHerexamen.Framework.Utility;
using GameDevelopmentHerexamen.Implementation.Component;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Object.Gameplay.Projectiles {
    public class Fireball : Projectile {
        private float animationTimer = 0;

        public Fireball(bool leftToRight, int velocity, UDim initialY) : base(
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
                    Flip = (!leftToRight, false)
                },
                (owner, deltaTime, playerReference) => {
                    if (leftToRight) {
                        return new UDim2(0, (int)(velocity * deltaTime), 0, 0);
                    }
                    return new UDim2(0, (int)(-velocity * deltaTime), 0, 0);
                }
                ) {
            Position = new UDim2(
                new UDim(leftToRight ? 0f : 1f, leftToRight ? -36 : 36),
                initialY
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
