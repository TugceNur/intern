using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace uygulama_1
{
    public partial class Anasayfa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dataislemleri yeni = new dataislemleri();
            string sorgu = "select personel.ad,personel.soyad,birim.birimadi from personel inner join birim on personel.birimid = birim.birimid";
            yeni.FillGridViewqueryDev(sorgu, GridView1);
        }
        protected void BtnBul_Click(object sender, EventArgs e)
        {
            personeller yenikullanici = new personeller();
            yenikullanici.ad = txt_ad.Text;
            yenikullanici.soyad = txt_soyad.Text;
            string Bul = @"select personel.ad
                ,personel.soyad
                ,birim.birimadi
                from personel
                inner join birim on personel.birimid=birim.birimid where ad='" + yenikullanici.ad + "' and soyad='" + yenikullanici.soyad + "'";

            dataislemleri yeni = new dataislemleri();
           
            yeni.FillGridViewqueryDev(Bul, GridView1);

            //Bu 3 satır ile aynı bulma işi yapılmaktadır.(a different path for the Find operation)
            //DataSet gelenveriler= yeni.GetDataSetQuery(Bul);
            //GridView1.DataSource = gelenveriler; 
            //GridView1.DataBind();

            Label3.Text = "Kaydınız Bulunmuştur.";
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dataislemleri yeni = new dataislemleri();
            string sorgu = "select personel.ad,personel.soyad,birim.birimadi from personel inner join birim on personel.birimid = birim.birimid";
            yeni.FillGridViewqueryDev(sorgu, GridView1);
        }
    }
}