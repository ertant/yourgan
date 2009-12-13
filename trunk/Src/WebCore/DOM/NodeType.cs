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
namespace Yourgan.Core.DOM
{
    public enum NodeType : int
    {
        Element = 1,
        Attribute = 2,
        Text = 3,
        CData = 4,
        EntityReference = 5,
        EntityNode = 6,
        ProcessingInstruction = 7,
        Comment = 8,
        Document  = 9,
        DocumentType = 10,
        DocumentFragment = 11,
        Notation = 12,
        XPathNamespace = 13
    }
}
