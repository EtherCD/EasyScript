using EasyScript.ast.expressions;
using EasyScript.lib.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.statements
{
    internal class DoWhileStatement : Statement
    {
        private Expression condition;
        private Statement statement;

        public DoWhileStatement(Expression condition, Statement statement)
        {
            this.condition = condition;
            this.statement = statement;
        }

        public void execute()
        {
            do
            {
                try
                {
                    statement.execute();
                }
                catch (BreakError e)
                {
                    break;
                }
                catch (NextError)
                {
                    continue;
                }
                catch (Exception e)
                {
                    throw e;
                }
            } while (condition.eval().asBoolean());
        }
    }
}
