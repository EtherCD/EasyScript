using EasyScript.ast.expressions;
using EasyScript.lib.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.statements
{
    internal class ForStatement : Statement
    {
        private Statement Init;
        private Expression Termination;
        private Statement Increment;
        private Statement Block;

        public ForStatement(Statement init, Expression termination, Statement increment, Statement block)
        {
            Init = init;
            Termination = termination;
            Increment = increment;
            Block = block;
        }

        public void execute()
        {
            for (Init.execute(); Termination.eval().asBoolean(); Increment.execute())
            {
                try
                {
                    Block.execute();
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
