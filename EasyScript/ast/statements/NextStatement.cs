using EasyScript.lib.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.statements
{
    internal class NextStatement : Statement
    {
        public NextStatement() { }

        public void execute()
        {
            throw new NextError();
        }
    }
}
