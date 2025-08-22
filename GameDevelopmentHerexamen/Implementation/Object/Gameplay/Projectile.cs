using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Object.Component;
using GameDevelopmentHerexamen.Framework.Scene;
using GameDevelopmentHerexamen.Framework.Utility;
using GameDevelopmentHerexamen.Implementation.Component;
using GameDevelopmentHerexamen.Implementation.Scene.Gameplay;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Object.Gameplay {
    public class Projectile : GameObject {
        private Player? playerReference;
        private Func<Projectile, float, Player?, UDim2> movementStepFunction;

        public Projectile(SheetImageComponent sheetImageComponent, Func<Projectile, float, Player?, UDim2> movementStepFunction, Player? playerReference = null): base() {
            AddComponent(sheetImageComponent);
            AddComponent(new ColliderComponent(collisionEnterHandler: (other) => {
                if (other is Player) {
                    SceneManager.Instance.TransitionScene(new InstantSceneTransitioner(new GameOverScene(false, (other as Player).Score)));
                }
            }));

            this.playerReference = playerReference;
            this.movementStepFunction = movementStepFunction;
        }

        public override void Update(GameTime gameTime) {
            Position += movementStepFunction.Invoke(this, gameTime.ElapsedGameTime.Milliseconds / 1000f, playerReference);

            base.Update(gameTime);
        }
    }
}
