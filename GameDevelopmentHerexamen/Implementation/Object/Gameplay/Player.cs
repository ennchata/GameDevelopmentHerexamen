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

            AddComponent(new KeyInputComponent(Keys.W, keyDownHandler: () => { Move(Vector2.One * 10); }));
        }

        public void Move(Vector2 offset) {
            Position += offset;
        }
    }
}
