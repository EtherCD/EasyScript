using EasyScript.ast.expressions;
using EasyScript.ast.values;
using EasyScript.lexer;
using EasyScript.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.statements
{
    internal class VarStatement : Statement
    {
        private String var;
        private Expression expression;
        private Token myToken;

        public VarStatement(string var, Expression expression, Token token)
        {
            this.var = var;
            this.expression = expression;
            this.myToken = token;
        }

        public void execute()
        {
            Value result = expression.eval();
            if (!Variables.set(var, result, true))
            {
                throw new RuntimeError("Attempt to create an existing variable", myToken);
            }
        }
    }
}
