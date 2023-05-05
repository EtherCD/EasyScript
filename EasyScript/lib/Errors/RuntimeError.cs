using EasyScript.lexer;
using System;

namespace EasyScript.lib
{
    internal class RuntimeError : Exception
    {
        public Token Token { get; }

        public RuntimeError(String message, Token token) : base(message)
        {
            Token = token;
        }
    }
}
