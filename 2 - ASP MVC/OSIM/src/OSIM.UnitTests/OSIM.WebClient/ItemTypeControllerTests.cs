using System;
using System.Collections.Generic;
using System.Web.Mvc;

using Moq;
using NUnit.Framework;
using NBehave.Spec.NUnit;


using OSIM.Core.Entities;
using OSIM.Core.Persistence;
using OSIM.WebClient.Controllers;

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

        public class and_trying_to_create_a_new_valid_item_type : when_working_with_the_item_type_controller
        {
            ItemType _newItemType;
            ItemTypeController _controller;
            RedirectToRouteResult _result;
            string _expectedRouteName;

            protected override void Establish_context()
            {
                base.Establish_context();
                _expectedRouteName = "Index";
                _newItemType = new ItemType() { Id = 99, Name = "New Item" };
                _controller = new ItemTypeController(_itemRepository.Object);
            }

            protected override void Because_of()
            {
                _result = _controller.Create(_newItemType) as RedirectToRouteResult;
            }

            [Test]
            public void then_a_new_item_type_should_be_created_and_the_redirected_to_the_correct_view()
            {
                _result.ShouldNotBeNull();
                _result.RouteValues.Values.ShouldContain(_expectedRouteName);
            }
        }

        public class and_trying_to_create_a_new_invalid_item_type : when_working_with_the_item_type_controller
        {
            ItemType _newItemType;
            ItemTypeController _controller;
            ViewResult _result;
            string _expectedRouteName;

            protected override void Establish_context()
            {
                base.Establish_context();
                _expectedRouteName = "create";
                _newItemType = new ItemType() { Id = 99, Name = "New Item" };
                _controller = new ItemTypeController(_itemRepository.Object);
                _controller.ModelState.AddModelError("key", "model is invalid");
            }

            protected override void Because_of()
            {
                _result = _controller.Create(_newItemType) as ViewResult;
            }

            [Test]
            public void then_a_new_item_type_should_not_be_created()
            {
                _result.ShouldNotBeNull();
                _result.ViewName.ShouldEqual(_expectedRouteName);
            }
        }

        public class and_trying_to_edit_an_existing_item : when_working_with_the_item_type_controller
        {
            string _expectedRouteName;
            ItemTypeController _controller;
            ViewResult _result;

            protected override void Establish_context()
            {
                base.Establish_context();
                _expectedRouteName = "edit";
                _controller = new ItemTypeController(_itemRepository.Object);
                _result = _controller.Edit(_itemOne.Id) as ViewResult;
            }

            protected override void Because_of()
            {
            }

            [Test]
            public void then_a_valid_edit_view_should_be_returned()
            {
                _expectedRouteName.ShouldEqual(_result.ViewName);
            }
        }
    }
}
