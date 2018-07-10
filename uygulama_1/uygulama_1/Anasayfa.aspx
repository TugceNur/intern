<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Anasayfa.aspx.cs" Inherits="uygulama_1.Anasayfa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 435px;
            height: 447px;
        }
        .auto-style6 {
        }
        .auto-style7 {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="Label1" runat="server" Text="Ad:"></asp:Label>
                        <br />
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="txt_ad" runat="server"></asp:TextBox>
                        <br />
                    </td>
                    <td class="auto-style7">
                        <asp:Label ID="Label2" runat="server" Text="Soyad:"></asp:Label>
                        <br />
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txt_soyad" runat="server"></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6" colspan="2">
                        <asp:Button ID="BtnBul" runat="server" BorderStyle="Double" Height="39px" OnClick="BtnBul_Click" Text="Bul" Width="80px" />
                    </td>
                    <td class="auto-style7" colspan="2">
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6" colspan="4">
                        <asp:GridView ID="GridView1" runat="server" Height="201px" Width="383px" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
