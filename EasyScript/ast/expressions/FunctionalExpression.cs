using EasyScript.ast.values;
using EasyScript.lexer;
using EasyScript.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return Functions.get(name).execute(values);
            } catch (Exception e)
            {
                throw new RuntimeError(e.Message, myToken);
            }

        }
    }
}
