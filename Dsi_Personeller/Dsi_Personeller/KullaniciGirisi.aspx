<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KullaniciGirisi.aspx.cs" Inherits="Dsi_Personeller.KullaniciGirisi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .hizala{
            vertical-align:top;
            ruby-align:center;
        }
         .sekil {
           background-color: aliceblue;
           color:black; 
        }
        .auto-style5 {
            width: 391px;
            height: 218px;
           
        }
        .auto-style6 {
            width: 427px;
            height: 350px;
        }
    </style>
   
</head>
<body class="sekil">
    <p>
        <br />
    </p>
     <p>
        <br />
    </p>
    <center>
    <form id="form1" runat="server" class="auto-style6">
        <div>
            <table style="caption-side: top;" class="auto-style5" >
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Kullanıcı Adı:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_ad" runat="server"></asp:TextBox>
                        <asp:Label ID="uyari2" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_sifre" runat="server" Text="Şifre:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_sifre" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:Label ID="uyari1" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btn_giris" runat="server" Text="Giriş" OnClick="btn_giris_Click"  />
                    &nbsp;
                        <asp:Button ID="btn_kayit" runat="server" OnClick="btn_kayit_Click" Text="Yeni Kayıt" />
&nbsp;
                    </td>
                    <td>
                        <asp:Label ID="Lbl_mesaj" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</center>
</body>
</html>
