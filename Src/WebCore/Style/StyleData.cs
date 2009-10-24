using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.Style
{
    public class StyleData
    {
        public StyleData()
        {

        }

        public static StyleData Initial
        {
            get
            {
                return new StyleData();
            }
        }

        public void InheritFrom(StyleData style)
        {
            throw new NotImplementedException();
        }

        private BoxData box = new BoxData();

        public Length Width
        {
            get
            {
                return this.box.Width;
            }
        }

        public Length MinWidth
        {
            get
            {
                return this.box.MinWidth;
            }
        }

        public Length MaxWidth
        {
            get
            {
                return this.box.MaxWidth;
            }
        }

        public Length Height
        {
            get
            {
                return this.box.Height;
            }
        }

        public Length MinHeight
        {
            get
            {
                return this.box.MinHeight;
            }
        }

        public Length MaxHeight
        {
            get
            {
                return this.box.MaxHeight;
            }
        }

        private Surround surround = new Surround();

        public Surround Surround
        {
            get
            {
                return surround;
            }
        }

        private PositionStyle position;

        public PositionStyle Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }
    }
}
