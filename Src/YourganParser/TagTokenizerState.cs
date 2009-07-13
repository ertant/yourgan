/*
Yourgan
Copyright (C) 2009  Ertan Tike

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.Parser
{
    public unsafe class TagTokenizerState
    {
        ProcessCharHandler handler;

        public TagTokenizerState(System.Xml.XmlDocument document)
        {
            this.entityGeneration = new EntityGenerationState(this, document);
            this.encoding = System.Text.Encoding.UTF8;
            this.handler = TagTokenizer.Data;
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

        ContentModelType contentModel = ContentModelType.PCData;

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

            this.EntityGeneration.Emit(docTypeName, publicIdentifier, systemIdentifier);
        }

        public void EmitComment()
        {
            string tokenValue = new string(this.token.ToArray());

            this.ClearToken();

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

            this.EntityGeneration.Emit(tokenValue, isOpen ? TokenType.OpenElement : TokenType.CloseElement);
        }

        public void EmitSelfClosedElement()
        {
            this.ClearToken();
            this.isOpen = false;

            this.EntityGeneration.EmitSelfClosed();
        }

        public void EmitCharacterReference()
        {
            string tokenValue = new string(this.token.ToArray());

            this.ClearToken();

            this.EntityGeneration.Emit(tokenValue, TokenType.Data);
        }

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

            // mark as processed
            this.ClearToken();
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

            fixed (char* c = buffer)
            {
                this.Position = offset;

                while (this.Position < offset + length)
                {
                    this.Position++;

                    this.handler(this, c + offset + Position - 1);
                }
            }
        }

        public void Parse(char c)
        {
            this.handler(this, &c);
        }
    }
}
