using System;
using System.Collections.Generic;

namespace Wrox.BooksRead.Web
{
    public interface IDisplayBooksReadView
    {
        event EventHandler DataRequested;
        List<BookRead> Data { get; set; }
        void Bind();
    }
}
