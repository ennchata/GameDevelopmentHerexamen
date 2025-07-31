using GameDevelopmentHerexamen.Framework.Scene;
using GameDevelopmentHerexamen.Framework.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Scene.Transition {
    public class BlackFadeScreenTransitioner(GameScene gameScene, float length = 0.33f) : ISceneTransitioner {
        public bool IsTransitioning { get; set; } = true;
        public GameScene NewScene { get; set; } = gameScene;

        private bool shouldChange = false;
        private bool hasChanged = false;
        private readonly float length = length;
        private float currentTransparency = 0f;

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(AssetManager.BlankTexture, SceneManager.Instance.GraphicsDevice.Viewport.Bounds, Color.Black * currentTransparency);
        }

        public void Update(GameTime gameTime) {
            if (IsTransitioning && !shouldChange) {
                currentTransparency = Math.Clamp(currentTransparency + gameTime.ElapsedGameTime.Milliseconds / (1000f * length), 0f, 1f);

                if (currentTransparency == 1f) shouldChange = true;
            } else if (IsTransitioning && shouldChange) {
                currentTransparency = Math.Clamp(currentTransparency - gameTime.ElapsedGameTime.Milliseconds / (1000f * length), 0f, 1f);

                if (currentTransparency == 0f) IsTransitioning = false;
            }

            if (shouldChange && !hasChanged) {
                SceneManager.Instance.ChangeScene(NewScene);
                hasChanged = true;
            }
        }
    }
}
