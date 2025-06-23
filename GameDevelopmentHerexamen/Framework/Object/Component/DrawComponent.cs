using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Framework.Object.Component {
    public class DrawComponent(Action<GameObject, SpriteBatch> action) : IComponent {
        private readonly Action<GameObject, SpriteBatch> action = action;

        public int Order { get; set; } = 0;

        public void Draw(GameObject owner, SpriteBatch spriteBatch) {
            action.Invoke(owner, spriteBatch);
        }
    }
}
