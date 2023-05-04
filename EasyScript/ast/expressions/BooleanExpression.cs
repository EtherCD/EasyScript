using EasyScript.ast.values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.expressions
{
    internal class BooleanExpression : Expression
    {
        bool Value;
        public BooleanExpression(bool val) 
        {
            Value = val; 
        }

        public Value eval()
        {
            return new BooleanValue(Value);
        }
    }
}
