using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Object.Component;
using GameDevelopmentHerexamen.Framework.Utility;
using GameDevelopmentHerexamen.Implementation.Component;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Object.UI {
    public class TextButton : GameObject {
        public Color ButtonColor { get; set; }
        public Color HoverColor { get; set; }
        public bool Hovering { get; private set; }

        public TextButton(
                TextComponent textComponent,
                Action onClick,
                Color buttonColor,
                Color? hoverColor = null) {
            ButtonColor = buttonColor;
            HoverColor = hoverColor ?? Color.Lerp(ButtonColor, Color.Black, 0.1f);

            AddComponent(new MouseInputComponent(
                hoverHandler: (isHovering) => { Hovering = isHovering; },
                clickHandler: onClick
            ));
            AddComponent(new DrawComponent((owner, spriteBatch) => {
                TextButton ownerTextButton = owner as TextButton;
                spriteBatch.Draw(AssetManager.BlankTexture, owner.Bounds, 
                    ownerTextButton.Hovering ? ownerTextButton.HoverColor : ownerTextButton.ButtonColor
                );
            }));
            AddComponent(textComponent);
            
        }
    }
}
