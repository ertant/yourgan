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
using NUnit.Framework;

namespace Yourgan.Core.DOM.UnitTest
{
    [TestFixture]
    public class BasicTests
    {
        [Test]
        public void CreateElement()
        {
            Document document = new Document();

            // create document element
            document.AppendChild(document.CreateElement("a"));

            // create two child
            Element child = document.CreateElement("b");

            // link secondary
            Element secondChild = document.CreateElement("c");

            secondChild.TextContent = "secondarychild";

            child.AppendChild(secondChild);

            // add to document
            document.DocumentElement.AppendChild(child);

            Assert.IsNull(document.TextContent, "Document TextContent should be null");

            Assert.AreEqual("secondarychild", document.DocumentElement.TextContent, "invalid text content");
        }

        [Test]
        public void TextContentUpdate()
        {
            Document document = new Document();

            // create document element
            document.AppendChild(document.CreateElement("a"));

            // create two child
            Element child = document.CreateElement("b");

            // create secondary
            Element secondChild = document.CreateElement("c");

            child.AppendChild(secondChild);

            // add to document
            document.DocumentElement.AppendChild(child);

            // replace whole content
            document.DocumentElement.TextContent = "replaced";

            Assert.AreEqual("replaced", document.DocumentElement.TextContent, "invalid content");

            Assert.IsNotNull(document.DocumentElement.FirstChild, "element must have a child to hold replaced content");

            Assert.AreEqual(1, document.DocumentElement.ChildNodes.Length, "all childs must replaced with a text node");

            Assert.AreEqual(document.DocumentElement.FirstChild.NodeType, NodeType.Text, "child node should replaced with a text node");

            Assert.IsNull(child.ParentNode, "parentnode must null on first node due removed");

            Assert.IsNotNull(secondChild.OwnerDocument, "ownerdocument must NOT null");

            Assert.IsNotNull(secondChild.ParentNode, "parentnode must NOT null on due parent removal");

            Assert.AreSame(child, secondChild.ParentNode, "second child having invalid parent");

            Assert.IsNotNull(secondChild.OwnerDocument, "ownerdocument must NOT null");
        }
    }
}
