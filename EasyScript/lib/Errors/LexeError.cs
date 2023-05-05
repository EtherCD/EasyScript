using EasyScript.lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.lib
{
    internal class LexeError : Exception
    {
        public int Position { get; }
        public string Line { get; }

        public LexeError(String message, int pos, string line) : base(message)
        {
            Position = pos;
            Line = line;
        }
    }
}
