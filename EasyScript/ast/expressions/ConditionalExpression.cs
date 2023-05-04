using EasyScript.ast.values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.expressions
{
    internal class ConditionalExpression : Expression
    {
        private Expression expr1, expr2;
        private String operation;

        public ConditionalExpression(String Operation, Expression expr1, Expression expr2)
        {
            this.operation = Operation;
            this.expr1 = expr1;
            this.expr2 = expr2;
        }

        public Value eval()
        {
            Value val1 = expr1.eval();
            Value val2 = expr2.eval();

            if (val1.GetType() == typeof(StringValue))
            {
                String string1 = val1.asString();
                String string2 = val2.asString();
                switch (this.operation)
                {
                    default:
                    case "==": return new BooleanValue(string1.Equals(string2));
                    case "<": return new BooleanValue(string1.CompareTo(string2) < 0);
                    case ">": return new BooleanValue(string1.CompareTo(string2) > 0);
                    case "<=": return new BooleanValue(string1.CompareTo(string2) <= 0);
                    case ">=": return new BooleanValue(string1.CompareTo(string2) >= 0);
                    case "!=": return new BooleanValue(!string1.Equals(string2));
                }
            }
            if (val2.GetType() == typeof(StringValue))
            {
                String string1 = val1.asString();
                String string2 = val2.asString();
                switch (this.operation)
                {
                    default:
                    case "==": return new BooleanValue(string2.Equals(string1));
                    case "<": return new BooleanValue(string2.CompareTo(string1) < 0);
                    case ">": return new BooleanValue(string2.CompareTo(string1) > 0);
                    case "<=": return new BooleanValue(string2.CompareTo(string1) <= 0);
                    case ">=": return new BooleanValue(string2.CompareTo(string1) >= 0);
                    case "!=": return new BooleanValue(!string2.Equals(string1));
                }
            }

            double number1 = val1.asDouble();
            double number2 = val2.asDouble();
            switch (this.operation)
            {
                default:
                case "==": return new BooleanValue(number1 == number2);
                case "<=": return new BooleanValue(number1 <= number2);
                case ">=": return new BooleanValue(number1 >= number2);
                case "!=": return new BooleanValue(number1 != number2);
                case "<": return new BooleanValue(number1 < number2);
                case ">": return new BooleanValue(number1 > number2);
            }
        }
    }
}
