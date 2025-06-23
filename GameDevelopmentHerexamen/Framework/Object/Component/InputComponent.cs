using GameDevelopmentHerexamen.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Framework.Object.Component {
    public class InputComponent(Action<GameObject, InputState> action) : IComponent {
        private readonly Action<GameObject, InputState> action = action;

        public int Order { get; set; } = 0;

        public void HandleInput(GameObject owner, InputState inputState) {
            action.Invoke(owner, inputState);
        }
    }
}
