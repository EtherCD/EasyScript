using EasyScript.ast.expressions;
using EasyScript.ast.values;
using EasyScript.lexer;
using EasyScript.lib;
using System;

namespace EasyScript.ast.statements
{
    internal class ArrayAssignmentStatement : Statement
    {
        private String variable;
        private Expression index;
        private Expression exrp;
        private Token myToken;

        public ArrayAssignmentStatement(string variable, Expression index, Expression exrp, Token token)
        {
            this.variable = variable;
            this.index = index;
            this.exrp = exrp;
            this.myToken= token;
        }

        public void execute()
        {
            Value var = Variables.get(variable);
            try
            {
                if (var.GetType() == typeof(ArrayValue))
                {
                    ArrayValue val = (ArrayValue)var;
                    val.set((int)index.eval().asDouble(), exrp.eval());
                }
                else
                {
                    throw new RuntimeError("Array expected", myToken);
                }
            } catch (Exception e)
            {
                throw new RuntimeError(e.Message, myToken);
            }
            
        }
    }
}
