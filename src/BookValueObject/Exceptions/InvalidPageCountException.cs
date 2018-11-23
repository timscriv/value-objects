using System;

namespace BookValueObject.Exceptions
{
    public class InvalidPageCountException : Exception
    {
        public InvalidPageCountException() 
            : base("Page count cannot be negative, zero, or over 50,000.")
        {
        }
    }
}
