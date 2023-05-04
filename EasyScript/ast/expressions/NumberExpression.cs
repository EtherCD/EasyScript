using EasyScript.ast.values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.expressions
{
    internal class NumberExpression : Expression
    {
        private double Value;
        
        public NumberExpression(double Value)
        {
            this.Value = Value;
        }

        public Value eval()
        {
            return new NumberValue(this.Value);
        }
    }
}
