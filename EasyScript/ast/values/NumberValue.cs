namespace EasyScript.ast.values
{
    internal class NumberValue : Value
    {
        private double value;

        public NumberValue(double value)
        {
            this.value = value;
        }

        public bool asBoolean()
        {
            return value == 1;
        }

        public double asDouble()
        {
            return value;
        }

        public string asString()
        {
            return "" + value;
        }
    }
}
