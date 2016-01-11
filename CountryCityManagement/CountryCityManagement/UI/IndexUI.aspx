<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexUI.aspx.cs" Inherits="CountryCityManagement.UI.IndexUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Index"></asp:Label>
        <br />
        <br />
    <div>
    
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="Large" OnClick="LinkButton1_Click">Country</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton2" runat="server" Font-Size="Large" OnClick="LinkButton2_Click">City</asp:LinkButton>
        <br />
    
    </div>
    </form>
</body>
</html>
