using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Object.Component;
using GameDevelopmentHerexamen.Framework.Scene;
using GameDevelopmentHerexamen.Framework.Utility;
using GameDevelopmentHerexamen.Implementation.Component;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Scene.Menu {
    public class SplashScreenScene : GameScene {
        public static float BackgroundHue = 0f;

        public SplashScreenScene() : base([
            new GameObject() {
                    Components = [
                        new DrawComponent((self, spriteBatch) => {
                            Color color = FromHSV(BackgroundHue, 1, 0.25f);
                            spriteBatch.Draw(AssetManager.BlankTexture, self.Bounds, color);
                        }),
                        new UpdateComponent((self, gameTime) => {
                            BackgroundHue += gameTime.ElapsedGameTime.Milliseconds / 60f;
                            BackgroundHue %= 360;
                        })
                    ]
                },
                new TextObject() {
                    FontReference = "fonts/roboto36",
                    Text = "My First Platformer",
                    TextAnchor = new Vector2(0.5f, 1),
                    TextPosition = UDim2.CenterCenter - (0, 24)
                },
                new TextObject() {
                    FontReference = "fonts/roboto14",
                    Text = "Game Development Herexamen - Thibo Maes",
                    TextPosition = UDim2.CenterCenter
                }
        ]) { }

        public static Color FromHSV(float hue, float saturation, float value) {
            hue = hue % 360;
            if (hue < 0) hue += 360;

            float c = value * saturation;
            float x = c * (1 - MathF.Abs((hue / 60f) % 2 - 1));
            float m = value - c;

            float r, g, b;

            if (hue < 60) {
                r = c; g = x; b = 0;
            } else if (hue < 120) {
                r = x; g = c; b = 0;
            } else if (hue < 180) {
                r = 0; g = c; b = x;
            } else if (hue < 240) {
                r = 0; g = x; b = c;
            } else if (hue < 300) {
                r = x; g = 0; b = c;
            } else {
                r = c; g = 0; b = x;
            }

            int rByte = (int)((r + m) * 255);
            int gByte = (int)((g + m) * 255);
            int bByte = (int)((b + m) * 255);

            return new Color(rByte, gByte, bByte);
        }
    }
}
