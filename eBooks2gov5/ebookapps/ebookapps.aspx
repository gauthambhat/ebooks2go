

<%--currently we are not using this page, we are using instead of ebookappps we are using newebookapps page only--%>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ebookapps.aspx.cs" Inherits="eBooks2goV5.ebookapps.ebookapps" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
   <meta charset="utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=7, IE=8, IE=9, chrome=1" />
<title>eBook Pricing | eBook Packages</title>
<script type="text/javascript" src="js/jquery.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/jquery-ui.js" type="text/javascript"></script>
<link href="css/styles.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    function loadnext(divout, divin) {
        $("." + divout).hide();
        $("." + divin).fadeIn("fast");
    }
</script>

<script type="text/javascript">
    function showMe(it, hide1, hide2, hide3, box) {
        document.getElementById(it).style.display = "block";
        document.getElementById(hide1).style.display = "none";
        document.getElementById(hide2).style.display = "none";
    }
    function showMe2(it) {
        var vis = document.getElementById(it).style.display
        if (vis == "block") { document.getElementById(it).style.display = "none"; }
        else { document.getElementById(it).style.display = "block"; }
    }

    $(document).ready(function () {
        $('#tabEbook').hide();
    });

    $(document).ready(function () {
        $('#tabEbook1').hide();
    });
</script>
<script type="text/javascript">
    function confirmPay() {
        $('#StandardeBookFormat').hide(1000);
        $('#tabEbook').show(1000, function () {
            $("html, body").animate({ scrollTop: 0 }, "slow");

        });
    }
    function editPay() {
        $('#StandardeBookFormat').show(1000);
        $('#tabEbook').hide(1000, function () {
            $("html, body").animate({ scrollTop: 0 }, "slow");

        });
    }


    function con() {
        $('#tabEbook').hide(1000);
        $('#tabEbook1').show(1000, function () {
            $("html, body").animate({ scrollTop: 0 }, "slow");

        });
    }
    function editPay1() {
        $('#tabEbook').show(1000);
        $('#tabEbook1').hide(1000, function () {
            $("html, body").animate({ scrollTop: 0 }, "slow");

        });
    }

    function complex() {
        $('#ComplexeBookApps').hide(1000);
        $('#complexeBook').show(1000, function () {
            $("html, body").animate({ scrollTop: 0 }, "slow");

        });
    }
    function complexeditPay() {
        $('#ComplexeBookApps').show(1000);
        $('#complexeBook').hide(1000, function () {
            $("html, body").animate({ scrollTop: 0 }, "slow");

        });
    }

    function complexecart() {
        $('#complexeBook').hide(1000);
        $('#complexeBookcart').show(1000, function () {
            $("html, body").animate({ scrollTop: 0 }, "slow");

        });
    }
    function complexeBookedit() {
        $('#complexeBook').show(1000);
        $('#complexeBookcart').hide(1000, function () {
            $("html, body").animate({ scrollTop: 0 }, "slow");

        });
    }
    function eBookAppsTextbooks() {
        $('#eBookAppsforTextbooks').hide(1000);
        $('#eBookTextbooks').show(1000, function () {
            $("html, body").animate({ scrollTop: 0 }, "slow");

        });
    }
    function eBookTextbooksedit() {
        $('#eBookAppsforTextbooks').show(1000);
        $('#eBookTextbooks').hide(1000, function () {
            $("html, body").animate({ scrollTop: 0 }, "slow");

        });
    }
    function ebookscarttextbook() {
        $('#eBookTextbooks').hide(1000);
        $('#eBookAppsTextbookscart').show(1000, function () {
            $("html, body").animate({ scrollTop: 0 }, "slow");

        });
    }
    function ebookscarttextbookedit() {
        $('#eBookTextbooks').show(1000);
        $('#eBookAppsTextbookscart').hide(1000, function () {
            $("html, body").animate({ scrollTop: 0 }, "slow");

        });
    }
</script>
   
<link type='text/css' href='css/pricingpage.css' rel='stylesheet' media='screen' />

    <link rel="stylesheet" href="css/accordion.css" type="text/css" media="all" />

      <script type="text/javascript" >
          var gCurrentIndex = 0; // global variable to keep the current index;
          var ACCORDION_PANEL_COUNT = 3; //global variable for panel count. Here 3 is for zero based accordion index

          $(document).ready(function () {
              showhidediv();
              var activeIndex = parseInt($('#hidAccordionIndex').val());
              wizard = $("#accordion").accordion({
                  event: 'click',
                  active: activeIndex,
                  autoHeight: false,
                  icons: { 'header': 'ui-icon-plus', 'headerSelected': 'ui-icon-minus' },
                  change: function (event, ui) { gCurrentIndex = $(this).find("h4").index(ui.newHeader[0]); document.getElementById("hidAccordionIndex").value = gCurrentIndex; showhidediv(); }
              });


          });
  </script>
  <script>
      function showhidediv() {
          if (document.getElementById("hidAccordionIndex").value == 0) {
              document.getElementById('divsimpleebook').style.display = 'block';
              document.getElementById('divcomplexebook').style.display = 'none';
              document.getElementById('divtextbooks').style.display = 'none';

          }
          if (document.getElementById("hidAccordionIndex").value == 1) {
              document.getElementById('divcomplexebook').style.display = 'block';
              document.getElementById('divsimpleebook').style.display = 'none';
              document.getElementById('divtextbooks').style.display = 'none';
          }
          if (document.getElementById("hidAccordionIndex").value == 2) {
              document.getElementById('divtextbooks').style.display = 'block';
              document.getElementById('divsimpleebook').style.display = 'none';
              document.getElementById('divcomplexebook').style.display = 'none';
          }

      }
  </script>
  
