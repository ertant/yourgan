﻿// /*
// Yourgan
// Copyright (C) 2009  Ertan Tike
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// */
using System.Collections.Generic;

namespace Yourgan.Rendering
{
    public class Body : Block, ILayoutProvider
    {
        public Body(ModelNode model)
            : base(model)
        {
            this.layout = new FlowLayout(this);
        }

        ILayout layout;

        public ILayout Layout
        {
            get
            {
                return this.layout;
            }
        }

        private float scrollTop;

        public override float ScrollTop
        {
            get
            {
                return scrollTop;
            }
            set
            {
                scrollTop = value;
            }
        }

        private float scrollLeft;

        public override float ScrollLeft
        {
            get
            {
                return scrollLeft;
            }
            set
            {
                scrollLeft = value;
            }
        }

        protected internal override void OnChildrenAdded(IEnumerable<GraphicNode> affectedChilds)
        {
            base.OnChildrenAdded(affectedChilds);
            this.Layout.Invalidate();
        }

        protected internal override void OnChildrenRemoved(IEnumerable<GraphicNode> affectedChilds)
        {
            base.OnChildrenRemoved(affectedChilds);
            this.Layout.Invalidate();
        }
    }
}
