using EasyScript.ast.values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.lib.libs
{
    class MathCos : Function
    {
        public Value execute(params Value[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception("One args expected");
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
                throw new Exception("One args expected");
            }
            return new NumberValue(Math.Sin(args[0].asDouble()));
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
                result = r.Next(0, (int)args[0].asDouble()) +  r.NextDouble();
            }
            if (args.Length > 2)
            {
                throw new Exception("One args expected");
            }
            return new NumberValue(result);
        }
    }
}
