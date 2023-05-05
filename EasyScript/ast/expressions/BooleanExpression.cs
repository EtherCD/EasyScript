using EasyScript.ast.values;

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
