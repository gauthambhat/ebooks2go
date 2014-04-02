using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using eBooks2goV5.bel;  //namespace for business entity layer
using eBooks2goV5.dal;  //namespace for data access layer
using eBooks2goV5.bll;
using System.Globalization;
using System.Data;  //namespace for business logic layer

namespace eBooks2goV5.ebookapps
{
    public partial class textbooksinvoice : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                if (Session["textbooksparentcart"] == null)
                {
                    Response.Write("<script>top.location.href='../pricingwithajaxtab.aspx';</script>");
                }
                else
                {
                    parentrptbind();
                    Bindcartvalues();
                    _cartmasterbel.cmid = addcarttodb();
                    getcartmaster((Int64)_cartmasterbel.cmid);
                    Session.Clear();
                }


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

        #region bind parent cart
        private void parentrptbind()
        {
            rptParent.DataSource = (DataTable)Session["textbooksparentcart"];
            rptParent.DataBind();

        }
        #endregion

        #region Bindvalues to invoice
        private void Bindcartvalues()
        {
            lbltextbooksinvoicecustomername.Text = Session["customername"].ToString();
            lbltextbooksinvoicecustomeraddressone.Text = Session["customeraddressone"].ToString();
            lbltextbooksinvoicecustomeraddresstwo.Text = Session["customeraddresstwo"].ToString();
            lbltextbooksinvoicecustomercountry.Text = Session["customercountry"].ToString();
            lbltextbooksinvoicecustomerzipcode.Text = Session["customerzipcode"].ToString();
            lbltextbooksinvoicesigncustomername.Text = Session["customername"].ToString();
            lbltextbooksinvoicesendtocustomername.Text = Session["customername"].ToString();
            lbltextbooksinvoicetotalamount.Text = Session["textbookscarttotal"].ToString();

            lbltextbooksgrandtotal.Text = roundofdecimalpoints(Convert.ToDecimal(Session["textbookscarttotal"].ToString()) + Convert.ToDecimal(Session["textbooksdiscountonbasepkg"].ToString()));
            lbltextbooksdiscountonbasepkg.Text = Session["textbooksdiscountonbasepkg"].ToString();
            lbltextbooksestimatedproductvalue.Text = Session["textbookscarttotal"].ToString();
            lbltextbookscartprice.Text = Session["textbookscarttotal"].ToString();

        }
        #endregion

        #region round the decimal points
        private string roundofdecimalpoints(decimal x)
        {
            return Math.Round(x, 2).ToString();
        }
        #endregion

