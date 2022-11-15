using System;
using System.Collections.Generic;
using System.Text;

namespace Niobe.Core
{
    public class Token
    {
        public Token(string value, long expireIn, string type)
        {
            Value = value;

            ExpireIn = expireIn;

            Type = type;
        }
        public string Value { get; }
        public long ExpireIn { get; }
        public string Type { get; }
    }
}
