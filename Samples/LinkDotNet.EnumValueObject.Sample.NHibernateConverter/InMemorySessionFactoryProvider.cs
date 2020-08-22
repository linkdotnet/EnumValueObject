using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LinkDotNet.EnumValueObject.Converter.NHibernateInterceptor;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace LinkDotNet.EnumValueObject.Sample.NHibernateConverter
{
    public class InMemorySessionFactoryProvider
    {
        private static InMemorySessionFactoryProvider _instance;
        public static InMemorySessionFactoryProvider Instance => _instance ??= new InMemorySessionFactoryProvider();

        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        private InMemorySessionFactoryProvider() { }

        public void Initialize()
        {
            _sessionFactory = CreateSessionFactory();
        }

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
                .ProxyFactoryFactory<EnumValueObjectFactoryFactory>()
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RootEntityMap>())
                .ExposeConfiguration(cfg =>
                {
                    cfg.SetInterceptor(new EnumValueObjectInterceptor());
                    _configuration = cfg;
                })
                .BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            var session = _sessionFactory.OpenSession();

            var export = new SchemaExport(_configuration);
            export.Execute(true, true, false, session.Connection, null);

            return session;
        }

        public void Dispose()
        {
            _sessionFactory?.Dispose();

            _sessionFactory = null;
            _configuration = null;
        }
    }
}