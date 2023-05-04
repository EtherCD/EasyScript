using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        FOR,
        PRINT,
        EVAL,
        LOADSCRIPT,

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
        LT,
        LTEQ,
        GT,
        GTEQ,

        EQ,
        EQEQ,
        NOTEQ,

        EOF
    }
}
