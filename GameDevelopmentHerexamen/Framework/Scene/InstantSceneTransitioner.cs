using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Framework.Scene {
    public class InstantSceneTransitioner(GameScene gameScene) : ISceneTransitioner {
        public bool IsTransitioning { get; set; } = true;
        public GameScene NewScene { get; set; } = gameScene;

        public void Draw(SpriteBatch spriteBatch) { }

        public void Update(GameTime gameTime) {
            if (!IsTransitioning) return;
            SceneManager.Instance.ChangeScene(NewScene);
            IsTransitioning = false;
        }
    }
}
