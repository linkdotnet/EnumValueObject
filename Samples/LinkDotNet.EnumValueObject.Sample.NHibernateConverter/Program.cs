using System;

namespace LinkDotNet.EnumValueObject.Sample.NHibernateConverter
{
    public static class Program
    {
        public static void Main()
        {
            var entity = new RootEntity {SampleEnumValueObject = SampleEnumValueObject.Second};
            InMemorySessionFactoryProvider.Instance.Initialize();
            SaveEntity(entity);
        }

        private static void SaveEntity(RootEntity entity)
        {
            using var session = InMemorySessionFactoryProvider.Instance.OpenSession();
            session.Save(entity);
            session.Flush();
            session.Clear();
        }
    }
}
