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

namespace Yourgan.Core.DOM.HTML
{
    public static class HTMLTagNames
    {
        public const string Html = "html";
        public const string Head = "head";
        public const string Title = "title";
        public const string Body = "body";
        public const string FrameSet = "frameset";
        public const string Br = "br";
        public const string Hr = "hr";
        public const string Div = "div";
        public const string Form = "form";
        public const string H1 = "h1";
        public const string H2 = "h2";
        public const string H3 = "h3";
        public const string H4 = "h4";
        public const string H5 = "h5";
        public const string H6 = "h6";
// ReSharper disable InconsistentNaming
        public const string IFrame = "iframe";
// ReSharper restore InconsistentNaming
        public const string Img = "img";
        public const string P = "p";
        public const string Option = "option";
        public const string Meta = "meta";
        public const string Map = "map";
        public const string Li = "li";
        public const string Legend = "legend";
        public const string Caption = "caption";
        public const string THead = "thead";
        public const string TFoot = "tfoot";
        public const string ColGroup = "colgroup";

        public static bool IsSame(string localName, string nodeName)
        {
            return string.Equals(localName, nodeName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
