using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Framework.Object.Component {
    public class UpdateComponent(Action<GameObject, GameTime> action) : IComponent {
        private readonly Action<GameObject, GameTime> action = action;

        public int Order { get; set; } = 0;

        public void Update(GameObject owner, GameTime gameTime) {
            action.Invoke(owner, gameTime);
        }
    }
}
