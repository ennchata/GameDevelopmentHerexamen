using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Object.Component;
using GameDevelopmentHerexamen.Framework.Utility;
using GameDevelopmentHerexamen.Implementation.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Object.Gameplay {
    public class Coin : GameObject {
        private bool used = false;

        public Coin(UDim initialXPosition) {
            AddComponent(new ImageComponent() {
                AssetReference = "images/coin"
            });
            AddComponent(new PhysicsComponent() {
                Gravity = 1000,
                TerminalYVelocity = 220
            });
            AddComponent(new ColliderComponent(collisionEnterHandler: (other) => {
                if (!used && other is Player) {
                    Player.Score++;
                    IsVisible = false;
                    used = true;
                }
            }));

            Size = new UDim2(0, 30, 0, 35);
            Position = new UDim2(initialXPosition, new UDim(0, -50));
        }
    }
}
