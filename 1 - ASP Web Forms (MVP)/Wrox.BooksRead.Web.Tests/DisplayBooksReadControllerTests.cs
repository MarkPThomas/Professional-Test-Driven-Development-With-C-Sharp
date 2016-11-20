using System;

using Rhino.Mocks;
using NBehave.Spec.NUnit;
using NUnit.Framework;

using Wrox.BooksRead.Web;

namespace Wrox.BooksRead.Tests
{
    /// Testing the 'presenter'.

    public class when_using_the_books_read_controller : Specification
    {

    }

    public class and_getting_a_list_of_books : when_using_the_books_read_controller
    {

    }

    public class and_when_calling_getdata_bind_should_be_called : and_getting_a_list_of_books
    {
        IDisplayBooksReadView _view;
        DisplayBooksReadController _controller;

        protected override void Establish_context()
        {
            base.Establish_context();
            _view = MockRepository.GenerateMock<IDisplayBooksReadView>();
            _view.Expect(v => v.Bind());
            _controller = new DisplayBooksReadController(_view);
        }

        protected override void Because_of()
        {
            _controller.GetData(this, EventArgs.Empty);
        }

        [Test]
        public void then_getdata_should_call_bind()
        {
            _view.VerifyAllExpectations();
        }
    }

    public class and_wireing_the_events_by_the_constructor : and_getting_a_list_of_books
    {
        IDisplayBooksReadView _view;

        protected override void Establish_context()
        {
            base.Establish_context();
            _view = MockRepository.GenerateMock<IDisplayBooksReadView>();
            _view.Expect(v => v.DataRequested += null).IgnoreArguments();
        }

        protected override void Because_of()
        {
            new DisplayBooksReadController(_view);
        }

        [Test]
        public void then_the_constructor_should_wire_up_events()
        {
            _view.VerifyAllExpectations();
        }
    }

    public class and_populating_data_with_getdata : and_getting_a_list_of_books
    {
        IDisplayBooksReadView _view;
        DisplayBooksReadController _controller;

        protected override void Establish_context()
        {
            base.Establish_context();
            _view = MockRepository.GenerateStub<IDisplayBooksReadView>();
            _controller = new DisplayBooksReadController(_view);
        }

        protected override void Because_of()
        {
            _controller.GetData(this, EventArgs.Empty);
        }

        [Test]
        public void then_getdata_should_populate_data()
        {
            _view.Data.Count.ShouldEqual(3);
        }
    }
}
