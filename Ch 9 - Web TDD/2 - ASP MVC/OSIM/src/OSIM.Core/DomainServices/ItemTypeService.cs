using System.Collections.Generic;
using OSIM.Core.Entities;
using OSIM.Core.Persistence;

namespace OSIM.Core.Services
{
    public interface IItemTypeService
    {
        IList<ItemType> GetItemTypes();
    }

    public class ItemTypeService : IItemTypeService
    {
        private readonly IItemTypeRepository _itemTypeRepository;

        public ItemTypeService(IItemTypeRepository itemTypeRepository)
        {
            _itemTypeRepository = itemTypeRepository;
        }

        public IList<ItemType> GetItemTypes()
        {
            return _itemTypeRepository.GetAll;
        }
    }
}