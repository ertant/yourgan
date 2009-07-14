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
    unsafe class TagTokenizer
    {
        static TagTokenizer()
        {
            Data = _Data;
            TagOpen = _TagOpen;
            CharacterRefence = _CharacterRefence;
            TagName = _TagName;
            SelfClosingStartTag = _SelfClosingStartTag;
            CloseTagOpen = _CloseTagOpen;
            BeforeAttributeName = _BeforeAttributeName;
            AttributeName = _AttributeName;
            AfterAttributeName = _AfterAttributeName;
            BeforeAttributeValue = _BeforeAttributeValue;
            AttributeValueDoubleQuoted = _AttributeValueDoubleQuoted;
            AttributeValueSingleQuoted = _AttributeValueSingleQuoted;
            AttributeValueUnQuoted = _AttributeValueUnQuoted;
            AttributeValueCharacterReference = _AttributeValueCharacterReference;
            AfterAttributeValueQuoted = _AfterAttributeValueQuoted;
            BogusComment = _BogusComment;
            CommentStart = _CommentStart;
            CommentStartDash = _CommentStartDash;
            Comment = _Comment;
            CommentEndDash = _CommentEnd;
            CommentEnd = _CommentEnd;
            MarkupDeclaration = _MarkupDeclaration;
            DocType = _DocType;
            BeforeDocTypeName = _BeforeDocTypeName;
            DocTypeName = _DocTypeName;
            AfterDocTypeName = _AfterDocTypeName;
            BeforeDocTypePublicIdentifier = _BeforeDocTypePublicIdentifier;
            DocTypePublicIdentifierDoubleQuoted = _DocTypePublicIdentifierDoubleQuoted;
            DocTypePublicIdentifierSingleQuoted = _DocTypePublicIdentifierSingleQuoted;
            AfterDocTypePublicIdentifier = _AfterDocTypePublicIdentifier;
            BeforeDocTypeSystemIdentifier = _BeforeDocTypeSystemIdentifier;
            DocTypeSystemIdentifierDoubleQuoted = _DocTypeSystemIdentifierDoubleQuoted;
            DocTypeSystemIdentifierSingleQuoted = _DocTypeSystemIdentifierSingleQuoted;
            AfterDocTypeSystemIdentifier = _AfterDocTypeSystemIdentifier;
            BogusDocType = _BogusDocType;
            CDataSection = _CDataSection;
        }

        public readonly static ProcessCharHandler Data;
        private readonly static ProcessCharHandler TagOpen;
        private readonly static ProcessCharHandler CharacterRefence;
        private readonly static ProcessCharHandler TagName;
        private readonly static ProcessCharHandler SelfClosingStartTag;
        private readonly static ProcessCharHandler CloseTagOpen;
        private readonly static ProcessCharHandler BeforeAttributeName;
        private readonly static ProcessCharHandler AttributeName;
        private readonly static ProcessCharHandler AfterAttributeName;
        private readonly static ProcessCharHandler BeforeAttributeValue;
        private readonly static ProcessCharHandler AttributeValueDoubleQuoted;
        private readonly static ProcessCharHandler AttributeValueSingleQuoted;
        private readonly static ProcessCharHandler AttributeValueUnQuoted;
        private readonly static ProcessCharHandler AttributeValueCharacterReference;
        private readonly static ProcessCharHandler AfterAttributeValueQuoted;
        private readonly static ProcessCharHandler BogusComment;
        private readonly static ProcessCharHandler CommentStart;
        private readonly static ProcessCharHandler CommentStartDash;
        private readonly static ProcessCharHandler Comment;
        private readonly static ProcessCharHandler CommentEndDash;
        private readonly static ProcessCharHandler CommentEnd;
        private readonly static ProcessCharHandler MarkupDeclaration;
        private readonly static ProcessCharHandler DocType;
        private readonly static ProcessCharHandler BeforeDocTypeName;
        private readonly static ProcessCharHandler DocTypeName;
        private readonly static ProcessCharHandler AfterDocTypeName;
        private readonly static ProcessCharHandler BeforeDocTypePublicIdentifier;
        private readonly static ProcessCharHandler DocTypePublicIdentifierDoubleQuoted;
        private readonly static ProcessCharHandler DocTypePublicIdentifierSingleQuoted;
        private readonly static ProcessCharHandler AfterDocTypePublicIdentifier;
        private readonly static ProcessCharHandler BeforeDocTypeSystemIdentifier;
        private readonly static ProcessCharHandler DocTypeSystemIdentifierDoubleQuoted;
        private readonly static ProcessCharHandler DocTypeSystemIdentifierSingleQuoted;
        private readonly static ProcessCharHandler AfterDocTypeSystemIdentifier;
        private readonly static ProcessCharHandler BogusDocType;
        private readonly static ProcessCharHandler CDataSection;

        private static void _Data(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '&':
                    {
                        // When the content model flag is set to one of the PCDATA or RCDATA states and the escape flag is false: switch to the character reference data state.
                        // Otherwise: treat it as per the "anything else" entry below.
                        if (
                            ((state.ContentModel == ContentModelType.PCData) || (state.ContentModel == ContentModelType.RCData))
                            &&
                            (!state.EscapeFlag)
                           )
                        {
                            state.EmitData();
                            state.Switch(CharacterRefence);
                        }
                        else
                        {
                            state.AddToken(*c);
                        }

                        break;
                    }
                case '<':
                    {
                        // When the content model flag is set to the PCDATA state: switch to the tag open state.
                        if (state.ContentModel == ContentModelType.PCData)
                        {
                            state.EmitData();
                            state.Switch(TagOpen);
                        }
                        // When the content model flag is set to either the RCDATA state or the CDATA state, and the escape flag is false: switch to the tag open state.
                        else if (((state.ContentModel == ContentModelType.RCData) || (state.ContentModel == ContentModelType.CData)) && !state.EscapeFlag)
                        {
                            state.EmitData();
                            state.Switch(TagOpen);
                        }
                        // Otherwise: treat it as per the "anything else" entry below.
                        else
                        {
                            state.AddToken(*c);
                        }

                        break;
                    }
                case '>':
                    {
                        // If the content model flag is set to either the RCDATA state or the CDATA state, and the escape flag is true,
                        // and the last three characters in the input stream including this one are
                        // U+002D HYPHEN-MINUS, U+002D HYPHEN-MINUS, U+003E GREATER-THAN SIGN ("-->"), set the escape flag to false.
                        if (((state.ContentModel == ContentModelType.RCData) || (state.ContentModel == ContentModelType.CData) && state.EscapeFlag))
                        {
                            string testString = new string(c, 0, 4);

                            if (testString == "-->")
                            {
                                state.EscapeFlag = false;
                            }
                        }

                        // In any case, emit the input character as a character token. Stay in the data state.
                        state.AddToken(*c);

                        break;
                    }
                case '-':
                    {
                        // If the content model flag is set to either the RCDATA state or the CDATA state, and the escape flag is false, 
                        // and there are at least three characters before this one in the input stream, and the last four characters in the input stream,
                        // including this one, are U+003C LESS-THAN SIGN, U+0021 EXCLAMATION MARK, U+002D HYPHEN-MINUS, and U+002D HYPHEN-MINUS ("<!--"), 
                        // then set the escape flag to true.

                        if (((state.ContentModel == ContentModelType.RCData) || (state.ContentModel == ContentModelType.CData)) && !state.EscapeFlag)
                        {
                            string testString = new string(c, 0, 4);

                            if (testString == "<!--")
                            {
                                state.EscapeFlag = true;
                            }
                        }

                        // In any case, emit the input character as a character token. Stay in the data state.
                        state.AddToken(*c);

                        break;
                    }
                default:
                    {
                        state.AddToken(*c);
                        break;
                    }
            }
        }

        private static void _TagOpen(TagTokenizerState state, char* c)
        {
            if ((state.ContentModel == ContentModelType.RCData) || (state.ContentModel == ContentModelType.CData))
            {
                // Consume the next input character. 
                char nextChar = *(c++);

                // If it is a U+002F SOLIDUS (/) character, switch to the close tag open state. 
                if (nextChar == '/')
                {
                    state.Switch(CloseTagOpen);
                }
                // Otherwise, emit a U+003C LESS-THAN SIGN character token and reconsume the current input character in the data state.
                else
                {
                    state.AddToken('<');
                    state.Position--;
                    state.Switch(Data);
                }
            }
            else if (state.ContentModel == ContentModelType.PCData)
            {
                switch (*c)
                {
                    case '/':
                        {
                            // Switch to the close tag open state.
                            state.CloseElement();
                            state.Switch(CloseTagOpen);
                            break;
                        }
                    case '!':
                        {
                            // Switch to the markup declaration open state.
                            state.Switch(MarkupDeclaration);
                            break;
                        }
                    case '>':
                        {
                            // Parse error. 
                            state.SetError();
                            // TODO : Emit a U+003C LESS-THAN SIGN character token and a U+003E GREATER-THAN SIGN character token. 
                            // Switch to the data state.
                            state.Switch(Data);
                            break;
                        }
                    case '?':
                        {
                            // Parse error. 
                            state.SetError();
                            // Switch to the bogus comment state.
                            state.Switch(BogusComment);
                            break;
                        }
                    default:
                        {
                            // Emit a U+003C LESS-THAN SIGN character token and reconsume the current input character in the data state.
                            if (char.IsLetter(*c))
                            {
                                state.OpenElement();
                                state.AddToken(*c);

                                state.Switch(TagName);
                            }
                            else
                            {
                                // Anything else
                                // Parse error. Emit a U+003C LESS-THAN SIGN character token and reconsume the current input character in the data state.
                                state.SetError();
                                // TODO : Emit a U+003C LESS-THAN SIGN character token
                                state.Position--;
                                state.Switch(Data);
                            }

                            break;
                        }
                }
            }
        }

        private static void _CharacterRefence(TagTokenizerState state, char* c)
        {
            char? consumedCharacter = ConsumeCharacter(state);

            if (!consumedCharacter.HasValue)
            {
                state.AddToken('&');
                state.AddToken(*c);
            }
            else
            {
                state.AddToken(consumedCharacter.Value);
            }

            state.Switch(Data);
        }

        private static void _TagName(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '\t':
                case '\r':
                case '\n':
                case ' ':
                    {
                        state.EmitElement();
                        state.Switch(BeforeAttributeName);
                        break;
                    }
                case '/':
                    {
                        state.IsSelfClosed = true;
                        state.Switch(SelfClosingStartTag);
                        break;
                    }
                case '>':
                    {
                        state.EmitElement();
                        state.Switch(Data);
                        break;
                    }
                default:
                    {
                        if (char.IsLetter(*c))
                        {
                            state.AddToken(*c);
                        }
                        else
                        {
                            state.SetError();
                        }

                        break;
                    }
            }
        }

        private static void _SelfClosingStartTag(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '>':
                    {
                        // Set the self-closing flag of the current tag token. Emit the current tag token. Switch to the data state.
                        state.EmitSelfClosedElement();
                        state.Switch(Data);
                        break;
                    }
                default:
                    {
                        // Parse error. Reconsume the character in the before attribute name state.
                        state.SetError();
                        state.Position--;
                        state.Switch(BeforeAttributeName);
                        break;
                    }
            }
        }

        private static void _CloseTagOpen(TagTokenizerState state, char* c)
        {
            // If the content model flag is set to the RCDATA or CDATA states but no start tag token has ever been emitted by this instance of the tokeniser (fragment case),
            // or, if the content model flag is set to the RCDATA or CDATA states and the next few characters do not match the tag name of the last start tag token 
            // emitted (compared in an ASCII case insensitive manner), or if they do but they are not immediately followed by one of the following characters:

            if ((state.ContentModel == ContentModelType.RCData) || (state.ContentModel == ContentModelType.CData))
            {
                // then emit a U+003C LESS-THAN SIGN character token, a U+002F SOLIDUS character token, and switch to the data state  to process the next input character.
                state.AddToken('<');
                state.AddToken('/');
                state.Switch(Data);
            }
            // Otherwise, if the content model flag is set to the PCDATA state, or if the next few characters do match that tag name, consume the next input character:
            else if (state.ContentModel == ContentModelType.PCData)
            {
                switch (*c)
                {
                    case '>':
                        {
                            state.SetError();

                            state.Switch(Data);

                            break;
                        }
                    default:
                        {
                            if (char.IsLetter(*c))
                            {
                                state.AddToken(*c);
                                state.Switch(TagName);
                            }
                            else
                            {
                                state.SetError();
                                state.Switch(BogusComment);
                            }

                            break;
                        }
                }
            }
        }

        private static void _BeforeAttributeName(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '\t':
                case '\r':
                case '\n':
                case ' ':
                    {
                        break;
                    }
                case '/':
                    {
                        state.Switch(SelfClosingStartTag);
                        break;
                    }
                default:
                    {
                        state.AddToken(*c);
                        state.Switch(AttributeName);
                        break;
                    }
            }
        }

        private static void _AttributeName(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '\t':
                case '\r':
                case '\n':
                case ' ':
                    {
                        state.Switch(AfterAttributeName);
                        break;
                    }
                case '/':
                    {
                        state.Switch(SelfClosingStartTag);
                        break;
                    }
                case '=':
                    {
                        state.EmitAttribute();
                        state.Switch(BeforeAttributeValue);
                        break;
                    }
                case '>':
                    {
                        state.EmitElement();
                        state.Switch(Data);
                        break;
                    }
                default:
                    {
                        state.AddToken(*c);
                        break;
                    }
            }
        }

        private static void _AfterAttributeNameAnythingElse(TagTokenizerState state, char* c)
        {
            // Start a new attribute in the current tag token. 
            state.EmitAttribute();
            // Set that attribute's name to the current input character, and its value to the empty string. Switch to the attribute name state.
            state.AddToken(*c);
            state.Switch(AttributeName);
        }

        private static void _AfterAttributeName(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '\t':
                case '\r':
                case '\n':
                case ' ':
                    {
                        //Stay in the after attribute name state.
                        break;
                    }
                case '/':
                    {
                        state.EmitAttribute();
                        // Switch to the self-closing start tag state.
                        state.Switch(SelfClosingStartTag);
                        break;
                    }
                case '=':
                    {
                        state.EmitAttribute();
                        //Switch to the before attribute value state.
                        state.Switch(BeforeAttributeValue);
                        break;
                    }
                case '>':
                    {
                        state.EmitAttribute();
                        //Emit the current tag token. Switch to the data state.
                        state.EmitElement();
                        state.Switch(Data);
                        break;
                    }
                // U+0022 QUOTATION MARK (")
                case '\"':
                // U+0027 APOSTROPHE (')
                case '\'':
                    {
                        // Parse error. Treat it as per the "anything else" entry below.
                        state.SetError();
                        _AfterAttributeNameAnythingElse(state, c);
                        break;
                    }
                default:
                    {
                        // U+0041 LATIN CAPITAL LETTER A through to U+005A LATIN CAPITAL LETTER Z
                        // Anything else
                        _AfterAttributeNameAnythingElse(state, c);
                        break;
                    }
            }
        }

        private static void _BeforeAttributeValue(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '\t':
                case '\r':
                case '\n':
                case ' ':
                    {
                        // Stay in the before attribute value state.
                        break;
                    }
                case '"':
                    {
                        // Switch to the attribute value (double-quoted) state.
                        state.Switch(AttributeValueDoubleQuoted);
                        break;
                    }
                case '\'':
                    {
                        // Switch to the attribute value (single-quoted) state.
                        state.Switch(AttributeValueSingleQuoted);
                        break;
                    }
                case '&':
                    {
                        // Switch to the attribute value (unquoted) state  and reconsume this input character.
                        state.Switch(AttributeValueUnQuoted);
                        break;
                    }
                case '>':
                    {
                        // Parse error. 
                        state.SetError();
                        // Emit the current tag token. Switch to the data state.
                        state.EmitElement();
                        state.Switch(Data);
                        break;
                    }
                case '=':
                    {
                        // Parse error. Treat it as per the "anything else" entry below.
                        state.SetError();
                        state.AddToken(*c);
                        state.Switch(AttributeValueUnQuoted);
                        break;
                    }
                // Anything else
                default:
                    {
                        // Append the current input character to the current attribute's value. Switch to the attribute value (unquoted) state.
                        state.AddToken(*c);
                        state.Switch(AttributeValueUnQuoted);
                        break;
                    }
            }
        }

        private static void _AttributeValueDoubleQuoted(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '"':
                    {
                        state.EmitAttributeValue();
                        state.Switch(AfterAttributeValueQuoted);
                        break;
                    }
                case '&':
                    {
                        state.PushState(AttributeValueCharacterReference);
                        break;
                    }
                default:
                    {
                        state.AddToken(*c);
                        break;
                    }
            }
        }

        private static void _AttributeValueSingleQuoted(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '\'':
                    {
                        state.EmitAttributeValue();
                        state.Switch(AfterAttributeValueQuoted);
                        break;
                    }
                case '&':
                    {
                        state.PushState(AttributeValueCharacterReference);
                        break;
                    }
                default:
                    {
                        state.AddToken(*c);
                        break;
                    }
            }
        }

        private static void _AttributeValueUnQuoted(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '\t':
                case '\r':
                case '\n':
                case ' ':
                    {
                        state.EmitAttributeValue();
                        state.Switch(BeforeAttributeName);
                        break;
                    }
                case '&':
                    {
                        state.PushState(AttributeValueCharacterReference);
                        break;
                    }
                case '>':
                    {
                        state.EmitAttributeValue();
                        state.Switch(Data);
                        break;
                    }
                default:
                    {
                        state.AddToken(*c);
                        break;
                    }
            }
        }

        private static void _AttributeValueCharacterReference(TagTokenizerState state, char* c)
        {
            char? consumedCharacter = ConsumeCharacter(state);

            if (consumedCharacter == null)
            {
                state.AddToken('&');
            }
            else
            {
                state.AddToken(consumedCharacter.Value);
            }

            state.PopState();
        }

        private static void _AfterAttributeValueQuoted(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '\t':
                case '\r':
                case '\n':
                case ' ':
                    {
                        state.Switch(BeforeAttributeName);
                        break;
                    }
                case '/':
                    {
                        state.Switch(SelfClosingStartTag);
                        break;
                    }
                case '>':
                    {
                        state.Switch(Data);
                        break;
                    }
                default:
                    {
                        state.Position--;
                        state.Switch(BeforeAttributeName);
                        break;
                    }
            }
        }

        private static void _BogusComment(TagTokenizerState state, char* c)
        {
            // (This can only happen if the content model flag is set to the PCDATA state.)

            switch (*c)
            {
                case '>':
                    {
                        state.EmitComment();
                        state.Switch(Data);
                        break;
                    }
                default:
                    {
                        state.AddToken(*c);
                        break;
                    }
            }
        }

        private static void _CommentStart(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '-':
                    {
                        state.Switch(CommentStartDash);
                        break;
                    }
                case '>':
                    {
                        state.SetError();
                        state.Switch(Data);
                        break;
                    }
                default:
                    {
                        state.AddToken(*c);
                        state.Switch(Comment);
                        break;
                    }
            }
        }

        private static void _CommentStartDash(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '-':
                    {
                        state.Switch(CommentEnd);
                        break;
                    }
                case '>':
                    {
                        state.SetError();
                        state.Switch(Data);
                        break;
                    }
                default:
                    {
                        //state.AddToken('-');
                        state.AddToken(*c);
                        state.Switch(Comment);
                        break;
                    }
            }
        }

        private static void _Comment(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '-':
                    {
                        state.Switch(CommentEndDash);
                        break;
                    }
                default:
                    {
                        state.AddToken(*c);
                        break;
                    }
            }
        }

        private static void _CommentEndDash(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '-':
                    {
                        state.Switch(CommentEnd);
                        break;
                    }
                default:
                    {
                        state.AddToken('-');
                        state.AddToken(*c);
                        state.Switch(Comment);
                        break;
                    }
            }
        }

        private static void _CommentEnd(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '>':
                    {
                        state.EmitComment();
                        state.Switch(Data);
                        break;
                    }
                case '-':
                    {
                        break;
                    }
                default:
                    {
                        state.AddToken('-');
                        state.AddToken('-');
                        state.AddToken(*c);
                        state.Switch(Comment);
                        break;
                    }
            }
        }

        private static void _MarkupDeclaration(TagTokenizerState state, char* c)
        {
            // (This can only happen if the content model flag is set to the PCDATA state.)

            string tmpVal = new string(c, 0, 2);

            // If the next two characters are both U+002D HYPHEN-MINUS (-) characters, consume those two characters, 
            // create a comment token whose data is the empty string, and switch to the comment start state.
            if (tmpVal == "--")
            {
                state.OpenElement();
                state.Switch(CommentStart);
            }
            else
            {
                tmpVal = new string(c, 0, 7);

                // Otherwise, if the next seven characters are an ASCII case-insensitive match for the word "DOCTYPE", then consume those characters and switch to the DOCTYPE state.
                if (string.Equals(tmpVal, "DOCTYPE", StringComparison.OrdinalIgnoreCase))
                {
                    state.Position += 6;
                    state.Switch(DocType);
                }
                // Otherwise, if the insertion mode is "in foreign content" and the current node is not an element in the HTML namespace and 
                // the next seven characters are an ASCII case-sensitive match for the string "[CDATA[" 
                // (the five uppercase letters "CDATA" with a U+005B LEFT SQUARE BRACKET character before and after), then 
                // consume those characters and switch to the CDATA section state (which is unrelated to the content model flag's CDATA state).
                else if (string.Equals(tmpVal, "[CDATA[", StringComparison.Ordinal))
                {
                    state.Position += 6;
                    state.Switch(CDataSection);
                }
                else
                {
                    // Otherwise, this is a parse error. 
                    // Switch to the bogus comment state. 
                    // The next character that is consumed, if any, is the first character that will be in the comment.
                    state.SetError();
                    state.Position--;
                    state.Switch(BogusComment);
                }
            }
        }

        private static void _DocType(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '\t':
                case '\r':
                case '\n':
                case ' ':
                    {
                        // Switch to the before DOCTYPE name state.
                        state.Switch(BeforeDocTypeName);

                        break;
                    }
                default:
                    {
                        // Parse error. Reconsume the current character in the before DOCTYPE name state.
                        state.SetError();
                        _BeforeDocTypeName(state, c);
                        break;
                    }
            }
        }

        private static void _BeforeDocTypeName(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '\t':
                case '\r':
                case '\n':
                case ' ':
                    {
                        // Stay in the before DOCTYPE name state.
                        break;
                    }
                case '>':
                    {
                        // Parse error. Create a new DOCTYPE token. Set its force-quirks flag to on. Emit the token. Switch to the data state.
                        state.SetError();
                        state.EmitDocType();
                        state.Switch(Data);

                        break;
                    }
                default:
                    {
                        // Create a new DOCTYPE token. Set the token's name to the lowercase version of the input character (add 0x0020 to the character's code point). 
                        // Switch to the DOCTYPE name state.
                        state.AddToken(c);
                        state.Switch(DocTypeName);

                        break;
                    }
            }
        }

        private static void _DocTypeName(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '\t':
                case '\r':
                case '\n':
                case ' ':
                    {
                        // Switch to the after DOCTYPE name state.
                        state.EmitDocTypeName();
                        state.Switch(AfterDocTypeName);
                        break;
                    }
                case '>':
                    {
                        // Emit the current DOCTYPE token. Switch to the data state.
                        state.EmitDocTypeName();
                        state.EmitDocType();
                        state.Switch(Data);
                        break;
                    }
                default:
                    {
                        // Append the lowercase version of the input character (add 0x0020 to the character's code point) to the current DOCTYPE token's name. Stay in the DOCTYPE name state.
                        state.AddToken(c);
                        break;
                    }
            }
        }

        private static void _AfterDocTypeName(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '\t':
                case '\r':
                case '\n':
                case ' ':
                    {
                        // Stay in the after DOCTYPE name state.
                        break;
                    }
                case '>':
                    {
                        // Emit the current DOCTYPE token. Switch to the data state.
                        state.EmitDocType();
                        state.Switch(Data);
                        break;
                    }
                // Anything else
                default:
                    {
                        string tokenVal = new string(c, 0, 6);

                        // If the next six characters are an ASCII case-insensitive match for the word "PUBLIC", then consume those characters 
                        // and switch to the before DOCTYPE public identifier state.
                        if (tokenVal.Equals("PUBLIC", StringComparison.OrdinalIgnoreCase))
                        {
                            state.Position += 6;
                            state.Switch(BeforeDocTypePublicIdentifier);
                        }
                        // Otherwise, if the next six characters are an ASCII case-insensitive match for the word "SYSTEM", 
                        // then consume those characters and switch to the before DOCTYPE system identifier state.
                        else if (tokenVal.Equals("SYSTEM", StringComparison.OrdinalIgnoreCase))
                        {
                            state.Position += 6;
                            state.Switch(BeforeDocTypeSystemIdentifier);
                        }
                        // Otherwise, this is the parse error. Set the DOCTYPE token's force-quirks flag to on. Switch to the bogus DOCTYPE state.
                        else
                        {
                            state.SetError();
                            state.Switch(BogusDocType);
                        }

                        break;
                    }
            }
        }

        private static void _BeforeDocTypePublicIdentifier(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '\t':
                case '\r':
                case '\n':
                case ' ':
                    {
                        // Stay in the before DOCTYPE public identifier state.
                        break;
                    }
                case '\"':
                    {
                        // Set the DOCTYPE token's public identifier to the empty string (not missing), then switch to the DOCTYPE public identifier (double-quoted) state.
                        state.Switch(DocTypePublicIdentifierDoubleQuoted);
                        break;
                    }
                case '\'':
                    {
                        // Set the DOCTYPE token's public identifier to the empty string (not missing), then switch to the DOCTYPE public identifier (single-quoted) state.
                        state.Switch(DocTypePublicIdentifierSingleQuoted);
                        break;
                    }
                case '>':
                    {
                        // Parse error. Set the DOCTYPE token's force-quirks flag to on. Emit that DOCTYPE token. Switch to the data state.
                        state.SetError();
                        state.EmitDocType();
                        state.Switch(Data);
                        break;
                    }
                // TODO : EOF , Parse error. Set the DOCTYPE token's force-quirks flag to on. Emit that DOCTYPE token. Switch to the data state.
                default:
                    {
                        // Parse error. Set the DOCTYPE token's force-quirks flag to on. Switch to the bogus DOCTYPE state.
                        state.SetError();
                        state.Switch(BogusDocType);
                        break;
                    }
            }
        }

        private static void _DocTypePublicIdentifierDoubleQuoted(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '\"':
                    {
                        // Switch to the after DOCTYPE public identifier state.
                        state.EmitDocTypePublicIdentifier();
                        state.Switch(AfterDocTypePublicIdentifier);
                        break;
                    }
                case '>':
                    {
                        // Parse error. Set the DOCTYPE token's force-quirks flag to on. Emit that DOCTYPE token. Switch to the data state.
                        state.SetError();
                        state.EmitDocType();
                        state.Switch(Data);
                        break;
                    }
                // TODO : EOF, Parse error. Set the DOCTYPE token's force-quirks flag to on. Emit that DOCTYPE token. Reconsume the EOF character in the data state.
                default:
                    {
                        // Append the current input character to the current DOCTYPE token's public identifier. Stay in the DOCTYPE public identifier (double-quoted) state.
                        state.AddToken(c);
                        break;
                    }
            }
        }

        private static void _DocTypePublicIdentifierSingleQuoted(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '\'':
                    {
                        // Switch to the after DOCTYPE public identifier state.
                        state.EmitDocTypePublicIdentifier();
                        state.Switch(AfterDocTypePublicIdentifier);
                        break;
                    }
                case '>':
                    {
                        // Parse error. Set the DOCTYPE token's force-quirks flag to on. Emit that DOCTYPE token. Switch to the data state.
                        state.SetError();
                        state.EmitDocType();
                        state.Switch(Data);
                        break;
                    }
                // TODO: EOF, Parse error. Set the DOCTYPE token's force-quirks flag to on. Emit that DOCTYPE token. Reconsume the EOF character in the data state.
                default:
                    {
                        // Append the current input character to the current DOCTYPE token's public identifier. Stay in the DOCTYPE public identifier (single-quoted) state.
                        state.AddToken(c);
                        break;
                    }
            }
        }

        private static void _AfterDocTypePublicIdentifier(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '\n':
                case '\r':
                case '\t':
                case ' ':
                    {
                        // Stay in the after DOCTYPE public identifier state.
                        break;
                    }
                case '\"':
                    {
                        // Set the DOCTYPE token's system identifier to the empty string (not missing), then switch to the DOCTYPE system identifier (double-quoted) state.
                        state.Switch(DocTypeSystemIdentifierDoubleQuoted);
                        break;
                    }
                case '\'':
                    {
                        // Set the DOCTYPE token's system identifier to the empty string (not missing), then switch to the DOCTYPE system identifier (single-quoted) state.
                        state.Switch(DocTypeSystemIdentifierSingleQuoted);
                        break;
                    }
                case '>':
                    {
                        // Emit the current DOCTYPE token. Switch to the data state.
                        state.EmitDocType();
                        state.Switch(Data);
                        break;
                    }
                // TODO : EOF , Parse error. Set the DOCTYPE token's force-quirks flag to on. Emit that DOCTYPE token. Reconsume the EOF character in the data state.
                default:
                    {
                        // Parse error. Set the DOCTYPE token's force-quirks flag to on. Switch to the bogus DOCTYPE state.
                        state.SetError();
                        state.Switch(BogusDocType);
                        break;
                    }
            }
        }

        private static void _BeforeDocTypeSystemIdentifier(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '\n':
                case '\r':
                case '\t':
                case ' ':
                    {
                        // Stay in the before DOCTYPE system identifier state.
                        break;
                    }
                case '\"':
                    {
                        // Set the DOCTYPE token's system identifier to the empty string (not missing), then switch to the DOCTYPE system identifier (double-quoted) state.
                        state.Switch(DocTypeSystemIdentifierDoubleQuoted);
                        break;
                    }
                case '\'':
                    {
                        // Set the DOCTYPE token's system identifier to the empty string (not missing), then switch to the DOCTYPE system identifier (single-quoted) state.
                        state.Switch(DocTypeSystemIdentifierSingleQuoted);
                        break;
                    }
                case '>':
                    {
                        // Parse error. Set the DOCTYPE token's force-quirks flag to on. Emit that DOCTYPE token. Switch to the data state.
                        state.SetError();
                        state.EmitDocType();
                        state.Switch(Data);
                        break;
                    }
                // TODO : EOF , Parse error. Set the DOCTYPE token's force-quirks flag to on. Emit that DOCTYPE token. Reconsume the EOF character in the data state.
                default:
                    {
                        // Parse error. Set the DOCTYPE token's force-quirks flag to on. Switch to the bogus DOCTYPE state.
                        state.SetError();
                        state.Switch(BogusDocType);
                        break;
                    }
            }
        }

        private static void _DocTypeSystemIdentifierDoubleQuoted(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '\"':
                    {
                        // Switch to the after DOCTYPE system identifier state.
                        state.EmitDocTypeSystemIdentifier();
                        state.Switch(AfterDocTypeSystemIdentifier);
                        break;
                    }
                case '>':
                    {
                        // Parse error. Set the DOCTYPE token's force-quirks flag to on. Emit that DOCTYPE token. Switch to the data state.
                        state.EmitDocType();
                        state.Switch(Data);
                        break;
                    }
                // TODO: EOF , Parse error. Set the DOCTYPE token's force-quirks flag to on. Emit that DOCTYPE token. Reconsume the EOF character in the data state.
                default:
                    {
                        // Append the current input character to the current DOCTYPE token's system identifier. Stay in the DOCTYPE system identifier (double-quoted) state.
                        state.AddToken(c);
                        break;
                    }
            }
        }

        private static void _DocTypeSystemIdentifierSingleQuoted(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '\'':
                    {
                        // Switch to the after DOCTYPE system identifier state.
                        state.EmitDocTypeSystemIdentifier();
                        state.Switch(AfterDocTypeSystemIdentifier);
                        break;
                    }
                case '>':
                    {
                        // Parse error. Set the DOCTYPE token's force-quirks flag to on. Emit that DOCTYPE token. Switch to the data state.
                        state.EmitDocType();
                        state.Switch(Data);
                        break;
                    }
                // TODO: EOF , Parse error. Set the DOCTYPE token's force-quirks flag to on. Emit that DOCTYPE token. Reconsume the EOF character in the data state.
                default:
                    {
                        // Append the current input character to the current DOCTYPE token's system identifier. Stay in the DOCTYPE system identifier (single-quoted) state.
                        state.AddToken(c);
                        break;
                    }
            }
        }

        private static void _AfterDocTypeSystemIdentifier(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '\n':
                case '\r':
                case '\t':
                case ' ':
                    {
                        // Stay in the after DOCTYPE system identifier state.
                        break;
                    }
                case '>':
                    {
                        // Emit the current DOCTYPE token. Switch to the data state.
                        state.EmitDocType();
                        state.Switch(Data);
                        break;
                    }
                // TODO : Parse error. Set the DOCTYPE token's force-quirks flag to on. Emit that DOCTYPE token. Reconsume the EOF character in the data state.
                default:
                    {
                        // Parse error. Switch to the bogus DOCTYPE state. (This does not set the DOCTYPE token's force-quirks flag to on.)
                        state.SetError();
                        state.Switch(BogusDocType);
                        break;
                    }
            }
        }

        private static void _BogusDocType(TagTokenizerState state, char* c)
        {
            switch (*c)
            {
                case '>':
                    {
                        // Emit the DOCTYPE token. Switch to the data state.
                        state.EmitDocType();
                        state.Switch(Data);
                        break;
                    }
                // TODO: EOF, Emit the DOCTYPE token. Reconsume the EOF character in the data state.
                default:
                    {
                        // Stay in the bogus DOCTYPE state.
                        break;
                    }
            }
        }

        private static void _CDataSection(TagTokenizerState state, char* c)
        {
            // (This can only happen if the content model flag is set to the PCDATA state, and is unrelated to the content model flag's CDATA state.)

            // Consume every character up to the next occurrence of the three character sequence 
            // U+005D RIGHT SQUARE BRACKET U+005D RIGHT SQUARE BRACKET U+003E GREATER-THAN SIGN (]]>), or the end of the file (EOF), whichever comes first. 
            // Emit a series of character tokens consisting of all the characters consumed except the matching three character sequence at the end 
            // (if one was found before the end of the file).
            string testString = new string(c, 0, 3);

            if (testString == "]]>")
            {
                state.EmitData();

                // Switch to the data state.
                state.Switch(Data);
            }
            else
            {
                state.AddToken(*c);
            }
        }

        private static char? ConsumeCharacter(TagTokenizerState state)
        {
            char c = state.Buffer[state.Position];

            switch (c)
            {
                case '\t':
                case '\r':
                case '\n':
                case ' ':
                case '<':
                case '&':
                    {
                        return null;
                    }
                case '#':
                    {
                        // TODO : implement
                        return null;
                    }
                default:
                    {
                        int pos = state.Position;

                        while ((pos < state.Length) && ((pos - state.Position) < 10) && (state.Buffer[pos] != ';'))
                        {
                            pos++;
                        }

                        if (pos != state.Length)
                        {
                            string reference = new string(state.Buffer, state.Position, pos - state.Position);

                            // TODO : implement
                            switch (reference)
                            {
                                case "nbsp":
                                    state.Position = pos;
                                    return ' ';
                                case "amp":
                                    state.Position = pos;
                                    return '&';
                            }
                        }

                        return null;
                    }
            }
        }
    }
}
