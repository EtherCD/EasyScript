using EasyScript.ast.values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.lib
{
    internal interface Function
    {
        Value execute(params Value[] args);
    }
}
