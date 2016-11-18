<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Wrox.BooksRead.Web._Default" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <asp:Repeater ID="rptBooksRead" runat="server">
        <ItemTemplate>
            <div class="readBook">
                <div class="bookInfo">
                    <h2><%# Wrox.BooksRead.Web.Helpers.HTMLHelper.Truncate(((Wrox.BooksRead.Web.BookRead)Container.DataItem).Name, 25) %></h2> 
                    <p><%# ((Wrox.BooksRead.Web.BookRead)Container.DataItem).Author %></p>
                    <p>ISBN: <%# ((Wrox.BooksRead.Web.BookRead)Container.DataItem).ISBN %></p>
                    <p>Date Finished: <%# ((Wrox.BooksRead.Web.BookRead)Container.DataItem).EndDate.ToString("MM/dd/yyyy")%></p>
                    <a href='<%# ((Wrox.BooksRead.Web.BookRead)Container.DataItem).PurchaseLink %>' target="_blank">Purchase</a>
                </div>
            
                <div class="ratingContainer">
                    <span class="rating"><%# ((Wrox.BooksRead.Web.BookRead)Container.DataItem).Rating %></span>
                </div>

                <div style="clear:both;" />
                <hr />
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>