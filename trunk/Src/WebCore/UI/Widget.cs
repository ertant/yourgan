using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Yourgan.Core.UI
{
    public class Widget
    {
        public Widget()
        {
        }

        private ScrollView parent;

        public ScrollView Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        private INativeWidget nativeWidget;

        public INativeWidget NativeWidget
        {
            get
            {
                return nativeWidget;
            }
            set
            {
                nativeWidget = value;
            }
        }

        private Rectangle bounds;

        public Rectangle Bounds
        {
            get
            {
                return bounds;
            }
            set
            {
                bounds = value;
            }
        }
    }
}
