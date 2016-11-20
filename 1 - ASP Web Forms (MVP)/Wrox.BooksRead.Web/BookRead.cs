using System;

namespace Wrox.BooksRead.Web
{
    /// <summary>
    /// Model part of the pattern.
    /// </summary>
    public class BookRead
    {
        public int ReadBookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Rating { get; set; }
        public string PurchaseLink { get; set; }

    }
}