<style>
@font-face {
font-family: "Droid Sans";
src: url(DroidSans.ttf) format("truetype");
}
@font-face {
font-family: "Trebuchet MS";
src: url(trebuc.ttf) format("truetype");
}
@font-face {
font-family: "Roboto";
src: url(Roboto-bold.ttf) format("truetype");
}
@font-face {
font-family: "Oswald";
src: url(Oswald-Regular.otf) format("truetype");
}
</style>
<style type='text/css'>
.blueclock {
	float:left;
	margin-left:-30px;
}
.pendulum-parent {
	display: none;
	height: 40px;
	width: 228px;
}
.pendulum-child {
	left: 150px;
	position: absolute;
	top: 0;
}
.ebooks_discount {
	width:230px;
	height:208px;
	float:left;
	background-image:url(images/discount_img.png);
	background-repeat:no-repeat;
}
.ebooks_discount_titles {
	width:200px;
	float:left;
	margin-left:15px;
	margin-top:32px;
}
#apDiv2 {
	position:absolute;
	left:5px;
	top:40px;
	width:300px;
	height:100px;
	z-index:0;
}
#tabEbook, #tabEbook1, #complexeBookcart, #eBookAppsTextbookscart {
	font-family:Verdana, Geneva, sans-serif;
	font-size:0.8em;
	color:#5a5a5a;
}
#tabEbook td, th, #tabEbook1 td, th, #complexeBook td, th, #complexeBookcart td, th, #eBookTextbooks td, th, #eBookAppsTextbookscart td, th {
	padding:0.5em;
}
#tabEbook th, #tabEbook1 th, #complexeBookcart th, #eBookAppsTextbookscart th {
	background-color:#aaaaaa;
	color:#fff;
	font-size:12px;
}
.tabHeads {
	color:##68b026;
	font-size:20px;
	line-height:40px;
	margin-left:2px;
}
.subHeads {
	text-align:right;
	color:#999;
}
.cartHold {
	display:inline-block;
	float:left;
}
.cartHold img {
	display:inline-block;
	width:50px;
	height:auto;
}
.productHold {
	display: inline-block;
	margin-left: 10px;
	color: #ff0000;
}
#tabEbook > table, #tabEbook1 > table, #complexeBookcart > table, #eBookAppsTextbookscart > table {
	border:0;
}
.eb2g_space {
	width:170px;
	float:left;
	margin-left:100px;
}
</style>
<link href="css/jquery.mCustomScrollbar.css" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="css/demo.css" />
<link rel="stylesheet" type="text/css" href="css/style.css" />
<script type="text/javascript" src="js/modernizr.custom.53451.js"></script>
<style type="text/css">
.divstyle {
	display: none;
	height:auto;
	width:auto;
}
</style>
<link type='text/css' href='css/pricingpage.css' rel='stylesheet' media='screen' />
<style>
body {
	font-family:Verdana, Geneva, sans-serif;
}
@font-face {
font-family: "Droid Sans";
src: url(DroidSans.ttf) format("truetype");
}
@font-face {
font-family: "Trebuchet MS";
src: url(trebuc.ttf) format("truetype");
}
@font-face {
font-family: "Roboto";
src: url(Roboto-bold.ttf) format("truetype");
}
@font-face {
font-family: "Oswald";
src: url(Oswald-Regular.otf) format("truetype");
}
</style>
<style type='text/css'>
.blueclock {
	float:left;
	margin-left:-30px;
}
.pendulum-parent {
	display: none;
	height: 40px;
	width: 228px;
}
.pendulum-child {
	left: 150px;
	position: absolute;
	top: 0;
}
.ebooks_discount {
	width: 233px;
	height: 235px;
	float: none;
	background-image: url(images/best.png);
	background-repeat: no-repeat;
	margin-left:193px;
	color: #FFF;/* [disabled]padding: 6px; *//* [disabled]padding-top: 20px; */
}
#apDiv1 {
	position: absolute;
	left: 236px;
	top: 90px;
	width: 64px;
	height: 55px;
	z-index: 1;
}
#apDiv2 {
	position:absolute;
	left:0px;
	top:40px;
	width:300px;
	height:100px;
	z-index:0;
}
.ebooks_discount {
	color:#000;
	font-size:1.2em;
	padding:10px;
	padding-top:5px;
}
.ebooks_discount ul {
	margin-left: -10px;
	font-size: 14px;
	font-weight: normal;
	margin-right: 10px;
	list-style-image: url(images/star.png);
	list-style-position: inside;
}
.ebooks_discount ul li {
	font-family: 'Gloria Hallelujah', cursive;
	color:#000;
	text-align:left;
	width:200px;
	font-size:13px;
	margin-left:40px;
	margin-bottom:10px;
}
.ebookapps {
	width:1000px;
	margin:auto;
}
.eb2g_space {
	width:170px;
	float:left;
	margin-left:100px;
}
.eb2g_ebooksapps{ height:150px;}
</style>
</head>

<body>
    <form id="form1" runat="server">
        
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <div class="ebookapps">
  <div id="apDiv2"> <span class="ebookappstyps">
   <input id="hidAccordionIndex" type="hidden" value='0' runat="server" />
        <div id="accordion" style="padding:5px;">
            <h4><a href="#">Simple eBook Apps</a></h4>
            <div id="sampletext">
             <div class="eb2g_StandardFormat_contents">
                                        <table width="250" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <li>Number of Pages - upto <asp:Label ID="lblebookappssimpleebookappsdefaultpages" runat="server"></asp:Label></li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>App Icon Creation</li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>Splash Page creation</li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>Read Aloud - Voice Integration</li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>Share with Social Media / Twitter</li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>Help with upload to App Store</li>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
            
            </div>
            <h4><a href="#">Complex eBook Apps</a></h4>
            <div> 
                <div class="eb2g_StandardFormat_contents">
                                        <table width="250" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <li>Number of Pages - upto <asp:Label ID="lblebookappscomplexebookappsdefaultpages" runat="server"></asp:Label></li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>App Icon Creation</li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>Splash Page creation</li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>Animation for upto <asp:Label ID="lblebookappscomplexebookappsdefaultanimationpages" runat="server"></asp:Label> pages</li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>Read Aloud - Voice Integration</li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>Share with Social Media / Twitter</li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>Help with upload to App Store</li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>Animation - $<asp:Label ID="lblebookappscomplexebookappsanimationcost" runat="server"></asp:Label> for each additonal page, either device?</li>
                                                </td>
                                            </tr>
                                        </table>
                                    </div></div>
            <h4><a href="#">eBook Apps for Textbooks</a></h4>
            <div>
            <div class="eb2g_StandardFormat_contents">
                                        <table width="250" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <li>Number of Pages - upto <asp:Label ID="lblebookappsfortextbooksdefaultpages" runat="server"></asp:Label></li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>App Icon Creation</li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>Splash Page creation</li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>TOC/Chapter Linking</li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>Page Conversion to HTML/XML</li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>Interactive Self Assessments,Q & A </li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>Share with Social Media / Twitter</li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>Video & Audio Integration</li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>Upload to App Store</li>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
            </div>
          
        </div>
  
