using GameDevelopmentHerexamen.Framework.Scene;
using GameDevelopmentHerexamen.Framework.Utility;
using GameDevelopmentHerexamen.Implementation.Object.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Scene.Gameplay {
    public class SingleplayerScene : GameScene {
        public SingleplayerScene() : base([
            new Player(new UDim2(0, 10, 0, 10))
        ]) { }
    }
}
