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
namespace Yourgan.Core.Parser
{
    public class FormattingElement
    {
        public FormattingElement(System.Xml.XmlElement element)
        {
            this.element = element;
            this.isMarker = false;
        }

        public FormattingElement()
        {
            this.isMarker = true;
        }

        System.Xml.XmlElement element;

        public System.Xml.XmlElement Element
        {
            get
            {
                return element;
            }
        }

        bool isMarker;

        public bool IsMarker
        {
            get
            {
                return isMarker;
            }
        }
    }
}


