using System;

namespace BookValueObject.Exceptions
{
    public class InvalidPublishYearException : Exception
    {
        public InvalidPublishYearException()
            :base("Publish year is invalid.")
        {
        }
    }
}
