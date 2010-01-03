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
    // http://www.w3.org/TR/html5/forms.html#the-option-element
    public abstract class HTMLOptionElement : HTMLElement
    {
        // TODO : Constructors

        public abstract bool Disabled
        {
            get;
            set;
        }

        public abstract HTMLFormElement Form
        {
            get;
        }

        public abstract string Label
        {
            get;
            set;
        }

        public abstract bool DefaultSelected
        {
            get;
            set;
        }

        public abstract bool Selected
        {
            get;
            set;
        }

        public abstract string Value
        {
            get;
            set;
        }

        public abstract string Text
        {
            get;
        }

        public abstract ulong Index
        {
            get;
        }
    }
}
