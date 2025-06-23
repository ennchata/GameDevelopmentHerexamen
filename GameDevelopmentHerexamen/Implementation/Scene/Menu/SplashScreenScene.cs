using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Object.Component;
using GameDevelopmentHerexamen.Framework.Scene;
using GameDevelopmentHerexamen.Framework.Utility;
using GameDevelopmentHerexamen.Implementation.Component;
using GameDevelopmentHerexamen.Implementation.Object.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
                    new InputComponent((self, inputState) => {
                        if (inputState.IsKeyDown(Keys.Escape)) {
                            Game1.ShouldExit();
                        }
                    })
                ]
            },
            new TextObject("fonts/roboto36", "My First Platformer", textPosition: new UDim2(0.5f, 0, 0.25f, 0)),
            new TextObject("fonts/roboto14", "Game Development Herexamen - Thibo Maes", textAnchor: new Vector2(0f, 1f), textPosition: UDim2.BottomLeft + (10, -35)),
            new TextObject("fonts/roboto14", "Press [Esc] to close game", textAnchor: new Vector2(0f, 1f), textPosition: UDim2.BottomLeft + (10, -10))
        
        ]) { }
    }
}
