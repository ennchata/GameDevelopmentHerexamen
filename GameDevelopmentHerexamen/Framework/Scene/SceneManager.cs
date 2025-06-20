using GameDevelopmentHerexamen.Framework.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Framework.Scene {
    public class SceneManager {
        public static SceneManager Instance { get; } = new SceneManager();
        public Scene CurrentScene { get; private set; }

        public GraphicsDevice GraphicsDevice { get; set; }
        public InputState InputState { get; } = new InputState();

        private SceneManager() { }

        public void ChangeScene(Scene newScene) {
            AssetManager.Instance.UnloadAll();
            CurrentScene = newScene;
        }

        public void Update(GameTime gameTime) {
            InputState.Update();
            CurrentScene?.HandleInput(InputState);
            CurrentScene?.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) {
            CurrentScene?.Draw(spriteBatch);
        }
    }
}
