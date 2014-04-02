using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eBooks2goV5.pricing
{
    public partial class enhancedebook : System.Web.UI.Page
    {
        #region object references
        bel.bel _pcbel = new bel.bel(); // To get the variables from business entity layer(bel) class need to create this object.

        bll.bll _pcbll = new bll.bll(); // To get the business logic i.e methods from business logic layer(bll) class need to create this object.
        #endregion

        #region variables declaration
        decimal Baseprice=0;
        decimal Productprice = 0;
        decimal PagePrice = 0;
        decimal linksprice = 0;
        decimal Cartprice = 0;
        decimal isbnprice = 0;
        decimal avprice = 0;
        decimal raprice = 0;
        decimal coverdesignprice = 0;
        decimal marketingservices = 0;
        #endregion

        #region get request

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)    //if it is a first request then load the getpcid() method.
            {
                getpcid((int)bel.bel.prodcategory.Enhaned_eBook);
                if (Session["dtenhancedeBookcart"] != null)
                    bindsessionvalues();
                calculatecost();
            }
        }

        #endregion

        #region get EnhancedeBook
        protected void getpcid(int _pcid)
        {
            DataTable dtpc = new DataTable();
            _pcbel.prodid = null;
            _pcbel.pcid = _pcid;

            dtpc = _pcbll.getprodcat(_pcbel); //get all the prodcat details from the Business Logic Layer(BLL) Class and store in datatable.

            lblenhancedebookpcdpages.Text = dtpc.Rows[0]["pcdpages"].ToString();

            
            lblenhancedebookpcdhplinks.Text = dtpc.Rows[0]["pcdhplinks"].ToString();
            lblenhancedebookoffer1.Text = dtpc.Rows[0]["offer1"].ToString();
            lblenhancedebookoffer1dis.Text = dtpc.Rows[0]["offer1dis"].ToString();
            lblenhancedebookoffer2.Text = dtpc.Rows[0]["offer2"].ToString();
            lblenhancedebookoffer2dis.Text = dtpc.Rows[0]["offer2dis"].ToString();

            lblenhancedebookcustpcdpages.Text = dtpc.Rows[0]["pcdpages"].ToString();
            lblenhancedebookperpagecost.Text = dtpc.Rows[0]["perpagecost"].ToString();

            
            lblenhancedebookcustpcdhplinks.Text = dtpc.Rows[0]["pcdhplinks"].ToString();

            //lblenhancedebookcustpcdhplinks.Text = dtpc.Rows[0]["pcdhplinks"].ToString();
            lblenhancedebookweblinkscost.Text = dtpc.Rows[0]["weblinkscost"].ToString();

            lblenhancedebooktwotofourelementscost.Text = dtpc.Rows[0]["twotofourelementscost"].ToString();
            lblenhancedebookfourpluselementscost.Text = dtpc.Rows[0]["fourpluselementscost"].ToString();

            imgEnhancedeBookAVelement.Attributes.Add("title", "Each Audio/Video file insert will be charged at the rate of $" + dtpc.Rows[0]["eachavcost"].ToString() + ".This feature is currently supported only on ePUB format.Epub files with Audio/Video elements are supported by Apple, Google Android, Sony and Kobo stores ant their devices.");
            hdnEnhancedavelementcost.Value = dtpc.Rows[0]["eachavcost"].ToString();
            
            imgEnhancedeBookReadaloud.Attributes.Add("title", "Total number of words requiring Text Highlite will be charged @" + dtpc.Rows[0]["readaloudwordcost"].ToString() + "cents.");
            hdnEnhancedReadaloudcost.Value = dtpc.Rows[0]["readaloudwordcost"].ToString();
            

            lblenhancedebookscoverdesigncost.Text = dtpc.Rows[0]["scoverdesigncost"].ToString();
            lblenhancedebookhcoverdesigncost.Text = dtpc.Rows[0]["hcoverdesigncost"].ToString();

            lblenhancedebooksocialmediacost.Text = dtpc.Rows[0]["socialmediacost"].ToString();
            lblenhancedebookpressreleasecost.Text = dtpc.Rows[0]["pressreleasecost"].ToString();

            lblenhancedebookemailcampaincost.Text = dtpc.Rows[0]["emailcampaincost"].ToString();
            lblenhancedebookwebsiteblogpromotioncost.Text = dtpc.Rows[0]["websiteblogpromotioncost"].ToString();
            lblenhancedebookmarketingdiscount.Text = dtpc.Rows[0]["marketingdiscount"].ToString();

            lblenhancedebookepubeisbncost.Text = dtpc.Rows[0]["eisbncost"].ToString();
            lblenhancedebookmobieisbncost.Text = dtpc.Rows[0]["eisbncost"].ToString();
            lblenhancedebooknookeisbncost.Text = dtpc.Rows[0]["eisbncost"].ToString();
            lblmktamt.Text = dtpc.Rows[0]["mktamt"].ToString();
            dtpc = _pcbll.getproducts(_pcbel);  //get all the product details from Business Logic Layer(BLL) Class and store it in datatable.

            lblenhancedebookepub3prodcost.Text = dtpc.Rows[0]["prodcost"].ToString();
            lblenhancedebookkindleprodcost.Text = dtpc.Rows[1]["prodcost"].ToString();
            lblenhancedebooknookprodcost.Text = dtpc.Rows[2]["prodcost"].ToString();
        }
        #endregion

        #region get the page calculation
        private void calculatecost()
        {
            int count=0;
            count = getcount(pnlEnhancedeBookproducts);//get the number of products selected
            if (count > 0)
            {
                imgbtnproceed.Enabled = true;
                Baseprice = getbasecostforproduct(count, Convert.ToInt16(lblenhancedebookoffer1.Text), Convert.ToInt16(lblenhancedebookoffer2.Text));//base price for products
                Baseprice = basepricewithelements(Baseprice);
                PagePrice = getpagevalues(count);
                linksprice = gethyperlinkvalues(count);
                isbnprice = cartpricewithisbn();
                avprice = cartpricewithavelement();
                raprice = cartpricewithraelement();
                coverdesignprice = pricewithcovercheck();
                marketingservices = cartpricewithmarketingservices();
                txtEnhancedeBookbaseprice.Text = roundofdecimalpoints(Baseprice);
                Cartprice = Baseprice + PagePrice + linksprice + isbnprice + avprice + raprice + coverdesignprice + marketingservices;
                txtEnhancedeBookcartprice.Text = roundofdecimalpoints(Cartprice);
            }
            else
            { 
                //To clear all start
                clearpagevalues();
                clearlinksvalues();
                clearavvalues();
                cleartextboxes();
                //end

                //to clear all product checkbox values start
                uncheck(pnlEnhancedeBookproducts); 
                uncheck(pnlEnhancedeBookisbn);
                uncheck(pnlEnhancedeBookelements);
                uncheck(pnlEnhancedeBookmarketingservices);
                //end

                clearradiobuttons();    //to clear all radiobutton values in coverdesign and distribution & royalties section

            }
            
        }
        #endregion

        #region checkedchanged event
        protected void chkEnhancedeBookepub3_CheckedChanged(object sender, EventArgs e)
        {
            calculatecost();
        }
        #endregion

        #region calculate productprice
        private decimal getproductprice()
        {
            Productprice =(chkEnhancedeBookepub3.Checked)?Convert.ToDecimal(lblenhancedebookepub3prodcost.Text):0;
            Productprice += (chkEnhancedeBookkindle.Checked) ? Convert.ToDecimal(lblenhancedebookkindleprodcost.Text) : 0;
            Productprice += (chkEnhancedeBooknook.Checked) ? Convert.ToDecimal(lblenhancedebooknookprodcost.Text) : 0;
            return Productprice;
           
        }
        #endregion

        #region get offer or discount price
        private decimal getbasecostforproduct(int count, int offer1, int offer2)
        {
            if (count == 0)
                return 0;
            else if (count < offer1)
                Baseprice = getproductprice();
            else if (count == offer1 || count < offer2)
                Baseprice = (getproductprice()) * ((100 - Convert.ToDecimal(lblenhancedebookoffer1dis.Text.Replace(@"%", string.Empty))) / 100);
            else
                Baseprice = (getproductprice()) * ((100 - Convert.ToDecimal(lblenhancedebookoffer2dis.Text.Replace(@"%", string.Empty))) / 100);
            return Baseprice;

        }
        #endregion

        #region trim the decimal points
        private string roundofdecimalpoints(decimal x)
        {
            return Math.Round(x, 2).ToString();
        }
        #endregion

        #region offer or dicount price on elements
        private decimal basepricewithelements(decimal baseprice)
        {
            int count = getcount(pnlEnhancedeBookelements);
            baseprice = (count >= 2) ? ((count <= 4) ? (baseprice * ((100 + Convert.ToDecimal(lblenhancedebooktwotofourelementscost.Text.Replace(@"%", string.Empty))) / 100)) : (baseprice * ((100 + Convert.ToDecimal(lblenhancedebookfourpluselementscost.Text.Replace(@"%", string.Empty))) / 100))) : baseprice;
            return baseprice;
        }
        #endregion

        #region get the Additional pageprice cost
        private decimal getpagevalues(int count)
        {
            if (!string.IsNullOrEmpty(txtEnhancedeBookcustpcdpages.Text))
            {
                if (Convert.ToInt32(txtEnhancedeBookcustpcdpages.Text) > Convert.ToInt32(lblenhancedebookpcdpages.Text))
                {
                    PagePrice += count * (Convert.ToInt32(txtEnhancedeBookcustpcdpages.Text) - Convert.ToInt32(lblenhancedebookpcdpages.Text)) * ((Convert.ToDecimal(lblenhancedebookperpagecost.Text)));
                    lblEnhancedeBookpageadditionalpages.Text = (Convert.ToInt32(txtEnhancedeBookcustpcdpages.Text) - Convert.ToInt32(lblenhancedebookpcdpages.Text)).ToString();
                    lblEnhancedeBookpageadditionalunit.Text = (Convert.ToDecimal(lblenhancedebookperpagecost.Text)).ToString();
                    lblEnhancedeBookpageadditionalunitscost.Text = getaddtionalcost(Convert.ToInt32(lblEnhancedeBookpageadditionalpages.Text), Convert.ToDecimal(lblEnhancedeBookpageadditionalunit.Text), count).ToString();
                    return PagePrice;
                }
                else
                {
                    clearpagevalues();
                    return 0;
                }
            }
            else
            {
                clearpagevalues();
                return 0;
            }
        }
        #endregion

        #region clear the additional pages values
        private void clearpagevalues()
        {
            lblEnhancedeBookpageadditionalpages.Text = "";
            lblEnhancedeBookpageadditionalunit.Text = "";
            lblEnhancedeBookpageadditionalunitscost.Text = "";
        }
        #endregion

        #region get the addtional page multiplication cost
        private decimal getaddtionalcost(int additionalunits, decimal unitcost, int count)
        {
            return (additionalunits * unitcost * count);
        }
        #endregion

        #region get the checkbox count
        private int getcount(Panel ebpanel)
        {
            int i = 0;
            foreach (var ctrl in ebpanel.Controls)
            {
                if (ctrl is CheckBox && ((CheckBox)ctrl).Checked)
                {
                    i++;
                }
            }
            return i;

        }
        #endregion

        #region get the additional links cost
        private decimal gethyperlinkvalues(int count)
        {
            if (!string.IsNullOrEmpty(txtEnhancedeBookcustpcdhplinks.Text))
            {
                if (Convert.ToInt32(txtEnhancedeBookcustpcdhplinks.Text) > Convert.ToInt32(lblenhancedebookcustpcdhplinks.Text))
                {
                    linksprice += count * (Convert.ToInt32(txtEnhancedeBookcustpcdhplinks.Text) - Convert.ToInt32(lblenhancedebookcustpcdhplinks.Text)) * ((Convert.ToDecimal(lblenhancedebookweblinkscost.Text)) / 100);
                    lblEnhancedeBooklinksadditionallinks.Text = (Convert.ToInt32(txtEnhancedeBookcustpcdhplinks.Text) - Convert.ToInt32(lblenhancedebookcustpcdhplinks.Text)).ToString();
                    lblEnhancedeBooklinksadditionalunits.Text = (Convert.ToDecimal(lblenhancedebookweblinkscost.Text) / 100).ToString();
                    lblEnhancedeBooklinksadditionalunitscost.Text = getaddtionalcost(Convert.ToInt32(lblEnhancedeBooklinksadditionallinks.Text), Convert.ToDecimal(lblEnhancedeBooklinksadditionalunits.Text), count).ToString();
                    return linksprice;
                }
                else
                {
                    clearlinksvalues();
                    return 0;
                }
            }
            else
            {
                clearlinksvalues();
                return 0;
            }
        }

        #endregion

        #region clear all the additional link values
        private void clearlinksvalues()
        {
            lblEnhancedeBooklinksadditionallinks.Text = "";
            lblEnhancedeBooklinksadditionalunits.Text = "";
            lblEnhancedeBooklinksadditionalunitscost.Text = "";
        }
        #endregion

        #region get the isbn cost
        private decimal cartpricewithisbn()
        {
            int count = getcount(pnlEnhancedeBookisbn);
            isbnprice += Convert.ToDecimal(lblenhancedebookepubeisbncost.Text) * count;
            return isbnprice;
        }
        #endregion

        #region Does Your Book Need Audio/Video Elements
        private decimal cartpricewithavelement()
        {
            if (!string.IsNullOrEmpty(txtEnhancedeBookavcost.Text))
            {
                avprice += Convert.ToDecimal(hdnEnhancedavelementcost.Value) * Convert.ToDecimal(txtEnhancedeBookavcost.Text);
                lblEnhancedeBookavunitcost.Text = hdnEnhancedavelementcost.Value.ToString();
                lblEnhancedeBookavtotalcost.Text = avprice.ToString();
                return avprice;
            }
            else
            {
                clearavvalues();
                return 0;
            }
        }
        #endregion

        #region clear audio and video element values
        private void clearavvalues()
        {
            lblEnhancedeBookavunitcost.Text = "";
            lblEnhancedeBookavtotalcost.Text = "";
        }
        #endregion

        #region Does your book need Read Aloud with Text High light
        private decimal cartpricewithraelement()
        {
            if (!string.IsNullOrEmpty(txtEnhancedeBookReadaloud.Text))
            {
                raprice = Convert.ToDecimal(hdnEnhancedReadaloudcost.Value) * Convert.ToDecimal(txtEnhancedeBookReadaloud.Text)/100;
                lblEnhancedeBookReadaloudunitcost.Text = hdnEnhancedReadaloudcost.Value.ToString();
                lblEnhancedeBookReadaloudtotalcost.Text = raprice.ToString();
                return raprice;
            }
            else
            {
                clearravalues();
                return 0;
            }
        }
        #endregion

        #region clear Read Aloud Values
        private void clearravalues()
        {
            lblEnhancedeBookReadaloudunitcost.Text = "";
            lblEnhancedeBookReadaloudtotalcost.Text = "";
        }
        #endregion

        #region Does your Book need Cover design
        private decimal pricewithcovercheck()
        {
            coverdesignprice = (rbEnhancedeBookSimpleDesign.Checked) ? Convert.ToDecimal(lblenhancedebookscoverdesigncost.Text) : ((rbEnhancedeBookHIDesign.Checked) ? Convert.ToDecimal(lblenhancedebookhcoverdesigncost.Text) : 0);
            return coverdesignprice;
        }
        #endregion

        #region Marketing Services
        private decimal cartpricewithmarketingservices()
        {
            int count = getcount(pnlEnhancedeBookmarketingservices);
            if (count >= 4 || chkEnhancedeBookmarketing.Checked)
            {
                //chkeBookmarketing.Checked = true;\\to remove check and uncheck all functionality.
                marketingservices = Convert.ToDecimal(lblmktamt.Text.Replace(@"%", string.Empty));
            }
            else if (count > 0)
            {
                marketingservices = (chkEnhancedeBooksocialmediasetup.Checked) ? Convert.ToDecimal(lblenhancedebooksocialmediacost.Text) : 0;
                marketingservices += (chkEnhancedeBookpressrelease.Checked) ? Convert.ToDecimal(lblenhancedebookpressreleasecost.Text) : 0;
                marketingservices += (chkEnhancedeBookemailcampaign.Checked) ? Convert.ToDecimal(lblenhancedebookemailcampaincost.Text) : 0;
            }
            return marketingservices;
        }
        #endregion

        #region clear all the textboxes
        private void cleartextboxes()
        {
            txtEnhancedeBookavcost.Text = "";
            txtEnhancedeBookbaseprice.Text = "";
            txtEnhancedeBookcartprice.Text = "";
            txtEnhancedeBookcustpcdhplinks.Text = "";
            txtEnhancedeBookcustpcdpages.Text = "";
            txtEnhancedeBookReadaloud.Text = "";
            imgbtnproceed.Enabled = false; 
            
        }
        #endregion

        #region proceed imagebutton click event
        protected void imgbtnproceed_Click(object sender, ImageClickEventArgs e)
        {
            storeinCart();
            //Response.Redirect("~/pricing/flupload.aspx?ID=2");
              Response.Redirect("~/pricing/fileupload.aspx?ID=2");
        }
        #endregion

        #region storein session
        private void storeinCart()
        {
            Session["dtenhancedeBookcart"] = null;  //after moving the values from session to eBook form then session should be cleared.
            //if (Session["dteBookcart"] == null)
            //{
            DataTable dtenhancedeBookcart = new DataTable();

            dtenhancedeBookcart.Columns.Add("cartid", typeof(System.String));
            dtenhancedeBookcart.Columns.Add("pcid", typeof(System.String));
            dtenhancedeBookcart.Columns.Add("qty", typeof(System.String));
            dtenhancedeBookcart.Columns.Add("unitcost", typeof(System.String));
            dtenhancedeBookcart.Columns.Add("totalcost", typeof(System.String));
            dtenhancedeBookcart.Columns.Add("parentid", typeof(System.String));
            dtenhancedeBookcart.Columns.Add("productname", typeof(System.String));
            dtenhancedeBookcart.Columns.Add("productid", typeof(System.String));
            addtosession(dtenhancedeBookcart);
            //}
            //else
            //{
            //    DataTable dteBookcart=(DataTable)Session["dteBookcart"];
            //    addtosession(dteBookcart);
            //}
        }
        #endregion

        private void addtosession(DataTable dtenhancedeBookcart)
        {
            int CustCount = 0;
            int AdditionalElements = 0;

            #region Add epub product to cart
            if (chkEnhancedeBookepub3.Checked)
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "1";
                dr["pcid"] = "2";
                dr["qty"] = "1";
                dr["productname"] = "ePUB";
                dr["unitcost"] = Convert.ToDecimal(lblenhancedebookepub3prodcost.Text);
                dr["totalcost"] = Convert.ToDecimal(lblenhancedebookepub3prodcost.Text);
                dtenhancedeBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "1";
                dr["pcid"] = "2";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }

            #endregion

            #region Add EnhancedeBook mobi to cart
            if (chkEnhancedeBookkindle.Checked)
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "2";
                dr["pcid"] = "2";
                dr["qty"] = "1";
                dr["productname"] = "Mobi";
                dr["unitcost"] = Convert.ToDecimal(lblenhancedebookkindleprodcost.Text);
                dr["totalcost"] = Convert.ToDecimal(lblenhancedebookkindleprodcost.Text);
                dtenhancedeBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "2";
                dr["pcid"] = "2";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }

            #endregion

            #region Add chkenhancedebook nook to cart

            if (chkEnhancedeBooknook.Checked)
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "3";
                dr["pcid"] = "2";
                dr["qty"] = "1";
                dr["productname"] = "Nook";
                dr["unitcost"] = Convert.ToDecimal(lblenhancedebooknookprodcost.Text);
                dr["totalcost"] = Convert.ToDecimal(lblenhancedebooknookprodcost.Text);
                dtenhancedeBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "3";
                dr["pcid"] = "2";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            #endregion

            if (!string.IsNullOrEmpty(txtEnhancedeBookcustpcdpages.Text))
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "4a";
                dr["pcid"] = "2";
                CustCount++;
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["productname"] = "Total Number of pages in the Book";
                dr["qty"] = txtEnhancedeBookcustpcdpages.Text;
                dr["unitcost"] = lblenhancedebookperpagecost.Text;
                dr["totalcost"] = lblEnhancedeBookpageadditionalunitscost.Text; 
                dtenhancedeBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "4a";
                dr["pcid"] = "2";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            if (!string.IsNullOrEmpty(txtEnhancedeBookcustpcdhplinks.Text))
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "4b";
                dr["pcid"] = "2";
                CustCount++;
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["productname"] = "Total Number of web links, Hyperlinks, email links";
                dr["qty"] = txtEnhancedeBookcustpcdhplinks.Text;
                dr["unitcost"] = lblenhancedebookweblinkscost.Text;
                dr["totalcost"] = lblEnhancedeBooklinksadditionalunitscost.Text;
                dtenhancedeBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "4b";
                dr["pcid"] = "2";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }

            if (CustCount > 0)
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "4";
                dr["pcid"] = "1";
                dr["qty"] = "1";
                dr["productid"] = (char)(bel.bel.parentid.Customisations);
                dr["productname"] = "Customisations";
                dr["parentid"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "4";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["productname"] = "Customisations";
                dr["parentid"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }

            #region elements
            if (chkEnhancedeBooknestedtoc.Checked)
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "5a";
                dr["pcid"] = "2";
                dr["qty"] = "1";
                AdditionalElements++;
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["productname"] = "Nested TOC";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "5a";
                dr["pcid"] = "2";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }

            if (chkEnhancedeBookdropcaps.Checked)
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "5b";
                dr["pcid"] = "2";
                dr["qty"] = "1";
                AdditionalElements++;
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["productname"] = "Drop Caps";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "5b";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            if (chkEnhancedeBookcoloredfonts.Checked)
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "5c";
                dr["pcid"] = "2";
                AdditionalElements++;
                dr["qty"] = "1";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["productname"] = "Colored Fonts";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "5c";
                dr["pcid"] = "2";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            if (chkEnhancedeBooklists.Checked)
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "5d";
                dr["pcid"] = "2";
                dr["qty"] = "1";
                AdditionalElements++;
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["productname"] = "Lists";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "5d";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            if (chkEnhancedeBooksections.Checked)
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "5e";
                dr["pcid"] = "2";
                AdditionalElements++;
                dr["qty"] = "1";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["productname"] = "Multiple Sections and Sub-Sections";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "5e";
                dr["pcid"] = "2";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            if (chkEnhancedeBookcallouts.Checked)
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "5f";
                dr["pcid"] = "2";
                AdditionalElements++;
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["productname"] = "Call Outs";
                dr["qty"] = "1";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "5f";
                dr["pcid"] = "2";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            if (chkEnhancedeBookdoublecolumntext.Checked)
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "5g";
                dr["pcid"] = "2";
                AdditionalElements++;
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["productname"] = "Double Column Text";
                dr["qty"] = "1";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "5g";
                dr["pcid"] = "2";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            if (chkEnhancedeBookcenteredtext.Checked)
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "5h";
                dr["pcid"] = "2";
                AdditionalElements++;
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["productname"] = "Centered Text";
                dr["qty"] = "1";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "5h";
                dr["pcid"] = "2";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            if (chkEnhancedeBookbvcolors.Checked)
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "5i";
                dr["pcid"] = "2";
                AdditionalElements++;
                dr["qty"] = "1";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["productname"] = "Text boxes with borders/varying colors";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "5i";
                dr["pcid"] = "2";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            #endregion

            if (AdditionalElements > 0)
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "5";
                dr["pcid"] = "1";
                dr["qty"] = "1";
                dr["productid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["productname"] = "Additional elements";
                dr["parentid"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "5";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["productname"] = "Additional elements";
                dr["parentid"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }

            #region audio and video elements
            if (!string.IsNullOrEmpty(txtEnhancedeBookavcost.Text))
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "6";
                dr["pcid"] = "2";
                dr["productname"] = "Audio & Video elements";
                dr["qty"] = txtEnhancedeBookavcost.Text;
                dr["unitcost"] = lblEnhancedeBookavunitcost.Text;
                dr["totalcost"] = lblEnhancedeBookavtotalcost.Text;
                dtenhancedeBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "6";
                dr["pcid"] = "2";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            #endregion

            #region read aloud text high lights
            if (!string.IsNullOrEmpty(txtEnhancedeBookReadaloud.Text))
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "7";
                dr["pcid"] = "2";
                dr["productname"] = "Text High Lights";
                dr["qty"] = txtEnhancedeBookReadaloud.Text;
                dr["unitcost"] = lblEnhancedeBookReadaloudunitcost.Text;
                dr["totalcost"] = lblEnhancedeBookReadaloudtotalcost.Text;
                dtenhancedeBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "7";
                dr["pcid"] = "2";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            #endregion

            #region coverdesign
            if (rbEnhancedeBookSimpleDesign.Checked || rbEnhancedeBookHIDesign.Checked)
            {
                if (rbEnhancedeBookSimpleDesign.Checked)
                {
                    DataRow drcover = dtenhancedeBookcart.NewRow();
                    drcover["cartid"] = "8";
                    drcover["pcid"] = "2";
                    drcover["qty"] = "1";
                    drcover["productname"] = "Cover design";
                    drcover["unitcost"] = lblenhancedebookscoverdesigncost.Text;
                    drcover["totalcost"] = lblenhancedebookscoverdesigncost.Text;
                    dtenhancedeBookcart.Rows.Add(drcover);

                    DataRow dr = dtenhancedeBookcart.NewRow();
                    dr["cartid"] = "8a";
                    dr["pcid"] = "2";
                    dr["qty"] = "1";
                    dr["productname"] = "";
                    dr["unitcost"] = lblenhancedebookscoverdesigncost.Text;
                    dr["totalcost"] = lblenhancedebookscoverdesigncost.Text;
                    dtenhancedeBookcart.Rows.Add(dr);
                }
                else
                {
                    DataRow dr = dtenhancedeBookcart.NewRow();
                    dr["cartid"] = "8a";
                    dr["pcid"] = "2";
                    dr["qty"] = "";
                    dr["unitcost"] = "";
                    dr["totalcost"] = "";
                    dtenhancedeBookcart.Rows.Add(dr);
                }

                if (rbEnhancedeBookHIDesign.Checked)
                {
                    DataRow drcover = dtenhancedeBookcart.NewRow();
                    drcover["cartid"] = "8";
                    drcover["pcid"] = "2";
                    drcover["qty"] = "1";
                    drcover["productname"] = "Cover design";
                    drcover["unitcost"] = lblenhancedebookhcoverdesigncost.Text;
                    drcover["totalcost"] = lblenhancedebookhcoverdesigncost.Text;
                    dtenhancedeBookcart.Rows.Add(drcover);

                    DataRow dr = dtenhancedeBookcart.NewRow();
                    dr["cartid"] = "8b";
                    dr["pcid"] = "2";
                    dr["qty"] = "1";
                    dr["productname"] = "Cover design";
                    dr["unitcost"] = lblenhancedebookhcoverdesigncost.Text;
                    dr["totalcost"] = lblenhancedebookhcoverdesigncost.Text;
                    dtenhancedeBookcart.Rows.Add(dr);
                }
                else
                {
                    DataRow drsimple = dtenhancedeBookcart.NewRow();
                    drsimple["cartid"] = "8b";
                    drsimple["pcid"] = "2";
                    drsimple["qty"] = "";
                    drsimple["unitcost"] = "";
                    drsimple["totalcost"] = "";
                    dtenhancedeBookcart.Rows.Add();

                }
            }
            else
            {
                DataRow drcover = dtenhancedeBookcart.NewRow();
                drcover["cartid"] = "8";
                drcover["pcid"] = "2";
                drcover["qty"] = "";
                drcover["productname"] = "Cover design";
                drcover["unitcost"] = "";
                drcover["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(drcover);
                DataRow drsimple = dtenhancedeBookcart.NewRow();
                drsimple["cartid"] = "8a";
                drsimple["pcid"] = "2";
                drsimple["qty"] = "";
                drsimple["unitcost"] = "";
                drsimple["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(drsimple);
                DataRow drHigh = dtenhancedeBookcart.NewRow();
                drHigh["cartid"] = "8b";
                drHigh["pcid"] = "1";
                drHigh["qty"] = "";
                drHigh["unitcost"] = "";
                drHigh["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(drHigh);
            }
            #endregion

            #region eisbn
            if (chkEnhancedeBookisbnepub.Checked || chkEnhancedeBookisbnmobi.Checked || chkEnhancedeBookisbnnook.Checked)
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                decimal eisbncost = 0;
                eisbncost += (chkEnhancedeBookisbnepub.Checked) ? Convert.ToDecimal(lblenhancedebookepubeisbncost.Text) : 0;
                eisbncost += (chkEnhancedeBookisbnmobi.Checked) ? Convert.ToDecimal(lblenhancedebookepubeisbncost.Text) : 0;
                eisbncost += (chkEnhancedeBookisbnnook.Checked) ? Convert.ToDecimal(lblenhancedebookepubeisbncost.Text) : 0;
                dr["cartid"] = "9";
                dr["pcid"] = "2";
                dr["qty"] = (eisbncost / Convert.ToDecimal(lblenhancedebookepubeisbncost.Text)).ToString();
                dr["unitcost"] = lblenhancedebookepubeisbncost.Text;
                dr["totalcost"] = eisbncost.ToString();
                dr["productname"] = "EISBN";
                dtenhancedeBookcart.Rows.Add(dr);
                if (chkEnhancedeBookisbnepub.Checked)
                {
                    DataRow drEnhancedeBookepubisbn = dtenhancedeBookcart.NewRow();
                    drEnhancedeBookepubisbn["cartid"] = "9a";
                    drEnhancedeBookepubisbn["pcid"] = "2";
                    drEnhancedeBookepubisbn["qty"] = "1";
                    drEnhancedeBookepubisbn["unitcost"] = "";
                    drEnhancedeBookepubisbn["totalcost"] = "";
                    dtenhancedeBookcart.Rows.Add(drEnhancedeBookepubisbn);
                }
                else
                {
                    DataRow drEnhancedeBookepubisbn = dtenhancedeBookcart.NewRow();
                    drEnhancedeBookepubisbn["cartid"] = "9a";
                    drEnhancedeBookepubisbn["pcid"] = "2";
                    drEnhancedeBookepubisbn["qty"] = "";
                    drEnhancedeBookepubisbn["unitcost"] = "";
                    drEnhancedeBookepubisbn["totalcost"] = "";
                    dtenhancedeBookcart.Rows.Add(drEnhancedeBookepubisbn);
                }

                if (chkEnhancedeBookisbnmobi.Checked)
                {
                    DataRow drEnhancedeBookmobieisbn = dtenhancedeBookcart.NewRow();
                    drEnhancedeBookmobieisbn["cartid"] = "9b";
                    drEnhancedeBookmobieisbn["pcid"] = "2";
                    drEnhancedeBookmobieisbn["qty"] = "1";
                    drEnhancedeBookmobieisbn["unitcost"] = "";
                    drEnhancedeBookmobieisbn["totalcost"] = "";
                    dtenhancedeBookcart.Rows.Add(drEnhancedeBookmobieisbn);
                }
                else
                {
                    DataRow drEnhancedeBookmobieisbn = dtenhancedeBookcart.NewRow();
                    drEnhancedeBookmobieisbn["cartid"] = "9b";
                    drEnhancedeBookmobieisbn["pcid"] = "2";
                    drEnhancedeBookmobieisbn["qty"] = "";
                    drEnhancedeBookmobieisbn["unitcost"] = "";
                    drEnhancedeBookmobieisbn["totalcost"] = "";
                    dtenhancedeBookcart.Rows.Add(drEnhancedeBookmobieisbn);
                }
                if (chkEnhancedeBookisbnnook.Checked)
                {
                    DataRow drEnhancedeBookenookisbn = dtenhancedeBookcart.NewRow();
                    drEnhancedeBookenookisbn["cartid"] = "9c";
                    drEnhancedeBookenookisbn["pcid"] = "2";
                    drEnhancedeBookenookisbn["qty"] = "1";
                    drEnhancedeBookenookisbn["unitcost"] = "";
                    drEnhancedeBookenookisbn["totalcost"] = "";
                    dtenhancedeBookcart.Rows.Add(drEnhancedeBookenookisbn);
                }
                else
                {
                    DataRow drEnhancedeBookenookisbn = dtenhancedeBookcart.NewRow();
                    drEnhancedeBookenookisbn["cartid"] = "9c";
                    drEnhancedeBookenookisbn["pcid"] = "2";
                    drEnhancedeBookenookisbn["qty"] = "";
                    drEnhancedeBookenookisbn["unitcost"] = "";
                    drEnhancedeBookenookisbn["totalcost"] = "";
                    dtenhancedeBookcart.Rows.Add(drEnhancedeBookenookisbn);
                }



            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "9";
                dr["pcid"] = "2";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);

                DataRow drEnhancedeBookepubisbn = dtenhancedeBookcart.NewRow();
                drEnhancedeBookepubisbn["cartid"] = "9a";
                drEnhancedeBookepubisbn["pcid"] = "2";
                drEnhancedeBookepubisbn["qty"] = "";
                drEnhancedeBookepubisbn["unitcost"] = "";
                drEnhancedeBookepubisbn["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(drEnhancedeBookepubisbn);


                DataRow drEnhancedeBookmobieisbn = dtenhancedeBookcart.NewRow();
                drEnhancedeBookmobieisbn["cartid"] = "9b";
                drEnhancedeBookmobieisbn["pcid"] = "2";
                drEnhancedeBookmobieisbn["qty"] = "";
                drEnhancedeBookmobieisbn["unitcost"] = "";
                drEnhancedeBookmobieisbn["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(drEnhancedeBookmobieisbn);

                DataRow drEnhancedeBookenookisbn = dtenhancedeBookcart.NewRow();
                drEnhancedeBookenookisbn["cartid"] = "9c";
                drEnhancedeBookenookisbn["pcid"] = "2";
                drEnhancedeBookenookisbn["qty"] = "";
                drEnhancedeBookenookisbn["unitcost"] = "";
                drEnhancedeBookenookisbn["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(drEnhancedeBookenookisbn);

            }
            #endregion

            #region book publishing and distribution
            if (rbEnhancedeBookdistagent.Checked)
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "10";
                dr["pcid"] = "2";
                dr["qty"] = "1";
                dr["productname"] = "Book publishing & Distribution";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "10";
                dr["pcid"] = "2";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);
            }
            #endregion

            #region marketing price
            if (chkEnhancedeBooksocialmediasetup.Checked || chkEnhancedeBookpressrelease.Checked || chkEnhancedeBookemailcampaign.Checked || chkEnhancedeBookwebsitepromotion.Checked || chkEnhancedeBookmarketing.Checked)
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                decimal marketingprice = 0;
                int count = 0;
                count = getcount(pnlEnhancedeBookmarketingservices);
                if (count == 4 || chkEnhancedeBookmarketing.Checked)
                {
                    marketingprice += Convert.ToDecimal(lblmktamt.Text);
                    dr["qty"] = 4;
                }
                else
                {
                    marketingprice += (chkEnhancedeBooksocialmediasetup.Checked) ? Convert.ToDecimal(lblenhancedebooksocialmediacost.Text) : 0;
                    marketingprice += (chkEnhancedeBookpressrelease.Checked) ? Convert.ToDecimal(lblenhancedebookpressreleasecost.Text) : 0;
                    marketingprice += (chkEnhancedeBookemailcampaign.Checked) ? Convert.ToDecimal(lblenhancedebookemailcampaincost.Text) : 0;
                    marketingprice += (chkEnhancedeBookwebsitepromotion.Checked) ? Convert.ToDecimal(lblenhancedebookwebsiteblogpromotioncost.Text) : 0;
                    dr["qty"] = count.ToString();
                }
                dr["cartid"] = "11";
                dr["pcid"] = "2";
                dr["unitcost"] = lblenhancedebookemailcampaincost.Text;
                dr["totalcost"] = marketingprice.ToString();
                dr["productname"] = "Marketing services";
                dtenhancedeBookcart.Rows.Add(dr);

                if (chkEnhancedeBooksocialmediasetup.Checked)
                {
                    DataRow drEnhancedeBooksocialmediasetup = dtenhancedeBookcart.NewRow();
                    drEnhancedeBooksocialmediasetup["cartid"] = "11a";
                    drEnhancedeBooksocialmediasetup["pcid"] = "2";
                    drEnhancedeBooksocialmediasetup["qty"] = "1";
                    drEnhancedeBooksocialmediasetup["unitcost"] = "";
                    drEnhancedeBooksocialmediasetup["totalcost"] = "";
                    dtenhancedeBookcart.Rows.Add(drEnhancedeBooksocialmediasetup);
                }
                else
                {
                    DataRow drEnhancedeBooksocialmediasetup = dtenhancedeBookcart.NewRow();
                    drEnhancedeBooksocialmediasetup["cartid"] = "11a";
                    drEnhancedeBooksocialmediasetup["pcid"] = "2";
                    drEnhancedeBooksocialmediasetup["qty"] = "";
                    drEnhancedeBooksocialmediasetup["unitcost"] = "";
                    drEnhancedeBooksocialmediasetup["totalcost"] = "";
                    dtenhancedeBookcart.Rows.Add(drEnhancedeBooksocialmediasetup);
                }
                if (chkEnhancedeBookpressrelease.Checked)
                {
                    DataRow drEnhancedeBookpressrelease = dtenhancedeBookcart.NewRow();
                    drEnhancedeBookpressrelease["cartid"] = "11b";
                    drEnhancedeBookpressrelease["pcid"] = "2";
                    drEnhancedeBookpressrelease["qty"] = "1";
                    drEnhancedeBookpressrelease["unitcost"] = "";
                    drEnhancedeBookpressrelease["totalcost"] = "";
                    dtenhancedeBookcart.Rows.Add(drEnhancedeBookpressrelease);
                }
                else
                {
                    DataRow drEnhancedeBookpressrelease = dtenhancedeBookcart.NewRow();
                    drEnhancedeBookpressrelease["cartid"] = "11b";
                    drEnhancedeBookpressrelease["pcid"] = "2";
                    drEnhancedeBookpressrelease["qty"] = "";
                    drEnhancedeBookpressrelease["unitcost"] = "";
                    drEnhancedeBookpressrelease["totalcost"] = "";
                    dtenhancedeBookcart.Rows.Add(drEnhancedeBookpressrelease);
                }

                if (chkEnhancedeBookemailcampaign.Checked)
                {
                    DataRow drEnhancedeBookemailcampaign = dtenhancedeBookcart.NewRow();
                    drEnhancedeBookemailcampaign["cartid"] = "11c";
                    drEnhancedeBookemailcampaign["pcid"] = "2";
                    drEnhancedeBookemailcampaign["qty"] = "1";
                    drEnhancedeBookemailcampaign["unitcost"] = "";
                    drEnhancedeBookemailcampaign["totalcost"] = "";
                    dtenhancedeBookcart.Rows.Add(drEnhancedeBookemailcampaign);
                }
                else
                {
                    DataRow drEnhancedeBookemailcampaign = dtenhancedeBookcart.NewRow();
                    drEnhancedeBookemailcampaign["cartid"] = "11c";
                    drEnhancedeBookemailcampaign["pcid"] = "2";
                    drEnhancedeBookemailcampaign["qty"] = "";
                    drEnhancedeBookemailcampaign["unitcost"] = "";
                    drEnhancedeBookemailcampaign["totalcost"] = "";
                    dtenhancedeBookcart.Rows.Add(drEnhancedeBookemailcampaign);
                }

                if (chkEnhancedeBookwebsitepromotion.Checked)
                {
                    DataRow drEnhancedeBookwebsitepromotion = dtenhancedeBookcart.NewRow();
                    drEnhancedeBookwebsitepromotion["cartid"] = "11d";
                    drEnhancedeBookwebsitepromotion["pcid"] = "2";
                    drEnhancedeBookwebsitepromotion["qty"] = "1";
                    drEnhancedeBookwebsitepromotion["unitcost"] = "";
                    drEnhancedeBookwebsitepromotion["totalcost"] = "";
                    dtenhancedeBookcart.Rows.Add(drEnhancedeBookwebsitepromotion);
                }
                else
                {
                    DataRow drEnhancedeBookwebsitepromotion = dtenhancedeBookcart.NewRow();
                    drEnhancedeBookwebsitepromotion["cartid"] = "11d";
                    drEnhancedeBookwebsitepromotion["pcid"] = "2";
                    drEnhancedeBookwebsitepromotion["qty"] = "";
                    drEnhancedeBookwebsitepromotion["unitcost"] = "";
                    drEnhancedeBookwebsitepromotion["totalcost"] = "";
                    dtenhancedeBookcart.Rows.Add(drEnhancedeBookwebsitepromotion);
                }

                if (chkEnhancedeBookmarketing.Checked)
                {
                    DataRow drEnhancedeBookmarketing = dtenhancedeBookcart.NewRow();
                    drEnhancedeBookmarketing["cartid"] = "11e";
                    drEnhancedeBookmarketing["pcid"] = "2";
                    drEnhancedeBookmarketing["qty"] = "5";
                    drEnhancedeBookmarketing["unitcost"] = "";
                    drEnhancedeBookmarketing["totalcost"] = "";
                    dtenhancedeBookcart.Rows.Add(drEnhancedeBookmarketing);
                }
                else
                {
                    DataRow drEnhancedeBookmarketing = dtenhancedeBookcart.NewRow();
                    drEnhancedeBookmarketing["cartid"] = "11e";
                    drEnhancedeBookmarketing["pcid"] = "2";
                    drEnhancedeBookmarketing["qty"] = "";
                    drEnhancedeBookmarketing["unitcost"] = "";
                    drEnhancedeBookmarketing["totalcost"] = "";
                    dtenhancedeBookcart.Rows.Add(drEnhancedeBookmarketing);
                }


            }
            else
            {
                DataRow dr = dtenhancedeBookcart.NewRow();
                dr["cartid"] = "11";
                dr["pcid"] = "2";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(dr);

                DataRow drEnhancedeBooksocialmediasetup = dtenhancedeBookcart.NewRow();
                drEnhancedeBooksocialmediasetup["cartid"] = "11a";
                drEnhancedeBooksocialmediasetup["pcid"] = "2";
                drEnhancedeBooksocialmediasetup["qty"] = "";
                drEnhancedeBooksocialmediasetup["unitcost"] = "";
                drEnhancedeBooksocialmediasetup["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(drEnhancedeBooksocialmediasetup);

                DataRow drEnhancedeBookpressrelease = dtenhancedeBookcart.NewRow();
                drEnhancedeBookpressrelease["cartid"] = "11b";
                drEnhancedeBookpressrelease["pcid"] = "2";
                drEnhancedeBookpressrelease["qty"] = "";
                drEnhancedeBookpressrelease["unitcost"] = "";
                drEnhancedeBookpressrelease["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(drEnhancedeBookpressrelease);

                DataRow drEnhancedeBookemailcampaign = dtenhancedeBookcart.NewRow();
                drEnhancedeBookemailcampaign["cartid"] = "11c";
                drEnhancedeBookemailcampaign["pcid"] = "2";
                drEnhancedeBookemailcampaign["qty"] = "";
                drEnhancedeBookemailcampaign["unitcost"] = "";
                drEnhancedeBookemailcampaign["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(drEnhancedeBookemailcampaign);

                DataRow drEnhancedeBookwebsitepromotion = dtenhancedeBookcart.NewRow();
                drEnhancedeBookwebsitepromotion["cartid"] = "11d";
                drEnhancedeBookwebsitepromotion["pcid"] = "2";
                drEnhancedeBookwebsitepromotion["qty"] = "";
                drEnhancedeBookwebsitepromotion["unitcost"] = "";
                drEnhancedeBookwebsitepromotion["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(drEnhancedeBookwebsitepromotion);

                DataRow drEnhancedeBookmarketing = dtenhancedeBookcart.NewRow();
                drEnhancedeBookmarketing["cartid"] = "11e";
                drEnhancedeBookmarketing["pcid"] = "2";
                drEnhancedeBookmarketing["qty"] = "";
                drEnhancedeBookmarketing["unitcost"] = "";
                drEnhancedeBookmarketing["totalcost"] = "";
                dtenhancedeBookcart.Rows.Add(drEnhancedeBookmarketing);
            }
            #endregion

            Session["dtenhancedeBookcart"] = dtenhancedeBookcart;
            Session["EnhancedeBookcarttotal"] = roundofdecimalpoints(Convert.ToDecimal(txtEnhancedeBookcartprice.Text));
            int prodcount = getcount(pnlEnhancedeBookproducts);
            Baseprice = getbasecostforproduct(prodcount, Convert.ToInt16(lblenhancedebookoffer1.Text), Convert.ToInt16(lblenhancedebookoffer2.Text));
            decimal EnhancedeBookdiscountonbasepkg = getproductprice() - Baseprice;
            //if (chkeBookmarketing.Checked || assigncount(pnleBookmarketingservices) >= 4)
            //{
            //    decimal eBooktotaldiscount = eBookdiscountonbasepkg + Convert.ToDecimal(lblmktamt.Text);
            //    Session["eBooktotaldiscount"] = roundofdecimalpoints(eBooktotaldiscount);
            //}
            //else
            Session["EnhancedeBooktotaldiscount"] = EnhancedeBookdiscountonbasepkg;
            Session["EnhancedeBookdiscountonbasepkg"] = roundofdecimalpoints(EnhancedeBookdiscountonbasepkg);
            Session["EnhancedeBookproductprice"] = roundofdecimalpoints(getproductprice());

        }

        #region bindcartvalues to eBook form
        protected void bindsessionvalues()  //bind the values from session to eBook form
        {
            DataTable dtEnhancedeBookcart = (DataTable)Session["dtEnhancedeBookcart"];

            //displaying the product values from session to eBook form start
            chkEnhancedeBookepub3.Checked = getvaluesfromrow(dtEnhancedeBookcart, "1")["qty"].ToString() == "1" ? true : false;
            chkEnhancedeBookkindle.Checked = getvaluesfromrow(dtEnhancedeBookcart, "2")["qty"].ToString() == "1" ? true : false;
            chkEnhancedeBooknook.Checked = getvaluesfromrow(dtEnhancedeBookcart, "3")["qty"].ToString() == "1" ? true : false;
            //complete

            //displaying the cust values from session to eBook values begin
            txtEnhancedeBookcustpcdpages.Text = getvaluesfromrow(dtEnhancedeBookcart, "4a")["qty"].ToString();
            txtEnhancedeBookcustpcdhplinks.Text = getvaluesfromrow(dtEnhancedeBookcart, "4b")["qty"].ToString();
            //complete

            //displaying the elements from session to eBook form start
            chkEnhancedeBooknestedtoc.Checked = getvaluesfromrow(dtEnhancedeBookcart, "5a")["qty"].ToString() == "1" ? true : false;
            chkEnhancedeBookdropcaps.Checked = getvaluesfromrow(dtEnhancedeBookcart, "5b")["qty"].ToString() == "1" ? true : false;
            chkEnhancedeBookcoloredfonts.Checked = getvaluesfromrow(dtEnhancedeBookcart, "5c")["qty"].ToString() == "1" ? true : false;
            chkEnhancedeBooklists.Checked = getvaluesfromrow(dtEnhancedeBookcart, "5d")["qty"].ToString() == "1" ? true : false;
            chkEnhancedeBooksections.Checked = getvaluesfromrow(dtEnhancedeBookcart, "5e")["qty"].ToString() == "1" ? true : false;
            chkEnhancedeBookcallouts.Checked = getvaluesfromrow(dtEnhancedeBookcart, "5f")["qty"].ToString() == "1" ? true : false;
            chkEnhancedeBookdoublecolumntext.Checked = getvaluesfromrow(dtEnhancedeBookcart, "5g")["qty"].ToString() == "1" ? true : false;
            chkEnhancedeBookcenteredtext.Checked = getvaluesfromrow(dtEnhancedeBookcart, "5h")["qty"].ToString() == "1" ? true : false;
            chkEnhancedeBookbvcolors.Checked = getvaluesfromrow(dtEnhancedeBookcart, "5i")["qty"].ToString() == "1" ? true : false;
            
            
            
            
            //complete

            //displaying the audio or video elements from session to eBook form start
           txtEnhancedeBookavcost.Text = getvaluesfromrow(dtEnhancedeBookcart, "6")["qty"].ToString();
            //complete

            //text highlight
            txtEnhancedeBookReadaloud.Text = getvaluesfromrow(dtEnhancedeBookcart, "7")["qty"].ToString();
            //end
            //displaying the coverdesign elements from session to eBook form start
            rbEnhancedeBookSimpleDesign.Checked = getvaluesfromrow(dtEnhancedeBookcart, "8a")["qty"].ToString() != "" ? true : false;
            rbEnhancedeBookHIDesign.Checked = getvaluesfromrow(dtEnhancedeBookcart, "8b")["qty"].ToString()!= "" ? true : false;
            //complete

            //region ISBN check
           chkEnhancedeBookisbnepub.Checked = getvaluesfromrow(dtEnhancedeBookcart, "9a")["qty"].ToString() != ""? true : false;
            chkEnhancedeBookisbnmobi.Checked = getvaluesfromrow(dtEnhancedeBookcart, "9b")["qty"].ToString() != "" ? true : false;
            chkEnhancedeBookisbnnook.Checked = getvaluesfromrow(dtEnhancedeBookcart, "9c")["qty"].ToString() != "" ? true : false;
            //end ISBN

            //distribution start
            if (getvaluesfromrow(dtEnhancedeBookcart, "10")["qty"].ToString() != "")
                rbEnhancedeBookdistagent.Checked = true;
            else
                rbEnhancedeBookdistmyself.Checked = true;
            //distributiion end

            //marketing prices 
            chkEnhancedeBooksocialmediasetup.Checked = getvaluesfromrow(dtEnhancedeBookcart, "11a")["qty"].ToString() != "" ? true : false;
            chkEnhancedeBookpressrelease.Checked = getvaluesfromrow(dtEnhancedeBookcart, "11b")["qty"].ToString() != ""? true : false;
            chkEnhancedeBookemailcampaign.Checked = getvaluesfromrow(dtEnhancedeBookcart, "11c")["qty"].ToString() != "" ? true : false;
            chkEnhancedeBookwebsitepromotion.Checked = getvaluesfromrow(dtEnhancedeBookcart, "11d")["qty"].ToString() != "" ? true : false;
            chkEnhancedeBookmarketing.Checked = getvaluesfromrow(dtEnhancedeBookcart, "11e")["qty"].ToString() != "" ? true : false;
            //end





        }
        #endregion

        #region get data row values
        private static DataRow getvaluesfromrow(DataTable dtEnhancedeBookcart,string s)
        {
            DataRow[] filteredRows =
                  dtEnhancedeBookcart.Select(string.Format("{0} LIKE '%{1}%'", "cartid", s));
            return filteredRows[0];
        }
        #endregion

        #region clear all checkbox values from EnhancedeBook form
        private void uncheck(Panel ebpanel)
        {
            foreach (var ctrl in ebpanel.Controls)
            {
                if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).Checked = false;
                }
            }

        }
        #endregion

        #region clear all radiobutton values from EnhancedeBook form
        private void clearradiobuttons()
        {
            //to clear Does your Book need Cover design radio button values start
            rbEnhancedeBookSimpleDesign.Checked = false;
            rbEnhancedeBookHIDesign.Checked = false;
            //end

            //to clear eBook Publishing, Distribution and Royalties radiobutton values start
            rbEnhancedeBookdistmyself.Checked = false;
            rbEnhancedeBookdistagent.Checked = false;
            //end
        }
        #endregion

       
    }
}