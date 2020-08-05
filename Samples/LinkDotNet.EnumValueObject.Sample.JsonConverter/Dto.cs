using System.Text.Json.Serialization;
using LinkDotNet.EnumValueObject.Converter.JsonConverter;

namespace LinkDotNet.EnumValueObject.Sample.JsonConverter
{
    public class Dto
    {
        [JsonConverter(typeof(EnumValueObjectJsonConverter<JsonEnumValueObject>))]
        public JsonEnumValueObject JsonEnumValueObject { get; set; }
    }
}