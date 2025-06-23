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
    public class TextComponent : IComponent {
        public string FontReference { get; set; }
        public string Text { get; set; }
        public Color TextColor { get; set; } = Color.White;
        public Vector2 TextAnchor { get; set; } = new Vector2(0.5f);
        public UDim2 TextPosition { get; set; } = UDim2.CenterCenter;
        public int Order { get; set; } = 0;

        public Rectangle AbsoluteTextBounds { get; private set; }
        public Vector2 AbsoluteTextSize { get; private set; }
        public Vector2 AbsoluteTextPosition { get; private set; }

        public void Draw(GameObject owner, SpriteBatch spriteBatch) {
            SpriteFont spriteFont = AssetManager.Instance.Load<SpriteFont>(FontReference);

            spriteBatch.DrawString(spriteFont, Text, AbsoluteTextPosition, TextColor);

            if (GameObject.DrawDebugBounds && AssetManager.BlankTexture != null) {
                spriteBatch.Draw(AssetManager.BlankTexture, new Rectangle(AbsoluteTextBounds.X, AbsoluteTextBounds.Y, AbsoluteTextBounds.Width, 1), Color.Red);
                spriteBatch.Draw(AssetManager.BlankTexture, new Rectangle(AbsoluteTextBounds.X, AbsoluteTextBounds.Bottom, AbsoluteTextBounds.Width, 1), Color.Red);
                spriteBatch.Draw(AssetManager.BlankTexture, new Rectangle(AbsoluteTextBounds.X, AbsoluteTextBounds.Y, 1, AbsoluteTextBounds.Height), Color.Red);
                spriteBatch.Draw(AssetManager.BlankTexture, new Rectangle(AbsoluteTextBounds.Right, AbsoluteTextBounds.Y, 1, AbsoluteTextBounds.Height), Color.Red);
            }
        }

        public void Update(GameObject owner, GameTime gameTime) {
            SpriteFont spriteFont = AssetManager.Instance.Load<SpriteFont>(FontReference);

            AbsoluteTextSize = spriteFont.MeasureString(Text);
            AbsoluteTextPosition = owner.AbsolutePosition + TextPosition.Resolve(owner.AbsoluteSize) - AbsoluteTextSize * TextAnchor;
            AbsoluteTextBounds = new Rectangle(
                (int)AbsoluteTextPosition.X, (int)AbsoluteTextPosition.Y,
                (int)AbsoluteTextSize.X, (int)AbsoluteTextSize.Y
            );
        }
    }
}
