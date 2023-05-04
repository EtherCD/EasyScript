using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.values
{
    internal class BooleanValue : Value
    {
        private bool value;

        public BooleanValue(bool value)
        {
            this.value = value;
        }

        public bool asBoolean()
        {
            return value;
        }

        public double asDouble()
        {
            return value ? 1 : 0;
        }

        public string asString()
        {
            return "" + value;
        }
    }
}
