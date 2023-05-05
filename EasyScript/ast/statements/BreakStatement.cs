using EasyScript.lib.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.statements
{
    internal class BreakStatement : Statement
    {
        public BreakStatement()
        {

        }

        public void execute()
        {
            throw new BreakError();
        }
    }
}
