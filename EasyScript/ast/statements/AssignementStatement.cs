using EasyScript.ast.expressions;
using EasyScript.ast.values;
using EasyScript.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.statements
{
    internal class AssignementStatement : Statement
    {
        private String var;
        private Expression expression;

        public AssignementStatement(string var, Expression expression)
        {
            this.var = var;
            this.expression = expression;
            int stat = Variables.Attempt(var);
            if (stat == 1)
            {
                throw new Exception("Attempting to change a non-existing variable");
            }
            if (stat == 2)
            {
                throw new Exception("Attempt to overwrite a non-rewritable variable");
            }
        }

        public void execute()
        {
            Value result = expression.eval();
            int stat = Variables.change(var, result);
        }
    }
}
