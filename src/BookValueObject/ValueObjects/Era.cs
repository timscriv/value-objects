namespace BookValueObject.ValueObjects
{
    public class Era
    {
        public static Era BeforeCommon = new Era("BCE");
        public static Era Common = new Era("CE");

        public Era(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override string ToString() => Name;
    }
}
