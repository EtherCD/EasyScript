using EasyScript.ast.values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.lib
{
    internal class VarHandler
    {
        private Value value;
        private bool overwrite;

        public VarHandler(Value val, bool overw) 
        {
            this.value = val;
            this.overwrite = overw;
        }

        public Value getValue()
        {
            return this.value;
        }

        public void setValue(Value val)
        {
            this.value = val;
        }

        public bool getOverwrite()
        {
            return overwrite;
        }
    }
}
