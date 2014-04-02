using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using eBooks2goV5.bel;  //namespace for business entity layer
using eBooks2goV5.dal;  //namespace for data access layer
using eBooks2goV5.bll;
using System.Globalization;  //namespace for business logic layer
namespace eBooks2goV5.pricing
{
    public partial class ebookinvoice : System.Web.UI.Page
    {
        #region object Instatances (References)
        bel.cartmasterbel _cartmasterbel = new bel.cartmasterbel();//object instantiation for business entity layer
        bel.cartproductsbel _cartproductsbel = new cartproductsbel();
        bel.ebfileuploadbel _ebfileuploadbel = new ebfileuploadbel();

        bll.bll _cartmasterbll = new bll.bll();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                parentrptbind();
                Bindcartvalues();
                _cartmasterbel.cmid=addcarttodb();
                getcartmaster((Int64)_cartmasterbel.cmid);
                Session.Clear();
            }
        }

        private Int64? addcarttodb()
        {
            #region cartmaster
            DataTable dteBookcart = (DataTable)Session["dteBookcart"];  //use the ebook session values here 

            DataTable dtfiles = (DataTable)Session["dteBookfiles"];     //this ref is used for to get the values from fileupload to this page.

            //fileupload start
            _cartmasterbel.title = dtfiles.Rows[0]["title"].ToString();
            _cartmasterbel.author = dtfiles.Rows[0]["author"].ToString();
            _cartmasterbel.bworcolor = Convert.ToBoolean(Convert.ToInt16(dtfiles.Rows[0]["color"].ToString()));
            _cartmasterbel.booklanguage = Convert.ToInt16(dtfiles.Rows[0]["booklang"].ToString());
            _cartmasterbel.prjcompdate = Convert.ToDateTime((DateTime.ParseExact(dtfiles.Rows[0]["projectcompletedate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture)).Date.ToString("MM/dd/yyyy"));
            _cartmasterbel.manscrpitdesc = dtfiles.Rows[0]["filedescription"].ToString();
            _cartmasterbel.cartrefcode = Convert.ToInt16(Application["cartgen"].ToString());
            //file upload complete

            //choose products start

            //choose products end

            //ebook customizations start

            _cartmasterbel.totalpages = getvaluesfromrow(dteBookcart, "4a", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dteBookcart, "4a", 0)[0]["qty"].ToString()) : (int?)null;
            _cartmasterbel.totalimages = getvaluesfromrow(dteBookcart, "4b", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dteBookcart, "4b", 0)[0]["qty"].ToString()) : (int?)null;
            _cartmasterbel.totalfenotes = getvaluesfromrow(dteBookcart, "4c", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dteBookcart, "4c", 0)[0]["qty"].ToString()) : (int?)null;
            _cartmasterbel.totalweblinks = getvaluesfromrow(dteBookcart, "4d", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dteBookcart, "4d", 0)[0]["qty"].ToString()) : (int?)null;
            //ebook customization complete

            //additional elements start
            _cartmasterbel.nestedtoc = getvaluesfromrow(dteBookcart, "5a", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dteBookcart, "5a", 0)[0]["qty"].ToString())) : (Boolean?)null;
            _cartmasterbel.dropcaps = getvaluesfromrow(dteBookcart, "5b", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dteBookcart, "5b", 0)[0]["qty"].ToString())) : (Boolean?)null;
            _cartmasterbel.coloredfonts = getvaluesfromrow(dteBookcart, "5c", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dteBookcart, "5c", 0)[0]["qty"].ToString())) : (Boolean?)null;
            _cartmasterbel.lists = getvaluesfromrow(dteBookcart, "5d", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dteBookcart, "5d", 0)[0]["qty"].ToString())) : (Boolean?)null;
            _cartmasterbel.multipleselection = getvaluesfromrow(dteBookcart, "5e", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dteBookcart, "5e", 0)[0]["qty"].ToString())) : (Boolean?)null;
            _cartmasterbel.callouts = getvaluesfromrow(dteBookcart, "5f", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dteBookcart, "5f", 0)[0]["qty"].ToString())) : (Boolean?)null;
            _cartmasterbel.doublecolumn = getvaluesfromrow(dteBookcart, "5g", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dteBookcart, "5g", 0)[0]["qty"].ToString())) : (Boolean?)null;
            _cartmasterbel.centeredtext = getvaluesfromrow(dteBookcart, "5h", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dteBookcart, "5h", 0)[0]["qty"].ToString())) : (Boolean?)null;
            _cartmasterbel.textboxboundry = getvaluesfromrow(dteBookcart, "5i", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dteBookcart, "5i", 0)[0]["qty"].ToString())) : (Boolean?)null;
            //additional elements complete

            //audio or video elements start
            _cartmasterbel.totalav = getvaluesfromrow(dteBookcart, "6", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dteBookcart, "6", 0)[0]["qty"].ToString()) : (int?)null;
            //audio or video elements complete

            //cover design start
            _cartmasterbel.coverdesign = getvaluesfromrow(dteBookcart, "7", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dteBookcart, "7", 0)[0]["qty"].ToString())) : (Boolean?)null;
            //cover design complete

            //eisbn start
            _cartproductsbel.eisbn = getvaluesfromrow(dteBookcart, "8", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dteBookcart, "8", 0)[0]["qty"].ToString()) : (int?)null;
            //eisbn complete

            //Book publishing & Distribution Start
            _cartmasterbel.distribution = getvaluesfromrow(dteBookcart, "9", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dteBookcart, "9", 0)[0]["qty"].ToString())) : (Boolean?)null;
            //Book publishing & Distribution complete

            //marketing services start
            if (getvaluesfromrow(dteBookcart, "10e", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dteBookcart, "10e", 0)[0]["qty"].ToString())) : false)
            {
                _cartmasterbel.socialmedia = true;
                _cartmasterbel.pressrelease = true;
                _cartmasterbel.emailcampain = true;
                _cartmasterbel.websiteandblog = true;
            }
            else
            {
                _cartmasterbel.socialmedia = getvaluesfromrow(dteBookcart, "10a", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dteBookcart, "10a", 0)[0]["qty"].ToString())) : (Boolean?)null;
                _cartmasterbel.pressrelease = getvaluesfromrow(dteBookcart, "10b", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dteBookcart, "10b", 0)[0]["qty"].ToString())) : (Boolean?)null;
                _cartmasterbel.emailcampain = getvaluesfromrow(dteBookcart, "10c", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dteBookcart, "10c", 0)[0]["qty"].ToString())) : (Boolean?)null;
                _cartmasterbel.websiteandblog = getvaluesfromrow(dteBookcart, "10d", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dteBookcart, "10d", 0)[0]["qty"].ToString())) : (Boolean?)null;
            }
            //marketing services complete

            _cartmasterbel.prodcatid = (int)(bel.bel.prodcategory.eBook);
            _cartmasterbel.offerselected = Convert.ToInt32((Session["eBookofferselected"]));
            _cartmasterbel.customerid = Convert.ToInt64((Session["customerid"]));
            _cartmasterbel.invoiceamt = Convert.ToDecimal(Session["eBookcarttotal"]);

            //_cartmasterbel.cmid = _cartmasterbll.insertnewcartmaster(_cartmasterbel);
            _cartproductsbel.cmid = _cartmasterbel.cmid;
            #endregion

            #region products
            List<cartproductsbel> _productlist = new List<cartproductsbel>();

            DataRow[] drselectedproducts = dteBookcart.Select("cartid IN('1','2','3') and qty='1'");    //here 1,2,3 's products like epub, mobi, pdf.
            foreach (DataRow drselectedproduct in drselectedproducts)
            {
                cartproductsbel _cartproductsbeltest = new cartproductsbel();
                _cartproductsbeltest.prodid = Convert.ToInt16(drselectedproduct["cartid"].ToString());
                switch (drselectedproduct["cartid"].ToString())
                {
                    case "1":
                        _cartproductsbeltest.eisbn = getvaluesfromrow(dteBookcart, "8a", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dteBookcart, "8a", 0)[0]["qty"].ToString()) : 0;
                        break;
                    case "2":
                        _cartproductsbeltest.eisbn = getvaluesfromrow(dteBookcart, "8b", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dteBookcart, "8b", 0)[0]["qty"].ToString()) : 0;
                        break;
                    default:
                        _cartproductsbeltest.eisbn = getvaluesfromrow(dteBookcart, "8c", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dteBookcart, "8c", 0)[0]["qty"].ToString()) : 0;
                        break;
                }
                _productlist.Add(_cartproductsbeltest);
                _cartproductsbeltest = null;
                //_cartmasterbll.insertnewcartproducts(_cartproductsbel);
            }

            DataRow[] drselectedisbn = dteBookcart.Select("cartid IN('8a','8b','8c') and qty='1'");
            foreach (DataRow drunselectedproduct in drselectedisbn)
            {
                cartproductsbel _cartproductsbeltest = new cartproductsbel();
                switch (drunselectedproduct["cartid"].ToString())
                {
                    case "8a":
                        if (getvaluesfromrow(dteBookcart, "1", 0)[0]["qty"].ToString() == "")
                        {

                            _cartproductsbeltest.prodid = 1;
                            _cartproductsbeltest.eisbn = 2;
                            //_cartmasterbll.insertnewcartproducts(_cartproductsbel);
                            _productlist.Add(_cartproductsbeltest);
                        }
                        break;

                    case "8b":
                        if (getvaluesfromrow(dteBookcart, "2", 0)[0]["qty"].ToString() == "")
                        {
                            _cartproductsbeltest.prodid = 2;
                            _cartproductsbeltest.eisbn = 2;
                            //_cartmasterbll.insertnewcartproducts(_cartproductsbel);
                            _productlist.Add(_cartproductsbeltest);
                        }
                        break;

                    default:
                        if (getvaluesfromrow(dteBookcart, "3", 0)[0]["qty"].ToString() == "")
                        {
                            _cartproductsbeltest.prodid = 3;
                            _cartproductsbeltest.eisbn = 2;
                            //_cartmasterbll.insertnewcartproducts(_cartproductsbel);
                            _productlist.Add(_cartproductsbel);
                        }
                        break;
                }

                _cartproductsbeltest = null;
            }


            #endregion

            #region fileuploads

            _ebfileuploadbel.cmid = _cartmasterbel.cmid;
            List<ebfileuploadbel> _fluploadlist = new List<ebfileuploadbel>();
            DataTable dtmultifiles = (DataTable)Session["eBookfiles"];    //get the multiple fileuploads from fileupload form to this form
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
        private static DataRow[] getvaluesfromrow(DataTable dteBookcart, string s, int Isparent = 1)
        {
            DataRow[] filteredRows;
            if (Isparent == 1)
                filteredRows = dteBookcart.Select(string.Format("{0} LIKE '%{1}%'", "parentid", s));
            else
                filteredRows = dteBookcart.Select(string.Format("{0} LIKE '%{1}%'", "cartid", s));
            return filteredRows;
        }
        #endregion

        protected void rptParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField hdnproductId = (HiddenField)(e.Item.FindControl("hdnproductId"));

            if (hdnproductId.Value.ToString() != "")
            {
                Repeater rptchild = (Repeater)(e.Item.FindControl("rptChild"));
                DataRow[] filteredRows = getvaluesfromrow((DataTable)Session["ebookchildcart"], hdnproductId.Value.ToString());
                DataTable dteBookcart = new DataTable();
                dteBookcart.Columns.Add("cartid", typeof(System.String));
                dteBookcart.Columns.Add("pcid", typeof(System.String));
                dteBookcart.Columns.Add("qty", typeof(System.String));
                dteBookcart.Columns.Add("unitcost", typeof(System.String));
                dteBookcart.Columns.Add("totalcost", typeof(System.String));
                dteBookcart.Columns.Add("parentid", typeof(System.String));
                dteBookcart.Columns.Add("productname", typeof(System.String));
                dteBookcart.Columns.Add("productid", typeof(System.String));
                dteBookcart.Columns.Add("alphaserial", typeof(System.String));
                foreach (DataRow row in filteredRows)
                {
                    dteBookcart.ImportRow(row);
                }
                rptchild.DataSource = dteBookcart;
                rptchild.DataBind();

            }
        }

        #region bind parent cart
        private void parentrptbind()
        {
          
            rptParent.DataSource = (DataTable)Session["ebookparentcart"];
            rptParent.DataBind();

        }
        #endregion

        #region Bindvalues to cart
        private void Bindcartvalues()
        {
            lblebookinvoicecustomername.Text = Session["customername"].ToString();
            lblebookinvoicecustomeraddressone.Text = Session["customeraddressone"].ToString();
            lblebookinvoicecustomeraddresstwo.Text = Session["customeraddresstwo"].ToString();
            lblebookinvoicecustomercountry.Text = Session["customercountry"].ToString();
            lblebookinvoicecustomerzipcode.Text = Session["customerzipcode"].ToString();
            lblebookinvoicesigncustomername.Text = Session["customername"].ToString();
            lblebookinvoiceinvoicesendtocustomername.Text = Session["customername"].ToString();
            lblebookinvoicetotalamount.Text = Session["eBookcarttotal"].ToString();

            lbleBookgrandtotal.Text = roundofdecimalpoints(Convert.ToDecimal(Session["eBookcarttotal"].ToString()) + Convert.ToDecimal(Session["eBookdiscountonbasepkg"].ToString()));
            lbleBookdiscountonbasepkg.Text = Session["eBookdiscountonbasepkg"].ToString();
            lbleBookestimatedproductvalue.Text = Session["eBookcarttotal"].ToString();
            lbleBookcartprice.Text = Session["eBookcarttotal"].ToString();
           
        }
        #endregion

        #region round the decimal points
        private string roundofdecimalpoints(decimal x)
        {
            return Math.Round(x, 2).ToString();
        }
        #endregion

        #region get cartmaster

        protected void getcartmaster(Int64 _cmid)
        {
            DataTable datatablegetcartmaster = new DataTable();
            
            _cartmasterbel.cmid= _cmid;
            datatablegetcartmaster = _cartmasterbll.getcartmaster(_cartmasterbel);//get all the cartmaster details from the Business Logic Layer(BLL) Class and store in datatable.

            lblebookinvoicenumber.Text = datatablegetcartmaster.Rows[0]["invoicenumber"].ToString();
            lblebookinvoicedate.Text = datatablegetcartmaster.Rows[0]["cartmastercreateddate"].ToString();
            lblebookponumber.Text = datatablegetcartmaster.Rows[0]["invoicenumber"].ToString();
        }
        #endregion

        
    }
}