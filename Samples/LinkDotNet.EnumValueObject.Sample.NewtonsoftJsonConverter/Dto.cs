using LinkDotNet.EnumValueObject.Converter.NewtonsoftJsonConverter;
using Newtonsoft.Json;

namespace LinkDotNet.EnumValueObject.Sample.NewtonsoftJsonConverter
{
    public class Dto
    {
        [JsonConverter(typeof(EnumValueObjectNewtonsoftJsonConverter<JsonEnumValueObject>))]
        public JsonEnumValueObject JsonEnumValueObject { get; set; }
    }
}