<!--    <div id="accordion">
      <div class="selectiteams">
        <h4 name="radio1" checked="checked" onclick="showMe('div1', 'div2', 'div3', this)" >
          <input type="radio" name="radio1" checked="checked" onclick="showMe('div1', 'div2', 'div3', this)" />
          Simple eBook Apps</h4>
      </div>
      <div>
        <div class="eb2g_StandardFormat_contents">
          <table width="250" cellspacing="0">
            <tr>
              <td><li>Number of Pages - upto 30</li></td>
            </tr>
            <tr>
              <td><li>App Icon Creation</li></td>
            </tr>
            <tr>
              <td><li>Splash Page creation</li></td>
            </tr>
            <tr>
              <td><li>Read Aloud - Voice Integration</li></td>
            </tr>
            <tr>
              <td><li>Share with Social Media / Twitter</li></td>
            </tr>
            <tr>
              <td><li>Help with upload to App Store</li></td>
            </tr>
          </table>
        </div>
      </div>
      <div class="selectiteams">
        <h4 name="radio1" onclick="showMe('div2', 'div3','div1', this)" >
          <input type="radio" name="radio1" onclick="showMe('div2', 'div3','div1', this)" />
          Complex eBook Apps</h4>
      </div>
      <div>
        <div class="eb2g_StandardFormat_contents">
          <table width="250" cellspacing="0">
            <tr>
              <td><li>Number of Pages - upto 30</li></td>
            </tr>
            <tr>
              <td><li>App Icon Creation</li></td>
            </tr>
            <tr>
              <td><li>Splash Page creation</li></td>
            </tr>
            <tr>
              <td><li>Animation for upto 10 pages</li></td>
            </tr>
            <tr>
              <td><li>Read Aloud - Voice Integration</li></td>
            </tr>
            <tr>
              <td><li>Share with Social Media / Twitter</li></td>
            </tr>
            <tr>
              <td><li>Help with upload to App Store</li></td>
            </tr>
            <tr>
              <td><li>Animation - $100 for each additonal page, either device?</li></td>
            </tr>
          </table>
        </div>
      </div>
      <div class="selectiteams">
        <h4 name="radio1" onclick="showMe('div3','div1', 'div2', this)" >
          <input type="radio" name="radio1" onclick="showMe('div3','div1', 'div2', this)" />
          eBook Apps for Textbooks</h4>
      </div>
      <div>
        <div class="eb2g_StandardFormat_contents">
          <table width="250" cellspacing="0">
            <tr>
              <td><li>Number of Pages - upto 200</li></td>
            </tr>
            <tr>
              <td><li>App Icon Creation</li></td>
            </tr>
            <tr>
              <td><li>Splash Page creation</li></td>
            </tr>
            <tr>
              <td><li>TOC/Chapter Linking</li></td>
            </tr>
            <tr>
              <td><li>Page Conversion to HTML/XML</li></td>
            </tr>
            <tr>
              <td><li>Interactive Self Assessments,Q & A </li></td>
            </tr>
            <tr>
              <td><li>Share with Social Media / Twitter</li></td>
            </tr>
            <tr>
              <td><li>Video & Audio Integration</li></td>
            </tr>
            <tr>
              <td><li>Upload to App Store</li></td>
            </tr>
          </table>
        </div>
      </div>
    </div>-->
    </span></div>
       <div class="divstyle" id="divsimpleebook">
   <asp:Panel ID="pnlSimple" runat="server">
            <div id="StandardeBookFormat">
                <div class="eb2g_StandardFormateBook">
                    <div class="eb2g_headerleft">
                        <div class="eb2g_StandardFormat_title">eBook Apps:</div>
                        <div style="height: 135px; width: 200px;"></div>
                        <div class="eb2g_StandardFormat_titleimg">
                            <img src="images/EnhancedeBookformating.png" alt="" />
                        </div>
                        <div class="eb2g_discountprice">
                            <div class="blueclock">
                                <div style="transform: rotate(0deg) scale(1, 1); display: block;" class="pendulum-parent">
                                    <div class="ebooks_discount" align="center">
                                        <b>Offers</b>
                                        <ul>
                                            <li>Select any '
                                                <asp:Label ID="lblebookappssimplebookappsoffer1" runat="server"></asp:Label>
                                                ' products get
                                                <asp:Label ID="lblebookappssimplebookappsoffer1discount" runat="server"></asp:Label>
                                                Discount on base price' </li>
                                            <li>Select any '
                                                <asp:Label ID="lblebookappssimplebookappsoffer2" runat="server"></asp:Label>
                                                ' products get
                                                <asp:Label ID="lblebookappssimplebookappsoffer2discount" runat="server"></asp:Label>
                                                Discount on base price'</li>
                                            <li>Select any '
                                                <asp:Label ID="lblebookappssimplebookappsoffer3" runat="server"></asp:Label>' products get
                                                <asp:Label ID="lblebookappssimplebookappsoffer3discount" runat="server"></asp:Label>
                                                Discount on base price'</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="eb2g_headerright">
                        <div class="box-heading">Choose product(s) </div>
                        <div class="apps-box-content">
                            <asp:Panel ID="pnlebookappssimpleebookappsproducts" runat="server">
                            <div class="eb2g_products">
                                <div class="eb2g_products_details">Product</div>
                                <div class="eb2g_products_details_right">Cost</div>
                                <div class="eb2g_ebooksappsdetails">
                                    <div class="eb2g_products_details_eup">
                                        <table class="simpleproducts">
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="epub" type="checkbox" service="1" title="ePUB Package" value="449" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappssimpleebookappsipad" runat="server" class="chksimpleproducts" />
                                                    IPad </td>
                                                <td>$<asp:Label ID="lblebookappssimpleebookappsipadproductcost" class="simpleprice" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; Works only with IPad & IPad mini </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="eb2g_products_details_mobi">
                                        <table  class="simpleproducts">
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="Mobi" type="checkbox" service="2" title="Mobi Package" value="449" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappssimpleebookappsiphone" runat="server" class="chksimpleproducts" />
                                                    IPhone</td>
                                                <td>$<asp:Label ID="lblebookappssimpleebookappsiphoneproductcost" class="simpleprice" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; Works only with IPhone 3,4,5 </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="eb2g_products_details_epdf">
                                        <table  class="simpleproducts">
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="ePDF" type="checkbox" service="3" title="ePDF Package" value="449" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappssimpleebookappsandroidtablets" runat="server" class="chksimpleproducts" />
                                                    Android Tablets</td>
                                                <td>$<asp:Label ID="lblebookappssimpleebookappsandroidtabletsproductcost" class="simpleprice" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; Works only with 10 inch and 7 inch</td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="eb2g_products_details_andriodphone">
                                        <table  class="simpleproducts">
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="Checkbox1" type="checkbox" service="4" title="ePDF Package" value="449" name="PackageName" style="margin-left: 15px;" />--%>
                                                     <asp:CheckBox ID="chkebookappssimpleebookappsandroidphones" runat="server" class="chksimpleproducts" />
                                                    Android Phones</td>
                                                <td>$<asp:Label ID="lblebookappssimpleebookappsandroidphonesproductcost" class="simpleprice" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; All Android smartphones 3.2 versions   devices</td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            </asp:Panel>
                            <div class="eb2g_products_cost">
                                <div class="eb2g_PackageCost">
                                    Package Cost
                                        <br />
                                    <%--<input type="text" id="totalamount" />--%>
                                    <asp:TextBox ID="txtebookappssimpleebookappspackagecost" class="simpletotalcost" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="eb2g_addtocart">
                                    <a href="#">
                                        <img src="images/addtocart.jpg" alt="" />
                                    </a>
                                </div>
                                <div class="eb2g_viewcart">
                                    <a href="#">
                                        <img src="images/viewcart.jpg" alt="" />
                                    </a>
                                </div>
                                <div class="eb2g_checkout"><a href="#"></a></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div>&nbsp;</div>
                <div style="width: 980px; float: left; height: 20px;">&nbsp;</div>
                <hr>
                <span class="Customizeyourproduct">
                    <h3>Customize your product</h3>
                </span>
                <div class="Customize_pricing">
                    <table width="1000" cellspacing="0" class="simple_customize_products">
                        <tr>
                            <td width="490">
                                <h4>Total Number of pages in the Book</h4>
                                <span class="Customize_totalnumber">Upto
                                    <asp:Label ID="lblebookappssimpleebookappscustpages" class="Custdefault"  runat="server"></asp:Label>
                                    pages are included in the base price.<br />
                                    &nbsp;&nbsp;&nbsp;Each Additonal pages be billed at. $<asp:Label ID="lblebookappssimpleebookappscustpagescost" class="Custcost" runat="server"></asp:Label>
                                </span>
                            </td>
                            <td width="100" align="center">
                               <%-- <input type="text" />--%>
                                <asp:TextBox ID="txtebookappssimpleebookappscustpages" runat="server" class="Custqty"></asp:TextBox>
                                  <asp:FilteredTextBoxExtender ID="fteebookappssimpleebookappscustpages" runat="server" FilterType="Numbers"
    TargetControlID="txtebookappssimpleebookappscustpages" />
                            </td> 
                            <td><asp:Label ID="lblebookappssimpleebookappsadditionalpages" class="Custadditional" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappssimpleebookappsadditonalpagesunitcost" class="Custadditionalunitcost" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappssimpleebookappsadditionaltotalcost" class="Custadditionaltotalcost" runat="server"></asp:Label></td>
                        </tr>

                    </table>
                    <h3>Samples Application</h3>
                    <div class="container">
                        <section id="dg-container" class="dg-container">
                            <div class="dg-wrapper">

                                <a href="#">
                                    <img src="images/SimpleeBookApps.png" alt="SimpleeBookApps">
                                    <div>Ellyn Satter </div>
                                </a>

                                &nbsp;

                                <a href="#">
                                    <img src="images/SimpleeBookApps1.png" alt="SimpleeBookApps">
                                    <div>Ellyn Satter </div>
                                </a>

                                &nbsp;

                                <a href="#">
                                    <img src="images/SimpleeBookApps2.png" alt="SimpleeBookApps">
                                    <div>Ellyn Satter </div>
                                </a>

                            &nbsp;&nbsp;<a href="#"><img alt="SimpleeBookApps" src="images/SimpleeBookApps4.png">
                                <div>
                                    Ellyn Satter
                                </div>
                                </img></a> &nbsp;<a href="#"><img alt="SimpleeBookApps" src="images/SimpleeBookApps5.png">
                                <div>
                                    Ellyn Satter
                                </div>
                                </img></a> &nbsp;</div>
                            <!--nav>	
					<span class="dg-prev">&lt;</span>
					<span class="dg-next">&gt;</span>
				</nav-->
                        </section>
                    </div>
                </div>
                <script>
                    $(document).ready(function () {
                        $("#proceed").click(function () {
                            $("#apDiv2").css("display", "none");
                        });
                    });
                </script>
                <asp:ImageButton ID="imgbtnsimpleproceed" OnClick="imgbtnsimpleproceed_Click" ImageUrl="images/proceed.jpg" Width="117" Height="30" align="right" Style="margin-right: 20px; margin-top: 10px;" runat="server" />
            </div>
        </asp:Panel>
  </div>
       <div class="divstyle" id="divcomplexebook">
  <asp:Panel ID="pnlComplex" runat="server">
            <div id="ComplexeBookApps">
                <div class="eb2g_StandardFormateBook">
                    <div class="eb2g_headerleft">
                        <div class="eb2g_StandardFormat_title">eBook Apps:</div>
                        <div style="height: 135px; width: 200px;"></div>
                        <div class="eb2g_StandardFormat_titleimg">
                            <img src="images/EnhancedeBookformating.png" alt="" />
                        </div>
                        <div class="eb2g_discountprice">
                            <div class="blueclock">
                                <div style="transform: rotate(0deg) scale(1, 1); display: block;" class="pendulum-parent">
                                    <div class="ebooks_discount" align="center">
                                        <b>Offers</b>
                                        <ul>
                                            <li>Select any '
                                                <asp:Label ID="lblebookappscomplexebookappsoffer1" class="complexoffer1" runat="server"></asp:Label>
                                                ' products get
                                                <asp:Label ID="lblebookappscomplexebookappsoffer1discount" class="complexoffer1discount" runat="server"></asp:Label> Discount on base price' </li>
                                            <li>Select any '
                                                <asp:Label ID="lblebookappscomplexebookappsoffer2" class="complexoffer2" runat="server"></asp:Label>
                                                ' products get
                                                <asp:Label ID="lblebookappscomplexebookappsoffer2discount"  class="complexoffer2discount" runat="server"></asp:Label> Discount on base price</li>
                                            <li>Select any '
                                                <asp:Label ID="lblebookappscomplexebookappsoffer3" class="complexoffer3" runat="server"></asp:Label>
                                                ' products get
                                                <asp:Label ID="lblebookappscomplexebookappsoffer3discount"  class="complexoffer3discount" runat="server"></asp:Label> Discount on base price</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="eb2g_headerright">
                        <div class="box-heading">Choose product(s) </div>
                        <div class="apps-box-content">
                            <asp:Panel ID="pnlebookappscomplexebookappsproducts" runat="server">
                            <div class="eb2g_products">
                                <div class="eb2g_products_details">Product</div>
                                <div class="eb2g_products_details_right">Cost</div>
                                <div class="eb2g_ebooksappsdetails">
                                    <div class="eb2g_products_details_eup">
                                        <table class="complexproducts">
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="Checkbox2" type="checkbox" service="1" title="ePUB Package" value="999" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappscomplexebookappsipad" class="chkcomplexproducts" runat="server"  />
                                                    IPad </td>
                                                <td>$<asp:Label ID="lblebookappscomplexebookappsipadproductcost" class="complexprice" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; Works only with IPad & IPad mini </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="eb2g_products_details_mobi">
                                        <table class="complexproducts">
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="Checkbox3" type="checkbox" service="2" title="Mobi Package" value="999" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappscomplexebookappsiphone" class="chkcomplexproducts" runat="server"  />
                                                    IPhone</td>
                                                <td>$<asp:Label ID="lblebookappscomplexebookappsiphoneproductcost" class="complexprice" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; Works only with IPhone 3,4,5 </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="eb2g_products_details_epdf">
                                        <table class="complexproducts">
                                            <tr class="store_name">
                                                <td width="220">
                                                   <%-- <input id="Checkbox4" type="checkbox" service="3" title="ePDF Package" value="999" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappscomplexebookappsandroidtablets" class="chkcomplexproducts" runat="server" />
                                                    Android Tablets</td>
                                                <td>$<asp:Label ID="lblebookappscomplexebookappsandroidtabletsproductcost" class="complexprice" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; Works only with 10 inch and 7 inch</td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="eb2g_products_details_andriodphone">
                                        <table class="complexproducts">
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="Checkbox5" type="checkbox" service="4" title="ePDF Package" value="999" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappscomplexebookappsandroidphones" class="chkcomplexproducts" runat="server" />
                                                    Android Phones</td>
                                                <td>$<asp:Label ID="lblebookappscomplexebookappsandroidphonesproductcost" class="complexprice"  runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; All Android smartphones 3.2 versions   devices</td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            </asp:Panel>
                            <div class="eb2g_products_cost">
                                <div class="eb2g_PackageCost">
                                    Package Cost
                                        <br />
                                    <%--<input type="text" id="Text1" />--%>
                                    <asp:TextBox ID="txtebookappscomplexebookappspackagecost" class="complexpackagecost" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="eb2g_addtocart">
                                    <a href="#">
                                        <img src="images/addtocart.jpg" alt="" />
                                    </a>
                                </div>
                                <div class="eb2g_viewcart">
                                    <a href="#">
                                        <img src="images/viewcart.jpg" alt="" />
                                    </a>
                                </div>
                                <div class="eb2g_checkout"><a href="#"></a></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div>&nbsp;</div>
                <div style="width: 980px; float: left; height: 20px;">&nbsp;</div>
                <hr>
                <span class="Customizeyourproduct">
                    <h3>Customize your product</h3>
                </span>
                <div class="Customize_pricing">
                    <table width="1000" cellspacing="0" class="complex_customize_products">
                        <tr>
                            <td width="490">
                                <h4>Total Number of pages in the Book</h4>
                                <span class="Customize_totalnumber">Upto
                                    <asp:Label ID="lblebookappscomplexebookappscustpages" class="complexCustdefault" runat="server"></asp:Label>
                                    pages are included in the base price. <br />&nbsp;&nbsp;&nbsp;Each Additonal Animation pages will be billed at. $<asp:Label ID="lblebookappscomplexebookappscustpagescost" class="complexCustcost" runat="server"></asp:Label>
                                    , either device </span></td>
                            <td width="100" align="center">
                               <%-- <input type="text" />--%>
                            <asp:TextBox ID="txtebookappscomplexebookappscustpages" runat="server" class="complexCustqty"></asp:TextBox>
                              <asp:FilteredTextBoxExtender ID="fteebookappscomplexebookappscustpages" runat="server" FilterType="Numbers"
    TargetControlID="txtebookappscomplexebookappscustpages" />
                            </td>
                            <td><asp:Label ID="lblebookappscomplexebookappsadditionalpages"  class="complexCustadditional"  runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappscomplexebookappsaddtionalpagesunitcost"  class="complexCustadditionalunitcost"  runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappscomplexebookappsadditionalpagestotalcost"  class="complexCustadditionaltotalcost" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="490">
                                <h4>Total Number of Animation pages</h4>
                                <span class="Customize_totalnumber">Upto
                                    <asp:Label ID="lblebookappscomplexebookappscustanimationpages" class="complexCustdefault" runat="server"></asp:Label>
                                    pages are included in the base price.<br />
                                    &nbsp;&nbsp;&nbsp;Each Additonal Animation pages will be billed at. $<asp:Label ID="lblebookappscomplexebookappscustanimationpagescost" class="complexCustcost" runat="server"></asp:Label>
                                    , either device </span></td>
                            <td width="100" align="center">
                                <%--<input type="text" />--%>
                                <asp:TextBox ID="txtebookappscomplexebookappscustanimationpages" runat="server" class="complexCustqty" ></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="fteebookappscomplexebookappscustanimationpages" runat="server" FilterType="Numbers"
    TargetControlID="txtebookappscomplexebookappscustanimationpages" />
                            </td>
                            <td><asp:Label ID="lblebookappscomplexebookappsadditionalanimationpages" class="complexCustadditional" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappscomplexebookappsadditionalanimationpagesunitcost"  class="complexCustadditionalunitcost"  runat="server"></asp:Label></td> 
                            <td><asp:Label ID="lblebookappscomplexebookappsadditionalanimationpagestotalcost"  class="complexCustadditionaltotalcost" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                    <h3>Samples Application</h3>
                    <div class="container">
                        <section id="dg-container1" class="dg-container1">
                            <div class="dg-wrapper">
                                <a href="#">
                                    <img src="images/1.png" alt="image01">
                                    <div>Time Soldiers</div>
                                </a><a href="#">
                                    &nbsp;&nbsp;<img alt="image02" src="images/2.png">
                                <div>
                                    Time Soldiers</div>
                                </img></a>


                                &nbsp;

                                <a href="#">
                                    <img src="images/3.png" alt="image03">
                                    <div>Time Soldiers</div>
                                </a>

                                &nbsp;
                                <a href="#">
                                    <img src="images/4.png" alt="Pearl Harbor ">
                                    <div>Pearl Harbor </div>
                                </a>
                                &nbsp;
                                <a href="#">
                                    <img src="images/5.png" alt="Pearl Harbor ">
                                    <div>Pearl Harbor </div>
                                </a>
                                &nbsp; <a href="#">
                                <img alt="Pearl Harbor " src="images/6.png">
                                <div>
                                    Pearl Harbor
                                </div>
                                </img></a> &nbsp;<a href="#"><img alt="Pearl Harbor " src="images/7.png">
                                <div>
                                    Pearl Harbor
                                </div>
                                </img></a> &nbsp;<a href="#"><img alt="Pearl Harbor " src="images/8.png">
                                <div>
                                    Pearl Harbor
                                </div>
                                </img></a> &nbsp;<a href="#"><img alt="Pearl Harbor " src="images/9.png">
                                <div>
                                    Pearl Harbor
                                </div>
                                </img></a> &nbsp;</div>
                            <!--nav>	
					<span class="dg-prev">&lt;</span>
					<span class="dg-next">&gt;</span>
				</nav-->
                        </section>
                    </div>
                </div>
                <script>
                    $(document).ready(function () {
                        $("#proceeds").click(function () {
                            $("#apDiv2").css("display", "none");
                        });
                    });
                </script>
                <%--                    <img src="images/proceed.jpg" id="proceeds" alt="proceed" width="117" height="30" align="right" onclick="complex();" style="margin-right: 20px; margin-top: 10px;">--%>
                <asp:ImageButton ID="imgbtncomplexproceed" OnClick="imgbtnsimpleproceed_Click" ImageUrl="images/proceed.jpg" Width="117" Height="30" align="right" Style="margin-right: 20px; margin-top: 10px;" runat="server" />
            </div>
            </asp:Panel>
           </div>
       <div class="divstyle"  id="divtextbooks">
  
  <asp:Panel ID="pnltxtbok" runat="server">
            <div id="eBookAppsforTextbooks">
                <div class="eb2g_StandardFormateBook">
                    <div class="eb2g_headerleft">
                        <div class="eb2g_StandardFormat_title">eBook Apps:</div>
                        <div style="height: 135px; width: 200px;"></div>
                        <div class="eb2g_StandardFormat_titleimg">
                            <img src="images/EnhancedeBookformating.png" alt="" />
                        </div>
                        <div class="eb2g_discountprice">
                            <div class="blueclock">
                                <div style="transform: rotate(0deg) scale(1, 1); display: block;" class="pendulum-parent">
                                    <div class="ebooks_discount" align="center">
                                        <b>Offers</b>
                                        <ul>
                                            <li>Select any '
                                                <asp:Label ID="lblebookappsfortextbooksoffer1" class="textbookoffer1" runat="server"></asp:Label>
                                                ' products get
                                                <asp:Label ID="lblebookappsfortextbooksoffer1discount"  class="textbookoffer1discount" runat="server"></asp:Label>
                                                Discount on base price' </li>
                                            <li>Select any '
                                                <asp:Label ID="lblebookappsfortextbooksoffer2" class="textbookoffer2" runat="server"></asp:Label>
                                                ' products get
                                                <asp:Label ID="lblebookappsfortextbooksoffer2discount" class="textbookoffer2discount" runat="server"></asp:Label>
                                                Discount on base price</li>
                                            <li>Select any '
                                                <asp:Label ID="lblebookappsfortextbooksoffer3" class="textbookoffer3" runat="server"></asp:Label>
                                                ' products get
                                                <asp:Label ID="lblebookappsfortextbooksoffer3discount" class="textbookoffer3discount" runat="server"></asp:Label>
                                                Discount on base price</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="eb2g_headerright">
                        <div class="box-heading">Choose product(s) </div>
                        <div class="apps-box-content">
                            <asp:Panel ID="pnlebookappsfortextbooksproducts" runat="server">
                            <div class="eb2g_products">
                                <div class="eb2g_products_details">Product</div>
                                <div class="eb2g_products_details_right">Cost</div>
                                <div class="eb2g_ebooksappsdetails">
                                    <div class="eb2g_products_details_eup">
                                        <table class="textbookproducts">
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="Checkbox6" type="checkbox" service="1" title="ePUB Package" value="999" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappsfortextbooksipad" class="chktextbookproducts" runat="server"   />
                                                    IPad </td>
                                                <td>$<asp:Label ID="lblebookappsfortextbooksipadproductcost" class="textbookprice" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; Works only with IPad & IPad mini </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="eb2g_products_details_mobi">
                                        <table class="textbookproducts">
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="Checkbox7" type="checkbox" service="2" title="Mobi Package" value="999" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappsfortextbooksiphone" class="chktextbookproducts" runat="server" />
                                                    IPhone</td>
                                                <td>$<asp:Label ID="lblebookappsfortextbooksiphoneproductcost" runat="server" class="textbookprice"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; Works only with IPhone 3,4,5 </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="eb2g_products_details_epdf">
                                        <table class="textbookproducts">
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="Checkbox8" type="checkbox" service="3" title="ePDF Package" value="999" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappsfortextbooksandroidtablets" class="chktextbookproducts" runat="server"  />
                                                    Android Tablets</td>
                                                <td>$<asp:Label ID="lblebookappsfortextbooksandroidtabletsproductcost" runat="server" class="textbookprice"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; Works only with 10 inch and 7 inch</td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="eb2g_products_details_andriodphone">
                                        <table class="textbookproducts">
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="Checkbox9" type="checkbox" service="4" title="ePDF Package" value="999" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappsfortextbooksandroidphones"  class="chktextbookproducts" runat="server"  />
                                                    Android Phones</td>
                                                <td>$<asp:Label ID="lblebookappsfortextbooksandroidphonesproductcost" runat="server" class="textbookprice"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; All Android smartphones 3.2 versions   devices</td>
                                            </tr>
                                        </table>
                                    </div>
                                </div


                            </div>
                                </asp:Panel>
                            <div class="eb2g_products_cost">
                                <div class="eb2g_PackageCost">
                                    Package Cost
                                        <br />
                                    <%--<input type="text" id="Text3" />--%>
                                    <asp:TextBox ID="txtebookappsfortextbookspackagecost" class="textbookpackagecost" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="eb2g_addtocart">
                                    <a href="#">
                                        <img src="images/addtocart.jpg" alt="" />
                                    </a>
                                </div>
                                <div class="eb2g_viewcart">
                                    <a href="#">
                                        <img src="images/viewcart.jpg" alt="" />
                                    </a>
                                </div>
                                <div class="eb2g_checkout"><a href="#"></a></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div>&nbsp;</div>
                <div style="width: 980px; float: left; height: 20px;">&nbsp;</div>
                <hr>
                <span class="Customizeyourproduct">
                    <h3>Customize your product</h3>
                </span>
                <div class="Customize_pricing">
                    <table width="1000" cellspacing="0" class="textbook_customize_products">
                        <tr>
                            <td width="490">
                                <h4>Total Number of pages in the Book</h4>
                                <span class="Customize_totalnumber">Upto
                                    <asp:Label ID="lblebookappsfortextbookscustpages" class="textbookCustdefault"  runat="server"></asp:Label>
                                    pages are included in the base price  <br />&nbsp;&nbsp;&nbsp;Each Additonal Animation pages will be billed at. $<asp:Label ID="lblebookappsfortextbookscustpagescost" class="textbookCustcost" runat="server"></asp:Label>
                                    , either device </span></td>
                            <td width="100" align="center">
                               <%-- <input type="text" />--%>
                             <asp:TextBox ID="txtebookappsfortextbookscustpages" class="txtbookqty" runat="server" ></asp:TextBox>
                             <asp:FilteredTextBoxExtender ID="fteebookappsfortextbookscustpages" runat="server" FilterType="Numbers"
    TargetControlID="txtebookappsfortextbookscustpages" />
                            </td>
                            <td><asp:Label ID="lblebookappsfortextbooksadditionalpages" class="textbookCustadditional" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappsfortextbooksadditionalpagesunitcost" class="textbookCustadditionalunitcost"  runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappsfortextbooksadditionalpagestotalcost" class="textbookCustadditionaltotalcost" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="490">
                                <h4>Interactive Self Assessments,Q & A</h4>
                                <span class="Customize_totalnumber">Upto
                                    <asp:Label ID="lblebookappsfortextbookscustinteractiveselfassessmentpages" class="textbookCustdefault" runat="server"></asp:Label>
                                    pages are included in the base price.<br />
                                    &nbsp;&nbsp;&nbsp;Each Additonal Interactive Self Assessments,Q & A will be billed at. $<asp:Label ID="lblebookappsfortextbookscustinteractiveselfassessmentpagescost" class="textbookCustcost" runat="server"></asp:Label></span></td>
                            <td width="100" align="center">
                               <%-- <input type="text" />--%>
                            <asp:TextBox ID="txtebookappsfortextbookscustinteractiveandselfassessmentpages" class="txtbookqty" runat="server" ></asp:TextBox>
                             <asp:FilteredTextBoxExtender ID="fteebookappsfortextbooksinteractiveassessement" runat="server" FilterType="Numbers"
    TargetControlID="txtebookappsfortextbookscustinteractiveandselfassessmentpages" />
                            </td>
                            <td><asp:Label ID="lblebookappsfortextbooksadditionalinteractiveselfassessmentpages" class="textbookCustadditional" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappsfortextbooksadditionalinteractiveselfassessmentunitcost" class="textbookCustadditionalunitcost" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappsfortextbooksadditionalinteractiveselfassessmenttotalcost" class="textbookCustadditionaltotalcost" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="490">
                                <h4>Video & Audio Integration</h4>
                                <span class="Customize_totalnumber">Upto
                                    <asp:Label ID="lblebookappsfortextbookscustavintergrationpages" class="textbookCustdefault" runat="server"></asp:Label>
                                    pages are included in the base price.
              <br />
                                    &nbsp;&nbsp;&nbsp;Each Additonal Video & Audio Integration will be billed at. $<asp:Label ID="lblebookappsfortextbookscustavintergrationpagescost" class="textbookCustcost" runat="server"></asp:Label>
                                </span></td>
                            <td width="100" align="center">
                                
                                <asp:TextBox ID="txtebookappsfortextbookscustavelements" class="txtbookqty" runat="server" ></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="fteebookappsfortextbooksaudioandvideo" runat="server" FilterType="Numbers"
    TargetControlID="txtebookappsfortextbookscustavelements" />
                            </td>
                            <td><asp:Label ID="lblebookappstextbooksadditionalavelements" class="textbookCustadditional"  runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappstextbooksadditionalavelementsunitcost" class="textbookCustadditionalunitcost" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappstextbooksadditionalavelementstotalcost" class="textbookCustadditionaltotalcost" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                    <h3>Samples Application</h3>
                    <div class="container">
                        <section id="dg-container2" class="dg-container2">
                            <div class="dg-wrapper">
                                <a href="#">
                                    <img src="images/1.png" alt="image01">
                                    <div>Time Soldiers</div>
                                </a><a href="#">
                                    &nbsp;&nbsp;<img alt="image02" src="images/2.png">
                                <div>
                                    Time Soldiers</div>
                                </img></a><a href="#">
                                    &nbsp;<img alt="image03" src="images/3.png">
                                <div>
                                    Time Soldiers</div>
                                </img></a>
                                &nbsp;</div>
                            <!--nav>	
					<span class="dg-prev">&lt;</span>
					<span class="dg-next">&gt;</span>
				</nav-->
                        </section>
                    </div>
                </div>
                <script>
                    $(document).ready(function () {
                        $("#ebookproceed").click(function () {
                            $("#apDiv2").css("display", "none");
                        });
                    });
                </script>
                <asp:ImageButton ID="imgbtntextbook" OnClick="imgbtnsimpleproceed_Click" ImageUrl="images/proceed.jpg" Width="117" Height="30" align="right" Style="margin-right: 20px; margin-top: 10px;" runat="server" />
            </div>
        </asp:Panel>
           </div>
