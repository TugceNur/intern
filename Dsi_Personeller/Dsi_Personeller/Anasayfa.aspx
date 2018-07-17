<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Anasayfa.aspx.cs" Inherits ="Dsi_Personeller.Anasayfa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 985px;
            height: 480px;
        }
        .auto-style2 {
        }
                       
        .auto-style17 {
            text-align: justify;
        }
       
        .hizala
        {

            text-align:center;
        }
        .sag
        {

            text-align:right;
        }
         .sol
        {

            text-align:left;
        }
        </style>

    <script type="text/javascript">
        function sor() {

            return confirm('Personel silinecektir emin misin ?');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style17 hizala" colspan="2" >
                        <asp:Label ID="lbl_dsi"  runat="server" BorderStyle="Outset" Text="DSI 14. Bölge Müdürlüğü" Width="326px" Font-Size="X-Large" Font-Overline="False" style="z-index: 1"></asp:Label>
                        <br />
                    </td>
                   
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Label ID="lbl_mesaj" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#336666"></asp:Label>
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" DataKeyNames="personelid" GridLines="Horizontal" Height="168px" Width="936px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="4" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" OnRowCommand="GridView1_RowCommand" OnSorting="GridView1_Sorting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True">
                            <Columns>
                                <asp:TemplateField HeaderText="Personel IDsi" SortExpression="personelid">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("personelid") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lbl_personelid" runat="server"></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("personelid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Personelin Adı" SortExpression="personelad">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("personelad") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_ad" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("personelad") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Personelin Soyadı" SortExpression="personelsoyad">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("personelsoyad") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_soyad" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("personelsoyad") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" Birimi " SortExpression="birimadi">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList ID="Drop_birimi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Drop_birimi_SelectedIndexChanged1">
                                        </asp:DropDownList>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("birimadi") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Görevi">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="Drop_gorevi_edit" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList ID="Drop_gorevi" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("gorevadi") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mail">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("mail") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_mail" runat="server" TextMode="Email"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("mail") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Telefon">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("telefon") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_tel" runat="server" TextMode="Number"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("telefon") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ImageField DataImageUrlField="fotograf" HeaderText="Resmi" Visible="False">
                                    <ItemStyle Height="20px" HorizontalAlign="Left" Width="20px" Wrap="True" />
                                </asp:ImageField>
                                <asp:TemplateField HeaderText="fotografi ---" Visible="False">
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:Button ID="Button1_guncel" runat="server" Text="Guncelle" />
                                        <asp:Button ID="Button2_vazgec" runat="server" CommandName="vazgec" Text="Vazgeç" />
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:Button ID="btn_add" runat="server" Text="EKLE" CommandName="ekle"/>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Button ID="btn_duzenle" runat="server" Text="Düzenle" CommandName="duzenle" />
                                        <asp:Button ID="btn_sil" runat="server" Text="Sil" CommandName="sil" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#333333" />
                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                            <PagerSettings FirstPageText="İlk Sayfa" LastPageText="Son Sayfa" NextPageText="&gt;&gt;" PreviousPageText="&lt;&lt;" />
                            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="White" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#487575" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#275353" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
