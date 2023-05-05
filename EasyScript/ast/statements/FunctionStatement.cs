using EasyScript.ast.expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.statements
{
    internal class FunctionStatement : Statement
    {
        private FunctionalExpression function;

        public FunctionStatement(FunctionalExpression function)
        {
            this.function = function;
        }

        public void execute()
        {
            function.eval();
        }
    }
}
