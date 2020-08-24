using System;
using NHibernate.Proxy;

namespace LinkDotNet.EnumValueObject.Converter.NHibernateInterceptor
{
    internal class EnumValueObjectConstructorValidator : DynProxyTypeValidator
    {
        protected override bool HasVisibleDefaultConstructor(Type type)
        {
            return type.IsSubclass(typeof(EnumValueObject<>)) || base.HasVisibleDefaultConstructor(type);
        }
    }
}