using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Framework.Scene {
    public class SceneManager {
        public static SceneManager Instance { get; } = new SceneManager();
        public GameScene CurrentScene { get; private set; }

        public GraphicsDevice GraphicsDevice { get; set; }
        public InputState InputState { get; } = new InputState();

        private SceneManager() { }

        public void ChangeScene(GameScene newScene) {
            AssetManager.Instance.UnloadAll();
            CurrentScene = newScene;
        }

        public void Update(GameTime gameTime) {
            InputState.Update();
            CurrentScene?.HandleInput(InputState);
            CurrentScene?.Update(gameTime);

            if (InputState.IsKeyDown(Keys.F1)) {
                GameObject.DrawDebugBounds = true;
            } else if (InputState.IsKeyDown(Keys.F2)) {
                GameObject.DrawDebugBounds = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            CurrentScene?.Draw(spriteBatch);

            if (GameObject.DrawDebugBounds) {
                spriteBatch.Draw(AssetManager.BlankTexture, new Rectangle(0, 10, GraphicsDevice.Viewport.Width, 1), Color.Blue);
                spriteBatch.Draw(AssetManager.BlankTexture, new Rectangle(0, GraphicsDevice.Viewport.Height - 10, GraphicsDevice.Viewport.Width, 1), Color.Blue);
                spriteBatch.Draw(AssetManager.BlankTexture, new Rectangle(10, 0, 1, GraphicsDevice.Viewport.Height), Color.Blue);
                spriteBatch.Draw(AssetManager.BlankTexture, new Rectangle(GraphicsDevice.Viewport.Width - 10, 0, 1, GraphicsDevice.Viewport.Height), Color.Blue);
                
                spriteBatch.Draw(AssetManager.BlankTexture, new Rectangle(0, GraphicsDevice.Viewport.Height / 2, GraphicsDevice.Viewport.Width, 1), Color.Black);
                spriteBatch.Draw(AssetManager.BlankTexture, new Rectangle(GraphicsDevice.Viewport.Width / 2, 0, 1, GraphicsDevice.Viewport.Height), Color.Black);
            }
        }
    }
}
