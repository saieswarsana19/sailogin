<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="sailogin.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbluname" runat="server" Text="username"></asp:Label><br />
            <asp:TextBox ID="txtuname" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblpassword" runat="server" Text="password"></asp:Label><br />
            <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click" Text="submit" /><br />
        </div>
    </form>
</body>
</html>
