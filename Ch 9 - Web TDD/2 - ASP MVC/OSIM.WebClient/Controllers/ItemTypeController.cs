using System;
using System.Web.Mvc;
using OSIM.Core.Entities;
using OSIM.Core.Persistence;

namespace OSIM.WebClient.Controllers
{
    public class ItemTypeController : Controller
    {
        IItemTypeRepository _itemTypeRepository;

        public ItemTypeController(IItemTypeRepository itemRepository)
        {
            _itemTypeRepository = itemRepository;
        }

        public ActionResult Index()
        {
            ViewData.Model = _itemTypeRepository.GetAll;
            return View();
        }
    }
}