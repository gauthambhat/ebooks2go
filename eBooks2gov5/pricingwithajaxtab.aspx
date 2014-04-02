<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pricingwithajaxtab.aspx.cs"
    Inherits="eBooks2goV5.pricingwithajaxtab" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>ebooks2go</title>
    <%-- Tab Container Css Begin--%>
    <style type="text/css">
        .fancy-green .ajax__tab_header
        {
            cursor: pointer;
        }
        .fancy-green .ajax__tab_hover .ajax__tab_outer, .fancy-green .ajax__tab_active .ajax__tab_outer
        {
            background: url(../green_left_Tab_hover.gif) no-repeat left top;
        }
        .fancy-green .ajax__tab_hover .ajax__tab_inner, .fancy-green .ajax__tab_active .ajax__tab_inner
        {
            background: url(../green_right_Tab_hover.gif) no-repeat right top;
        }
        .ajax__tab_outer
        {
            background: url(../green_left_Tab.gif) no-repeat left top;
        }
        .ajax__tab_inner
         {
            background: url(../green_right_Tab.gif) no-repeat right top;
        }
        .fancy .ajax__tab_header
        {
            font-size: 13px;
            font-weight: bold;
            color: #000;
            font-family: sans-serif;
        }
        .fancy .ajax__tab_active .ajax__tab_outer, .fancy .ajax__tab_header .ajax__tab_outer, .fancy .ajax__tab_hover .ajax__tab_outer
        {
            height: 33px;
        }
        .fancy .ajax__tab_active .ajax__tab_inner, .fancy .ajax__tab_header .ajax__tab_inner, .fancy .ajax__tab_hover .ajax__tab_inner
        {
            height: 33px;
            margin-left: 5px; /* offset the width of the left image */
        }
        .fancy .ajax__tab_active .ajax__tab_tab, .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_header .ajax__tab_tab
        {
            margin: 0px 0px 0px 0px;
            padding:8px;
        }
        .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_active .ajax__tab_tab
        {
            color: #000;
        }
        .fancy .ajax__tab_body
        {
            font-family: Arial;
            font-size: 10pt;
            border-top: 0;
            border: 1px solid #999999;
            background-color: #ffffff;
        }
        .ajax__tab_outer{
           width:200px;
        }
        .ajax__tab_inner {
            width:194px;
         }
        .test_tab{
            width:194px;
            float:left;
         }
        .eb2g_test
        {
            width: 1000px;
            margin: auto;
        }
    </style>
    <%-- Tab Container Css End--%>
    <%--eBooks2go css begin--%>
    <link href='http://fonts.googleapis.com/css?family=Gloria+Hallelujah' rel='stylesheet'
        type='text/css'>
    <link href="../css/pricingpage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type='text/javascript' src="../js/jquery-css-transform.js"></script>
    <script type="text/javascript" src="../js/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../js/jquery.ui.accordion.js"></script>
    <script type="text/javascript">
        var setChecked = function (oThis) {
            setTimeout(function () {
                $(oThis).attr("checked", "checked");
            }, 10);
        };
        $(function () {
            $("#accordion").accordion({
                collapsible: false,
                change: function (event, ui) {
                    setChecked($("input", ui.newHeader));
                }
            });
            $("#accordion h4 input").css("margin-left", "50px");
            $("#accordion h4 input").eq(0).attr("checked", "checked");
        }); 
  
    </script>
    <script type='text/javascript'>//<![CDATA[
        $(window).load(function () {
            // Short-form of `document.ready`
            $(function () {
                $("#div1").show();

            });
        });//]]>  

    </script>
    <script type='text/javascript'>
        $(document).ready(function () {

            $('#tabEbook').hide();

            $("#preview").click(function () {
                $(".eb2g_StandardFormat_contents").slideToggle("slow");
            });
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

        $(function () {
            $(document).tooltip();
        });

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
    </script>
    <style type="text/css">
        .divstyle
        {
            display: none;
            height: auto;
            width: auto;
        }
    </style>
    <link type='text/css' href='../css/pricingpage.css' rel='stylesheet' media='screen' />
    <style>
        body
        {
            font-family: Verdana, Geneva, sans-serif;
        }
        @font-face
        {
            font-family: "Droid Sans";
            src: url(DroidSans.ttf) format("truetype");
        }
        @font-face
        {
            font-family: "Trebuchet MS";
            src: url(trebuc.ttf) format("truetype");
        }
        @font-face
        {
            font-family: "Roboto";
            src: url(Roboto-bold.ttf) format("truetype");
        }
        @font-face
        {
            font-family: "Oswald";
            src: url(Oswald-Regular.otf) format("truetype");
        }
    </style>
    <style type='text/css'>
        .blueclock
        {
            float: left;
            margin-left: -30px;
        }
        .pendulum-parent
        {
            display: none;
            height: 40px;
            width: 228px;
        }
        .pendulum-child
        {
            left: 150px;
            position: absolute;
            top: 0;
        }
        .ebooks_discount
        {
            width: 235px;
            height: 235px;
            float: none;
            background-image: url(../images/best.png);
            background-repeat: no-repeat;
            color: #FFF; /* [disabled]padding: 6px; */ /* [disabled]padding-top: 20px; */
        }
        
        #apDiv1
        {
            position: absolute;
            left: 236px;
            top: 90px;
            width: 64px;
            height: 55px;
            z-index: 1;
        }
        #apDiv2
        {
            position: absolute;
            left: 5px;
            top: 40px;
            width: 300px;
            height: 100px;
            z-index: 0;
        }
        #apDiv3
        {
            position: absolute;
            left: 300px;
            top: 120px;
            width: 64px;
            height: 55px;
            z-index: 1;
        }
        .ebooks_discount
        {
            color: #000;
            font-size: 1.2em;
            padding: 10px;
            padding-top: 5px;
        }
        
        .ebooks_discount ul
        {
            margin-left: -10px;
            font-size: 0.8em;
            font-weight: normal;
            margin-right: 10px;
            list-style-image: url(../images/star.png);
            list-style-position: inside;
        }
        .ebooks_discount ul li
        {
            font-family: 'Gloria Hallelujah' , cursive;
            color: #000;
            text-align: left;
        }
        #tabEbook
        {
            font-family: Verdana, Geneva, sans-serif;
            font-weight: bold;
            font-size: 0.8em;
            color: #000;
        }
        #tabEbook td, th
        {
            padding: 0.5em;
        }
        #tabEbook th
        {
            background-color: #000;
            color: #fff;
            font-size: 1.2em;
        }
        .tabHeads
        {
            color: ##68b026;
            font-size: 20px;
            line-height: 40px;
            margin-left: 2px;
        }
        .subHeads
        {
            text-align: right;
            color: #999;
        }
        .cartHold
        {
            display: inline-block;
            float: left;
        }
        .cartHold img
        {
            display: inline-block;
            width: 50px;
            height: auto;
        }
        .productHold
        {
            display: inline-block;
            margin-left: 10px;
            color: #ff0000;
        }
        #tabEbook > table
        {
            border: 0;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="../js/modernizr.custom.53451.js"></script>
    <script type="text/javascript" src="../js/jquery.gallery.js"></script>
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
    <%--eBooks2go Css End--%>

    <%--back button disable start--%>
    <script type="text/javascript">
    function preventBack() {
    window.history.forward();
}
 window.onunload = function() {
    null;
};
 setTimeout("preventBack()", 0);
        </script>
    <%--back button disable complete--%>
</head>

<body>
    <form id="form1" runat="server">

    <ajax:ToolkitScriptManager ID="scriptmanager1" runat="server">
    </ajax:ToolkitScriptManager>

    <div class="eb2g_test">

        <ajax:TabContainer ID="TabContainer1" runat="server" CssClass="fancy fancy-green"
            ActiveTabIndex="0">
            
            <ajax:TabPanel ID="tbpnlebook" runat="server">
                <HeaderTemplate>
                   <div class="test_tab" align="center"> eBook</div>
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:Panel ID="pnlebook" runat="server">
                        <%--<div id="view1" runat="server" class="tabcontent default">
                            <div id="Div4">
                                <div class="eb2g_StandardFormateBook">
                                    <div class="eb2g_headerleft">
                                        <div class="eb2g_StandardFormat_title">
                                            Standard Format eBook:<br />
                                            <span class="book_style">Free Flow Text Layout</span><br />
                                            <br />
                                            Basic Packages includes
                                        </div>
                                        <div class="eb2g_StandardFormat_content">
                                            <table width="250" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <li>Conversion upto
                                                            <asp:Label ID="lblebookpcdpages" runat="server"></asp:Label>
                                                            pages</li>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <li>
                                                            <asp:Label ID="lblebookpcdimages" runat="server"></asp:Label>
                                                            images / Tables </li>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <li>
                                                            <asp:Label ID="lblebookpcdfootnotes" runat="server"></asp:Label>
                                                            Foot Notes/End Notes</li>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <li>
                                                            <asp:Label ID="lblebookpcdhplinks" runat="server"></asp:Label>
                                                            Hyperlinks </li>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <li>TOC Linking</li>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <li>QC Check </li>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="eb2g_StandardFormat_titleimg">
                                            <img src="../images/ebooksformating.png" alt="" /></div>
                                        <div class="eb2g_discountprice">
                                            <div class="blueclock">
                                                <div style="transform: rotate(0deg) scale(1, 1); display: block;" class="pendulum-parent">
                                                    <div class="ebooks_discount" align="center">
                                                        <b>Offers</b>
                                                        <ul>
                                                            <li>Select any '
                                                                <asp:Label ID="lblebookoffer1" runat="server"></asp:Label>
                                                                ' products get
                                                                <asp:Label ID="lblebookoffer1dis" runat="server"></asp:Label>
                                                                Discount on base price </li>
                                                            <li>Select any '
                                                                <asp:Label ID="lblebookoffer2" runat="server"></asp:Label>
                                                                ' products get
                                                                <asp:Label ID="lblebookoffer2dis" runat="server"></asp:Label>
                                                                Discount on base price</li></ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="eb2g_headerright">
                                        <div class="box-heading">
                                            Choose product(s)
                                        </div>
                                        <div class="box-content">
                                            <div class="eb2g_products">
                                                <div class="eb2g_products_details_eup">
                                                    <table>
                                                        <tr class="store_name">
                                                            <td width="93" rowspan="2" valign="middle">
                                                                <input type="checkbox" name="epub" id="epub2" />
                                                                <label for="epub2">
                                                                    <img src="../images/epub.png" alt="epub" /></label>
                                                            </td>
                                                            <td width="222">
                                                                <span class="product_details">Works on 90 percent of the devices available in the market.
                                                                    Doesn't work on Amazon devices.</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="productPrice">
                                                                $<asp:Label ID="lblebookepubprodcost" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div class="eb2g_products_details_mobi">
                                                    <table width="319">
                                                        <tr class="store_name">
                                                            <td style="padding-top: 8px;" width="93" rowspan="2">
                                                                <input type="checkbox" name="kindle" id="kindle" />
                                                                <label for="kindle">
                                                                    <img src="../images/kindle.png" width="511" height="511" alt="kindle" /></label>
                                                            </td>
                                                            <td width="214">
                                                                <span class="product_details">Works only with Amazon kindle fire devices.</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="productPrice">
                                                                $<asp:Label ID="lblebookkindleprodcost" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div class="eb2g_products_details_epdf">
                                                    <table>
                                                        <tr class="store_name">
                                                            <td width="93" rowspan="2">
                                                                <input type="checkbox" name="epdf" id="Checkbox1" />
                                                                <label for="epdf">
                                                                    <img src="../images/PDF.png" width="512" height="512" alt="epdf" /></label>
                                                            </td>
                                                            <td>
                                                                <span class="product_details">Works on 90 percent of the devices available in the market.
                                                                    Doesn't work on Amazon devices.</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="productPrice">
                                                                $<asp:Label ID="lblebookpdfprodcost" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                            <div class="eb2g_products_cost">
                                                <div class="eb2g_PackageCost">
                                                    Package Cost
                                                    <br />
                                                    <input type="text" id="Text1" />
                                                </div>
                                                <div class="eb2g_addtocart">
                                                    <a href="#">
                                                        <img src="../images/addtocart.jpg" alt="" />
                                                    </a>
                                                </div>
                                                <div class="eb2g_viewcart">
                                                    <a href="#">
                                                        <img src="../images/viewcart.jpg" alt="" />
                                                    </a>
                                                </div>
                                            </div>
                                            <br />
                                            <br class="clear" />
                                            ;
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    &nbsp;</div>
                                <hr>
                                <span class="Customizeyourproduct">
                                    <h3>
                                        Customize your product</h3>
                                </span>
                                <label>
                                </label>
                                <div class="Customize_pricing">
                                    <table width="1000" cellspacing="0" class="customize_products">
                                        <tr>
                                            <th>
                                                &nbsp;
                                            </th>
                                            <th align="center">
                                                Total Units
                                            </th>
                                            <th>
                                                Additional Units
                                            </th>
                                            <th>
                                                Unit Cost
                                            </th>
                                            <th>
                                                Additional Cost
                                            </th>
                                        </tr>
                                        <tr>
                                            <td width="490">
                                                <h4>
                                                    Total Number of pages in the Book</h4>
                                                <span class="Customize_totalnumber">Upto
                                                    <asp:Label ID="lblebookcustpcdpages" runat="server"></asp:Label>
                                                    pages are included in the base price.<br />
                                                    Additional pages will be billed at.
                                                    <asp:Label ID="lblebookperpagecost" runat="server"></asp:Label>
                                                    cents per page Please include front & back covers in the total page count</span>
                                            </td>
                                            <td width="100" align="center">
                                                <input type="text" id="price" value="" />
                                            </td>
                                            <td width="135" align="center">
                                                <label>
                                                    AU</label>
                                            </td>
                                            <td width="135" align="center">
                                                <label>
                                                    UC</label>
                                            </td>
                                            <td width="135" align="center">
                                                <label>
                                                    AC</label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="490">
                                                <h4>
                                                    Total Number of Images in the Book
                                                </h4>
                                                <span class="Customize_totalnumber">Upto
                                                    <asp:Label ID="lblebookcustpcdimages" runat="server"></asp:Label>
                                                    images are included in the Base price.
                                                    <br />
                                                    Additional images will be billed at $<asp:Label ID="lblebookperimagecost" runat="server"></asp:Label>
                                                    per images</span>
                                            </td>
                                            <td width="100" align="center">
                                                <input type="text" />
                                            </td>
                                            <td align="center">
                                            </td>
                                            <td align="center">
                                            </td>
                                            <td align="center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="490">
                                                <h4>
                                                    Total Number of Foot Notes & End Notes Linking
                                                </h4>
                                                <span class="Customize_totalnumber">Additional links will be billed at
                                                    <asp:Label ID="lblebookfootnotesandendnotescost" runat="server"></asp:Label>
                                                    cents per link</span>
                                            </td>
                                            <td width="100" align="center">
                                                <input type="text" />
                                            </td>
                                            <td align="center">
                                            </td>
                                            <td align="center">
                                            </td>
                                            <td align="center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="490">
                                                <h4>
                                                    Total Number of web links, Hyperlinks, email links etc
                                                </h4>
                                                <span class="Customize_totalnumber">Upto
                                                    <asp:Label ID="lblebookcustpcdhplinks" runat="server"></asp:Label>
                                                    links are included in the base price.
                                                    <br />
                                                    Additional Hyperlinks will be billed at
                                                    <asp:Label ID="lblebookweblinkscost" runat="server"></asp:Label>
                                                    cents per link</span>
                                            </td>
                                            <td width="100" align="center">
                                                <input type="text" />
                                            </td>
                                            <td align="center">
                                            </td>
                                            <td align="center">
                                            </td>
                                            <td align="center">
                                            </td>
                                        </tr>
                                    </table>
                                    <h3>
                                        Does Your Book contain any of the following elements</h3>
                                    <div class="Customize_Bookcontain_content">
                                        <span class="Customize_Bookcontain">When 2 to 4 elements are selected,it adds
                                            <asp:Label ID="lblebooktwotofourelementscost" runat="server"></asp:Label>
                                            to the bace cost,</span><br />
                                        <span class="Customize_Bookcontain">When 5 & Above elements are selected,it adds
                                            <asp:Label ID="lblebookfourpluselementscost" runat="server"></asp:Label>
                                            to the bace cost</span>
                                    </div>
                                    <div class="Customize_Bookcontain_total">
                                        <input type="text" />
                                    </div>
                                    <br />
                                    <table width="1000" cellspacing="0">
                                        <tr>
                                            <td width="350">
                                                <h4>
                                                    Nested TOC</h4>
                                            </td>
                                            <td width="150" align="center">
                                                <input type="checkbox" />
                                            </td>
                                            <td width="350">
                                                <h4>
                                                    Drop Caps</h4>
                                            </td>
                                            <td width="150" align="center">
                                                <input type="checkbox" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="350">
                                                <h4>
                                                    Colored Fonts</h4>
                                            </td>
                                            <td width="150" align="center">
                                                <input type="checkbox" />
                                            </td>
                                            <td width="350">
                                                <h4>
                                                    Lists</h4>
                                            </td>
                                            <td width="150" align="center">
                                                <input type="checkbox" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="350">
                                                <h4>
                                                    Multiple Sections and Sub-Sections</h4>
                                            </td>
                                            <td width="150" align="center">
                                                <input type="checkbox" />
                                            </td>
                                            <td width="350">
                                                <h4>
                                                    Call Outs</h4>
                                            </td>
                                            <td width="150" align="center">
                                                <input type="checkbox" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="350">
                                                <h4>
                                                    Double Column Text</h4>
                                            </td>
                                            <td width="150" align="center">
                                                <input type="checkbox" />
                                            </td>
                                            <td width="350">
                                                <h4>
                                                    Centered Text</h4>
                                            </td>
                                            <td width="150" align="center">
                                                <input type="checkbox" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="350">
                                                <h4>
                                                    Text boxes with borders/varying colors</h4>
                                            </td>
                                            <td width="150" align="center">
                                                <input type="checkbox" />
                                            </td>
                                            <td width="350">
                                                <h4>
                                                </h4>
                                            </td>
                                            <td width="150" align="center">
                                            </td>
                                        </tr>
                                    </table>
                                    <h3>
                                        Does Your Book Need Audio/Video Elements</h3>
                                    <table width="1000" cellspacing="0">
                                        <tr>
                                            <td width="450" valign="top">
                                                <h4>
                                                    Total Number of Audio/Video Elements in the book.
                                                    <img class="helpTip" title="Each Audio/Video file insert will be charged at the rate of $30.00.&#013; &#013; This feature is currently supported only on ePUB format.&#013; &#013; Epub files with Audio/Video elements are supported by Apple, Google Android, Sony and Kobo stores ant their devices."
                                                        src="../images/help2.png" width="32" height="32" alt="help" /></h4>
                                            </td>
                                            <td width="100" align="center">
                                                <input type="text" />
                                            </td>
                                            <td>
                                            </td>
                                            <td align="center">
                                                N/A
                                            </td>
                                            <td align="center">
                                                N/A
                                            </td>
                                        </tr>
                                    </table>
                                    <h3>
                                        Does your Book need Cover design?</h3>
                                    <table width="1000" cellspacing="0">
                                        <tr>
                                            <td width="468">
                                                <h4>
                                                    Simple Cover Design</h4>
                                            </td>
                                            <td width="171" align="left">
                                                <input type="radio" name="CoverDesign" />
                                            </td>
                                            <td colspan="3">
                                                <span class="store_format_isbn">$<asp:Label ID="lblebookscoverdesigncost" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="468">
                                                <h4>
                                                    High Impact Cover Design</h4>
                                            </td>
                                            <td width="171" align="left">
                                                <input type="radio" name="CoverDesign" />
                                            </td>
                                            <td colspan="3">
                                                <span class="store_format_isbn">$<asp:Label ID="lblebookhcoverdesigncost" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="468">
                                                <h4>
                                                    EISBN Cost
                                                </h4>
                                            </td>
                                            <td colspan="2" align="center">
                                                <span class="store_format">ePUB</span> <span class="store_format_checkbox">
                                                    <input type="checkbox" />
                                                </span><span class="store_format_isbn">$<asp:Label ID="lblebookepubprodisbncost"
                                                    runat="server"></asp:Label>
                                                </span>
                                            </td>
                                            <td width="154">
                                                <span class="store_format">Mobi</span> <span class="store_format_checkbox">
                                                    <input type="checkbox" />
                                                </span><span class="store_format_isbn">$<asp:Label ID="lblebookmobiprodisbncost"
                                                    runat="server"></asp:Label>
                                                </span>
                                            </td>
                                            <td width="154">
                                                <span class="store_format">Nook</span> <span class="store_format_checkbox">
                                                    <input type="checkbox" />
                                                </span><span class="store_format_isbn">$<asp:Label ID="lblebooknookprodisbncost"
                                                    runat="server"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                    </table>
                                    <h3>
                                        eBook Publishing, Distribution and Royalties</h3>
                                    <table width="1000" cellspacing="0">
                                        <tr>
                                            <td width="450" valign="top">
                                                <h4>
                                                    I will take care of the distribution myself</h4>
                                            </td>
                                            <td align="left">
                                                <input type="radio" name="CoverDesign" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="450">
                                                <h4>
                                                    I would like eBooks2go to be my distribution agent..
                                                    <img src="../images/PDFdownload.png" alt="view/download odf" width="24" /></h4>
                                            </td>
                                            <td align="left">
                                                <input type="radio" name="CoverDesign" />
                                            </td>
                                        </tr>
                                    </table>
                                    <h3>
                                        Marketing Services
                                    </h3>
                                    <table width="1000" cellspacing="0">
                                        <tr>
                                            <td width="450">
                                                <h4>
                                                    Social Media Setup</h4>
                                            </td>
                                            <td width="100" align="left">
                                                <input type="checkbox" />
                                            </td>
                                            <td align="center">
                                                <span class="store_format_isbn">$<asp:Label ID="lblebooksocialmediacost" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Press Release</h4>
                                            </td>
                                            <td align="left">
                                                <input type="checkbox" />
                                            </td>
                                            <td align="center">
                                                <span class="store_format_isbn">$<asp:Label ID="lblebookpressreleasecost" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Email Campaign</h4>
                                            </td>
                                            <td align="left">
                                                <input type="checkbox" />
                                            </td>
                                            <td align="center">
                                                <span class="store_format_isbn">$<asp:Label ID="lblebookemailcampaincost" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Website and Blog Promotion</h4>
                                            </td>
                                            <td align="left">
                                                <input type="checkbox" />
                                            </td>
                                            <td align="center">
                                                <span class="store_format_isbn">$<asp:Label ID="lblebookwebsiteblogpromotioncost"
                                                    runat="server"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Select all of marketing and get $<asp:Label ID="lblebookmarketingdiscount" runat="server"></asp:Label>
                                                    percent off</h4>
                                            </td>
                                            <td align="left">
                                                <input type="checkbox" />
                                            </td>
                                            <td align="center">
                                                <span class="store_format_isbn">$<asp:Label ID="lblmktamt" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <img src="../images/proceed.jpg" alt="proceed" width="117" height="30" align="right"
                                    onclick="confirmPay()" />
                            </div>
                            <table id="tabEbook" width="100%" border="1" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="5" scope="col">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="5">
                                            <tr>
                                                <td width="33%" valign="bottom">
                                                    <img src="../images/scart.png" width="50" height="40" alt="shoping cart" />CART
                                                    ID: <span style="color: #ff0000">xxxxxxxx</span>
                                                </td>
                                                <td width="67%" valign="bottom">
                                                    Product: <span class="productHold">eBook</span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="col">
                                        S.No
                                    </th>
                                    <th scope="col">
                                        Item
                                    </th>
                                    <th scope="col">
                                        Quantity
                                    </th>
                                    <th scope="col">
                                        Unit Cost (USD)
                                    </th>
                                    <th scope="col">
                                        Total Cost(USD)
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        1.
                                    </td>
                                    <td>
                                        ePUB
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        2.
                                    </td>
                                    <td>
                                        Mobi
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        3.
                                    </td>
                                    <td>
                                        ePDF
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        4.
                                    </td>
                                    <td class="eb2g_Additonaloption" colspan="4">
                                        Customizations
                                    </td>
                                </tr>
                                <tr>
                                    <td class="subHeads">
                                        a.
                                    </td>
                                    <td>
                                        Total Number of pages in the Book
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="subHeads">
                                        b.
                                    </td>
                                    <td>
                                        Total Number of Images in the Book
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="subHeads">
                                        c.
                                    </td>
                                    <td>
                                        Total Number of Foot Notes &amp; End Notes Linking
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="subHeads">
                                        d.
                                    </td>
                                    <td>
                                        Total Number of web links, Hyperlinks, email links
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        5.
                                    </td>
                                    <td colspan="4" class="eb2g_Additonaloption">
                                        Additional elements
                                    </td>
                                </tr>
                                <tr>
                                    <td class="subHeads">
                                        a.
                                    </td>
                                    <td>
                                        Nested TOC
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="subHeads">
                                        b.
                                    </td>
                                    <td>
                                        Drop Caps
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="subHeads">
                                        c.
                                    </td>
                                    <td>
                                        Colored Fonts
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="subHeads">
                                        d.
                                    </td>
                                    <td>
                                        Lists
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="subHeads">
                                        e.
                                    </td>
                                    <td>
                                        Multiple Sections and Sub-Sections
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="subHeads">
                                        f.
                                    </td>
                                    <td>
                                        Call Outs
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="subHeads">
                                        g.
                                    </td>
                                    <td>
                                        Double Column Text
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="subHeads">
                                        h.
                                    </td>
                                    <td>
                                        Centered Text
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="subHeads">
                                        i.
                                    </td>
                                    <td>
                                        Text boxes with borders/varying colors
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        6.
                                    </td>
                                    <td>
                                        audio &amp; Video elements
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        7.
                                    </td>
                                    <td>
                                        Cover design
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        8.
                                    </td>
                                    <td>
                                        EISBN
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        9.
                                    </td>
                                    <td>
                                        Book publishing &amp; Distribution
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        10.
                                    </td>
                                    <td>
                                        Marketing services
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="3" align="right">
                                        Total
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="3" align="right">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="3" align="right">
                                        Discount on Base package value @ 10% /20%...
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="right">
                                        Estimated product value
                                    </td>
                                    <td colspan="2" align="right">
                                        Total - discount
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" align="right">
                                        <img src="../images/btnBack.jpg" width="117" height="30" alt="edit" onclick="editPay();" />
                                        <img src="../images/checkout_btn.jpg" width="117" height="30" alt="check out" />
                                    </td>
                                </tr>
                            </table>
                        </div>--%>
                        <iframe src="../pricing/xebook.aspx" Width="1000px"  scrolling="no" frameborder="0" Height="2250px"></iframe>
                         <%--<div class="tabEbook" style="display:none;"> <iframe src="flupload.aspx" scrolling="no" height="1000px" width="1000px"></iframe></div>--%>
                    </asp:Panel>
                </ContentTemplate>
            </ajax:TabPanel>

            <ajax:TabPanel ID="tbpnlenhancedebook" runat="server">
                <HeaderTemplate>
                  <div class="test_tab" align="center">  Enhanced eBook </div>
                </HeaderTemplate>
                <ContentTemplate>
                <asp:Panel ID="pnlenhancedebook" runat="server">
                    <%--<div id="view2" runat="server" class="tabcontent default">
                        <div id="StandardeBookFormat">
                            <div class="eb2g_StandardFormateBook">
                                <div class="eb2g_headerleft">
                                    <div class="eb2g_StandardFormat_title">
                                        Enhanced eBook:<br />
                                        <span class="book_style">Fixed Format Text Layout</span><br />
                                        <br />
                                        Basic Packages includes
                                    </div>
                                    <div class="eb2g_StandardFormat_content">
                                        <table width="250" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <li>Up to 50 pages</li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>10 Hyperlinks </li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>TOC Linking</li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li>QC Check </li>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="eb2g_StandardFormat_titleimg">
                                        <img src="../images/EnhancedeBookformating.png" alt="" /></div>
                                    <div class="eb2g_discountprice">
                                        <div class="blueclock">
                                            <div style="transform: rotate(0deg) scale(1, 1); display: block;" class="pendulum-parent">
                                                <div class="ebooks_discount" align="center">
                                                    <b>Offers</b>
                                                    <ul>
                                                        <li>Select any ' 2 ' products get 10% Discount on base price </li>
                                                        <li>Select any ' 3 ' products get 20% Discount on base price</li></ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="eb2g_headerright">
                                    <div class="box-heading">
                                        Choose product(s)
                                    </div>
                                    <div class="box-content">
                                        <div class="eb2g_products">
                                            <div class="eb2g_products_details_eup">
                                                <table>
                                                    <tr class="store_name">
                                                        <td width="93" rowspan="2" valign="middle">
                                                            <input type="checkbox" name="epub" id="epub3" />
                                                            <label for="epub3">
                                                                <img style="margin-top: 8px;" src="../images/epub3.png" alt="epub" /></label>
                                                        </td>
                                                        <td width="222">
                                                            <span class="product_details">Apple and Android supported devices such as Samsung, Lenovo,
                                                                Kobo & Sony</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" class="productPrice">
                                                            $249.00
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="eb2g_products_details_mobi">
                                                <table width="319">
                                                    <tr class="store_name">
                                                        <td style="padding-top: 8px;" width="93" rowspan="2">
                                                            <input type="checkbox" name="kindle" id="kindle2" />
                                                            <label for="kindle2">
                                                                <img src="../images/kindle.png" width="511" height="511" alt="kindle" /></label>
                                                        </td>
                                                        <td width="214">
                                                            <span class="product_details">Works only with Amazon kindle fire devices.</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" class="productPrice">
                                                            $249.00
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="eb2g_products_details_epdf">
                                                <table width="100%">
                                                    <tr class="store_name">
                                                        <td width="93" rowspan="2">
                                                            <input type="checkbox" name="nook" id="nook" />
                                                            <label for="nook">
                                                                <img style="margin-top: 10px;" src="../images/nook.png" width="150" height="150"
                                                                    alt="epdf" /></label>
                                                        </td>
                                                        <td>
                                                            <span class="product_details">Works only with Nook devices.</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" class="productPrice">
                                                            $249.00
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                        <div class="eb2g_products_cost">
                                            <div class="eb2g_PackageCost">
                                                Package Cost
                                                <br />
                                                <input type="text" id="totalamount" />
                                            </div>
                                            <div class="eb2g_addtocart">
                                                <a href="#">
                                                    <img src="../images/addtocart.jpg" alt="" />
                                                </a>
                                            </div>
                                            <div class="eb2g_viewcart">
                                                <a href="#">
                                                    <img src="../images/viewcart.jpg" alt="" />
                                                </a>
                                            </div>
                                        </div>
                                        <br />
                                        <br class="clear" />
                                        ;
                                    </div>
                                </div>
                            </div>
                            <div>
                                &nbsp;</div>
                            <p>
                            </p>
                            <hr>
                            <span class="Customizeyourproduct">
                                <h3>
                                    Customize your product</h3>
                                <p>
                                    &nbsp;
                                </p>
                            </span>
                            <div class="Customize_pricing">
                                <table width="1000" cellspacing="0" class="customize_products">
                                    <td width="490">
                                        <h4>
                                            Total Number of pages in the Book</h4>
                                        <span class="Customize_totalnumber">Upto 50 pages are included in the base price.
                                            <br />
                                            Additional pages will be billed at $5.0 per page Please include front & back covers
                                            in the total page count</span>
                                    </td>
                                    <td width="100" align="center">
                                        <input type="text" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    </tr>
                                    <tr>
                                        <td width="490">
                                            <h4>
                                                Total Number of web links, Hyperlinks, email links etc</h4>
                                            <span class="Customize_totalnumber">Upto 10 links are included in the base price.
                                                <br />
                                                Additional Hyperlinks will be billed at .50 cents per link</span>
                                        </td>
                                        <td width="100" align="center">
                                            <input type="text" />
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="490">
                                            <h4>
                                                EISBN Cost
                                            </h4>
                                        </td>
                                        <td width="100" align="center">
                                        </td>
                                        <td width="135">
                                            <span class="store_format">ePUB</span> <span class="store_format_checkbox">
                                                <input type="checkbox" />
                                            </span><span class="store_format_isbn">$9.99</span>
                                        </td>
                                        <td width="135">
                                            <span class="store_format">Mobi</span> <span class="store_format_checkbox">
                                                <input type="checkbox" />
                                            </span><span class="store_format_isbn">$9.99</span>
                                        </td>
                                        <td width="135">
                                            <span class="store_format">Nook</span> <span class="store_format_checkbox">
                                                <input type="checkbox" />
                                            </span><span class="store_format_isbn">$9.99</span>
                                        </td>
                                    </tr>
                                </table>
                                <h3>
                                    Does Your Book contain any of the following elements</h3>
                                <div class="Customize_Bookcontain_content">
                                    <span class="Customize_Bookcontain">When 2 to 4 elements are selected,it adds 30% to
                                        the bace cost,</span><br />
                                    <span class="Customize_Bookcontain">When 5 & Above elements are selected,it adds 50%
                                        to the bace cost</span>
                                </div>
                                <div class="Customize_Bookcontain_total">
                                    <input type="text" />
                                </div>
                                <table width="1000" cellspacing="0">
                                    <tr>
                                        <td width="350">
                                            <h4>
                                                Nested TOC</h4>
                                        </td>
                                        <td width="150" align="center">
                                            <input type="checkbox" />
                                        </td>
                                        <td width="350">
                                            <h4>
                                                Drop Caps</h4>
                                        </td>
                                        <td width="150" align="center">
                                            <input type="checkbox" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="350">
                                            <h4>
                                                Colored Fonts</h4>
                                        </td>
                                        <td width="150" align="center">
                                            <input type="checkbox" />
                                        </td>
                                        <td width="350">
                                            <h4>
                                                Lists</h4>
                                        </td>
                                        <td width="150" align="center">
                                            <input type="checkbox" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="350">
                                            <h4>
                                                Multiple Sections and Sub-Sections</h4>
                                        </td>
                                        <td width="150" align="center">
                                            <input type="checkbox" />
                                        </td>
                                        <td width="350">
                                            <h4>
                                                Call Outs</h4>
                                        </td>
                                        <td width="150" align="center">
                                            <input type="checkbox" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="350">
                                            <h4>
                                                Double Column Text</h4>
                                        </td>
                                        <td width="150" align="center">
                                            <input type="checkbox" />
                                        </td>
                                        <td width="350">
                                            <h4>
                                                Centered Text</h4>
                                        </td>
                                        <td width="150" align="center">
                                            <input type="checkbox" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="350">
                                            <h4>
                                                Text boxes with borders/varying colors</h4>
                                        </td>
                                        <td width="150" align="center">
                                            <input type="checkbox" />
                                        </td>
                                        <td width="350">
                                            <h4>
                                            </h4>
                                        </td>
                                        <td width="150" align="center">
                                        </td>
                                    </tr>
                                </table>
                                <h3>
                                    Does Your Book Need Audio/Video Elements</h3>
                                <table width="1000" cellspacing="0">
                                    <tr>
                                        <td width="450" valign="top">
                                            <h4>
                                                Total Number of Audio/Video Elements in the book
                                                <img class="helpTip" title="Each Audio/Video file insert will be charged at the rate of $30.00.&#013; &#013; This feature is currently supported only on ePUB format.&#013; &#013; Epub files with Audio/Video elements are supported by Apple, Google Android, Sony and Kobo stores ant their devices."
                                                    src="../images/help2.png" width="32" height="32" alt="help" /></h4>
                                        </td>
                                        <td width="100" align="center">
                                            <input type="text" />
                                        </td>
                                        <td>
                                        </td>
                                        <td align="center">
                                            N/A
                                        </td>
                                        <td align="center">
                                            N/A
                                        </td>
                                    </tr>
                                </table>
                                <h3>
                                    Does your book need Read Aloud with Text High light</h3>
                                <table width="1000" cellspacing="0">
                                    <tr>
                                        <td width="450" valign="top">
                                            <h4>
                                                Total Number of words requiring Text High Lights
                                                <img class="helpTip" title="Total number of words requiring Text Highlite will be charged @ 10 cents."
                                                    src="../images/help2.png" width="32" height="32" alt="help" /></h4>
                                        </td>
                                        <td width="100" align="center">
                                            <input type="text" />
                                        </td>
                                        <td>
                                        </td>
                                        <td align="center">
                                            N/A
                                        </td>
                                        <td align="center">
                                            N/A
                                        </td>
                                    </tr>
                                </table>
                                <h3>
                                    Does your Book need Cover design?</h3>
                                <table width="1000" cellspacing="0">
                                    <tr>
                                        <td width="450">
                                            <h4>
                                                Simple Cover Design</h4>
                                        </td>
                                        <td width="100" align="left">
                                            <input type="radio" name="CoverDesign" />
                                        </td>
                                        <td>
                                            <span class="store_format_isbn">$149.00</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="450">
                                            <h4>
                                                High Impact Cover Design</h4>
                                        </td>
                                        <td width="100" align="left">
                                            <input type="radio" name="CoverDesign" />
                                        </td>
                                        <td>
                                            <span class="store_format_isbn">$249.00</span>
                                        </td>
                                    </tr>
                                </table>
                                <h3>
                                    eBook Publishing, Distribution and Royalties</h3>
                                <table width="1000" cellspacing="0">
                                    <tr>
                                        <td width="450" valign="top">
                                            <h4>
                                                I will take care of the distribution myself</h4>
                                        </td>
                                        <td align="left" valign="top">
                                            <input type="radio" name="CoverDesign" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="450" valign="top">
                                            <h4>
                                                I would like eBooks2go to be my distribution agent</h4>
                                        </td>
                                        <td align="left" valign="top">
                                            <input type="radio" name="CoverDesign" />
                                        </td>
                                    </tr>
                                </table>
                                <h3>
                                    Marketing Services
                                </h3>
                                <table width="1000" cellspacing="0">
                                    <tr>
                                        <td width="450">
                                            <h4>
                                                Social Media Setup</h4>
                                        </td>
                                        <td width="100" align="left">
                                            <input type="checkbox" />
                                        </td>
                                        <td align="center">
                                            <span class="store_format_isbn">$250.00</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4>
                                                Press Release</h4>
                                        </td>
                                        <td align="left">
                                            <input type="checkbox" />
                                        </td>
                                        <td align="center">
                                            <span class="store_format_isbn">$250.00</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4>
                                                Email Campaign</h4>
                                        </td>
                                        <td align="left">
                                            <input type="checkbox" />
                                        </td>
                                        <td align="center">
                                            <span class="store_format_isbn">$250.00</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4>
                                                Website and Blog Promotion</h4>
                                        </td>
                                        <td align="left">
                                            <input type="checkbox" />
                                        </td>
                                        <td align="center">
                                            <span class="store_format_isbn">$250.00</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4>
                                                Select all of marketing and get 30 percent off</h4>
                                        </td>
                                        <td align="left">
                                            <input type="checkbox" />
                                        </td>
                                        <td align="center">
                                            <span class="store_format_isbn">$700.00</span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <img src="../images/proceed.jpg" alt="proceed" width="117" height="30" align="right" />
                    </div>--%>
                    <iframe src="../pricing/xenhancedebook.aspx" Width="1000px" style=" margin-left:0px;" scrolling="no" frameborder="0" Height="2250px"></iframe>
                    </asp:Panel>
                </ContentTemplate>
            </ajax:TabPanel>

            <ajax:TabPanel ID="tabpnlebookapps" runat="server">
                <HeaderTemplate>
                  <div class="test_tab" align="center">  eBook Apps </div>
                </HeaderTemplate>
                <ContentTemplate>
                    <iframe src ="ebookapps/newebookapps.aspx" Width="1000px" style=" margin-left:0px;" scrolling="no" frameborder="0" Height="2250px"></iframe>
                    </ContentTemplate>
            </ajax:TabPanel>

             <ajax:TabPanel ID="tabpnlsalesanddistribution" runat="server">
                <HeaderTemplate>
                 <div class="test_tab" align="center">  Sales & Distribution </div>
                </HeaderTemplate>
                <ContentTemplate>
                    <iframe src ="ebookapps/ebookapps.aspx" Width="1000px" style=" margin-left:0px;" scrolling="no" frameborder="0" Height="2250px"></iframe>
                    </ContentTemplate>
            </ajax:TabPanel>

             <ajax:TabPanel ID="tabpnlmarketing" runat="server">
                <HeaderTemplate>
                  <div class="test_tab" align="center"> Marketing </div>
                </HeaderTemplate>
                <ContentTemplate>
                    <iframe src ="ebookapps/ebookapps.aspx" Width="1000px" style=" margin-left:0px;" scrolling="no" frameborder="0" Height="2250px"></iframe>
                    </ContentTemplate>
            </ajax:TabPanel>
        </ajax:TabContainer>

    </div>
    </form>
</body>

</html>