</div>
        <script type="text/javascript">
            TINY.scroller.init('scroll', 'scrollcontent', 'scrollbar', 'scroller', 'buttonclick');
</script>
<script type="text/javascript" src="js/jquery.gallery.js"></script>
<script>
    function updateTextArea() {
        var total = 0;
        $('#StandardeBookFormat :checked').each(function () {
            total += parseFloat($(this).val());
        });
        $('#totalamount').val(total)
    }
    $(function () {
        $('#StandardeBookFormat input').click(updateTextArea);
        updateTextArea();
    });

</script>
<script>jsbinShowEdit({ "root": "http://static.jsbin.com", "csrf": "EBPkHVtpW6pWr2NUndySD+SD" });</script>
<script src="http://static.jsbin.com/js/vendor/eventsource.js?3.8.10"></script>
<script src="http://static.jsbin.com/js/spike.js?3.8.10"></script>
<script>
    var _gaq = _gaq || [];
    _gaq.push(['_setAccount', 'UA-1656750-34']);
    _gaq.push(['_trackPageview']);

    (function () {
        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
        (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(ga);
    })();
</script>
<script type="text/javascript" src="js/jquery.gallery.js"></script>
<script type="text/javascript">
    $(function () {
        $('#dg-container').gallery({
            autoplay: true
        });
    });
		</script>
<script type="text/javascript">
    $(function () {
        $('#dg-container1').gallery({
            autoplay: true
        });
    });
		</script>
<script type="text/javascript">
    $(function () {
        $('#dg-container2').gallery({
            autoplay: true
        });
    });
		</script>
<script src="js/jquery.mCustomScrollbar.concat.min.js"></script>
<script>
    (function ($) {
        $(window).load(function () {
            $("#content_1").mCustomScrollbar({
                scrollButtons: {
                    enable: true
                },
                callbacks: {
                    onScrollStart: function () { OnScrollStart(); },
                    onScroll: function () { OnScroll(); },
                    onTotalScroll: function () { OnTotalScroll(); },
                    onTotalScrollBack: function () { OnTotalScrollBack(); },
                    onTotalScrollOffset: 40,
                    onTotalScrollBackOffset: 20,
                    whileScrolling: function () { WhileScrolling(); }
                }
            });
            function OnScrollStart() {
                $(".output .onScrollStart").stop(true, true).css("display", "inline-block").delay(500).fadeOut(500);
            }
            function OnScroll() {
                $(".output .onScroll").stop(true, true).css("display", "inline-block").delay(500).fadeOut(500);
            }
            function OnTotalScroll() {
                $(".output .onTotalScroll").stop(true, true).css("display", "inline-block").delay(500).fadeOut(500);
            }
            function OnTotalScrollBack() {
                $(".output .onTotalScrollBack").stop(true, true).css("display", "inline-block").delay(500).fadeOut(500);
            }
            function WhileScrolling() {
                $(".output .whileScrolling").stop(true, true).css("display", "inline-block").fadeOut(500);
                $(".info .content-position").text(mcs.top);
                $(".info .dragger-position").text(mcs.draggerTop);
                $(".info .scroll-pct").text(mcs.topPct + "%");
            }
            $(".total-scroll-offset").text($("#content_1").data("onTotalScroll_Offset"));
            $(".total-scroll-back-offset").text($("#content_1").data("onTotalScrollBack_Offset"));
            $(".output a").click(function (e) {
                e.preventDefault();
                var $this = $(this),
                    rel = $this.attr("rel"),
                    target = $this.parent().find("." + rel);
                target.add($this).toggleClass("hidden");
            });
        });
    })(jQuery);
	</script>

          <script>
              $(".chksimpleproducts").change(function () {
                  simpleebookcalculation()
              });
        </script>

         <script>
             function simpleproductcount() {
                 var i = 0;
                 $("#pnlebookappssimpleebookappsproducts input:checked").each(function () {
                     i++;
                 });
                 return i;
             }
        </script>
        <script>
            function simpleproductcost() {
                var totproductcost = 0;
                var count = simpleproductcount();
                $('.simpleproducts tr').each(function (i, row) {

                    // reference all the stuff you need first
                    var $row = $(row);
                    //Custdefault = $row.find('.Custdefault').html();
                    rowcheckbox = $row.find('input:checked');
                    if (rowcheckbox.is(':checked')) {
                        totproductcost = parseFloat(totproductcost) + parseFloat($row.find('.simpleprice').html());
                    }

                });
                if (totproductcost > 0) {
                    if (count == parseInt($('.simpleoffer1').html()) && count < parseInt($('.simpleoffer2').html())) {
                        totproductcost = totproductcost - (100 - parseFloat($('.simpleoffer1discount').html())) / 100;

                    }
                    else if (count == parseInt($('.simpleoffer2').html()) && count < parseInt($('.simpleoffer3').html())) {
                        totproductcost = totproductcost - (100 - parseFloat($('.simpleoffer2discount').html())) / 100;

                    }
                    else if (count >= parseInt($('.simpleoffer3').html())) {
                        totproductcost = totproductcost - (100 - parseFloat($('.simpleoffer3discount').html())) / 100;
                    }
                    return totproductcost;
                }
                else {
                    return totproductcost;
                }
            }
        </script>
        <script>
            function simpleebookcalculation() {
                var baseprice = 0;
                var Customisationcost = 0;
                baseprice = simpleproductcost();
                var count = simpleproductcount();
                if (count > 0) {

                    $('.simple_customize_products tr').each(function (i, row) {
                        //alert('Hi');
                        var $row = $(row),
                         Custdefault = $row.find('.Custdefault').html();
                        Custcost = $row.find('.Custcost').html();
                        Custqty = $row.find('.Custqty').val();
                        Custadditional = $row.find('.Custadditional').val();
                        Custadditionalunitcost = $row.find('.Custadditionalunitcost').val();
                        if (!isNaN(parseInt($row.find('.Custqty').val()))) {
                            if (parseInt($row.find('.Custqty').val()) > parseInt($row.find('.Custdefault').html())) {

                                $row.find('.Custadditional').html(parseInt($row.find('.Custqty').val()) - parseInt($row.find('.Custdefault').html()));
                                $row.find('.Custadditionalunitcost').html($row.find('.Custcost').html());
                                $row.find('.Custadditionaltotalcost').html((parseInt($row.find('.Custqty').val()) - parseInt($row.find('.Custdefault').html())) * parseFloat($row.find('.Custcost').html()) * parseInt(count));
                                Customisationcost = parseFloat(Customisationcost) + parseFloat((parseInt($row.find('.Custqty').val()) - parseInt($row.find('.Custdefault').html())) * parseFloat($row.find('.Custcost').html()) * parseInt(count))
                            }
                            else {
                                $row.find('.Custadditional').html('');
                                $row.find('.Custadditionalunitcost').html('');
                                $row.find('.Custadditionaltotalcost').html('');
                            }

                        }
                        else {
                            $row.find('.Custadditional').html('');
                            $row.find('.Custadditionalunitcost').html('');
                            $row.find('.Custadditionaltotalcost').html('');
                        }

                    });
                    $('.simpletotalcost').val((parseFloat(baseprice) + parseFloat(Customisationcost)).toFixed(2));
                    $('#imgbtnsimpleproceed').prop('disabled', false);
                }
                else {
                    clearcustomisations();
                    $('.simpletotalcost').val('');
                    $('input:checkbox').removeAttr('checked');
                    $('#imgbtnsimpleproceed').prop('disabled', true);
                }
                
                
            }
        </script>

        <script>
            function clearcustomisations() {
                $('.simple_customize_products tr').each(function (i, row) {
                    var $row = $(row);
                    $row.find('.Custadditional').html('');
                    $row.find('.Custadditionalunitcost').html('');
                    $row.find('.Custadditionaltotalcost').html('');
                    $row.find('.Custqty').val('');
                });
            }
        </script>
       <script>
           jQuery('.Custqty').on('keyup', function () {
               //alert('Hi');
               simpleebookcalculation();
           });
            </script>

         <script>
             $(".chkcomplexproducts").change(function () {
                 
                 complexebookcalculation();
             });
        </script>
         <script>
             function complexproductcount() {
                 var i = 0;
                 $("#pnlebookappscomplexebookappsproducts input:checked").each(function () {
                     i++;
                 });
                 return i;
             }
        </script>
         <script>
             function complexproductcost() {
                 var totproductcost = 0;
                 var count = complexproductcount();
                 $('.complexproducts tr').each(function (i, row) {

                     // reference all the stuff you need first
                     var $row = $(row);
                     //Custdefault = $row.find('.Custdefault').html();
                     rowcheckbox = $row.find('input:checked');
                     if (rowcheckbox.is(':checked')) {
                         totproductcost = parseFloat(totproductcost) + parseFloat($row.find('.complexprice').html());
                     }

                 });
                
                 if (totproductcost > 0) {
                     if (count == parseInt($('.complexoffer1').html()) && count < parseInt($('.complexoffer2').html())) {
                         totproductcost = totproductcost - (100 - parseFloat($('.complexoffer1discount').html())) / 100;
                        
                     }
                     else if ( count == parseInt($('.complexoffer2').html()) && count < parseInt($('.complexoffer3').html())) {
                         totproductcost = totproductcost - (100 - parseFloat($('.complexoffer2discount').html())) / 100;
                     }
                     else if (count >= parseInt($('.complexoffer3').html())) {
                         totproductcost = totproductcost - (100 - parseFloat($('.complexoffer3discount').html())) / 100;
                        
                     }
                    
                 }
                 else {
                     totproductcost = 0;

                 }
                 return totproductcost;
             }
        </script>
           <script>
               function complexebookcalculation() {
                   var baseprice = 0;
                   var Customisationcost = 0;
                   var count = 0;
                   baseprice = complexproductcost();
                   count = complexproductcount();
                   //alert(count);
                   if (count > 0) {
                       //alert('Hi');
                       $('.complex_customize_products tr').each(function (i, row) {
                           var $row = $(row),
                            Custdefault = $row.find('.complexCustdefault').html();
                           Custcost = $row.find('.complexCustcost').html();
                           Custqty = $row.find('.complexCustqty').val();
                           Custadditional = $row.find('.complexCustadditional').val();
                           Custadditionalunitcost = $row.find('.complexCustadditionalunitcost').val();
                           if (!isNaN(parseInt($row.find('.complexCustqty').val()))) {
                               if (parseInt($row.find('.complexCustqty').val()) > parseInt($row.find('.complexCustdefault').html())) {
                                   $row.find('.complexCustadditional').html(parseInt($row.find('.complexCustqty').val()) - parseInt($row.find('.complexCustdefault').html()));
                                   $row.find('.complexCustadditionalunitcost').html($row.find('.complexCustcost').html());
                                   $row.find('.complexCustadditionaltotalcost').html((parseInt($row.find('.complexCustqty').val()) - parseInt($row.find('.complexCustdefault').html())) * parseFloat($row.find('.complexCustcost').html()) * parseInt(count));
                                   Customisationcost = parseFloat(Customisationcost) + parseFloat((parseInt($row.find('.complexCustqty').val()) - parseInt($row.find('.complexCustdefault').html())) * parseFloat($row.find('.complexCustcost').html()) * parseInt(count));

                               }
                               else {
                                   $row.find('.complexCustadditional').html('');
                                   $row.find('.complexCustadditionalunitcost').html('');
                                   $row.find('.complexCustadditionaltotalcost').html('');
                               }

                           }
                           else {
                               $row.find('.complexCustadditional').html('');
                               $row.find('.complexCustadditionalunitcost').html('');
                               $row.find('.complexCustadditionaltotalcost').html('');
                           }
                       });
                       $('.complexpackagecost').val((parseFloat(baseprice) + parseFloat(Customisationcost)).toFixed(2));
                       $('#imgbtncomplexproceed').prop('disabled', false);
                   }
                   else {
                       clearcustomisations();
                       $('.complexpackagecost').val('');
                       $('input:checkbox').removeAttr('checked');
                       $('#imgbtncomplexproceed').prop('disabled',true);
                   }
                   
               }
               </script>
        <script>
            jQuery('.txtbookqty').on('keyup', function () {
                //alert('Hi');
                complexebookcalculation();
            });
            </script>

                <script>
                    function clearcustomisations() {
                        $('.complex_customize_products tr').each(function (i, row) {
                            var $row = $(row);
                            $row.find('.complexCustadditional').html('');
                            $row.find('.complexCustadditionalunitcost').html('');
                            $row.find('.complexCustadditionaltotalcost').html('');
                            $row.find('.complexCustqty').val('');
                        });
                    }
        </script>
           <script>
               function textbookproductcount() {
                   var i = 0;
                   $("#pnlebookappsfortextbooksproducts input:checked").each(function () {
                       i++;
                   });
                   return i;
               }
        </script>
         <script>
             jQuery('.textbookCustqty').on('keyup', function () {
                 //txtbookcalculation();
             });
            </script>
        <script>
            $(".chktextbookproducts").change(function () {
                txtbookcalculation();
            });
        </script>

         <script>
             function textbookproductcost() {
                 var totproductcost = 0;
                 var count = textbookproductcount();
                 $('.textbookproducts tr').each(function (i, row) {

                     // reference all the stuff you need first
                     var $row = $(row);
                     //Custdefault = $row.find('.Custdefault').html();
                     rowcheckbox = $row.find('input:checked');
                     if (rowcheckbox.is(':checked')) {
                         totproductcost = parseFloat(totproductcost) + parseFloat($row.find('.textbookprice').html());
                     }

                 });

                 if (totproductcost > 0) {
                     if (count == parseInt($('.textbookoffer1').html()) && count < parseInt($('.textbookoffer2').html())) {
                         totproductcost = totproductcost - (100 - parseFloat($('.textbookoffer1discount').html())) / 100;

                     }
                     else if (count == parseInt($('.textbookoffer2').html()) && count < parseInt($('.textbookoffer3').html())) {
                         totproductcost = totproductcost - (100 - parseFloat($('.textbookoffer2discount').html())) / 100;
                     }
                     else if (count >= parseInt($('.textbookoffer3').html())) {
                         totproductcost = totproductcost - (100 - parseFloat($('.textbookoffer3discount').html())) / 100;

                     }

                 }
                 else {
                     totproductcost = 0;

                 }
                 return totproductcost;
             }
        </script>
    </form>
</body>

</html>
