using EasyScript.ast.values;

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
