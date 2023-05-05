using EasyScript.ast.values;
using System;

namespace EasyScript.ast.expressions
{
    internal class UnaryExpression : Expression
    {
        private Expression expr1;
        private Char operation;

        public UnaryExpression(Char Operation, Expression expr1)
        {
            this.operation = Operation;
            this.expr1 = expr1;
        }

        public Value eval()
        {
            switch (this.operation)
            {
                default:
                case '+': return this.expr1.eval();
                case '-': return new NumberValue(-this.expr1.eval().asDouble());
            }
        }
    }
}
