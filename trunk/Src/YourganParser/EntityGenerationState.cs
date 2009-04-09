using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.Parser
{
    public class EntityGenerationState
    {
        public EntityGenerationState(TagTokenizerState tagTokenizer, System.Xml.XmlDocument document)
        {
            this.htmlTokenization = new TreeConstructionState(tagTokenizer, document);
        }

        public void Close()
        {
            Flush();
        }

        TreeConstructionState htmlTokenization;

        public TreeConstructionState HTMLTokenization
        {
            get
            {
                return htmlTokenization;
            }
        }

        Entity entity = new Entity();

        string lastAttributeName;

        private void ProcessEntity(Entity e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
#if(DEBUG)
                //System.Diagnostics.Debug.WriteLineIf(e.Type != EntityType.WhiteSpace, e);
#endif
                htmlTokenization.Emit(e);
            }
        }

        private void Flush()
        {
            ProcessEntity(entity);

            lastAttributeName = null;
        }

        public void Emit(string docTypeName, string publicIdentifier, string systemIdentifier)
        {
            Flush();

            entity.Reset(docTypeName, EntityType.DOCType);

            entity.Data1 = publicIdentifier;
            entity.Data2 = systemIdentifier;
        }

        public void EmitSelfClosed()
        {
            entity.IsSelfClosed = true;
        }

        public void Emit(string token, TokenType type)
        {
            switch (type)
            {
                case TokenType.OpenElement:
                    {
                        Flush();

                        entity.Reset(token, EntityType.OpenElement);

                        break;
                    }
                case TokenType.Attribute:
                    {
                        lastAttributeName = token;
                        entity.Attributes[lastAttributeName] = "";
                        break;
                    }
                case TokenType.AttributeValue:
                    {
                        entity.Attributes[lastAttributeName] = token;
                        break;
                    }
                case TokenType.CloseElement:
                    {
                        Flush();

                        entity.Reset(token, EntityType.CloseElement);
                        break;
                    }
                case TokenType.DOCType:
                    {
                        throw new InvalidOperationException("Use overloaded Emit method to submit doctype token");
                    }
                default:
                    {
                        Flush();

                        EntityType t = (EntityType)((int)type);

                        entity.Reset(token, t);

                        Flush();

                        entity.Reset();

                        break;
                    }
            }
        }
    }
}
