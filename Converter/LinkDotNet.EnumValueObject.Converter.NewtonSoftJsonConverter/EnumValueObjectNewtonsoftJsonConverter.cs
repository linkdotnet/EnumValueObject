using System;
using Newtonsoft.Json;

namespace LinkDotNet.EnumValueObject.Converter.NewtonsoftJsonConverter
{
    public class EnumValueObjectNewtonsoftJsonConverter<TEnumValueObject> : JsonConverter<TEnumValueObject>
    where TEnumValueObject : EnumValueObject<TEnumValueObject>
    {
        public override bool CanRead => true;

        public override void WriteJson(JsonWriter writer, TEnumValueObject value, JsonSerializer serializer)
        {
            if (value != null)
            {
                writer.WriteValue(value.Key);
            }
        }

        public override TEnumValueObject ReadJson(JsonReader reader, Type objectType, TEnumValueObject existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var key = reader.Value as string;

            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            var result = EnumValueObject<TEnumValueObject>.Create(key);

            if (result.IsFailure)
            {
                throw new ArgumentException($"Could not transform to type {typeof(TEnumValueObject).Name} from key: {key}");
            }

            return result.Value;
        }
    }
}
