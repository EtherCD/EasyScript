using EasyScript.ast.expressions;

namespace EasyScript.ast.statements
{
    internal class IfStatement : Statement
    {
        private Expression expression;
        private Statement ifStat, elseStat;

        public IfStatement(Expression expression, Statement ifStat, Statement elseStat)
        {
            this.expression = expression;
            this.ifStat = ifStat;
            this.elseStat = elseStat;
        }

        public void execute()
        {
            bool result = expression.eval().asBoolean();
            if (result)
            {
                ifStat.execute();
            }
            else if (elseStat != null)
            {
                elseStat.execute();
            }
        }
    }
}
