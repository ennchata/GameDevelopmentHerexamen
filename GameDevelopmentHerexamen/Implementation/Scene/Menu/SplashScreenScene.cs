using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Object.Component;
using GameDevelopmentHerexamen.Framework.Scene;
using GameDevelopmentHerexamen.Framework.Utility;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Scene.Menu {
    public class SplashScreenScene : GameScene {
        public SplashScreenScene() : base([
            new GameObject() {
                Components = [
                    new DrawComponent((self, spriteBatch) => {
                        spriteBatch.Draw(AssetManager.BlankTexture, self.Bounds, Color.White);
                    })
                ],
                Size = new UDim2(0.5f, 0, 0.5f, 0),
                Position = new UDim2(0.5f, 0, 0f, 0),
                Anchor = Vector2.One * 0.5f
            }
        ]) { }
    }
}
