namespace LinkDotNet.EnumValueObject.Sample.EFCore
{
    public class Origin : EnumValueObject<Origin>
    {
        public static readonly Origin MushroomKingdom = new Origin("mushroom", "Princess Peach", "Mushroom Kingdom");
        public static readonly Origin Hyrule = new Origin("hyrule", "Royal Family of Hyrule", "Hyrule");

        public string Ruler { get; }

        public string DisplayName { get; }

        protected Origin(string origin, string ruler, string displayName) : base(origin)
        {
            Ruler = ruler;
            DisplayName = displayName;
        }
    }
}