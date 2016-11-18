using System;
using System.Collections.Generic;
using System.Web.Mvc;

using Moq;
using NUnit.Framework;
using NBehave.Spec.NUnit;

using OSIM.WebClient.Controllers;
using OSIM.Core.Entities;
using OSIM.Core.Persistence;

namespace OSIM.UnitTests.OSIM.WebClient
{
    public class when_working_with_the_item_type_controller : Specification
    {
        protected Mock<IItemTypeRepository> _itemRepository = new Mock<IItemTypeRepository>();
        protected ItemType _itemOne;
        protected ItemType _itemTwo;
        protected ItemType _itemThree;

        protected override void Establish_context()
        {
            _itemOne = new ItemType { Id = 1, Name = "USB drives" };
            _itemTwo = new ItemType { Id = 2, Name = "Nerf darts" };
            _itemThree = new ItemType { Id = 3, Name = "Flying Monkeys" };

            var itemTypeList = new List<ItemType>
                {
                    _itemOne,
                    _itemTwo,
                    _itemThree
                };

            _itemRepository.Setup(x => x.GetAll).Returns(itemTypeList);
        }

        public class and_trying_to_load_the_index_page : when_working_with_the_item_type_controller
        {
            object _model;
            int _expectedNumberOfItemsInModel;

            protected override void Establish_context()
            {
                base.Establish_context();
                _expectedNumberOfItemsInModel = _itemRepository.Object.GetAll.Count;
            }

            protected override void Because_of()
            {
                _model = ((ViewResult)new ItemTypeController(_itemRepository.Object).Index()).ViewData.Model;
            }

            [Test]
            public void then_a_valid_list_of_items_should_be_returned_in_the_model()
            {
                _expectedNumberOfItemsInModel.ShouldEqual(((List<ItemType>)_model).Count);
                _itemOne.ShouldEqual(((List<ItemType>)_model)[0]);
            }
        } 
    }
}
