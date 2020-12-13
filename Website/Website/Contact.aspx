<%@ Page Title="Kontakt os" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Website.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Kontakt os her.</h3>
    <address>
        <asp:Label ID="address" runat="server" Text=""></asp:Label>
        <br />
        <abbr title="Phone">Tlf.:</abbr>
        <asp:Label ID="phoneNumber" runat="server" Text=""></asp:Label>
        &nbsp;
    </address>

    <address>
        <strong>Email:</strong>
        <asp:HyperLink ID="mailLink" runat="server">
            <asp:Label ID="mail" runat="server" Text=""></asp:Label>
        </asp:HyperLink><br />
    </address>
</asp:Content>
