<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reg.aspx.cs" Inherits="RSVPsite.Reg" UnobtrusiveValidationMode="None" %>

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
            <asp:ValidationSummary ID="validationSummary" runat="server" ForeColor="Red" ShowModelStateErrors="true" />
            <label>Your name:</label><asp:TextBox ID ="name" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="name" ErrorMessage="'Name' field can not be blank" ForeColor="#FF3300">
            </asp:RequiredFieldValidator>
        </div>
        <div>
            <label>Your email:</label><asp:TextBox ID="email" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="email" ErrorMessage="'E-mail' field can not be blank" 
                Display="Dynamic" 
                ForeColor="#FF3300">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ControlToValidate="email"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ErrorMessage="E-mail is not in a valid format" Display="Dynamic"
                ForeColor="Red">e-mail adress incorrect!
            </asp:RegularExpressionValidator>
        </div>
        <div>
            <label>Your phone:</label><asp:TextBox ID="phone" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="phone" ErrorMessage="'Phone' field can not be blank" ForeColor="#FF3300">
            </asp:RequiredFieldValidator>
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
