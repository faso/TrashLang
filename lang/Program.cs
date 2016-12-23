using lang.Lexing;
using Lang.REPL;
using System;
using System.Diagnostics;
using System.IO;

namespace lang
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TrashLang v0.000000420");
            REPL.Start();

            Console.ReadKey(); 
        }
    }
}
