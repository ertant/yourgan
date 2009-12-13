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
using System.Collections.Generic;
using System.Text;
using Yourgan.Core.DOM;

namespace Yourgan.Core.Parser
{
#if(DEBUG)
    [System.Diagnostics.DebuggerDisplay("T={TokenValue} ContentModel={ContentModel}")]
#endif
    public unsafe class TagTokenizerState
    {
        ProcessCharHandler handler;

        public TagTokenizerState(Document document)
        {
            this.entityGeneration = new EntityGenerationState(this, document);
            this.encoding = System.Text.Encoding.UTF8;
            this.handler = TagTokenizer.Data;
            this.contentModel = ContentModelType.PCData;
        }

        public void Close()
        {
            this.entityGeneration.Close();
        }

        EntityGenerationState entityGeneration;

        public EntityGenerationState EntityGeneration
        {
            get
            {
                return entityGeneration;
            }
        }

        ContentModelType contentModel;

        public ContentModelType ContentModel
        {
            get
            {
                return contentModel;
            }
            set
            {
                originalContentModel = contentModel;
                contentModel = value;
            }
        }

        ContentModelType originalContentModel;

        public void ResetContentModel()
        {
            this.ContentModel = originalContentModel;
        }

        bool escapeFlag;

        public bool EscapeFlag
        {
            get
            {
                return escapeFlag;
            }
            set
            {
                escapeFlag = value;
            }
        }

        List<char> token = new List<char>(1024);

#if(DEBUG)

        public string TokenValue
        {
            get
            {
                return new string(token.ToArray());
            }
        }

#endif

        public void AddToken(char* c)
        {
            token.Add(*c);
        }

        public void AddToken(char c)
        {
            token.Add(c);
        }

        public void AddToken(char* c, int count)
        {
            for (int i = 0; i < count; i++)
                token.Add(*(c + i));
        }

        public void ClearToken()
        {
            token.Clear();
        }

        public char[] Buffer;

        //public int Offset;

        public int Position;

        public int Length;

        Encoding encoding;

        public Encoding Encoding
        {
            get
            {
                return encoding;
            }
        }

        bool isOpen;

        public bool IsOpen
        {
            get
            {
                return isOpen;
            }
        }

        public void OpenElement()
        {
            isOpen = true;
            isSelfClosed = false;
        }

        public void CloseElement()
        {
            isOpen = false;
        }

        bool isSelfClosed;

        public bool IsSelfClosed
        {
            get
            {
                return isSelfClosed;
            }
            set
            {
                isSelfClosed = value;
            }
        }

        private string publicIdentifier;

        public void EmitDocTypePublicIdentifier()
        {
            this.publicIdentifier = new string(this.token.ToArray());

            this.ClearToken();
        }

        private string systemIdentifier;

        public void EmitDocTypeSystemIdentifier()
        {
            this.systemIdentifier = new string(this.token.ToArray());

            this.ClearToken();
        }

        private string docTypeName;

        public void EmitDocTypeName()
        {
            this.docTypeName = new string(this.token.ToArray());

            this.ClearToken();
        }

        public void EmitDocType()
        {
            this.ClearToken();

            this.ContentModel = ContentModelType.PCData;

            this.EntityGeneration.Emit(docTypeName, publicIdentifier, systemIdentifier);
        }

        public void EmitComment()
        {
            string tokenValue = new string(this.token.ToArray());

            this.ClearToken();

            this.ContentModel = ContentModelType.PCData;

            this.EntityGeneration.Emit(tokenValue, TokenType.Comment);
        }

        public void EmitAttribute()
        {
            string tokenValue = new string(this.token.ToArray());

            this.ClearToken();

            this.EntityGeneration.Emit(tokenValue, TokenType.Attribute);
        }

        public void EmitAttributeValue()
        {
            string tokenValue = new string(this.token.ToArray());

            this.ClearToken();

            this.EntityGeneration.Emit(tokenValue, TokenType.AttributeValue);
        }

        public void EmitElement()
        {
            string tokenValue = new string(this.token.ToArray());

            this.ClearToken();

            if (Entity.IsOneOf(tokenValue, "title", "textarea"))
            {
                this.ContentModel = ContentModelType.RCData;
            }
            else if (Entity.IsOneOf(tokenValue, "style", "script", "xml", "iframe", "noembed", "noframes"))
            {
                this.ContentModel = ContentModelType.CData;
            }
            else if (Entity.IsOneOf(tokenValue, "noscript"))
            {
                if (this.EntityGeneration.HTMLTokenization.ScriptingEnabled)
                {
                    this.ContentModel = ContentModelType.CData;
                }
                else
                {
                    this.ContentModel = ContentModelType.PCData;
                }
            }
            else if (Entity.IsTag(tokenValue, "plaintext"))
            {
                this.ContentModel = ContentModelType.PlainText;
            }
            else
            {
                this.ContentModel = ContentModelType.PCData;
            }

            this.EntityGeneration.Emit(tokenValue, isOpen ? TokenType.OpenElement : TokenType.CloseElement);
        }

        public void EmitSelfClosedElement()
        {
            this.ClearToken();

            this.isOpen = false;

            this.ContentModel = ContentModelType.PCData;

            this.EntityGeneration.EmitSelfClosed();
        }

        //public void EmitCharacterReference()
        //{
        //    string tokenValue = new string(this.token.ToArray());

        //    this.ClearToken();

        //    switch (tokenValue)
        //    {
        //        case "nbsp":
        //            tokenValue = " ";
        //            break;
        //            case "
        //    }
        //    if ( tokenValue == "nbsp")


        //    this.EntityGeneration.Emit(tokenValue, TokenType.Data);
        //}

        StringBuilder dataBuilder = new StringBuilder();

        public void EmitData()
        {
            dataBuilder.Length = 0;

            bool isPreviousWhitespace = false;

            foreach (char c in this.token)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (isPreviousWhitespace)
                    {
                        continue;
                    }
                    else
                    {
                        isPreviousWhitespace = true;

                        dataBuilder.Append(c);
                    }
                }
                else
                {
                    isPreviousWhitespace = false;

                    dataBuilder.Append(c);
                }
            }

            // mark as processed
            this.ClearToken();

            this.ContentModel = ContentModelType.PCData;

            // any real data processed ?
            if (dataBuilder.Length > 1)
            {
                // emit data
                this.EntityGeneration.Emit(dataBuilder.ToString(), TokenType.Data);
            }
            else
            {
                // emit as whitespace
                this.EntityGeneration.Emit(dataBuilder.ToString(), TokenType.WhiteSpace);
            }
        }

        public void SetError()
        {
            this.ClearToken();

#if(LOG)
            System.Diagnostics.Debug.WriteLine("Parse error");
#endif
        }

        public void Switch(ProcessCharHandler newHandler)
        {
            this.handler = newHandler;
        }

        Stack<ProcessCharHandler> handlerStack = new Stack<ProcessCharHandler>();

        public void PushState(ProcessCharHandler newHandler)
        {
            handlerStack.Push(this.handler);

            this.handler = newHandler;
        }

        public void PopState()
        {
            this.handler = handlerStack.Pop();
        }

        public void Parse(char[] buffer, int offset, int length)
        {
            this.Buffer = buffer;
            this.Length = length;

            fixed (char* c = buffer)
            {
                this.Position = offset;

                while (this.Position < offset + length)
                {
                    this.handler(this, c + offset + Position);
                    this.Position++;
                }
            }
        }

        public void Parse(char c)
        {
            this.handler(this, &c);
        }
    }
}


