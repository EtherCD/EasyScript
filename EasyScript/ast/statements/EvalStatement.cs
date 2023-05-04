using EasyScript.ast.expressions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.statements
{
    internal class EvalStatement : Statement
    {
        private String value;

        public EvalStatement(Expression value)
        {
            this.value = value.eval().asString();
        }

        public void execute()
        {
            Program.Eval(value);
        }
    }
}
