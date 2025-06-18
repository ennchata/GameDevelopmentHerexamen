using GameDevelopmentHerexamen.Framework.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Framework.GameObject {
    public interface IGameObject {
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
        public void HandleInput(InputState inputState);
    }
}
