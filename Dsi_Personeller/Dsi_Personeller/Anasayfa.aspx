<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Anasayfa.aspx.cs" Inherits ="Dsi_Personeller.Anasayfa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 918px;
            height: 593px;
        }
        .auto-style2 {
        }
        .auto-style4 {
            height: 38px;
        }
        .auto-style6 {
            height: 36px;
        }
               
        .auto-style8 {
            height: 26px;
        }
        .auto-style10 {
            width: 120px;
        }
        .auto-style11 {
            height: 26px;
            width: 120px;
        }
        .auto-style12 {
            height: 38px;
            width: 120px;
        }
        .auto-style14 {
            height: 28px;
            width: 120px;
        }
        .auto-style16 {
            height: 28px;
        }
       
        .auto-style17 {
            text-align: justify;
        }
       
        .hizala
        {

            text-align:center;
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
                    </td>
                   
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="Label1" runat="server" Text="Ad:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Ad" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Ad" ErrorMessage="***"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="Label2" runat="server" Text="Soyad:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Soyad" runat="server" TabIndex="1"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="Label3" runat="server" Text="Birim:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="Drop_birim" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Drop_birim_SelectedIndexChanged" TabIndex="2">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label4" runat="server" Text="Görev:"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:DropDownList ID="Drop_gorev" runat="server" AutoPostBack="True" TabIndex="3">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="Label5" runat="server" Text="Telefon:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Tel" runat="server" TabIndex="4"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="Label6" runat="server" Text="Mail:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Mail" runat="server" TabIndex="5"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_Mail" ErrorMessage="mail formatında giriş yapınız" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        <asp:Label ID="Label7" runat="server" Text="Fotoğraf:"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:FileUpload ID="FileUpload1" runat="server" TabIndex="6" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        </td>
                    <td class="auto-style16">
                        <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_ekle" runat="server" OnClick="btn_ekle_Click" Text="EKLE" CssClass="auto-style6" Font-Bold="True" TabIndex="7" />
                        &nbsp;
                        <asp:Button ID="btn_ara" runat="server" Text="ARA" OnClick="btn_ara_Click" CssClass="auto-style6" Font-Bold="True" TabIndex="8" />
                        &nbsp;
                        <asp:Button ID="btn_guncelle" runat="server" Text="GÜNCELLE" CssClass="auto-style6" Font-Bold="True" TabIndex="9" OnClick="btn_guncelle_Click" />
                    &nbsp;&nbsp;
                        <asp:Button ID="btn_temzle" runat="server" Text="TEMİZLE" CssClass="auto-style6" Font-Bold="True" TabIndex="10" OnClick="btn_temzle_Click1" />
                    </td>
                   
                </tr>
                <tr>
                    <td class="auto-style2" colspan="3">
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" DataKeyNames="personelid" GridLines="Horizontal" Height="168px" Width="904px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="4" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" OnRowCommand="GridView1_RowCommand" OnSorting="GridView1_Sorting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True">
                            <Columns>
                                <asp:TemplateField HeaderText="Güncelle">
                                    <FooterTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Button ID="btnguncelle" runat="server" CommandName="guncelle" Text="Düzenle" Width="100px" CausesValidation="False" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sil">
                                    <ItemTemplate>
                                        <asp:Button ID="btnsil" runat="server" CausesValidation="False" CommandName="sil" Text="Sil"  Width="100px"   OnClientClick="sor()"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Seç">
                                    <ItemTemplate>
                                        <asp:Button ID="btnsec" runat="server" CausesValidation="False" CommandName="sec" Text="Seç" Width="100px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="personelid" HeaderText="Personel IDsi" SortExpression="personelid" />
                                <asp:BoundField DataField="personelad" HeaderText="Personelin Adı" SortExpression="personelad" />
                                <asp:BoundField DataField="personelsoyad" HeaderText="Personelin Soyadı" SortExpression="personelsoyad" />
                                <asp:BoundField DataField="birimadi" HeaderText=" Birimi " SortExpression="birimadi" />
                                <asp:BoundField DataField="gorevadi" HeaderText="Görevi" />
                                <asp:BoundField DataField="mail" HeaderText="Mail" />
                                <asp:BoundField DataField="telefon" HeaderText="Telefon" />
                                <asp:ImageField DataImageUrlField="fotograf" HeaderText="Resmi" Visible="False">
                                    <ItemStyle Height="20px" HorizontalAlign="Left" Width="20px" Wrap="True" />
                                </asp:ImageField>
                                <asp:TemplateField HeaderText="fotografi ---" Visible="False">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("fotograf") %>' />
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
