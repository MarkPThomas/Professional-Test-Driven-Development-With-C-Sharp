using System.Configuration;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Ninject.Activation;
using Ninject.Modules;

using OSIM.Core.Persistence;
using OSIM.Core.Persistence.Mappings;

namespace OSIM.IntegrationTests
{
    public class IntegrationTestModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IItemTypeRepository>().To<ItemTypeRepository>();
            Bind<ISessionFactory>().ToProvider(new IntegrationTestSessionFactoryProvider());
        }
    }

    public class IntegrationTestSessionFactoryProvider : Provider<ISessionFactory>
    {
        protected override ISessionFactory CreateInstance(IContext context)
        {
            //// This was done in case the App.Config file was not being read.
            //if (ConfigurationManager.AppSettings["localDb"] == null)
            //{
            //    ConfigurationManager.AppSettings.Add("localDb",
            //        @"Data Source=(localdb)\ProjectsV13;Initial Catalog=OSIM.Dev;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True");
            //}

            // Note: This works if App.Config is included in the test project. See App.Config for key-value connection strings.
            // Note: For the value string, use literally what in the ConnectionString property of the desired database.
            // This is found by opening View > SQL Server Object Explorer and looking up the server containign the matching DB project.
            // Note: Export path must exist.
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.Is(ConfigurationManager.AppSettings["localDb"])).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ItemTypeMap>().ExportTo(@"C:\Temp"))
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .BuildSessionFactory();

            return sessionFactory;
        }
    }
}
