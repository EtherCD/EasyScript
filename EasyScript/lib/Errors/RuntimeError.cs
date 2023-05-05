using EasyScript.lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
