using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace eBooks2goV5.ebookapps
{
    public partial class complexebookappscart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bindcartvalues();
        }

        #region Bindvalues to cart
        private void Bindcartvalues()
        {
            DataTable dtfiles;
            //if (Request.QueryString["ID"] == "3")
            dtfiles = (DataTable)Session["dtcomplexebookappsfiles"];

            lblcomplexebookappstitle.Text = dtfiles.Rows[0]["title"].ToString();
            lblcomplexebookappsauthor.Text = dtfiles.Rows[0]["author"].ToString();
            lblcomplexebookappsproduct.Text = "Complex eBook Apps";

            //#region parent copy with  qty
            DataTable dtcomplexebookapps = (DataTable)Session["dtcomplexebookappscart"];
            //DataTable parentcopied = dtsimpleebookapps.Clone();
            //foreach (DataRow dr in dtsimpleebookapps.Rows)
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
            //DataTable childcopied = dtsimpleebookapps.Clone();
            //foreach (DataRow dr in dtsimpleebookapps.Rows)
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

            lblcomplexebookappsipadquantity.Text = getvaluesfromrow(dtcomplexebookapps, "4.1")["qty"].ToString();
            lblcomplexebookappsipadunitcost.Text = getvaluesfromrow(dtcomplexebookapps, "4.1")["unitcost"].ToString();
            lblcomplexebookappsipadtotalcost.Text = getvaluesfromrow(dtcomplexebookapps, "4.1")["totalcost"].ToString();

            lblcomplexebookappsiphonequantity.Text = getvaluesfromrow(dtcomplexebookapps, "4.2")["qty"].ToString();
            lblcomplexebookappsiphoneunitcost.Text = getvaluesfromrow(dtcomplexebookapps, "4.2")["unitcost"].ToString();
            lblcomplexebookappsiphonetotalcost.Text = getvaluesfromrow(dtcomplexebookapps, "4.2")["totalcost"].ToString();

            lblcomplexebookappsandroidtabletsquantity.Text = getvaluesfromrow(dtcomplexebookapps, "4.3")["qty"].ToString();
            lblcomplexebookappsandroidtabletsunitcost.Text = getvaluesfromrow(dtcomplexebookapps, "4.3")["unitcost"].ToString();
            lblcomplexebookappsandroidtabletstotalcost.Text = getvaluesfromrow(dtcomplexebookapps, "4.3")["totalcost"].ToString();

            lblcomplexebookappsandroidphonesquantity.Text = getvaluesfromrow(dtcomplexebookapps, "4.4")["qty"].ToString();
            lblcomplexebookappsandroidphonesunitcost.Text = getvaluesfromrow(dtcomplexebookapps, "4.4")["unitcost"].ToString();
            lblcomplexebookappsandroidphonestotalcost.Text = getvaluesfromrow(dtcomplexebookapps, "4.4")["totalcost"].ToString();

            lblcomplexebookappscustpagesquantity.Text = getvaluesfromrow(dtcomplexebookapps, "4a")["qty"].ToString();
            lblcomplexebookappscustpagesunitcost.Text = getvaluesfromrow(dtcomplexebookapps, "4a")["unitcost"].ToString();
            lblcomplexebookappscustpagestotalcost.Text = getvaluesfromrow(dtcomplexebookapps, "4a")["totalcost"].ToString();

            lblcomplexebookappscustanimationpagesquantity.Text = getvaluesfromrow(dtcomplexebookapps, "4b")["qty"].ToString();
            lblcomplexebookappscustanimationpagesunitcost.Text = getvaluesfromrow(dtcomplexebookapps, "4b")["unitcost"].ToString();
            lblcomplexebookappscustanimationpagestotalcost.Text = getvaluesfromrow(dtcomplexebookapps, "4b")["totalcost"].ToString();




            lblcomplexebookappsgrandtotal.Text = roundofdecimalpoints(Convert.ToDecimal(Session["complexeBookappscarttotal"].ToString()) + Convert.ToDecimal(Session["complexebookappsdiscountonbasepkg"].ToString()));

            lblcomplexebookappsdiscountonbasepkg.Text = Session["complexebookappsdiscountonbasepkg"].ToString();
            lblcomplexebookappsestimatedproductvalue.Text = Session["complexeBookappscarttotal"].ToString();
            lblcomplexebookappscartprice.Text = Session["complexeBookappscarttotal"].ToString();
            lblcomplexebookappscartid.Text = Application["cartgen"].ToString();
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