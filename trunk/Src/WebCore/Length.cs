// /*
// Yourgan
// Copyright (C) 2009  Ertan Tike
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// */
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

        private int? innerValue;

        public int Value
        {
            get
            {
                if (innerValue.HasValue)
                    return this.innerValue.Value;

                return 0;
            }
            set
            {
                this.innerValue = value;
            }
        }

        public bool IsZero
        {
            get
            {
                return this.innerValue.HasValue && this.innerValue.Value != 0;
            }
        }

        public bool IsDefined
        {
            get
            {
                return this.innerValue.HasValue;
            }
        }

        public int Calculate(int max)
        {
            switch (this.type)
            {
                case LengthType.Fixed:
                    return this.Value;
                case LengthType.Percent:
                    return this.Value * max / 100;
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
                    return this.Value;
                case LengthType.Percent:
                    return this.Value * min / 100;
                default:
                    return 0;
            }
        }
    }
}
