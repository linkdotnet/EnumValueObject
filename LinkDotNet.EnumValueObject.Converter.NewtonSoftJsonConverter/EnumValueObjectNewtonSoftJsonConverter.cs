using System;
using Newtonsoft.Json;

namespace LinkDotNet.EnumValueObject.Converter.NewtonSoftJsonConverter
{
    public class EnumValueObjectNewtonSoftJsonConverter<TEnumValueObject> : JsonConverter
    where TEnumValueObject : EnumValueObject<TEnumValueObject>
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null)
            {
                var enumValue = (EnumValueObject<TEnumValueObject>)value;
                writer.WriteRawValue(enumValue.Key);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var key = reader.ReadAsString();
            var result = EnumValueObject<TEnumValueObject>.Create(key);

            if (result.IsFailure)
            {
                throw new ArgumentException($"Could not transform to type {typeof(TEnumValueObject).Name} from key: {key}");
            }

            return result.Value;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
