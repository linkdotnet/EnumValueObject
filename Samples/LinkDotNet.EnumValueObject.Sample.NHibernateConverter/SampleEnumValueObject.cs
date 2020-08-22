namespace LinkDotNet.EnumValueObject.Sample.NHibernateConverter
{
    public class SampleEnumValueObject : EnumValueObject<SampleEnumValueObject>
    {
        public static readonly SampleEnumValueObject First = new SampleEnumValueObject("First", "Text A");

        public static readonly SampleEnumValueObject Second = new SampleEnumValueObject("Second", "Text B");
        public string Text { get; }

        private SampleEnumValueObject(string key, string text) : base(key)
        {
            Text = text;
        }
    }
}