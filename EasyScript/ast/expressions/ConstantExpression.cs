using EasyScript.ast.values;
using EasyScript.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.ast.expressions
{
    internal class ConstantExpression : Expression
    {
        private String name;

        public ConstantExpression(string name)
        {
            this.name = name;
            if (!Variables.isExists(name)) throw new Exception("Constant does not exists");
        }

        public Value eval()
        {
            return Variables.get(name);
        }
    }
}
