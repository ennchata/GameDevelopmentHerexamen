using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Scene;
using GameDevelopmentHerexamen.Framework.Utility;
using GameDevelopmentHerexamen.Implementation.Component;
using GameDevelopmentHerexamen.Implementation.Object.UI;
using GameDevelopmentHerexamen.Implementation.Scene.Gameplay;
using GameDevelopmentHerexamen.Implementation.Scene.Transition;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Scene.Menu {
    public class LevelSelectionScene : GameScene {
        public LevelSelectionScene() : base([
            new GameObject() {
                Components = [ new KeyInputComponent(Keys.Escape, keyUpHandler: () => {
                    SceneManager.Instance.TransitionScene(new BlackFadeScreenTransitioner(new SplashScreenScene()));
                }) ]
            },
            new GameObject() {
                Components = [ new RainbowBackgroundComponent() ],
                ZIndex = -100
            },
            new TextObject("fonts/roboto36", "Select Level", textPosition: new UDim2(0.5f, 0, 1f/8f, 0)),
            new TextObject("fonts/roboto14", "[Esc] - Return to main menu", textAnchor: new Vector2(0f, 1f), textPosition: UDim2.BottomLeft + (10, -10)),
            new TextButton(
                new TextComponent() {
                    FontReference = "fonts/roboto14",
                    Text = "Solo",
                    TextColor = Color.Black
                },
                () => {
                    SceneManager.Instance.TransitionScene(new BlackFadeScreenTransitioner(new SingleplayerScene()));
                },
                Color.LightGreen
            ) {
                Size = new UDim2(0.25f, 0, 0.1f, 0),
                Position = UDim2.CenterCenter - new UDim2(0f, 0, 0.1f, 10),
                Anchor = Vector2.One / 2f
            },
            new TextButton(
                new TextComponent() {
                    FontReference = "fonts/roboto14",
                    Text = "Versus",
                    TextColor = Color.Black
                },
                () => {

                },
                Color.Salmon
            ) {
                Size = new UDim2(0.25f, 0, 0.1f, 0),
                Position = UDim2.CenterCenter,
                Anchor = Vector2.One / 2f
            }
        ]) { }
    }
}
