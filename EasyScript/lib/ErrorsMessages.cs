using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.lib
{
    internal static class ErrorsMessages
    {
        public static void ParseError(ParseError e)
        {
            String buffer = "";
            buffer += $"On line: {e.Token.Column}\n";
            buffer += e.Token.LineText + '\n';
            for (int i = 0; i < e.Token.startPos; i++)
            {
                buffer += " ";
            }
            for (int i = 0; i < Math.Abs(e.Token.endPos - e.Token.startPos); i++)
            {
                buffer += "^";
            }
            buffer += $"\nParseExpesion: {e.Message}";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(buffer);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void LexeError(LexeError e)
        {
            String buffer = "";
            buffer += e.Line + '\n';
            for (int i = 0; i < e.Position - 1; i++)
            {
                buffer += " ";
            }
            buffer += "^";
            buffer += $"\nLexeException: {e.Message}";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(buffer);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void RuntimeError(RuntimeError e)
        {
            String buffer = "";
            buffer += $"On line: {e.Token.Column}\n";
            if (e.Token == null)
            {
                return;
            }
            else
            {
                buffer += e.Token.LineText.Replace("\n", "") + '\n';
                for (int i = 0; i < e.Token.startPos; i++)
                {
                    buffer += " ";
                }
                for (int i = 0; i < Math.Abs(e.Token.endPos - e.Token.startPos); i++)
                {
                    buffer += "^";
                }
                buffer += $"\nRuntimeException: {e.Message}";

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(buffer);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
