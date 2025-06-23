using GameDevelopmentHerexamen.Framework.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Framework.Object.Component {
    public interface IComponent {
        public int Order { get; set; }

        public void Update(GameObject owner, GameTime gameTime) { }
        public void Draw(GameObject owner, SpriteBatch spriteBatch) { }
        public void HandleInput(GameObject owner, InputState inputState) { }
    }
}
