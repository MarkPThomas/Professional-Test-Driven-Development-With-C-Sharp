using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wrox.BooksRead.Web
{
    /// <summary>
    /// Presenter part of the pattern.
    /// </summary>
    public class DisplayBooksReadController
    {
        public IDisplayBooksReadView View { get; set; }

        public DisplayBooksReadController(IDisplayBooksReadView view)
        {
            View = view;
            View.DataRequested += GetData;
        }

        public void GetData(object sender, EventArgs e)
        {
            // Creating a default set of data as 'stubbing'
            View.Data = new List<BookRead> {
                    new BookRead {ReadBookId = 1, Name = "Testing ASP.NET Web Applications", Author = "Jeff McWherter/Ben Hall", ISBN = "978-0470496640", StartDate = new DateTime(2010, 2, 1), EndDate = new DateTime(2010, 2, 12), Rating = 10, PurchaseLink = "http://www.amazon.com/gp/product/0470496649/ref=s9_simh_gw_p14_d3_i1?pf_rd_m=ATVPDKIKX0DER&pf_rd_s=center-2&pf_rd_r=0D96AAEEB8ZQV98XVA03&pf_rd_t=101&pf_rd_p=470938631&pf_rd_i=507846" },
                    new BookRead {ReadBookId = 2, Name = "Test Driven Development: By Example", Author = "Kent Beck", ISBN = "978-0321146533", StartDate = new DateTime(2010, 2, 1), EndDate = new DateTime(2010, 2, 12), Rating = 9, PurchaseLink = "http://www.amazon.com/Test-Driven-Development-Kent-Beck/dp/0321146530/ref=sr_1_1?s=books&ie=UTF8&qid=1295751237&sr=1-1" },
                    new BookRead {ReadBookId = 3, Name = "Test2", Author = "Author3", ISBN = "22222222", StartDate = new DateTime(2010, 3, 1), EndDate = new DateTime(2010, 3, 12), Rating = 3, PurchaseLink = "http://www.msu.edu" }
                };
            View.Bind();
        }
    }
}