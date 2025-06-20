using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Framework.Utility {
    public struct UDim(float scale, int offset) {
        public float Scale = scale;
        public int Offset = offset;

        public readonly float Resolve(float parentSize) {
            return parentSize * Scale + Offset;
        }

        public static UDim Zero { get; } = new UDim(0, 0);
        public static UDim Half { get; } = new UDim(0.5f, 0);
        public static UDim One { get; } = new UDim(1f, 0);

        public static UDim operator +(UDim uDim, int offset) => new UDim(uDim.Scale, uDim.Offset + offset);
        public static UDim operator -(UDim uDim, int offset) => new UDim(uDim.Scale, uDim.Offset - offset);
    }
}
