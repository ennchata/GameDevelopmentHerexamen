using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Framework.Utility {
    public class UDim(float scale, float offset) {
        public float Scale = scale;
        public float Offset = offset;

        public float Resolve(float parentSize) {
            return parentSize * Scale + Offset;
        }
    }
}
