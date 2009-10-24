using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core
{
    public struct Length
    {
        private LengthType type;

        public LengthType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        private int value;

        public int Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public bool IsZero()
        {
            return this.value != 0;
        }

        public int Calculate(int max)
        {
            switch (this.type)
            {
                case LengthType.Fixed:
                    return this.value;
                case LengthType.Percent:
                    return this.value*max/100;
                case LengthType.Auto:
                    return max;
                default:
                    return -1;
            }
        }

        public int CalculateMin(int min)
        {
            switch (this.type)
            {
                case LengthType.Fixed:
                    return this.value;
                case LengthType.Percent:
                    return this.value*min/100;
                case LengthType.Auto:
                default:
                    return 0;
            }
        }
    }
}
