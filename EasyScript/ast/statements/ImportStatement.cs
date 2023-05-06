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
    internal class ImportStatement : Statement
    {
        Token tk;

        public ImportStatement(Token tk)
        {
            this.tk = tk;
        }

        public void execute()
        {
            try
            {
                string code = File.ReadAllText(tk.getValue());
                ES.Eval(code);
            }
            catch
            {
                throw new Exception("Wrong file location");
            }
        }
    }
}
