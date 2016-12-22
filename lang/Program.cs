using lang.Lexing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lang
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            using (StreamReader sr = new StreamReader("../../tests/test1.txt"))
                input = sr.ReadToEnd();

            var lexer = new Lexer()
            {
                input = input,
                position = 0,
                readPosition = 0
            };

            var watch = new Stopwatch();
            watch.Start();
            var tokens = lexer.Lex();
            watch.Stop();
            Console.WriteLine($"Lexing successful!\nTime elapsed: {watch.Elapsed.TotalSeconds}\n");
            

            foreach (var tok in tokens)
            {
                Console.WriteLine($"{Enum.GetName(typeof(TokenType), tok.Type).PadRight(12)}{tok.Literal}");
            }

            Console.ReadKey();
        }
    }
}
