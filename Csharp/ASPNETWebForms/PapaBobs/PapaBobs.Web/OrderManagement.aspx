<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderManagement.aspx.cs" Inherits="PapaBobs.Web.OrderManagement" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
    <h1>Order Management</h1>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:ButtonField Text="Complete" />
        </Columns>
    </asp:GridView>
    </div>
    </form>
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
