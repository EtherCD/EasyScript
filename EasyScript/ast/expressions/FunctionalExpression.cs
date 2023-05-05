using EasyScript.ast.values;
using EasyScript.lexer;
using EasyScript.lib;
using System;
using System.Collections.Generic;

namespace EasyScript.ast.expressions
{
    internal class FunctionalExpression : Expression
    {
        private String name;
        private List<Expression> arguments;
        private Token myToken;

        public FunctionalExpression(String name, Token token)
        {
            this.name = name;
            arguments = new List<Expression>();
            this.myToken = token;
        }

        public FunctionalExpression(String name, List<Expression> args)
        {
            this.name = name;
            arguments = args;
        }

        public void addArgument(Expression arg)
        {
            arguments.Add(arg);
        }

        public Value eval()
        {
            int size = arguments.Count;
            Value[] values = new Value[size];
            for (int i = 0; i < size; i++)
            {
                values[i] = arguments[i].eval();
            }
            try
            {
                Function func = Functions.get(name);
                if (func.GetType() == typeof(UserFunction))
                {
                    UserFunction userF = (UserFunction)func;
                    if (size != userF.getArgsCount()) throw new RuntimeError("Args Count mismatch", myToken);

                    for (int i = 0; i < size; i++)
                    {
                        Variables.set(userF.getArgsName(i), values[i], true);
                    }
                }
                return func.execute(values);
            }
            catch (Exception e)
            {
                throw new RuntimeError(e.Message, myToken);
            }

        }
    }
}
