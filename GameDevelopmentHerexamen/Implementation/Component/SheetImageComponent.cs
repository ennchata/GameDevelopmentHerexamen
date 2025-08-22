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
    public class SheetImageComponent : IComponent {
        public string AssetReference { get; set; }
        public Rectangle[] SourceRectangles { get; set; }
        public int CurrentRectangle { get; set; }

        public int Order { get; set; } = 0;

        public (bool Horizontal, bool Vertical) Flip { get; set; } = (false, false);

        public void Draw(GameObject owner, SpriteBatch spriteBatch) {
            Texture2D texture = AssetManager.Instance.Load<Texture2D>(AssetReference);

            SpriteEffects effects = SpriteEffects.None;
            if (Flip.Horizontal) effects |= SpriteEffects.FlipHorizontally;
            if (Flip.Vertical) effects |= SpriteEffects.FlipVertically;

            spriteBatch.Draw(texture, owner.Bounds, SourceRectangles[CurrentRectangle], Color.White, 0f, Vector2.Zero, effects, 0f);
        }
    }
}