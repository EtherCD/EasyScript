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
        public Token(TokenType Type, String Value) 
        {
            this.Type = Type;
            this.Value= Value;
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
