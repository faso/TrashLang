using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lang.TokenTypes;

namespace lang.Lexing
{
    public class Lexer
    {
        public string input;
        public int position;
        public int readPosition;
        public char ch;

        private void readChar()
        {
            if (readPosition >= input.Length)
                ch = (char)0;
            else
                ch = input[readPosition];

            position = readPosition;
            readPosition++; 
        }

        public List<Token> Lex()
        {
            return new List<Token>();
        }
    }
}
