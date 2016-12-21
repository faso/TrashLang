using lang.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lang
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "+=(){},;";

            var lexer = new Lexer()
            {
                input = s,
                position = 0,
                readPosition = 0
            };

            var tokens = lexer.Lex();

            Console.ReadKey();
        }
    }
}
