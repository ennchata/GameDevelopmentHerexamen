using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Framework.Utility {
    public class UDim2 {
        public UDim X;
        public UDim Y;

        public UDim2(UDim x, UDim y) {
            X = x;
            Y = y;
        }

        public UDim2(float xScale, float xOffset, float yScale, float yOffset) {
            X = new UDim(xScale, xOffset);
            Y = new UDim(yScale, yOffset);
        }

        public Vector2 Resolve(Vector2 parentSize) {
            return new Vector2(X.Resolve(parentSize.X), Y.Resolve(parentSize.Y));
        }
    }
}
