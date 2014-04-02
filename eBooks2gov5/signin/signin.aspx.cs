using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Configuration;

namespace eBooks2goV5.signin
{
    public partial class signin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnLogIn_Click(object sender, EventArgs e)
        {
        }

        protected void lnkSignUp_Click(object sender, EventArgs e)
        {

            switch (Request.QueryString["ID"])
            {
                case "1": Response.Write("<script>window.parent.location='../customer/addcustomer.aspx?ID=1';</script>");
                    break;
                case "2": Response.Write("<script>window.parent.location='../customer/addcustomer.aspx?ID=2';</script>");
                    break;
                case "3": Response.Write("<script>window.parent.location='../customer/addcustomer.aspx?ID=3';</script>");
                    break;
                case "4": Response.Write("<script>window.parent.location='../customer/addcustomer.aspx?ID=4';</script>");
                    break;
                case "5": Response.Write("<script>window.parent.location='../customer/addcustomer.aspx?ID=5';</script>");
                    break;
            }
            
            
        }
    }
}

