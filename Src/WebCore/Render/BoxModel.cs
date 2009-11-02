using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Yourgan.Core.DOM;
using Yourgan.Core.Render.Style;

namespace Yourgan.Core.Render
{
    public class BoxModel : Primitive
    {
        public BoxModel(Node node)
            : base(node)
        {
        }

        public override bool IsBoxModel
        {
            get
            {
                return true;
            }
        }

        public int OffsetLeft()
        {
            if (this.IsBody)
                return 0;

            BoxModel offsetParent = this.OffsetParent();

            int xPos = 0;

            if (this.IsBox)
            {
                xPos = ((Box)this).X;
            }

            if (offsetParent != null)
            {
                if (offsetParent.IsBox && !offsetParent.IsBody)
                    xPos -= offsetParent.Style.Surround.Border.Left.Width;

                if (!this.IsPositioned)
                {
                    if (this.IsRelativePositioned)
                    {
                        // TODO : xPos += this.RelativePositionOffsetX();
                    }

                    Primitive current = this.Parent;

                    while ((current != null) && (current != offsetParent))
                    {
                        if (current.IsBox)
                        {
                            xPos += ((Box)current).X;
                        }

                        current = current.Parent;
                    }

                    if (offsetParent.IsBox && offsetParent.IsBody && !offsetParent.IsRelativePositioned && !offsetParent.IsPositioned)
                    {
                        xPos += ((Box)offsetParent).X;
                    }
                }
            }

            return xPos;
        }

        public int OffsetTop()
        {
            if (this.IsBody)
                return 0;


            BoxModel offsetParent = this.OffsetParent();

            int yPos = 0;

            if (this.IsBox)
            {
                yPos = ((Box)this).Y;
            }

            if (offsetParent != null)
            {
                if (offsetParent.IsBox && !offsetParent.IsBody)
                    yPos -= offsetParent.Style.Surround.Border.Top.Width;

                if (!this.IsPositioned)
                {
                    if (this.IsRelativePositioned)
                    {
                        // TODO : yPos += this.RelativePositionOffsetX();
                    }

                    Primitive current = this.Parent;

                    while ((current != null) && (current != offsetParent))
                    {
                        if (current.IsBox)
                        {
                            yPos += ((Box)current).Y;
                        }

                        current = current.Parent;
                    }

                    if (offsetParent.IsBox && offsetParent.IsBody && !offsetParent.IsRelativePositioned && !offsetParent.IsPositioned)
                    {
                        yPos += ((Box)offsetParent).Y;
                    }
                }
            }

            return yPos;
        }

        public int BorderLeft
        {
            get
            {
                return this.Style.Surround.Border.Left.GetWidth();
            }
        }

        public int BorderTop
        {
            get
            {
                return this.Style.Surround.Border.Top.GetWidth();
            }
        }

        public int BorderRight
        {
            get
            {
                return this.Style.Surround.Border.Right.GetWidth();
            }
        }

        public int BorderBottom
        {
            get
            {
                return this.Style.Surround.Border.Bottom.GetWidth();
            }
        }

        public virtual int PaddingLeft
        {
            get
            {
                Length padding = this.Style.Surround.Padding.Left;

                int width = 0;

                if (padding.Type == LengthType.Percent)
                {
                    width = this.ContainingBlock.AvailableWidth;
                }

                return padding.CalculateMin(width);
            }
        }

        public virtual int PaddingTop
        {
            get
            {
                Length padding = this.Style.Surround.Padding.Top;

                int width = 0;

                if (padding.Type == LengthType.Percent)
                {
                    width = this.ContainingBlock.AvailableWidth;
                }

                return padding.CalculateMin(width);
            }
        }

        public virtual int PaddingRight
        {
            get
            {
                Length padding = this.Style.Surround.Padding.Right;

                int width = 0;

                if (padding.Type == LengthType.Percent)
                {
                    width = this.ContainingBlock.AvailableWidth;
                }

                return padding.CalculateMin(width);
            }
        }

        public virtual int PaddingBottom
        {
            get
            {
                Length padding = this.Style.Surround.Padding.Bottom;

                int width = 0;

                if (padding.Type == LengthType.Percent)
                {
                    width = this.ContainingBlock.AvailableWidth;
                }

                return padding.CalculateMin(width);
            }
        }

        public int MarginTop
        {
            get
            {
                // TODO : 
                return 0;
            }
        }

        public int MarginLeft
        {
            get
            {
                // TODO : 
                return 0;
            }
        }

        public int MarginRight
        {
            get
            {
                // TODO : 
                return 0;
            }
        }

        public int MarginBottom
        {
            get
            {
                // TODO : 
                return 0;
            }
        }

        protected override void OnStyleChanged(StyleData oldStyle)
        {
            base.OnStyleChanged(oldStyle);

            if (this.IsRequiresLayer)
            {
                this.Layer = new Layer(this);
                this.Layer.InsertToParent();
            }
            else if (this.HasLayer)
            {
                this.Layer = null;
            }
        }
    }
}
