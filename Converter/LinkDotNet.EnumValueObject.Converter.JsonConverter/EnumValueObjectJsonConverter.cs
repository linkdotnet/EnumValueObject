using System;
using System.Data.SqlTypes;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LinkDotNet.EnumValueObject.Converter.JsonConverter
{
    public class EnumValueObjectJsonConverter<TEnumValueObject> : JsonConverter<TEnumValueObject> 
        where TEnumValueObject : EnumValueObject<TEnumValueObject>
    {
        public override TEnumValueObject Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var jsonString = reader.GetString();
            var result = EnumValueObject<TEnumValueObject>.Create(jsonString);

            if (result.IsFailure)
            {
                throw new ArgumentException($"Could not transform to type {typeof(TEnumValueObject).Name} from key: {jsonString}");
            }

            return result.Value;
        }

        public override void Write(Utf8JsonWriter writer, TEnumValueObject value, JsonSerializerOptions options)
        {
            if (value != null)
            {
                writer.WriteStringValue(value.Key);
            }
        }
    }
}
