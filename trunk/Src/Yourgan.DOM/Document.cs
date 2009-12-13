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
namespace Yourgan.DOM
{
    // http://www.w3.org/TR/2004/REC-DOM-Level-3-Core-20040407/core.html#i-Document
    public interface Document : Node
    {
        Element createElement(string tagName);

        DocumentFragment createDocumentFragment();

        Text createTextNode(string data);

        Comment createComment(string data);

        CDATASection createCDATASection(string data);

        Attr createAttribute(string name);
    }
}
