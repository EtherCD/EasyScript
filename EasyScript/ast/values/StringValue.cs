using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.values
{
    internal class StringValue : Value
    {
        private String value;

        public StringValue(String value)
        {
            this.value = value;
        }

        public double asDouble()
        {
            int var;
            int.TryParse(value, out var);
            return var;
        }

        public string asString()
        {
            return value;
        }
    }
}
