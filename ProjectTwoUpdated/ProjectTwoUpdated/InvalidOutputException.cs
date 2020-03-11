using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Two
{
    class InvalidOutputException : Exception
    {
        public string Output { get; }

        public InvalidOutputException() { }

        public InvalidOutputException(string message)
        : base(message) { }

        public InvalidOutputException(string message, Exception inner)
            : base(message, inner) { }

        public InvalidOutputException(string message, string output)
            : this(message)
        {
            Output = output;
        }
    }
}
