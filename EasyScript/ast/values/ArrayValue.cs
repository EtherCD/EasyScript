using System;

namespace EasyScript.ast.values
{
    internal class ArrayValue : Value
    {
        private Value[] elements;

        public ArrayValue(int size)
        {
            this.elements = new Value[size];
        }

        public ArrayValue(Value[] elements)
        {
            this.elements = new Value[elements.Length];
            Array.Copy(elements, 0, this.elements, 0, elements.Length);
        }

        public ArrayValue(ArrayValue array)
        {
            this.elements = array.elements;
        }

        public Value get(int index)
        {
            return elements[index];
        }

        public void set(int index, Value value)
        {
            elements[index] = value;
        }

        public bool asBoolean()
        {
            throw new Exception("Cannot cast array to number.");
        }

        public double asDouble()
        {
            throw new Exception("Cannot cast array to boolean.");
        }

        public string asString()
        {
            String buffer = "[";
            int index = 0;
            int len = elements.Length;
            foreach (Value val in elements)
            {
                if (index != 0 && index != len)
                {
                    buffer += ", ";
                }
                buffer += val.asString();
                index++;
            }
            buffer += "]";

            return buffer;
        }
    }
}
