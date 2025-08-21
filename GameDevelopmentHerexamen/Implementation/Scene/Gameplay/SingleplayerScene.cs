using GameDevelopmentHerexamen.Framework.Scene;
using GameDevelopmentHerexamen.Framework.Utility;
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
            new Player(new UDim2(0.5f, 0, 0.5f, 0)),
            new Ground() {
                Position = UDim2.BottomCenter,
                Anchor = new Vector2(0.5f, 1),
                Size = new UDim2(0.25f, 0, 0, 16)
            }
        ]) { }
    }
}
