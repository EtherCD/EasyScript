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
    internal class ArrayAcessExpression : Expression
    {
        private Token variable;
        private Expression index;

        public ArrayAcessExpression(Token variable, Expression index)
        {
            this.variable = variable;
            this.index = index;
        }
        public Value eval()
        {
            Value var = Variables.get(variable.getValue());
            try
            {
                if (var.GetType() == typeof(ArrayValue))
                {
                    ArrayValue val = (ArrayValue)var;
                    return val.get((int)index.eval().asDouble());
                }
                else
                {
                    throw new RuntimeError("Array expected", variable);
                }
            }
            catch (Exception e)
            {
                throw new RuntimeError(e.Message, variable);
            }
        }
    }
}
