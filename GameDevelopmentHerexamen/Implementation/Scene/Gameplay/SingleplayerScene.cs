using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Scene;
using GameDevelopmentHerexamen.Framework.Utility;
using GameDevelopmentHerexamen.Implementation.Component;
using GameDevelopmentHerexamen.Implementation.Object.Gameplay;
using GameDevelopmentHerexamen.Implementation.Object.Gameplay.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Scene.Gameplay {
    public class SingleplayerScene : GameScene {
        public Player[] Players { get; private set; } 

        private ProjectileFactory projectileFactory;
        private float projectileTimer = 0;
        private float coinTimer = 0;
        private Random random = new Random();

        public SingleplayerScene() : base([
            new GameObject() {
                Components = [
                    new ImageComponent() {
                        AssetReference = "images/bg",
                        Color = Color.Gray
                    }
                ]
            },
            new Ground() {
                Position = UDim2.BottomCenter,
                Anchor = new Vector2(0.5f, 1),
                Size = new UDim2(0.25f, 0, 0, 16)
            },
            new Ground() {
                Position = new UDim2(0.25f, 0, 0.75f, 0),
                Anchor = new Vector2(0.5f, 1),
                Size = new UDim2(0.25f, 0, 0, 16)
            },
            new Ground() {
                Position = new UDim2(0.5f, 0, 0.2f, 0),
                Anchor = new Vector2(0.5f, 1),
                Size = new UDim2(0.25f, 0, 0, 16)
            },
            new Ground() {
                Position = new UDim2(0.75f, 0, 0.75f, 0),
                Anchor = new Vector2(0.5f, 1),
                Size = new UDim2(0.25f, 0, 0, 16)
            },
            new Ground() {
                Position = new UDim2(0, 0, 0.5f, 0),
                Anchor = new Vector2(0, 1),
                Size = new UDim2(0.25f, 0, 0, 16)
            },
            new Ground() {
                Position = new UDim2(1, 0, 0.5f, 0),
                Anchor = new Vector2(1, 1),
                Size = new UDim2(0.25f, 0, 0, 16)
            },
            new Fog() {
                ZIndex = 101
            }
            ]) {
            Player.Score = 0;

            Players = [new Player(new UDim2(0.5f, 0, 0.5f, 0)) {
                 ZIndex = 100
            }];
            projectileFactory = new ProjectileFactory(this);

            AddChild(Players[0]);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            projectileFactory.Cleanup();

            projectileTimer += gameTime.ElapsedGameTime.Milliseconds / 1000f;
            if (projectileTimer > 2) {
                int choice = random.Next(Enum.GetValues<ProjectilePreset>().Length);
                if (choice < Enum.GetValues<ProjectilePreset>().Length) {
                    ProjectilePreset preset = (ProjectilePreset)choice;

                    projectileFactory.AddFromPreset(preset, new UDim2(0, random.Next(SceneManager.Instance.GraphicsDevice.Viewport.Width), 0, random.Next(SceneManager.Instance.GraphicsDevice.Viewport.Height)));
                }
                projectileTimer %= 2;
            }

            coinTimer += gameTime.ElapsedGameTime.Milliseconds / 1000f;
            if (coinTimer > 5) {
                AddChild(new Coin(new UDim(0, random.Next(SceneManager.Instance.GraphicsDevice.Viewport.Width))));
                coinTimer %= 5;
            }

            if (Player.Score >= 10) {
                SceneManager.Instance.TransitionScene(new InstantSceneTransitioner(new GameOverScene(true, Player.Score)));
            }
        }
    }
}
