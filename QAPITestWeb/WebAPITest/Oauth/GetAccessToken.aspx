<%@ Page Title="主页" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="GetAccessToken.aspx.cs" Inherits="WebAPITest.Oauth.GetAccessToken" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <div>
        <p id="info"><asp:Label runat="server" ID="txtMsg"></asp:Label></p>
        <div class="fieldset"></div>
        <p id="userInfo"><asp:Label runat="server" id="txtUserInfo"></asp:Label></p>
    </div>
</asp:Content>
