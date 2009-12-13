using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
