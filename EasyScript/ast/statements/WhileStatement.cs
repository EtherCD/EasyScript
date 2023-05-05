using EasyScript.ast.expressions;
using EasyScript.lib.Errors;
using System;

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
            }
        }
    }
}
