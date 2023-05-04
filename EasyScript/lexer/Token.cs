using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScript.lexer
{
    internal class Token
    {
        private TokenType Type;
        private String Value;
        public string LineText;
        public int Column;
        public int startPos = 0;
        public int endPos = 0;

        public Token(TokenType Type, String Value) 
        {
            this.Type = Type;
            this.Value= Value;
        }

        public void SetType(TokenType Type)
        {
            this.Type = Type;
        }

        public TokenType getType()
        {
            return this.Type;
        }

        public String getValue()
        {
            return this.Value;
        }

        public override string ToString()
        {
            return "Token: Type = " + this.Type + ", Value = " + this.Value;
        }
    }
}
