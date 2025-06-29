using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Object.Component;
using GameDevelopmentHerexamen.Framework.Utility;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Component {
    public class MouseInputComponent : IComponent {
        public int Order { get; set; } = 0;

        public delegate void MouseInputEventHandler(bool isClicked, bool isHovering);
        public event MouseInputEventHandler InputEvent;
        private (bool isClicked, bool isHovering) previousState;

        public MouseInputComponent(
                Action<bool, bool> anyHandler = null,
                Action<bool> hoverHandler = null,
                Action clickHandler = null) {
            InputEvent += (isClicked, isHovering) => {
                anyHandler?.Invoke(isClicked, isHovering);
            };


            InputEvent += (_, isHovering) => {
                if (previousState.isHovering != isHovering) {
                    hoverHandler?.Invoke(isHovering);
                }
            };


            InputEvent += (isClicked, isHovering) => {
                if (previousState.isClicked && !isClicked && isHovering) {
                    clickHandler?.Invoke();
                }
            };
        }

        public void HandleInput(GameObject owner, InputState inputState) {
            Rectangle mouseBounds = new Rectangle(inputState.MouseState.Position, Point.Zero);

            owner.Bounds.Intersects(ref mouseBounds, out bool isHovering);
            bool isClicked = isHovering && inputState.IsLeftClickPressed();

            if (previousState.isClicked != isClicked || previousState.isHovering != isHovering) {
                InputEvent.Invoke(isClicked, isHovering);
            }

            previousState = (isClicked, isHovering);
        }
    }
}
