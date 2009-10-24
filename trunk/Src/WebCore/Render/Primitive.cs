using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yourgan.Core.Style;

namespace Yourgan.Core.Render
{
    public class Primitive
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

        private bool isPositioned;

        public bool IsPositioned
        {
            get
            {
                return this.isPositioned;
            }
            set
            {
                this.isPositioned = value;
            }
        }

        private bool isRelativePositioned;

        public bool IsRelativePositioned
        {
            get
            {
                return this.isRelativePositioned;
            }
            set
            {
                this.isRelativePositioned = value;
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
                Primitive parent = this.Parent;

                while (parent != null)
                {
                    // TODO : Check relative or absolute positions

                    Block block = parent as Block;

                    if (block != null)
                    {
                        return block;
                    }

                    parent = parent.Parent;
                }

                return null;
            }
        }
    }
}
