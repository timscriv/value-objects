namespace BookValueObject.ValueObjects
{
    public class Year
    {
        public int Value { get; }
        public Era Era { get; }

        public override string ToString() => $"{Value} {Era}";
    }
}
