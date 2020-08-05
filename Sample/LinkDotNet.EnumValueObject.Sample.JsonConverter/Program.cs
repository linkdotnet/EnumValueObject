using System;
using System.Text.Json;

namespace LinkDotNet.EnumValueObject.Sample.JsonConverter
{
    public static class Program
    {
        public static void Main()
        {
            var dto = new Dto {JsonEnumValueObject = JsonEnumValueObject.First};
            Console.WriteLine($"Before: {dto.JsonEnumValueObject.Key} / {dto.JsonEnumValueObject.Text}");
            var dtoAsJson = JsonSerializer.Serialize(dto);
            var deserialized = JsonSerializer.Deserialize<Dto>(dtoAsJson);
            Console.WriteLine($"After: {deserialized.JsonEnumValueObject.Key} / {deserialized.JsonEnumValueObject.Text}");
        }
    }
}
