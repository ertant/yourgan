using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.Render.Style
{
    public class BorderValue
    {
        public BorderValue()
        {
            this.color = Color.Transparent;
            this.width = 0;
            this.style = BorderStyle.None;
        }

        private Color color;

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        private int width;

        public int Width
        {
            get
            {
                return width;
            }
        }

        private BorderStyle style;

        public BorderStyle Style
        {
            get
            {
                return style;
            }
            set
            {
                style = value;
            }
        }

        public bool IsZero
        {
            get
            {
                return (this.width != 0);
            }
        }

        public bool IsVisible
        {
            get
            {
                return (this.style != BorderStyle.Hidden) && (this.style != BorderStyle.None);
            }
        }

        public int GetWidth()
        {
            if (this.IsVisible)
            {
                return this.Width;
            }
            else
            {
                return 0;
            }
        }
    }
}
