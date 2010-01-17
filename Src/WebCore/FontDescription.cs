using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core
{
    public class FontDescription
    {
        private FontFamily family;

        public FontFamily Family
        {
            get
            {
                return family;
            }
            set
            {
                family = value;
            }
        }

        private float size;

        public float Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }

        private bool italic;

        public bool Italic
        {
            get
            {
                return italic;
            }
            set
            {
                italic = value;
            }
        }

        private int weight;

        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }
    }
}
