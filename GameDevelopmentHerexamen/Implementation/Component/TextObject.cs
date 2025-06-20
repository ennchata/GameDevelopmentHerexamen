using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Object.Component;
using GameDevelopmentHerexamen.Framework.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Component {
    public class TextObject : GameObject {
        public string FontReference { get; set; }
        public string Text { get; set; }
        public Color TextColor { get; set; } = Color.White;
        public Vector2 TextAnchor { get; set; } = new Vector2(0.5f);
        public UDim2 TextPosition { get; set; } = UDim2.CenterCenter;

        public TextObject() {
            AddComponent(new DrawComponent((self, spriteBatch) => {
                TextObject textSelf = self as TextObject;
                SpriteFont spriteFont = AssetManager.Instance.Load<SpriteFont>(textSelf.FontReference);

                Vector2 textSize = spriteFont.MeasureString(textSelf.Text);
                Vector2 textPosition = textSelf.AbsolutePosition + textSelf.TextPosition.Resolve(textSelf.AbsoluteSize) - textSize * textSelf.TextAnchor;

                spriteBatch.DrawString(spriteFont, textSelf.Text, textPosition, textSelf.TextColor);

                if (DrawDebugBounds && AssetManager.BlankTexture != null) {
                    Rectangle TextBounds = new Rectangle(
                        (int)textPosition.X, (int)textPosition.Y,
                        (int)textSize.X, (int)textSize.Y
                    );

                    spriteBatch.Draw(AssetManager.BlankTexture, new Rectangle(TextBounds.X, TextBounds.Y, TextBounds.Width, 1), Color.Red);
                    spriteBatch.Draw(AssetManager.BlankTexture, new Rectangle(TextBounds.X, TextBounds.Bottom, TextBounds.Width, 1), Color.Red);
                    spriteBatch.Draw(AssetManager.BlankTexture, new Rectangle(TextBounds.X, TextBounds.Y, 1, TextBounds.Height), Color.Red);
                    spriteBatch.Draw(AssetManager.BlankTexture, new Rectangle(TextBounds.Right, TextBounds.Y, 1, TextBounds.Height), Color.Red);
                }
            }));
        }
    }
}
