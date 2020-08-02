using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CSharpFunctionalExtensions;

namespace LinkDotNet.EnumValueObject
{
    public abstract class EnumValueObject<TEnumeration> : ValueObject
        where TEnumeration : EnumValueObject<TEnumeration>
    {
        private static readonly TEnumeration[] Enumerations = GetEnumerations();

        private string _key;

        protected EnumValueObject()
        {
        }

        protected EnumValueObject(string key)
        {
            _key = key;
        }

        public static IReadOnlyList<TEnumeration> All => Enumerations;

        public virtual string Key
        {
            get => _key;
            protected set => PopulateOnLoadingFromDb(Create(value).Value);
        }

        public static bool operator ==(EnumValueObject<TEnumeration> a, string b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Key.Equals(b);
        }

        public static bool operator !=(EnumValueObject<TEnumeration> a, string b)
        {
            return !(a == b);
        }

        public static bool operator ==(string a, EnumValueObject<TEnumeration> b)
        {
            return b == a;
        }

        public static bool operator !=(string a, EnumValueObject<TEnumeration> b)
        {
            return !(b == a);
        }

        public override bool Equals(object obj)
        {
            if (obj is string s)
            {
                return this == s;
            }

            return base.Equals(obj);
        }

        public static Result<TEnumeration> Create(string key)
        {
            var enumeration = All.SingleOrDefault(p => p.Key == key);

            if (enumeration == null)
            {
                return Result.Failure<TEnumeration>($"The type '{key}' is not a valid {typeof(TEnumeration).Name}.");
            }

            return Result.Success(enumeration);
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override string ToString() => Key;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Key;
        }

        protected virtual void PopulateOnLoadingFromDb(TEnumeration enumValue)
        {
            _key = enumValue.Key;
        }

        private static TEnumeration[] GetEnumerations()
        {
            var enumerationType = typeof(TEnumeration);

            return enumerationType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                                  .Where(info => enumerationType.IsAssignableFrom(info.FieldType))
                                  .Select(info => info.GetValue(null))
                                  .Cast<TEnumeration>()
                                  .ToArray();
        }
    }
}
