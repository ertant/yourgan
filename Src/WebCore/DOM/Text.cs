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

namespace Yourgan.Core.DOM
{
    public class Text : CharacterData
    {
        public Text(Document document)
            : base(document)
        {
        }

        public override NodeType NodeType
        {
            get
            {
                return NodeType.Text;
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

        public override string NodeName
        {
            get
            {
                return "#text";
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

        public bool IsElementContentWhitespace
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string WholeText
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Text ReplaceWholeText(string content)
        {
            throw new NotImplementedException();
        }

        public Text SplitText(int offset)
        {
            throw new NotImplementedException();
        }
    }
}
