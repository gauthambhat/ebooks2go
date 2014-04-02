using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eBooks2goV5.pricing
{
    public partial class ebookcart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bindcartvalues();
        }

        #region Bindvalues to cart
        private void Bindcartvalues()
        {
            
            DataTable dtfiles;
            if (Request.QueryString["ID"] == "1")
                dtfiles = (DataTable)Session["dteBookfiles"];
            else
                dtfiles = (DataTable)Session["dtEnhancedeBookfiles"];
            
            lbleBookTitle.Text = dtfiles.Rows[0]["title"].ToString();
            lbleBookauthor.Text = dtfiles.Rows[0]["author"].ToString();
            lbleBookproduct.Text = "eBook";

            #region parent copy with  qty
            DataTable dteBookcart = (DataTable)Session["dteBookcart"];
            DataTable parentcopied = dteBookcart.Clone();
            parentcopied.Columns.Add("serialNo", typeof(System.String));
            int i=1;
            foreach (DataRow dr in dteBookcart.Rows)
            {
                if (dr["parentid"].ToString() == "" && dr["qty"].ToString() != "" && dr["productname"].ToString()!="")
                {
                        
                        DataRow dcopy = parentcopied.NewRow();
                        dcopy.ItemArray = dr.ItemArray;
                        dcopy["serialNo"] = (i++).ToString();
                        parentcopied.Rows.Add(dcopy);
                   
                }
            }
            #endregion

            #region child copy with qty
            DataTable childcopied = dteBookcart.Clone();
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            childcopied.Columns.Add("alphaserial", typeof(System.String));
            i = 0;//customisation
           int j = 0;//elemenets
            foreach (DataRow dr in dteBookcart.Rows)
            {
                if (dr["parentid"].ToString() != "" && dr["qty"].ToString() != "" && dr["productname"].ToString() != "")
                {
                    DataRow dcopy = childcopied.NewRow();
                    dcopy.ItemArray = dr.ItemArray;
                    if (dr["parentid"].ToString() == "1")
                        dcopy["alphaserial"] = alpha[i++];
                    else
                        dcopy["alphaserial"] = alpha[j++];
                    childcopied.Rows.Add(dcopy);
                }
            }
            #endregion 

            if(parentcopied.Rows.Count>0)
            hdncopyrow.Value = parentcopied.Rows[0]["qty"].ToString();
            if(childcopied.Rows.Count>0)
            hdncopyrow.Value = childcopied.Rows[0]["qty"].ToString();
            Session["ebookparentcart"] = parentcopied;
            Session["ebookchildcart"] = childcopied;
            lbleBookepubquantity.Text = getvaluesfromrow(dteBookcart, "1")["qty"].ToString();
            lbleBookepubunitcost.Text = getvaluesfromrow(dteBookcart, "1")["unitcost"].ToString();
            lbleBookepubtotalcost.Text = getvaluesfromrow(dteBookcart, "1")["totalcost"].ToString();

            lbleBookmobiquantity.Text = getvaluesfromrow(dteBookcart, "2")["qty"].ToString();
            lbleBookmobiunitcost.Text = getvaluesfromrow(dteBookcart, "2")["unitcost"].ToString();
            lbleBookmobitotalcost.Text = getvaluesfromrow(dteBookcart, "2")["totalcost"].ToString();

            lbleBookpdfquantity.Text = getvaluesfromrow(dteBookcart, "3")["qty"].ToString();
            lbleBookpdfunitcost.Text = getvaluesfromrow(dteBookcart, "3")["unitcost"].ToString();
            lbleBookpdftotalcost.Text = getvaluesfromrow(dteBookcart, "3")["totalcost"].ToString();

            lbleBookpagequantity.Text = getvaluesfromrow(dteBookcart, "4a")["qty"].ToString();
            lbleBookpageunitcost.Text = getvaluesfromrow(dteBookcart, "4a")["unitcost"].ToString();
            lbleBookpagetotalcost.Text = getvaluesfromrow(dteBookcart, "4a")["totalcost"].ToString();

            lbleBookimagequantity.Text = getvaluesfromrow(dteBookcart, "4b")["qty"].ToString();
            lbleBookimageunitcost.Text = getvaluesfromrow(dteBookcart, "4b")["unitcost"].ToString();
            lbleBookimagetotalcost.Text = getvaluesfromrow(dteBookcart, "4b")["totalcost"].ToString();

            lbleBookfootandendnotesquantity.Text = getvaluesfromrow(dteBookcart, "4c")["qty"].ToString();
            lbleBookfootandendnotesunitcost.Text = getvaluesfromrow(dteBookcart, "4c")["unitcost"].ToString();
            lbleBookfootandendnotestotalcost.Text = getvaluesfromrow(dteBookcart, "4c")["totalcost"].ToString();

            lbleBooklinksquantity.Text = getvaluesfromrow(dteBookcart, "4d")["qty"].ToString();
            lbleBooklinksunitcost.Text = getvaluesfromrow(dteBookcart, "4d")["unitcost"].ToString();
            lbleBooklinkstotalcost.Text = getvaluesfromrow(dteBookcart, "4d")["totalcost"].ToString();

            lbleBooknestedtocquantity.Text = getvaluesfromrow(dteBookcart, "5a")["qty"].ToString();

            lbleBookdropcapsquantity.Text = getvaluesfromrow(dteBookcart, "5b")["qty"].ToString();

            lbleBookcoloredfontsquantity.Text = getvaluesfromrow(dteBookcart, "5c")["qty"].ToString();

            lbleBooklistsquantity.Text = getvaluesfromrow(dteBookcart, "5d")["qty"].ToString();

            lbleBooksectionsquantity.Text = getvaluesfromrow(dteBookcart, "5e")["qty"].ToString();

            lbleBookcalloutsquantity.Text = getvaluesfromrow(dteBookcart, "5f")["qty"].ToString();

            lbleBookdoublecolumntextquantity.Text = getvaluesfromrow(dteBookcart, "5g")["qty"].ToString();

            lbleBookcenteredtextquantity.Text = getvaluesfromrow(dteBookcart, "5h")["qty"].ToString();

            lbleBookbordercolorquantity.Text = getvaluesfromrow(dteBookcart, "5i")["qty"].ToString();

            lbleBookavelementsquantity.Text = getvaluesfromrow(dteBookcart, "6")["qty"].ToString();
            lbleBookavelementsunitcost.Text = getvaluesfromrow(dteBookcart, "6")["unitcost"].ToString();
            lbleBookavelementstotalcost.Text = getvaluesfromrow(dteBookcart, "6")["totalcost"].ToString();

            lbleBookcoverdesignquantity.Text = getvaluesfromrow(dteBookcart, "7")["qty"].ToString();
            lbleBookcoverdesignunitcost.Text = getvaluesfromrow(dteBookcart, "7")["unitcost"].ToString();
            lbleBookcoverdesigntotalcost.Text = getvaluesfromrow(dteBookcart, "7")["totalcost"].ToString();

            lbleBookeisbnquantity.Text = getvaluesfromrow(dteBookcart, "8")["qty"].ToString();
            lbleBookeisbnunitcost.Text = getvaluesfromrow(dteBookcart, "8")["unitcost"].ToString();
            lbleBookeisbntotalcost.Text = getvaluesfromrow(dteBookcart, "8")["totalcost"].ToString();

            lbleBookdistributionquantity.Text = getvaluesfromrow(dteBookcart, "9")["qty"].ToString();

            lbleBookmarketingservicesquantity.Text = getvaluesfromrow(dteBookcart, "10")["qty"].ToString();
            lbleBookmarketingservicesunitcost.Text = getvaluesfromrow(dteBookcart, "10")["unitcost"].ToString();
            lbleBookmarketingservicestotalcost.Text = getvaluesfromrow(dteBookcart, "10")["totalcost"].ToString();

            lbleBookgrandtotal.Text = roundofdecimalpoints(Convert.ToDecimal(Session["eBookcarttotal"].ToString()) + Convert.ToDecimal(Session["eBookdiscountonbasepkg"].ToString()));

            lbleBookdiscountonbasepkg.Text = Session["eBookdiscountonbasepkg"].ToString();
            lbleBookestimatedproductvalue.Text = Session["eBookcarttotal"].ToString();
            lbleBookcartprice.Text = Session["eBookcarttotal"].ToString();
            cartID.Text = Application["cartgen"].ToString();
        }
        #endregion

        #region round the decimal points
        private string roundofdecimalpoints(decimal x)
        {
            return Math.Round(x, 2).ToString();
        }
        #endregion

        #region get data row values
        private static DataRow getvaluesfromrow(DataTable dteBookcart, string s)
        {
            DataRow[] filteredRows =
                  dteBookcart.Select(string.Format("{0} LIKE '%{1}%'", "cartid", s));
            return filteredRows[0];
        }
        #endregion
    }

   
}