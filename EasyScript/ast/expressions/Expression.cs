using EasyScript.ast.values;

namespace EasyScript.ast.expressions
{
    internal interface Expression
    {
        Value eval();
    }
}
