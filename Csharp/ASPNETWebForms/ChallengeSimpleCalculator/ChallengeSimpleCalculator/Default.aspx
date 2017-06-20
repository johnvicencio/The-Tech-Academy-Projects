<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeSimpleCalculator.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <h1>Simple Calculator</h1>
        <span class="auto-style1">First Value:</span>
        <asp:TextBox ID="firstTextBox" runat="server"></asp:TextBox>
        <br />
        <span class="auto-style1">Second Value:</span>
        <asp:TextBox ID="secondTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="plusButton" runat="server" OnClick="plusButton_Click" Text="+" />
&nbsp;<asp:Button ID="subtractButton" runat="server" OnClick="subtractButton_Click" Text="-" />
&nbsp;<asp:Button ID="multiplyButton" runat="server" OnClick="multiplyButton_Click" Text="*" />
&nbsp;<asp:Button ID="divideButton" runat="server" OnClick="divideButton_Click" Text="/" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server" BackColor="#99CCFF" Font-Bold="True" Font-Size="Larger"></asp:Label>
    
    </div>
    </form>
</body>
</html>
