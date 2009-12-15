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
using System.IO;
using System.Text;
using System.Xml.XPath;
using NUnit.Framework;
using Yourgan.Core.DOM;

namespace Yourgan.Core.Parser.UnitTest
{
    public abstract class FixtureBase
    {
        protected Document LoadDocument(string html)
        {
            return LoadDocument(html, null);
        }

        protected Document LoadDocument(string html, EventHandler<EntityErrorEventArgs> errorHandler)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(html);

            Document doc = new Document();

            using (DocumentStream stream = new DocumentStream(doc))
            {
                if (errorHandler != null)
                {
                    stream.EntityError += errorHandler;
                }

                using (Stream input = new MemoryStream(bytes))
                {
                    using (StreamReader reader = new StreamReader(input))
                    {
                        int size = 512;
                        char[] buffer = new char[size];

                        while (size > 0)
                        {
                            size = reader.Read(buffer, 0, size);

                            stream.Write(buffer, 0, size);
                        }
                    }

                }
            }

            return doc;
        }

        private XPathNavigator GetNavigator(Document doc)
        {
            // TODO : Fix here
            // XPathNavigator nav = doc.CreateNavigator();
            // return nav;

            throw new NotImplementedException();
        }

        private XPathNavigator GetSingleNode(Document doc, string xpath)
        {
            XPathNavigator nav = GetNavigator(doc);

            // TODO : Fix here

            // System.Xml.XmlNamespaceManager manager = new System.Xml.XmlNamespaceManager(doc.NameTable);

            // manager.AddNamespace("h", StdNamespaces.HTML);

            // return nav.SelectSingleNode(xpath, manager);

            return nav.SelectSingleNode(xpath);
        }

        protected void Eval(Document doc, string xpath, string value)
        {
            XPathNavigator node = GetSingleNode(doc, xpath);

            if (node == null)
                Assert.Fail(xpath + " not found");

            Assert.AreEqual(value, node.Value);
        }

        protected void EvalAsNull(Document doc, string xpath)
        {
            XPathNavigator node = GetSingleNode(doc, xpath);

            Assert.IsNull(node);
        }

        protected void EvalAsEmpty(Document doc, string xpath)
        {
            XPathNavigator node = GetSingleNode(doc, xpath);

            Assert.IsNotNull(node);

            Assert.IsEmpty(node.Value);
        }
    }
}


