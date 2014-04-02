using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;  //To get the datatable object need to add this namespace.

namespace eBooks2goV5.pricing
{
    public partial class ebook : System.Web.UI.Page
    {
        bel.bel _pcbel = new bel.bel(); // To get the variables from business entity layer(bel) class need to create this object.

        bll.bll _pcbll = new bll.bll(); // To get the business logic i.e methods from business logic layer(bll) class need to create this object.

        decimal Cartprice = 0;
        decimal BasePrice = 0;
        decimal ProductPrice = 0;
        decimal PagePrice = 0;
        decimal Imageprice = 0;
        decimal Footandendnotesprice = 0;
        decimal linksprice = 0;
        decimal avprice = 0;

        #region get request

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)    //if it is a first request then load the getpcid() method.
            {
                getpcid((int)bel.bel.prodcategory.eBook);
                if (Session["dteBookcart"] != null)
                    bindsessionvalues();
                   calculatecost();
            }
           
        }

        #endregion

        #region get eBook

        protected void getpcid(int _pcid)
        {
            DataTable dtpc = new DataTable();
            _pcbel.prodid = null;
            _pcbel.pcid = _pcid;

            dtpc = _pcbll.getprodcat(_pcbel); //get all the prodcat details from the Business Logic Layer(BLL) Class and store in datatable.

            lblebookpcdpages.Text = dtpc.Rows[0]["pcdpages"].ToString();
            lblebookpcdimages.Text = dtpc.Rows[0]["pcdimages"].ToString();
            lblebookpcdfootnotes.Text = dtpc.Rows[0]["pcdfootnotes"].ToString();
            lblebookpcdhplinks.Text = dtpc.Rows[0]["pcdhplinks"].ToString();
            lblebookoffer1.Text = dtpc.Rows[0]["offer1"].ToString();
            lblebookoffer1dis.Text = dtpc.Rows[0]["offer1dis"].ToString();
            lblebookoffer2.Text = dtpc.Rows[0]["offer2"].ToString();
            lblebookoffer2dis.Text = dtpc.Rows[0]["offer2dis"].ToString();

            lblebookcustpcdpages.Text = dtpc.Rows[0]["pcdpages"].ToString();
            lblebookperpagecost.Text = dtpc.Rows[0]["perpagecost"].ToString();
            imgeBookAVelement.Attributes.Add("title", "Each Audio/Video file insert will be charged at the rate of $" + dtpc.Rows[0]["eachavcost"].ToString() + ".This feature is currently supported only on ePUB format.Epub files with Audio/Video elements are supported by Apple, Google Android, Sony and Kobo stores ant their devices.");
            hdnavelementcost.Value = dtpc.Rows[0]["eachavcost"].ToString();
            lblebookcustpcdimages.Text = dtpc.Rows[0]["pcdimages"].ToString();
            lblebookperimagecost.Text = dtpc.Rows[0]["perimagecost"].ToString();

            lblebookfootnotesandendnotescost.Text = dtpc.Rows[0]["footnotesandendnotescost"].ToString();
            lblebookcustpcdhplinks.Text = dtpc.Rows[0]["pcdhplinks"].ToString();

            lblebookcustpcdhplinks.Text = dtpc.Rows[0]["pcdhplinks"].ToString();
            lblebookweblinkscost.Text = dtpc.Rows[0]["weblinkscost"].ToString();

            lblebooktwotofourelementscost.Text = dtpc.Rows[0]["twotofourelementscost"].ToString();
            lblebookfourpluselementscost.Text = dtpc.Rows[0]["fourpluselementscost"].ToString();

            lblebookscoverdesigncost.Text = dtpc.Rows[0]["scoverdesigncost"].ToString();
            lblebookhcoverdesigncost.Text = dtpc.Rows[0]["hcoverdesigncost"].ToString();

            lblebooksocialmediacost.Text = dtpc.Rows[0]["socialmediacost"].ToString();
            lblebookpressreleasecost.Text = dtpc.Rows[0]["pressreleasecost"].ToString();

            lblebookemailcampaincost.Text = dtpc.Rows[0]["emailcampaincost"].ToString();
            lblebookwebsiteblogpromotioncost.Text = dtpc.Rows[0]["websiteblogpromotioncost"].ToString();
            lblebookmarketingdiscount.Text = dtpc.Rows[0]["marketingdiscount"].ToString();

            lblebookepubprodisbncost.Text = dtpc.Rows[0]["eisbncost"].ToString();
            lblebookmobiprodisbncost.Text = dtpc.Rows[0]["eisbncost"].ToString();
            lblebooknookprodisbncost.Text = dtpc.Rows[0]["eisbncost"].ToString();
            lblmktamt.Text = dtpc.Rows[0]["mktamt"].ToString();
            dtpc = _pcbll.getproducts(_pcbel);  //get all the product details from Business Logic Layer(BLL) Class and store it in datatable.

            lblebookepubprodcost.Text = dtpc.Rows[0]["prodcost"].ToString();
            lblebookkindleprodcost.Text = dtpc.Rows[1]["prodcost"].ToString();
            lblebookpdfprodcost.Text = dtpc.Rows[2]["prodcost"].ToString();
        }
        #endregion

        protected void chkprod_CheckedChanged(object sender, EventArgs e)
        {
            calculatecost();
        }

        private void calculatecost()
        {
            int count = 0;
            count = assigncount(pnleBookproducts);
            if (count > 0)
            {
                PagePrice = getpagevalues(count);
                avprice = cartpricewithavelement();
                Imageprice = getimagevalues(count);
                Footandendnotesprice = getfootandendnotesvalues(count);
                linksprice = gethyperlinkvalues(count);
                BasePrice= getbasepricefrproducts(count,Convert.ToInt16(lblebookoffer1.Text),Convert.ToInt16(lblebookoffer2.Text));
                BasePrice = getbasepricewithelements(BasePrice);
                txtelemadditonalbasecost.Text = roundofdecimalpoints(BasePrice);

                Cartprice = BasePrice + PagePrice + Imageprice + Footandendnotesprice + linksprice+avprice;
                Cartprice  = pricewithcovercheck(Cartprice);
                Cartprice = cartpricewithisbn(Cartprice);
                Cartprice = cartpricewithmarketingservices(Cartprice);
                txteBookPckCst.Text = roundofdecimalpoints(Cartprice);
                imgbtnproceed.Enabled = true;

            }
            else
            {
                clearpagevalues();
                clearimagevalues();
                clearfootandendnotesvalues();
                clearlinksvalues();
                clearavvalues();
                cleartextboxes();
                uncheck(pnleBookeisbn);
                uncheck(pnleBookelements);
                uncheck(pnleBookmarketingservices);
                clearradiobuttons();
              
            }
        }

        private void clearradiobuttons()
        {
            rbeBookHIDesign.Checked = false;
            rbeBookSimpleDesign.Checked = false;
            rbeBookdistmyself.Checked = false;
            rbeBookdistagent.Checked = false;
        }

        private decimal cartpricewithavelement()
        {
            if (!string.IsNullOrEmpty(txteBookeachavcost.Text))
            {
                avprice += Convert.ToDecimal(hdnavelementcost.Value) * Convert.ToDecimal(txteBookeachavcost.Text);
                lbleBookavunitcost.Text = hdnavelementcost.Value.ToString();
                lbleBookavtotalcost.Text = avprice.ToString();
                return avprice;
            }
            else
            {
                clearavvalues();
                return 0;
            }
        }

        private decimal cartpricewithmarketingservices(decimal cartprice)
        {
            int count = assigncount(pnleBookmarketingservices);
            if (count >= 4 || chkeBookmarketing.Checked)
            {
                //chkeBookmarketing.Checked = true;\\to remove check and uncheck all functionality.
                Cartprice += Convert.ToDecimal(lblmktamt.Text.Replace(@"%", string.Empty));
            }
            else if (count > 0)
            {
                Cartprice += (chkeBooksocialmediasetup.Checked) ? Convert.ToDecimal(lblebooksocialmediacost.Text) : 0;
                Cartprice += (chkeBookpressrelease.Checked) ? Convert.ToDecimal(lblebookpressreleasecost.Text) : 0;
                Cartprice += (chkeBookemailcampaign.Checked) ? Convert.ToDecimal(lblebookemailcampaincost.Text) : 0;
            }
            return Cartprice;
        }

        private decimal cartpricewithisbn(decimal cartprice)
        {
            int count = assigncount(pnleBookeisbn);
            cartprice += Convert.ToDecimal(lblebookepubprodisbncost.Text) * count;
            return cartprice;
        }

        private decimal pricewithcovercheck(decimal cartprice)
        {
            cartprice += (rbeBookSimpleDesign.Checked) ? Convert.ToDecimal(lblebookscoverdesigncost.Text) : ((rbeBookHIDesign.Checked) ? Convert.ToDecimal(lblebookhcoverdesigncost.Text) : 0);
            return cartprice;
        }

        private decimal getbasepricewithelements(decimal baseprice)
        {
            int count = assigncount(pnleBookelements);
            BasePrice = (count >=2) ? ((count <= 4) ? (baseprice * ((100 + Convert.ToDecimal(lblebooktwotofourelementscost.Text.Replace(@"%", string.Empty))) / 100)) : (baseprice * ((100 + Convert.ToDecimal(lblebookfourpluselementscost.Text.Replace(@"%", string.Empty))) / 100))) : baseprice;
            return BasePrice;
        }

        private decimal getbasepricefrproducts(int count,int offer1,int offer2)
        {
            if (count == 0)
                BasePrice = 0;
            else if (count < offer1)
                BasePrice = calculateproductprice();
            else if (count == offer1 || count<offer2)
                BasePrice = ((calculateproductprice())) * ((100 - Convert.ToDecimal(lblebookoffer1dis.Text.Replace(@"%", string.Empty))) / 100);
            else 
                BasePrice = ((calculateproductprice())) * ((100 - Convert.ToDecimal(lblebookoffer2dis.Text.Replace(@"%", string.Empty))) / 100);
            return BasePrice;
        }

        private decimal gethyperlinkvalues(int count)
        {
            if (!string.IsNullOrEmpty(txteBookcustpcdhplinks.Text))
            {
                if (Convert.ToInt32(txteBookcustpcdhplinks.Text) > Convert.ToInt32(lblebookcustpcdhplinks.Text))
                {
                    linksprice += count * (Convert.ToInt32(txteBookcustpcdhplinks.Text) - Convert.ToInt32(lblebookpcdhplinks.Text)) * ((Convert.ToDecimal(lblebookweblinkscost.Text)) / 100);
                    lbleBookadditionalpcdhplinks.Text = (Convert.ToInt32(txteBookcustpcdhplinks.Text) - Convert.ToInt32(lblebookcustpcdhplinks.Text)).ToString();
                    lbleBookadditionalpcdhplinksunitcost.Text = (Convert.ToDecimal(lblebookweblinkscost.Text) / 100).ToString();
                    lbleBookpcdhplinksadditionalcost.Text = getaddtionalcost(Convert.ToInt32(lbleBookadditionalpcdhplinks.Text), Convert.ToDecimal(lbleBookadditionalpcdhplinksunitcost.Text), count).ToString();
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

        private decimal getfootandendnotesvalues(int count)
        {
            if (!string.IsNullOrEmpty(txteBookfootnotesandendnotes.Text))
            {
                if (Convert.ToInt32(txteBookfootnotesandendnotes.Text) > Convert.ToInt32(lblebookpcdfootnotes.Text))
                {
                    Footandendnotesprice += count * (Convert.ToInt32(txteBookfootnotesandendnotes.Text) - Convert.ToInt32(lblebookpcdfootnotes.Text)) * ((Convert.ToDecimal(lblebookfootnotesandendnotescost.Text)) / 100);
                    lbleBookadditionalfootandendnotes.Text = (Convert.ToInt32(txteBookfootnotesandendnotes.Text) - Convert.ToInt32(lblebookpcdfootnotes.Text)).ToString();
                    lbleBookadditionalfootandendnotesunitcost.Text = (Convert.ToDecimal(lblebookfootnotesandendnotescost.Text) / 100).ToString();
                    lbleBookfootandendnotesadditionalcost.Text = getaddtionalcost(Convert.ToInt32(lbleBookadditionalfootandendnotes.Text), Convert.ToDecimal(lbleBookadditionalfootandendnotesunitcost.Text), count).ToString();
                    return Footandendnotesprice;
                }
                else
                {
                    clearfootandendnotesvalues();
                    return 0;
                }
            }
            else
            {
                clearfootandendnotesvalues();
                return 0;
            }
        }

        private decimal getimagevalues(int count)
        {
            if (!string.IsNullOrEmpty(txteBookcustpcdimages.Text))
            {
                if (Convert.ToInt32(txteBookcustpcdimages.Text) > Convert.ToInt32(lblebookcustpcdimages.Text))
                {
                    Imageprice += count * (Convert.ToInt32(txteBookcustpcdimages.Text) - Convert.ToInt32(lblebookcustpcdimages.Text)) * ((Convert.ToDecimal(lblebookperimagecost.Text)));
                    lbleBookadditionalimages.Text = roundofdecimalpoints((Convert.ToInt32(txteBookcustpcdimages.Text) - Convert.ToInt32(lblebookcustpcdimages.Text)));
                    lbleBookadditionalimagesunitcost.Text = (Convert.ToDecimal(lblebookperimagecost.Text)).ToString();
                    lbleBookimagesadditionalcost.Text = getaddtionalcost(Convert.ToInt32(lbleBookadditionalimages.Text), Convert.ToDecimal(lbleBookadditionalimagesunitcost.Text), count).ToString();
                    return Imageprice;
                }
                else
                {
                    clearimagevalues();
                    return 0;
                }
            }
            else
            {
                clearimagevalues();
                return 0;
            }
        }

        private decimal getpagevalues(int count)
        {
            if (!string.IsNullOrEmpty(txtebookcustpcdpages.Text))
            {
                if (Convert.ToInt32(txtebookcustpcdpages.Text) > Convert.ToInt32(lblebookcustpcdpages.Text))
                {
                    PagePrice += count * (Convert.ToInt32(txtebookcustpcdpages.Text) - Convert.ToInt32(lblebookcustpcdpages.Text)) * ((Convert.ToDecimal(lblebookperpagecost.Text)) / 100);
                    lbleBookadditonalpages.Text = (Convert.ToInt32(txtebookcustpcdpages.Text) - Convert.ToInt32(lblebookcustpcdpages.Text)).ToString();
                    lbleBookadditonalpagesunitcost.Text = (Convert.ToDecimal(lblebookperpagecost.Text) / 100).ToString();
                    lbleBookpageadditionalcost.Text = getaddtionalcost(Convert.ToInt32(lbleBookadditonalpages.Text), Convert.ToDecimal(lbleBookadditonalpagesunitcost.Text), count).ToString();
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

        private void clearavvalues()
        {
            lbleBookavunitcost.Text = "";
            lbleBookavtotalcost.Text = "";
        }

        private void clearpagevalues()
        {
            lbleBookadditonalpages.Text = "";
            lbleBookadditonalpagesunitcost.Text = "";
            lbleBookpageadditionalcost.Text = "";
        }

        private void clearimagevalues()
        {
            lbleBookadditionalimages.Text = "";
            lbleBookadditionalimagesunitcost.Text = "";
            lbleBookimagesadditionalcost.Text = "";
        }

        private void clearfootandendnotesvalues()
        {
            lbleBookadditionalfootandendnotes.Text = "";
            lbleBookadditionalfootandendnotesunitcost.Text = "";
            lbleBookfootandendnotesadditionalcost.Text = "";
        }

        private void clearlinksvalues()
        {
            lbleBookadditionalpcdhplinks.Text = "";
            lbleBookadditionalpcdhplinksunitcost.Text = "";
            lbleBookpcdhplinksadditionalcost.Text = "";
        }

        private void cleartextboxes()
        {
            txteBookcustpcdhplinks.Text = "";
            txteBookcustpcdimages.Text = "";
            txtebookcustpcdpages.Text = "";
            txteBookeachavcost.Text = "";
            txtelemadditonalbasecost.Text = "";
            txteBookPckCst.Text = "";
            txteBookfootnotesandendnotes.Text = "";
            imgbtnproceed.Enabled = false;
        }
        protected void txtebookcustpcdpages_TextChanged(object sender, EventArgs e)
        {
            calculatecost();
        }

        private decimal getaddtionalcost(int additionalunits, decimal unitcost,int count)
        {
            return (additionalunits * unitcost * count);
        }

        private int assigncount(Panel ebpanel)
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

        protected void chkeBookmarketing_CheckedChanged(object sender, EventArgs e)
        {
            //commented by muni and gautham on 6/2/2014 it was supposed  to check and uncheck All but was removed as per  request 
            //if(chkeBookmarketing.Checked)
            //assigncheck(pnleBookmarketingservices,true);
            //else
            //    assigncheck(pnleBookmarketingservices, false);
            calculatecost(); 
        }

        //private int assigncheck(Panel ebpanel,bool chk)
        //{
        //    int i = 0;
        //    foreach (var ctrl in ebpanel.Controls)
        //    {
        //        if (ctrl is CheckBox)
        //        {
        //            ((CheckBox)ctrl).Checked = chk;
        //        }
        //    }
        //    return i;

        //}
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

        private decimal calculateproductprice()
        {
            ProductPrice = (chkeBookePub.Checked) ? Convert.ToDecimal(lblebookepubprodcost.Text) : 0;
            ProductPrice += (chkeBookKindle.Checked) ? Convert.ToDecimal(lblebookkindleprodcost.Text) : 0;
            ProductPrice += (chkeBookePDF.Checked) ? Convert.ToDecimal(lblebookpdfprodcost.Text) : 0;
            return ProductPrice;
        }

        private string roundofdecimalpoints(decimal x)
        {
             return Math.Round(x, 2).ToString();
        }

        #region storein session
        private void storeinCart()
        {
            Session["dteBookcart"] = null;  //after moving the values from session to eBook form then session should be cleared.
            //if (Session["dteBookcart"] == null)
            //{
                DataTable dteBookcart = new DataTable();
                dteBookcart.Columns.Add("cartid", typeof(System.String));
                dteBookcart.Columns.Add("pcid", typeof(System.String));
                dteBookcart.Columns.Add("qty", typeof(System.String));
                dteBookcart.Columns.Add("unitcost", typeof(System.String));
                dteBookcart.Columns.Add("totalcost", typeof(System.String));
                dteBookcart.Columns.Add("parentid", typeof(System.String));
                dteBookcart.Columns.Add("productname", typeof(System.String));
                dteBookcart.Columns.Add("productid", typeof(System.String));
                addtosession(dteBookcart);
            //}
            //else
            //{
            //    DataTable dteBookcart=(DataTable)Session["dteBookcart"];
            //    addtosession(dteBookcart);
            //}
        }
        #endregion

        private void addtosession(DataTable dteBookcart)
        {
            int CustCount = 0;
            int AdditionalElements = 0;

           #region Add epub product to cart 
            if (chkeBookePub.Checked)
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "1";
                dr["pcid"] = "1";
                dr["qty"] = "1";
                dr["productname"] = "ePUB";
                dr["unitcost"] = Convert.ToDecimal(lblebookepubprodcost.Text);
                dr["totalcost"] = Convert.ToDecimal(lblebookepubprodcost.Text);
                dteBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "1";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }

           #endregion

            #region Add eBookKindle to cart
            if (chkeBookKindle.Checked)
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "2";
                dr["pcid"] = "1";
                dr["qty"] = "1";
                dr["productname"] = "Mobi";
                dr["unitcost"] = Convert.ToDecimal(lblebookkindleprodcost.Text);
                dr["totalcost"] = Convert.ToDecimal(lblebookkindleprodcost.Text);
                dteBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "2";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }

            #endregion

            #region Add chkeBookePDF to cart

            if (chkeBookePDF.Checked)
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "3";
                dr["pcid"] = "1";
                dr["qty"] = "1";
                dr["productname"] = "ePDF";
                dr["unitcost"] = Convert.ToDecimal(lblebookpdfprodcost.Text);
                dr["totalcost"] = Convert.ToDecimal(lblebookpdfprodcost.Text);
                dteBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "3";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }
            #endregion

            if (!string.IsNullOrEmpty(txtebookcustpcdpages.Text))
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "4a";
                dr["pcid"] = "1";
                CustCount++;
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["productname"] = "Total Number of pages in the Book";
                dr["qty"] = txtebookcustpcdpages.Text;
                dr["unitcost"] = lbleBookadditonalpagesunitcost.Text;
                dr["totalcost"] = lbleBookpageadditionalcost.Text;
                dteBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "4a";
                dr["pcid"] = "1";
                dr["qty"] ="";
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }
            if (!string.IsNullOrEmpty(txteBookcustpcdimages.Text))
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "4b";
                dr["pcid"] = "1";
                CustCount++;
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["productname"] = "Total Number of Images in the Book";
                dr["qty"] = txteBookcustpcdimages.Text;
                dr["unitcost"] = lbleBookadditionalimagesunitcost.Text;
                dr["totalcost"] = lbleBookimagesadditionalcost.Text;
                dteBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "4b";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }
            if (!string.IsNullOrEmpty(txteBookfootnotesandendnotes.Text))
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "4c";
                dr["pcid"] = "1";
                CustCount++;
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["productname"] = "Total Number of Foot Notes & End Notes Linking";
                dr["qty"] = txteBookfootnotesandendnotes.Text;
                dr["unitcost"] = lbleBookadditionalfootandendnotesunitcost.Text;
                dr["totalcost"] = lbleBookfootandendnotesadditionalcost.Text;
                dteBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "4c";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }


            if (CustCount > 0)
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "4";
                dr["pcid"] = "1";
                dr["qty"] = "1";
                dr["productid"] = (char)(bel.bel.parentid.Customisations);
                dr["productname"] = "Customisations";
                dr["parentid"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "4";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["productname"] = "Customisations";
                dr["parentid"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }
            if (!string.IsNullOrEmpty(txteBookcustpcdhplinks.Text))
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "4d";
                dr["pcid"] = "1";
               
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["productname"] = "Total Number of web links, Hyperlinks, email links";
                dr["qty"] = txteBookcustpcdhplinks.Text;
                dr["unitcost"] =  lbleBookadditionalpcdhplinksunitcost.Text;
                dr["totalcost"] = lbleBookpcdhplinksadditionalcost.Text;
                dteBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "4d";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }
            #region elements
            if (chkeBooknestedtoc.Checked)
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "5a";
                dr["pcid"] = "1";
                AdditionalElements++;
                dr["qty"] = "1";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["productname"] = "Nested TOC";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "5a";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }

            if (chkeBookdropcaps.Checked)
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "5b";
                dr["pcid"] = "1";
                dr["qty"] = "1";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["productname"] = "Drop Caps";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                AdditionalElements++;
                dteBookcart.Rows.Add(dr);
            }
             else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "5b";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }
            if (chkeBookcoloredfonts.Checked)
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "5c";
                dr["pcid"] = "1";
                dr["qty"] = "1";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["productname"] = "Colored Fonts";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                AdditionalElements++;
                dteBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "5c";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }
            if (chkeBooklists.Checked)
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "5d";
                dr["pcid"] = "1";
                dr["qty"] = "1";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["productname"] = "Lists";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                AdditionalElements++;
                dteBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "5d";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }
            if (chkeBooksections.Checked)
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "5e";
                dr["pcid"] = "1";
                dr["qty"] = "1";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["productname"] = "Multiple Sections and Sub-Sections";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                AdditionalElements++;
                dteBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "5e";
                dr["pcid"] = "1";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }
            if (chkeBookcallouts.Checked)
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "5f";
                dr["pcid"] = "1";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["productname"] = "Call Outs";
                dr["qty"] = "1";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                AdditionalElements++;
                dteBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "5f";
                dr["pcid"] = "1";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }
            if (chkeBookdoublecolumntext.Checked)
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "5g";
                dr["pcid"] = "1";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["productname"] = "Double Column Text";
                dr["qty"] = "1";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                AdditionalElements++;
                dteBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "5g";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }
            if (chkeBookcenteredtext.Checked)
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "5h";
                dr["pcid"] = "1";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["productname"] = "Centered Text";
                dr["qty"] = "1";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                AdditionalElements++;
                dteBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "5h";
                dr["pcid"] = "1";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }
            if (chkeBooktextboxescolors.Checked)
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "5i";
                dr["pcid"] = "1";
                dr["qty"] = "1";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["productname"] = "Text boxes with borders/varying colors";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                AdditionalElements++;
                dteBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "5i";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }
            #endregion

            if (AdditionalElements > 0)
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "5";
                dr["pcid"] = "1";
                dr["qty"] = "1";
                dr["productid"] = (char)(bel.bel.parentid.AdditionalElements);
                dr["productname"] = "Additional elements";
                dr["parentid"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "5";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["productname"] = "Additional elements";
                dr["parentid"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }

            #region audio and video elements
            if (!string.IsNullOrEmpty(txteBookeachavcost.Text))
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "6";
                dr["pcid"] = "1";
                dr["productname"] = "Audio & Video elements";
                dr["qty"] = txteBookeachavcost.Text;
                dr["unitcost"] = lbleBookavunitcost.Text;
                dr["totalcost"] = lbleBookavtotalcost.Text;
                dteBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "6";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }
            #endregion

            #region coverdesign
            if (rbeBookSimpleDesign.Checked || rbeBookHIDesign.Checked)
            {
                if (rbeBookSimpleDesign.Checked)
                {
                    DataRow drcover = dteBookcart.NewRow();
                    drcover["cartid"] = "7";
                    drcover["pcid"] = "1";
                    drcover["qty"] = "1";
                    drcover["productname"] = "Cover design";
                    drcover["unitcost"] = lblebookscoverdesigncost.Text;
                    drcover["totalcost"] = lblebookscoverdesigncost.Text;
                    dteBookcart.Rows.Add(drcover);

                    DataRow dr = dteBookcart.NewRow();
                    dr["cartid"] = "7a";
                    dr["pcid"] = "1";
                    dr["qty"] = "1";
                    dr["parentid"] = (char)(bel.bel.parentid.CoverDesign);
                    dr["productname"] = "";
                    dr["unitcost"] = lblebookscoverdesigncost.Text;
                    dr["totalcost"] = lblebookscoverdesigncost.Text;
                    dteBookcart.Rows.Add(dr);
                }
                else
                {
                    DataRow dr = dteBookcart.NewRow();
                    dr["cartid"] = "7a";
                    dr["pcid"] = "1";
                    dr["qty"] = "";
                    dr["parentid"] = (char)(bel.bel.parentid.CoverDesign);
                    dr["unitcost"] = lblebookscoverdesigncost.Text;
                    dr["totalcost"] = lblebookscoverdesigncost.Text;
                    dteBookcart.Rows.Add(dr);
                }

                if (rbeBookHIDesign.Checked)
                {
                    DataRow drcover = dteBookcart.NewRow();
                    drcover["cartid"] = "7";
                    drcover["pcid"] = "1";
                    drcover["qty"] = "1";
                    drcover["productname"] = "Cover design";
                    drcover["unitcost"] = lblebookscoverdesigncost.Text;
                    drcover["totalcost"] = lblebookscoverdesigncost.Text;
                    dteBookcart.Rows.Add(drcover);

                    DataRow dr = dteBookcart.NewRow();
                    dr["cartid"] = "7b";
                    dr["pcid"] = "1";
                    dr["qty"] = "1";
                    dr["parentid"] = (char)(bel.bel.parentid.CoverDesign);
                    dr["productname"] = "";
                    dr["unitcost"] = lblebookhcoverdesigncost.Text;
                    dr["totalcost"] = lblebookhcoverdesigncost.Text;
                    dteBookcart.Rows.Add(dr);
                }
                else
                {
                   
                    DataRow dr = dteBookcart.NewRow();
                    dr["cartid"] = "7b";
                    dr["pcid"] = "1";
                    dr["qty"] = "";
                    dr["parentid"] = (char)(bel.bel.parentid.CoverDesign);
                    dr["unitcost"] = "";
                    dr["totalcost"] = "";
                    dteBookcart.Rows.Add(dr);
                }
            }
            else
            {
                DataRow drcover = dteBookcart.NewRow();
                drcover["cartid"] = "7";
                drcover["pcid"] = "1";
                drcover["qty"] = "";
                drcover["productname"] = "";
                drcover["unitcost"] ="";
                drcover["totalcost"] = "";
                dteBookcart.Rows.Add(drcover);

                DataRow drsimple = dteBookcart.NewRow();
                drsimple["cartid"] = "7a";
                drsimple["pcid"] = "1";
                drsimple["qty"] = "";
                drsimple["parentid"] = (char)(bel.bel.parentid.CoverDesign);
                drsimple["unitcost"] = "";
                drsimple["totalcost"] = "";
                dteBookcart.Rows.Add(drsimple);
                DataRow drHigh = dteBookcart.NewRow();
                drHigh["cartid"] = "7b";
                drHigh["pcid"] = "1";
                drHigh["qty"] = "";
                drHigh["parentid"] = (char)(bel.bel.parentid.CoverDesign);
                drHigh["unitcost"] = "";
                drHigh["totalcost"] = "";
                dteBookcart.Rows.Add(drHigh);
            }
            #endregion

            #region eisbn
            if (chkeBookepubeisbn.Checked || chkeBookmobieisbn.Checked || chkeBookenookeisbn.Checked)
            {
                DataRow dr = dteBookcart.NewRow();
                decimal eisbncost = 0;
                eisbncost += (chkeBookepubeisbn.Checked) ? Convert.ToDecimal(lblebookepubprodisbncost.Text) : 0;
                eisbncost += (chkeBookmobieisbn.Checked) ? Convert.ToDecimal(lblebookepubprodisbncost.Text) : 0;
                eisbncost += (chkeBookenookeisbn.Checked) ? Convert.ToDecimal(lblebookepubprodisbncost.Text) : 0;
                dr["cartid"] = "8";
                dr["pcid"] = "1";
                dr["qty"] = (eisbncost / Convert.ToDecimal(lblebookepubprodisbncost.Text)).ToString();
                dr["unitcost"] = lblebookepubprodisbncost.Text;
                dr["totalcost"] = eisbncost.ToString();
                dr["productname"] = "EISBN";
                dteBookcart.Rows.Add(dr);
                if (chkeBookepubeisbn.Checked)
                {
                    DataRow dreBookepubisbn = dteBookcart.NewRow();
                    dreBookepubisbn["cartid"] = "8a";
                    dreBookepubisbn["pcid"] = "1";
                    dreBookepubisbn["qty"] = "1";
                    dreBookepubisbn["unitcost"] = "";
                    dreBookepubisbn["totalcost"] = "";
                    dteBookcart.Rows.Add(dreBookepubisbn);
                }
                else
                {
                    DataRow dreBookepubisbn = dteBookcart.NewRow();
                    dreBookepubisbn["cartid"] = "8a";
                    dreBookepubisbn["pcid"] = "1";
                    dreBookepubisbn["qty"] = "";
                    dreBookepubisbn["unitcost"] = "";
                    dreBookepubisbn["totalcost"] = "";
                    dteBookcart.Rows.Add(dreBookepubisbn);
                }

                if (chkeBookmobieisbn.Checked)
                {
                    DataRow dreBookmobieisbn = dteBookcart.NewRow();
                    dreBookmobieisbn["cartid"] = "8b";
                    dreBookmobieisbn["pcid"] = "1";
                    dreBookmobieisbn["qty"] = "1";
                    dreBookmobieisbn["unitcost"] = "";
                    dreBookmobieisbn["totalcost"] = "";
                    dteBookcart.Rows.Add(dreBookmobieisbn);
                }
                else
                {
                    DataRow dreBookmobieisbn = dteBookcart.NewRow();
                    dreBookmobieisbn["cartid"] = "8b";
                    dreBookmobieisbn["pcid"] = "1";
                    dreBookmobieisbn["qty"] = "";
                    dreBookmobieisbn["unitcost"] = "";
                    dreBookmobieisbn["totalcost"] = "";
                    dteBookcart.Rows.Add(dreBookmobieisbn);
                }
                if (chkeBookenookeisbn.Checked)
                {
                    DataRow dreBookenookisbn = dteBookcart.NewRow();
                    dreBookenookisbn["cartid"] = "8c";
                    dreBookenookisbn["pcid"] = "1";
                    dreBookenookisbn["qty"] = "1";
                    dreBookenookisbn["unitcost"] = "";
                    dreBookenookisbn["totalcost"] = "";
                    dteBookcart.Rows.Add(dreBookenookisbn);
                }
                else
                {
                    DataRow dreBookenookisbn = dteBookcart.NewRow();
                    dreBookenookisbn["cartid"] = "8c";
                    dreBookenookisbn["pcid"] = "1";
                    dreBookenookisbn["qty"] = "";
                    dreBookenookisbn["unitcost"] = "";
                    dreBookenookisbn["totalcost"] = "";
                    dteBookcart.Rows.Add(dreBookenookisbn);
                }



            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "8";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);

                DataRow dreBookepubisbn = dteBookcart.NewRow();
                dreBookepubisbn["cartid"] = "8a";
                dreBookepubisbn["pcid"] = "1";
                dreBookepubisbn["qty"] = "";
                dreBookepubisbn["unitcost"] = "";
                dreBookepubisbn["totalcost"] = "";
                dteBookcart.Rows.Add(dreBookepubisbn);


                DataRow dreBookmobieisbn = dteBookcart.NewRow();
                dreBookmobieisbn["cartid"] = "8b";
                dreBookmobieisbn["pcid"] = "1";
                dreBookmobieisbn["qty"] = "";
                dreBookmobieisbn["unitcost"] = "";
                dreBookmobieisbn["totalcost"] = "";
                dteBookcart.Rows.Add(dreBookmobieisbn);

                DataRow dreBookenookisbn = dteBookcart.NewRow();
                dreBookenookisbn["cartid"] = "8c";
                dreBookenookisbn["pcid"] = "1";
                dreBookenookisbn["qty"] = "";
                dreBookenookisbn["unitcost"] = "";
                dreBookenookisbn["totalcost"] = "";
                dteBookcart.Rows.Add(dreBookenookisbn);

            }
            #endregion

            #region book publishing and distribution
            if (rbeBookdistagent.Checked)
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "9";
                dr["pcid"] = "1";
                dr["qty"] = "1";
                dr["productname"] = "Book publishing & Distribution";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "9";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);
            }
            #endregion

            #region marketing price
            if (chkeBooksocialmediasetup.Checked || chkeBookpressrelease.Checked || chkeBookemailcampaign.Checked || chkeBookwebsitepromotion.Checked || chkeBookmarketing.Checked)
            {
                DataRow dr = dteBookcart.NewRow();
                decimal marketingprice = 0;
                int count = 0;
                count = assigncount(pnleBookmarketingservices);
                if (count == 4 || chkeBookmarketing.Checked)
                {
                    marketingprice += Convert.ToDecimal(lblmktamt.Text);
                    dr["qty"] = 4; 
                }
                else
                {
                    marketingprice += (chkeBooksocialmediasetup.Checked) ? Convert.ToDecimal(lblebooksocialmediacost.Text) : 0;
                    marketingprice += (chkeBookpressrelease.Checked) ? Convert.ToDecimal(lblebookpressreleasecost.Text) : 0;
                    marketingprice += (chkeBookemailcampaign.Checked) ? Convert.ToDecimal(lblebookemailcampaincost.Text) : 0;
                    marketingprice += (chkeBookwebsitepromotion.Checked) ? Convert.ToDecimal(lblebookwebsiteblogpromotioncost.Text) : 0;
                    dr["qty"] = count.ToString(); 
                }
                 dr["cartid"] = "10";
                dr["pcid"] = "1";
                dr["unitcost"] = lblebookemailcampaincost.Text;
                dr["totalcost"] = marketingprice.ToString();
                dr["productname"] = "Marketing services";
                dteBookcart.Rows.Add(dr);

                if (chkeBooksocialmediasetup.Checked)
                {
                    DataRow dreBooksocialmediasetup = dteBookcart.NewRow();
                    dreBooksocialmediasetup["cartid"] = "10a";
                    dreBooksocialmediasetup["pcid"] = "1";
                    dreBooksocialmediasetup["qty"] = "1";
                    dreBooksocialmediasetup["unitcost"] = "";
                    dreBooksocialmediasetup["totalcost"] = "";
                    dteBookcart.Rows.Add(dreBooksocialmediasetup);
                }
                else
                {
                    DataRow dreBooksocialmediasetup = dteBookcart.NewRow();
                    dreBooksocialmediasetup["cartid"] = "10a";
                    dreBooksocialmediasetup["pcid"] = "1";
                    dreBooksocialmediasetup["qty"] = "";
                    dreBooksocialmediasetup["unitcost"] = "";
                    dreBooksocialmediasetup["totalcost"] = "";
                    dteBookcart.Rows.Add(dreBooksocialmediasetup);
                }
                if(chkeBookpressrelease.Checked)
                {
                    DataRow dreBookpressrelease = dteBookcart.NewRow();
                    dreBookpressrelease["cartid"] = "10b";
                    dreBookpressrelease["pcid"] = "1";
                    dreBookpressrelease["qty"] = "1";
                    dreBookpressrelease["unitcost"] = "";
                    dreBookpressrelease["totalcost"] = "";
                    dteBookcart.Rows.Add(dreBookpressrelease);
                }
                else
                {
                    DataRow dreBookpressrelease = dteBookcart.NewRow();
                    dreBookpressrelease["cartid"] = "10b";
                    dreBookpressrelease["pcid"] = "1";
                    dreBookpressrelease["qty"] = "";
                    dreBookpressrelease["unitcost"] = "";
                    dreBookpressrelease["totalcost"] = "";
                    dteBookcart.Rows.Add(dreBookpressrelease);
                }

                if (chkeBookemailcampaign.Checked)
                {
                    DataRow dreBookemailcampaign = dteBookcart.NewRow();
                    dreBookemailcampaign["cartid"] = "10c";
                    dreBookemailcampaign["pcid"] = "1";
                    dreBookemailcampaign["qty"] = "1";
                    dreBookemailcampaign["unitcost"] = "";
                    dreBookemailcampaign["totalcost"] = "";
                    dteBookcart.Rows.Add(dreBookemailcampaign);
                }
                else
                {
                    DataRow dreBookemailcampaign = dteBookcart.NewRow();
                    dreBookemailcampaign["cartid"] = "10c";
                    dreBookemailcampaign["pcid"] = "1";
                    dreBookemailcampaign["qty"] = "";
                    dreBookemailcampaign["unitcost"] = "";
                    dreBookemailcampaign["totalcost"] = "";
                    dteBookcart.Rows.Add(dreBookemailcampaign);
                }
               
                if(chkeBookwebsitepromotion.Checked)
                {
                    DataRow dreBookwebsitepromotion = dteBookcart.NewRow();
                    dreBookwebsitepromotion["cartid"] = "10d";
                    dreBookwebsitepromotion["pcid"] = "1";
                    dreBookwebsitepromotion["qty"] = "1";
                    dreBookwebsitepromotion["unitcost"] = "";
                    dreBookwebsitepromotion["totalcost"] = "";
                    dteBookcart.Rows.Add(dreBookwebsitepromotion);
                }
                else
                {
                    DataRow dreBookwebsitepromotion = dteBookcart.NewRow();
                    dreBookwebsitepromotion["cartid"] = "10d";
                    dreBookwebsitepromotion["pcid"] = "1";
                    dreBookwebsitepromotion["qty"] = "";
                    dreBookwebsitepromotion["unitcost"] = "";
                    dreBookwebsitepromotion["totalcost"] = "";
                    dteBookcart.Rows.Add(dreBookwebsitepromotion);
                }
                
                if(chkeBookmarketing.Checked)
                {
                    DataRow dreBookmarketing = dteBookcart.NewRow();
                    dreBookmarketing["cartid"] = "10e";
                    dreBookmarketing["pcid"] = "1";
                    dreBookmarketing["qty"] = "5";
                    dreBookmarketing["unitcost"] = "";
                    dreBookmarketing["totalcost"] = "";
                    dteBookcart.Rows.Add(dreBookmarketing);
                }
                else
                {
                    DataRow dreBookmarketing = dteBookcart.NewRow();
                    dreBookmarketing["cartid"] = "10e";
                    dreBookmarketing["pcid"] = "1";
                    dreBookmarketing["qty"] = "";
                    dreBookmarketing["unitcost"] = "";
                    dreBookmarketing["totalcost"] = "";
                    dteBookcart.Rows.Add(dreBookmarketing);
                }
                
                
            }
            else
            {
                DataRow dr = dteBookcart.NewRow();
                dr["cartid"] = "10";
                dr["pcid"] = "1";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dteBookcart.Rows.Add(dr);

                DataRow dreBooksocialmediasetup = dteBookcart.NewRow();
                dreBooksocialmediasetup["cartid"] = "10a";
                dreBooksocialmediasetup["pcid"] = "1";
                dreBooksocialmediasetup["qty"] = "";
                dreBooksocialmediasetup["unitcost"] = "";
                dreBooksocialmediasetup["totalcost"] = "";
                dteBookcart.Rows.Add(dreBooksocialmediasetup);

                DataRow dreBookpressrelease = dteBookcart.NewRow();
                dreBookpressrelease["cartid"] = "10b";
                dreBookpressrelease["pcid"] = "1";
                dreBookpressrelease["qty"] = "";
                dreBookpressrelease["unitcost"] = "";
                dreBookpressrelease["totalcost"] = "";
                dteBookcart.Rows.Add(dreBookpressrelease);

                DataRow dreBookemailcampaign = dteBookcart.NewRow();
                dreBookemailcampaign["cartid"] = "10c";
                dreBookemailcampaign["pcid"] = "1";
                dreBookemailcampaign["qty"] = "";
                dreBookemailcampaign["unitcost"] = "";
                dreBookemailcampaign["totalcost"] = "";
                dteBookcart.Rows.Add(dreBookemailcampaign);

                DataRow dreBookwebsitepromotion = dteBookcart.NewRow();
                dreBookwebsitepromotion["cartid"] = "10d";
                dreBookwebsitepromotion["pcid"] = "1";
                dreBookwebsitepromotion["qty"] = "";
                dreBookwebsitepromotion["unitcost"] = "";
                dreBookwebsitepromotion["totalcost"] = "";
                dteBookcart.Rows.Add(dreBookwebsitepromotion);

                DataRow dreBookmarketing = dteBookcart.NewRow();
                dreBookmarketing["cartid"] = "10e";
                dreBookmarketing["pcid"] = "1";
                dreBookmarketing["qty"] = "";
                dreBookmarketing["unitcost"] = "";
                dreBookmarketing["totalcost"] = "";
                dteBookcart.Rows.Add(dreBookmarketing);
            }
            #endregion

            Session["dteBookcart"] = dteBookcart;
            Session["eBookcarttotal"] = roundofdecimalpoints(Convert.ToDecimal(txteBookPckCst.Text));
            int prodcount = assigncount(pnleBookproducts);
            BasePrice = getbasepricefrproducts(prodcount, Convert.ToInt16(lblebookoffer1.Text), Convert.ToInt16(lblebookoffer2.Text));
             decimal  eBookdiscountonbasepkg= calculateproductprice() - BasePrice;
             //if (chkeBookmarketing.Checked || assigncount(pnleBookmarketingservices) >= 4)
             //{
             //    decimal eBooktotaldiscount = eBookdiscountonbasepkg + Convert.ToDecimal(lblmktamt.Text);
             //    Session["eBooktotaldiscount"] = roundofdecimalpoints(eBooktotaldiscount);
             //}
             //else
            Session["eBooktotaldiscount"] = eBookdiscountonbasepkg;
            Session["eBookdiscountonbasepkg"] = roundofdecimalpoints(eBookdiscountonbasepkg);
            Session["eBookproductprice"] = roundofdecimalpoints(calculateproductprice());

        }

        protected void imgbtnproceed_Click(object sender, ImageClickEventArgs e)
        {
            storeinCart();
            //Response.Redirect("~/pricing/flupload.aspx?ID=1");
            Response.Redirect("~/pricing/fileupload.aspx?ID=1");
        }

        #region bindcartvalues to eBook form
        protected void bindsessionvalues()  //bind the values from session to eBook form
        {
            DataTable dteBookcart = (DataTable)Session["dteBookcart"];

            //displaying the product values from session to eBook form start
            chkeBookePub.Checked = getvaluesfromrow(dteBookcart, "1")["qty"].ToString() == "1" ? true : false;
            chkeBookKindle.Checked = getvaluesfromrow(dteBookcart, "2")["qty"].ToString() == "1" ? true : false;
            chkeBookePDF.Checked = getvaluesfromrow(dteBookcart, "3")["qty"].ToString() == "1" ? true : false;
            //complete

            //displaying the cust values from session to eBook values begin
            txtebookcustpcdpages.Text = getvaluesfromrow(dteBookcart, "4a")["qty"].ToString();
            txteBookcustpcdimages.Text = getvaluesfromrow(dteBookcart, "4b")["qty"].ToString();
            txteBookfootnotesandendnotes.Text = getvaluesfromrow(dteBookcart, "4c")["qty"].ToString();
            txteBookcustpcdhplinks.Text = getvaluesfromrow(dteBookcart, "4d")["qty"].ToString();
            //complete

            //displaying the elements from session to eBook form start
            chkeBooknestedtoc.Checked = getvaluesfromrow(dteBookcart, "5a")["qty"].ToString() == "1" ? true : false;
            chkeBookdropcaps.Checked = getvaluesfromrow(dteBookcart, "5b")["qty"].ToString() == "1" ? true : false;
            chkeBookcoloredfonts.Checked = getvaluesfromrow(dteBookcart, "5c")["qty"].ToString() == "1" ? true : false;
            chkeBooklists.Checked = getvaluesfromrow(dteBookcart, "5d")["qty"].ToString() == "1" ? true : false;
            chkeBooksections.Checked = getvaluesfromrow(dteBookcart, "5e")["qty"].ToString() == "1" ? true : false;
            chkeBookcallouts.Checked = getvaluesfromrow(dteBookcart, "5f")["qty"].ToString() == "1" ? true : false;
            chkeBookdoublecolumntext.Checked = getvaluesfromrow(dteBookcart, "5g")["qty"].ToString() == "1" ? true : false;
            chkeBookcenteredtext.Checked = getvaluesfromrow(dteBookcart, "5h")["qty"].ToString() == "1" ? true : false;
            chkeBooktextboxescolors.Checked = getvaluesfromrow(dteBookcart, "5i")["qty"].ToString() == "1" ? true : false;

            //complete

            //displaying the audio or video elements from session to eBook form start
            txteBookeachavcost.Text = getvaluesfromrow(dteBookcart, "6")["qty"].ToString();
            //complete

            //displaying the coverdesign elements from session to eBook form start
            rbeBookSimpleDesign.Checked = (getvaluesfromrow(dteBookcart, "7a")["qty"].ToString() != "") ? true : false;
            rbeBookHIDesign.Checked = (getvaluesfromrow(dteBookcart, "7b")["qty"].ToString() != "") ? true : false; 
            //complete
           
            //region ISBN check
            chkeBookepubeisbn.Checked = (getvaluesfromrow(dteBookcart, "8a")["qty"].ToString() != "") ? true : false;
            chkeBookmobieisbn.Checked = (getvaluesfromrow(dteBookcart, "8b")["qty"].ToString() != "") ? true : false;
            chkeBookenookeisbn.Checked = (getvaluesfromrow(dteBookcart, "8c")["qty"].ToString() != "") ? true : false;
            //end ISBN
            //distribution start
            if (getvaluesfromrow(dteBookcart, "9")["qty"].ToString() != "")
                   rbeBookdistagent.Checked = true ;
            else
                  rbeBookdistmyself.Checked=true;
            //distributiion end

            //marketing prices 
            chkeBooksocialmediasetup.Checked = (getvaluesfromrow(dteBookcart, "10a")["qty"].ToString() != "") ? true : false;
            chkeBookpressrelease.Checked = (getvaluesfromrow(dteBookcart, "10b")["qty"].ToString() != "") ? true : false;
            chkeBookemailcampaign.Checked = (getvaluesfromrow(dteBookcart, "10c")["qty"].ToString() != "") ? true : false;
            chkeBookwebsitepromotion.Checked = (getvaluesfromrow(dteBookcart, "10d")["qty"].ToString() != "") ? true : false;
            chkeBookmarketing.Checked = (getvaluesfromrow(dteBookcart, "10e")["qty"].ToString() != "") ? true : false;
            //end
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