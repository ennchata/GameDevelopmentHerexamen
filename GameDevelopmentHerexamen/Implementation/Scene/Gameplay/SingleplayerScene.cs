using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Scene;
using GameDevelopmentHerexamen.Framework.Utility;
using GameDevelopmentHerexamen.Implementation.Component;
using GameDevelopmentHerexamen.Implementation.Object.Gameplay;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Scene.Gameplay {
    public class SingleplayerScene : GameScene {
        public SingleplayerScene() : base([
            new Player(new UDim2(0.5f, 0, 0.5f, 0)) {
                ZIndex = 100
            },
            new GameObject() {
                Components = [
                    new ImageComponent() {
                        AssetReference = "images/bg"
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
            }
        ]) { }
    }
}
