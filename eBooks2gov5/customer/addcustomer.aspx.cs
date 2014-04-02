using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;      //namespace for datatable
using eBooks2goV5.bel;  //namespace for business entity layer
using eBooks2goV5.dal;  //namespace for data access layer
using eBooks2goV5.bll;  //namespace for businesss logic layer



namespace eBooks2goV5.customer
{
    public partial class addcustomer : System.Web.UI.Page
    {
        #region object Instatances (References)
        bel.insertnewcustomerbel _insertnewcustomerbel = new insertnewcustomerbel();   //using this reference we can get the customer properties from BEL(Business Entity Layer) Class.
        bll.bll _insertnewcustomerbll = new bll.bll();  //using this reference we can get the insertnewcustomer method from BLL Class(Business Logic Layer)
        bel.Countries _countries = new bel.Countries();//using this reference we can get the countries properties from BEL(Business Entity Layer) Class.
        bel.States _states = new bel.States();//using this reference we can get the statees properties from BEL(Business Entity Layer) Class.
        #endregion

        #region get request
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtcustomeremail.Focus();
               
            }
        }
        #endregion

        #region insert new customer
        protected void btncustomersubmit_Click(object sender, EventArgs e)
        {
            _insertnewcustomerbel.emailid = txtcustomeremail.Text.Trim();
            _insertnewcustomerbel.password = txtcustomerpassword.Text.Trim();
            _insertnewcustomerbel.firstname = txtcustomerfirstname.Text.Trim();
            _insertnewcustomerbel.lastname = txtcustomerlastname.Text.Trim();
            _insertnewcustomerbel.address1 = txtcustomeraddressone.Text.Trim();
            _insertnewcustomerbel.address2 = txtcustomeraddresstwo.Text.Trim();
            _insertnewcustomerbel.city = txtcustomercity.Text.Trim();
            _insertnewcustomerbel.countryid = Convert.ToInt16(ddlcustomercountry.SelectedValue);
            _insertnewcustomerbel.stateid = Convert.ToInt16(ddlcustomerstate.SelectedValue);
            _insertnewcustomerbel.zipCode = txtcustomerzip.Text.Trim();
            _insertnewcustomerbel.phone = txtcustomerphone.Text.Trim();
            _insertnewcustomerbel.fax = txtcustomerfax.Text.Trim();
            _insertnewcustomerbel.customertype = Convert.ToInt16(ddlcustomertype.SelectedValue);
            _insertnewcustomerbel.companyname = txtcustomercompany.Text == "" ? null : txtcustomercompany.Text;

            object objinsertstatus = new object();//why we need to create this instance is sometimes customer result may be string or int.

            objinsertstatus = _insertnewcustomerbll.insertnewcustomer(_insertnewcustomerbel);  //call the insertnewcustomer method from bll and do process after that assign the result to customerid

            if (objinsertstatus is string)  //i.e if customer already exist 
            {
                lblebookcustomermsg.Text = objinsertstatus.ToString();
            }
            else
            {
               _insertnewcustomerbel.customerid = (Int64?)objinsertstatus;  //store the customerid
                Session["customerid"] = _insertnewcustomerbel.customerid;   //store the customer id in session
                Session["customername"] = _insertnewcustomerbel.firstname + " " + _insertnewcustomerbel.lastname;   //store the customer name in session
                Session["customeraddressone"] = _insertnewcustomerbel.address1; //store the customer address1 in session
                Session["customeraddresstwo"] = _insertnewcustomerbel.address2; //store the customer address2 in session
                Session["customercountry"] = ddlcustomercountry.SelectedItem.Text.ToString();   //store the customer country in session
                Session["customerzipcode"] = _insertnewcustomerbel.zipCode; //store the zipcode in session
                
                //switch(Request.QueryString["ID"])
                //{
                //    case "1" :Response.Redirect("../pricing/ebookinvoice.aspx");
                //        break;
                //    case "2": Response.Redirect("../pricing/enhancedebookinvoice.aspx");
                //        break;
                //    case "3": Response.Redirect("../ebookapps/simpleebookappsinvoice.aspx");
                //        break;
                //    case "4": Response.Redirect("../ebookapps/complexebookappsinvoice.aspx");
                //        break;
                //    case "5": Response.Redirect("../ebookapps/textbooksinvoice.aspx");
                //        break;
                //}
                hdnregistrationvalue.Value = "1";   //if value is one then show the modal popup window
                lbladdcustomermsg.Text = "Customer Registered Successfully";  
            }
        }
        #endregion

     

        

       
    }
}
