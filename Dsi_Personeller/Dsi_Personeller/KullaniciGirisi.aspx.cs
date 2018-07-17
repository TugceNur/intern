using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dsi_Personeller
{
    public partial class KullaniciGirisi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_giris_Click(object sender, EventArgs e)
        {
            if(txt_ad.Text=="" && txt_sifre.Text=="")
            {
                uyari1.Text = "*";
                uyari2.Text = "*";
            }
            else { 
            dataislemleri yenidb = new dataislemleri();

            string sorgu = "SELECT * FROM personeller where personel.ad='" + txt_ad.Text + "' AND sifre='" + txt_sifre.Text + "'";

            if (txt_ad.Text == " ")
            {
                Lbl_mesaj.Text = "kullanıcı adı alanı boş olamaz";
            }
            string sorgum = "select  personelad from personeller where personelad='" + txt_ad.Text + "'  and sifre='" + txt_sifre.Text + "'";
            dataislemleri nesnem = new dataislemleri();
            object kullanicivarmi = nesnem.GetScalarQuery(sorgum);

            DataSet nesnemmm = nesnem.GetDataSetQuery(sorgum);

            if (nesnemmm.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("AnaSayfa.aspx");
            }
            if (kullanicivarmi != null)
            {
                Response.Redirect("AnaSayfa.aspx");
            }
            else
            {
                Lbl_mesaj.Text = "Hatalı giriş yaptınız.";
            }
            }
        }
        protected void btn_kayit_Click(object sender, EventArgs e)
        {

            Response.Redirect("YeniKayit.aspx");
        }
    }
}
