<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Anasayfa.aspx.cs" Inherits ="Dsi_Personeller.Anasayfa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 502px;
            height: 361px;
        }
        .auto-style2 {
        }
        .auto-style3 {
            width: 134px;
        }
        .auto-style4 {
            height: 38px;
        }
        .auto-style5 {
            width: 134px;
            height: 38px;
        }
        .auto-style6 {
            height: 36px;
        }
        .auto-style7 {
            width: 134px;
            height: 36px;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2" colspan="2">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Text="Ad:"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txt_Ad" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="Soyad:"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txt_Soyad" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Text="Birim:"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="Drop_birim" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Drop_birim_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label4" runat="server" Text="Görev:"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="Drop_gorev" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label5" runat="server" Text="Telefon:"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txt_Tel" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label6" runat="server" Text="Mail:"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txt_Mail" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label7" runat="server" Text="Fotoğraf:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                    <td class="auto-style4"></td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td class="auto-style5">
                        <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:Button ID="btn_ekle" runat="server" BorderStyle="Groove" OnClick="btn_ekle_Click" Text="EKLE" />
                        <asp:Button ID="btn_ara" runat="server" BorderStyle="Groove" Text="ARA" />
                        <asp:Button ID="btn_guncelle" runat="server" BorderStyle="Groove" Text="GÜNCELLE" />
                    </td>
                    <td class="auto-style7">
                        <asp:Button ID="btn_sil" runat="server" BorderStyle="Groove" Text="SİL" OnClick="btn_sil_Click" />
                    </td>
                    <td class="auto-style6">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="3">
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" DataKeyNames="personelid" ForeColor="#333333" GridLines="None" Height="168px" Width="700px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="2">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="personelid" HeaderText="Personel IDsi" />
                                <asp:BoundField DataField="personelad" HeaderText="Personelin Adı" />
                                <asp:BoundField DataField="personelsoyad" />
                                <asp:BoundField DataField="birimadi" />
                                <asp:BoundField DataField="gorevadi" />
                                <asp:BoundField DataField="mail" />
                                <asp:BoundField DataField="telefon" />
                                <asp:ImageField DataImageUrlField="fotograf">
                                    <ItemStyle Height="20px" HorizontalAlign="Left" Width="20px" Wrap="True" />
                                </asp:ImageField>
                                <asp:TemplateField HeaderText="fotografi ---" Visible="False">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("fotograf") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
