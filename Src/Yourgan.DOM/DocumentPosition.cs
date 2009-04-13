﻿/*
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

namespace Yourgan.DOM
{
    public enum DocumentPosition : ushort
    {
        DISCONNECTED = 0x01,
        PRECEDING = 0x02,
        FOLLOWING = 0x04,
        CONTAINS = 0x08,
        CONTAINED_BY = 0x10,
        IMPLEMENTATION_SPECIFIC = 0x20
    }
}
