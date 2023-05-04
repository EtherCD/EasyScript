using EasyScript.ast.expressions;
using EasyScript.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.statements
{
    internal class PrintStatement : Statement
    {
        private Expression expression;

        public PrintStatement(Expression expression)
        {
            this.expression = expression;
        }

        public void execute()
        {
            Console.WriteLine(expression.eval().asString());
        }
    }
}
