using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace eBooks2goV5.ebookapps
{
    public partial class textbookscart : System.Web.UI.Page
    {
        #region get request
        protected void Page_Load(object sender, EventArgs e)
        {
            Bindcartvalues();
        }
        #endregion

        #region Bindvalues to cart
        private void Bindcartvalues()
        {
            DataTable dtfiles;
            //if (Request.QueryString["ID"] == "3")
            dtfiles = (DataTable)Session["dttextbookfiles"];

            lbltextbookstitle.Text = dtfiles.Rows[0]["title"].ToString();
            lbltextbooksauthor.Text = dtfiles.Rows[0]["author"].ToString();
            lbltextbooksproduct.Text = "eBook Apps for Textbooks";

            //#region parent copy with  qty
            DataTable dttextbookscart = (DataTable)Session["dttextbookscart"];
            //DataTable parentcopied = dttextbooks.Clone();
            //foreach (DataRow dr in dttextbooks.Rows)
            //{
            //    if (dr["parentid"].ToString() == "" && dr["qty"].ToString() != "" && dr["productname"].ToString() != "")
            //    {
            //        //if (dr["cartid"].ToString() != "8a" && dr["cartid"].ToString() != "8b" && dr["cartid"].ToString() != "8c" && dr["cartid"].ToString() != "10a" && dr["cartid"].ToString() != "10b" && dr["cartid"].ToString() != "10c" && dr["cartid"].ToString() != "10d" && dr["cartid"].ToString() != "10e")
            //        //{
            //        DataRow dcopy = parentcopied.NewRow();
            //        dcopy.ItemArray = dr.ItemArray;
            //        parentcopied.Rows.Add(dcopy);
            //        //}
            //    }
            //}
            //#endregion

            //#region child copy with qty
            //DataTable childcopied = dttextbooks.Clone();
            //foreach (DataRow dr in dttextbooks.Rows)
            //{
            //    if (dr["parentid"].ToString() != "" && dr["qty"].ToString() != "" && dr["productname"].ToString() != "")
            //    {
            //        DataRow dcopy = childcopied.NewRow();
            //        dcopy.ItemArray = dr.ItemArray;
            //        childcopied.Rows.Add(dcopy);
            //    }
            //}
            //#endregion

            //if (parentcopied.Rows.Count > 0)
            //    hdncopyrow.Value = parentcopied.Rows[0]["qty"].ToString();
            //if (childcopied.Rows.Count > 0)
            //    hdncopyrow.Value = childcopied.Rows[0]["qty"].ToString();

            lbltextbooksipadquantity.Text = getvaluesfromrow(dttextbookscart, "5.1")["qty"].ToString();
            lbltextbooksipadunitcost.Text = getvaluesfromrow(dttextbookscart, "5.1")["unitcost"].ToString();
            lbltextbooksipadtotalcost.Text = getvaluesfromrow(dttextbookscart, "5.1")["totalcost"].ToString();

            lbltextbooksiphonequantity.Text = getvaluesfromrow(dttextbookscart, "5.2")["qty"].ToString();
            lbltextbooksiphoneunitcost.Text = getvaluesfromrow(dttextbookscart, "5.2")["unitcost"].ToString();
            lbltextbooksiphonetotalcost.Text = getvaluesfromrow(dttextbookscart, "5.2")["totalcost"].ToString();

            lbltextbooksandroidtabletsquantity.Text = getvaluesfromrow(dttextbookscart, "5.3")["qty"].ToString();
            lbltextbooksandroidtabletsunitcost.Text = getvaluesfromrow(dttextbookscart, "5.3")["unitcost"].ToString();
            lbltextbooksandroidtabletstotalcost.Text = getvaluesfromrow(dttextbookscart, "5.3")["totalcost"].ToString();

            lbltextbooksandroidphonesquantity.Text = getvaluesfromrow(dttextbookscart, "5.4")["qty"].ToString();
            lbltextbooksandroidphonesunitcost.Text = getvaluesfromrow(dttextbookscart, "5.4")["unitcost"].ToString();
            lbltextbooksandroidphonestotalcost.Text = getvaluesfromrow(dttextbookscart, "5.4")["totalcost"].ToString();

            lbltextbookscustpagesquantity.Text = getvaluesfromrow(dttextbookscart, "5a")["qty"].ToString();
            lbltextbookscustpagesunitcost.Text = getvaluesfromrow(dttextbookscart, "5a")["unitcost"].ToString();
            lbltextbookscustpagestotalcost.Text = getvaluesfromrow(dttextbookscart, "5a")["totalcost"].ToString();

            lbltextbooksinteractivequantity.Text = getvaluesfromrow(dttextbookscart, "5b")["qty"].ToString();
            lbltextbooksinteractiveunitcost.Text = getvaluesfromrow(dttextbookscart, "5b")["unitcost"].ToString();
            lbltextbooksinteractivetotalcost.Text = getvaluesfromrow(dttextbookscart, "5b")["totalcost"].ToString();

            lbltextbooksavquantity.Text = getvaluesfromrow(dttextbookscart, "5c")["qty"].ToString();
            lbltextbooksavunitcost.Text = getvaluesfromrow(dttextbookscart, "5c")["unitcost"].ToString();
            lbltextbooksavtotalcost.Text = getvaluesfromrow(dttextbookscart, "5c")["totalcost"].ToString();




            lbltextbooksgrandtotal.Text = roundofdecimalpoints(Convert.ToDecimal(Session["textbookscarttotal"].ToString()) + Convert.ToDecimal(Session["textbooksdiscountonbasepkg"].ToString()));

            lbltextbooksdiscountonbasepkg.Text = Session["textbooksdiscountonbasepkg"].ToString();
            lbltextbooksestimatedproductvalue.Text = Session["textbookscarttotal"].ToString();
            lbltextbookscartprice.Text = Session["textbookscarttotal"].ToString();
            lbltextbookscartid.Text = Application["cartgen"].ToString();
        }
        #endregion

        #region round the decimal points
        private string roundofdecimalpoints(decimal x)
        {
            return Math.Round(x, 2).ToString();
        }
        #endregion

        #region get data row values
        private static DataRow getvaluesfromrow(DataTable dtsimpleebookappscart, string s)
        {
            DataRow[] filteredRows =
                  dtsimpleebookappscart.Select(string.Format("{0} LIKE '%{1}%'", "cartid", s));
            return filteredRows[0];
        }
        #endregion
    }
}