<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HomeWorkWeek2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        發票號碼：<asp:TextBox ID="txtinNum"  runat="server"></asp:TextBox><br />
        日期時間：<asp:TextBox ID="txtinDate" runat="server"></asp:TextBox><br />
        發票金額：<asp:TextBox ID="txtinAmt"  runat="server"></asp:TextBox><br />
        收入支出：<asp:DropDownList ID="drpE_R" runat="server">
            <asp:ListItem Value="Revenue" Text="收入"></asp:ListItem>
            <asp:ListItem Value="Expense" Text="支出"></asp:ListItem>
        </asp:DropDownList><br />
        <asp:Button ID="Button1" runat="server" Text="新增" OnClick="Button1_Click" />&nbsp
        <asp:Button ID="Button2" runat="server" Text="刪除" OnClick="Button2_Click" />&nbsp
        <asp:Button ID="Button3" runat="server" Text="修改" OnClick="Button3_Click" />&nbsp
        <asp:Button ID="Button4" runat="server" Text="查詢" OnClick="Button4_Click" /><br />
        <asp:GridView ID="ListB_Tax" runat="server"  AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="invoiceNumber" HeaderText="invoiceNumber"/>
                <asp:BoundField DataField="invoiceDate"  HeaderText="invoiceDate" DataFormatString="{0:d}" />
                <asp:BoundField DataField="invoiceAmount" HeaderText="invoiceAmount" DataFormatString="{0:c0}"/>
                <asp:BoundField DataField="Reven_Expen" HeaderText="Reven_Expen"/>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
