using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
            string sorgu = @"select personeller.personelid,personeller.personelad,personeller.personelsoyad
                    ,      birimler.birimadi
                    ,      gorevler.gorevadi
                    , personeller.mail
                    ,personeller.telefon
                    ,personeller.fotograf
                    from       personeller
                    inner join gorevler    on personeller.gorevid=gorevler.gorevid
                    inner join birimler    on gorevler.birimid=birimler.birimid";

            if (!IsPostBack)
            {
                dataislemleri yeni = new dataislemleri();
                yeni.FillGridViewqueryDev(sorgu, GridView1);

                DropDownList birimdropdown = (DropDownList)GridView1.FooterRow.FindControl("Drop_birimi");
                DropDownList gorevdropdown = (DropDownList)GridView1.FooterRow.FindControl("Drop_gorevi");

                yeni.FillDropDownDev2("select birimid,birimadi from birimler", birimdropdown);
                yeni.FillDropDownDev2("select gorevid,gorevadi from gorevler", gorevdropdown);

                gorevdropdown.Enabled = false;

                // sorting için ekledim
                DataSet ds = yeni.GetDataSetQuery(sorgu);

                DataTable dt = ds.Tables[0];
                ViewState["dt"] = dt;
                ViewState["sort"] = "Asc";

                // sorting sonu
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            GridView1.EditIndex = -1;
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

            DropDownList birimdropdown = (DropDownList)GridView1.FooterRow.FindControl("Drop_birimi");
            DropDownList gorevdropdown = (DropDownList)GridView1.FooterRow.FindControl("Drop_gorevi");

            yeni.FillDropDownDev2("select birimid,birimadi from birimler", birimdropdown);
            yeni.FillDropDownDev2("select gorevid,gorevadi from gorevler", gorevdropdown);

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
            if (e.CommandName == "ekle")
            {
                // insert işlemini yapınız 

                TextBox adi = (TextBox)GridView1.FooterRow.FindControl("txt_ad");
                TextBox soyadi = (TextBox)GridView1.FooterRow.FindControl("txt_soyad");
                DropDownList birimi = (DropDownList)GridView1.FooterRow.FindControl("Drop_birimi");
                TextBox maili = (TextBox)GridView1.FooterRow.FindControl("txt_mail");
                TextBox telefonu = (TextBox)GridView1.FooterRow.FindControl("txt_tel");

                string ad = adi.Text;
                string soyad = soyadi.Text;
                int birimid = Convert.ToInt32(birimi.SelectedValue);
                string mail = maili.Text;
                string telefon = telefonu.Text;
                string sorgu = @"
                                insert into personeller ( personelad, personelsoyad,gorevid, telefon, mail )

                                values                  ( '" + ad + "', '" + soyad + "', '" + birimid + "', '" + telefon + "', '" +mail + "')";

                dataislemleri db = new dataislemleri();
                db.ExecuteSPQuery(sorgu);

                dataislemleri yeni2 = new dataislemleri();
                string sorgu2 = @"

                                        select personeller.personelid,personeller.personelad,personeller.personelsoyad
                        ,      birimler.birimadi
                        ,      gorevler.gorevadi
                        
                        ,personeller.telefon
                        ,personeller.mail
                        
                        from       personeller
                        inner join gorevler    on personeller.gorevid=gorevler.gorevid
                        inner join birimler    on gorevler.birimid=birimler.birimid";
               
                yeni2.FillGridViewqueryDev(sorgu2, GridView1);
                adi.Text = "";
                soyadi.Text = "";
                maili.Text = "";
                telefonu.Text = "";

                DropDownList birimdropdown = (DropDownList)GridView1.FooterRow.FindControl("Drop_birimi");
                DropDownList gorevdropdown = (DropDownList)GridView1.FooterRow.FindControl("Drop_gorevi");

                yeni2.FillDropDownDev2("select birimid,birimadi from birimler", birimdropdown);
                yeni2.FillDropDownDev2("select gorevid,gorevadi from gorevler", gorevdropdown);
            }
            //if (e.CommandName == "Edit")
            //{
            //    //button yerini alır.
            //    GridViewRow gvr = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            //    ////satırını gösterir.

            //    //GridView1.EditIndex = gvr.RowIndex;

            //    Label lblbirim = (Label)GridView1.Rows[gvr.RowIndex].FindControl("Label4");

            //    Label lblgorev = (Label)GridView1.Rows[gvr.RowIndex].FindControl("Label8");

            //    string birim = lblbirim.Text;
            //    string gorevi = lblgorev.Text;

            //    string birimidgetir = "select birimid from birimler where birimadi='" + birim + "'";
            //    string gorevidgetir = "select gorevid from gorevler where gorevadi='" + gorevi + "'";

            //    dataislemleri yeni = new dataislemleri();

            //    object birimidsi = yeni.GetScalarQuery(birimidgetir);
            //    object gorevidsi = yeni.GetScalarQuery(gorevidgetir);

            //    Session["brid"] = birimidsi;
            //    Session["grid"] = gorevidsi;
            //}

            if (e.CommandName == "editleme")
            {
                GridViewRow gvr = (GridViewRow)(((Control)e.CommandSource).NamingContainer);


                //

                Label lblbirim = (Label)GridView1.Rows[gvr.RowIndex].FindControl("Label4");

                Label lblgorev = (Label)GridView1.Rows[gvr.RowIndex].FindControl("Label8");

                string birim = lblbirim.Text;
                string gorevi = lblgorev.Text;

                string birimidgetir = "select birimid from birimler where birimadi='" + birim + "'";
                string gorevidgetir = "select gorevid from gorevler where gorevadi='" + gorevi + "'";

                dataislemleri yeni = new dataislemleri();

                object birimidsi = yeni.GetScalarQuery(birimidgetir);
                object gorevidsi = yeni.GetScalarQuery(gorevidgetir);

                Session["brid"] = birimidsi;
                Session["grid"] = gorevidsi;

                //

                GridView1.EditIndex = gvr.RowIndex;

                string sorgu = @"select personeller.personelid,personeller.personelad,personeller.personelsoyad
                    ,      birimler.birimadi
                    ,      gorevler.gorevadi
                    , personeller.mail
                    ,personeller.telefon
                    ,personeller.fotograf
                    from       personeller
                    inner join gorevler    on personeller.gorevid=gorevler.gorevid
                    inner join birimler    on gorevler.birimid=birimler.birimid";


                //dataislemleri yeni = new dataislemleri();
                yeni.FillGridViewqueryDev(sorgu, GridView1);

                DropDownList drpbirim = (DropDownList)GridView1.Rows[gvr.RowIndex].FindControl("DropDownList1");

                DropDownList drpgorevi = (DropDownList)GridView1.Rows[gvr.RowIndex].FindControl("Drop_gorevi_edit");

                string birimid = drpbirim.SelectedValue;
                string gorevid = drpgorevi.SelectedValue;

                yeni.FillDropDownDev2("select birimid,birimadi from birimler", drpbirim);
                yeni.FillDropDownDev2("select gorevid,gorevadi from gorevler", drpgorevi);

                drpbirim.SelectedValue = Session["brid"].ToString();
                drpgorevi.SelectedValue = Session["grid"].ToString();

            }
            if (e.CommandName=="guncelle")
            {
                GridViewRow gvr = (GridViewRow)(((Control)e.CommandSource).NamingContainer);

                Label lblpersonelid = (Label)GridView1.Rows[gvr.RowIndex].FindControl("Label10");

                string personelid = lblpersonelid.Text;

                TextBox txtpersonelad = (TextBox)GridView1.Rows[gvr.RowIndex].FindControl("TextBox2");
                string ad = txtpersonelad.Text;

                TextBox txtpersonelsoyad = (TextBox)GridView1.Rows[gvr.RowIndex].FindControl("TextBox3");
                string soyad = txtpersonelsoyad.Text;

                DropDownList drpbirimi = (DropDownList)GridView1.Rows[gvr.RowIndex].FindControl("DropDownList1");
                int birimid = Convert.ToInt32 (drpbirimi.SelectedValue);

                DropDownList drpgorevi = (DropDownList)GridView1.Rows[gvr.RowIndex].FindControl("Drop_gorevi_edit");
                int gorevid = Convert.ToInt32(drpgorevi.SelectedValue);

                TextBox txtmail = (TextBox)GridView1.Rows[gvr.RowIndex].FindControl("TextBox6");
                string mail = txtmail.Text;

                TextBox txttelefon = (TextBox)GridView1.Rows[gvr.RowIndex].FindControl("TextBox7");
                string telefon = txttelefon.Text;

                dataislemleri yeniupdate = new dataislemleri();
                string updatesorgusu = @"update personeller set personelad='"+ad+"',personelsoyad='"+soyad+ "', gorevid='"+gorevid+"', mail='" + mail+"', telefon='"+telefon+ "' from personeller  where personelid='" + personelid+"'"; 

                yeniupdate.ExecuteSPQuery(updatesorgusu);

                GridView1.EditIndex = -1;

                string sorgu = @"select personeller.personelid,personeller.personelad,personeller.personelsoyad
                    ,      birimler.birimadi
                    ,      gorevler.gorevadi
                    , personeller.mail
                    ,personeller.telefon
                    ,personeller.fotograf
                    from       personeller
                    inner join gorevler    on personeller.gorevid=gorevler.gorevid
                    inner join birimler    on gorevler.birimid=birimler.birimid";


                dataislemleri yeni = new dataislemleri();
                yeni.FillGridViewqueryDev(sorgu, GridView1);

                DropDownList birimdropdown = (DropDownList)GridView1.FooterRow.FindControl("Drop_birimi");
                DropDownList gorevdropdown = (DropDownList)GridView1.FooterRow.FindControl("Drop_gorevi");

                yeni.FillDropDownDev2("select birimid,birimadi from birimler", birimdropdown);
                yeni.FillDropDownDev2("select gorevid,gorevadi from gorevler", gorevdropdown);

            }
            if(e.CommandName=="sil")
            {
                GridViewRow gvr = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
                int personelid = Convert.ToInt32(GridView1.DataKeys[gvr.RowIndex].Value.ToString());

                string silmesorgum = "delete from personeller where personelid='" + personelid + "'";

                dataislemleri yeni = new dataislemleri();
                yeni.ExecuteSPQuery(silmesorgum);

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

                DropDownList birimdropdown = (DropDownList)GridView1.FooterRow.FindControl("Drop_birimi");
                DropDownList gorevdropdown = (DropDownList)GridView1.FooterRow.FindControl("Drop_gorevi");

                yeni.FillDropDownDev2("select birimid,birimadi from birimler", birimdropdown);
                yeni.FillDropDownDev2("select gorevid,gorevadi from gorevler", gorevdropdown);
            }

            if(e.CommandName=="iptal")
            {
                GridView1.EditIndex = -1;

                string sorgu = @"select personeller.personelid,personeller.personelad,personeller.personelsoyad
                    ,      birimler.birimadi
                    ,      gorevler.gorevadi
                    , personeller.mail
                    ,personeller.telefon
                    ,personeller.fotograf
                    from       personeller
                    inner join gorevler    on personeller.gorevid=gorevler.gorevid
                    inner join birimler    on gorevler.birimid=birimler.birimid";


                dataislemleri yeni = new dataislemleri();
                yeni.FillGridViewqueryDev(sorgu, GridView1);

                DropDownList birimdropdown = (DropDownList)GridView1.FooterRow.FindControl("Drop_birimi");
                DropDownList gorevdropdown = (DropDownList)GridView1.FooterRow.FindControl("Drop_gorevi");

                yeni.FillDropDownDev2("select birimid,birimadi from birimler", birimdropdown);
                yeni.FillDropDownDev2("select gorevid,gorevadi from gorevler", gorevdropdown);

            }
        }
        protected void Drop_birimi_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DropDownList drop_B = (DropDownList)GridView1.FooterRow.FindControl("Drop_birimi");
            DropDownList drop_G = (DropDownList)GridView1.FooterRow.FindControl("Drop_gorevi");
            drop_G.Enabled = true;

            int birimid = Convert.ToInt32(drop_B.SelectedValue);
            dataislemleri db = new dataislemleri();
            db.FillDropDownDev2("select gorevler.gorevid,gorevler.gorevadi from gorevler where birimid='" + birimid + "'", drop_G);
        }

        protected void btn_geri_Click(object sender, EventArgs e)
        {
            Response.Redirect("KullaniciGirisi.aspx");
        }

       protected void Button2_vazgec_Click(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dropbirim = (DropDownList)sender;

            int birimid = Convert.ToInt32(dropbirim.SelectedValue);

            // Get the current GridView Row, from which the DropDownList is selected.
            GridViewRow currentRow = (GridViewRow)dropbirim.NamingContainer;

            // Now let's find the City DropDownList on the same GridView Row.
            DropDownList dropgorev = (DropDownList)currentRow.FindControl("Drop_gorevi_edit");

            string sorgumuz = "select gorevid,gorevadi from gorevler where birimid='" + birimid + "'";

            dataislemleri yeni = new dataislemleri();
            yeni.FillDropDownDev2(sorgumuz, dropgorev);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (e.Row.Cells[6].Text == "0251615")
            //    {
            //        e.Row.Cells[6].BackColor = Color.Cyan;
            //    }
             
            //}

            if (e.Row.RowType == DataControlRowType.DataRow) //template oldugunda kullanım.
            {
                Label myLabel = ((Label)e.Row.FindControl("Label7"));

               if(myLabel.Text== "0251615")
                {
                    myLabel.BackColor = Color.Cyan;
                    myLabel.Text = "düşüşte";

                }
            }
        }
    }
}