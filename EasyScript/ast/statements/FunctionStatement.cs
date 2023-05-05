using EasyScript.ast.expressions;

namespace EasyScript.ast.statements
{
    internal class FunctionStatement : Statement
    {
        private FunctionalExpression function;

        public FunctionStatement(FunctionalExpression function)
        {
            this.function = function;
        }

        public void execute()
        {
            function.eval();
        }
    }
}
