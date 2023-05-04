using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.values
{
    internal class NumberValue : Value
    {
        private double value;

        public NumberValue(double value)
        {
            this.value = value;
        }

        public double asDouble()
        {
            return value;
        }

        public string asString()
        {
            return "" + value;
        }
    }
}
