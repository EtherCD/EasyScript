using EasyScript.lib.Errors;

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
