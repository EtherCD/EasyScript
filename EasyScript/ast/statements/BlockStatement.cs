using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.statements
{
    internal class BlockStatement : Statement
    {
        private List<Statement> statements;

        public BlockStatement()
        {
            statements = new List<Statement>();
        }

        public void AddStatement(Statement statement)
        {
            statements.Add(statement);
        }

        public void execute()
        {
            foreach (Statement statement in statements)
            {
                statement.execute();
            }
        }
    }
}
