﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.lib.Errors
{
    internal class BreakError : Exception
    {
        public BreakError() : base("")
        {
        }
    }
}