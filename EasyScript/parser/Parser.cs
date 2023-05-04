using EasyScript.ast.expressions;
using EasyScript.ast.statements;
using EasyScript.lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.parser
{
    internal class Parser
    {
        private static Token EOF = new Token(TokenType.EOF, "");

        private List<Token> Tokens;
        private int Size;
        private int Position;

        public Parser(List<Token> Tokens)
        {
            this.Tokens = Tokens;
            this.Position = 0;
            this.Size = Tokens.Count;
        }

        public List<Statement> parse()
        {
            List<Statement> result = new List<Statement>();
            while (!match(TokenType.EOF))
            {
                result.Add(statement());
            }
            return result;
        }

        private Statement statement()
        {
            if (match(TokenType.PRINT))
            {
                return new PrintStatement(expression());
            }
            if (match(TokenType.EVAL))
            {
                return new EvalStatement(expression());
            }
            if (match(TokenType.IF))
            {
                return ifElse();
            }
            return assignmentStatement();
        }

        private Statement ifElse()
        {
            Expression condition = conditional();
            Statement ifStatement = statement();
            Statement elseStatement;
            if (match(TokenType.ELSE))
            {
                elseStatement = statement();
            }
            else
            {
                elseStatement = null;
            }
            return new IfStatement(condition, ifStatement, elseStatement);
        }

        private Statement assignmentStatement()
        {
            Token current = get(0);
            if (match(TokenType.WORD) && get(0).getType() == TokenType.EQ)
            {
                String variable = current.getValue();
                consume(TokenType.EQ);
                return new AssignementStatement(variable, expression());
            }
            if (match(TokenType.VAR) && get(0).getType() == TokenType.WORD && get(1).getType() == TokenType.EQ)
            {
                String variable = get(0).getValue();
                consume(TokenType.WORD);
                consume(TokenType.EQ);
                return new VarStatement(variable, expression());
            }
            if (match(TokenType.CONST) && get(0).getType() == TokenType.WORD && get(1).getType() == TokenType.EQ)
            {
                String variable = get(0).getValue();
                consume(TokenType.WORD);
                consume(TokenType.EQ);
                return new ConstStatement(variable, expression());
            }
            throw new Exception("Unknown Statement");
        }

        private Expression expression()
        {
            return conditional();
        }

        private Expression conditional()
        {
            Expression result = addtive();

            while (true)
            {
                if (match(TokenType.EQEQ))
                {
                    result = new ConditionalExpression("==", result, addtive());
                    continue;
                }
                if (match(TokenType.NOTEQ))
                {
                    result = new ConditionalExpression("!=", result, addtive());
                    continue;
                }
                if (match(TokenType.LT))
                {
                    result = new ConditionalExpression("<", result, addtive());
                    continue;
                }
                if (match(TokenType.GT))
                {
                    result = new ConditionalExpression(">", result, addtive());
                    continue;
                }
                if (match(TokenType.LTEQ))
                {
                    result = new ConditionalExpression("<=", result, addtive());
                    continue;
                }
                if (match(TokenType.GTEQ))
                {
                    result = new ConditionalExpression(">=", result, addtive());
                    continue;
                }
                break;
            }

            return result;
        }

        private Expression addtive()
        {
            Expression result = multiplicative();

            while (true)
            {
                if (match(TokenType.PLUS))
                {
                    result = new BinaryExpression('+', result, multiplicative());
                    continue;
                }
                if (match(TokenType.MINUS))
                {
                    result = new BinaryExpression('-', result, multiplicative());
                    continue;
                }
                break;
            }

            return result;
        }

        private Expression multiplicative()
        {
            Expression result = unary();

            while (true)
            {
                if (match(TokenType.STAR))
                {
                    result = new BinaryExpression('*', result, unary());
                    continue;
                }
                if (match(TokenType.SLASH))
                {
                    result = new BinaryExpression('/', result, unary());
                    continue;
                }
                break;
            }

            return result;
        }

        private Expression unary()
        {
            if (match(TokenType.MINUS))
            {
                return new UnaryExpression('-', primary());
            }
            return primary();
        }

        private Expression primary()
        {
            Token current = get(0);
            if (match(TokenType.NUMBER))
            {
                int val;
                int.TryParse(current.getValue(), out val);
                return new NumberExpression(val);
            }
            if (match(TokenType.TEXT))
            {
                return new StringExpression(current.getValue());
            }
            if (match(TokenType.WORD))
            {
                return new ConstantExpression(current.getValue());
            }
            if (match(TokenType.LPAREN))
            {
                Expression result = expression();
                match(TokenType.RPAREN);
                return result;
            }
            throw new Exception("Unknown expression");
        }

        private Token consume(TokenType type)
        {
            Token current = this.get(0);
            if (current.getType() != type) throw new Exception("Token " + current.getType() + " doesn't match " + type);
            this.Position++;
            return current;
        }

        private bool match(TokenType type)
        {
            Token current = this.get(0);
            if (current.getType() != type) return false;
            this.Position++;
            return true;
        }

        private Token get(int pos)
        {
            int position = this.Position + pos;
            if (position >= this.Size) return EOF;
            return this.Tokens[position];
        }
    }
}
