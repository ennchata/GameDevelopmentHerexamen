using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Object.Component;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Object.Input {
    public class KeyHandlerObject : GameObject {
        public Keys Key { get; set; }

        public delegate void StateChangedEventHandler(Keys key, bool isDown);
        public event StateChangedEventHandler StateChanged;

        private bool previousState = false;

        public KeyHandlerObject(Keys key,
                Action<Keys, bool>? anyHandler = null,
                Action<Keys>? keyDownHandler = null,
                Action<Keys>? keyUpHandler = null) {
            Key = key;

            if (anyHandler != null) {
                StateChanged += anyHandler.Invoke;
            }

            if (keyDownHandler != null) {
                StateChanged += (key, isDown) => {
                    if (isDown) {
                        keyDownHandler.Invoke(key);
                    }
                };
            }

            if (keyUpHandler != null) {
                StateChanged += (key, isDown) => {
                    if (!isDown) {
                        keyUpHandler.Invoke(key);
                    }
                };
            }

            AddComponent(new InputComponent((owner, inputState) => {
                KeyHandlerObject handlerOwner = owner as KeyHandlerObject;
                bool state = inputState.IsKeyDown(handlerOwner.Key);
               
                if (handlerOwner.previousState != state) {
                    handlerOwner.previousState = state;
                    handlerOwner.StateChanged.Invoke(handlerOwner.Key, state);
                }
            }));
        }
    }
}
