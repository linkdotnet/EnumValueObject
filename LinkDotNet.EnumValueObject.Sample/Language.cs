namespace LinkDotNet.EnumValueObject.Sample
{
    public class Language : EnumValueObject<Language>
    {
        public static readonly Language German = new Language("de", "€");

        public static readonly Language English = new Language("de", "£");
        public string Currency { get; }

        public Language(string key, string currency) : base(key)
        {
            Currency = currency;
        }
    }
}