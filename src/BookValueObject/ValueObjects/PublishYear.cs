using BookValueObject.Exceptions;
using System;

namespace BookValueObject.ValueObjects
{
    public class PublishYear
    {
        public PublishYear(int year)
        {
            if (year < 0) Era = Era.BeforeCommon;

            if (year > DateTime.Now.Year) throw new InvalidPublishYearException();

            Year = Math.Abs(year);
        }

        public int Year { get; }
        public Era Era { get; } = Era.Common;

        public override string ToString() => $"{Year} {Era}";

        public static explicit operator PublishYear(int year) => new PublishYear(year);
    }
}
