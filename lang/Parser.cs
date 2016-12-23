using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lang.AST;
using lang.Lexing;

namespace Lang.Parsing
{
    public class Program : INode
    {
        public List<IStatement> Statements { get; set; }

        public string TokenLiteral()
        {
            if (this.Statements.Count > 0)
                return this.Statements[0].TokenLiteral();
            else
                return String.Empty;
        }
    }

    public class Parser
    {
        private Lexer Lexer;

        private Token CurToken;
        private Token PeekToken;

        public List<string> Errors;

        public Parser(Lexer lexer)
        {
            this.Lexer = lexer;
            this.Errors = new List<string>();
            PeekToken = Lexer.NextToken();
            NextToken();
            NextToken();
        }

        private void NextToken()
        {
            CurToken = PeekToken;
            PeekToken = Lexer.NextToken();
        }

        public Program ParseProgram()
        {
            var program = new Program();
            program.Statements = new List<IStatement>();

            while (CurToken.Type != TokenType.EOF)
            {
                var stmt = ParseStatement();
                if (stmt != null)
                {
                    program.Statements.Add(stmt);
                }
                NextToken();
            }

            return program;
        }

        public IStatement ParseStatement()
        {
            switch(CurToken.Type)
            {
                case TokenType.VAR:
                    return ParseVarStatement();
                default:
                    return null;
            }
        }

        public VarStatement ParseVarStatement()
        {
            var stmt = new VarStatement();
            stmt.Token = CurToken;

            if (!ExpectPeek(TokenType.IDENT))
                return null;

            stmt.Name = new Identifier()
            {
                Token = CurToken,
                Value = CurToken.Literal
            };

            while (!CurTokenIs(TokenType.SEMICOLON))
                NextToken();

            return stmt;
        }

        private bool CurTokenIs(TokenType t)
            => (CurToken.Type == t);

        private bool PeekTokenIs(TokenType t)
            => (PeekToken.Type == t);

        private bool ExpectPeek(TokenType t)
        {
            if (PeekTokenIs(t))
            {
                NextToken();
                return true;
            }
            else
            {
                PeekError(t);
                return false;
            }
        }

        private void PeekError(TokenType t)
        {
            var msg = $"Expected token {Enum.GetName(typeof(TokenType), t)}, got {Enum.GetName(typeof(TokenType), PeekToken.Type)} instead";
            Errors.Add(msg);
        }
    }
}
