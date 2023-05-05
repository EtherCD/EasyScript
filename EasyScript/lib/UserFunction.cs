using EasyScript.ast.statements;
using EasyScript.ast.values;
using System;
using System.Collections.Generic;

namespace EasyScript.lib
{
    internal class UserFunction : Function
    {
        private List<string> argnames;
        private Statement body;

        public UserFunction(List<string> argnames, Statement body)
        {
            this.argnames = argnames;
            this.body = body;
        }

        public int getArgsCount()
        {
            return argnames.Count;
        }

        public String getArgsName(int index)
        {
            if (index < 0 || index >= getArgsCount()) return "";
            return argnames[index];
        }

        public Value execute(params Value[] args)
        {
            Variables.Stack();
            body.execute();
            Variables.Push();
            return new NumberValue(0);
        }
    }
}
