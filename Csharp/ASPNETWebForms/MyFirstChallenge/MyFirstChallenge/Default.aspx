<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyFirstChallenge.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        How old are you?&nbsp;
        <asp:TextBox ID="ageTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        How much money do you have in your pocket?&nbsp;
        <asp:TextBox ID="moneyTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="okButton" runat="server" OnClick="okButton_Click" Text="Click Me To See Your Fortune" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>    </div>
    </form>
</body>
</html>
