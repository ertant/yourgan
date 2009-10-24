using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core
{
    public class Color
    {
        public Color(int argb)
        {

        }

        public static Color Transparent
        {
            get
            {
                return new Color(0);
            }
        }
    }
}
