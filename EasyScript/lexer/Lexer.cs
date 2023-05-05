using EasyScript.lib;
using System;
using System.Collections.Generic;

namespace EasyScript.lexer
{
    internal class Lexer
    {
        private string Input;
        private int Length;
        private List<Token> Tokens = new List<Token>();
        private int Position;
        private int LinePosition;
        private int Column = 1;

        private Dictionary<String, TokenType> TokenKeys = new Dictionary<String, TokenType>();

        public Lexer(string Input)
        {
            this.Input = Input;
            this.Length = Input.Length;
            this.Position = 0;

            this.TokenKeys.Add("+", TokenType.PLUS);
            this.TokenKeys.Add("-", TokenType.MINUS);
            this.TokenKeys.Add("*", TokenType.STAR);
            this.TokenKeys.Add("/", TokenType.SLASH);
            this.TokenKeys.Add("(", TokenType.LPAREN);
            this.TokenKeys.Add(")", TokenType.RPAREN);
            this.TokenKeys.Add("{", TokenType.LBRACE);
            this.TokenKeys.Add("}", TokenType.RBRACE);
            this.TokenKeys.Add("[", TokenType.LBRACKET);
            this.TokenKeys.Add("]", TokenType.RBRACKET);
            this.TokenKeys.Add("=", TokenType.EQ);
            this.TokenKeys.Add("!", TokenType.NOT);
            this.TokenKeys.Add(",", TokenType.COMMA);

            this.TokenKeys.Add("==", TokenType.EQEQ);
            this.TokenKeys.Add("<", TokenType.LT);
            this.TokenKeys.Add(">", TokenType.GT);
            this.TokenKeys.Add("<=", TokenType.LTEQ);
            this.TokenKeys.Add(">=", TokenType.GTEQ);
            this.TokenKeys.Add("!=", TokenType.NOTEQ);

            this.TokenKeys.Add("const", TokenType.CONST);
            this.TokenKeys.Add("var", TokenType.VAR);
            this.TokenKeys.Add("if", TokenType.IF);
            this.TokenKeys.Add("else", TokenType.ELSE);
            this.TokenKeys.Add("while", TokenType.WHILE);
            this.TokenKeys.Add("do", TokenType.DO);
            this.TokenKeys.Add("break", TokenType.BREAK);
            this.TokenKeys.Add("next", TokenType.NEXT);
            this.TokenKeys.Add("for", TokenType.FOR);
            this.TokenKeys.Add("func", TokenType.FUNC);

        }

        public List<Token> Tokenize()
        {
            try
            {
                while (this.Position < this.Length)
                {
                    Char current = this.peek(0);
                    if (current == '\n')
                    {
                        this.LinePosition = this.Position;
                        this.Column++;
                    }
                    if (Char.IsNumber(current)) this.number();
                    else if (Char.IsLetter(current)) this.word();
                    else if ("'\"".IndexOf(current) != -1) this.text();
                    else if (this.TokenKeys.ContainsKey("" + current)) this.operators();
                    else this.next();
                }
            }
            catch (LexeError e)
            {
                ErrorsMessages.LexeError(e);
            }


            foreach (Token t in this.Tokens)
            {
                if (t.getType() == TokenType.WORD && (t.getValue() == "true" || t.getValue() == "false"))
                {
                    t.SetType(TokenType.BOOL);
                }
            }

            return this.Tokens;
        }

        private void number()
        {
            String buffer = "";
            Char current = this.peek(0);
            int startPositon = this.Position;
            while (true)
            {
                if (current == '.')
                {
                    if (buffer.IndexOf(".") != -1) throw new LexeError("Invalid float number.", startPositon, this.Input.Substring(this.LinePosition));
                }
                else if (!Char.IsNumber(current))
                {
                    break;
                }
                buffer += current;
                current = this.next();
            }
            this.addToken(TokenType.NUMBER, buffer, startPositon);
        }

        private void word()
        {
            String buffer = "";
            Char current = this.peek(0);
            int startPositon = this.Position;
            while (true)
            {
                if (!Char.IsLetterOrDigit(current) && current != '_' && current != '$')
                {
                    break;
                }
                buffer += current;
                current = this.next();
            }
            if (this.TokenKeys.ContainsKey(buffer))
            {
                this.addToken(this.TokenKeys[buffer], startPositon);
            }
            else
            {
                this.addToken(TokenType.WORD, buffer, startPositon);
            }
        }

        private void text()
        {
            this.next();
            String buffer = "";
            Char current = this.peek(0);
            Char startOperator = this.peek(-1);
            int startPositon = this.Position;
            while (true)
            {
                if (current == '\\')
                {
                    current = this.next();
                    switch (current)
                    {
                        case '"': current = this.next(); buffer += '\"'; continue;
                        case 'n': current = this.next(); buffer += '\n'; continue;
                        case 't': current = this.next(); buffer += '\t'; continue;
                    }
                    buffer += '\\';
                    continue;
                }
                if (startOperator == current)
                    break;
                if (current == '\0') throw new LexeError("Quote has no end.", startPositon, this.Input.Substring(this.LinePosition));
                buffer += current;
                current = this.next();
            }
            this.next();
            this.addToken(TokenType.TEXT, buffer, startPositon);
        }

        private void comment()
        {
            Char current = this.peek(0);
            while ("\r\n\0".IndexOf(current) == -1)
            {
                current = this.next();
            }
        }

        private void multilineComment()
        {
            Char current = this.peek(0);
            int startPosition = this.Position;
            while (true)
            {
                if (current == '\0') throw new LexeError("No end to multiline comment", startPosition, this.Input.Substring(this.LinePosition));
                if (this.peek(0) == '*' && this.peek(1) == '/') break;
                current = this.next();
            }
            this.next();
            this.next();
        }

        private void operators()
        {
            Char current = this.peek(0);
            if (current == '/')
            {
                if (this.peek(1) == '/')
                {
                    this.next(); this.next();
                    this.comment();
                    return;
                }
                else if (this.peek(1) == '*')
                {
                    this.next(); this.next();
                    this.multilineComment();
                    return;
                }
            }
            int startPositon = this.Position;
            String buffer = "";
            while (true)
            {
                if (!this.TokenKeys.ContainsKey(buffer + current) && buffer != "")
                {
                    this.addToken(this.TokenKeys[buffer], startPositon);
                    return;
                }
                buffer += current;
                current = this.next();
            }
        }

        private Char next()
        {
            this.Position++;
            return this.peek(0);
        }

        private Char peek(int index)
        {
            int position = this.Position + index;
            if (position >= this.Length) return '\0';
            return this.Input[position];
        }

        private void addToken(TokenType Type, int startPosition)
        {
            this.addToken(Type, "", startPosition);
        }

        private void addToken(TokenType Type, String Value, int startPosition)
        {
            Token token = new Token(Type, Value);
            token.LineText = this.Input.Substring(this.LinePosition, Math.Abs(this.Position - this.LinePosition));
            token.startPos = startPosition - this.LinePosition;
            token.endPos = this.Position - this.LinePosition;
            token.Column = this.Column;
            this.Tokens.Add(token);
        }
    }
}
