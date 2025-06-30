using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Object.Component;
using GameDevelopmentHerexamen.Framework.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Component {
    public class RainbowBackgroundComponent : IComponent {
        public int Order { get; set; } = 0;
        public float Hue { get => hue; set { hue = value % 360; } }
        public float Velocity { get; set; } = 15; 

        private float hue;

        public void Update(GameObject owner, GameTime gameTime) {
            Hue += Velocity * gameTime.ElapsedGameTime.Milliseconds / 1000;
        }

        public void Draw(GameObject owner, SpriteBatch spriteBatch) {
            spriteBatch.Draw(AssetManager.BlankTexture, owner.Bounds, HsvToColor(Hue, 1, 0.33f));
        }

        private Color HsvToColor(float h, float s, float v) {
            float r = 0, g = 0, b = 0;

            if (s == 0) {
                r = g = b = v;
            } else {
                h = h % 360; // Wrap hue around
                h /= 60;
                int i = (int)h;
                float f = h - i;
                float p = v * (1 - s);
                float q = v * (1 - s * f);
                float t = v * (1 - s * (1 - f));

                switch (i) {
                    case 0: r = v; g = t; b = p; break;
                    case 1: r = q; g = v; b = p; break;
                    case 2: r = p; g = v; b = t; break;
                    case 3: r = p; g = q; b = v; break;
                    case 4: r = t; g = p; b = v; break;
                    case 5: default: r = v; g = p; b = q; break;
                }
            }

            return new Color(
                (byte)(r * 255),
                (byte)(g * 255),
                (byte)(b * 255)
            );
        }
    }
}
