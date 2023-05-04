using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.values
{
    interface Value
    {
        double asDouble();
        String asString();
    }
}
