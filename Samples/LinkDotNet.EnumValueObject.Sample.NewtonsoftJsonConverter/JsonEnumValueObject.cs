namespace LinkDotNet.EnumValueObject.Sample.NewtonsoftJsonConverter
{
    public class JsonEnumValueObject : EnumValueObject<JsonEnumValueObject>
    {
        public static readonly JsonEnumValueObject First = new JsonEnumValueObject("First", "Text A");

        public static readonly JsonEnumValueObject Second = new JsonEnumValueObject("Second", "Text B");
        public string Text { get; }

        private JsonEnumValueObject(string key, string text) : base(key)
        {
            Text = text;
        }
    }
}