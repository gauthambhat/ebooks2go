using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eBooks2goV5.pricing
{
    public partial class enhancedebookcart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bindcartvalues();
        }

        #region Bindvalues to cart
        private void Bindcartvalues() //display the Enhanced eBook Form values from session to cart form
        {
            DataTable dtfiles; //declaration of datatable
                if(Request.QueryString["ID"]=="1") //pass the product category's as a ID in query string,like eBook, Enhanced eBook, eBook Apps, etc.
                    dtfiles = (DataTable)Session["dteBookfiles"]; //if id is eBook then store values from session datatable to eBook form datatable.
                else
                    dtfiles = (DataTable)Session["dtEnhancedeBookfiles"]; //if id is Enhanced eBook then store values from session datatable to Enhanced eBook form datatable.

            lblcartid.Text = Application["cartgen"].ToString(); //generate the cartid from global.asax file.
            lblEnhancedeBooktitle.Text = dtfiles.Rows[0]["title"].ToString(); //display the title from dtfiles datatable to lbl
            lblEnhancedeBookauthor.Text = dtfiles.Rows[0]["author"].ToString(); //display the author from dtfiles datatable to lbl
            lblEnhancedeBookproduct.Text = "EnhancedeBook"; //display the product name as a static.

            #region parent copy with  qty
            DataTable dtEnhancedeBookcart = (DataTable)Session["dtEnhancedeBookcart"];
            DataTable parentcopied = dtEnhancedeBookcart.Clone();
            parentcopied.Columns.Add("serialNo", typeof(System.String));
            int i = 1;
            foreach (DataRow dr in dtEnhancedeBookcart.Rows)
            {
                if (dr["parentid"].ToString() == "" && dr["qty"].ToString() != "" && dr["productname"].ToString() != "")
                {

                    DataRow dcopy = parentcopied.NewRow();
                    dcopy.ItemArray = dr.ItemArray;
                    dcopy["serialNo"] = (i++).ToString();
                    parentcopied.Rows.Add(dcopy);

                }
            }
            #endregion

            #region child copy with qty
            DataTable childcopied = dtEnhancedeBookcart.Clone();
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            childcopied.Columns.Add("alphaserial", typeof(System.String));
            i = 0;//customisation
            int j = 0;//elemenets
            foreach (DataRow dr in dtEnhancedeBookcart.Rows)
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
            
            Session["enhancedebookparentcart"] = parentcopied;
            Session["enhancedebookchildcart"] = childcopied;

            lblEnhancedeBookepubquantity.Text = getvaluesfromrow(dtEnhancedeBookcart, "1")["qty"].ToString();
            lblEnhancedeBookepubunitcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "1")["unitcost"].ToString();
            lblEnhancedeBookepubtotalcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "1")["totalcost"].ToString();

            lblEnhancedeBookmobiquantity.Text = getvaluesfromrow(dtEnhancedeBookcart, "2")["qty"].ToString();
            lblEnhancedeBookmobiunitcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "2")["unitcost"].ToString();
            lblEnhancedeBookmobitotalcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "2")["totalcost"].ToString();

            lblEnhancedeBooknookquantity.Text = getvaluesfromrow(dtEnhancedeBookcart, "3")["qty"].ToString();
            lblEnhancedeBooknookunitcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "3")["unitcost"].ToString();
            lblEnhancedeBooknooktotalcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "3")["totalcost"].ToString();

            lblEnhancedeBookcustpagesquantity.Text = getvaluesfromrow(dtEnhancedeBookcart, "4a")["qty"].ToString();
            lblEnhancedeBookcustpagesunitcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "4a")["unitcost"].ToString();
            lblEnhancedeBookcustpagestotalcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "4a")["totalcost"].ToString();

            lblEnhancedeBookcustlinksquantity.Text = getvaluesfromrow(dtEnhancedeBookcart, "4b")["qty"].ToString();
            lblEnhancedeBookcustlinksunitcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "4b")["unitcost"].ToString();
            lblEnhancedeBookcustlinkstotalcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "4b")["totalcost"].ToString();

            lblEnhancedeBooknestedtocquantity.Text = getvaluesfromrow(dtEnhancedeBookcart, "5a")["qty"].ToString();

            lblEnhancedeBookdropcapsquantity.Text = getvaluesfromrow(dtEnhancedeBookcart, "5b")["qty"].ToString();

            lblEnhancedeBookcoloredfontsquantity.Text = getvaluesfromrow(dtEnhancedeBookcart, "5c")["qty"].ToString();

            lblEnhancedeBooklistsquantity.Text = getvaluesfromrow(dtEnhancedeBookcart, "5d")["qty"].ToString();

            lblEnhancedeBooksectionsquantity.Text = getvaluesfromrow(dtEnhancedeBookcart, "5e")["qty"].ToString();

            lblEnhancedeBookcalloutsquantity.Text = getvaluesfromrow(dtEnhancedeBookcart, "5f")["qty"].ToString();

            lblEnhancedeBookdoublecolumntextquantity.Text = getvaluesfromrow(dtEnhancedeBookcart, "5g")["qty"].ToString();

            lblEnhancedeBookcenteredtextquantity.Text = getvaluesfromrow(dtEnhancedeBookcart, "5h")["qty"].ToString();

            lblEnhancedeBooktextboxcolorsquantity.Text = getvaluesfromrow(dtEnhancedeBookcart, "5i")["qty"].ToString();

            lblEnhancedeBookavelementsquantity.Text = getvaluesfromrow(dtEnhancedeBookcart, "6")["qty"].ToString();
            lblEnhancedeBookavelementsunitcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "6")["unitcost"].ToString();
            lblEnhancedeBookavelementstotalcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "6")["totalcost"].ToString();

            lblEnhancedeBooktexthighlightsquantity.Text = getvaluesfromrow(dtEnhancedeBookcart, "7")["qty"].ToString();
            lblEnhancedeBooktexthighlightsunitcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "7")["unitcost"].ToString();
            lblEnhancedeBooktexthighlightstotalcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "7")["totalcost"].ToString();


            lblEnhancedeBookcoverdesignquantity.Text = getvaluesfromrow(dtEnhancedeBookcart, "8")["qty"].ToString(); ;
            lblEnhancedeBookcoverdesignunitcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "8")["unitcost"].ToString(); ;
            lblEnhancedeBookcoverdesigntotalcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "8")["totalcost"].ToString(); ;
          

            lblEnhancedeBookeisbnquantity.Text = getvaluesfromrow(dtEnhancedeBookcart, "9")["qty"].ToString();
            lblEnhancedeBookeisbnunitcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "9")["unitcost"].ToString();
            lblEnhancedeBookeisbntotalcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "9")["totalcost"].ToString();

            lblEnhancedeBookdistributionquantity.Text = getvaluesfromrow(dtEnhancedeBookcart, "10")["qty"].ToString();

            lblEnhancedeBookmarketingservicesquantity.Text = getvaluesfromrow(dtEnhancedeBookcart, "11")["qty"].ToString();
            lblEnhancedeBookmarketingservicesunitcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "11")["unitcost"].ToString();
            lblEnhancedeBookmarketingservicestotalcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "11")["totalcost"].ToString();

            lblEnhancedeBookgrandtotal.Text = roundofdecimalpoints(Convert.ToDecimal(Session["EnhancedeBookcarttotal"].ToString()) + Convert.ToDecimal(Session["EnhancedeBookdiscountonbasepkg"].ToString()));

            lblEnhancedeBookdiscountonbasepkg.Text = Session["EnhancedeBookdiscountonbasepkg"].ToString();
            lblEnhancedeBooktotaldiscount.Text = Session["EnhancedeBookcarttotal"].ToString();
            lblEnhancedeBookestimatedcartvalue.Text = Session["EnhancedeBookcarttotal"].ToString();
            //lblEnhancedeBookestimatedcartvalue.Text = Session["EnhancedeBookcarttotal"].ToString();
            //lblcartid.Text = Application["cartgen"].ToString();
        }

        #region get the values from data row in a datatable
        private static DataRow getvaluesfromrow(DataTable dtEnhancedeBookcart,string s)
        {
            DataRow[] filteredRows =
                  dtEnhancedeBookcart.Select(string.Format("{0} LIKE '%{1}%'", "cartid", s));
            return filteredRows[0];
        }
        #endregion

        #endregion

        #region round the decimal
        private string roundofdecimalpoints(decimal x)
        {
            return Math.Round(x, 2).ToString();
        }
        #endregion


    }
}