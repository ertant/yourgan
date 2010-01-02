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
namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLImageElement : HTMLElement
    {
        public HTMLImageElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        public abstract string Name
        {
            get;
            set;
        }

        public abstract string Align
        {
            get;
            set;
        }

        public abstract string Alt
        {
            get;
            set;
        }

        public abstract string Border
        {
            get;
            set;
        }

        public abstract int Height
        {
            get;
            set;
        }

        public abstract int HSpace
        {
            get;
            set;
        }

        public abstract bool IsMap
        {
            get;
            set;
        }

        public abstract string LongDesc
        {
            get;
            set;
        }

        public abstract string Src
        {
            get;
            set;
        }

        public abstract string UseMap
        {
            get;
            set;
        }

        public abstract int VSPace
        {
            get;
            set;
        }

        public abstract int Width
        {
            get;
            set;
        }
    }
}
