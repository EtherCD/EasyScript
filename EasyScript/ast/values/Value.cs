using System;

namespace EasyScript.ast.values
{
    interface Value
    {
        double asDouble();
        String asString();

        bool asBoolean();
    }
}
