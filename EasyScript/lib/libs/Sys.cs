using EasyScript.ast.values;
using System;
using System.IO;

namespace EasyScript.lib.libs
{
    public static class SysLib
    {
        public static void Init()
        {
            Functions.addFunction("print", new SysPrint());
            Functions.addFunction("eval", new SysEval());
            Functions.addFunction("LoadScript", new SysLoadScript());
            Functions.addFunction("array", new SysArrayConstructor());
        }
    }

    class SysArrayConstructor : Function
    {
        public Value execute(params Value[] args)
        {
            return new ArrayValue(args);
        }
    }

    class SysPrint : Function
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
            ES.Eval(args[0].asString());
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
                Variables.Clear();
                Functions.Stack();
                string code = File.ReadAllText(args[0].asString());
                ES.Eval(code);
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
