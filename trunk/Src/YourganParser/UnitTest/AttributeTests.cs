using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Yourgan.Parser.UnitTest
{
    [TestFixture]
    public class AttributeTests : FixtureBase
    {
        [Test]
        public void PlainAttribute()
        {
            string html = "<html><body><div a=\"b\" \t\n\r c=\"d\"></div></body></html>";

            System.Xml.XmlDocument doc = LoadDocument(html);

            Eval(doc, "/h:html/h:body/h:div/@a", "b");
            Eval(doc, "/h:html/h:body/h:div/@c", "d");
        }

        [Test]
        public void PlainSingleQuoteAttribute()
        {
            string html = "<html><body><div a='b' c='d' \t\n e=\"f'></div></body></html>";

            System.Xml.XmlDocument doc = LoadDocument(html);

            EvalAsEmpty(doc, "/h:html/h:body/h:div/@e");
            Eval(doc, "/h:html/h:body/h:div/@a", "b");
            Eval(doc, "/h:html/h:body/h:div/@c", "d");
        }

        [Test]
        public void MissingQuoteAttribute()
        {
            string html = "<html><body><div a=b \n\r c=\"d\"></div></body></html>";

            System.Xml.XmlDocument doc = LoadDocument(html);

            Eval(doc, "/h:html/h:body/h:div/@a", "b");
            Eval(doc, "/h:html/h:body/h:div/@c", "d");
        }

        [Test]
        public void MissingAttributeValue()
        {
            string html = "<html><body><div a \r c=\"d\"></div></body></html>";

            System.Xml.XmlDocument doc = LoadDocument(html);

            EvalAsEmpty(doc, "/h:html/h:body/h:div/@a");
            Eval(doc, "/h:html/h:body/h:div/@c", "d");
        }
    }
}
