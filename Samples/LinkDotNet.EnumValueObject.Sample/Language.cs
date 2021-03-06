﻿namespace LinkDotNet.EnumValueObject.Sample
{
    public class Language : EnumValueObject<Language>
    {
        public static readonly Language German = new Language("de", "€");

        public static readonly Language English = new Language("en", "£");
        public string Currency { get; }

        private Language(string key, string currency) : base(key)
        {
            Currency = currency;
        }
    }
}