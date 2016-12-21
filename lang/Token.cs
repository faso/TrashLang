using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lang.TokenTypes
{
    public static class Tokens
    {
        // Special
        public static TokenType ILLEGAL = new TokenType("ILLEGAL");
        public static TokenType EOF = new TokenType("EOF");

        // Identifiers and literals
        public static TokenType IDENT = new TokenType("IDENT");
        public static TokenType INT = new TokenType("INT");

        // Operators
        public static TokenType ASSIGN = new TokenType("=");
        public static TokenType PLUS = new TokenType("+");

        // Delimiters
        public static TokenType COMMA = new TokenType(",");
        public static TokenType SEMICOLON = new TokenType(";");

        public static TokenType LPAREN = new TokenType("(");
        public static TokenType RPAREN = new TokenType(")");
        public static TokenType LBRACE = new TokenType("{");
        public static TokenType RBRACE = new TokenType("}");

        // Keywords
        public static TokenType FUNCTION = new TokenType("FUNCTION");
        public static TokenType VAR = new TokenType("VAR");
    }

    public class TokenType
    {
        public string Value { get; set; }

        public TokenType(string value)
        {
            this.Value = value;
        }
    }

    public class Token
    {
        public TokenType Type { get; set; }
        public string Literal { get; set; }
    }
}
