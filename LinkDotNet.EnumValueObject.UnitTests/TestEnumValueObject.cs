namespace LinkDotNet.EnumValueObject.UnitTests
{
    public sealed class TestEnumValueObject : EnumValueObject<TestEnumValueObject>
    {
        public static readonly TestEnumValueObject One = new TestEnumValueObject(nameof(One));

        public static readonly TestEnumValueObject Two = new TestEnumValueObject(nameof(Two));

        private TestEnumValueObject(string key) : base(key)
        {
        }
    }
}