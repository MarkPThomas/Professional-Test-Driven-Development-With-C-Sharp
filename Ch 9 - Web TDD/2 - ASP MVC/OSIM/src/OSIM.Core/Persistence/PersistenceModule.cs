using System;
using System.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Ninject.Activation;
using Ninject.Modules;
using OSIM.Core.Entities;
using Configuration = NHibernate.Cfg.Configuration;

namespace OSIM.Core.Persistence
{
    public class PersistenceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IItemTypeRepository>().To<ItemTypeRepository>();
            Bind<ISessionFactory>().ToProvider(new SessionFactoryProvider());
        }
    }

    public class SessionFactoryProvider : Provider<ISessionFactory>
    {
        protected override ISessionFactory CreateInstance(IContext context)
        {
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                              .ConnectionString(c => c.Is(ConfigurationManager.AppSettings["localDb"]))
                              .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ItemType>()
                                   .ExportTo(@"C:\Temp"))
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();

            return sessionFactory;
        }

        private static void BuildSchema(Configuration configuration)
        {
            new SchemaExport(configuration).Create(true, true);
        }
    }
}