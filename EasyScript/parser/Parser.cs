using EasyScript.ast.expressions;
using EasyScript.ast.statements;
using EasyScript.lexer;
using EasyScript.lib;
using System.Collections.Generic;
using System.Globalization;

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
            catch (ParseError e)
            {
                ErrorsMessages.ParseError(e);
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
            if (match(TokenType.IF))
            {
                return ifElse();
            }
            if (match(TokenType.DO))
            {
                return doWhileStatement();
            }
            if (match(TokenType.WHILE))
            {
                return whileStatement();
            }
            if (match(TokenType.FOR))
            {
                return forStatement();
            }
            if (match(TokenType.BREAK))
            {
                return new BreakStatement();
            }
            if (match(TokenType.NEXT))
            {
                return new NextStatement();
            }
            if (match(TokenType.FUNC))
            {
                return functionCreate();
            }
            if (match(TokenType.IMPORT))
            {
                return importStatement();
            }
            if (get(0).getType() == TokenType.WORD && get(1).getType() == TokenType.LPAREN)
            {
                return new FunctionStatement(functionExpression());
            }
            return assignmentStatement();
        }

        private Statement importStatement()
        {
            Token tk = consume(TokenType.TEXT);
            return new ImportStatement(tk);
        }

        private Statement doWhileStatement()
        {
            Statement statmnt = statementOrBlock();
            consume(TokenType.WHILE);
            Expression condition = conditional();
            return new DoWhileStatement(condition, statmnt);
        }

        private Statement forStatement()
        {
            match(TokenType.LPAREN);
            Statement init = assignmentStatement();
            consume(TokenType.COMMA);
            Expression termination = expression();
            consume(TokenType.COMMA);
            Statement increment = assignmentStatement();
            match(TokenType.RPAREN);
            Statement block = statementOrBlock();
            return new ForStatement(init, termination, increment, block);
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

        private FunctionCreateStatement functionCreate()
        {
            Token name = consume(TokenType.WORD);
            consume(TokenType.LPAREN);
            List<string> argNames = new List<string>();
            while (!match(TokenType.RPAREN))
            {
                argNames.Add(consume(TokenType.WORD).getValue());
                match(TokenType.COMMA);
            }
            Statement body = statementOrBlock();
            return new FunctionCreateStatement(name.getValue(), argNames, body);
        }

        private FunctionalExpression functionExpression()
        {
            Token name = consume(TokenType.WORD);
            consume(TokenType.LPAREN);
            FunctionalExpression function = new FunctionalExpression(name.getValue(), name);
            while (!match(TokenType.RPAREN))
            {
                function.addArgument(expression());
                match(TokenType.COMMA);
            }
            return function;
        }

        private ArrayAccessExpression element()
        {
            Token variable = consume(TokenType.WORD);
            List<Expression> indices = new List<Expression>();
            while (get(0).getType() == TokenType.LBRACKET)
            {
                consume(TokenType.LBRACKET);
                indices.Add(expression());
                consume(TokenType.RBRACKET);
            }
                
            return new ArrayAccessExpression(variable, indices);
        }

        private Expression array()
        {
            List<Expression> elements = new List<Expression>();
            consume(TokenType.LBRACKET);
            while (!match(TokenType.RBRACKET))
            {
                elements.Add(expression());
                match(TokenType.COMMA);
            }
            return new ArrayExpression(elements);
        }

        private Statement assignmentStatement()
        {
            if (get(0).getType() == TokenType.WORD && get(1).getType() == TokenType.EQ)
            {
                Token variable = consume(TokenType.WORD);
                consume(TokenType.EQ);
                return new AssignementStatement(variable.getValue(), expression(), variable);
            }
            if (match(TokenType.VAR) && get(0).getType() == TokenType.WORD && get(1).getType() == TokenType.EQ)
            {
                Token variable = get(0);
                consume(TokenType.WORD);
                consume(TokenType.EQ);
                return new VarStatement(variable.getValue(), expression(), variable);
            }
            if (match(TokenType.CONST) && get(0).getType() == TokenType.WORD && get(1).getType() == TokenType.EQ)
            {
                Token variable = get(0);
                consume(TokenType.WORD);
                consume(TokenType.EQ);
                return new ConstStatement(variable.getValue(), expression(), variable);
            }
            if (get(0).getType() == TokenType.WORD && get(1).getType() == TokenType.LBRACKET)
            {
                Token variable = get(0);
                ArrayAccessExpression array = element();
                consume(TokenType.EQ);
                return new ArrayAssignmentStatement(variable, array, expression());
            }
            throw new ParseError("Unknown Statement", get(0));
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
            Token current = get(0);

            while (true)
            {
                if (match(TokenType.PLUS))
                {
                    result = new BinaryExpression('+', result, multiplicative(), current);
                    continue;
                }
                if (match(TokenType.MINUS))
                {
                    result = new BinaryExpression('-', result, multiplicative(), current);
                    continue;
                }
                break;
            }

            return result;
        }

        private Expression multiplicative()
        {
            Expression result = unary();
            Token current = get(0);

            while (true)
            {
                if (match(TokenType.STAR))
                {
                    result = new BinaryExpression('*', result, unary(), current);
                    continue;
                }
                if (match(TokenType.SLASH))
                {
                    result = new BinaryExpression('/', result, unary(), current);
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
            if (get(0).getType() == TokenType.WORD && get(1).getType() == TokenType.LPAREN)
            {
                return functionExpression();
            }
            if (get(0).getType() == TokenType.WORD && get(1).getType() == TokenType.LBRACKET)
            {
                return element();
            }
            if (get(0).getType() == TokenType.LBRACKET)
            {
                return array();
            }
            if (match(TokenType.WORD))
            {
                return new ConstantExpression(current.getValue(), current);
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
