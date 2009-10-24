using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

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
    }
}
