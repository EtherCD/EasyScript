﻿using EasyScript.ast.expressions;
using EasyScript.ast.values;
using EasyScript.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.statements
{
    internal class ConstStatement : Statement
    {
        private String var;
        private Expression expression;

        public ConstStatement(string var, Expression expression)
        {
            this.var = var;
            this.expression = expression;
        }

        public void execute()
        {
            Value result = expression.eval();
            if (!Variables.set(var, result, false))
            {
                throw new Exception("Attempt to create an existing variable");
            }
        }
    }
}