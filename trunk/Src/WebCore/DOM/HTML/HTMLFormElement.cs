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
    // http://www.w3.org/TR/html5/forms.html#the-form-element
    public abstract class HTMLFormElement : HTMLElement
    {

        public abstract string AcceptCharset
        {
            get;
            set;
        }

        public abstract string Action
        {
            get;
            set;
        }

        public abstract bool AutoComplete
        {
            get;
            set;
        }

        public abstract string EncType
        {
            get;
            set;
        }

        public abstract string Method
        {
            get;
            set;
        }

        public abstract string Name
        {
            get;
            set;
        }

        public abstract bool NoValidate
        {
            get;
            set;
        }

        public abstract string Target
        {
            get;
            set;
        }

        public abstract HTMLFormControlsCollection Elements
        {
            get;
        }

        public abstract int Length
        {
            get;
        }

        public abstract object this[int index]
        {
            get;
        }

        public abstract object this[string name]
        {
            get;
        }

        public abstract void Submit();

        public abstract void Reset();

        public abstract void CheckValidity();

        public abstract void DispatchFormInput();

        public abstract void DispatchFormChange();
    }
}
