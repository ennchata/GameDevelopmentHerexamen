using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Object.Component;
using GameDevelopmentHerexamen.Framework.Scene;
using GameDevelopmentHerexamen.Framework.Utility;
using GameDevelopmentHerexamen.Implementation.Component;
using GameDevelopmentHerexamen.Implementation.Object.UI;
using GameDevelopmentHerexamen.Implementation.Scene.Menu;
using GameDevelopmentHerexamen.Implementation.Scene.Transition;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Scene.Gameplay {
    public class GameOverScene : GameScene {
        public GameOverScene(bool didWin, int score = -1) : base([
            new GameObject() {
                Components = [
                    new DrawComponent((owner, spriteBatch) => {
                        spriteBatch.Draw(AssetManager.BlankTexture, owner.Bounds, Color.DarkSlateGray);
                    })
                ]
            },
            new TextObject("fonts/roboto36", didWin ? "You won!" : "Game over!", textPosition: new UDim2(0.5f, 0, 1f/8f, 0), textColor: didWin ? Color.LightGreen : Color.LightSalmon),
            new TextObject("fonts/roboto14", $"Score: {score.ToString("#,##0").Replace(",", " ")}", textPosition: new UDim2(0.5f, 0, 1f/4f, 0)),
            new TextButton(
                new TextComponent() {
                    FontReference = "fonts/roboto14",
                    Text = "Return to Menu",
                    TextColor = Color.Black
                },
                () => {
                    SceneManager.Instance.TransitionScene(new BlackFadeScreenTransitioner(new SplashScreenScene()));
                },
                Color.LightGoldenrodYellow
            ) {
                Size = new UDim2(0.25f, 0, 0.1f, 0),
                Position = UDim2.CenterCenter - new UDim2(0f, 0, 0.1f, 10),
                Anchor = Vector2.One / 2f
            },
        ]) { }
    }
}
