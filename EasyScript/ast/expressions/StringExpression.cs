using EasyScript.ast.values;
using System;

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
