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
    public class Entity
    {
        public string Data;
        public string Data1;
        public string Data2;

        public bool IsSelfClosed;

        public EntityType Type;

        public Dictionary<string, string> Attributes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public void Reset()
        {
            this.Data = null;
            this.IsSelfClosed = false;
            this.Type = EntityType.Data;
            this.Attributes.Clear();
        }

        public void Reset(string data, EntityType type)
        {
            this.Data = data;
            this.Type = type;
            this.IsSelfClosed = false;
            this.Attributes.Clear();
        }

        public bool IsTag(string tagName)
        {
            return string.Equals(this.Data, tagName, StringComparison.OrdinalIgnoreCase);
        }

        public bool IsOneOfTag(params string[] tags)
        {
            return IsOneOf(this.Data, tags);
        }

        public override string ToString()
        {
            StringBuilder o = new StringBuilder();

            o.Append("(");
            o.Append(Type.ToString().PadLeft(20));
            o.Append(") ");

            o.Append(Data);

            if (this.IsSelfClosed)
                o.Append("(SelfClose)");

            if (this.Attributes.Count > 0)
            {
                o.Append("[");

                string pre = "";

                foreach (KeyValuePair<string, string> pair in Attributes)
                {
                    o.Append(pre);
                    o.Append(pair.Key);
                    o.Append("=\"");
                    o.Append(pair.Value);
                    o.Append("\"");

                    pre = ";";
                }

                o.Append("]");
            }

            return o.ToString();
        }

        public static bool IsTag(string actual, string expected)
        {
            return string.Equals(actual, expected, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsOneOf(string currentTagName, params string[] tags)
        {
            foreach (string tagName in tags)
            {
                if (string.Equals(currentTagName, tagName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        public static bool IsSpecialTag(string tagName)
        {
            return IsOneOf(tagName, "address", "area", "article", "aside", "base", "basefont", "bgsound",
                "blockquote", "body", "br", "center", "col", "colgroup", "command", "datagrid", "dd", "details", "dialog",
                "dir", "div", "dl", "dt", "embed", "eventsource", "fieldset", "figure", "footer", "form", "frame", "frameset",
                "h1", "h2", "h3", "h4", "h5", "h6", "head", "header", "hr", "iframe", "img", "input", "isindex", "li", "link",
                "listing", "menu", "meta", "nav", "noembed", "noframes", "noscript", "ol", "p", "param", "plaintext", "pre",
                "script", "section", "select", "spacer", "style", "tbody", "textarea", "tfoot", "thead", "title", "tr", "ul", "wbr");
        }

        public static bool IsScopingTag(string tagName)
        {
            return IsOneOf(tagName, "applet", "button", "caption", "html", "marquee", "object", "table", "td", "th");
        }

        public static bool IsFormattingTag(string tagName)
        {
            return IsOneOf(tagName, "a", "b", "big", "code", "em", "font", "i", "nobr", "s", "small", "strike", "strong", "tt", "u");
        }

        public static bool IsPhrasingTag(string tagName)
        {
            // All other elements found while parsing an HTML document. 
            return (!IsSpecialTag(tagName) && !IsScopingTag(tagName) && !IsFormattingTag(tagName));
        }
    }
}
