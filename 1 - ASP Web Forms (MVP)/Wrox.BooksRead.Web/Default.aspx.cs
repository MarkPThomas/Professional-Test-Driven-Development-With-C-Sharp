using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wrox.BooksRead.Web
{
    public partial class _Default : Page, IDisplayBooksReadView
    {
        private DisplayBooksReadController _controller;

        public List<BookRead> Data { get; set; }

        public event EventHandler DataRequested;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            _controller = new DisplayBooksReadController(this);
            DataRequested(sender, e);
        }

        public void Bind()
        {
            rptBooksRead.DataSource = Data;
            rptBooksRead.DataBind();
        }
    }
}