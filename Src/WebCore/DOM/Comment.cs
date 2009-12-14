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
    public class Comment : CharacterData
    {
        public Comment(Document document)
            : base(document)
        {
            
        }

        public override NodeType NodeType
        {
            get
            {
                return NodeType.Comment;
            }
        }

        public override string NodeName
        {
            get
            {
                return "#comment";
            }
        }

        public override string NodeValue
        {
            get
            {
                return this.Data;
            }
            set
            {
                this.Data = value;
            }
        }

        public override string TextContent
        {
            get
            {
                return this.Data;
            }
            set
            {
                this.Data = value;
            }
        }
    }
}
