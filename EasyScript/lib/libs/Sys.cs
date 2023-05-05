using EasyScript.ast.values;
using EasyScript.lexer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.lib.libs
{
    public static class SysLib
    {
        public static void Init()
        {
            Functions.addFunction("print", new SysPrint());
            Functions.addFunction("println", new SysPrintln());
            Functions.addFunction("eval", new SysEval());
            Functions.addFunction("LoadScript", new SysLoadScript());
        }
    }

    class SysPrint : Function
    {
        public Value execute(params Value[] args)
        {
            foreach (Value val in args)
            {
                Console.Write(val.asString());
            }
            return new BooleanValue(false);
        }
    }

    class SysPrintln : Function
    {
        public Value execute(params Value[] args)
        {
            foreach (Value val in args)
            {
                Console.WriteLine(val.asString());
            }
            return new BooleanValue(false);
        }
    }

    class SysEval : Function
    {
        public Value execute(params Value[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception("The eval method has only one argument.");
            }
            Program.Eval(args[0].asString());
            return new BooleanValue(false);
        }
    }

    class SysLoadScript : Function
    {
        public Value execute(params Value[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception("The LoadScript method has only one argument.");
            }
            try
            {
                Variables.Stack();
                Functions.Stack();
                string code = File.ReadAllText(args[0].asString());
                Program.Eval(code);
                Variables.Push();
                Functions.Push();
            }
            catch
            {
                throw new Exception("Wrong file location");
            }
            return new BooleanValue(false);
        }
    }
}
