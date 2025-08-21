using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Object.Component;
using GameDevelopmentHerexamen.Framework.Utility;
using GameDevelopmentHerexamen.Implementation.Component;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Object.Gameplay {
    public class Ground : GameObject {
        public Ground() {
            AddComponent(new ColliderComponent());
            AddComponent(new SheetImageComponent() {
                AssetReference = "images/blocks",
                SourceRectangles = [
                    new Rectangle(272, 192, 16, 16)
                ],
                CurrentRectangle = 0
            });
        }
    }
}
