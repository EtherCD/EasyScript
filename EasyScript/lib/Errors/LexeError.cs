using System;

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
