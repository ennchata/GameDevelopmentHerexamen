using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Framework.Scene {
    public interface ISceneTransitioner {
        public bool IsTransitioning { get; set; }
        public GameScene NewScene { get; set; }

        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch);
    }
}
