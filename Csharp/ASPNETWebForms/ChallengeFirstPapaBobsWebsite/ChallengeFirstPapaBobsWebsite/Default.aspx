<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeFirstPapaBobsWebsite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 200px;
            height: 200px;
        }
        .auto-style2 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style3 {
            color: #FF3300;
        }
    </style>
</head>
<body>
    <h1>
        <img alt="" class="auto-style1" src="PapaBob.png" /><span class="auto-style2">Papa Bob&#39;s Pizza and Software</span></h1>
    <form id="form1" runat="server">
        <p>
            <asp:RadioButton ID="smallRadioButton" runat="server" GroupName="SizeGroup" Text="Baby Bob Size (10&quot;) - $10" />
            <br />
            <asp:RadioButton ID="mediumRadioButton" runat="server" GroupName="SizeGroup" Text="Mama Bob Size (13&quot;) - $13" />
            <br />
            <asp:RadioButton ID="largeRadioButton" runat="server" GroupName="SizeGroup" Text="Papa Bob Size (16&quot;) - $16" />
            <br />
        </p>
        <p>
            <asp:RadioButton ID="thinRadioButton" runat="server" GroupName="CrustGroup" Text="Thin Crust" />
            <br />
            <asp:RadioButton ID="deepRadioButton" runat="server" GroupName="CrustGroup" Text="Deep Dish (+$2)" />
        </p>
        <p>
            <asp:CheckBox ID="pepperoniCheckBox" runat="server" Text="Pepperoni (+$1.50)" />
            <br />
            <asp:CheckBox ID="onionCheckBox" runat="server" Text="Onions (+$0.75)" />
            <br />
            <asp:CheckBox ID="greenPepperCheckBox" runat="server" Text="Green Peppers (+$0.50)" />
            <br />
            <asp:CheckBox ID="redPepperCheckBox" runat="server" Text="Red Peppers (+$0.75)" />
            <br />
            <asp:CheckBox ID="anchoviesCheckBox" runat="server" Text="Anchovies (+ $2)" />
        </p>
        <h3 class="auto-style2">Papa Bob&#39;s <span class="auto-style3">Special Deal</span></h3>
        <p>
            Save $2.00 when you add Pepperoni, Green Peppers and Anchovices OR Pepperoni, Red Peppers and Onions to your pizza.</p>
        <p>
            <asp:Button ID="purchaseButton" runat="server" OnClick="purchaseButton_Click" Text="Purchase" />
        </p>
        <p>
            Total:&nbsp; <asp:Label ID="totalLabel" runat="server" Text="$0.00"></asp:Label>
        </p>
        <p>
            Sorry, at this time you can only order one pizza online, and pick-up only ... we need a better website!</p>
        <p>
            &nbsp;</p>
        <p>
            <br />
        </p>
        <p>
            &nbsp;</p>
    <div>
    
    </div>
    </form>
</body>
</html>
