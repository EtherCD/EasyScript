using EasyScript.ast.expressions;
using EasyScript.lexer;
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
        private Token myToken;

        public LoadScriptStatement(Expression link, Token myToken)
        {
            this.link = link.eval().asString();
            this.myToken = myToken;
        }

        public void execute()
        {
            try
            {
                Dictionary<String, VarHandler> a = Variables.Get();
                Variables.Clear();
                string code = File.ReadAllText(link);
                Program.Eval(code);
                Variables.Clear();
                Variables.Set(a);
            } catch
            {
                throw new RuntimeError("Wrong file location", myToken);
            }
        }
    }
}
