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
        public const string Html = "HTML";
        public const string Head = "HEAD";
        public const string Title = "TITLE";
        public const string Body = "BODY";
        public const string FrameSet = "FRAMESET";

        public static bool IsSame(string localName, string nodeName)
        {
            return string.Equals(localName, nodeName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
