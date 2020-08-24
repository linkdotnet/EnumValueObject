using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LinkDotNet.EnumValueObject.Converter.NHibernateInterceptor;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Environment = NHibernate.Cfg.Environment;

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
            Environment.BytecodeProvider = new EnumValueObjectByteCodeProvider();
            _sessionFactory = CreateSessionFactory();
        }

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RootEntityMap>())
                .ExposeConfiguration(cfg =>
                {
                    _configuration = cfg;
                })
                .BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            var session = _sessionFactory.WithOptions().Interceptor(new EnumValueObjectInterceptor()).OpenSession();

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