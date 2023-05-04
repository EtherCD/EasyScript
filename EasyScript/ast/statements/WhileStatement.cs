using EasyScript.ast.expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.statements
{
    internal class WhileStatement : Statement
    {
        private Expression condition;
        private Statement statement;

        public WhileStatement(Expression condition, Statement statement)
        {
            this.condition = condition;
            this.statement = statement;
        }

        public void execute()
        {
            while (condition.eval().asBoolean())
            {
                statement.execute();
            }
        }
    }
}
