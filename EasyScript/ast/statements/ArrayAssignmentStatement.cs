using EasyScript.ast.expressions;
using EasyScript.ast.values;
using EasyScript.lexer;
using EasyScript.lib;
using System;

namespace EasyScript.ast.statements
{
    internal class ArrayAssignmentStatement : Statement
    {
        private ArrayAccessExpression array;
        private Expression expr;
        private Token myToken;

        public ArrayAssignmentStatement(Token token, ArrayAccessExpression array, Expression expr)
        {
            this.array = array;
            this.myToken= token;
            this.expr = expr;
        }

        public void execute()
        {
            try
            {
                array.getArray().set(array.getIndex(), expr.eval());
            } catch (Exception e)
            {
                throw new RuntimeError(e.Message, myToken);
            }
            
        }
    }
}
