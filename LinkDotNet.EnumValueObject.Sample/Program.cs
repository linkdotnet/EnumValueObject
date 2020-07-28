using System;

namespace LinkDotNet.EnumValueObject.Sample
{
    public static class Program
    {
        public static void Main()
        {
            Console.Write("Which language? Type 'de' for german or 'en' for english:");
            var input = Console.ReadLine();
            var languageResult = Language.Create(input);

            if (languageResult.IsFailure)
            {
                Console.WriteLine("You entered the wrong language code");
                return;
            }

            var language = languageResult.Value;
            Console.WriteLine($"Currency: {language.Currency}");

            // You can also compare two ValueObjects
            if (language == Language.English)
            {
                Console.WriteLine("English");
            }

            // Or compare it to its key
            if (language == "en")
            {
                Console.WriteLine("English key");
            }
        }
    }
}
