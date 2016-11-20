using System;
using Ninject.Modules;

namespace OSIM.Core.Services
{
    public class CoreServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IItemTypeService>().To<ItemTypeService>();
        }
    }
}