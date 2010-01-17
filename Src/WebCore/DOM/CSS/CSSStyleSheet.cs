﻿// /*
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

namespace Yourgan.Core.DOM.CSS
{
    public class CSSStyleSheet : StyleSheet
    {
        private CSSRule ownerRule;

        public CSSRule OwnerRule
        {
            get
            {
                return ownerRule;
            }
        }

        public CSSRuleList CSSRules
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ulong InsertRule(string rule, ulong index)
        {
            throw new NotImplementedException();
        }

        public void DeleteRule(ulong index)
        {
            throw new NotImplementedException();
        }
    }
}