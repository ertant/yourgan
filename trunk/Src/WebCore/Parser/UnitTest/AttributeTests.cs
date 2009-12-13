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
using Yourgan.Core.DOM;

namespace Yourgan.Core.Parser.UnitTest
{
    [TestFixture]
    public class AttributeTests : FixtureBase
    {
        [Test]
        public void PlainAttribute()
        {
            string html = "<html><body><div a=\"b\" \t\n\r c=\"d\"></div></body></html>";

            Document doc = LoadDocument(html);

            Eval(doc, "/h:html/h:body/h:div/@a", "b");
            Eval(doc, "/h:html/h:body/h:div/@c", "d");
        }

        [Test]
        public void PlainSingleQuoteAttribute()
        {
            string html = "<html><body><div a='b' c='d' \t\n e=\"f'></div></body></html>";

            Document doc = LoadDocument(html);

            EvalAsEmpty(doc, "/h:html/h:body/h:div/@e");
            Eval(doc, "/h:html/h:body/h:div/@a", "b");
            Eval(doc, "/h:html/h:body/h:div/@c", "d");
        }

        [Test]
        public void MissingQuoteAttribute()
        {
            string html = "<html><body><div a=b \n\r c=\"d\"></div></body></html>";

            Document doc = LoadDocument(html);

            Eval(doc, "/h:html/h:body/h:div/@a", "b");
            Eval(doc, "/h:html/h:body/h:div/@c", "d");
        }

        [Test]
        public void MissingAttributeValue()
        {
            string html = "<html><body><div a \r c=\"d\"></div></body></html>";

            Document doc = LoadDocument(html);

            EvalAsEmpty(doc, "/h:html/h:body/h:div/@a");
            Eval(doc, "/h:html/h:body/h:div/@c", "d");
        }
    }
}


