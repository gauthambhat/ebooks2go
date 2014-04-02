using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eBooks2goV5.bel
{ 
    public class bel
    {
        #region procat Properties

        public int ? pcid { get; set; } 
        public string pcname { get; set; }
        public int offer1 { get; set; }
        public int offer1dis { get; set; }
        public int offer2 { get; set; }
        public int offer2dis { get; set; }
        public int pcdpages { get; set; }
        public int pcdimages { get; set; }
        public int pcdfootnotes{get;set;}
        public int pcdhplinks { get; set; }
        public decimal perpagecost { get; set; }
        public decimal perimagecost { get; set; }
        public decimal footnotesandendnotescost { get; set; }
        public decimal weblinkscost { get; set; }
        public int  twotofourelementscost { get; set; }
        public int  fourpluselementscost { get; set; }
        public decimal eachavcost { get; set; }
        public decimal readaloudwordcost { get; set; }
        public decimal scoverdesigncost { get; set; }
        public decimal hcoverdesigncost { get; set; }
        public decimal eisbncost { get; set; }
        public decimal socialmediacost { get; set; }
        public decimal pressreleasecost { get; set; }
        public decimal emailcampaincost { get; set; }
        public decimal websiteblogpromotioncost { get; set; }
        public int marketingdiscount { get; set; }
        public bool pcstatus { get; set; }
        public string pResult {get; set;}

        public decimal mktamt { get; set;} //here this property is not available in any table.

        #endregion

        #region products properties

        public int? prodid { get; set; }   //here ? is the Nullable Operator.by using this Nullable Operator we are passing the null value.Because Whenever get the product                                               category id it should display all the products.i.e here we don't pass the product id,here we are passing the id as a null.
        public string prodname { get; set; }
        public decimal prodcost { get; set; }

        #endregion

        #region enumaration for prodcat  
        public enum prodcategory    //enumaration for if you click tab1 it should display tab1 content and remaining tabs are same.
        {
            eBook = 1,  //when we click eBook tab container, it should display eBook content on output window
            Enhaned_eBook = 2,  //when we click Enhanced eBook, it should display Enhanced eBook Content on output window
            simpleebookapps = 3,   //When we click simple eBook Apps Accordian pane tab, it should display eBook Apps Content on the output window
            complexebookapps = 4,  //When we click complex ebook apps Accordian Pane tab it should display the complex ebook app content on the output window
            eBookappsfortextbooks = 5   //when we click ebook apps for textbooks Accordian pane tab it should display the ebooks apps for textbooks content on the output window.
        };
        #endregion

        #region enumeration for parentid
        public enum parentid
        {
            Customisations = '1',
            AdditionalElements = '2',
            CoverDesign='3'
        };
        #endregion

    }

    #region cartmaster table 
        public class cartmasterbel
        {
        public Int64? cmid { get; set; }    //here ? is the nullable operator.
        public Int64? customerid { get; set; }
        public int? prodcatid { get; set; }
        public int? offerselected { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public bool? bworcolor { get; set; }
        public int? booklanguage { get; set; }
        public DateTime? prjcompdate { get; set; }
        public string manscrpitdesc { get; set; }
        public int? cartrefcode { get; set; }
        public DateTime? cartmastercreateddate { get; set; }
        public int? totalpages { get; set; }
        public int? totalimages { get; set; }
        public int? totalfenotes { get; set; }
        public int? totalweblinks { get; set; }
        public bool? nestedtoc { get; set; }
        public bool? coloredfonts { get; set; }
        public bool? multipleselection { get; set; }
        public bool? doublecolumn { get; set; }
        public bool? textboxboundry { get; set; }
        public bool? dropcaps { get; set; }
        public bool? lists { get; set; }
        public bool? callouts { get; set; }
        public bool? centeredtext { get; set; }
        public decimal? elementscost { get; set; }
        public int? totalav { get; set; }
        public bool? coverdesign { get; set; }
        public bool? distribution { get; set; }
        public bool? socialmedia { get; set; }
        public bool? pressrelease { get; set; }
        public bool? emailcampain { get; set; }
        public bool? websiteandblog { get; set; }
        public int? readallowedtext { get; set; }
        public int? totalanimationpages { get; set; }
        public int? interactiveselfassessmentqa { get; set; }
        public string projfilename { get; set; }
        public decimal? invoiceamt { get; set; }
        public int? recstatus { get; set; }
        public string pResult { get; set; }
    }
    #endregion

    #region ebfileupload table
        public class ebfileuploadbel
        {
            public Int64? cmid { get; set; }
            public Int64? fileupid { get; set; }
            public string upfilename { get; set; }
            public DateTime? fileuploaddate { get; set; }
            public bool? fstatus { get; set; }
            public string pResult { get; set; }
        }
    #endregion

    #region cartproducts table
        public class cartproductsbel
        {
            public Int64? cmid { get; set; }
            public Int64? cdetailid { get; set; }
            public int? prodid { get; set; }
            public int? eisbn { get; set; }
            public string pResult { get; set; }
            public int? recstatus { get; set; }
        }
    #endregion

    #region customer table
        public class insertnewcustomerbel
        {
            public Int64? customerid { get; set; }
            public string emailid { get; set; }
            public string password { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string companyname { get; set; }
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string city { get; set; }
            public int? countryid { get; set; }
            public int? stateid { get; set; }
            public string zipCode { get; set; }
            public string phone { get; set; }
            public string fax { get; set; }
            public int? customertype { get; set; }
            public bool cstatus { get; set; }
            public string pResult { get; set; }

        }
#endregion

#region countrytable
        public class Countries
        {
            public int countryid{get;set;}
            public string countyname { get; set; }
            public int stateid { get; set; }
            public string pResult { get; set; }
        }
#endregion

#region statetable
        public class States
        {
            public int StateId { get; set; }
            public string StateName { get; set; }
            public string pResult { get; set; }
            public int countryid { get; set; }
        }
#endregion

}