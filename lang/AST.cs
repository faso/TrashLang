using lang.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lang.AST
{
    public interface INode
    {
        string TokenLiteral();
    }

    public interface IStatement : INode
    {
        void StatementNode();
    }

    public interface IExpression : INode
    {
        void ExpressionNode();
    }

    public class VarStatement : IStatement
    {
        public Token Token { get; set; }
        public Identifier Name { get; set; }
        public IExpression Value { get; set; }

        public void StatementNode() { }
        public string TokenLiteral()
            => this.Token.Literal;
    }

    public class Identifier : IExpression
    {
        public Token Token { get; set; }
        public string Value { get; set; }

        public void ExpressionNode() {}

        public string TokenLiteral()
        {
            return this.Token.Literal;
        }

    }
}
