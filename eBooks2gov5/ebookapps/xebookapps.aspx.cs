using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace eBooks2goV5.ebookapps
{
    public partial class xebookapps : System.Web.UI.Page
    {
        #region object references
        bel.bel _pcbel = new bel.bel(); // To get the variables from business entity layer(bel) class need to create this object.

        bll.bll _pcbll = new bll.bll(); // To get the business logic i.e methods from business logic layer(bll) class need to create this object.
        #endregion

        #region get request
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               //Response.Write(hdnfieldcat.Value);  //it should display the value of which accordian pane we clicked i.e simple or complex or textbooks ebookapps on the output                                                        screen form.
                getsimpleebookappspcid((int)bel.bel.prodcategory.simpleebookapps); //when we click simple ebook apps from accordian pane tab it should bind the values from                                                                                             databae to form label
                getcomplexebookappspcid((int)bel.bel.prodcategory.complexebookapps); //when we click complex ebook apps from accordian pane tab it should bind the values from                                                                                              database to form label
                getebookappsfortextbookspcid((int)bel.bel.prodcategory.eBookappsfortextbooks);//when we click ebooks apps for textbooks from accordian pane tab it should bind the                                                                                                  values from database to label.
                if (Request.QueryString["ID"] != null)
                {
                    if (Request.QueryString["ID"] == "3")
                        bindsimpleebookappssessionvalues();
                    if (Request.QueryString["ID"] == "4")
                        bindcomplexebookappssessionvalues();
                    else if (Request.QueryString["ID"] == "5")
                        bindtextbookssessionvalues();
                }
                else
                {
                    if (Session["dtsimpleebookappscart"] != null)
                        bindsimpleebookappssessionvalues();
                    else if (Session["dtcomplexebookappscart"] != null)
                        bindcomplexebookappssessionvalues();
                    else if (Session["dttextbookscart"] != null)
                        bindtextbookssessionvalues();
                }
                ebookappscalculation();
                getheaderchk();
               
            }
           
        }
        #endregion

        #region variables declaration
        decimal productprice = 0;
        decimal baseprice = 0;
        decimal pageprice = 0;
        decimal animationpageprice = 0;
        decimal interactiveselfassemntprice = 0;
        decimal audioandvideovprice = 0;
        decimal cartprice = 0;
        #endregion

        #region get values from database to ebook apps form

        #region get simple ebook apps values from database to simple ebook apps form
        protected void getsimpleebookappspcid(int _pcid)
        {
            DataTable dtpc = new DataTable();
            _pcbel.prodid = null;
            _pcbel.pcid = _pcid;

            dtpc = _pcbll.getprodcat(_pcbel); //get all the prodcat details from the Business Logic Layer(BLL) Class and store in datatable.

            //default section start
            lblebookappssimpleebookappsdefaultpages.Text = dtpc.Rows[0]["pcdpages"].ToString(); //display the default pages values from database to label form
            //end

            //offers section start
            lblebookappssimplebookappsoffer1.Text = dtpc.Rows[0]["offer1"].ToString(); //display the offer1 values from db to label
            lblebookappssimplebookappsoffer1discount.Text = dtpc.Rows[0]["offer1dis"].ToString(); //display the offer1discount value from db to label

            lblebookappssimplebookappsoffer2.Text = dtpc.Rows[0]["offer2"].ToString(); //display the offer2 value from database to label
            lblebookappssimplebookappsoffer2discount.Text = dtpc.Rows[0]["offer2dis"].ToString(); //display the offer2discount value from database to label

            lblebookappssimplebookappsoffer3.Text = dtpc.Rows[0]["offer3"].ToString(); //display the offer3 value from database to label
            lblebookappssimplebookappsoffer3discount.Text = dtpc.Rows[0]["offer3dis"].ToString(); //display the offer3discount value from database to label
            //end

            //customization section start
            lblebookappssimpleebookappscustpages.Text = dtpc.Rows[0]["pcdpages"].ToString(); //display the custpages value from db to label
            lblebookappssimpleebookappscustpagescost.Text = dtpc.Rows[0]["perpagecost"].ToString(); //display the custpages cost value from db to label
            //end

            dtpc = _pcbll.getproducts(_pcbel);  //get all the product details from Business Logic Layer(BLL) Class and store it in datatable.

            //products section start
            lblebookappssimpleebookappsipadproductcost.Text = dtpc.Rows[0]["prodcost"].ToString(); //display the ipad cost from database to label

            lblebookappssimpleebookappsiphoneproductcost.Text = dtpc.Rows[1]["prodcost"].ToString(); //display the iphone cost from database to label

            lblebookappssimpleebookappsandroidtabletsproductcost.Text = dtpc.Rows[2]["prodcost"].ToString();    //display the android tablets cost from database to label

            lblebookappssimpleebookappsandroidphonesproductcost.Text = dtpc.Rows[3]["prodcost"].ToString(); //dispaly the android phones cost from database to label
            //end
        }
        #endregion

        #region get complex ebook apps values from database to complex ebook apps form
        protected void getcomplexebookappspcid(int _pcid)
        {
            DataTable dtpc = new DataTable();
            _pcbel.prodid = null;
            _pcbel.pcid = _pcid;

            dtpc = _pcbll.getprodcat(_pcbel); //get all the prodcat details from the Business Logic Layer(BLL) Class and store in datatable.

            //default section start
            lblebookappscomplexebookappsdefaultpages.Text = dtpc.Rows[0]["pcdpages"].ToString(); //display the default pages from database to label form
            lblebookappscomplexebookappsdefaultanimationpages.Text = dtpc.Rows[0]["pcdanimationpages"].ToString(); //display the animationpages value from db to label
            lblebookappscomplexebookappsanimationcost.Text = dtpc.Rows[0]["pcanimationcost"].ToString(); //display the animationpage cost from db to label
           
            //end

            //offers section start
            lblebookappscomplexebookappsoffer1.Text = dtpc.Rows[0]["offer1"].ToString(); //display the offer1 value from db to label
            lblebookappscomplexebookappsoffer1discount.Text = dtpc.Rows[0]["offer1dis"].ToString(); //display the offer1discount value from db to label
            lblebookappscomplexebookappsoffer2.Text = dtpc.Rows[0]["offer2"].ToString(); //display the offer2 value from db to label
            lblebookappscomplexebookappsoffer2discount.Text = dtpc.Rows[0]["offer2dis"].ToString(); //display the offer2discount value from db to label
            lblebookappscomplexebookappsoffer3.Text = dtpc.Rows[0]["offer3"].ToString(); //display the offer3 value from db to label
            lblebookappscomplexebookappsoffer3discount.Text = dtpc.Rows[0]["offer3dis"].ToString(); //display the offer3discount value from db to label
            //end

            //customization section start
            lblebookappscomplexebookappscustpages.Text = dtpc.Rows[0]["pcdpages"].ToString(); //display the custpage values from db to label
            lblebookappscomplexebookappscustpagescost.Text = dtpc.Rows[0]["perpagecost"].ToString(); //display the custpages cost value from db to label

            lblebookappscomplexebookappscustanimationpages.Text = dtpc.Rows[0]["pcdanimationpages"].ToString(); //display the custanimationpages value from db to label
            lblebookappscomplexebookappscustanimationpagescost.Text = dtpc.Rows[0]["pcanimationcost"].ToString(); //display the custanimationpage cost value from db to label
            //end

            dtpc = _pcbll.getproducts(_pcbel);  //get all the product details from Business Logic Layer(BLL) Class and store it in datatable.

            //products section start
            lblebookappscomplexebookappsipadproductcost.Text = dtpc.Rows[0]["prodcost"].ToString(); //display the ipad cost from database to label
            lblebookappscomplexebookappsiphoneproductcost.Text = dtpc.Rows[1]["prodcost"].ToString(); //display the iphone cost from database to label
            lblebookappscomplexebookappsandroidtabletsproductcost.Text = dtpc.Rows[2]["prodcost"].ToString(); //display the android tablets cost from database to label
            lblebookappscomplexebookappsandroidphonesproductcost.Text = dtpc.Rows[3]["prodcost"].ToString(); //dispaly the android phones cost from database to label
            //end
        }
        #endregion

        #region get ebook apps for textbooks values from database to textbooks form
        protected void getebookappsfortextbookspcid(int _pcid)
        {
            DataTable dtpc = new DataTable();
            _pcbel.prodid = null;
            _pcbel.pcid = _pcid;

            dtpc = _pcbll.getprodcat(_pcbel); //get all the prodcat details from the Business Logic Layer(BLL) Class and store in datatable.

            //default section start
            lblebookappsfortextbooksdefaultpages.Text = dtpc.Rows[0]["pcdpages"].ToString(); //display the default pages from database to label form
            //end

            //offers section start
            lblebookappsfortextbooksoffer1.Text = dtpc.Rows[0]["offer1"].ToString(); //display offer1 value from db to label
            lblebookappsfortextbooksoffer1discount.Text = dtpc.Rows[0]["offer1dis"].ToString(); //display offer1discount value from db to label

            lblebookappsfortextbooksoffer2.Text = dtpc.Rows[0]["offer2"].ToString(); //display offer2 value from db to label
            lblebookappsfortextbooksoffer2discount.Text = dtpc.Rows[0]["offer2dis"].ToString(); //display offer2discount from db to label

            lblebookappsfortextbooksoffer3.Text = dtpc.Rows[0]["offer3"].ToString(); //display the offer3 value from db to label
            lblebookappsfortextbooksoffer3discount.Text = dtpc.Rows[0]["offer3dis"].ToString(); //display the offer3discount value from db to label
            //end

            //customization section start
            lblebookappsfortextbookscustpages.Text = dtpc.Rows[0]["pcdpages"].ToString(); //display the custpages value from db to label
            lblebookappsfortextbookscustpagescost.Text = dtpc.Rows[0]["perpagecost"].ToString(); //display the custpages cost value from db to label

            lblebookappsfortextbookscustinteractiveselfassessmentpages.Text = dtpc.Rows[0]["pcdinteractiveselfassessmentQA"].ToString(); //display the selfpages value from db to                                                                                                                                               label
            lblebookappsfortextbookscustinteractiveselfassessmentpagescost.Text = dtpc.Rows[0]["pcinteractiveselfassessmentQAcost"].ToString();//display the selfpagecost value                                                                                                                                                    from db to label

            lblebookappsfortextbookscustavintergrationpages.Text = dtpc.Rows[0]["pcdavelements"].ToString();//display audio and video values from db to label
            lblebookappsfortextbookscustavintergrationpagescost.Text = dtpc.Rows[0]["eachavcost"].ToString(); //display audio and video cost value from db to label


            //end

            dtpc = _pcbll.getproducts(_pcbel);  //get all the product details from Business Logic Layer(BLL) Class and store it in datatable.

            //products section start
            lblebookappsfortextbooksipadproductcost.Text = dtpc.Rows[0]["prodcost"].ToString(); //display the ipad cost from database to label

            lblebookappsfortextbooksiphoneproductcost.Text = dtpc.Rows[1]["prodcost"].ToString(); //display the iphone cost from database to label

            lblebookappsfortextbooksandroidtabletsproductcost.Text = dtpc.Rows[2]["prodcost"].ToString();    //display the android tablets cost from database to label

            lblebookappsfortextbooksandroidphonesproductcost.Text = dtpc.Rows[3]["prodcost"].ToString(); //dispaly the android phones cost from database to label
            //end
        }
        #endregion

        #endregion

        #region Accordian pane
        protected void rbebookappssimpleebookapps_CheckedChanged(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", "showMe('pnlSimple', ' pnlComplex', 'pnltxtbok', this)", true);//when we click simple app it shows div's
            simpleebookappschecked();
        }

        private void simpleebookappschecked()
        {
            if (rbebookappssimpleebookapps.Checked)
            {
                Session["accIndex"] = 0;
                rbebookappscomplexebookapps.Checked = false;
                rbebookappsfortextbooks.Checked = false;

                pnlSimple.Visible = true;
                pnlComplex.Visible = false;
                pnltxtbok.Visible = false;
            }
        }

        protected void rbebookappscomplextebookapps_CheckedChanged(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", "showMe(' pnlComplex', 'pnltxtbok', 'pnlSimple', this)", true);//when we click complex app it shows div's
            complexebookappschecked();
        }

        private void complexebookappschecked()
        {
            if (rbebookappscomplexebookapps.Checked)
            {
                Session["accIndex"] = 1;
                rbebookappssimpleebookapps.Checked = false;
                rbebookappsfortextbooks.Checked = false;
                pnlSimple.Visible = false;
                pnlComplex.Visible = true;
                pnltxtbok.Visible = false;
            }
        }

        protected void rbebookappsfortextbooks_CheckedChanged(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", "showMe('pnltxtbok', 'pnlSimple', ' pnlComplex', this)", true);//when we click textbookks it shows div's
            ebooksappsfortextbookschecked();
        }

        private void ebooksappsfortextbookschecked()
        {
            if (rbebookappsfortextbooks.Checked)
            {
                Session["accIndex"] = 2;
                rbebookappssimpleebookapps.Checked = false;
                rbebookappscomplexebookapps.Checked = false;
                pnlSimple.Visible = false;
                pnlComplex.Visible = false;
                pnltxtbok.Visible = true;
            }
        }

        #region getheaderchk
        private void getheaderchk()
        {
            if (Session["accIndex"] != null)
            {
                if (Session["accIndex"].ToString() == "0")
                {
                    accebookapps.SelectedIndex = 0;
                    rbebookappssimpleebookapps.Checked = true;
                    simpleebookappschecked();
                }
                if (Session["accIndex"].ToString() == "1")
                {
                    accebookapps.SelectedIndex = 1;
                    rbebookappscomplexebookapps.Checked = true;
                    complexebookappschecked();
                }
                if (Session["accIndex"].ToString() == "2")
                {
                    accebookapps.SelectedIndex = 2;
                    rbebookappsfortextbooks.Checked = true;
                    ebooksappsfortextbookschecked();
                }
            }
            if (accebookapps.SelectedIndex == 0)
            {
                rbebookappssimpleebookapps.Checked = true;
                simpleebookappschecked();
            }
            else if (accebookapps.SelectedIndex == 1)
            {
                rbebookappscomplexebookapps.Checked = true;
                complexebookappschecked();
            }
            else
            {
                rbebookappsfortextbooks.Checked = true;
                ebooksappsfortextbookschecked();
            }

        }
        #endregion

        protected void lnkbtnebookappssimpleebookapps_Click(object sender, EventArgs e)
        {
            Session["accIndex"] = 0;
            rbebookappssimpleebookapps.Checked = true;
            rbebookappscomplexebookapps.Checked = false;
            rbebookappsfortextbooks.Checked = false;
            pnlSimple.Visible = true;
            pnlComplex.Visible = false;
            pnltxtbok.Visible = false;
        }

        protected void lnkbtnebookappscomplexebookapps_Click(object sender, EventArgs e)
        {

            Session["accIndex"] = 1;
            rbebookappssimpleebookapps.Checked = false;
            rbebookappscomplexebookapps.Checked = true;
            rbebookappsfortextbooks.Checked = false;
            pnlSimple.Visible = false;
            pnlComplex.Visible = true;
            pnltxtbok.Visible = false;
        }

        protected void lnkbtneBookAppstextbook_Click(object sender, EventArgs e)
        {
            Session["accIndex"] = 2;
            rbebookappssimpleebookapps.Checked = false;
            rbebookappscomplexebookapps.Checked = false;
            rbebookappsfortextbooks.Checked = true;
            pnlSimple.Visible = false;
            pnlComplex.Visible = false;
            pnltxtbok.Visible = true;
        }

        #endregion

        #region checkbox checkedchanged event
        protected void chkebookappssimpleebookappsipad_CheckedChanged(object sender, EventArgs e)
        {
            ebookappscalculation();
        }
        #endregion

        #region Simple eBook Apps Calculation

        #region Each products calculation
        private decimal getproductprice(int pcid) //here pass the pcid like either it may be 3 nor 4 nor 5
        {
            switch (pcid)
            {
                case 3: //here 3 means simple ebook apps that value coming from prodcat table in a database
                    productprice = (chkebookappssimpleebookappsipad.Checked) ? Convert.ToDecimal(lblebookappssimpleebookappsipadproductcost.Text) : 0;
                    productprice += (chkebookappssimpleebookappsiphone.Checked) ? Convert.ToDecimal(lblebookappssimpleebookappsiphoneproductcost.Text) : 0;
                    productprice += (chkebookappssimpleebookappsandroidtablets.Checked) ? Convert.ToDecimal(lblebookappssimpleebookappsandroidtabletsproductcost.Text) : 0;
                    productprice += (chkebookappssimpleebookappsandroidphones.Checked) ? Convert.ToDecimal(lblebookappssimpleebookappsandroidphonesproductcost.Text) : 0;
                    return productprice;

                case 4: //here 4 means complex ebook apps that value coming from prodcat table in database
                    productprice = (chkebookappscomplexebookappsipad.Checked) ? Convert.ToDecimal(lblebookappscomplexebookappsipadproductcost.Text) : 0;
                    productprice += (chkebookappscomplexebookappsiphone.Checked) ? Convert.ToDecimal(lblebookappscomplexebookappsiphoneproductcost.Text) : 0;
                    productprice += (chkebookappscomplexebookappsandroidtablets.Checked) ? Convert.ToDecimal(lblebookappscomplexebookappsandroidtabletsproductcost.Text) : 0;
                    productprice += (chkebookappscomplexebookappsandroidphones.Checked) ? Convert.ToDecimal(lblebookappscomplexebookappsandroidphonesproductcost.Text) : 0;
                    return productprice;

                default: //here default means 5 i.e 5 is ebook apps for textbooks that value coming from prodcat table in database.
                    productprice = (chkebookappsfortextbooksipad.Checked) ? Convert.ToDecimal(lblebookappsfortextbooksipadproductcost.Text) : 0;
                    productprice += (chkebookappsfortextbooksiphone.Checked) ? Convert.ToDecimal(lblebookappsfortextbooksiphoneproductcost.Text) : 0;
                    productprice += (chkebookappsfortextbooksandroidtablets.Checked) ? Convert.ToDecimal(lblebookappsfortextbooksandroidtabletsproductcost.Text) : 0;
                    productprice += (chkebookappsfortextbooksandroidphones.Checked) ? Convert.ToDecimal(lblebookappsfortextbooksandroidphonesproductcost.Text) : 0;
                    return productprice;
            }

        }
        #endregion

        #region products offer price calculation
        private decimal getsimpleebookappsbasecostforproduct(int count, int offer1, int offer2, int offer3)
        {
            if (count == 0)
                return 0;
            else if (count < offer1)
                baseprice = getproductprice(3);
            else if (count == offer1 || count < offer2)
                baseprice = (getproductprice(3)) * ((100 - Convert.ToDecimal(lblebookappssimplebookappsoffer1discount.Text.Replace(@"%", string.Empty))) / 100);
            else if(count == offer2 || count < offer3)
                baseprice = (getproductprice(3)) * ((100 - Convert.ToDecimal(lblebookappssimplebookappsoffer2discount.Text.Replace(@"%", string.Empty))) / 100);
            else
                baseprice = (getproductprice(3)) * ((100 - Convert.ToDecimal(lblebookappssimplebookappsoffer3discount.Text.Replace(@"%", string.Empty))) / 100);
            return baseprice;

        }
        #endregion

        #region customizations calculations

        #region calculate pageprice
        private decimal getpagevalues(int count)
        {
            if (!string.IsNullOrEmpty(txtebookappssimpleebookappscustpages.Text))
            {
                if (Convert.ToInt32(txtebookappssimpleebookappscustpages.Text) > Convert.ToInt32(lblebookappssimpleebookappscustpages.Text))
                {
                    pageprice += count * (Convert.ToInt32(txtebookappssimpleebookappscustpages.Text) - Convert.ToInt32(lblebookappssimpleebookappscustpages.Text)) * ((Convert.ToDecimal(lblebookappssimpleebookappscustpagescost.Text)));
                    lblebookappssimpleebookappsadditionalpages.Text = (Convert.ToInt32(txtebookappssimpleebookappscustpages.Text) - Convert.ToInt32(lblebookappssimpleebookappscustpages.Text)).ToString();
                    lblebookappssimpleebookappsadditonalpagesunitcost.Text = (Convert.ToDecimal(lblebookappssimpleebookappscustpagescost.Text)).ToString();
                    lblebookappssimpleebookappsadditionaltotalcost.Text = getaddtionalcost(Convert.ToInt32(lblebookappssimpleebookappsadditionalpages.Text), Convert.ToDecimal(lblebookappssimpleebookappsadditonalpagesunitcost.Text), count).ToString();
                    return pageprice;
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

        #region get the addtional page multiplication cost
        private decimal getaddtionalcost(int additionalunits, decimal unitcost, int count)
        {
            return (additionalunits * unitcost * count);
        }
        #endregion

        #region clear the additional pages values
        private void clearpagevalues()
        {
            lblebookappssimpleebookappsadditionalpages.Text = "";
            lblebookappssimpleebookappsadditonalpagesunitcost.Text = "";
            lblebookappssimpleebookappsadditionaltotalcost.Text = "";
        }
        #endregion

        #endregion

        #endregion

        #region Complex eBook Apps Calculation

        #region Complex eBook Apps products offer price calculation
        private decimal getcomplexebookappsbasecostforproduct(int count, int offer1, int offer2, int offer3)
        {
            if (count == 0)
                return 0;
            else if (count < offer1)
                baseprice = getproductprice(4);
            else if (count == offer1 || count < offer2)
                baseprice = (getproductprice(4)) * ((100 - Convert.ToDecimal(lblebookappscomplexebookappsoffer1discount.Text.Replace(@"%", string.Empty))) / 100);
            else if (count == offer2 || count < offer3)
                baseprice = (getproductprice(4)) * ((100 - Convert.ToDecimal(lblebookappscomplexebookappsoffer2discount.Text.Replace(@"%", string.Empty))) / 100);
            else
                baseprice = (getproductprice(4)) * ((100 - Convert.ToDecimal(lblebookappscomplexebookappsoffer3discount.Text.Replace(@"%", string.Empty))) / 100);
            return baseprice;

        }
        #endregion

        #region complex eBook Apps customizations calculations

        #region cust page calc

        #region calculate pageprice
        private decimal getcomplexebookappspagevalues(int count)
        {
            if (!string.IsNullOrEmpty(txtebookappscomplexebookappscustpages.Text))
            {
                if (Convert.ToInt32(txtebookappscomplexebookappscustpages.Text) > Convert.ToInt32(lblebookappscomplexebookappscustpages.Text))
                {
                    pageprice += count * (Convert.ToInt32(txtebookappscomplexebookappscustpages.Text) - Convert.ToInt32(lblebookappscomplexebookappscustpages.Text)) * ((Convert.ToDecimal(lblebookappscomplexebookappscustpagescost.Text)));

                    lblebookappscomplexebookappsadditionalpages.Text = (Convert.ToInt32(txtebookappscomplexebookappscustpages.Text) - Convert.ToInt32(lblebookappscomplexebookappscustpages.Text)).ToString();

                    lblebookappscomplexebookappsaddtionalpagesunitcost.Text = (Convert.ToDecimal(lblebookappscomplexebookappscustpagescost.Text)).ToString();

                    lblebookappscomplexebookappsadditionalpagestotalcost.Text = getcomplexebookappsaddtionalcost(Convert.ToInt32(lblebookappscomplexebookappsadditionalpages.Text), Convert.ToDecimal(lblebookappscomplexebookappsaddtionalpagesunitcost.Text), count).ToString();
                    return pageprice;
                }
                else
                {
                    clearcomplexebookappspagevalues();
                    return 0;
                }
            }
            else
            {
                clearcomplexebookappspagevalues();
                return 0;
            }
        }
        #endregion

        #region get the addtional page multiplication cost
        private decimal getcomplexebookappsaddtionalcost(int additionalunits, decimal unitcost, int count)
        {
            return (additionalunits * unitcost * count);
        }
        #endregion

        #region clear the additional pages values
        private void clearcomplexebookappspagevalues()
        {
            lblebookappscomplexebookappsadditionalpages.Text = "";
            lblebookappscomplexebookappsaddtionalpagesunitcost.Text = "";
            lblebookappscomplexebookappsadditionalpagestotalcost.Text = "";
        }
        #endregion

        #endregion

        #region cust animation page calc

        #region calculate animation pageprice
        private decimal getcomplexebookappsanimationpagevalues(int count)
        {
            if (!string.IsNullOrEmpty(txtebookappscomplexebookappscustanimationpages.Text))
            {
                if (Convert.ToInt32(txtebookappscomplexebookappscustanimationpages.Text) > Convert.ToInt32(lblebookappscomplexebookappscustanimationpages.Text))
                {
                    animationpageprice += count * (Convert.ToInt32(txtebookappscomplexebookappscustanimationpages.Text) - Convert.ToInt32(lblebookappscomplexebookappscustanimationpages.Text)) * ((Convert.ToDecimal(lblebookappscomplexebookappscustanimationpagescost.Text)));

                    lblebookappscomplexebookappsadditionalanimationpages.Text = (Convert.ToInt32(txtebookappscomplexebookappscustanimationpages.Text) - Convert.ToInt32(lblebookappscomplexebookappscustanimationpages.Text)).ToString();

                    lblebookappscomplexebookappsadditionalanimationpagesunitcost.Text = (Convert.ToDecimal(lblebookappscomplexebookappscustanimationpagescost.Text)).ToString();

                    lblebookappscomplexebookappsadditionalanimationpagestotalcost.Text = getcomplexebookappsaddtionalanimationcost(Convert.ToInt16(lblebookappscomplexebookappsadditionalanimationpages.Text), Convert.ToDecimal(lblebookappscomplexebookappsadditionalanimationpagesunitcost.Text),count).ToString();
                    return animationpageprice;
                }
                else
                {
                    clearcomplexebookappsanimationpagevalues();
                    return 0;
                }
            }
            else
            {
                clearcomplexebookappsanimationpagevalues();
                return 0;
            }
        }
        #endregion

        #region get the addtional animation page multiplication cost
        private decimal getcomplexebookappsaddtionalanimationcost(int additionalunits, decimal unitcost, int count)
        {
            return (additionalunits * unitcost * count);
        }
        #endregion

        #region clear the additional animation pages values
        private void clearcomplexebookappsanimationpagevalues()
        {
            lblebookappscomplexebookappsadditionalanimationpages.Text = "";
            lblebookappscomplexebookappsadditionalanimationpagesunitcost.Text = "";
            lblebookappscomplexebookappsadditionalanimationpagestotalcost.Text = "";
        }
        #endregion

        #endregion

        #endregion

        #endregion

        #region eBook Apps For TextBooks

        #region eBook Apps for textbooks product offer price calc
        private decimal getebookappsfortextbooksbasecostforproduct(int count, int offer1, int offer2, int offer3)
        {
            if (count == 0)
                return 0;
            else if (count < offer1)
                baseprice = getproductprice(5);
            else if (count == offer1 || count < offer2)
                baseprice = (getproductprice(5)) * ((100 - Convert.ToDecimal(lblebookappsfortextbooksoffer1discount.Text.Replace(@"%", string.Empty))) / 100);
            else if (count == offer2 || count < offer3)
                baseprice = (getproductprice(5)) * ((100 - Convert.ToDecimal(lblebookappsfortextbooksoffer2discount.Text.Replace(@"%", string.Empty))) / 100);
            else
                baseprice = (getproductprice(5)) * ((100 - Convert.ToDecimal(lblebookappsfortextbooksoffer3discount.Text.Replace(@"%", string.Empty))) / 100);
            return baseprice;

        }
        #endregion

        #region ebook apps for textbooks customizations

        #region cust page calc

        #region calculate pageprice
        private decimal getebookappsfortextbookspagevalues(int count)
        {
            if (!string.IsNullOrEmpty(txtebookappsfortextbookscustpages.Text))
            {
                if (Convert.ToInt32(txtebookappsfortextbookscustpages.Text) > Convert.ToInt32(lblebookappsfortextbookscustpages.Text))
                {
                    pageprice += count * (Convert.ToInt32(txtebookappsfortextbookscustpages.Text) - Convert.ToInt32(lblebookappsfortextbookscustpages.Text)) * ((Convert.ToDecimal(lblebookappsfortextbookscustpagescost.Text)));

                    lblebookappsfortextbooksadditionalpages.Text = (Convert.ToInt32(txtebookappsfortextbookscustpages.Text) - Convert.ToInt32(lblebookappsfortextbookscustpages.Text)).ToString();

                    lblebookappsfortextbooksadditionalpagesunitcost.Text = (Convert.ToDecimal(lblebookappsfortextbookscustpagescost.Text)).ToString();

                    lblebookappsfortextbooksadditionalpagestotalcost.Text = getebookappsfortextbooksadditionalpagescost(Convert.ToInt32(lblebookappsfortextbooksadditionalpages.Text), Convert.ToDecimal(lblebookappsfortextbooksadditionalpagesunitcost.Text), count).ToString();
                    return pageprice;
                }
                else
                {
                    clearebookappsfortextbookspages();
                    return 0;
                }
            }
            else
            {
                clearebookappsfortextbookspages();
                return 0;
            }
        }
        #endregion

        #region get the addtional page multiplication cost
        private decimal getebookappsfortextbooksadditionalpagescost(int additionalunits, decimal unitcost, int count)
        {
            return (additionalunits * unitcost * count);
        }
        #endregion

        #region clear the additional pages values
        private void clearebookappsfortextbookspages()
        {
            lblebookappsfortextbooksadditionalpages.Text = "";
            lblebookappsfortextbooksadditionalpagesunitcost.Text = "";
            lblebookappsfortextbooksadditionalpagestotalcost.Text = "";
        }
        #endregion

        #endregion

        #region Interactive Selfassessement QA

        #region calculate Interactive self assessment QA calc
        private decimal getebookappsfortextbooksinteracitve(int count)
        {
            if (!string.IsNullOrEmpty(txtebookappsfortextbookscustinteractiveandselfassessmentpages.Text))
            {
                if (Convert.ToInt32(txtebookappsfortextbookscustinteractiveandselfassessmentpages.Text) > Convert.ToInt32(lblebookappsfortextbookscustinteractiveselfassessmentpages.Text))
                {
                    interactiveselfassemntprice += count * (Convert.ToInt32(txtebookappsfortextbookscustinteractiveandselfassessmentpages.Text) - Convert.ToInt32(lblebookappsfortextbookscustinteractiveselfassessmentpages.Text)) * ((Convert.ToDecimal(lblebookappsfortextbookscustinteractiveselfassessmentpagescost.Text)));

                    lblebookappsfortextbooksadditionalinteractiveselfassessmentpages.Text = (Convert.ToInt32(txtebookappsfortextbookscustinteractiveandselfassessmentpages.Text) - Convert.ToInt32(lblebookappsfortextbookscustinteractiveselfassessmentpages.Text)).ToString();

                    lblebookappsfortextbooksadditionalinteractiveselfassessmentunitcost.Text = (Convert.ToDecimal(lblebookappsfortextbookscustinteractiveselfassessmentpagescost.Text)).ToString();

                    lblebookappsfortextbooksadditionalinteractiveselfassessmenttotalcost.Text = getebookappsfortextbooksaddtionalcost(Convert.ToInt32(lblebookappsfortextbooksadditionalinteractiveselfassessmentpages.Text), Convert.ToDecimal(lblebookappsfortextbooksadditionalinteractiveselfassessmentunitcost.Text), count).ToString();
                    return interactiveselfassemntprice;
                }
                else
                {
                    clearebookappsfortextbooksinteractiveselfassessmentpagevalues();
                    return 0;
                }
            }
            else
            {
                clearebookappsfortextbooksinteractiveselfassessmentpagevalues();
                return 0;
            }
        }
        #endregion

        #region get the addtional page multiplication cost
        private decimal getebookappsfortextbooksaddtionalcost(int additionalunits, decimal unitcost, int count)
        {
            return (additionalunits * unitcost * count);
        }
        #endregion

        #region clear the ebooks apps for textbooks interactive selfassessment  pages values
        private void clearebookappsfortextbooksinteractiveselfassessmentpagevalues()
        {
            lblebookappsfortextbooksadditionalinteractiveselfassessmentpages.Text = "";
            lblebookappsfortextbooksadditionalinteractiveselfassessmentunitcost.Text = "";
            lblebookappsfortextbooksadditionalinteractiveselfassessmenttotalcost.Text = "";
        }
        #endregion

        #endregion

        #region audio and video integration

        #region calculate ebook apps for textbooks audio and video integration
        private decimal getebookappsfortextbooksaudioandvideo(int count)
        {
            if (!string.IsNullOrEmpty(txtebookappsfortextbookscustavelements.Text))
            {
                if (Convert.ToInt32(txtebookappsfortextbookscustavelements.Text) > Convert.ToInt32(lblebookappsfortextbookscustavintergrationpages.Text))
                {
                    audioandvideovprice += count * (Convert.ToInt32(txtebookappsfortextbookscustavelements.Text) - Convert.ToInt32(lblebookappsfortextbookscustavintergrationpages.Text)) * ((Convert.ToDecimal(lblebookappsfortextbookscustavintergrationpagescost.Text)));

                    lblebookappstextbooksadditionalavelements.Text = (Convert.ToInt32(txtebookappsfortextbookscustavelements.Text) - Convert.ToInt32(lblebookappsfortextbookscustavintergrationpages.Text)).ToString();

                    lblebookappstextbooksadditionalavelementsunitcost.Text = (Convert.ToDecimal(lblebookappsfortextbookscustavintergrationpagescost.Text)).ToString();

                    lblebookappstextbooksadditionalavelementstotalcost.Text = getebookappsfortextbooksaudioandvideoaddtionalcost(Convert.ToInt32(lblebookappstextbooksadditionalavelements.Text), Convert.ToDecimal(lblebookappstextbooksadditionalavelementsunitcost.Text), count).ToString();
                    return audioandvideovprice;
                }
                else
                {
                    clearaudioandvideopagevalues();
                    return 0;
                }
            }
            else
            {
                clearaudioandvideopagevalues();
                return 0;
            }
        }
        #endregion

        #region get the addtional page multiplication cost
        private decimal getebookappsfortextbooksaudioandvideoaddtionalcost(int additionalunits, decimal unitcost, int count)
        {
            return (additionalunits * unitcost * count);
        }
        #endregion

        #region clear the ebooks apps for textbooks audio and video pages values
        private void clearaudioandvideopagevalues()
        {
            lblebookappstextbooksadditionalavelements.Text = "";
            lblebookappstextbooksadditionalavelementsunitcost.Text = "";
            lblebookappstextbooksadditionalavelementstotalcost.Text = "";
        }
        #endregion

        #endregion

        #endregion

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

        #region trim the decimal points
        private string roundofdecimalpoints(decimal x)
        {
            return Math.Round(x, 2).ToString();
        }
        #endregion

        #region calculation for eBook Apps
        private void ebookappscalculation()
        {
            int pcid = getproductcategoryid();

            productprice = getproductprice(pcid);

            if (pcid == (int)bel.bel.prodcategory.simpleebookapps) //if it is a simple ebook apps then do simple ebook apps calculation
            {
                int count = 0;
                count = getcount(pnlebookappssimpleebookappsproducts);//here count will check how many product checkboxs are checked and store that count in count variable.
                if (count > 0)
                {
                    baseprice = getsimpleebookappsbasecostforproduct(count, Convert.ToInt16(lblebookappssimplebookappsoffer1.Text), Convert.ToInt16(lblebookappssimplebookappsoffer2.Text), Convert.ToInt16(lblebookappssimplebookappsoffer3.Text)); //store the product price cost in baseprice variable
                    pageprice = getpagevalues(count);   //store the page calculation cost in pageprice variable
                    cartprice = baseprice + pageprice;  //store the total simple ebook apps calculation cost in cartprice vairable
                    txtebookappssimpleebookappspackagecost.Text = roundofdecimalpoints(cartprice); //display the total simple ebook apps cost to textbox control
                    imgbtnsimpleproceed.Enabled = true;
                }
                else
                {
                    txtboxsclearforsimpleebookapps();
                    imgbtnsimpleproceed.Enabled = false;

                }

            }
            else if (pcid == (int)bel.bel.prodcategory.complexebookapps) //if it is a complex ebook apps then do complex ebook app calculation
            {
                int count = 0;
                count = getcount(pnlebookappscomplexebookappsproducts);//here count will check how many product checkboxs are checked and store that count in count variable.
                if (count > 0)
                {
                    baseprice = getcomplexebookappsbasecostforproduct(count, Convert.ToInt16(lblebookappscomplexebookappsoffer1.Text), Convert.ToInt16(lblebookappscomplexebookappsoffer2.Text), Convert.ToInt16(lblebookappscomplexebookappsoffer3.Text)); //store the product price cost in baseprice variable
                    pageprice = getcomplexebookappspagevalues(count);   //store the page calculation cost in pageprice variable
                    animationpageprice = getcomplexebookappsanimationpagevalues(count);
                    cartprice = baseprice + pageprice + animationpageprice;  //store the total simple ebook apps calculation cost in cartprice vairable
                    txtebookappscomplexebookappspackagecost.Text = roundofdecimalpoints(cartprice); //display the total simple ebook apps cost to textbox control

                    imgbtncomplexproceed.Enabled = true;
                }
                else
                {
                    txtboxsclearforcomplexebookapps();
                    imgbtncomplexproceed.Enabled = false;
                }

            }
            else //if it is a ebook apps for textbooks then do the ebook apps for textbook calculation.
            {
                int count = 0;
                count = getcount(pnlebookappsfortextbooksproducts);//here count will check how many product checkboxs are checked and store that count in count variable.
                if (count > 0)
                {
                    baseprice = getebookappsfortextbooksbasecostforproduct(count, Convert.ToInt16(lblebookappsfortextbooksoffer1.Text), Convert.ToInt16(lblebookappsfortextbooksoffer2.Text), Convert.ToInt16(lblebookappsfortextbooksoffer3.Text)); //store the product price cost in baseprice variable
                    pageprice = getebookappsfortextbookspagevalues(count);   //store the page calculation cost in pageprice variable
                    interactiveselfassemntprice = getebookappsfortextbooksinteracitve(count);
                    audioandvideovprice = getebookappsfortextbooksaudioandvideo(count);
                    cartprice = baseprice + pageprice + interactiveselfassemntprice + audioandvideovprice;  //store the total simple ebook apps calculation cost in cartprice vairable
                    txtebookappsfortextbookspackagecost.Text = roundofdecimalpoints(cartprice); //display the total simple ebook apps cost to textbox control

                    imgbtntextbook.Enabled = true;
                }
                else
                {
                    txtboxsclearforebookappsfortextbooks();
                    imgbtntextbook.Enabled = false;
                }

            }

        }
        #endregion

        #region To Clear All the Controls From eBook Apps
       private void txtboxsclearforebookappsfortextbooks()
        {
            txtebookappsfortextbookspackagecost.Text = "";
            txtebookappsfortextbookscustpages.Text = "";
            txtebookappsfortextbookscustinteractiveandselfassessmentpages.Text = "";
            txtebookappsfortextbookscustavelements.Text = "";
        }

        private void txtboxsclearforcomplexebookapps()
        {
            txtebookappscomplexebookappspackagecost.Text = "";
            txtebookappscomplexebookappscustpages.Text = "";
            txtebookappscomplexebookappscustanimationpages.Text = "";
        }

        private void txtboxsclearforsimpleebookapps()
        {
            txtebookappssimpleebookappspackagecost.Text = "";
            txtebookappssimpleebookappscustpages.Text = "";
        }
        
        #region clear all checkbox values from eBook Apps form
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

        #endregion

        #region proceed button click event
        protected void imgbtnsimpleproceed_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ib = (ImageButton)sender;
            if (ib.ID == "imgbtnsimpleproceed")
            {
                storeinCartsimpleebookapps();
                Response.Redirect("~/ebookapps/simpleebookfinalcart.aspx?ID=3");
            }//based on select the accordian pane tab we can pass the accordian pane tab values in this method i.e suppose if we select simple we can pass                                       3 or if we select complex we can pass 4 or if we select textbooks we can pass 5
            else if (ib.ID == "imgbtncomplexproceed")
            {
                storeinCartcomplexebookapps();
                Response.Redirect("~/ebookapps/complexebookappsfinalcart.aspx?ID=4");
            }
            else
            {
                storeinCarttextbooks();
                Response.Redirect("~/ebookapps/textbooksfinalcart?ID=5");
            }

        }

        #region accordian tab pane to proceed button
        private int getproductcategoryid() //when we click proceed button it should display those details based on select the accordian pane.
        {
            switch (accebookapps.SelectedIndex) //here hiddenfiled capture the value of accordian tab pane.
            {
                case  2: return 5; //if you click accordian pane 5, i.e ebookapps for textbooks it should display that div content only.

                case   1: return 4;    //if you click accordian pane 2, i.e complex ebookapps it should display that div content only

                default: return 3; //otherwise it should display accordian pane 1, i.e simple ebookapps div content

            }
        }
        #endregion

        #endregion

        #region store the values from simple ebook apps form to session

        #region simple ebook apps form values store in session
        private void storeinCartsimpleebookapps()
        {
            Session["dtsimpelebookappscart"] = null;  //after moving the values from session to eBook form then session should be cleared.
            //if (Session["dteBookcart"] == null)
            //{
            DataTable dtsimpleebookappscart = new DataTable();

            dtsimpleebookappscart.Columns.Add("cartid", typeof(System.String));
            dtsimpleebookappscart.Columns.Add("productname", typeof(System.String));
            dtsimpleebookappscart.Columns.Add("pcid", typeof(System.String));
            dtsimpleebookappscart.Columns.Add("qty", typeof(System.String));
            dtsimpleebookappscart.Columns.Add("unitcost", typeof(System.String));
            dtsimpleebookappscart.Columns.Add("totalcost", typeof(System.String));
            dtsimpleebookappscart.Columns.Add("parentid", typeof(System.String));
            

            addtosession(dtsimpleebookappscart);
            //}
            //else
            //{
            //    DataTable dteBookcart=(DataTable)Session["dteBookcart"];
            //    addtosession(dteBookcart);
            //}
        }
        #endregion

        private void addtosession(DataTable dtsimpleebookappscart)
        {
            #region Simple eBook Apps Products

            #region Add Simple ebook apps ipad product to cart
            if (chkebookappssimpleebookappsipad.Checked)
            {
                DataRow dr = dtsimpleebookappscart.NewRow();
                dr["cartid"] = "3.1";
                dr["pcid"] = "3";
                dr["qty"] = "1";
                dr["productname"] = "IPad";
                dr["unitcost"] = Convert.ToDecimal(lblebookappssimpleebookappsipadproductcost.Text);
                dr["totalcost"] = Convert.ToDecimal(lblebookappssimpleebookappsipadproductcost.Text);
                dtsimpleebookappscart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtsimpleebookappscart.NewRow();
                dr["cartid"] = "3.1";
                dr["pcid"] = "3";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtsimpleebookappscart.Rows.Add(dr);
            }

            #endregion

            #region Add Simple eBook Apps Iphone to cart
            if (chkebookappssimpleebookappsiphone.Checked)
            {
                DataRow dr = dtsimpleebookappscart.NewRow();
                dr["cartid"] = "3.2";
                dr["pcid"] = "3";
                dr["qty"] = "1";
                dr["productname"] = "IPhone";
                dr["unitcost"] = Convert.ToDecimal(lblebookappssimpleebookappsiphoneproductcost.Text);
                dr["totalcost"] = Convert.ToDecimal(lblebookappssimpleebookappsiphoneproductcost.Text);
                dtsimpleebookappscart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtsimpleebookappscart.NewRow();
                dr["cartid"] = "3.2";
                dr["pcid"] = "3";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtsimpleebookappscart.Rows.Add(dr);
            }

            #endregion

            #region Add Simple eBook Apps Android Tablets to cart

            if (chkebookappssimpleebookappsandroidtablets.Checked)
            {
                DataRow dr = dtsimpleebookappscart.NewRow();
                dr["cartid"] = "3.3";
                dr["pcid"] = "3";
                dr["qty"] = "1";
                dr["productname"] = "Android Tablets";
                dr["unitcost"] = Convert.ToDecimal(lblebookappssimpleebookappsandroidtabletsproductcost.Text);
                dr["totalcost"] = Convert.ToDecimal(lblebookappssimpleebookappsandroidtabletsproductcost.Text);
                dtsimpleebookappscart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtsimpleebookappscart.NewRow();
                dr["cartid"] = "3.3";
                dr["pcid"] = "3";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtsimpleebookappscart.Rows.Add(dr);
            }
            #endregion

            #region Add Simple eBook Apps Android phones to cart
            if (chkebookappssimpleebookappsandroidphones.Checked)
            {
                DataRow dr = dtsimpleebookappscart.NewRow();
                dr["cartid"] = "3.4";
                dr["pcid"] = "3";
                dr["qty"] = "1";
                dr["productname"] = "Android Phones";
                dr["unitcost"] = Convert.ToDecimal(lblebookappssimpleebookappsandroidphonesproductcost.Text);
                dr["totalcost"] = Convert.ToDecimal(lblebookappssimpleebookappsandroidphonesproductcost.Text);
                dtsimpleebookappscart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtsimpleebookappscart.NewRow();
                dr["cartid"] = "3.4";
                dr["pcid"] = "3";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtsimpleebookappscart.Rows.Add(dr);
            }
            #endregion

            #endregion

            #region Simple eBook Apps Customizations
            if (!string.IsNullOrEmpty(txtebookappssimpleebookappscustpages.Text))
            {
                DataRow dr = dtsimpleebookappscart.NewRow();
                dr["cartid"] = "3a";
                dr["pcid"] = "3";
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["productname"] = "Total Number of pages in the Book";
                dr["qty"] = txtebookappssimpleebookappscustpages.Text;
                dr["unitcost"] = lblebookappssimpleebookappsadditonalpagesunitcost.Text;
                dr["totalcost"] = lblebookappssimpleebookappsadditionaltotalcost.Text;
                dtsimpleebookappscart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtsimpleebookappscart.NewRow();
                dr["cartid"] = "3a";
                dr["pcid"] = "3";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtsimpleebookappscart.Rows.Add(dr);
            }
            #endregion

            Session["dtsimpleebookappscart"] = dtsimpleebookappscart;   //store the simple ebook apps form values from datatable to session

            Session["simpleeBookappscarttotal"] = roundofdecimalpoints(Convert.ToDecimal(txtebookappssimpleebookappspackagecost.Text)); //calculate the simple ebook apps total and                                                                                                                                         store it in session
            int productcount = getcount(pnlebookappssimpleebookappsproducts);

            baseprice = getsimpleebookappsbasecostforproduct(productcount, Convert.ToInt16(lblebookappssimplebookappsoffer1.Text), Convert.ToInt16(lblebookappssimplebookappsoffer2.Text), Convert.ToInt16(lblebookappssimplebookappsoffer3.Text));

            decimal simpleebookappsdiscountonbasepkg = getproductprice(3) - baseprice;

            Session["simpleebookappstotaldiscount"] = simpleebookappsdiscountonbasepkg;
            Session["simpleebookappsdiscountonbasepkg"] = roundofdecimalpoints(simpleebookappsdiscountonbasepkg);
            Session["simpleebookappsproductprice"] = roundofdecimalpoints(getproductprice(3));

        }

        #endregion

        #region display values from session to simple ebook apps form

        #region bindcartvalues to eBook form
        protected void bindsimpleebookappssessionvalues()  //dispalay the values session to simple ebook apps form
        {
            DataTable dtsimpleebookappscart = (DataTable)Session["dtsimpleebookappscart"];

            //displaying the product values from session to eBook form start
            chkebookappssimpleebookappsipad.Checked = getvaluesfromrow(dtsimpleebookappscart, "3.1")["qty"].ToString() == "1" ? true : false;
            chkebookappssimpleebookappsiphone.Checked = getvaluesfromrow(dtsimpleebookappscart, "3.2")["qty"].ToString() == "1" ? true : false;
            chkebookappssimpleebookappsandroidtablets.Checked = getvaluesfromrow(dtsimpleebookappscart, "3.3")["qty"].ToString() == "1" ? true : false;
            chkebookappssimpleebookappsandroidphones.Checked = getvaluesfromrow(dtsimpleebookappscart, "3.4")["qty"].ToString() == "1" ? true : false;
            //complete

            //displaying the cust values from session to eBook values begin
            txtebookappssimpleebookappscustpages.Text = getvaluesfromrow(dtsimpleebookappscart, "3a")["qty"].ToString();

            accebookapps.SelectedIndex = 0;
           



          





        }
        #endregion


        #region get data row values
        private static DataRow getvaluesfromrow(DataTable dtEnhancedeBookcart, string s)
        {
            DataRow[] filteredRows =
                  dtEnhancedeBookcart.Select(string.Format("{0} LIKE '%{1}%'", "cartid", s));
            return filteredRows[0];
        }
        #endregion

        #endregion

        #region store the values from complex ebook apps form to session

        #region complex ebook apps form values store in session
        private void storeinCartcomplexebookapps()
        {
            Session["dtcomplexebookappscart"] = null;  //after moving the values from session to eBook form then session should be cleared.
            //if (Session["dteBookcart"] == null)
            //{
            DataTable dtcomplexebookappscart = new DataTable();

            dtcomplexebookappscart.Columns.Add("cartid", typeof(System.String));
            dtcomplexebookappscart.Columns.Add("productname", typeof(System.String));
            dtcomplexebookappscart.Columns.Add("pcid", typeof(System.String));
            dtcomplexebookappscart.Columns.Add("qty", typeof(System.String));
            dtcomplexebookappscart.Columns.Add("unitcost", typeof(System.String));
            dtcomplexebookappscart.Columns.Add("totalcost", typeof(System.String));
            dtcomplexebookappscart.Columns.Add("parentid", typeof(System.String));


            addtocomplexebookappssession(dtcomplexebookappscart);
            //}
            //else
            //{
            //    DataTable dteBookcart=(DataTable)Session["dteBookcart"];
            //    addtosession(dteBookcart);
            //}
        }
        #endregion

        private void addtocomplexebookappssession(DataTable dtcomplexebookappscart)
        {
            #region complex eBook Apps Products

            #region Add complex ebook apps ipad product to cart
            if (chkebookappscomplexebookappsipad.Checked)
            {
                DataRow dr = dtcomplexebookappscart.NewRow();
                dr["cartid"] = "4.1";
                dr["pcid"] = "4";
                dr["qty"] = "1";
                dr["productname"] = "IPad";
                dr["unitcost"] = Convert.ToDecimal(lblebookappscomplexebookappsipadproductcost.Text);
                dr["totalcost"] = Convert.ToDecimal(lblebookappscomplexebookappsipadproductcost.Text);
                dtcomplexebookappscart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtcomplexebookappscart.NewRow();
                dr["cartid"] = "4.1";
                dr["pcid"] = "4";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtcomplexebookappscart.Rows.Add(dr);
            }

            #endregion

            #region Add Complex eBook Apps Iphone to cart
            if (chkebookappscomplexebookappsiphone.Checked)
            {
                DataRow dr = dtcomplexebookappscart.NewRow();
                dr["cartid"] = "4.2";
                dr["pcid"] = "4";
                dr["qty"] = "1";
                dr["productname"] = "IPhone";
                dr["unitcost"] = Convert.ToDecimal(lblebookappscomplexebookappsiphoneproductcost.Text);
                dr["totalcost"] = Convert.ToDecimal(lblebookappscomplexebookappsiphoneproductcost.Text);
                dtcomplexebookappscart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtcomplexebookappscart.NewRow();
                dr["cartid"] = "4.2";
                dr["pcid"] = "4";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtcomplexebookappscart.Rows.Add(dr);
            }

            #endregion

            #region Add Complex eBook Apps Android Tablets to cart

            if (chkebookappscomplexebookappsandroidtablets.Checked)
            {
                DataRow dr = dtcomplexebookappscart.NewRow();
                dr["cartid"] = "4.3";
                dr["pcid"] = "4";
                dr["qty"] = "1";
                dr["productname"] = "Android Tablets";
                dr["unitcost"] = Convert.ToDecimal(lblebookappscomplexebookappsandroidtabletsproductcost.Text);
                dr["totalcost"] = Convert.ToDecimal(lblebookappscomplexebookappsandroidtabletsproductcost.Text);
                dtcomplexebookappscart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtcomplexebookappscart.NewRow();
                dr["cartid"] = "4.3";
                dr["pcid"] = "4";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtcomplexebookappscart.Rows.Add(dr);
            }
            #endregion

            #region Add Complex eBook Apps Android phones to cart
            if (chkebookappscomplexebookappsandroidphones.Checked)
            {
                DataRow dr = dtcomplexebookappscart.NewRow();
                dr["cartid"] = "4.4";
                dr["pcid"] = "4";
                dr["qty"] = "1";
                dr["productname"] = "Android Phones";
                dr["unitcost"] = Convert.ToDecimal(lblebookappscomplexebookappsandroidphonesproductcost.Text);
                dr["totalcost"] = Convert.ToDecimal(lblebookappscomplexebookappsandroidphonesproductcost.Text);
                dtcomplexebookappscart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtcomplexebookappscart.NewRow();
                dr["cartid"] = "4.4";
                dr["pcid"] = "4";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtcomplexebookappscart.Rows.Add(dr);
            }
            #endregion

            #endregion

            #region Complex eBook Apps Customizations

            #region pages
            if (!string.IsNullOrEmpty(txtebookappscomplexebookappscustpages.Text))
            {
                DataRow dr = dtcomplexebookappscart.NewRow();
                dr["cartid"] = "4a";
                dr["pcid"] = "4";
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["productname"] = "Total Number of pages in the Book";
                dr["qty"] = txtebookappscomplexebookappscustpages.Text;
                dr["unitcost"] = lblebookappscomplexebookappsaddtionalpagesunitcost.Text;
                dr["totalcost"] = lblebookappscomplexebookappsadditionalpagestotalcost.Text;
                dtcomplexebookappscart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtcomplexebookappscart.NewRow();
                dr["cartid"] = "4a";
                dr["pcid"] = "4";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtcomplexebookappscart.Rows.Add(dr);
            }
            #endregion

            #region animation pages
            if (!string.IsNullOrEmpty(txtebookappscomplexebookappscustanimationpages.Text))
            {
                DataRow dr = dtcomplexebookappscart.NewRow();
                dr["cartid"] = "4b";
                dr["pcid"] = "4";
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["productname"] = "Total Number of Animation pages";
                dr["qty"] = txtebookappscomplexebookappscustanimationpages.Text;
                dr["unitcost"] = lblebookappscomplexebookappsadditionalanimationpagesunitcost.Text;
                dr["totalcost"] = lblebookappscomplexebookappsadditionalanimationpagestotalcost.Text;
                dtcomplexebookappscart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtcomplexebookappscart.NewRow();
                dr["cartid"] = "4b";
                dr["pcid"] = "4";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dtcomplexebookappscart.Rows.Add(dr);
            }
            #endregion

            #endregion

            Session["dtcomplexebookappscart"] = dtcomplexebookappscart;   //store the simple ebook apps form values from datatable to session

            Session["complexeBookappscarttotal"] = roundofdecimalpoints(Convert.ToDecimal(txtebookappscomplexebookappspackagecost.Text)); //calculate the simple ebook apps total and                                                                                                                                         store it in session
            int productcount = getcount(pnlebookappscomplexebookappsproducts);

            baseprice = getcomplexebookappsbasecostforproduct(productcount, Convert.ToInt16(lblebookappscomplexebookappsoffer1.Text), Convert.ToInt16(lblebookappscomplexebookappsoffer2.Text), Convert.ToInt16(lblebookappscomplexebookappsoffer3.Text)); 

            decimal complexebookappsdiscountonbasepkg = getproductprice(4) - baseprice;
            Session["complexebookappsdiscountonbasepkg"] = roundofdecimalpoints(complexebookappsdiscountonbasepkg);
            Session["complexebookappstotaldiscount"] = complexebookappsdiscountonbasepkg; //base page discount cost

            Session["complexebookappsproductprice"] = roundofdecimalpoints(getproductprice(4));//estimated product value

        }

        
        #endregion

        #region display the values from session to complex ebook apps form
        #region bindcartvalues to eBook form
        protected void bindcomplexebookappssessionvalues()  //dispalay the values session to complex ebook apps form
        {
            DataTable dtcomplexebookappscart = (DataTable)Session["dtcomplexebookappscart"];

            //displaying the product values from session to eBook form start
            chkebookappscomplexebookappsipad.Checked = getvaluesfromrow(dtcomplexebookappscart, "4.1")["qty"].ToString() == "1" ? true : false;
            chkebookappscomplexebookappsiphone.Checked = getvaluesfromrow(dtcomplexebookappscart, "4.2")["qty"].ToString() == "1" ? true : false;
            chkebookappscomplexebookappsandroidtablets.Checked = getvaluesfromrow(dtcomplexebookappscart, "4.3")["qty"].ToString() == "1" ? true : false;
            chkebookappscomplexebookappsandroidphones.Checked = getvaluesfromrow(dtcomplexebookappscart, "4.4")["qty"].ToString() == "1" ? true : false;
            //complete

            //displaying the cust values from session to eBook values begin
            txtebookappscomplexebookappscustpages.Text = getvaluesfromrow(dtcomplexebookappscart, "4a")["qty"].ToString();
            txtebookappscomplexebookappscustanimationpages.Text = getvaluesfromrow(dtcomplexebookappscart, "4b")["qty"].ToString();
            accebookapps.SelectedIndex = 1;
        }

        #endregion
        #endregion

        #region store the values from textbooks to session

        #region Textbooks form values store in session
        private void storeinCarttextbooks()
        {
            Session["dttextbookscart"] = null;  //after moving the values from session to eBook form then session should be cleared.
            //if (Session["dteBookcart"] == null)
            //{
            DataTable dttextbookscart = new DataTable();

            dttextbookscart.Columns.Add("cartid", typeof(System.String));
            dttextbookscart.Columns.Add("productname", typeof(System.String));
            dttextbookscart.Columns.Add("pcid", typeof(System.String));
            dttextbookscart.Columns.Add("qty", typeof(System.String));
            dttextbookscart.Columns.Add("unitcost", typeof(System.String));
            dttextbookscart.Columns.Add("totalcost", typeof(System.String));
            dttextbookscart.Columns.Add("parentid", typeof(System.String));

            addtotextbookssession(dttextbookscart);
            //}
            //else
            //{
            //    DataTable dteBookcart=(DataTable)Session["dteBookcart"];
            //    addtosession(dteBookcart);
            //}
        }
        #endregion

        private void addtotextbookssession(DataTable dttextbookscart)
        {
            #region textbooks Products

            #region Add textbooks ipad product to cart
            if (chkebookappsfortextbooksipad.Checked)
            {
                DataRow dr = dttextbookscart.NewRow();
                dr["cartid"] = "5.1";
                dr["pcid"] = "5";
                dr["qty"] = "1";
                dr["productname"] = "IPad";
                dr["unitcost"] = Convert.ToDecimal(lblebookappsfortextbooksipadproductcost.Text);
                dr["totalcost"] = Convert.ToDecimal(lblebookappsfortextbooksipadproductcost.Text);
                dttextbookscart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dttextbookscart.NewRow();
                dr["cartid"] = "5.1";
                dr["pcid"] = "5";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dttextbookscart.Rows.Add(dr);
            }

            #endregion

            #region Add textbook Iphone to cart
            if (chkebookappsfortextbooksiphone.Checked)
            {
                DataRow dr = dttextbookscart.NewRow();
                dr["cartid"] = "5.2";
                dr["pcid"] = "5";
                dr["qty"] = "1";
                dr["productname"] = "IPhone";
                dr["unitcost"] = Convert.ToDecimal(lblebookappsfortextbooksiphoneproductcost.Text);
                dr["totalcost"] = Convert.ToDecimal(lblebookappsfortextbooksiphoneproductcost.Text);
                dttextbookscart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dttextbookscart.NewRow();
                dr["cartid"] = "5.2";
                dr["pcid"] = "5";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dttextbookscart.Rows.Add(dr);
            }

            #endregion

            #region Add textbooks Android Tablets to cart

            if (chkebookappsfortextbooksandroidtablets.Checked)
            {
                DataRow dr = dttextbookscart.NewRow();
                dr["cartid"] = "5.3";
                dr["pcid"] = "5";
                dr["qty"] = "1";
                dr["productname"] = "Android Tablets";
                dr["unitcost"] = Convert.ToDecimal(lblebookappsfortextbooksandroidtabletsproductcost.Text);
                dr["totalcost"] = Convert.ToDecimal(lblebookappsfortextbooksandroidtabletsproductcost.Text);
                dttextbookscart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dttextbookscart.NewRow();
                dr["cartid"] = "5.3";
                dr["pcid"] = "5";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dttextbookscart.Rows.Add(dr);
            }
            #endregion

            #region Add textbooks Android phones to cart
            if (chkebookappsfortextbooksandroidphones.Checked)
            {
                DataRow dr = dttextbookscart.NewRow();
                dr["cartid"] = "5.4";
                dr["pcid"] = "5";
                dr["qty"] = "1";
                dr["productname"] = "Android Phones";
                dr["unitcost"] = Convert.ToDecimal(lblebookappsfortextbooksandroidphonesproductcost.Text);
                dr["totalcost"] = Convert.ToDecimal(lblebookappsfortextbooksandroidphonesproductcost.Text);
                dttextbookscart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dttextbookscart.NewRow();
                dr["cartid"] = "5.4";
                dr["pcid"] = "5";
                dr["qty"] = "";
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dttextbookscart.Rows.Add(dr);
            }
            #endregion

            #endregion

            #region textbooks Customizations

            #region pages
            if (!string.IsNullOrEmpty(txtebookappsfortextbookscustpages.Text))
            {
                DataRow dr = dttextbookscart.NewRow();
                dr["cartid"] = "5a";
                dr["pcid"] = "5";
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["productname"] = "Total Number of pages in the Book";
                dr["qty"] = txtebookappsfortextbookscustpages.Text;
                dr["unitcost"] = lblebookappsfortextbooksadditionalpagesunitcost.Text;
                dr["totalcost"] = lblebookappsfortextbooksadditionalpagestotalcost.Text;
                dttextbookscart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dttextbookscart.NewRow();
                dr["cartid"] = "5a";
                dr["pcid"] = "5";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dttextbookscart.Rows.Add(dr);
            }
            #endregion

            #region Interactive Self 
           
            if (!string.IsNullOrEmpty(txtebookappsfortextbookscustinteractiveandselfassessmentpages.Text))
            {
                DataRow dr = dttextbookscart.NewRow();
                dr["cartid"] = "5b";
                dr["pcid"] = "5";
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["productname"] = "Interactive Self Assessments,Q & A";
                dr["qty"] = txtebookappsfortextbookscustinteractiveandselfassessmentpages.Text;
                dr["unitcost"] = lblebookappsfortextbooksadditionalinteractiveselfassessmentunitcost.Text;
                dr["totalcost"] = lblebookappsfortextbooksadditionalinteractiveselfassessmenttotalcost.Text;
                dttextbookscart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dttextbookscart.NewRow();
                dr["cartid"] = "5b";
                dr["pcid"] = "5";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dttextbookscart.Rows.Add(dr);
            }
            #endregion

            #region Audio and video Integration
            if (!string.IsNullOrEmpty(txtebookappsfortextbookscustavelements.Text))
            {
                DataRow dr = dttextbookscart.NewRow();
                dr["cartid"] = "5c";
                dr["pcid"] = "5";
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["productname"] = "Video & Audio Integration";
                dr["qty"] = txtebookappsfortextbookscustavelements.Text;
                dr["unitcost"] = lblebookappstextbooksadditionalavelementsunitcost.Text;
                dr["totalcost"] = lblebookappstextbooksadditionalavelementstotalcost.Text;
                dttextbookscart.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dttextbookscart.NewRow();
                dr["cartid"] = "5c";
                dr["pcid"] = "5";
                dr["qty"] = "";
                dr["parentid"] = (char)(bel.bel.parentid.Customisations);
                dr["unitcost"] = "";
                dr["totalcost"] = "";
                dttextbookscart.Rows.Add(dr);
            }
            #endregion

            #endregion

            Session["dttextbookscart"] = dttextbookscart;   //store the simple ebook apps form values from datatable to session

            Session["textbookscarttotal"] = roundofdecimalpoints(Convert.ToDecimal(txtebookappsfortextbookspackagecost.Text)); //calculate the simple ebook apps total and                                                                                                                                         store it in session
            int productcount = getcount(pnlebookappsfortextbooksproducts);

            baseprice = getebookappsfortextbooksbasecostforproduct(productcount, Convert.ToInt16(lblebookappsfortextbooksoffer1.Text), Convert.ToInt16(lblebookappsfortextbooksoffer2.Text), Convert.ToInt16(lblebookappsfortextbooksoffer3.Text)); 

            decimal textbooksdiscountonbasepkg = getproductprice(5) - baseprice;
            Session["textbooksdiscountonbasepkg"] = roundofdecimalpoints(textbooksdiscountonbasepkg);
            Session["textbookstotaldiscount"] = textbooksdiscountonbasepkg; //base page discount cost

            Session["textbooksproductprice"] = roundofdecimalpoints(getproductprice(5));//estimated product value

        }

        #endregion

        #region display the values from session to ebook apps for textbooks
        protected void bindtextbookssessionvalues()  //dispalay the values session to ebook apps for textbooks form
        {
            DataTable dttextbookscart = (DataTable)Session["dttextbookscart"];  //store the values from session to datatable 

            //displaying the product values from session to eBook form start
            chkebookappsfortextbooksipad.Checked = getvaluesfromrow(dttextbookscart, "5.1")["qty"].ToString() == "1" ? true : false;
            chkebookappsfortextbooksiphone.Checked = getvaluesfromrow(dttextbookscart, "5.2")["qty"].ToString() == "1" ? true : false;
            chkebookappsfortextbooksandroidtablets.Checked = getvaluesfromrow(dttextbookscart, "5.3")["qty"].ToString() == "1" ? true : false;
            chkebookappsfortextbooksandroidphones.Checked = getvaluesfromrow(dttextbookscart, "5.4")["qty"].ToString() == "1" ? true : false;
            //completed

            //displaying the cust values from session to eBook values begin
            txtebookappsfortextbookscustpages.Text = getvaluesfromrow(dttextbookscart, "5a")["qty"].ToString();
            txtebookappsfortextbookscustinteractiveandselfassessmentpages.Text = getvaluesfromrow(dttextbookscart, "5b")["qty"].ToString();
            txtebookappsfortextbookscustavelements.Text = getvaluesfromrow(dttextbookscart, "5c")["qty"].ToString();
            //completed
            accebookapps.SelectedIndex = 2;
        }
        #endregion



    }
}