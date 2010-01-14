// /*
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
using System;

namespace Yourgan.Core.DOM.CSS
{
    public class StyleSheet
    {
        private string type;

        public string Type
        {
            get
            {
                return type;
            }
        }

        private string href;

        public string HRef
        {
            get
            {
                return href;
            }
        }

        public Node OwnerNode
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public StyleSheet ParentStyleSheet
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Title
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public MediaList Media
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private bool disabled;

        public bool Disabled
        {
            get
            {
                return disabled;
            }
            set
            {
                disabled = value;
            }
        }
    }
}
