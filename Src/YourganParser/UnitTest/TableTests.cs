using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Yourgan.Parser.UnitTest
{
    [TestFixture]
    public class TableTests : FixtureBase
    {
        [Test]
        public void PlainTable()
        {
            string html = @"<html><body><table><tr><td>cell1</td></tr></table></body></html>";

            System.Xml.XmlDocument doc = LoadDocument(html);

            Eval(doc, "/h:html/h:body/h:table/h:tbody/h:tr/h:td/text()", "cell1");
        }

        [Test]
        public void MissingTrWithCloseTag()
        {
            string html = @"<html><body><table><td>cell1</td></tr></table></body></html>";

            System.Xml.XmlDocument doc = LoadDocument(html);

            Eval(doc, "/h:html/h:body/h:table/h:tbody/h:tr/h:td/text()", "cell1");
        }

        [Test]
        public void TrWithMissingCloseTag()
        {
            string html = @"<html><body><table><tr><td>cell1</td></html>";

            System.Xml.XmlDocument doc = LoadDocument(html);

            Eval(doc, "/h:html/h:body/h:table/h:tbody/h:tr/h:td/text()", "cell1");
        }
    }
}
