using EasyScript.ast.values;
using EasyScript.lexer;
using EasyScript.lib;
using System;
using System.Collections.Generic;

namespace EasyScript.ast.expressions
{
    internal class ArrayExpression : Expression
    {
        private List<Expression> elements;

        public ArrayExpression(List<Expression> elements)
        {
            this.elements = elements;
        }

        public Value eval()
        {
            int size = elements.Count;
            ArrayValue arr = new ArrayValue(size);
            for (int i = 0; i < size; i++)
            {
                arr.set(i, elements[i].eval());
            }
            return arr;
        }
    }
}
