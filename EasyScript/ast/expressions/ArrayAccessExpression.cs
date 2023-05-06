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
    internal class ArrayAccessExpression : Expression
    {
        private Token variable;
        private List<Expression> indices;

        public ArrayAccessExpression(Token variable, List<Expression> indices)
        {
            this.variable = variable;
            this.indices = indices;
        }

        public ArrayValue getArray()
        {
            ArrayValue arr = consumeArray(Variables.get(variable.getValue()));
            int last = indices.Count - 1;
            for (int i = 0; i < last; i++)
            {
                arr = consumeArray(arr.get((int)indices[i].eval().asDouble()));
            }
            return arr;
        }

        private ArrayValue consumeArray(Value val)
        {
            if (val.GetType() == typeof(ArrayValue))
            {
                return (ArrayValue) val;
            }
            else
            {
                throw new RuntimeError("Array expected", variable);
            }
        }

        public int getIndex()
        {
            return (int)indices[indices.Count-1].eval().asDouble();
        }

        public Value eval()
        {
            try
            {
                return getArray().get(getIndex());
            }
            catch (Exception e)
            {
                throw new RuntimeError(e.Message, variable);
            }
        }
    }
}
