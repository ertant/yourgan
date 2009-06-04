using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Rendering
{
    public class Style
    {
        public Style()
        {
            this.display = DisplayMode.Block;
            this.padding = new Padding(1);
            this.margin = new Padding(2);
        }

        private Padding padding;

        public Padding Padding
        {
            get
            {
                return padding;
            }
            set
            {
                padding = value;
            }
        }

        private Padding margin;

        public Padding Margin
        {
            get
            {
                return margin;
            }
            set
            {
                margin = value;
            }
        }

        private DisplayMode display;

        public DisplayMode Display
        {
            get
            {
                return display;
            }
            set
            {
                display = value;
            }
        }
    }
}
