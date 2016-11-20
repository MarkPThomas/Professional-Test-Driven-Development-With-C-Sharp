using System;

using Rhino.Mocks;
using NBehave.Spec.NUnit;
using NUnit.Framework;

using Wrox.BooksRead.Web.Helpers;

namespace Wrox.BooksRead.Tests
{
    public class when_using_the_html_helper_to_truncate_text : Specification
    {
        protected string _textToTruncate;
        protected string _expected;
        protected string _actual;
        protected int _numberToTruncate;

        protected override void Because_of()
        {
            _actual = HTMLHelper.Truncate(_textToTruncate, _numberToTruncate);
        }
    }

    public class and_passing_a_string_that_needs_to_be_truncated : when_using_the_html_helper_to_truncate_text
    {
        protected override void Establish_context()
        {
            _textToTruncate = "This is my text";
            _expected = "This ...";
            _numberToTruncate = 5;
        }

        [Test]
        public void then_the_text_should_be_truncated_with_ellipses()
        {
            _expected.ShouldEqual(_actual);
        }
    }

    public class and_passing_a_string_that_does_not_need_to_be_truncated : when_using_the_html_helper_to_truncate_text
    {
        protected override void Establish_context()
        {
            _textToTruncate = "This is my text";
            _expected = "This is my text";
            _numberToTruncate = 0;
        }

        [Test]
        public void then_the_text_should_not_contain_ellipses()
        {
            _expected.ShouldEqual(_actual);
        }
    }

    public class and_passing_a_string_that_is_less_than_what_needs_to_be_truncated : when_using_the_html_helper_to_truncate_text
    {
        protected override void Establish_context()
        {
            _textToTruncate = "This is my text";
            _expected = "This is my text";
            _numberToTruncate = 50;
        }

        [Test]
        public void then_the_text_should_not_contain_ellipses()
        {
            _expected.ShouldEqual(_actual);
        }
    }

    public class and_passing_a_null_value : when_using_the_html_helper_to_truncate_text
    {
        protected override void Establish_context()
        {
            _textToTruncate = null;
            _expected = string.Empty;
            _numberToTruncate = 50;
        }

        [Test]
        public void then_the_text_should_not_contain_ellipses()
        {
            _expected.ShouldEqual(_actual);
        }
    }
}
