using EasyScript.lexer;
using EasyScript.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyScript.ast.expressions;
using EasyScript.ast.statements;
using static System.Net.Mime.MediaTypeNames;
using EasyScript.lib;

namespace EasyScript
{
    internal class Program
    {

        public static void Eval(String code)
        {

            List<Token> tokens = new Lexer(code).Tokenize();
            BlockStatement three = new Parser(tokens).parse();
            try
            {
                three.execute();
            } catch (RuntimeError e)
            {
                ErrorsMessages.RuntimeError(e);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to EasyScript Interpreter");
            while (true)
            {
                var text = Console.ReadLine();
                Eval(text);
            }
        }
    }
}
