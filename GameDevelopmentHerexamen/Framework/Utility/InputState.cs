using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Framework.Utility {
    public class InputState {
        public KeyboardState KeyboardState { get; private set; }
        public MouseState MouseState { get; private set; }

        public void Update() {
            KeyboardState = Keyboard.GetState();
            MouseState = Mouse.GetState();
        }

        public bool IsKeyDown(Keys key) => KeyboardState.IsKeyDown(key);
        public bool IsLeftClickPressed() => MouseState.LeftButton == ButtonState.Pressed;
    }
}
