using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//this is fr mutiple file upload modified by muni
namespace eBooks2goV5.pricing
{
    public partial class fileupload : System.Web.UI.Page
    {
        #region get request
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
        #endregion

        #region proceed image button click event
        protected void imgbtnflproceed_Click(object sender, ImageClickEventArgs e)
        {
            if (IsValidFileSize(getfilesize()))
            {
                if (Request.QueryString["ID"] == "1")
                    Session["dteBookfiles"] = null;
                else
                    Session["dtenhancedeBookfiles"] = null;

                DataTable dtfiles = new DataTable();    //create datatable for fileupload to store the fileupload values i.e title, author, color etc..

                dtfiles.Columns.Add("title", typeof(System.String));
                dtfiles.Columns.Add("author", typeof(System.String));
                dtfiles.Columns.Add("color", typeof(System.String));
                dtfiles.Columns.Add("booklang", typeof(System.String));
                dtfiles.Columns.Add("projectcompletedate", typeof(System.String));
                dtfiles.Columns.Add("filename", typeof(System.String));
                dtfiles.Columns.Add("projectfile", typeof(System.String));
                dtfiles.Columns.Add("filedescription", typeof(System.String));

                addtosession(dtfiles);
                uploadfiles();

                if (Request.QueryString["ID"] == "1")
                    Response.Redirect("~/pricing/ebookfinalcart.aspx?ID=1");
                else
                    Response.Redirect("~/pricing/enhancedebookfinalcart.aspx?ID=2");
            }
            else
            {
                lblflmsg.Text = "File size is too long. 10MB only allowed";
                RetainProjectDate();
            }

        }
        #endregion

        #region store the values from fileupload to session
        private void addtosession(DataTable dtfiles)
        {
            DataRow dr = dtfiles.NewRow(); //create datarow for datatable fileupload

            dr["title"] = txtfltitle.Text;
            dr["author"] = txtflauthor.Text;
            dr["color"] = (rbflcolor.Checked) ? 1 : 0;
            dr["booklang"] = ddlflbooklang.SelectedItem.Value;
            dr["projectcompletedate"] = txtprojectdate.Text.ToString();
            dr["filename"] = txtflfilename.Text;
            dr["projectfile"] = (flupselectfile.HasFile) ? flupselectfile.FileName : hdnflupload.Value;  //check wether file is available or not if it is available upload the                                                                                                             file otherwise not
            dr["filedescription"] = txtflfiledescription.Text;

            if (flupselectfile.HasFile)
            flupselectfile.SaveAs(Server.MapPath("~/manuscriptdocuments/" + flupselectfile.FileName));

            dtfiles.Rows.Add(dr);

            if (Request.QueryString["ID"] == "1")
                Session["dteBookfiles"] = dtfiles;
            else
                Session["dtenhancedeBookfiles"] = dtfiles;
        }
        #endregion

        #region display the values from session to fileupload
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
                ddlflbooklang.SelectedValue = dtsessionvalues.Rows[0]["booklang"].ToString();
                txtprojectdate.Text = dtsessionvalues.Rows[0]["projectcompletedate"].ToString();
                txtflfilename.Text = dtsessionvalues.Rows[0]["filename"].ToString();
                txtflfiledescription.Text = dtsessionvalues.Rows[0]["filedescription"].ToString();
                hdnflupload.Value = dtsessionvalues.Rows[0]["projectfile"].ToString();
            }

        }
        #endregion

        #region "Retain Date"
        public void RetainProjectDate()
        {
            txtprojectdate.Attributes.Add("value", txtprojectdate.Text);
        }
        #endregion

        #region Assign postback url
        protected void assignpostbackurl()//when ever we click the back button it should redirect the form based on we pass the id.
        {
            if (Request.QueryString["ID"] == "1") //if id is 1 i.e eBook it should redirect the ebook form.
                imgbtnback.PostBackUrl = "../pricing/xebook.aspx";
            else
                imgbtnback.PostBackUrl = "../pricing/xenhancedebook.aspx";
        }

        #endregion

        #region enable or disbale filerequiredvalidator
        protected void enableflvalidator(DataTable dtsession)
        {
            //if (dtsession.Rows.Count > 0)
            //    rfvselectfile.Enabled = false;
            //else
            //    rfvselectfile.Enabled = true;

        }
        #endregion

        #region browse the file

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

        #region upload mutiple files
        protected void uploadfiles()
        {

            DataTable dtmultifiles = new DataTable();
            dtmultifiles.Columns.Add("filename", typeof(System.String));

            if (Request.QueryString["ID"] == "1" && Session["eBookfiles"] != null)
            {
                dtmultifiles = savefiles((DataTable)Session["eBookfiles"]);
                Session["eBookfiles"] = dtmultifiles;
            }
            else if (Request.QueryString["ID"] == "2" && Session["enhancedeBookfiles"] != null)
            {
                dtmultifiles = savefiles((DataTable)Session["enhancedeBookfiles"]);
                Session["enhancedeBookfiles"] = dtmultifiles;
            }
            
             else if (Request.QueryString["ID"] == "1")
            {
                dtmultifiles = savefiles(dtmultifiles);
                Session["eBookfiles"] = dtmultifiles;
            }
            else if (Request.QueryString["ID"] == "2")
            {
                dtmultifiles = savefiles(dtmultifiles);
                Session["enhancedeBookfiles"] = dtmultifiles;
            }
            else
            {
                dtmultifiles = savefiles(dtmultifiles);
                Session["textbookebookappfiles"] = dtmultifiles;
            }
        }

        private DataTable savefiles(DataTable dtmulifiles)
        {
            string fileName1 = "";
            HttpFileCollection uploads = Request.Files;
            for (int fileCount = 0; fileCount < 6; fileCount++)
            {
                if (fileCount < uploads.Count)
                {
                    HttpPostedFile uploadedFile = uploads[fileCount];
                    fileName1 = Path.GetFileName(uploadedFile.FileName);
                    if (uploadedFile.ContentLength > 0)
                    {
                        string[] a = new string[1];
                        a = uploadedFile.FileName.Split('.');
                        fileName1 = a.GetValue(0).ToString() +
                        "." + a.GetValue(1).ToString();
                        DataRow dfiles = dtmulifiles.NewRow();
                        uploadedFile.SaveAs(Server.MapPath
                        ("~/manuscriptdocuments/" + fileName1));
                        dfiles["filename"] = "manuscriptdocuments/" + fileName1;
                        dtmulifiles.Rows.Add(dfiles);
                    }
                }
            }
            return dtmulifiles;
        }
        #endregion

        #region check multliple files total size
        private int getfilesize()
        {
            HttpFileCollection uploads = Request.Files;
            int filesize = 0;
            for (int fileCount = 0; fileCount < 6; fileCount++)
            {
                if (fileCount < uploads.Count)
                {
                    HttpPostedFile uploadedFile = uploads[fileCount];
                    filesize += uploadedFile.ContentLength;

                }
            }
            return filesize;
        }
        #endregion

        #endregion
    }
}