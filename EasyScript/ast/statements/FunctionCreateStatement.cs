using EasyScript.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.statements
{
    internal class FunctionCreateStatement : Statement
    {
        private String name;
        private List<String> arguments;
        private Statement body;

        public FunctionCreateStatement(string name, List<string> arguments, Statement body)
        {
            this.name = name;
            this.arguments = arguments;
            this.body = body;
        }

        public void execute()
        {
            Functions.set(name, new UserFunction(arguments, body));
        }
    }
}
