using BookValueObject.Exceptions;

namespace BookValueObject.ValueObjects
{
    public class PageCount
    {
        public PageCount(int value)
        {
            if (value <= 0 || value > 50000) throw new InvalidPageCountException();

            Value = value;
        }

        public int Value { get; }

        public override string ToString() => $"{Value:n0} pages";

        public static implicit operator PageCount(int value)
        {
            return new PageCount(value);
        }
    }
}
