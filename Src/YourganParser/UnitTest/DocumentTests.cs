using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Xml;

namespace Yourgan.Parser.UnitTest
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
