using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NUnit.Framework;
using System.Xml.XPath;

namespace Yourgan.Parser.UnitTest
{
    public abstract class FixtureBase
    {
        protected System.Xml.XmlDocument LoadDocument(string html)
        {
            return LoadDocument(html, null);
        }

        protected System.Xml.XmlDocument LoadDocument(string html, EventHandler<EntityErrorEventArgs> errorHandler)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(html);

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();

            using (DocumentStream stream = new DocumentStream(doc))
            {
                if (errorHandler != null)
                {
                    stream.EntityError += errorHandler;
                }

                using (Stream input = new MemoryStream(bytes))
                {
                    int size = 512;
                    byte[] buffer = new byte[size];

                    while (size > 0)
                    {
                        size = input.Read(buffer, 0, size);

                        stream.Write(buffer, 0, size);
                    }
                }
            }

            return doc;
        }

        private XPathNavigator GetNavigator(System.Xml.XmlDocument doc)
        {
            XPathNavigator nav = doc.CreateNavigator();

            return nav;
        }

        private XPathNavigator GetSingleNode(System.Xml.XmlDocument doc, string xpath)
        {
            XPathNavigator nav = GetNavigator(doc);

            System.Xml.XmlNamespaceManager manager = new System.Xml.XmlNamespaceManager(doc.NameTable);

            manager.AddNamespace("h", StdNamespaces.HTML);

            return nav.SelectSingleNode(xpath, manager);
        }

        protected void Eval(System.Xml.XmlDocument doc, string xpath, string value)
        {
            XPathNavigator node = GetSingleNode(doc, xpath);

            if (node == null)
                Assert.Fail(xpath + " not found");

            Assert.AreEqual(value, node.Value);
        }

        protected void EvalAsNull(System.Xml.XmlDocument doc, string xpath)
        {
            XPathNavigator node = GetSingleNode(doc, xpath);

            Assert.IsNull(node);
        }

        protected void EvalAsEmpty(System.Xml.XmlDocument doc, string xpath)
        {
            XPathNavigator node = GetSingleNode(doc, xpath);

            Assert.IsNotNull(node);

            Assert.IsEmpty(node.Value);
        }
    }
}
