using System;

namespace OSIM.Core.Entities
{
    public class ItemType
    {
        // Note: All public members that are mapped using NHibernate must be virtual

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}
