<%@ Page Title="主页" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="~/Default.aspx.cs" Inherits="WebAPITest._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        欢迎使用 ASP.NET!
    </h2>
    <p>
        若要了解关于 ASP.NET 的详细信息，请访问 <a href="http://www.asp.net/cn" title="ASP.NET 网站">www.asp.net/cn</a>。
    </p>
    <p>
        您还可以 <asp:HyperLink ID="authLink" runat="server">马上去注册</asp:HyperLink>。
    </p>
</asp:Content>
