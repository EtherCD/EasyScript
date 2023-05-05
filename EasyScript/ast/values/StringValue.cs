using System;

namespace EasyScript.ast.values
{
    internal class StringValue : Value
    {
        private String value;

        public StringValue(String value)
        {
            this.value = value;
        }

        public bool asBoolean()
        {
            return false;
        }

        public double asDouble()
        {
            int var;
            int.TryParse(value, out var);
            return var;
        }

        public string asString()
        {
            return value;
        }
    }
}
