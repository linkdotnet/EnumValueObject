using System;

namespace LinkDotNet.EnumValueObject.Sample.NHibernateConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var entity = new RootEntity {SampleEnumValueObject = SampleEnumValueObject.Second};
            InMemorySessionFactoryProvider.Instance.Initialize();
            var session = InMemorySessionFactoryProvider.Instance.OpenSession();
            session.Save(entity);
            session.Flush();
            Console.WriteLine("Hello World!");
        }
    }
}
