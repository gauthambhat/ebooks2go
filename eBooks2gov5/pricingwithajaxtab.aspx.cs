using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;  //To get the datatable object need to add this namespace.


namespace eBooks2goV5
{
    public partial class pricingwithajaxtab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        ////bel.bel _pcbel = new bel.bel(); // To get the variables from business entity layer(bel) class need to create this object.

        ////bll.bll _pcbll = new bll.bll(); // To get the business logic i.e methods from business logic layer(bll) class need to create this object.

        //#region get request

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)    //if it is a first request then load the getpcid() method.
        //    {
        //        getpcid((int)bel.bel.prodcategory.eBook);
        //    }
        //}

        //#endregion

        //#region get eBook

        //protected void getpcid(int _pcid)
        //{
        //    DataTable dtpc = new DataTable();
        //    _pcbel.pcid = null;
        //    _pcbel.prodid = null;
        //    _pcbel.pcid = 1;

        //    dtpc = _pcbll.getprodcat(_pcbel); //get all the prodcat details from the Business Logic Layer(BLL) Class and store in datatable.

        //    lblebookpcdpages.Text = dtpc.Rows[0]["pcdpages"].ToString();
        //    lblebookpcdimages.Text = dtpc.Rows[0]["pcdimages"].ToString();
        //    lblebookpcdfootnotes.Text = dtpc.Rows[0]["pcdfootnotes"].ToString();
        //    lblebookpcdhplinks.Text = dtpc.Rows[0]["pcdhplinks"].ToString();
        //    lblebookoffer1.Text = dtpc.Rows[0]["offer1"].ToString();
        //    lblebookoffer1dis.Text = dtpc.Rows[0]["offer1dis"].ToString();
        //    lblebookoffer2.Text = dtpc.Rows[0]["offer2"].ToString();
        //    lblebookoffer2dis.Text = dtpc.Rows[0]["offer2dis"].ToString();

        //    lblebookcustpcdpages.Text = dtpc.Rows[0]["pcdpages"].ToString();
        //    lblebookperpagecost.Text = dtpc.Rows[0]["perpagecost"].ToString();

        //    lblebookcustpcdimages.Text = dtpc.Rows[0]["pcdimages"].ToString();
        //    lblebookperimagecost.Text = dtpc.Rows[0]["perimagecost"].ToString();

        //    lblebookfootnotesandendnotescost.Text = dtpc.Rows[0]["footnotesandendnotescost"].ToString();
        //    lblebookcustpcdhplinks.Text = dtpc.Rows[0]["pcdhplinks"].ToString();

        //    lblebookcustpcdhplinks.Text = dtpc.Rows[0]["pcdhplinks"].ToString();
        //    lblebookweblinkscost.Text = dtpc.Rows[0]["weblinkscost"].ToString();

        //    lblebooktwotofourelementscost.Text = dtpc.Rows[0]["twotofourelementscost"].ToString();
        //    lblebookfourpluselementscost.Text = dtpc.Rows[0]["fourpluselementscost"].ToString();

        //    lblebookscoverdesigncost.Text = dtpc.Rows[0]["scoverdesigncost"].ToString();
        //    lblebookhcoverdesigncost.Text = dtpc.Rows[0]["hcoverdesigncost"].ToString();

        //    lblebooksocialmediacost.Text = dtpc.Rows[0]["socialmediacost"].ToString();
        //    lblebookpressreleasecost.Text = dtpc.Rows[0]["pressreleasecost"].ToString();

        //    lblebookemailcampaincost.Text = dtpc.Rows[0]["emailcampaincost"].ToString();
        //    lblebookwebsiteblogpromotioncost.Text = dtpc.Rows[0]["websiteblogpromotioncost"].ToString();
        //    lblebookmarketingdiscount.Text = dtpc.Rows[0]["marketingdiscount"].ToString();

        //    lblebookepubprodisbncost.Text = dtpc.Rows[0]["eisbncost"].ToString();
        //    lblebookmobiprodisbncost.Text = dtpc.Rows[0]["eisbncost"].ToString();
        //    lblebooknookprodisbncost.Text = dtpc.Rows[0]["eisbncost"].ToString();
        //    lblmktamt.Text = dtpc.Rows[0]["mktamt"].ToString();
        //    dtpc = _pcbll.getproducts(_pcbel);  //get all the product details from Business Logic Layer(BLL) Class and store it in datatable.

        //    lblebookepubprodcost.Text = dtpc.Rows[0]["prodcost"].ToString();
        //    lblebookkindleprodcost.Text = dtpc.Rows[1]["prodcost"].ToString();
        //    lblebookpdfprodcost.Text = dtpc.Rows[2]["prodcost"].ToString();
        //}
        //#endregion

        
    }
}