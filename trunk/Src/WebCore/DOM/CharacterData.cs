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
    public abstract class CharacterData : Node
    {
        protected CharacterData(Document document)
            : base(document)
        {
        }

        private string data;

        public string Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public int Length
        {
            get
            {
                return data.Length;
            }
        }

        public string SubstringData(int offset, int count)
        {
            return data.Substring(offset, count);
        }

        public void AppendData(string arg)
        {
            throw new NotImplementedException();
        }

        public void InsertData(int offset, string arg)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(int offset, int count)
        {
            throw new NotImplementedException();
        }

        public void ReplaceData(int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}
