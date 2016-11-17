using System;

using NHibernate;

using OSIM.Core.Entities;

namespace OSIM.Core.Persistence
{
    // Note: It is intentional to place both the interface and class in the same file.
    // This is recommended in the majority of cases where an interface is only used by 1 class.
    // This is a good strategy because:
    //  1. This reduces the number of files in VS, which keeps it running faster.
    //  2. The interface and dedicated class make a logical unit.

    public interface IItemTypeRepository
    {
        int Save(ItemType testItemType);
    }

    public class ItemTypeRepository : IItemTypeRepository
    {
        private ISessionFactory _sessionFactory;

        public ItemTypeRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public int Save(ItemType itemType)
        {
            int id;
            using (var session = _sessionFactory.OpenSession())
            {
                id = (int)session.Save(itemType);
                session.Flush();
            }
            return id;
        }
    }
}
