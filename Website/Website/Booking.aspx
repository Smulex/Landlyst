<%@ Page Title="Booking" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="Website.Booking" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2><%: Title %>.</h2>
    </div>
    <div style="display:flex;">
        <div>
            <table class="BookingForm">
                <tr>
                    <td>
                        <asp:RadioButton ID="newGuest" runat="server" Text="Ny gæst" GroupName="userType" Checked="True" onclick="$( '.newUserFields' ).css( 'display', '');" />
                    </td>
                    <td>
                        <asp:RadioButton ID="oldguest" runat="server" Text="Tidligere gæst" GroupName="userType" onclick="$( '.newUserFields' ).css( 'display', 'none'); $( '.newUserFields' ).Attr('required', 'false');" />
                    </td>
                </tr>
                <tr class="newUserFields">
                    <td>
                        <asp:TextBox ID="firstname" runat="server" TabIndex="1" placeholder="Fornavn og mellemnavn" required="true"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="lastname" runat="server" TabIndex="2" placeholder="Efternavn" required="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="mail" runat="server" TabIndex="3" placeholder="E-mail" TextMode="Email" required="true"></asp:TextBox>
                    </td>
                </tr>
                <tr class="newUserFields">
                    <td>
                        <asp:TextBox ID="phoneNumber" runat="server" TabIndex="4" placeholder="Telefon nummer" TextMode="Phone" required="true"></asp:TextBox>
                    </td>

                    <td>
                        <asp:TextBox ID="zipCode" runat="server" TabIndex="5" placeholder="Postnummer" required="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="newUserFields">
                        <asp:TextBox ID="streetAddress" runat="server" TabIndex="6" placeholder="Vejnavn og husnummer" required="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span>Check ind dato</span>
                    </td>
                    <td>
                        <span>Check ud dato</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="checkInDate" runat="server" TabIndex="7" TextMode="Date" required="true"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="checkOutDate" runat="server" TabIndex="8" TextMode="Date" required="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding: 10px 50px 0px 50px;">
                        <asp:Button ID="viewRooms" runat="server" TabIndex="9" Text="Se ledige værelser" Height="35px" OnClick="ViewRooms_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="roomTable">
            <asp:Table ID="rooms" runat="server"></asp:Table>
        </div>
    </div>
</asp:Content>
