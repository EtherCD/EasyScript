using EasyScript.ast.values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.expressions
{
    internal class StringExpression : Expression
    {
        private String Value;

        public StringExpression(String Value)
        {
            this.Value = Value;
        }

        public Value eval()
        {
            return new StringValue(this.Value);
        }
    }
}
