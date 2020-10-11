using System;
using Newtonsoft.Json;

namespace LinkDotNet.EnumValueObject.Sample.NewtonsoftJsonConverter
{
    public static class Program
    {
        public static void Main()
        {
            var dto = new Dto { JsonEnumValueObject = JsonEnumValueObject.First };
            Console.WriteLine($"Before: {dto.JsonEnumValueObject.Key} / {dto.JsonEnumValueObject.Text}");
            var dtoAsJson = JsonConvert.SerializeObject(dto);
            var deserialized = (Dto)JsonConvert.DeserializeObject(dtoAsJson, typeof(Dto));
            Console.WriteLine($"After: {deserialized.JsonEnumValueObject.Key} / {deserialized.JsonEnumValueObject.Text}");
        }
    }
}
