using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dsi_Personeller
{
    public partial class Anasayfa : System.Web.UI.Page
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



                yeni.FillGridViewqueryDev(sorgu, GridView1);


                // sorting için ekledim
                DataSet ds = yeni.GetDataSetQuery(sorgu);

                DataTable dt = ds.Tables[0];
                ViewState["dt"] = dt;
                ViewState["sort"] = "Asc";


                // sorting sonu

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


            personeller yeni = new personeller();
            yeni.personelad = txt_Ad.Text;
            yeni.personelsoyad = txt_Soyad.Text.ToUpper();
            //yeni.birimid = Convert.ToInt32(Drop_birim.SelectedValue);
            yeni.gorevid = Convert.ToInt32(Drop_gorev.SelectedValue);
            yeni.telefon = txt_Tel.Text;
            yeni.mail = txt_Mail.Text;

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
                        insert into personeller ( personelad, personelsoyad,gorevid, telefon, mail, fotograf )

                        values                  ( '" + yeni.personelad + "', '" + yeni.personelsoyad + "', '" + yeni.gorevid + "', '" + yeni.telefon + "', '" + yeni.mail + "', '" + yeni.fotograf + "' )";

            dataislemleri db = new dataislemleri();
            db.ExecuteSPQuery(sorgu);



            dataislemleri yeni2 = new dataislemleri();
            string sorgu2 = @"

                                select personeller.personelid,personeller.personelad,personeller.personelsoyad
                ,      birimler.birimadi
                ,      gorevler.gorevadi
                , personeller.mail
                ,personeller.telefon
                ,personeller.fotograf
                from       personeller
                inner join gorevler    on personeller.gorevid=gorevler.gorevid
                inner join birimler    on gorevler.birimid=birimler.birimid
";
            textleritemizle();

            yeni2.FillGridViewqueryDev(sorgu2, GridView1);

        }

        protected void btn_sil_Click(object sender, EventArgs e)
        {
            string sorgum = "delete from personeller where personel ??";

            dataislemleri yeni = new dataislemleri();
            yeni.ExecuteSPQuery(sorgum);

            string sorgum2 = "select * from personeller order by personelid desc ";

            yeni.FillGridViewqueryDev(sorgum2, GridView1);
        }
        public void textleritemizle()
        {
            txt_Ad.Text = "";
            txt_Soyad.Text = "";
            txt_Tel.Text = "";
            txt_Mail.Text = "";
            Drop_birim.SelectedValue = null;
            Drop_gorev.SelectedValue = null;
            Drop_gorev.Enabled = false;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            dataislemleri yeni = new dataislemleri();
            string sorgu = @"select personeller.personelid,personeller.personelad,personeller.personelsoyad
                    ,      birimler.birimadi
                    ,      gorevler.gorevadi
                    , personeller.mail
                    ,personeller.telefon
                    ,personeller.fotograf
                    from       personeller
                    inner join gorevler    on personeller.gorevid=gorevler.gorevid
                    inner join birimler    on gorevler.birimid=birimler.birimid";



            yeni.FillGridViewqueryDev(sorgu, GridView1);
        }

        protected void btn_ara_Click(object sender, EventArgs e)
        {


            //DateTime dogumtarih = Calendar1.SelectedDate;


            //if(CheckBox1.Checked)
            //{

            //    string dil1 = CheckBox1.Text;
            //}

            //if(CheckBox1.Checked)

            //{
            //}
            dataislemleri db = new dataislemleri();
            string personel_adi = txt_Ad.Text;
            string sorgu_arama = @"
                                    select personeller.personelid,personeller.personelad,personeller.personelsoyad
                                                        ,      birimler.birimadi
                                                        ,      gorevler.gorevadi
                                                        , personeller.mail
                                                        ,personeller.telefon
                                                        ,personeller.fotograf
                                                        from       personeller
                                                        inner join gorevler    on personeller.gorevid=gorevler.gorevid
                                                        inner join birimler    on gorevler.birimid=birimler.birimid
					                                    where personeller.personelad='" + personel_adi + "' ";
            db.FillGridViewqueryDev(sorgu_arama, GridView1);

            //1.yontem

            DataSet ds = db.GetDataSetQuery(sorgu_arama);
            lbl_mesaj.Text = ds.Tables[0].Rows.Count.ToString() + " tane personel bulunmuştur";

        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt1 = (DataTable)ViewState["dt"];

            if (dt1.Rows.Count > 0)

            {

                if (Convert.ToString(ViewState["sort"]) == "Asc")

                {

                    dt1.DefaultView.Sort = e.SortExpression + " Desc";

                    ViewState["sort"] = "Desc";

                }

                else

                {

                    dt1.DefaultView.Sort = e.SortExpression + " Asc";

                    ViewState["sort"] = "Asc";

                }

                GridView1.DataSource = dt1;

                GridView1.DataBind();
            }



        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            dataislemleri yeni2 = new dataislemleri();



            if (e.CommandName == "guncelle")
            {

                GridViewRow gvr = (GridViewRow)(((Control)e.CommandSource).NamingContainer);

                GridView1.SelectedIndex = gvr.RowIndex; //satır seçiyor

                int personelid = Convert.ToInt32(GridView1.SelectedRow.Cells[3].Text);
                string ad = GridView1.SelectedRow.Cells[4].Text;
                string soyad = GridView1.SelectedRow.Cells[5].Text;

                string birim = GridView1.SelectedRow.Cells[6].Text;  // birim adını yakaladım

                string gorevi = GridView1.SelectedRow.Cells[7].Text;


                // birim adından birimid yi bulacağız

                string sorgumbirimidgetir = "select birimid from birimler where birimadi='" + birim + "' ";
                object birimidsi = yeni2.GetScalarQuery(sorgumbirimidgetir);
                int birimid = Convert.ToInt32(birimidsi);  
                Drop_birim.SelectedValue = birimid.ToString();



                string gorevidgetir = "select * from gorevler where gorevadi='" + gorevi + "' ";
                object gorevidisi = yeni2.GetScalarQuery(gorevidgetir);
                int gorevid = Convert.ToInt32(gorevidisi);
                Drop_gorev.SelectedValue = gorevid.ToString();




                string mail = GridView1.SelectedRow.Cells[8].Text;
                string telefon = (GridView1.SelectedRow.Cells[9].Text);

                txt_Ad.Text = ad;
                txt_Soyad.Text = soyad;
                txt_Mail.Text = mail;
                txt_Tel.Text = telefon;



            }


            if (e.CommandName == "sec")
            {
                GridViewRow gvr = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
                GridView1.SelectedIndex = gvr.RowIndex;
                Page.MaintainScrollPositionOnPostBack = true;
            }





            if (e.CommandName == "sil")
            {


                GridViewRow gvr = (GridViewRow)(((Control)e.CommandSource).NamingContainer);

                GridView1.SelectedIndex = gvr.RowIndex; //satır seçiyor

                int personelid = Convert.ToInt32(GridView1.SelectedRow.Cells[3].Text);

                string silmesorgum = "delete from personel where personelid='" + personelid + "'";

                dataislemleri yeni = new dataislemleri();

                yeni.ExecuteSPQuery(silmesorgum);



                // gridi doldur

                string sorgu = @"select personeller.personelid,personeller.personelad,personeller.personelsoyad
                    ,      birimler.birimadi
                    ,      gorevler.gorevadi
                    , personeller.mail
                    ,personeller.telefon
                    ,personeller.fotograf
                    from       personeller
                    inner join gorevler    on personeller.gorevid=gorevler.gorevid
                    inner join birimler    on gorevler.birimid=birimler.birimid";



                yeni.FillGridViewqueryDev(sorgu, GridView1);

                // grid doldur sonu

            }
        }


        protected void btn_temzle_Click1(object sender, EventArgs e)
        {
            textleritemizle();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataislemleri yeni = new dataislemleri();
            string sorgu =@"select personeller.personelid,personeller.personelad,personeller.personelsoyad
                                                        , birimler.birimadi
                                                        ,      gorevler.gorevadi
                                                        , personeller.mail
                                                        ,personeller.telefon
                                                        ,personeller.fotograf from personeller inner join birimler on personeller.birimid=birimler.birimid";
            yeni.FillGridViewqueryDev(sorgu, GridView1);
        }

        protected void btn_guncelle_Click(object sender, EventArgs e)
        {
            personeller yeni = new personeller();
            yeni.personelad = txt_Ad.Text;
            yeni.personelsoyad = txt_Soyad.Text.ToUpper();
            yeni.birimid = Convert.ToInt32(Drop_birim.SelectedValue);
            yeni.gorevid = Convert.ToInt32(Drop_gorev.SelectedValue);
            yeni.telefon = txt_Tel.Text;
            yeni.mail = txt_Mail.Text;

            int personelid = Convert.ToInt32(GridView1.SelectedRow.Cells[3].Text);

            yeni.personelid = personelid;

            string guncellesorgusu = "update personeller set personelad='" + yeni.personelad + "' ,personelsoyad='" + yeni.personelsoyad + "', gorevid='" + yeni.gorevid + "',telefon='" + yeni.telefon + "',mail='" + yeni.mail + "',fotograf='" + yeni.fotograf + "' where personelid='"+yeni.personelid+"' ";

             
           
            dataislemleri db = new dataislemleri();
           
            db.ExecuteSPQuery(guncellesorgusu);


            string sorgu = @"select personeller.personelid,personeller.personelad,personeller.personelsoyad
                    ,      birimler.birimadi
                    ,      gorevler.gorevadi
                    , personeller.mail
                    ,personeller.telefon
                    ,personeller.fotograf
                    from       personeller
                    inner join gorevler    on personeller.gorevid=gorevler.gorevid
                    inner join birimler    on gorevler.birimid=birimler.birimid";



            db.FillGridViewqueryDev(sorgu, GridView1);
        }
    }
}