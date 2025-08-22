using GameDevelopmentHerexamen.Framework.Utility;
using GameDevelopmentHerexamen.Implementation.Component;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Object.Gameplay.Projectiles {
    public class FakeCoin : Projectile {
        public FakeCoin(UDim initialX, Player playerReference) : base(
            new SheetImageComponent() {
                AssetReference = "images/coin",
                SourceRectangles = [new Rectangle(0, 0, 48, 59)],
                CurrentRectangle = 0,
                Color = Color.LightSalmon
            },
            (owner, deltaTime, playerReference) => {
                return new UDim2(
                    0, (int)((playerReference.AbsolutePosition.X - owner.AbsolutePosition.X) * deltaTime),
                    0, (int)(180 * deltaTime)
                );
            },
            playerReference
        ) {
            Size = new UDim2(0, 30, 0, 35);
            Position = new UDim2(initialX, new UDim(0, -60));
        }
    }
}
