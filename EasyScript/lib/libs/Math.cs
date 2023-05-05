using EasyScript.ast.values;
using System;

namespace EasyScript.lib.libs
{
    public class MathLib
    {
        public static void Init()
        {
            Functions.addFunction("cos", new MathCos());
            Functions.addFunction("sin", new MathSin());
            Functions.addFunction("random", new MathRandom());
            Functions.addFunction("abs", new MathAbs());
            Functions.addFunction("atan", new MathAbs());
            Functions.addFunction("atan2", new MathAtan2());
            Functions.addFunction("ceil", new MathCeil());
            Functions.addFunction("floor", new MathFloor());
            Functions.addFunction("min", new MathMin());
            Functions.addFunction("max", new MathMax());
            Functions.addFunction("round", new MathRound());
            Functions.addFunction("log", new MathLog());
            Functions.addFunction("log10", new MathLog10());
            Functions.addFunction("trunc", new MathTrunc());
        }
    }

    class MathCos : Function
    {
        public Value execute(params Value[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception("The cos method has only one argument.");
            }
            return new NumberValue(Math.Cos(args[0].asDouble()));
        }
    }

    class MathSin : Function
    {
        public Value execute(params Value[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception("The sin method has only one argument.");
            }
            return new NumberValue(Math.Sin(args[0].asDouble()));
        }
    }

    class MathRandom : Function
    {
        public Value execute(params Value[] args)
        {
            Random r = new Random();
            double result = 0;
            if (args.Length == 0)
            {
                result = r.NextDouble();
            }
            if (args.Length == 1)
            {
                result = r.Next(0, (int)args[0].asDouble()) + r.NextDouble();
            }
            if (args.Length == 2)
            {
                result = r.Next(0, (int)args[0].asDouble()) + r.NextDouble();
            }
            if (args.Length > 2)
            {
                throw new Exception("One args expected");
            }
            return new NumberValue(result);
        }
    }

    class MathAbs : Function
    {
        public Value execute(params Value[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception("One args expected");
            }
            return new NumberValue(Math.Abs(args[0].asDouble()));
        }
    }

    class MathAtan : Function
    {
        public Value execute(params Value[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception("The atan method has only one argument.");
            }
            return new NumberValue(Math.Atan(args[0].asDouble()));
        }
    }

    class MathAtan2 : Function
    {
        public Value execute(params Value[] args)
        {
            if (args.Length != 2)
            {
                throw new Exception("The atan2 method has only two argument.");
            }
            return new NumberValue(Math.Atan2(args[0].asDouble(), args[1].asDouble()));
        }
    }

    class MathCeil : Function
    {
        public Value execute(params Value[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception("The ceil method has only one argument.");
            }
            return new NumberValue(Math.Ceiling(args[0].asDouble()));
        }
    }

    class MathFloor : Function
    {
        public Value execute(params Value[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception("The floor method has only one argument.");
            }
            return new NumberValue(Math.Floor(args[0].asDouble()));
        }
    }

    class MathMin : Function
    {
        public Value execute(params Value[] args)
        {
            if (args.Length == 0)
            {
                throw new Exception("The min method must have at least 1 parameter.");
            }
            Double lastMin = args[0].asDouble();
            foreach (Value val in args)
            {
                if (val.asDouble() < lastMin) lastMin = val.asDouble();
            }
            return new NumberValue(lastMin);
        }
    }

    class MathMax : Function
    {
        public Value execute(params Value[] args)
        {
            if (args.Length == 0)
            {
                throw new Exception("The max method must have at least 1 parameter.");
            }
            Double lastMax = args[0].asDouble();
            foreach (Value val in args)
            {
                if (val.asDouble() > lastMax) lastMax = val.asDouble();
            }
            return new NumberValue(lastMax);
        }
    }

    class MathRound : Function
    {
        public Value execute(params Value[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception("The round method has only one argument.");
            }
            return new NumberValue(Math.Round(args[0].asDouble()));
        }
    }

    class MathLog : Function
    {
        public Value execute(params Value[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception("The log method has only one argument.");
            }
            return new NumberValue(Math.Log(args[0].asDouble()));
        }
    }

    class MathLog10 : Function
    {
        public Value execute(params Value[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception("The log10 method has only one argument.");
            }
            return new NumberValue(Math.Log10(args[0].asDouble()));
        }
    }

    class MathTrunc : Function
    {
        public Value execute(params Value[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception("The trunc method has only one argument.");
            }
            return new NumberValue(Math.Truncate(args[0].asDouble()));
        }
    }
}
