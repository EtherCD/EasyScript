using EasyScript;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EasyScriptPackage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Welcome to EasyScript Interpreter");
                while (true)
                {
                    var text = Console.ReadLine();
                    ES.Eval(text);
                }
            } else
            {
                string code = File.ReadAllText(args[0]);
                ES.Eval(code);
            }
        }
    }
}
