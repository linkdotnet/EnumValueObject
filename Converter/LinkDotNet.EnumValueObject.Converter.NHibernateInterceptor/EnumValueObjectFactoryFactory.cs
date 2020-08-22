using NHibernate.Bytecode;
using NHibernate.Proxy;

namespace LinkDotNet.EnumValueObject.Converter.NHibernateInterceptor
{
    public class EnumValueObjectFactoryFactory : StaticProxyFactoryFactory
    {
        public new IProxyValidator ProxyValidator => new EnumValueObjectConstructorValidator();
    }
}