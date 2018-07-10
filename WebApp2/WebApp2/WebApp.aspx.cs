using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp2
{
    public partial class WebApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList2.Enabled = false;
            if (!IsPostBack)
            {              
                dataislemleri yeni = new dataislemleri();
                yeni.FillDropDownDev2("select birimid,birimadi from birimler ", DropDownList1);
                yeni.FillDropDownDev2("select gorevid,gorevadi from gorev ", DropDownList2);
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Enabled = true;
            int id = Convert.ToInt32(DropDownList1.SelectedValue);
            dataislemleri yeni = new dataislemleri();
            yeni.FillDropDownDev2("select gorevid,gorevadi from gorev where gorevid='"+id+"'",DropDownList2);
        }
    }
}