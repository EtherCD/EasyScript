using EasyScript.ast.expressions;
using EasyScript.ast.statements;
using EasyScript.lexer;
using EasyScript.lib;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        private void ErrorHandler(ParseError e)
        {
            String buffer = "!| Error |!\n";
            buffer += $"On line: {e.Token.Column}\n";
            buffer += e.Token.LineText + '\n';
            for (int i = 0; i < e.Token.startPos; i++)
            {
                buffer += " ";
            }
            for (int i = 0; i < Math.Abs(e.Token.endPos - e.Token.startPos); i++)
            {
                buffer += "^";
            }
            buffer += $"\nException: {e.Message}";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(buffer);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public BlockStatement parse()
        {
            try
            {
                BlockStatement result = new BlockStatement();

                while (!match(TokenType.EOF))
                {
                    result.AddStatement(statement());
                }
                return result;
            }
            catch (ParseError e) {
                ErrorHandler(e);
                return new BlockStatement();
            }
        }

        private Statement block()
        {
            BlockStatement block = new BlockStatement();
            consume(TokenType.LBRACE);
            while (!match(TokenType.RBRACE))
            {
                block.AddStatement(statement());
            }
            return block;
        }

        private Statement statementOrBlock()
        {
            if (get(0).getType() == TokenType.LBRACE)
            {
                return block();
            }
            return statement();
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
            if (match(TokenType.LOADSCRIPT))
            {
                return new LoadScriptStatement(expression());
            }
            if (match(TokenType.IF))
            {
                return ifElse();
            }
            if (match(TokenType.WHILE))
            {
                return whileStatement();
            }
            return assignmentStatement();
        }

        private Statement whileStatement()
        {
            Expression condition = conditional();
            Statement statmnt = statementOrBlock();
            return new WhileStatement(condition, statmnt);
        }

        private Statement ifElse()
        {
            Expression condition = conditional();
            Statement ifStatement = statementOrBlock();
            Statement elseStatement;
            if (match(TokenType.ELSE))
            {
                elseStatement = statementOrBlock();
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
                try
                {
                    return new AssignementStatement(variable, expression());
                }
                catch (Exception e)
                {
                    throw new ParseError(e.Message, current);
                }
            }
            if (match(TokenType.VAR) && get(0).getType() == TokenType.WORD && get(1).getType() == TokenType.EQ)
            {
                String variable = get(0).getValue();
                consume(TokenType.WORD);
                consume(TokenType.EQ);
                try
                {
                    return new VarStatement(variable, expression());
                }
                catch (Exception e)
                {
                    throw new ParseError(e.Message, current);
                }
            }
            if (match(TokenType.CONST) && get(0).getType() == TokenType.WORD && get(1).getType() == TokenType.EQ)
            {
                String variable = get(0).getValue();
                consume(TokenType.WORD);
                consume(TokenType.EQ);
                try
                {
                    return new ConstStatement(variable, expression());
                }
                catch (Exception e)
                {
                    throw new ParseError(e.Message, current);
                }
            }
            throw new ParseError("Unknown Statement", current);
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
                return new NumberExpression((double)float.Parse(current.getValue(), CultureInfo.InvariantCulture));
            }
            if (match(TokenType.TEXT))
            {
                return new StringExpression(current.getValue());
            }
            if (match(TokenType.WORD))
            {
                try
                {
                    return new ConstantExpression(current.getValue());
                }
                catch (Exception e)
                {
                    throw new ParseError(e.Message, current);
                }
            }
            if (match(TokenType.BOOL))
            {
                return new BooleanExpression(bool.Parse(current.getValue()));
            }
            if (match(TokenType.LPAREN))
            {
                Expression result = expression();
                match(TokenType.RPAREN);
                return result;
            }
            throw new ParseError("Unknown expression", current);
        }

        private Token consume(TokenType type)
        {
            Token current = this.get(0);
            if (current.getType() != type) throw new ParseError("Token " + current.getType() + " doesn't match " + type, current);
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
