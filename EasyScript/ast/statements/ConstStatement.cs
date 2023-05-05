using EasyScript.ast.expressions;
using EasyScript.ast.values;
using EasyScript.lexer;
using EasyScript.lib;
using System;

namespace EasyScript.ast.statements
{
    internal class ConstStatement : Statement
    {
        private String var;
        private Expression expression;
        private Token myToken;

        public ConstStatement(string var, Expression expression, Token token)
        {
            this.var = var;
            this.expression = expression;
            this.myToken = token;
        }

        public void execute()
        {
            if (Variables.isExists(var))
            {
                throw new RuntimeError("Attempt to create an existing variable", myToken);
            }
            Value result = expression.eval();
            Variables.set(var, result, false);
        }
    }
}
