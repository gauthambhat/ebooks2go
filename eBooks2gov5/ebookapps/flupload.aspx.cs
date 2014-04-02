using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace eBooks2goV5.ebookapps
{
    public partial class flupload : System.Web.UI.Page
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
 
        #region proceed Image button click event
        protected void imgbtnflproceed_Click(object sender, ImageClickEventArgs e)
        {
            if (IsValidFileSize(getfilesize())) 
            {
                if (Request.QueryString["ID"] == "3")   //if QS is 3 i.e Simple eBook Apps then clear the session(Nullify the session)
                    Session["dtsimpleebookappsfiles"] = null;
                else if (Request.QueryString["ID"] == "4")  //if QS is 4 i.e Complex eBook Apps then clear the session(Nullify the session)
                    Session["dtcomplexebookappsfiles"] = null;
                else
                    Session["dttextbookfiles"] = null;  //if QS is 5 i.e eBook Apps TextBooks then clear the session(Nullify the session)

                    DataTable dtfiles = new DataTable(); //create the datatable to store the fileupload form details.

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
                    if (Request.QueryString["ID"] == "3")
                         Response.Redirect("~/ebookapps/simpleebookfinalcart.aspx?ID=3");
                    else if (Request.QueryString["ID"] == "4")
                        Response.Redirect("~/ebookapps/complexebookappsfinalcart.aspx?ID=4");
                    else
                        Response.Redirect("~/ebookapps/textbooksfinalcart.aspx?ID=5");
                   
                  
            }
             else 
            {
                lblflmsg.Text  = "File size is too long. 10MB only allowed";
                RetainProjectDate();
            }
            
            
        }
        #endregion

        #region store the values from to session 
        private void addtosession(DataTable dtfiles)
        {
            DataRow dr = dtfiles.NewRow();
            dr["title"] = txtfltitle.Text;
            dr["author"] = txtflauthor.Text;
            dr["color"] = (rbflcolor.Checked) ? 1 : 0;
            dr["booklang"] = ddlflbooklang.SelectedItem.Value;
            dr["projectcompletedate"] = txtprojectdate.Text;
            dr["projectfile"] = txtflfilename.Text;  //check wether file is available or not if is available 
            dr["filedescription"] = txtflfiledescription.Text;
            if(flupselectfile.HasFile)
            flupselectfile.SaveAs(Server.MapPath("~/manuscriptdocuments/" + flupselectfile.FileName));
            dtfiles.Rows.Add(dr);
            if (Request.QueryString["ID"] == "3")
                Session["dtsimpleebookappsfiles"] = dtfiles;
            else if (Request.QueryString["ID"] == "4")
                Session["dtcomplexebookappsfiles"] = dtfiles;
            else
                Session["dttextbookfiles"] = dtfiles;
            }
        #endregion

        #region Check file upload size
        private const int MyMaxContentLength = 10485760;//20971520;//10485760;
        public bool IsValidFileSize(int _fileContentLength)
        {
           
            if (_fileContentLength <= MyMaxContentLength)
                return true;
            else
                return false;
        }
        #endregion

        #region Retain Date
        public void RetainProjectDate()
        {
            txtprojectdate.Attributes.Add("value", txtprojectdate.Text);
        }
        #endregion

        #region bindcartvalues
        protected void bindsessionvalues()  //bind the values from session to fileupload form
        {
            DataTable dtsessionvalues;
            if (Request.QueryString["ID"] == "3" && Session["dtsimpleebookappsfiles"] != null)
            {
                dtsessionvalues = (DataTable)Session["dtsimpleebookappsfiles"];
                enableflvalidator(dtsessionvalues);

            }
            else if (Request.QueryString["ID"] == "4" && Session["dtcomplexebookappsfiles"] != null)
            {
                dtsessionvalues = (DataTable)Session["dtcomplexebookappsfiles"];
                enableflvalidator(dtsessionvalues);
            }
            else if (Request.QueryString["ID"] == "5" && Session["dttextbookfiles"] != null)
            {
                dtsessionvalues = (DataTable)Session["dttextbookfiles"];
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
                txtflfilename.Text = dtsessionvalues.Rows[0]["projectfile"].ToString();
                txtflfiledescription.Text = dtsessionvalues.Rows[0]["filedescription"].ToString();
                hdnflupload.Value = dtsessionvalues.Rows[0]["projectfile"].ToString();
            }
            
        }
        #endregion

        #region Assign postback url
        protected void assignpostbackurl()
        {
            if (Request.QueryString["ID"] == "3")
                imgbtnback.PostBackUrl = "../ebookapps/newebookapps.aspx?ID=3";
            else if (Request.QueryString["ID"] == "4")
                imgbtnback.PostBackUrl = "../ebookapps/newebookapps.aspx?ID=4";
            else
                imgbtnback.PostBackUrl = "../ebookapps/newebookapps.aspx?ID=5";
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

        #region upload mutiple files
        protected void uploadfiles()
        {
          
            DataTable dtmultifiles = new DataTable();
            dtmultifiles.Columns.Add("filename", typeof(System.String));

            if (Request.QueryString["ID"] == "3" && Session["simpleeBookfiles"] != null)
            {
                dtmultifiles = savefiles((DataTable)Session["simpleeBookfiles"]);
                Session["simpleeBookfiles"] = dtmultifiles;
            }
            else if (Request.QueryString["ID"] == "4" && Session["complexebookappsfiles"] != null)
            {
                dtmultifiles = savefiles((DataTable)Session["complexebookappsfiles"]);
                Session["complexebookappsfiles"] = dtmultifiles;
            }
            else if (Request.QueryString["ID"] == "5" && Session["textbookebookappfiles"] != null)
            {
                dtmultifiles = savefiles((DataTable)Session["textbookebookappfiles"]);
                Session["textbookebookappfiles"] = dtmultifiles;
            }
            if (Request.QueryString["ID"] == "3")
            {
                dtmultifiles = savefiles(dtmultifiles);
                Session["simpleeBookfiles"] = dtmultifiles;
            }
            else if (Request.QueryString["ID"] == "4")
            {
                dtmultifiles = savefiles(dtmultifiles);
                Session["complexebookappsfiles"] = dtmultifiles;
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
                        (@"~/manuscriptdocuments/" + fileName1));
                        dfiles["filename"] = "~/manuscriptdocuments/" + fileName1;
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
            int filesize=0;
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

    }
}