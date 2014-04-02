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
    public partial class textbooksfinalcart : System.Web.UI.Page
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
            DataTable dttextbookscart = (DataTable)Session["dttextbookscart"];
            DataTable parentcopied = dttextbookscart.Clone();
            parentcopied.Columns.Add("serialNo", typeof(System.String));
            int i = 1;
            foreach (DataRow dr in dttextbookscart.Rows)
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
            DataTable childcopied = dttextbookscart.Clone();
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            childcopied.Columns.Add("alphaserial", typeof(System.String));
            i = 0;//customisation
            int j = 0;//elemenets
            foreach (DataRow dr in dttextbookscart.Rows)
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

            Session["textbooksparentcart"] = parentcopied;
            Session["textbookschildcart"] = childcopied;
            rptParent.DataSource = (DataTable)Session["textbooksparentcart"];
            rptParent.DataBind();

        }
        #endregion

        #region repeater item databound event
        protected void rptParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField hdnproductId = (HiddenField)(e.Item.FindControl("hdnproductId"));

            if (hdnproductId.Value.ToString() != "")
            {
                Repeater rptchild = (Repeater)(e.Item.FindControl("rptChild"));
                DataRow[] filteredRows = getvaluesfromrow((DataTable)Session["textbookschildcart"], hdnproductId.Value.ToString());

                DataTable dttextbookscart = new DataTable();
                dttextbookscart.Columns.Add("cartid", typeof(System.String));
                dttextbookscart.Columns.Add("pcid", typeof(System.String));
                dttextbookscart.Columns.Add("qty", typeof(System.String));
                dttextbookscart.Columns.Add("unitcost", typeof(System.String));
                dttextbookscart.Columns.Add("totalcost", typeof(System.String));
                dttextbookscart.Columns.Add("parentid", typeof(System.String));
                dttextbookscart.Columns.Add("productname", typeof(System.String));
                dttextbookscart.Columns.Add("productid", typeof(System.String));
                dttextbookscart.Columns.Add("alphaserial", typeof(System.String));
                foreach (DataRow row in filteredRows)
                {
                    dttextbookscart.ImportRow(row);
                }
                rptchild.DataSource = dttextbookscart;
                rptchild.DataBind();

            }
        }
        #endregion

        #region get data row values
        //private static DataRow[] getvaluesfromrow(DataTable dteBookcart, string s)
        //{
        //    DataRow[] filteredRows = dteBookcart.Select(string.Format("{0} LIKE '%{1}%'", "parentid", s));
        //    return filteredRows;
        //}
        #endregion

        #region get data row values
        private static DataRow[] getvaluesfromrow(DataTable dttextbookscart, string s, int Isparent = 1)
        {
            DataRow[] filteredRows;
            if (Isparent == 1)
                filteredRows = dttextbookscart.Select(string.Format("{0} LIKE '%{1}%'", "parentid", s));
            else
                filteredRows = dttextbookscart.Select(string.Format("{0} LIKE '%{1}%'", "cartid", s));
            return filteredRows;
        }
        #endregion

        #region Bindvalues to cart
        private void Bindcartvalues()
        {

            DataTable dtfiles;
            dtfiles = (DataTable)Session["dttextbookfiles"];

            lbltextbookstitle.Text = dtfiles.Rows[0]["title"].ToString();
            lbltextbooksauthor.Text = dtfiles.Rows[0]["author"].ToString();
            lbltextbooksproduct.Text = "eBook Apps for Textbooks";



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

        #region checkout image button click event
        protected void imgbtncheckout_Click(object sender, ImageClickEventArgs e)
        {
            //#region cartmaster
            //DataTable dtfiles = (DataTable)Session["dttextbookfiles"];//this ref is used for to get the values from fileupload to this page.

            ////fileupload start
            //_cartmasterbel.title = lbltextbookstitle.Text;
            //_cartmasterbel.author = lbltextbooksauthor.Text;
            //_cartmasterbel.bworcolor = Convert.ToBoolean(Convert.ToInt16(dtfiles.Rows[0]["color"].ToString()));
            //_cartmasterbel.booklanguage = Convert.ToInt16(dtfiles.Rows[0]["booklang"].ToString());
            //_cartmasterbel.prjcompdate = Convert.ToDateTime((DateTime.ParseExact(dtfiles.Rows[0]["projectcompletedate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture)).Date.ToString("MM/dd/yyyy"));
            //_cartmasterbel.manscrpitdesc = dtfiles.Rows[0]["filedescription"].ToString();
            //_cartmasterbel.cartrefcode = Convert.ToInt16(lbltextbookscartid.Text.ToString());
            ////file upload complete

            //DataTable dttextbookscart = (DataTable)Session["dttextbookscart"];//use the simple ebook apps session values here 
            ////ebook customizations start
            //_cartmasterbel.totalpages = getvaluesfromrow(dttextbookscart, "5a", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dttextbookscart, "5a", 0)[0]["qty"].ToString()) : (int?)null;
            //_cartmasterbel.interactiveselfassessmentqa = getvaluesfromrow(dttextbookscart, "5b", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dttextbookscart, "5b", 0)[0]["qty"].ToString()) : (int?)null;
            //_cartmasterbel.totalav = getvaluesfromrow(dttextbookscart, "5c", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dttextbookscart, "5c", 0)[0]["qty"].ToString()) : (int?)null;
            ////ebook customization complete

            ////offer selected value start
            //_cartmasterbel.prodcatid = (int)(bel.bel.prodcategory.eBookappsfortextbooks);
            //_cartmasterbel.offerselected = Convert.ToInt32((Session["textbooksofferselected"]));
            ////offer selected values end


            ////_cartmasterbel.cmid = _cartmasterbll.insertnewcartmaster(_cartmasterbel);
            //_cartproductsbel.cmid = _cartmasterbel.cmid;
            //#endregion

            //#region products
            ////DataRow[] drselectedproducts = dttextbookscart.Select("cartid IN('5.1','5.2','5.3','5.4') and qty='1'");
            ////foreach (DataRow drselectedproduct in drselectedproducts)
            ////{
            ////    switch (drselectedproduct["cartid"].ToString())
            ////    {
            ////        case "5.1":
            ////            _cartproductsbel.prodid = 15;
            ////            break;
            ////        case "5.2":
            ////            _cartproductsbel.prodid = 16;
            ////            break;
            ////        case "5.3":
            ////            _cartproductsbel.prodid = 17;
            ////            break;
            ////        default:
            ////            _cartproductsbel.prodid = 18;
            ////            break;
            ////    }
            ////    _cartproductsbel.eisbn = 0;
            ////    _cartmasterbll.insertnewcartproducts(_cartproductsbel);
            ////}
            //#endregion

            //#region products for list
            //List<cartproductsbel> _productlist = new List<cartproductsbel>();   //this is for list

            //DataRow[] drselectedproducts = dttextbookscart.Select("cartid IN('5.1','5.2','5.3','5.4') and qty='1'");   //here 1,2,3 's products like epub, mobi, pdf.
            //foreach (DataRow drselectedproduct in drselectedproducts)
            //{
            //    cartproductsbel _cartproductsbeltest = new cartproductsbel();
            //    switch (drselectedproduct["cartid"].ToString())
            //    {
            //        case "5.1":
            //            _cartproductsbeltest.prodid = 15;
            //            break;
            //        case "5.2":
            //            _cartproductsbeltest.prodid = 16;
            //            break;
            //        case "5.3":
            //            _cartproductsbeltest.prodid = 17;
            //            break;
            //        default:
            //            _cartproductsbeltest.prodid = 18;
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
            ////DataTable dtmultifiles = (DataTable)Session["textbookebookappfiles"];    //get the multiple fileuploads from fileupload form to this form
            ////foreach (DataRow drmultiplefiles in dtmultifiles.Rows)
            ////{
            ////    _ebfileuploadbel.upfilename = drmultiplefiles["filename"].ToString();
            ////    _cartmasterbll.insertnewebfileupload(_ebfileuploadbel);
            ////}
            //#endregion

            //#region fileuploads for list

            //_ebfileuploadbel.cmid = _cartmasterbel.cmid;
            //List<ebfileuploadbel> _fluploadlist = new List<ebfileuploadbel>();//this fileupload for list
            //DataTable dtmultifiles = (DataTable)Session["textbookebookappfiles"];   //get the multiple fileuploads from fileupload form to this form
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