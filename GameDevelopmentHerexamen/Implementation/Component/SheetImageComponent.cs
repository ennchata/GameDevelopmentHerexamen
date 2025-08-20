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

        public void Draw(GameObject owner, SpriteBatch spriteBatch) {
            Texture2D texture = AssetManager.Instance.Load<Texture2D>(AssetReference);
            spriteBatch.Draw(texture, owner.Bounds, SourceRectangles[CurrentRectangle], Color.White);
        }
    }
}
