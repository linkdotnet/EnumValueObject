using System;
using NHibernate.Proxy;

namespace LinkDotNet.EnumValueObject.Converter.NHibernateInterceptor
{
    public class EnumValueObjectConstructorValidator : DynProxyTypeValidator
    {
        protected override bool HasVisibleDefaultConstructor(Type type)
        {
            return type.IsSubclassOf(typeof(EnumValueObject<>)) || base.HasVisibleDefaultConstructor(type);
        }
    }
}