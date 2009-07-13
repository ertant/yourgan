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
            this.decoder = System.Text.Encoding.UTF8.GetDecoder();
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

        public int Offset;

        public int Length;

        Decoder decoder;

        public Decoder Encoding
        {
            get
            {
                return decoder;
            }
        }

        public bool HasMore
        {
            get
            {
                return this.Offset < this.Length;
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

        public void EmitData()
        {
            string tokenValue = new string(this.token.ToArray());

            // scan value
            for (int i = 0; i < tokenValue.Length; i++)
            {
                // is current not a whitespace ?
                if (!char.IsWhiteSpace(tokenValue, i))
                {
                    this.EntityGeneration.Emit(tokenValue, TokenType.Data);

                    // mark as processed
                    this.ClearToken();

                    break;
                }
            }

            // is not processed ?
            if (this.token.Count > 0)
            {
                // emit as whitespace
                this.EntityGeneration.Emit(tokenValue, TokenType.WhiteSpace);
                this.ClearToken();
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

        public void Parse(byte[] buffer, int offset, int length)
        {
            int charCount = this.Encoding.GetCharCount(buffer, offset, length);

            if (charCount > this.Length)
            {
                Array.Resize(ref this.Buffer, charCount);
            }

            this.Offset = 0;
            this.Length = this.Encoding.GetChars(buffer, offset, length, this.Buffer, 0);

            fixed (char* c = this.Buffer)
            {
                while (this.HasMore)
                {
                    int tmpOffset = this.Offset++;

                    this.handler(this, c + tmpOffset);
                }
            }
        }
    }
}
