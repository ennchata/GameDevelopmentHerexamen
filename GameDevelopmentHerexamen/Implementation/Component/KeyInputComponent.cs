using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Object.Component;
using GameDevelopmentHerexamen.Framework.Utility;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Component {
    public class KeyInputComponent : IComponent {
        public Keys Key { get; set; }
        public int Order { get; set; } = 0;

        public delegate void KeyInputEventHandler(bool state);
        public event KeyInputEventHandler InputEvent;
        private bool previousState = false;

        public KeyInputComponent(Keys key,
                Action<bool> anyHandler = null,
                Action keyDownHandler = null,
                Action keyUpHandler = null) {
            Key = key;

            if (anyHandler != null) {
                InputEvent += anyHandler.Invoke;
            }

            if (keyDownHandler != null) {
                InputEvent += (isDown) => {
                    if (isDown) {
                        keyDownHandler.Invoke();
                    }
                };
            }

            if (keyUpHandler != null) {
                InputEvent += (isDown) => {
                    if (!isDown) {
                        keyUpHandler.Invoke();
                    }
                };
            }
        }

        public void HandleInput(GameObject owner, InputState inputState) {
            bool state = inputState.IsKeyDown(Key);
            if (previousState != state) {
                previousState = state;
                InputEvent.Invoke(state);
            }
        }
    }
}
