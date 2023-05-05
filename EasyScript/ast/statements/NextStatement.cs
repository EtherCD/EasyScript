using EasyScript.lib.Errors;

namespace EasyScript.ast.statements
{
    internal class NextStatement : Statement
    {
        public NextStatement() { }

        public void execute()
        {
            throw new NextError();
        }
    }
}
