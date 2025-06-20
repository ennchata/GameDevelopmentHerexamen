using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Framework.Utility {
    public struct UDim2 {
        public UDim X;
        public UDim Y;

        public UDim2(UDim x, UDim y) {
            X = x;
            Y = y;
        }

        public UDim2(float xScale, int xOffset, float yScale, int yOffset) {
            X = new UDim(xScale, xOffset);
            Y = new UDim(yScale, yOffset);
        }

        public readonly Vector2 Resolve(Vector2 parentSize) {
            return new Vector2(X.Resolve(parentSize.X), Y.Resolve(parentSize.Y));
        }

        public static UDim2 TopLeft { get; } = new UDim2(UDim.Zero, UDim.Zero);
        public static UDim2 TopCenter { get; } = new UDim2(UDim.Half, UDim.Zero);
        public static UDim2 TopRight { get; } = new UDim2(UDim.One, UDim.Zero);
        public static UDim2 CenterLeft { get; } = new UDim2(UDim.Zero, UDim.Half);
        public static UDim2 CenterCenter { get; } = new UDim2(UDim.Half, UDim.Half);
        public static UDim2 CenterRight { get; } = new UDim2(UDim.One, UDim.Half);
        public static UDim2 BottomLeft { get; } = new UDim2(UDim.Zero, UDim.One);
        public static UDim2 BottomCenter { get; } = new UDim2(UDim.Half, UDim.One);
        public static UDim2 BottomRight { get; } = new UDim2(UDim.One, UDim.One);

        public static UDim2 operator +(UDim2 uDim2, (int x, int y) offset) => new UDim2(uDim2.X + offset.x, uDim2.Y + offset.y);
        public static UDim2 operator -(UDim2 uDim2, (int x, int y) offset) => new UDim2(uDim2.X - offset.x, uDim2.Y - offset.y);
    }
}
