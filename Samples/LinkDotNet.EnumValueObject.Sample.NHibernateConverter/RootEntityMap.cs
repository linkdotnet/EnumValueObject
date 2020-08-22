using FluentNHibernate.Mapping;

namespace LinkDotNet.EnumValueObject.Sample.NHibernateConverter
{
    public class RootEntityMap : ClassMap<RootEntity>
    {
        public RootEntityMap()
        {
            Not.LazyLoad();
            Id(r => r.Id);
            Component(r => r.SampleEnumValueObject, part => part.Map(e => e.Key));
        }
    }
}