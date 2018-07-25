<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YeniKayit.aspx.cs" Inherits="Dsi_Personeller.YeniKayit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .hizala{
            align-content:center;
            text-align:center;
        }
        .sekil {
           background-color: aliceblue;
           color:black; 
        }
       
        .auto-style3 {
            width: 506px;
            height: 637px;
        }
    </style>
</head>
<body class="sekil">
    <center> <form id="form1" runat="server">
        <div>
            <table class="auto-style3" aria-autocomplete="none" border="0" >
                <tr>
                    <td class="auto-style17 hizala" colspan="2" >
                        <asp:Label ID="lbl_uyeol"  runat="server" BorderStyle="Outset" Text="Üye Ol Paneli" Width="326px" Font-Size="X-Large" Font-Overline="False" style="z-index: 1"></asp:Label>
                    </td>
                   
                </tr>
                <tr>
                    <td class="auto-style1" colspan="2">
                        </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="Label1" runat="server" Text="Ad:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Ad" runat="server"></asp:TextBox>
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
                    <td class="auto-style11">
                        <asp:Label ID="Label8" runat="server" Text="Şifre:"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txt_sifre" runat="server" TextMode="Password" TabIndex="4"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="Label5" runat="server" Text="Telefon:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Tel" runat="server" TabIndex="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="Label6" runat="server" Text="Mail:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Mail" runat="server" TabIndex="6"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_Mail" ErrorMessage="mail formatında giriş yapınız" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        <asp:Label ID="Label7" runat="server" Text="Fotoğraf:"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:FileUpload ID="FileUpload1" runat="server" TabIndex="7" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        &nbsp;</td>
                    <td class="auto-style4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        </td>
                    <td class="auto-style16">
                        <asp:Label ID="lbl_mesaj" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;
                        </td>
                   
                </tr>
               
                <tr>
                    <td class="auto-style14">
                        &nbsp;</td>
                    <td class="auto-style16">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_geri" runat="server" OnClick="btn_geri_Click" Text="Geri" TabIndex="8" />
                        &nbsp;
                        <asp:Button ID="btn_ekle" runat="server" OnClick="btn_ekle_Click" Text="EKLE" CssClass="auto-style6" Font-Bold="True" TabIndex="9" />
                    </td>
                   
                </tr>
               
            </table>
        </div>
    </form></center>
</body>
</html>
