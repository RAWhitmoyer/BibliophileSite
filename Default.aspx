<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <article>
        <h2>Welcome to BOOK REPOSITORY</h2>
        <p>Check out some content</p>
    </article>
    <article>
        <h2>What is a bibliophile?</h2>
        <div id="box1" class="box">
            <p class="test">

                <a id="Bibliophile" href="/Webpages/Bibliophile/Bibliophile.aspx">
                    <img src="Images/Bibliophile.jpg" height="250" width="200" alt="">
                </a>
            </p>


        </div>  
    </article>

    <article>
        <h2>Classic Books</h2>
        <div id="box2" class="box">
            <p class="test">

                <a id="ClassicBooks" href="/Webpages/ClassicBooks/ClassicBooks.aspx">
                    <img src="Images/BestBooks.jpg" height="190" width="250" alt="">
                </a>
            </p>


        </div>     
    </article>

    <article>
        <h2>The rise of e-books</h2>
        <div id="box3" class="box">
            <p class="test">

                <a id="Ebooks" href="/Webpages/Ebooks/Ebooks.aspx">
                    <img src="Images/Ebook.jpg" width="250" height="200" alt="">
                </a>
            </p>


        </div>
        
    </article>

</asp:Content>

