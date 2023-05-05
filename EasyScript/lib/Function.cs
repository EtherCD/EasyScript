using EasyScript.ast.values;

namespace EasyScript.lib
{
    internal interface Function
    {
        Value execute(params Value[] args);
    }
}
