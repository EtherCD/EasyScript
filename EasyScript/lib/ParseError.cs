using EasyScript.lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
