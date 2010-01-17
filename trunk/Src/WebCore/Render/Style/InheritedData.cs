using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.Render.Style
{
    public class InheritedData
    {
        // azimuth
        // border-collapse
        // border-spacing
        // caption-side
        // cursor
        // direction
        // elevation
        // empty-cells
        // font-family
        // letter-spacing
        // line-height
        // list-style-*
        // orphans
        // pitch-*
        // quotes
        // richness
        // speak-*
        // text-align
        // text-indent
        // text-transform
        // visibility
        // white-space
        // word-spacing

        private Font font;

        public Font Font
        {
            get
            {
                return font;
            }
            set
            {
                font = value;
            }
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
    }
}
