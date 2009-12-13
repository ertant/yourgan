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
using System.Xml;
using NUnit.Framework;

namespace Yourgan.Core.Parser.UnitTest
{
    [TestFixture]
    public class DocumentTests : FixtureBase
    {
        [Test]
        public void InitialCommentTest()
        {
            string html = @"<!DOCTYPE html><!-- start comment --><html lang=en-US><title>title without head</title></html>";

            System.Xml.XmlDocument doc = LoadDocument(html);

            Assert.AreEqual(3, doc.ChildNodes.Count);

            Assert.AreEqual(XmlNodeType.DocumentType, doc.ChildNodes[0].NodeType);
            Assert.AreEqual("html", doc.ChildNodes[0].Name);
            Assert.AreEqual(XmlNodeType.Comment, doc.ChildNodes[1].NodeType);
            Assert.AreEqual(" start comment ", doc.ChildNodes[1].Value);
            Assert.AreEqual(XmlNodeType.Element, doc.ChildNodes[2].NodeType);
            Assert.AreEqual("html", doc.ChildNodes[2].LocalName);
            Assert.AreEqual("head", doc.ChildNodes[2].ChildNodes[0].LocalName);
            Assert.AreEqual("title", doc.ChildNodes[2].ChildNodes[0].ChildNodes[0].LocalName);
            Assert.AreEqual(1, doc.ChildNodes[2].ChildNodes.Count);
        }

        public void IdentifierTest()
        {
            string html = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd""><html xmlns = ""http://www.w3.org/1999/xhtml"" ></html>;";

            System.Xml.XmlDocument doc = LoadDocument(html);

            Assert.AreEqual(2, doc.ChildNodes.Count);
            Assert.AreEqual("html", doc.DocumentType.Name);
            Assert.AreEqual("-//W3C//DTD XHTML 1.0 Transitional//EN", doc.DocumentType.PublicId);
            Assert.AreEqual("http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd", doc.DocumentType.SystemId);
        }
    }
}


