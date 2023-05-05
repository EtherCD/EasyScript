using EasyScript.ast.values;
using EasyScript.lib.libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.lib
{
    static class Functions
    {
        private static Dictionary<String, Function> functions = new Dictionary<String, Function>();

        static Functions()
        {
            functions.Add("cos", new MathCos());
            functions.Add("sin", new MathSin());
            functions.Add("random", new MathRandom());
            functions.Add("abs", new MathAbs());
        }

        public static bool isExists(String key)
        {
            return functions.ContainsKey(key);
        }

        public static Function get(String key)
        {
            if (!isExists(key))
            {
                throw new Exception("Unknown function "+key);
            }
            return functions[key];
        }

        public static bool set(String key, Function func)
        {
            if (isExists(key))
            {
                return false;
            }
            functions[key] = func;
            return true;
        }
    }
}
