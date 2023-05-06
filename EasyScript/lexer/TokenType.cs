namespace EasyScript.lexer
{
    internal enum TokenType
    {
        NUMBER,
        BOOL,
        WORD,
        TEXT,

        CONST,
        VAR,
        IF,
        ELSE,
        WHILE,
        DO,
        BREAK,
        NEXT,
        FOR,
        IMPORT,

        FUNC,

        PLUS,
        PLUSPLUS,
        PLUSEQ,
        MINUS,
        MINUSMINUS,
        MINUSEQ,
        STAR,
        SLASH,
        NOT,
        LPAREN,
        RPAREN,
        LBRACE,
        RBRACE,
        LBRACKET,
        RBRACKET,
        LT,
        LTEQ,
        GT,
        GTEQ,

        EQ,
        EQEQ,
        NOTEQ,

        COMMA,

        EOF
    }
}
