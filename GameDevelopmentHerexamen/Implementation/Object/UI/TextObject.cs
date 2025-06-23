using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Utility;
using GameDevelopmentHerexamen.Implementation.Component;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Object.UI {
    public class TextObject : GameObject {
        public TextObject(
                string fontReference, 
                string text, 
                Color? textColor = null, 
                Vector2? textAnchor = null, 
                UDim2? textPosition = null) {
            AddComponent(new TextComponent() {
                FontReference = fontReference,
                Text = text,
                TextColor = textColor ?? Color.White,
                TextAnchor = textAnchor ?? new Vector2(0.5f),
                TextPosition = textPosition ?? UDim2.CenterCenter
            });
        }
    }
}
