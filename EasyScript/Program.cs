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

namespace EasyScript
{
    internal class Program
    {
        public static void Eval(String code)
        {
            List<Token> tokens = new Lexer(code).Tokenize();
            List<Statement> three = new Parser(tokens).parse();
            three.ForEach(item => item.execute());
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
