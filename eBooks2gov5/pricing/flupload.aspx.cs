using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace eBooks2goV5.pricing
{
    public partial class flupload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                assignpostbackurl();
                bindsessionvalues();
                
                    

                txtfltitle.Focus();
            }
            RetainProjectDate();
        }
 
        protected void imgbtnflproceed_Click(object sender, ImageClickEventArgs e)
        {
            if (IsValidFileSize(flupselectfile.PostedFile.ContentLength))
            {
                if (Request.QueryString["ID"] == "1")
                    Session["dteBookfiles"] = null;
                else
                    Session["dtenhancedeBookfiles"] = null;
                    DataTable dtfiles = new DataTable();
                    dtfiles.Columns.Add("title", typeof(System.String));
                    dtfiles.Columns.Add("author", typeof(System.String));
                    dtfiles.Columns.Add("color", typeof(System.String));
                    dtfiles.Columns.Add("booklang", typeof(System.String));
                    dtfiles.Columns.Add("projectcompletedate", typeof(System.String));
                    dtfiles.Columns.Add("filename", typeof(System.String));
                    dtfiles.Columns.Add("projectfile", typeof(System.String));
                    dtfiles.Columns.Add("filedescription", typeof(System.String));
                    addtosession(dtfiles);
                
                    if (Request.QueryString["ID"] == "1")
                         Response.Redirect("~/pricing/ebookfinalcart.aspx?ID=1");
                    else
                        Response.Redirect("~/pricing/enhancedebookfinalcart.aspx?ID=2");
            }
            else
            {
                lblflmsg.Text  = "File size is too long. 10MB only allowed";
                RetainProjectDate();
            }
            
        }

        private void addtosession(DataTable dtfiles)
        {
            DataRow dr = dtfiles.NewRow();
            dr["title"] = txtfltitle.Text;
            dr["author"] = txtflauthor.Text;
            dr["color"] = (rbflcolor.Checked) ? 1 : 0;
            dr["booklang"] = ddlflbooklang.SelectedItem.Text;
            dr["projectcompletedate"] = txtprojectdate.Text;
            dr["filename"] = txtflfilename.Text;
            dr["projectfile"] = (flupselectfile.HasFile) ? flupselectfile.FileName : hdnflupload.Value;  //check wether file is available or not if is available 
            dr["filedescription"] = txtflfiledescription.Text;
            if(flupselectfile.HasFile)
                flupselectfile.SaveAs(Server.MapPath(@"~/ProjDocs/" + flupselectfile.FileName));
            dtfiles.Rows.Add(dr);
            if (Request.QueryString["ID"] == "1")
                Session["dteBookfiles"] = dtfiles;
            else
            Session["dtenhancedeBookfiles"] = dtfiles;
        }


        #region "Check file upload size"
        private const int MyMaxContentLength = 10485760;//20971520;//10485760;
        public bool IsValidFileSize(int _fileContentLength)
        {
            if (_fileContentLength <= MyMaxContentLength)
                return true;
            else
                return false;
        }
        #endregion

        #region "Retain Date"
        public void RetainProjectDate()
        {
            txtprojectdate.Attributes.Add("value", txtprojectdate.Text);
        }
        #endregion


        #region bindcartvalues
        protected void bindsessionvalues()  //bind the values from session to fileupload form
        {
            DataTable dtsessionvalues;
            if (Request.QueryString["ID"] == "1" && Session["dteBookfiles"] != null)
            {
                dtsessionvalues = (DataTable)Session["dteBookfiles"];
                enableflvalidator(dtsessionvalues);

            }
            else if (Request.QueryString["ID"] == "2" && Session["dtEnhancedeBookfiles"] != null)
            {
                dtsessionvalues = (DataTable)Session["dtEnhancedeBookfiles"];
                enableflvalidator(dtsessionvalues);
            }
            else
            {
                dtsessionvalues = new DataTable(); 
                //rfvselectfile.Enabled = true;
            }
            if (dtsessionvalues.Rows.Count > 0)
            {
                txtfltitle.Text = dtsessionvalues.Rows[0]["title"].ToString();
                txtflauthor.Text = dtsessionvalues.Rows[0]["author"].ToString();
                if (dtsessionvalues.Rows[0]["color"].ToString() == "0")
                    rbflbandwcolor.Checked = true;
                else
                    rbflcolor.Checked = true;
                ddlflbooklang.SelectedItem.Text = dtsessionvalues.Rows[0]["booklang"].ToString();
                txtprojectdate.Text = dtsessionvalues.Rows[0]["projectcompletedate"].ToString();
                txtflfilename.Text = dtsessionvalues.Rows[0]["filename"].ToString();
                txtflfiledescription.Text = dtsessionvalues.Rows[0]["filedescription"].ToString();
                hdnflupload.Value = dtsessionvalues.Rows[0]["projectfile"].ToString();
            }
            
        }
        #endregion

        #region Assign postback url
        protected void assignpostbackurl()
        {
            if (Request.QueryString["ID"] == "1")
                imgbtnback.PostBackUrl = "../pricing/ebook.aspx";
            else
                imgbtnback.PostBackUrl = "../pricing/enhancedebook.aspx";
        }

        #endregion

        #region enable or disbale filerequiredvalidator
        protected void enableflvalidator(DataTable dtsession)
        {
            if (dtsession.Rows.Count > 0)
                rfvselectfile.Enabled = false;
            else
                rfvselectfile.Enabled = true;
             
        }
        #endregion
    }
}