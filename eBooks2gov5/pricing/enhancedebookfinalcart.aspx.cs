using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;      //namespace for datatable
using eBooks2goV5.bel;  //namespace for business entity layer
using eBooks2goV5.dal;  //namespace for data access layer
using eBooks2goV5.bll;
using System.Globalization;  //namespace for business logic layer
namespace eBooks2goV5.pricing
{
    public partial class enhancedebookfinalcart : System.Web.UI.Page
    {
        #region object Instatances (References)
        bel.cartmasterbel _cartmasterbel = new bel.cartmasterbel();//object instantiation for business entity layer
        bel.cartproductsbel _cartproductsbel = new cartproductsbel();
        bel.ebfileuploadbel _ebfileuploadbel = new ebfileuploadbel();

        bll.bll _cartmasterbll = new bll.bll();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                parentrptbind();
                Bindcartvalues();
            }
        }

        #region bind parent cart
        private void parentrptbind()
       {

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
           rptParent.DataSource = (DataTable)Session["enhancedebookparentcart"];
            rptParent.DataBind();
        }
        #endregion

        #region "Hide or show edit checkbox inside datalist"
        protected string getStatus(object productid)
        {
            if (productid.ToString()!= "")
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

        protected void rptParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField hdnproductId = (HiddenField)(e.Item.FindControl("hdnproductId"));
            
            if (hdnproductId.Value.ToString() != "")
            {
                Repeater rptchild=(Repeater)(e.Item.FindControl("rptChild"));
                DataRow[] filteredRows = getvaluesfromrow((DataTable)Session["enhancedebookchildcart"], hdnproductId.Value.ToString());
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

        #region Bindvalues to cart
        private void Bindcartvalues() //display the Enhanced eBook Form values from session to cart form
        {
            DataTable dtfiles; //declaration of datatable
            if (Request.QueryString["ID"] == "1") //pass the product category's as a ID in query string,like eBook, Enhanced eBook, eBook Apps, etc.
                dtfiles = (DataTable)Session["dteBookfiles"]; //if id is eBook then store values from session datatable to eBook form datatable.
            else
                dtfiles = (DataTable)Session["dtEnhancedeBookfiles"]; //if id is Enhanced eBook then store values from session datatable to Enhanced eBook form datatable.

            lblcartid.Text = Application["cartgen"].ToString(); //generate the cartid from global.asax file.
            lblEnhancedeBooktitle.Text = dtfiles.Rows[0]["title"].ToString(); //display the title from dtfiles datatable to lbl
            lblEnhancedeBookauthor.Text = dtfiles.Rows[0]["author"].ToString(); //display the author from dtfiles datatable to lbl
            lblEnhancedeBookproduct.Text = "EnhancedeBook"; //display the product name as a static.

            lblEnhancedeBookgrandtotal.Text = roundofdecimalpoints(Convert.ToDecimal(Session["EnhancedeBookcarttotal"].ToString()) + Convert.ToDecimal(Session["EnhancedeBookdiscountonbasepkg"].ToString()));

            lblEnhancedeBookdiscountonbasepkg.Text = Session["EnhancedeBookdiscountonbasepkg"].ToString();
            lblEnhancedeBooktotaldiscount.Text = Session["EnhancedeBookcarttotal"].ToString();
            lblEnhancedeBookestimatedcartvalue.Text = Session["EnhancedeBookcarttotal"].ToString();
            lblEnhancedeBookestimatedcartvalue.Text = Session["EnhancedeBookcarttotal"].ToString();
            lblcartid.Text = Application["cartgen"].ToString();
        }
#endregion

        #region round the decimal points
        private string roundofdecimalpoints(decimal x)
        {
            return Math.Round(x, 2).ToString();
        }
        #endregion

        #region checkout imagebutton click event
        protected void imgbtnenhancedebookcheckout_Click(object sender, ImageClickEventArgs e)
        {
            //#region cartmaster
            //DataTable dtEnhancedeBookcart = (DataTable)Session["dtEnhancedeBookcart"];  //use the Enhanced ebook session values here 

            //DataTable dtfiles = (DataTable)Session["dtenhancedeBookfiles"];     //this ref is used for to get the values from fileupload to this page.

            ////fileupload start
            //_cartmasterbel.title = lblEnhancedeBooktitle.Text;
            //_cartmasterbel.author = lblEnhancedeBookauthor.Text;
            //_cartmasterbel.bworcolor = Convert.ToBoolean(Convert.ToInt16(dtfiles.Rows[0]["color"].ToString()));
            //_cartmasterbel.booklanguage = Convert.ToInt16(dtfiles.Rows[0]["booklang"].ToString());
            //_cartmasterbel.prjcompdate = Convert.ToDateTime((DateTime.ParseExact(dtfiles.Rows[0]["projectcompletedate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture)).Date.ToString("MM/dd/yyyy"));
            //_cartmasterbel.manscrpitdesc = dtfiles.Rows[0]["filedescription"].ToString();
            //_cartmasterbel.cartrefcode = Convert.ToInt16(lblcartid.Text.ToString());
            ////file upload complete

            ////ebook customizations start

            //_cartmasterbel.totalpages = getvaluesfromrow(dtEnhancedeBookcart, "4a", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "4a", 0)[0]["qty"].ToString()) : (int?)null;
            //_cartmasterbel.totalimages = getvaluesfromrow(dtEnhancedeBookcart, "4b", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "4b", 0)[0]["qty"].ToString()) : (int?)null;

            ////ebook customization complete

            ////additional elements start
            //_cartmasterbel.nestedtoc = getvaluesfromrow(dtEnhancedeBookcart, "5a", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "5a", 0)[0]["qty"].ToString())) : (Boolean?)null;
            //_cartmasterbel.dropcaps = getvaluesfromrow(dtEnhancedeBookcart, "5b", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "5b", 0)[0]["qty"].ToString())) : (Boolean?)null;
            //_cartmasterbel.coloredfonts = getvaluesfromrow(dtEnhancedeBookcart, "5c", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "5c", 0)[0]["qty"].ToString())) : (Boolean?)null;
            //_cartmasterbel.lists = getvaluesfromrow(dtEnhancedeBookcart, "5d", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "5d", 0)[0]["qty"].ToString())) : (Boolean?)null;
            //_cartmasterbel.multipleselection = getvaluesfromrow(dtEnhancedeBookcart, "5e", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "5e", 0)[0]["qty"].ToString())) : (Boolean?)null;
            //_cartmasterbel.callouts = getvaluesfromrow(dtEnhancedeBookcart, "5f", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "5f", 0)[0]["qty"].ToString())) : (Boolean?)null;
            //_cartmasterbel.doublecolumn = getvaluesfromrow(dtEnhancedeBookcart, "5g", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "5g", 0)[0]["qty"].ToString())) : (Boolean?)null;
            //_cartmasterbel.centeredtext = getvaluesfromrow(dtEnhancedeBookcart, "5h", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "5h", 0)[0]["qty"].ToString())) : (Boolean?)null;
            //_cartmasterbel.textboxboundry = getvaluesfromrow(dtEnhancedeBookcart, "5i", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "5i", 0)[0]["qty"].ToString())) : (Boolean?)null;
            ////additional elements complete

            ////audio or video elements start
            //_cartmasterbel.totalav = getvaluesfromrow(dtEnhancedeBookcart, "6", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "6", 0)[0]["qty"].ToString()) : (int?)null;
            ////audio or video elements complete

            ////text highlight start
            //_cartmasterbel.readallowedtext = getvaluesfromrow(dtEnhancedeBookcart, "7", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "7", 0)[0]["qty"].ToString()) : (int?)null;
            ////text highlight end
            ////cover design start
            //_cartmasterbel.coverdesign = getvaluesfromrow(dtEnhancedeBookcart, "8", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "8", 0)[0]["qty"].ToString())) : (Boolean?)null;
            ////cover design complete

            ////eisbn start
            //_cartproductsbel.eisbn = getvaluesfromrow(dtEnhancedeBookcart, "9", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "9", 0)[0]["qty"].ToString()) : (int?)null;
            ////eisbn complete

            ////Book publishing & Distribution Start
            //_cartmasterbel.distribution = getvaluesfromrow(dtEnhancedeBookcart, "10", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "10", 0)[0]["qty"].ToString())) : (Boolean?)null;
            ////Book publishing & Distribution complete

            ////marketing services start
            //if (getvaluesfromrow(dtEnhancedeBookcart, "11e", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "11e", 0)[0]["qty"].ToString())) : false)
            //{
            //    _cartmasterbel.socialmedia = true;
            //    _cartmasterbel.pressrelease = true;
            //    _cartmasterbel.emailcampain = true;
            //    _cartmasterbel.websiteandblog = true;
            //}
            //else
            //{
            //    _cartmasterbel.socialmedia = getvaluesfromrow(dtEnhancedeBookcart, "11a", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "11a", 0)[0]["qty"].ToString())) : (Boolean?)null;
            //    _cartmasterbel.pressrelease = getvaluesfromrow(dtEnhancedeBookcart, "11b", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "11b", 0)[0]["qty"].ToString())) : (Boolean?)null;
            //    _cartmasterbel.emailcampain = getvaluesfromrow(dtEnhancedeBookcart, "11c", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "11c", 0)[0]["qty"].ToString())) : (Boolean?)null;
            //    _cartmasterbel.websiteandblog = getvaluesfromrow(dtEnhancedeBookcart, "11d", 0)[0]["qty"].ToString() != "" ? Convert.ToBoolean(Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "11d", 0)[0]["qty"].ToString())) : (Boolean?)null;
            //}
            ////marketing services complete

            //_cartmasterbel.prodcatid = (int)(bel.bel.prodcategory.Enhaned_eBook);
            //_cartmasterbel.offerselected = Convert.ToInt32(Session["EnhancedeBookofferselected"]);

            ////_cartmasterbel.cmid = _cartmasterbll.insertnewcartmaster(_cartmasterbel);
            //_cartproductsbel.cmid = _cartmasterbel.cmid;
            //#endregion

            //#region products
            ////DataRow[] drselectedproducts = dtEnhancedeBookcart.Select("cartid IN('1','2','3') and qty='1'");
            ////foreach (DataRow drselectedproduct in drselectedproducts)
            ////{
                
            ////    switch (drselectedproduct["cartid"].ToString())
            ////    {
            ////        case "1":
            ////            _cartproductsbel.prodid = 4;
            ////            _cartproductsbel.eisbn = getvaluesfromrow(dtEnhancedeBookcart, "9a", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "9a", 0)[0]["qty"].ToString()) : 0;
            ////            break;
            ////        case "2":
            ////            _cartproductsbel.prodid = 5;
            ////            _cartproductsbel.eisbn = getvaluesfromrow(dtEnhancedeBookcart, "9b", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "9b", 0)[0]["qty"].ToString()) : 0;
            ////            break;
            ////        default:
            ////            _cartproductsbel.prodid = 6;
            ////            _cartproductsbel.eisbn = getvaluesfromrow(dtEnhancedeBookcart, "9c", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "9c", 0)[0]["qty"].ToString()) : 0;
            ////            break;
            ////    }
            ////    _cartmasterbll.insertnewcartproducts(_cartproductsbel);
            ////}

            ////DataRow[] drselectedisbn = dtEnhancedeBookcart.Select("cartid IN('9a','9b','9c') and qty='1'");
            ////foreach (DataRow drunselectedproduct in drselectedisbn)
            ////{

            ////    switch (drunselectedproduct["cartid"].ToString())
            ////    {
            ////        case "9a":
            ////            if (getvaluesfromrow(dtEnhancedeBookcart, "1", 0)[0]["qty"].ToString() == "")
            ////            {
            ////                _cartproductsbel.prodid = 4;
            ////                _cartproductsbel.eisbn = 2;
            ////                _cartmasterbll.insertnewcartproducts(_cartproductsbel);
            ////            }
            ////            break;

            ////        case "9b":
            ////            if (getvaluesfromrow(dtEnhancedeBookcart, "2", 0)[0]["qty"].ToString() == "")
            ////            {
            ////                _cartproductsbel.prodid = 5;
            ////                _cartproductsbel.eisbn = 2;
            ////                _cartmasterbll.insertnewcartproducts(_cartproductsbel);
            ////            }
            ////            break;

            ////        default:
            ////            if (getvaluesfromrow(dtEnhancedeBookcart, "3", 0)[0]["qty"].ToString() == "")
            ////            {
            ////                _cartproductsbel.prodid = 6;
            ////                _cartproductsbel.eisbn = 2;
            ////                _cartmasterbll.insertnewcartproducts(_cartproductsbel);
            ////            }
            ////            break;
            ////    }

            ////}


            //#endregion

            //#region products    
            //List<cartproductsbel> _productlist = new List<cartproductsbel>();   //this is for list

            //DataRow[] drselectedproducts = dtEnhancedeBookcart.Select("cartid IN('1','2','3') and qty='1'");    //here 1,2,3 's products like epub, mobi, pdf.
            //foreach (DataRow drselectedproduct in drselectedproducts)
            //{
            //    cartproductsbel _cartproductsbeltest = new cartproductsbel();
            //    switch (drselectedproduct["cartid"].ToString())
            //    {
            //        case "1":
            //            _cartproductsbeltest.prodid = 4;
            //            _cartproductsbeltest.eisbn = getvaluesfromrow(dtEnhancedeBookcart, "9a", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "9a", 0)[0]["qty"].ToString()) : 0;
            //            break;
            //        case "2":
            //            _cartproductsbeltest.prodid = 5;
            //            _cartproductsbeltest.eisbn = getvaluesfromrow(dtEnhancedeBookcart, "9b", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "9b", 0)[0]["qty"].ToString()) : 0;
            //            break;
            //        default:
            //            _cartproductsbeltest.prodid = 6;
            //            _cartproductsbeltest.eisbn = getvaluesfromrow(dtEnhancedeBookcart, "9c", 0)[0]["qty"].ToString() != "" ? Convert.ToInt16(getvaluesfromrow(dtEnhancedeBookcart, "9c", 0)[0]["qty"].ToString()) : 0;
            //            break;
            //    }
            //    _productlist.Add(_cartproductsbeltest);
            //    _cartproductsbeltest = null;
            //    //_cartmasterbll.insertnewcartproducts(_cartproductsbel);
            //}

            //DataRow[] drselectedisbn = dtEnhancedeBookcart.Select("cartid IN('9a','9b','9c') and qty='1'");
            //foreach (DataRow drunselectedproduct in drselectedisbn)
            //{
            //    cartproductsbel _cartproductsbeltest = new cartproductsbel();

            //    switch (drunselectedproduct["cartid"].ToString())
            //    {
            //        case "9a":
            //            if (getvaluesfromrow(dtEnhancedeBookcart, "1", 0)[0]["qty"].ToString() == "")
            //            {
            //                _cartproductsbeltest.prodid = 4;
            //                _cartproductsbeltest.eisbn = 2;
            //                //_cartmasterbll.insertnewcartproducts(_cartproductsbel);
            //                _productlist.Add(_cartproductsbeltest);

            //            }
            //            break;

            //        case "9b":
            //            if (getvaluesfromrow(dtEnhancedeBookcart, "2", 0)[0]["qty"].ToString() == "")
            //            {
            //                _cartproductsbeltest.prodid = 5;
            //                _cartproductsbeltest.eisbn = 2;
            //                //_cartmasterbll.insertnewcartproducts(_cartproductsbel);
            //                _productlist.Add(_cartproductsbeltest);
            //            }
            //            break;

            //        default:
            //            if (getvaluesfromrow(dtEnhancedeBookcart, "3", 0)[0]["qty"].ToString() == "")
            //            {
            //                _cartproductsbeltest.prodid = 6;
            //                _cartproductsbeltest.eisbn = 2;
            //                //_cartmasterbll.insertnewcartproducts(_cartproductsbel);
            //                _productlist.Add(_cartproductsbeltest);
            //            }
            //            break;
            //    }
                
            //    _cartproductsbeltest = null;
            //}

            //#endregion//this is for list

            //#region fileuploads

            ////_ebfileuploadbel.cmid = _cartmasterbel.cmid;
            ////DataTable dtmultifiles = (DataTable)Session["enhancedeBookfiles"];    //get the multiple fileuploads from fileupload form to this form
            ////foreach (DataRow drmultiplefiles in dtmultifiles.Rows)
            ////{
            ////    _ebfileuploadbel.upfilename = drmultiplefiles["filename"].ToString();
            ////    _cartmasterbll.insertnewebfileupload(_ebfileuploadbel);
            ////}
            //#endregion

            //#region fileuploads

            //_ebfileuploadbel.cmid = _cartmasterbel.cmid;
            //List<ebfileuploadbel> _fluploadlist = new List<ebfileuploadbel>();//this fileupload for list
            //DataTable dtmultifiles = (DataTable)Session["enhancedeBookfiles"];   //get the multiple fileuploads from fileupload form to this form
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

            hdnsigninvalue.Value = "1"; // here 1 means model popup visible.
            
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
    
