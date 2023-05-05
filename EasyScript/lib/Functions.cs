using EasyScript.ast.values;
using EasyScript.lib.libs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.lib
{
    static class Functions
    {
        private static Dictionary<String, Function> functions = new Dictionary<String, Function>();
        private static Dictionary<String, Function> stack = new Dictionary<String, Function>();

        static Functions()
        {
            MathLib.Init();
            SysLib.Init();
        }

        public static void Push()
        {
            functions = stack;
            functions.Clear();
        }

        public static void Stack()
        {
            stack = functions;
            functions.Clear();
            MathLib.Init();
            SysLib.Init();
        }


        public static void addFunction(String name, Function func)
        {
            functions.Add(name, func);
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

        public static Dictionary<String, Function> Get()
        {
            return functions;
        }

        public static void Set(Dictionary<String, Function> funcs)
        {
            functions = funcs;
        }
        public static void Clear()
        {
            functions.Clear();
        }
    }
}
