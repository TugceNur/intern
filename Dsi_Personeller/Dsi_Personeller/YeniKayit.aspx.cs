using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dsi_Personeller
{
    public partial class YeniKayit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataislemleri yeni = new dataislemleri();
                yeni.FillDropDownDev2("select birimid,birimadi from birimler", Drop_birim);
                yeni.FillDropDownDev2("select gorevid,gorevadi from gorevler", Drop_gorev);
                Drop_gorev.Enabled = false;

                string sorgu = @"select personeller.personelid,personeller.personelad,personeller.personelsoyad
                    ,      birimler.birimadi
                    ,      gorevler.gorevadi
                    , personeller.mail
                    ,personeller.telefon
                    ,personeller.fotograf
                    from       personeller
                    inner join gorevler    on personeller.gorevid=gorevler.gorevid
                    inner join birimler    on gorevler.birimid=birimler.birimid";
            }
        }
        protected void Drop_birim_SelectedIndexChanged(object sender, EventArgs e)
        {
            Drop_gorev.Enabled = true;
            int birimid = Convert.ToInt32(Drop_birim.SelectedValue);
            dataislemleri db = new dataislemleri();
            db.FillDropDownDev2("select gorevler.gorevid,gorevler.gorevadi from gorevler where birimid='" + birimid + "'", Drop_gorev);
        }
        protected void btn_ekle_Click(object sender, EventArgs e)
        {
            if (txt_Ad.Text=="" & txt_Soyad.Text==""  & txt_Tel.Text=="" & txt_sifre.Text=="")
            {
                lbl_mesaj.Text = "Boş bırakmayınız.";
            }
            else { 
            personeller yeni = new personeller();
            yeni.personelad = txt_Ad.Text;
            yeni.personelsoyad = txt_Soyad.Text.ToUpper();
            yeni.gorevid = Convert.ToInt32(Drop_gorev.SelectedValue);
            yeni.telefon = txt_Tel.Text;
            yeni.mail = txt_Mail.Text;
            yeni.sifre = txt_sifre.Text;

            
            // resim ekleme

            if (FileUpload1.HasFile)
            {
                string uzanti = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();

                if (uzanti == ".jpg" || uzanti == ".gif")
                {
                    // resmin yolu
                    yeni.fotograf = "~/fotograflar/" + FileUpload1.FileName;
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("./fotograflar/") + FileUpload1.FileName);
                    lbl_mesaj.Text = "Kayıt eklendi.";
                    Drop_birim.SelectedValue = null;
                    Drop_gorev.SelectedValue = null;                 
                }
                else
                {
                    lbl_mesaj.Text = "uygun dosya formatı seçiniz";
                    return;
                }
            }
            // resim ekleme sonu
            string sorgu = @"
                        insert into personeller ( personelad, personelsoyad,gorevid, telefon, mail, fotograf,sifre )
                        values                  ( '" + yeni.personelad + "', '" + yeni.personelsoyad + "', '" + yeni.gorevid + "', '" + yeni.telefon + "', '" + yeni.mail + "', '" + yeni.fotograf + "', '" + yeni.sifre + "' )";

            dataislemleri db = new dataislemleri();
            db.ExecuteSPQuery(sorgu);
            txt_Ad.Text = "";
            txt_Soyad.Text = "";
            txt_Mail.Text = "";
            txt_Tel.Text = "";
        }
    }
        protected void btn_geri_Click(object sender, EventArgs e)
        {
            Response.Redirect("KullaniciGirisi.aspx");
           
        }
    }
}