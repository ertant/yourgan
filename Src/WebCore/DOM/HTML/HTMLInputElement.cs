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

namespace Yourgan.Core.DOM.HTML
{
    // http://www.w3.org/TR/html5/forms.html#the-input-element
    public abstract class HTMLInputElement : HTMLFormControl
    {
        public abstract string Accept
        {
            get;
            set;
        }

        public abstract string Alt
        {
            get;
            set;
        }

        public abstract bool AutoComplete
        {
            get;
            set;
        }

        public abstract bool DefaultChecked
        {
            get;
            set;
        }

        public abstract bool Checked
        {
            get;
            set;
        }

        // TODO : Files

        public abstract string Height
        {
            get;
            set;
        }

        public abstract bool Indeterminate
        {
            get;
            set;
        }

        public abstract HTMLElement List
        {
            get;
        }

        public abstract string Max
        {
            get;
            set;
        }

        public abstract int MaxLength
        {
            get;
            set;
        }

        public abstract string Min
        {
            get;
            set;
        }

        public abstract bool Multiple
        {
            get;
            set;
        }

        public abstract string Pattern
        {
            get;
            set;
        }

        public abstract string PlaceHolder
        {
            get;
            set;
        }

        public abstract bool Readonly
        {
            get;
            set;
        }

        public abstract bool Required
        {
            get;
            set;
        }

        public abstract int Size
        {
            get;
            set;
        }

        public abstract string Src
        {
            get;
            set;
        }

        public abstract string Step
        {
            get;
            set;
        }

        public abstract string DefaultValue
        {
            get;
            set;
        }

        public abstract DateTime ValueAsDate
        {
            get;
            set;
        }

        public abstract float ValueAsNumber
        {
            get;
            set;
        }

        public abstract HTMLOptionElement SelectedOption
        {
            get;
        }

        public abstract string Width
        {
            get;
            set;
        }

        public abstract void StepUp(int n);

        public abstract void StepDown(int n);

        public abstract NodeList Labels
        {
            get;
        }

        public abstract void Select();

        public abstract int SelectionStart
        {
            get;
            set;
        }

        public abstract int SelectionEnd
        {
            get;
            set;
        }

        public abstract void SetSelectionRange(int start, int end);
    }
}
