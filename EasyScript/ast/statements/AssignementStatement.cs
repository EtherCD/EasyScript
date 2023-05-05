using EasyScript.ast.expressions;
using EasyScript.ast.values;
using EasyScript.lexer;
using EasyScript.lib;
using System;

namespace EasyScript.ast.statements
{
    internal class AssignementStatement : Statement
    {
        private String var;
        private Expression expression;
        private Token myToken;

        public AssignementStatement(string var, Expression expression, Token token)
        {
            this.var = var;
            this.expression = expression;
            this.myToken = token;
        }

        public void execute()
        {
            Value result = expression.eval();
            int stat = Variables.change(var, result);
            if (stat == 1)
            {
                throw new RuntimeError("Attempting to change a non-existing variable", myToken);
            }
            if (stat == 2)
            {
                throw new RuntimeError("Attempt to overwrite a non-rewritable variable", myToken);
            }
        }
    }
}
