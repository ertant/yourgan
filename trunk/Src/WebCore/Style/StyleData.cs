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

        private Length Left
        {
            get
            {
                return this.surround.Offset.Left;
            }
            set
            {
                this.surround.Offset.Left = value;
            }
        }

        private Length Top
        {
            get
            {
                return this.surround.Offset.Top;
            }
            set
            {
                this.surround.Offset.Top = value;
            }
        }

        private Length Right
        {
            get
            {
                return this.surround.Offset.Right;
            }
            set
            {
                this.surround.Offset.Right = value;
            }
        }

        private Length Bottom
        {
            get
            {
                return this.surround.Offset.Bottom;
            }
            set
            {
                this.surround.Offset.Bottom = value;
            }
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
            get { return position; }
            set { position = value; }
        }

        private DisplayStyle displayStyle;

        public DisplayStyle DisplayStyle
        {
            get { return this.displayStyle; }
            set { this.displayStyle = value; }
        }
    }
}
