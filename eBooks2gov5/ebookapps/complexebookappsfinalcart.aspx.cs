using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;      //namespace for datatable
using eBooks2goV5.bel;  //namespace for business entity layer
using eBooks2goV5.dal;  //namespace for data access layer
using eBooks2goV5.bll;
using System.Globalization;  //namespace for business logic layer


namespace eBooks2goV5.ebookapps
{
    public partial class complexebookappsfinalcart : System.Web.UI.Page
    {
        #region object Instatances (References)
        bel.cartmasterbel _cartmasterbel = new bel.cartmasterbel();//object instantiation for business entity layer
        bel.cartproductsbel _cartproductsbel = new cartproductsbel();
        bel.ebfileuploadbel _ebfileuploadbel = new ebfileuploadbel();

        bll.bll _cartmasterbll = new bll.bll();
        #endregion

        #region get request
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                parentrptbind();
                Bindcartvalues();
            }
        }
        #endregion

        #region "Hide or show edit checkbox inside datalist"
        protected string getStatus(object productid)
        {
            if (productid.ToString() != "")
                return "4";
            else
                return "1";
        }
        #endregion

        #region "Hide or show edit checkbox inside datalist"
        protected string getCSS(object productid)
        {
            if (productid.ToString() != "")
                return "eb2g_Additonaloption_cart";
            else
                return "ebook_aligncenter";
        }
        #endregion

        #region "Hide or show edit checkbox inside datalist"
        protected bool enablevisible(object productid)
        {
            if (productid.ToString() != "")
                return false;
            else
                return true;
        }
        #endregion

        #region bind parent cart
        private void parentrptbind()
        {
            #region parent copy with  qty
            DataTable dtcomplexebookappscart = (DataTable)Session["dtcomplexebookappscart"];
            DataTable parentcopied = dtcomplexebookappscart.Clone();
            parentcopied.Columns.Add("serialNo", typeof(System.String));
            int i = 1;
            foreach (DataRow dr in dtcomplexebookappscart.Rows)
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
            DataTable childcopied = dtcomplexebookappscart.Clone();
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            childcopied.Columns.Add("alphaserial", typeof(System.String));
            i = 0;//customisation
            int j = 0;//elemenets
            foreach (DataRow dr in dtcomplexebookappscart.Rows)
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

            Session["complexebookappsparentcart"] = parentcopied;
            Session["complexebookappsebookchildcart"] = childcopied;
            rptParent.DataSource = (DataTable)Session["complexebookappsparentcart"];
            rptParent.DataBind();

        }
        #endregion

        protected void rptParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField hdnproductId = (HiddenField)(e.Item.FindControl("hdnproductId"));

            if (hdnproductId.Value.ToString() != "")
            {
                Repeater rptchild = (Repeater)(e.Item.FindControl("rptChild"));
                DataRow[] filteredRows = getvaluesfromrow((DataTable)Session["complexebookappsebookchildcart"], hdnproductId.Value.ToString());
                DataTable dtcomplexeBookappscart = new DataTable();
                dtcomplexeBookappscart.Columns.Add("cartid", typeof(System.String));
                dtcomplexeBookappscart.Columns.Add("pcid", typeof(System.String));
                dtcomplexeBookappscart.Columns.Add("qty", typeof(System.String));
                dtcomplexeBookappscart.Columns.Add("unitcost", typeof(System.String));
                dtcomplexeBookappscart.Columns.Add("totalcost", typeof(System.String));
                dtcomplexeBookappscart.Columns.Add("parentid", typeof(System.String));
                dtcomplexeBookappscart.Columns.Add("productname", typeof(System.String));
                dtcomplexeBookappscart.Columns.Add("productid", typeof(System.String));
                dtcomplexeBookappscart.Columns.Add("alphaserial", typeof(System.String));
                foreach (DataRow row in filteredRows)
                {
                    dtcomplexeBookappscart.ImportRow(row);
                }
                rptchild.DataSource = dtcomplexeBookappscart;
                rptchild.DataBind();

            }
        }

        #region get data row values
        //private static DataRow[] getvaluesfromrow(DataTable dteBookcart, string s)
        //{
        //    DataRow[] filteredRows = dteBookcart.Select(string.Format("{0} LIKE '%{1}%'", "parentid", s));
        //    return filteredRows;
        //}
        #endregion

        #region get data row values
        private static DataRow[] getvaluesfromrow(DataTable dtcomplexebookappscart, string s, int Isparent = 1)
        {
            DataRow[] filteredRows;
            if (Isparent == 1)
                filteredRows = dtcomplexebookappscart.Select(string.Format("{0} LIKE '%{1}%'", "parentid", s));
            else
                filteredRows = dtcomplexebookappscart.Select(string.Format("{0} LIKE '%{1}%'", "cartid", s));
            return filteredRows;
        }
        #endregion

        #region Bindvalues to cart
        private void Bindcartvalues()
        {

            DataTable dtfiles;

            dtfiles = (DataTable)Session["dtcomplexebookappsfiles"];

            lblcomplexebookappstitle.Text = dtfiles.Rows[0]["title"].ToString();
            lblcomplexebookappsauthor.Text = dtfiles.Rows[0]["author"].ToString();
            lblcomplexebookappsproduct.Text = "Complex eBook Apps";


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

        #region checkout button click event
        protected void imgbtncheckout_Click(object sender, ImageClickEventArgs e)
        {
            //#region cartmaster
            //DataTable dtfiles = (DataTable)Session["dtcomplexebookappsfiles"];//this ref is used for to get the values from fileupload to this page.

            ////fileupload start
            //_cartmasterbel.title = lblcomplexebookappstitle.Text;
            //_cartmasterbel.author = lblcomplexebookappsauthor.Text;
            //_cartmasterbel.bworcolor = Convert.ToBoolean(Convert.ToInt16(dtfiles.Rows[0]["color"].ToString()));
            //_cartmasterbel.booklanguage = Convert.ToInt16(dtfiles.Rows[0]["booklang"].ToString());
            //_cartmasterbel.prjcompdate = Convert.ToDateTime((DateTime.ParseExact(dtfiles.Rows[0]["projectcompletedate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture)).Date.ToString("MM/dd/yyyy"));
            //_cartmasterbel.manscrpitdesc = dtfiles.Rows[0]["filedescription"].ToString();
            //_cartmasterbel.cartrefcode = Convert.ToInt16(lblcomplexebookappscartid.Text.ToString());
            ////file upload complete

            //DataTable dtcomplexebookappscart = (DataTable)Session["dtcomplexebookappscart"];//use the simple ebook apps session values here 
            ////ebook customizations start
            //_cartmasterbel.totalpages = getvaluesfromrow(dtcomplexebookappscart, "4a", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dtcomplexebookappscart, "4a", 0)[0]["qty"].ToString()) : (int?)null;
            //_cartmasterbel.totalanimationpages = getvaluesfromrow(dtcomplexebookappscart, "4b", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dtcomplexebookappscart, "4b", 0)[0]["qty"].ToString()) : (int?)null;
            ////ebook customization complete

            ////offer selected value start
            //_cartmasterbel.prodcatid = (int)(bel.bel.prodcategory.complexebookapps);
            //_cartmasterbel.offerselected = Convert.ToInt32((Session["complexeBookappsofferselected"]));
            ////offer selected values end


            ////_cartmasterbel.cmid = _cartmasterbll.insertnewcartmaster(_cartmasterbel);
            //_cartproductsbel.cmid = _cartmasterbel.cmid;
            //#endregion

            //#region products
            ////DataRow[] drselectedproducts = dtcomplexebookappscart.Select("cartid IN('4.1','4.2','4.3','4.4') and qty='1'");
            ////foreach (DataRow drselectedproduct in drselectedproducts)
            ////{
            ////    switch (drselectedproduct["cartid"].ToString())
            ////    {
            ////        case "4.1":
            ////            _cartproductsbel.prodid = 11;
            ////            break;
            ////        case "4.2":
            ////            _cartproductsbel.prodid = 12;
            ////            break;
            ////        case "4.3":
            ////            _cartproductsbel.prodid = 13;
            ////            break;
            ////        default:
            ////            _cartproductsbel.prodid = 14;
            ////            break;
            ////    }
            ////    _cartproductsbel.eisbn = 0;
            ////    _cartmasterbll.insertnewcartproducts(_cartproductsbel);
            ////}
            //#endregion

            //#region products for list
            //List<cartproductsbel> _productlist = new List<cartproductsbel>();   //this is for list

            //DataRow[] drselectedproducts = dtcomplexebookappscart.Select("cartid IN('4.1','4.2','4.3','4.4') and qty='1'");   //here 1,2,3 's products like epub, mobi, pdf.
            //foreach (DataRow drselectedproduct in drselectedproducts)
            //{
            //    cartproductsbel _cartproductsbeltest = new cartproductsbel();
            //    switch (drselectedproduct["cartid"].ToString())
            //    {
            //        case "4.1":
            //            _cartproductsbeltest.prodid = 11;
            //            break;
            //        case "4.2":
            //            _cartproductsbeltest.prodid = 12;
            //            break;
            //        case "4.3":
            //            _cartproductsbeltest.prodid = 13;
            //            break;
            //        default:
            //            _cartproductsbeltest.prodid = 14;
            //            break;
            //    }
            //    _cartproductsbeltest.eisbn = 0;
            //    // _cartmasterbll.insertnewcartproducts(_cartproductsbel);
            //    _productlist.Add(_cartproductsbeltest);
            //    _cartproductsbeltest = null;

            //}

            //#endregion

            //#region fileuploads

            ////_ebfileuploadbel.cmid = _cartmasterbel.cmid;
            ////DataTable dtmultifiles = (DataTable)Session["complexebookappsfiles"];    //get the multiple fileuploads from fileupload form to this form
            ////foreach (DataRow drmultiplefiles in dtmultifiles.Rows)
            ////{
            ////    _ebfileuploadbel.upfilename = drmultiplefiles["filename"].ToString();
            ////    _cartmasterbll.insertnewebfileupload(_ebfileuploadbel);
            ////}
            //#endregion

            //#region fileuploads for list

            //_ebfileuploadbel.cmid = _cartmasterbel.cmid;
            //List<ebfileuploadbel> _fluploadlist = new List<ebfileuploadbel>();//this fileupload for list
            //DataTable dtmultifiles = (DataTable)Session["complexebookappsfiles"];   //get the multiple fileuploads from fileupload form to this form
            //foreach (DataRow drmultiplefiles in dtmultifiles.Rows)
            //{
            //    ebfileuploadbel _ebfileuploadtest = new ebfileuploadbel();
            //    _ebfileuploadtest.upfilename = drmultiplefiles["filename"].ToString();
            //    //_cartmasterbll.insertnewebfileupload(_ebfileuploadbel);
            //    _fluploadlist.Add(_ebfileuploadtest);
            //    _ebfileuploadtest = null;
            //}
            //#endregion

            //_cartmasterbll.insertnewcartmaster(_cartmasterbel, _productlist, _fluploadlist);
            //clearsession();
            hdnsigninvalue.Value = "1";// here 1 means model popup visible.
        }

        #region clear session values
        //private void clearsession()
        //{
        //    Session.Clear();
        //    //Response.Redirect("~/pricingwithajaxtab.aspx"); //if u use this stmt it should displays two tabs
        //    Response.Write("<script>top.location.href='../pricingwithajaxtab.aspx'</script>");
        //}
        #endregion
        #endregion


    }
}