        #region add cart to db
        private Int64? addcarttodb()
        {
            #region cartmaster
            DataTable dtfiles = (DataTable)Session["dttextbookfiles"];//this ref is used for to get the values from fileupload to this page.

            //fileupload start
            _cartmasterbel.title = dtfiles.Rows[0]["title"].ToString();
            _cartmasterbel.author = dtfiles.Rows[0]["author"].ToString();
            _cartmasterbel.bworcolor = Convert.ToBoolean(Convert.ToInt16(dtfiles.Rows[0]["color"].ToString()));
            _cartmasterbel.booklanguage = Convert.ToInt16(dtfiles.Rows[0]["booklang"].ToString());
            _cartmasterbel.prjcompdate = Convert.ToDateTime((DateTime.ParseExact(dtfiles.Rows[0]["projectcompletedate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture)).Date.ToString("MM/dd/yyyy"));
            _cartmasterbel.manscrpitdesc = dtfiles.Rows[0]["filedescription"].ToString();
            _cartmasterbel.cartrefcode = Convert.ToInt16(Application["cartgen"].ToString());
            //file upload complete

            DataTable dttextbookscart = (DataTable)Session["dttextbookscart"];//use the simple ebook apps session values here 
            //ebook customizations start
            _cartmasterbel.totalpages = getvaluesfromrow(dttextbookscart, "5a", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dttextbookscart, "5a", 0)[0]["qty"].ToString()) : (int?)null;
            _cartmasterbel.interactiveselfassessmentqa = getvaluesfromrow(dttextbookscart, "5b", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dttextbookscart, "5b", 0)[0]["qty"].ToString()) : (int?)null;
            _cartmasterbel.totalav = getvaluesfromrow(dttextbookscart, "5c", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dttextbookscart, "5c", 0)[0]["qty"].ToString()) : (int?)null;
            //ebook customization complete

            //offer selected value start
            _cartmasterbel.prodcatid = (int)(bel.bel.prodcategory.eBookappsfortextbooks);
            _cartmasterbel.offerselected = Convert.ToInt32((Session["textbooksofferselected"]));
            _cartmasterbel.customerid = Convert.ToInt64((Session["customerid"]));
            //offer selected values end
            _cartmasterbel.invoiceamt = Convert.ToDecimal(Session["textbookscarttotal"]);


            //_cartmasterbel.cmid = _cartmasterbll.insertnewcartmaster(_cartmasterbel);
            _cartproductsbel.cmid = _cartmasterbel.cmid;
            #endregion

            #region products
            //DataRow[] drselectedproducts = dttextbookscart.Select("cartid IN('5.1','5.2','5.3','5.4') and qty='1'");
            //foreach (DataRow drselectedproduct in drselectedproducts)
            //{
            //    switch (drselectedproduct["cartid"].ToString())
            //    {
            //        case "5.1":
            //            _cartproductsbel.prodid = 15;
            //            break;
            //        case "5.2":
            //            _cartproductsbel.prodid = 16;
            //            break;
            //        case "5.3":
            //            _cartproductsbel.prodid = 17;
            //            break;
            //        default:
            //            _cartproductsbel.prodid = 18;
            //            break;
            //    }
            //    _cartproductsbel.eisbn = 0;
            //    _cartmasterbll.insertnewcartproducts(_cartproductsbel);
            //}
            #endregion

            #region products for list
            List<cartproductsbel> _productlist = new List<cartproductsbel>();   //this is for list

            DataRow[] drselectedproducts = dttextbookscart.Select("cartid IN('5.1','5.2','5.3','5.4') and qty='1'");   //here 1,2,3 's products like epub, mobi, pdf.
            foreach (DataRow drselectedproduct in drselectedproducts)
            {
                cartproductsbel _cartproductsbeltest = new cartproductsbel();
                switch (drselectedproduct["cartid"].ToString())
                {
                    case "5.1":
                        _cartproductsbeltest.prodid = 15;
                        break;
                    case "5.2":
                        _cartproductsbeltest.prodid = 16;
                        break;
                    case "5.3":
                        _cartproductsbeltest.prodid = 17;
                        break;
                    default:
                        _cartproductsbeltest.prodid = 18;
                        break;
                }
                _cartproductsbeltest.eisbn = 0;
                // _cartmasterbll.insertnewcartproducts(_cartproductsbel);
                _productlist.Add(_cartproductsbeltest);
                _cartproductsbeltest = null;

            }

            #endregion

            #region fileuploads

            //_ebfileuploadbel.cmid = _cartmasterbel.cmid;
            //DataTable dtmultifiles = (DataTable)Session["textbookebookappfiles"];    //get the multiple fileuploads from fileupload form to this form
            //foreach (DataRow drmultiplefiles in dtmultifiles.Rows)
            //{
            //    _ebfileuploadbel.upfilename = drmultiplefiles["filename"].ToString();
            //    _cartmasterbll.insertnewebfileupload(_ebfileuploadbel);
            //}
            #endregion

            #region fileuploads for list

            _ebfileuploadbel.cmid = _cartmasterbel.cmid;
            List<ebfileuploadbel> _fluploadlist = new List<ebfileuploadbel>();//this fileupload for list
            DataTable dtmultifiles = (DataTable)Session["textbookebookappfiles"];   //get the multiple fileuploads from fileupload form to this form
            foreach (DataRow drmultiplefiles in dtmultifiles.Rows)
            {
                ebfileuploadbel _ebfileuploadtest = new ebfileuploadbel();
                _ebfileuploadtest.upfilename = drmultiplefiles["filename"].ToString();
                //_cartmasterbll.insertnewebfileupload(_ebfileuploadbel);
                _fluploadlist.Add(_ebfileuploadtest);
                _ebfileuploadtest = null;
            }
            #endregion

            return _cartmasterbll.insertnewcartmaster(_cartmasterbel, _productlist, _fluploadlist);
        }
        #endregion

        #region get cartmaster

        protected void getcartmaster(Int64 _cmid)
        {
            DataTable datatablegetcartmaster = new DataTable();

            _cartmasterbel.cmid = _cmid;
            datatablegetcartmaster = _cartmasterbll.getcartmaster(_cartmasterbel);//get all the cartmaster details from the Business Logic Layer(BLL) Class and store in datatable.

            lbltextbooksinvoicenumber.Text = datatablegetcartmaster.Rows[0]["invoicenumber"].ToString();
            lbltextbooksinvoicedate.Text = datatablegetcartmaster.Rows[0]["cartmastercreateddate"].ToString();
            lbltextbooksponumber.Text = datatablegetcartmaster.Rows[0]["invoicenumber"].ToString();
        }
        #endregion

    }
}