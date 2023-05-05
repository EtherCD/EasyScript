using EasyScript.lexer;
using System;

namespace EasyScript.lib
{
    internal class ParseError : Exception
    {
        public Token Token { get; }

        public ParseError(String message, Token token) : base(message)
        {
            Token = token;
        }
    }
}
