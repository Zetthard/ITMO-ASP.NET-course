<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reg.aspx.cs" Inherits="RSVPsite.Reg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="RSVPstyleSheet.css" />
</head>
<body>
    <form id="RegForm" runat="server">
        <div>
            <h1>You are invited to seminar</h1>
            <p></p>
        </div>
        <div>
            <label>Your name:</label><asp:TextBox ID ="name" runat="server"></asp:TextBox>
        </div>
        <div>
            <label>Your email:</label><asp:TextBox ID="email" runat="server"></asp:TextBox>
        </div>
        <div>
            <label>Your phone:</label><asp:TextBox ID="phone" runat="server"></asp:TextBox>
        </div>
        <div>
            <label>Are you planning to present?</label><asp:CheckBox ID="PresentYN" runat="server" />
        </div>
        <div>
            <button type="submit">Send RSVP response</button>
        </div>
    </form>
</body>
</html>
