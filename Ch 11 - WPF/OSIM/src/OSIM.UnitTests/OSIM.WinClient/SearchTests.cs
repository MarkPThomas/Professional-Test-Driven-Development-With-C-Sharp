using System;
using System.Collections.Generic;

using NBehave.Spec.NUnit;
using NUnit.Framework;

using OSIM.Core.Entities;
using OSIM.WinClient.ViewModels;

namespace OSIM.UnitTests.OSIM.WinClient
{
    #region when attempting to search
    public class when_attempting_to_search : Specification
    {
    }

    public class and_the_search_criteria_is_blank : when_attempting_to_search
    {
        private bool _result;
        private ISearchViewModel _searchViewModel;

        protected override void Establish_context()
        {
            base.Establish_context();
            _searchViewModel = new SearchViewModel();
        }

        protected override void Because_of()
        {
            _searchViewModel.Criteria = string.Empty;
            _result = _searchViewModel.CanSearch;
        }

        [Test]
        public void then_cansearch_should_be_false()
        {
            _result.ShouldBeFalse();
        }
    }

    public class and_the_search_criteria_is_not_blank : when_attempting_to_search
    {
        private bool _result;
        private ISearchViewModel _searchViewModel;

        protected override void Establish_context()
        {
            base.Establish_context();
            _searchViewModel = new SearchViewModel();
        }

        protected override void Because_of()
        {
            _searchViewModel.Criteria = "foo";
            _result = _searchViewModel.CanSearch;
        }

        [Test]
        public void then_cansearch_should_be_true()
        {
            _result.ShouldBeTrue();
        }
    }

    public class and_wanting_to_clear_when_criteria_is_empty : when_attempting_to_search
    {
        private bool _result;
        private ISearchViewModel _searchViewModel;

        protected override void Establish_context()
        {
            base.Establish_context();
            _searchViewModel = new SearchViewModel();
        }

        protected override void Because_of()
        {
            _result = _searchViewModel.CanClear;
        }

        [Test]
        public void then_cancelclear_should_be_false()
        {
            _result.ShouldBeFalse();
        }
    }

    public class and_wanting_to_clear_when_criteria_is_not_empty : when_attempting_to_search
    {
        private bool _result;
        private ISearchViewModel _searchViewModel;

        protected override void Establish_context()
        {
            base.Establish_context();
            _searchViewModel = new SearchViewModel();
            _searchViewModel.Criteria = "foo";
        }

        protected override void Because_of()
        {
            _result = _searchViewModel.CanClear;
        }

        [Test]
        public void then_cancelclear_should_be_false()
        {
            _result.ShouldBeTrue();
        }
    }

    public class and_executing_clear : when_attempting_to_search
    {
        private bool _canClear;
        private string _result;
        private ISearchViewModel _searchViewModel;
        private List<ItemType> _searchResults;

        protected override void Establish_context()
        {
            base.Establish_context();
            _searchViewModel = new SearchViewModel();
            _searchViewModel.Criteria = "foo";
            _searchViewModel.Results = new List<ItemType>();
        }

        protected override void Because_of()
        {
            _canClear = _searchViewModel.CanClear;
            _searchViewModel.Clear();
            _result = _searchViewModel.Criteria;
            _searchResults = _searchViewModel.Results;
        }

        [Test]
        public void then_criteria_should_be_blank()
        {
            _result.ShouldBeEmpty();
        }

        [Test]
        public void then_results_should_be_cleared()
        {
            _searchResults.ShouldBeNull();
        }
    }
    #endregion

    #region when searching
    public class when_searching : Specification
    {

    }

    public class and_searching_for_an_item_that_does_not_exist : when_searching
    {
        private List<ItemType> _results;
        private bool _canSearch;
        private ISearchViewModel _searchViewModel;

        protected override void Establish_context()
        {
            base.Establish_context();
            _searchViewModel = new SearchViewModel();
            _searchViewModel.Criteria = "foo";
        }

        protected override void Because_of()
        {
            _canSearch = _searchViewModel.CanSearch;
            _searchViewModel.Search();
            _results = _searchViewModel.Results;
        }

        [Test]
        public void then_results_should_be_null()
        {
            _canSearch.ShouldBeTrue();
            _results.ShouldBeNull();
        }
    }

    public class and_searching_for_an_item_that_does_exist : when_searching
    {
        private List<ItemType> _results;
        private bool _canSearch;
        private ISearchViewModel _searchViewModel;

        protected override void Establish_context()
        {
            base.Establish_context();
            _searchViewModel = new SearchViewModel();
            _searchViewModel.Criteria = "USB";
        }

        protected override void Because_of()
        {
            _canSearch = _searchViewModel.CanSearch;
            _searchViewModel.Search();
            _results = _searchViewModel.Results;
        }

        [Test]
        public void then_results_should_be_null()
        {
            _canSearch.ShouldBeTrue();
            _results.ShouldNotBeEmpty();
        }
    }

    #endregion


}
