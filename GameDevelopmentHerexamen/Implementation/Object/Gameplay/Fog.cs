using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Implementation.Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Object.Gameplay {
    public class Fog : GameObject {
        public Fog() {
            AddComponent(new ImageComponent() {
                AssetReference = "images/Vignette"
            });
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            ImageComponent imageComponent = GetComponent<ImageComponent>();
            float alpha = 1f - Math.Clamp(Player.Score / 10f, 0.1f, 1f);
            imageComponent.Color = new Color(1f, 1f, 1f, alpha);
        }
    }
}
