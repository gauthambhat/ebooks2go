using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace eBooks2goV5.ebookapps
{
    public partial class simpleebookcart : System.Web.UI.Page
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
                dtfiles = (DataTable)Session["dtsimpleebookappsfiles"];
            
            lblsimpleebookappstitle.Text = dtfiles.Rows[0]["title"].ToString();
            lblsimpleebookappsauthor.Text = dtfiles.Rows[0]["author"].ToString();
            lblsimpleebookappsproduct.Text = "Simple eBook Apps";

            //#region parent copy with  qty
            DataTable dtsimpleebookapps = (DataTable)Session["dtsimpleebookappscart"];
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

            lblsimpleebookappsipadquantity.Text = getvaluesfromrow(dtsimpleebookapps, "3.1")["qty"].ToString();
            lblsimpleebookappsipadunitcost.Text = getvaluesfromrow(dtsimpleebookapps, "3.1")["unitcost"].ToString();
            lblsimpleebookappsipadtotalcost.Text = getvaluesfromrow(dtsimpleebookapps, "3.1")["totalcost"].ToString();

            lblsimpleebookappsiphonequantity.Text = getvaluesfromrow(dtsimpleebookapps, "3.2")["qty"].ToString();
            lblsimpleebookappsiphoneunitcost.Text = getvaluesfromrow(dtsimpleebookapps, "3.2")["unitcost"].ToString();
            lblsimpleebookappsiphonetotalcost.Text = getvaluesfromrow(dtsimpleebookapps, "3.2")["totalcost"].ToString();

            lblsimpleebookappsandroidtabletsquantity.Text = getvaluesfromrow(dtsimpleebookapps, "3.3")["qty"].ToString();
            lblsimpleebookappsandroidtabletsunitcost.Text = getvaluesfromrow(dtsimpleebookapps, "3.3")["unitcost"].ToString();
            lblsimpleebookappsandroidtabletstotalcost.Text = getvaluesfromrow(dtsimpleebookapps, "3.3")["totalcost"].ToString();

            lblsimpleebookappsandroidphonesqunatity.Text = getvaluesfromrow(dtsimpleebookapps, "3.4")["qty"].ToString();
            lblsimpleebookappsandroidphonesunitcost.Text = getvaluesfromrow(dtsimpleebookapps, "3.4")["unitcost"].ToString();
            lblsimpleebookappsandroidphonestotalcost.Text = getvaluesfromrow(dtsimpleebookapps, "3.4")["totalcost"].ToString();

            lblsimpleebookappspagesquantity.Text = getvaluesfromrow(dtsimpleebookapps, "3a")["qty"].ToString();
            lblsimpleebookappspagesunitcost.Text = getvaluesfromrow(dtsimpleebookapps, "3a")["unitcost"].ToString();
            lblsimpleebookappspagestotalcost.Text = getvaluesfromrow(dtsimpleebookapps, "3a")["totalcost"].ToString();



            lblsimpleebookappsgrandtotal.Text = roundofdecimalpoints(Convert.ToDecimal(Session["simpleeBookappscarttotal"].ToString()) + Convert.ToDecimal(Session["simpleebookappsdiscountonbasepkg"].ToString()));

            lblsimpleebookappsdiscountonbasepkg.Text = Session["simpleebookappsdiscountonbasepkg"].ToString();
            lblsimpleebookappsestimatedproductvalue.Text = Session["simpleeBookappscarttotal"].ToString();
            lblsimpleebookappscartprice.Text = Session["simpleeBookappscarttotal"].ToString();
            lblsimpleebookappscartid.Text = Application["cartgen"].ToString();
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