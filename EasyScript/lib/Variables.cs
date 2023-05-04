using EasyScript.ast.values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.lib
{
    static class Variables
    {
        private static Dictionary<String, VarHandler> variables = new Dictionary<String, VarHandler>();

        public static void Set(Dictionary<String, VarHandler> vars)
        {
            variables = vars;
        }

        public static Dictionary<String, VarHandler> Get()
        {
            return variables;
        }

        public static void Clear()
        {
            variables.Clear();
        }

        public static bool isExists(String key)
        {
            return variables.ContainsKey(key);
        }

        public static Value get(String key)
        {
            if (!isExists(key))
            {
                return new NumberValue(0);
            }
            return variables[key].getValue();
        }

        public static bool set(String key, Value value, bool overwrite)
        {
            if (isExists(key))
            {
                return false;
            }
            variables[key] = new VarHandler(value, overwrite);
            return true;
        }

        public static int change(String key, Value value)
        {
            if (!isExists(key))
            {
                return 1;
            } else if (!variables[key].getOverwrite())
            {
                return 2;
            }
            variables[key].setValue(value);
            return 0;
        }

        public static int Attempt(String key)
        {
            if (!isExists(key))
            {
                return 1;
            }
            else if (!variables[key].getOverwrite())
            {
                return 2;
            }
            return 0;
        }
    }
}
