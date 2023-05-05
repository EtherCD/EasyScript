using EasyScript.ast.values;
using EasyScript.lexer;
using EasyScript.lib;
using System;

namespace EasyScript.ast.expressions
{
    internal class ConstantExpression : Expression
    {
        private String name;
        private Token myToken;

        public ConstantExpression(string name, Token myToken)
        {
            this.name = name;
            this.myToken = myToken;
        }

        public Value eval()
        {
            if (!Variables.isExists(name)) throw new RuntimeError("Constant does not exists", myToken);
            return Variables.get(name);
        }
    }
}
