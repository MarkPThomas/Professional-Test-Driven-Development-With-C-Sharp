using System;
using System.Web.Mvc;
using OSIM.Core.Entities;
using OSIM.Persistence;

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

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            var ItemType = new ItemType();

            return View(ItemType);
        }

        [HttpPost]
        public ActionResult Create(ItemType itemType)
        {
            if (ModelState.IsValid)
            {

                //Save the item
                //_itemTypeRepository.Save(itemType);

                return RedirectToAction("Index");

            }

            return View("create", itemType);
        }

        public ActionResult Edit(int id)
        {
            ItemType itemType = _itemTypeRepository.GetById(id);
            
            return View("edit",itemType);
        }

        [HttpPost]
        public ActionResult Edit(int id, ItemType itemType)
        {
            try
            {
                _itemTypeRepository.Save(itemType);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
