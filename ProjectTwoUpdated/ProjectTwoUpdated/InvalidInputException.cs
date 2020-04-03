using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Two
{
    class InvalidInputException : Exception
    {
        public string Input { get; }

        public InvalidInputException() { }

        public InvalidInputException(string message)
        : base(message) { }

        public InvalidInputException(string message, Exception inner)
            : base(message, inner) { }

        public InvalidInputException(string message, string input)
            : this(message)
        {
            Input = input;
        }
        public InvalidInputException(string message, char input)
            : this(message)
        {
            Input = input.ToString();
        }
    }
}
