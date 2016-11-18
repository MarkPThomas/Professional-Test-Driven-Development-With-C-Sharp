using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentNHibernate.Mapping;
using OSIM.Core.Entities;

namespace OSIM.Core.Persistence.Mappings
{
    /// <summary>
    /// The result of this mapping class is the creation of a table called 'ItemType' with two columns, 'Id' (primary key) and 'Name'.
    /// </summary>
    public class ItemTypeMap : ClassMap<ItemType>
    {
        public ItemTypeMap()
        {
            // Specifies in which field or fields the entitity class map to the primary key of the table the data wll be stored.
            Id(x => x.Id);
            
            // Tells Fluent NHibernate to map that field in the entity class to a field of the same name and type in the data table.
            Map(x => x.Name);
        }
    }
}
