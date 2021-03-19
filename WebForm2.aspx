<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="HomeWorkWeek2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        編號：<asp:TextBox ID="ID" runat="server"></asp:TextBox><br />
        日期：<asp:TextBox ID="cashDate" runat="server"></asp:TextBox><br />
        科目：<asp:TextBox ID="account" runat="server"></asp:TextBox><br />
        摘要：<asp:TextBox ID="summary" runat="server"></asp:TextBox><br />
        收入：<asp:TextBox ID="receive" runat="server"></asp:TextBox><br />
        支出：<asp:TextBox ID="pay" runat="server"></asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" Text="新增" OnClick="Button1_Click" />&nbsp
        <asp:Button ID="Button2" runat="server" Text="修改" OnClick="Button2_Click" />&nbsp
        <asp:Button ID="Button4" runat="server" Text="查詢" OnClick="Button4_Click" /><br />
        <asp:GridView ID="ListC_Jnal" runat="server"  AutoGenerateColumns="False" DataKeyNames="ID" OnRowDeleting="ListC_Jnal_RowDeleting">
            <Columns>  
                <asp:TemplateField HeaderText="ID"> 
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CashDate"  HeaderText="CashDate" DataFormatString="{0:d}" />
                <asp:BoundField DataField="Account" HeaderText="Account" />
                <asp:BoundField DataField="Summary" HeaderText="Summary" />
                <asp:BoundField DataField="Revenue" HeaderText="Revenue" DataFormatString="{0:c0}" nulldisplaytext="Null"/>
                <asp:BoundField DataField="Expence" HeaderText="Expence" DataFormatString="{0:c0}" nulldisplaytext="Null"/>
                <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
