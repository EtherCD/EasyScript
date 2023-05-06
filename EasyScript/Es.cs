using EasyScript.ast.statements;
using EasyScript.lexer;
using EasyScript.lib;
using EasyScript.parser;
using System;
using System.Collections.Generic;

namespace EasyScript
{
    public class ES
    {

        public static void Eval(String code)
        {

            List<Token> tokens = new Lexer(code).Tokenize();
            BlockStatement three = new Parser(tokens).parse();
            try
            {
                three.execute();
            }
            catch (RuntimeError e)
            {
                ErrorsMessages.RuntimeError(e);
            }
        }

        /*static void Main(string[] args)
        {
            Console.WriteLine("Welcome to EasyScript Interpreter");
            while (true)
            {
                var text = Console.ReadLine();
                Eval(text);
            }
        }*/
    }
}
