using EasyScript.ast.expressions;
using EasyScript.lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.statements
{
    internal class LoadScriptStatement : Statement
    {
        private String link;

        public LoadScriptStatement(Expression link)
        {
            this.link = link.eval().asString();
        }

        public void execute()
        {
            Dictionary < String, VarHandler > a = Variables.Get();
            Variables.Clear();
            string code = File.ReadAllText(link);
            Program.Eval(code);
            Variables.Clear();
            Variables.Set(a);
        }
    }
}
