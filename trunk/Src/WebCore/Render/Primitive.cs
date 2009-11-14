using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yourgan.Core.DOM;
using Yourgan.Core.Render.Style;
using System.Drawing;
using Yourgan.Core.Drawing;

namespace Yourgan.Core.Render
{
    public abstract class Primitive
    {
        public Primitive(Node node)
        {
            this.node = node;
        }

        private Node node;

        public Node Node
        {
            get { return node; }
        }

        private Primitive parent;

        public Primitive Parent
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

        private StyleData style = StyleData.Initial;

        public StyleData Style
        {
            get
            {
                return style;
            }
            set
            {
                OnStyleChanging(value);

                StyleData oldStyle = this.style;

                style = value;

                OnStyleChanged(oldStyle);

                Invalidate();
            }
        }

        protected virtual void OnStyleChanging(StyleData newStyle)
        {

        }

        protected virtual void OnStyleChanged(StyleData oldStyle)
        {

        }

        protected void Invalidate()
        {
            Invalidate(Rectangle.Empty);
        }

        protected void Invalidate(Rectangle rectangle)
        {
            this.EnclosingLayer.Invalidate(rectangle);
        }

        public bool IsRoot
        {
            get
            {
                return this.node == this.node.Document.DocumentElement;
            }
        }

        public bool IsBody
        {
            get
            {
                // TODO : 
                return false;
            }
        }

        public virtual bool IsBoxModel
        {
            get
            {
                return false;
            }
        }

        public virtual bool IsBox
        {
            get
            {
                return false;
            }
        }

        public bool IsFloating
        {
            get
            {
                return this.IsPositioned && (this.Style.IsFloating);
            }
        }

        public bool IsPositioned
        {
            get
            {
                return (this.Style.Position == PositionStyle.Fixed) || (this.Style.Position == PositionStyle.Absolute);
            }
        }

        public bool IsRelativePositioned
        {
            get
            {
                return this.Style.Position == PositionStyle.Relative;
            }
        }

        public BoxModel OffsetParent()
        {
            if (this.IsRoot || this.IsBody || (this.Style.Position == PositionStyle.Fixed))
                return null;

            Primitive current = this.Parent;

            while ((current != null) && !current.IsPositioned && !current.IsRelativePositioned)
            {
                current = current.Parent;
            }

            BoxModel boxObject = current as BoxModel;

            return boxObject;
        }

        public Block ContainingBlock
        {
            get
            {
                Primitive tmpParent = this.Parent;

                while (tmpParent != null)
                {
                    // TODO : Check relative or absolute positions

                    Block block = tmpParent as Block;

                    if (block != null)
                    {
                        return block;
                    }

                    tmpParent = tmpParent.Parent;
                }

                return null;
            }
        }

        public Box EnclosingBox
        {
            get
            {
                Primitive tmpParent = this.Parent;

                while (tmpParent != null)
                {
                    Box box = tmpParent as Box;

                    if (box != null)
                    {
                        return box;
                    }

                    tmpParent = tmpParent.Parent;
                }

                return null;
            }
        }

        public bool IsRequiresLayer
        {
            get
            {
                // isTransparent() || hasOverflowClip() || hasTransform() || hasMask() || hasReflection();
                return IsRoot || IsPositioned || IsRelativePositioned;
            }
        }

        private Layer layer;

        public Layer Layer
        {
            get
            {
                return layer;
            }
            set
            {
                if (layer != null)
                {
                    layer.Destroy();
                }

                layer = value;
            }
        }

        public bool HasLayer
        {
            get
            {
                return layer != null;
            }
        }

        public Layer EnclosingLayer
        {
            get
            {
                Primitive current = this;

                while ((current != null) && !current.HasLayer)
                {
                    current = current.Parent;
                }

                BoxModel boxModel = current as BoxModel;

                if (boxModel != null)
                {
                    return boxModel.Layer;
                }

                return null;
            }
        }

        public static Primitive Create(Node node, StyleData style)
        {
            switch (style.DisplayStyle)
            {
                case DisplayStyle.Inline:
                    {
                        return new Inline(node);
                    }
                case DisplayStyle.Block:
                    {
                        return new Block(node);
                    }
                default:
                    {
                        return new Block(node);
                    }
            }
        }

        public void Paint(IGraphicsContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            OnPaint(context);
        }

        protected virtual void OnPaint(IGraphicsContext context)
        {

        }

        public void PerformLayout()
        {
            OnPerformLayout();
            this.isLayoutInvalid = false;
        }

        protected virtual void OnPerformLayout()
        {

        }

        private bool isLayoutInvalid;

        public bool IsLayoutInvalid
        {
            get
            {
                return isLayoutInvalid;
            }
        }

        public void UpdateLayout(bool isInvalid)
        {
            isLayoutInvalid = isInvalid;
        }
    }
}
