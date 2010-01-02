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
    // http://www.w3.org/TR/html5/forms.html#the-select-element
    public abstract class HTMLSelectElement : HTMLFormControl
    {
        public abstract bool Multiple
        {
            get;
            set;
        }

        public abstract HTMLOptionsCollection Options
        {
            get;
        }

        public abstract int Length
        {
            get;
            set;
        }

        public abstract HTMLOptionElement this[int index]
        {
            get;
        }

        public abstract HTMLOptionElement this[string name]
        {
            get;
        }

        public abstract void Add(HTMLElement element, HTMLElement before);

        public abstract void Add(HTMLElement element, int before);

        public abstract void Remove(int index);

        public abstract HTMLCollection SelectedOptions
        {
            get;
        }

        public abstract int SelectedIndex
        {
            get;
            set;
        }

        public abstract NodeList Labels
        {
            get;
        }
    }
}
