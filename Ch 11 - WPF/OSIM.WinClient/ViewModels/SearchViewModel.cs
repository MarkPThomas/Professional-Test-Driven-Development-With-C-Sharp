using System;
using System.Collections.Generic;

using Caliburn.Micro;

using OSIM.Core.Entities;
using OSIM.Core.Persistence;

namespace OSIM.WinClient.ViewModels
{
    public interface ISearchViewModel
    {
        string Criteria { get; set; }
        bool CanSearch { get; }
        bool CanClear { get; }
        void Clear();
        List<ItemType> Results { get; set; }
        void Search();
    }

    public class SearchViewModel : PropertyChangedBase, ISearchViewModel
    {
        private string _criteria;
        public string Criteria
        {
            get { return _criteria; }
            set
            {
                _criteria = value;
                NotifyOfPropertyChange(() => Criteria);
            }
        }
        public bool CanSearch { get { return !string.IsNullOrEmpty(Criteria); } }

        public bool CanClear { get { return !string.IsNullOrEmpty(Criteria); } }

        private List<ItemType> _results;
        public List<ItemType> Results
        {
            get { return _results; }
            set
            {
                _results = value;
                NotifyOfPropertyChange(() => Results);
            }
        }

        public void Clear()
        {
            Criteria = string.Empty;
            Results = null;
        }

        public void Search()
        {
            // In the grand scheme of things, instead of hard-coding data, you'll call methods in a service or possibly a repository class, 
            // pass in the criteria, and set results to the output from those methods.
            if (Criteria == "foo")
                Results = null;
            else
            {
                Results = new List<ItemType>();
                if (Criteria == "USB")
                {
                    Results.Add(new ItemType { Id = 1, Name = "USB Key - 2GB" });
                    Results.Add(new ItemType { Id = 2, Name = "USB Key - 4GB" });
                    Results.Add(new ItemType { Id = 3, Name = "USB Key - 8GB" });
                    Results.Add(new ItemType { Id = 4, Name = "USB Key - 16GB" });
                }
            }

        }
    }
}
