using EasyScript.ast.values;
using EasyScript.lexer;
using EasyScript.lib;
using System;

namespace EasyScript.ast.expressions
{
    internal class BinaryExpression : Expression
    {
        private Expression expr1, expr2;
        private Char operation;
        private Token myToken;

        public BinaryExpression(Char Operation, Expression expr1, Expression expr2, Token token)
        {
            this.operation = Operation;
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.myToken = token;
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
                    case '+': return new StringValue(string1 + string2);
                    case '*':
                        {
                            int iterations = (int)val2.asDouble();
                            if (iterations > 2048)
                            {
                                throw new RuntimeError($"Too many multiplication iterations for string {iterations} > 2048", myToken);
                            }
                            String buffer = "";
                            for (int i = 0; i < iterations; i++)
                            {
                                buffer += string1;
                            }
                            return new StringValue(buffer);
                        }
                }
            }
            if (val2.GetType() == typeof(StringValue))
            {
                String string1 = val1.asString();
                String string2 = val2.asString();
                switch (this.operation)
                {
                    default:
                    case '+': return new StringValue(string1 + string2);
                    case '*':
                        {
                            int iterations = (int)val1.asDouble();
                            if (iterations > 2048)
                            {
                                throw new RuntimeError($"Too many multiplication iterations for string {iterations} > 2048", myToken);
                            }
                            String buffer = "";
                            for (int i = 0; i < iterations; i++)
                            {
                                buffer += string2;
                            }
                            return new StringValue(buffer);
                        }
                }
            }

            double number1 = val1.asDouble();
            double number2 = val2.asDouble();
            switch (this.operation)
            {
                default:
                case '+': return new NumberValue(number1 + number2);
                case '-': return new NumberValue(number1 - number2);
                case '*': return new NumberValue(number1 * number2);
                case '/': return new NumberValue(number1 / number2);
            }
        }
    }
}
