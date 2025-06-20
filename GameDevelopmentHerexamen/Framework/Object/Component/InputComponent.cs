﻿using GameDevelopmentHerexamen.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Framework.Object.Component {
    public class InputComponent(Action<GameObject, InputState> action) : IComponent {
        private readonly Action<GameObject, InputState> action = action;

        public void Draw(GameObject owner, InputState inputState) {
            action.Invoke(owner, inputState);
        }
    }
}
