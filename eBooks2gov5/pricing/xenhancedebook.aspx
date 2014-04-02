<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xenhancedebook.aspx.cs" Inherits="eBooks2goV5.pricing.xenhancedebook" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>Ajax Tab Container</title>
    <%-- Tab Container Css Begin--%>
    <style type="text/css">
        .fancy-green .ajax__tab_header
        {
            background: url(../green_bg_Tab.gif) repeat-x;
            cursor: pointer;
        }
        .fancy-green .ajax__tab_hover .ajax__tab_outer, .fancy-green .ajax__tab_active .ajax__tab_outer
        {
            background: url(../green_left_Tab.gif) no-repeat left top;
        }
        .fancy-green .ajax__tab_hover .ajax__tab_inner, .fancy-green .ajax__tab_active .ajax__tab_inner
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
            height: 46px;
        }
        .fancy .ajax__tab_active .ajax__tab_inner, .fancy .ajax__tab_header .ajax__tab_inner, .fancy .ajax__tab_hover .ajax__tab_inner
        {
            height: 46px;
            margin-left: 16px; /* offset the width of the left image */
        }
        .fancy .ajax__tab_active .ajax__tab_tab, .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_header .ajax__tab_tab
        {
            margin: 16px 16px 0px 0px;
        }
        .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_active .ajax__tab_tab
        {
            color: #fff;
        }
        .fancy .ajax__tab_body
        {
            font-family: Arial;
            font-size: 10pt;
            border-top: 0;
            border: 1px solid #999999;
            padding: 8px;
            background-color: #ffffff;
        }
        .eb2g_test
        {
            width: 1000px;
            margin: auto;
        }
    </style>
    <%-- Tab Container Css End--%>
    <%--eBooks2go css begin--%>
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
            src: url(../DroidSans.ttf) format("truetype");
        }
        @font-face
        {
            font-family: "Trebuchet MS";
            src: url(../trebuc.ttf) format("truetype");
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
         .hdnisdollar {
            display:none;
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
            font-size:13px;
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
       <script type='text/javascript' src='https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js'></script>
</head>

<body>
    <form id="form1" runat="server" autocomplete="off">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
    <div id="view2" runat="server" class="tabcontent default">
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
                                                    <li>Up to <asp:Label ID="lblenhancedebookpcdpages" runat="server"></asp:Label> pages</li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <li><asp:Label ID = "lblenhancedebookpcdhplinks" runat="server"></asp:Label> Hyperlinks </li>
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
                                                        <li>Select any ' <asp:Label ID="lblenhancedebookoffer1" class="offer1"  runat="server"></asp:Label> ' products get <asp:Label ID ="lblenhancedebookoffer1dis" class="offer1discount" runat="server"></asp:Label> Discount on base price </li>
                                                        <li>Select any ' <asp:Label ID = "lblenhancedebookoffer2" class="offer2" runat="server"></asp:Label> ' products get <asp:Label ID="lblenhancedebookoffer2dis"  class="offer2discount" runat="server"></asp:Label> Discount on base price</li></ul>
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
                                         <asp:Panel ID="pnlEnhancedeBookproducts" runat="server">
                                        <div class="eb2g_products">
                                            <div class="eb2g_products_details_eup">
                                                <table class="products">
                                                    <tr class="store_name">
                                                        <td width="93" rowspan="2" valign="middle">
                                                           <asp:CheckBox ID ="chkEnhancedeBookepub3" class="checkboxproduct" runat="server" />
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
                                                            $<asp:Label ID = "lblenhancedebookepub3prodcost" class="pprice" runat = "server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="eb2g_products_details_mobi">
                                                <table width="319" class="products">
                                                    <tr class="store_name">
                                                        <td style="padding-top: 8px;" width="93" rowspan="2">
                                                            <asp:CheckBox ID ="chkEnhancedeBookkindle" class="checkboxproduct" runat="server"  />
                                                            <label for="kindle2">
                                                                <img src="../images/kindle.png" width="511" height="511" alt="kindle" /></label>
                                                        </td>
                                                        <td width="214">
                                                            <span class="product_details">Works only with Amazon kindle fire devices.</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" class="productPrice">
                                                            $<asp:Label ID = "lblenhancedebookkindleprodcost" class="pprice" runat = "server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="eb2g_products_details_epdf">
                                                <table width="100%" class="products">
                                                    <tr class="store_name">
                                                        <td width="93" rowspan="2">
                                                            <asp:CheckBox ID="chkEnhancedeBooknook" class="checkboxproduct" runat="server"  />
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
                                                            $<asp:Label ID = "lblenhancedebooknookprodcost" class="pprice" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                             </asp:Panel>
                                        <div class="eb2g_products_cost">
                                            <div class="eb2g_PackageCost">
                                                Package Cost
                                                <br />
                                                <asp:TextBox ID="txtEnhancedeBookcartprice" class="totalpackagecost" runat="server"   ></asp:TextBox>
                                                <asp:TextBox ID="txtEnhanceeBookhdnPckCst" class="totalpackagecost" style="display:none;"  runat="server"></asp:TextBox>
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
                            <div style="width:970px; float:left; height:50px;">
                                &nbsp;</div>
                            <hr>
                            <span class="Customizeyourproduct">
                                <h3>
                                    Customize your product</h3>
                             
                            </span>
                            <div class="Customize_pricing">
                                <table width="1000" cellspacing="0" class="customize_products">
                                    <tr>
                                    <td width="490">
                                        <h4>
                                            Total Number of pages in the Book</h4>
                                           <asp:Label runat="server" class="hdnisdollar">1</asp:Label>
                                        <span class="Customize_totalnumber">Upto <asp:Label ID = "lblenhancedebookcustpcdpages" class="Custdefault" runat = "server"></asp:Label> pages are included in the base price.
                                            <br />
                                            &nbsp;&nbsp;&nbsp;Additional pages will be billed at $<asp:Label ID = "lblenhancedebookperpagecost" class="Custcost" runat = "server"></asp:Label> per page Please include front &<br />&nbsp;&nbsp;&nbsp;back covers
                                            in the total page count</span>
                                    </td>
                                    <td width="100" align="center">
                                       <asp:TextBox ID="txtEnhancedeBookcustpcdpages" runat="server" class="Custqty"></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="fteEnhancedebookcustpcdpages" runat="server" FilterType="Numbers"
    TargetControlID="txtEnhancedeBookcustpcdpages" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEnhancedeBookpageadditionalpages" class="Custadditional" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEnhancedeBookpageadditionalunit" class="Custadditionalunitcost" runat="server"></asp:Label>
                                        <asp:TextBox ID="hdnEnhancedeBookpageadditionalunit" style="display:none;" class="Custadditionalunitcost" runat="server"/>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEnhancedeBookpageadditionalunitscost" class="Custadditionaltotalcost" runat="server"></asp:Label>
                                        <asp:TextBox ID="hdnEnhancedeBookpageadditionalunitscost" style="display:none;" class="Custadditionaltotalcost" runat="server"/>
                                    </td>
                                    </tr>
                                    <tr>
                                        <td width="490">
                                            <h4>
                                                Total Number of web links, Hyperlinks, email links etc</h4>
                                            <asp:Label  runat="server" class="hdnisdollar">0</asp:Label>
                                            <span class="Customize_totalnumber">Upto <asp:Label ID ="lblenhancedebookcustpcdhplinks" class="Custdefault" runat="server"></asp:Label> links are included in the base price.
                                                <br />
                                                &nbsp;&nbsp;&nbsp;Additional Hyperlinks will be billed at <asp:Label ID ="lblenhancedebookweblinkscost" class="Custcost" runat="server"></asp:Label> cents per link</span>
                                        </td>
                                        <td width="100" align="center">
                                            <asp:TextBox ID="txtEnhancedeBookcustpcdhplinks" runat="server" class="Custqty"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="fteEnhancedeBookcustpcdhplinks" runat="server" FilterType="Numbers"
    TargetControlID="txtEnhancedeBookcustpcdhplinks" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblEnhancedeBooklinksadditionallinks"  class="Custadditional"  runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblEnhancedeBooklinksadditionalunits" class="Custadditionalunitcost" runat="server"></asp:Label>
                                             <asp:TextBox ID="hdnEnhancedeBooklinksadditionalunits" style="display:none;" class="Custadditionalunitcost" runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblEnhancedeBooklinksadditionalunitscost"  class="Custadditionaltotalcost" runat="server"></asp:Label>
                                             <asp:TextBox ID="hdnEnhancedeBooklinksadditionalunitscost" style="display:none;" class="Custadditionaltotalcost" runat="server"/>

                                        </td>
                                    </tr>
                                    <asp:Panel ID="pnlEnhancedeBookisbn" runat="server">
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
                                                <asp:CheckBox ID="chkEnhancedeBookisbnepub" runat="server" class="ebookisbn" />
                                            </span><span class="store_format_isbn">$<asp:Label ID = "lblenhancedebookepubeisbncost" runat="server" class="isbncost"></asp:Label></span>
                                        </td>
                                        <td width="135">
                                            <span class="store_format">Mobi</span> <span class="store_format_checkbox">
                                                 <asp:CheckBox ID="chkEnhancedeBookisbnmobi" runat="server" class="ebookisbn" />
                                            </span><span class="store_format_isbn">$<asp:Label ID = "lblenhancedebookmobieisbncost" class="isbncost" runat="server"></asp:Label></span>
                                        </td>
                                        <td width="135">
                                            <span class="store_format">Nook</span> <span class="store_format_checkbox">
                                                <asp:CheckBox ID="chkEnhancedeBookisbnnook" runat="server" class="ebookisbn" />
                                            </span><span class="store_format_isbn">$<asp:Label ID ="lblenhancedebooknookeisbncost" class="isbncost" runat="server"></asp:Label></span>
                                        </td>
                                    </tr>
                                        </asp:Panel>
                                </table>
                                <h3>
                                   
                                    Does Your Book contain any of the following elements</h3>
                                <div class="Customize_Bookcontain_content">
                                    <span class="Customize_Bookcontain">When 2 to 4 elements are selected,it adds <asp:Label ID = "lblenhancedebooktwotofourelementscost" class="twoelementcost" runat = "server"></asp:Label> to
                                        the bace cost,</span><br />
                                    <span class="Customize_Bookcontain">When 5 & Above elements are selected,it adds <asp:Label ID ="lblenhancedebookfourpluselementscost" class="fourelementcost" runat="server"></asp:Label>
                                        to the bace cost</span>
                                </div>
                                <div class="Customize_Bookcontain_total">
                                    <asp:TextBox ID="txtEnhancedeBookbaseprice" class="basecost" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                
                                <table width="1000" cellspacing="0" class="tblenhancedelements">
                                     <asp:Panel ID="pnlEnhancedeBookelements" runat="server">
                                    <tr>
                                        <td width="350">
                                            <h4>
                                                Nested TOC</h4>
                                        </td>
                                        <td width="150" align="center">
                                            <asp:CheckBox ID="chkEnhancedeBooknestedtoc" runat="server"  class="elements"/>
                                        </td>
                                        <td width="350">
                                            <h4>
                                                Drop Caps</h4>
                                        </td>
                                        <td width="150" align="center">
                                            <asp:CheckBox ID="chkEnhancedeBookdropcaps" runat="server" class="elements" />
                                        
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="350">
                                            <h4>
                                                Colored Fonts</h4>
                                        </td>
                                        <td width="150" align="center">
                                            <asp:CheckBox ID="chkEnhancedeBookcoloredfonts" runat="server" class="elements" />
                                        
                                        </td>
                                        <td width="350">
                                            <h4>
                                                Lists</h4>
                                        </td>
                                        <td width="150" align="center">
                                            <asp:CheckBox ID="chkEnhancedeBooklists" runat="server" class="elements" />
                                        
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="350">
                                            <h4>
                                                Multiple Sections and Sub-Sections</h4>
                                        </td>
                                        <td width="150" align="center">
                                            <asp:CheckBox ID="chkEnhancedeBooksections" runat="server" class="elements" />
                                        </td>
                                        <td width="350">
                                            <h4>
                                                Call Outs</h4>
                                        </td>
                                        <td width="150" align="center">
                                            <asp:CheckBox ID="chkEnhancedeBookcallouts" runat="server" class="elements" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="350">
                                            <h4>
                                                Double Column Text</h4>
                                        </td>
                                        <td width="150" align="center">
                                            <asp:CheckBox ID="chkEnhancedeBookdoublecolumntext" runat="server" class="elements" />
                                        </td>
                                        <td width="350">
                                            <h4>
                                                Centered Text</h4>
                                        </td>
                                        <td width="150" align="center">
                                            <asp:CheckBox ID="chkEnhancedeBookcenteredtext" runat="server" class="elements" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="350">
                                            <h4>
                                                Text boxes with borders/varying colors</h4>
                                        </td>
                                        <td width="150" align="center">
                                            <asp:CheckBox ID="chkEnhancedeBookbvcolors" runat="server" class="elements" />
                                        </td>
                                        <td width="350">
                                            <h4>
                                            </h4>
                                        </td>
                                        <td width="150" align="center">
                                        </td>
                                    </tr>
                                          </asp:Panel>
                                </table>
                                <h3>
                                    Does Your Book Need Audio/Video Elements</h3>
                                <table width="1000" cellspacing="0">
                                    <tr>
                                        <td width="450" valign="top">
                                            <h4>
                                                Total Number of Audio/Video Elements in the book
                                                <img class="helpTip"  id="imgEnhancedeBookAVelement"  
                                                        src="../images/help2.png" width="32" runat="server" height="32" alt="help" />
                                        <asp:HiddenField ID="hdnEnhancedavelementcost" runat="server" />
                                            </h4>
                                        </td>
                                        <td width="100" align="center">
                              
                                            <asp:TextBox ID ="txtEnhancedeBookavcost" runat="server" class="avqty"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="fteEnhancedeBookeachavcost" runat="server" FilterType="Numbers"
    TargetControlID="txtEnhancedeBookavcost" />
                                        </td>
                                        
                                        <td align="center">
                                           <asp:Label ID="lblEnhancedeBookavunitcost" class="avunitcost" runat="server"></asp:Label>
                                            <asp:TextBox ID="hdnEnhancedeBookavunitcost" class="avunitcost" style="display:none;" runat="server"/>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblEnhancedeBookavtotalcost" class="avtotalcost" runat="server"></asp:Label>
                                            <asp:TextBox ID="hdnEnhancedeBookavtotalcost" class="avtotalcost" style="display:none;"  runat="server"/>
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
                                               <img class="helpTip"  id="imgEnhancedeBookReadaloud"  
                                                        src="../images/help2.png" width="32" runat="server" height="32" alt="help" />
                                        <asp:HiddenField ID="hdnEnhancedReadaloudcost"  runat="server" />
                                            </h4>
                                        </td>
                                        <td width="100" align="center">
                                            <asp:TextBox ID ="txtEnhancedeBookReadaloud" runat="server"  class="txthavqty"></asp:TextBox>
                                             <ajax:FilteredTextBoxExtender ID="fteEnhancedeBookReadaloud" runat="server" FilterType="Numbers"
    TargetControlID="txtEnhancedeBookReadaloud" />
                                        </td>
                                       
                                        <td align="center">
                                           <asp:Label ID="lblEnhancedeBookReadaloudunitcost" runat="server" class="havunitcost"></asp:Label>
                                            <asp:TextBox ID="hdnEnhancedeBookReadaloudunitcost" style="display:none;" class="havunitcost" runat="server"/>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblEnhancedeBookReadaloudtotalcost" runat="server" class="havtotalcost"></asp:Label>
                                             <asp:TextBox ID="hdnEnhancedeBookReadaloudtotalcost" style="display:none;" class="havtotalcost" runat="server"/>
                                        </td>
                                    </tr>
                                </table>
                                <h3>
                                    Does your Book need Cover design?</h3>
                                <table width="1000" cellspacing="0" class="tblcover">
                                    <tr>
                                        <td width="450">
                                            <h4>
                                                Simple Cover Design</h4>
                                        </td>
                                        <td width="100" align="left">
                                            <asp:RadioButton ID="rbEnhancedeBookSimpleDesign" runat="server"  value="simple"     GroupName="CoverDesign"/>
                                        </td>
                                        <td>
                                            <span class="store_format_isbn">$<asp:Label ID ="lblenhancedebookscoverdesigncost" class="covercost" runat = "server"></asp:Label></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="450">
                                            <h4>
                                                High Impact Cover Design</h4>
                                        </td>
                                        <td width="100" align="left">
                                           <asp:RadioButton ID="rbEnhancedeBookHIDesign" runat="server" value="complex"   GroupName="CoverDesign"   />
                                        </td>
                                        <td>
                                            <span class="store_format_isbn">$<asp:Label ID ="lblenhancedebookhcoverdesigncost" class="covercost"  runat="server"></asp:Label></span>
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
                                           <asp:RadioButton ID="rbEnhancedeBookdistmyself" runat="server"  Checked="true" GroupName="EnhancedeBookdistribution" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="450" valign="top">
                                            <h4>
                                                I would like eBooks2go to be my distribution agent</h4>
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:RadioButton ID="rbEnhancedeBookdistagent" runat="server" GroupName="EnhancedeBookdistribution"  />
                                        </td>
                                    </tr>
                                </table>
                                <h3>
                                    Marketing Services
                                </h3>
                                <asp:Panel ID="pnlEnhancedeBookmarketingservices" runat="server">
                                <table width="1000" cellspacing="0" class="ebookmarket">
                                    <tr>
                                        <td width="450">
                                            <h4>
                                                Social Media Setup</h4>
                                        </td>
                                        <td width="100" align="left">
                                           <asp:CheckBox ID="chkEnhancedeBooksocialmediasetup" runat="server" class="market"/>
                                        </td>
                                        <td align="center">
                                            <span class="store_format_isbn">$<asp:Label ID ="lblenhancedebooksocialmediacost"   class="marketcost" runat="server"></asp:Label></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4>
                                                Press Release</h4>
                                        </td>
                                        <td align="left">
                                           <asp:CheckBox ID="chkEnhancedeBookpressrelease" runat="server" class="market" />
                                        </td>
                                        <td align="center">
                                            <span class="store_format_isbn">$<asp:Label ID ="lblenhancedebookpressreleasecost"  class="marketcost" runat="server"></asp:Label></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4>
                                                Email Campaign</h4>
                                        </td>
                                        <td align="left">
                                           <asp:CheckBox ID="chkEnhancedeBookemailcampaign" runat="server" class="market"/>
                                        </td>
                                        <td align="center">
                                            <span class="store_format_isbn">$<asp:Label ID ="lblenhancedebookemailcampaincost"  class="marketcost" runat="server"></asp:Label></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4>
                                                Website and Blog Promotion</h4>
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="chkEnhancedeBookwebsitepromotion" runat="server" class="market" />
                                        </td>
                                        <td align="center">
                                            <span class="store_format_isbn">$<asp:Label ID = "lblenhancedebookwebsiteblogpromotioncost"  class="marketcost" runat="server"></asp:Label></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4>
                                                Select all of marketing and get <asp:Label ID ="lblenhancedebookmarketingdiscount" runat = "server"></asp:Label> percent off</h4>
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="chkEnhancedeBookmarketing" runat="server" class="market" />
                                        </td>
                                        <td align="center">
                                            <span class="store_format_isbn">$<asp:Label ID="lblmktamt"  class="marketcost" runat="server"></asp:Label></span>
                                        </td>
                                    </tr>
                                </table>
                                    </asp:Panel>
                            </div>
                        </div>
                        
                    <asp:ImageButton ID="imgbtnproceed" ImageUrl="../images/proceed.jpg" ImageAlign="Right"   OnClick="imgbtnproceed_Click" runat="server" />
                    </div>
    </div>


           <script>
               function productcost() {
                   var totproductcost = 0;
                   var count = productcount();
                   $('.products tr').each(function (i, row) {

                       // reference all the stuff you need first
                       var $row = $(row);
                       //Custdefault = $row.find('.Custdefault').html();
                       rowcheckbox = $row.find('input:checked');
                       if (rowcheckbox.is(':checked')) {
                           totproductcost = parseFloat(totproductcost) + parseFloat($row.next().find('.pprice').html());
                       }

                   });
                   if (totproductcost > 0) {
                       if (count == parseInt($('.offer1').html()) && count < parseInt($('.offer2').html())) {
                           totproductcost = totproductcost * ((100 - parseFloat($('.offer1discount').html())) / 100);

                       }
                       else if (count >= parseInt($('.offer2').html())) {
                           totproductcost = totproductcost * ((100 - parseFloat($('.offer2discount').html())) / 100);

                       }
                       return totproductcost;
                   }
                   else {
                       return totproductcost;
                   }
               }
        </script>
        
         <script>
             function productcount() {
                 var i = 0;
                 $("#pnlEnhancedeBookproducts input:checked").each(function () {
                     i++;
                 });
                 return i;
             }
        </script>

         <script>


             $(".checkboxproduct").change(function () {
                 costcalculation();
                
             });  //run through each row



        </script>
          <script>
              function elementcostbaseprice(baseprice) {
                  var elementcount = getelementcount();
                  if (parseInt(elementcount) == parseInt(2) || parseInt(elementcount) == parseInt(3) || parseInt(elementcount) == parseInt(4)) {
                      baseprice = (parseFloat(baseprice) * (100 + parseFloat($('.twoelementcost').html().replace('%', ''))) / 100)
                      return baseprice;
                  }
                  else if (parseInt(elementcount) >= parseInt(5)) {
                      baseprice = (parseFloat(baseprice) * (100 + parseFloat($('.fourelementcost').html().replace('%', ''))) / 100);
                      return baseprice;
                  }
                  else {
                      return baseprice;
                  }



              }
               </script>

         <script>
             function getelementcount() {
                 var count = 0;
                
                 $('.tblenhancedelements td').each(function (i, row) {

                     // reference all the stuff you need first
                     var $row = $(row);
                     rowcheckbox = $row.find('input:checked');
                     if (rowcheckbox.is(':checked')) {
                         count++;
                     }
                     
                 });
                 return count;
             }

         </script>
        <script>
            $(".elements").change(function () {
                costcalculation();
            });  //ru
        </script>

         <script>
             function getISBNcount() {
                 var i = 0;
                 $(".ebookisbn input:checked").each(function () {
                     i++;
                 });
                 return i;

             }

        </script>
        <script>
            function getISBNCost() {
                var count = 0;
                var ISBNcost = 0;
                count = getISBNcount();
                ISBNcost = parseFloat($('.isbncost').html()) * parseInt(count);
                return ISBNcost;
            }
        </script>
        <script>
            $(".ebookisbn").change(function () {
                costcalculation();
            });
        </script>
        <script>
            function costcalculation() {
                var count = productcount();
                var prodcost = productcost();
                var Customisationcost = 0;
                var avideocost = 0;
                var ebookisbncost = 0;
                var marketcost = 0;
                var covercost = 0;
                var totalhavcost = 0;
                var baseprice = productcost();
                baseprice = elementcostbaseprice(baseprice);
                ebookisbncost = getISBNCost();
                marketcost = getmarketcost();
                avideocost = avcost();
                covercost = getcovercost();
                totalhavcost = havcost();
                //alert(totalhavcost);
                var totalpackagecost = 0;
                if (count > 0) {
                    $('.customize_products tr').each(function (i, row) {

                        // reference all the stuff you need first
                        var $row = $(row),
                           Custdefault = $row.find('.Custdefault').html();
                        Custcost = $row.find('.Custcost').html();
                        Custqty = $row.find('.Custqty').val();
                        Custadditional = $row.find('.Custadditional').val();
                        Custadditionalunitcost = $row.find('.Custadditionalunitcost').val();

                        if (!isNaN(parseInt($row.find('.Custqty').val()))) {
                            if (parseInt($row.find('.Custqty').val()) > parseInt($row.find('.Custdefault').html())) {
                                $row.find('.Custadditional').html(parseInt($row.find('.Custqty').val()) - parseInt($row.find('.Custdefault').html()));
                                if ($row.find('.hdnisdollar').html() == 1) {
                                    $row.find('.Custadditionalunitcost').html($row.find('.Custcost').html());
                                    $row.find('.Custadditionaltotalcost').html((parseInt($row.find('.Custqty').val()) - parseInt($row.find('.Custdefault').html())) * parseFloat($row.find('.Custcost').html()) * parseInt(count));
                                    $row.find('.Custadditionalunitcost').val($row.find('.Custcost').html());
                                    $row.find('.Custadditionaltotalcost').val((parseInt($row.find('.Custqty').val()) - parseInt($row.find('.Custdefault').html())) * parseFloat($row.find('.Custcost').html()) * parseInt(count));
                                    Customisationcost = parseFloat(Customisationcost) + parseFloat((parseInt($row.find('.Custqty').val()) - parseInt($row.find('.Custdefault').html())) * parseFloat($row.find('.Custcost').html()) * parseInt(count))
                                }
                                else {
                                    $row.find('.Custadditionalunitcost').html((parseFloat($row.find('.Custcost').html()) / 100).toFixed(2));
                                    $row.find('.Custadditionaltotalcost').html((parseInt($row.find('.Custqty').val()) - parseInt($row.find('.Custdefault').html())) * (parseFloat($row.find('.Custcost').html()) * parseInt(count) / 100));
                                    $row.find('.Custadditionalunitcost').val((parseFloat($row.find('.Custcost').html()) / 100).toFixed(2));
                                    $row.find('.Custadditionaltotalcost').val((parseInt($row.find('.Custqty').val()) - parseInt($row.find('.Custdefault').html())) * (parseFloat($row.find('.Custcost').html()) * parseInt(count) / 100));
                                    Customisationcost = (parseFloat(Customisationcost) + parseFloat((parseInt($row.find('.Custqty').val()) - parseInt($row.find('.Custdefault').html())) * (parseFloat($row.find('.Custcost').html()) * parseInt(count) / 100))).toFixed(2);
                                }
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
                    //$('.totalpackagecost').val(parseFloat(baseprice).toFixed(2));
                    //$('.basecost').val(parseFloat(baseprice).toFixed(2));
                    $('#imgbtnproceed').prop('disabled', false);
                    $('.totalpackagecost').val((parseFloat(baseprice) + parseFloat(ebookisbncost) + parseFloat(marketcost) + parseFloat(avideocost) + parseFloat(covercost)+parseFloat(Customisationcost)+parseFloat(totalhavcost)).toFixed(2));
                    $('.basecost').val(parseFloat(baseprice).toFixed(2));
                }
                else {
                    clearcustomisations();
                    $('.totalpackagecost').val('');
                    $('.avunitcost').html('');
                    $('.avtotalcost').html('');
                    $('.avqty').val('');
                    $('.basecost').val('');
                    $('.havunitcost').html('');
                    $('.havtotalcost').html('');
                    $('.txthavqty').val('');
                    $('input:checkbox').removeAttr('checked');
                    $("input:radio").attr("checked", false);
                    $('#imgbtnproceed').prop('disabled', true);
                }
            }

        </script>
                <script>
                    function clearcustomisations() {
                        $('.customize_products tr').each(function (i, row) {
                            var $row = $(row);
                            $row.find('.Custadditional').html('');
                            $row.find('.Custadditionalunitcost').html('');
                            $row.find('.Custadditionaltotalcost').html('');
                            $row.find('.Custqty').val('');
                        });
                    }
        </script>
          <script>
              function getmarketcost() {
                  var totalmarketcost = 0;
                  var count = 0;
                  $('.ebookmarket tr').each(function (i, row) {
                      var $row = $(row);
                      marketcost = $row.find('.marketcost').html();
                      rowcheckbox = $row.find('input:checked');
                      if (rowcheckbox.is(':checked')) {
                          count++;
                          totalmarketcost = parseFloat(totalmarketcost) + parseFloat($row.find('.marketcost').html());
                      }

                  });
                  if (count >= 4)
                      totalmarketcost = parseFloat($("#lblmktamt").html());
                  if ($('#chkEnhancedeBookmarketing').is(':checked')) {
                      totalmarketcost = parseFloat($("#lblmktamt").html());
                  }
                  return totalmarketcost;
                  //alert(totalmarketcost);
              }
        </script>
         <script>
             $(".market").change(function () {
                 costcalculation();
             });  //ru
        </script>
          <script>
              jQuery('.avqty').on('keyup', function () {
                  costcalculation();
                  //avcost();
              });

        </script>
        <script>
            function avcost() {
                var avcost = 0;
                if (!isNaN(parseInt($('.avqty').val()))) {
                    avcost = parseFloat($('.avqty').val()) * parseFloat($('#hdnEnhancedavelementcost').val());
                    $('.avunitcost').html($('#hdnEnhancedavelementcost').val());
                    $('.avtotalcost').html(avcost);
                    $('.avunitcost').val($('#hdnEnhancedavelementcost').val());
                    $('.avtotalcost').val(avcost);
                    return avcost;
                }
                else {
                    $('.avunitcost').html('');
                    $('.avtotalcost').html('');
                    $('.avunitcost').val('');
                    $('.avtotalcost').val('');
                    $('.avqty').val('');
                    return avcost;
                }

            }
        </script>


        <script>
            $(document).ready(function () {
                var coverdesigncost = 0;
                $('input:radio[name=CoverDesign]').change(function () {
                    //alert('hi');
                    costcalculation();
                });
            });
        </script>
        <script>
            function getcovercost() {
                var totalcovercost = 0;
                $('.tblcover tr').each(function (i, row) {
                    var $row = $(row);
                    covercost = $row.find('.covercost').html();
                    rowradiobutton = $row.find('input:radio[name=CoverDesign]:checked');
                    if (rowradiobutton.is(':checked')) {
                        totalcovercost = parseFloat(covercost);
                    }

                });
                return totalcovercost;
            }
        </script>
         <script>
             jQuery('.Custqty').on('keyup', function () {
                 //alert('Hi');
                 costcalculation();
             });
            </script>

        <script>
            jQuery('.txthavqty').on('keyup', function () {
                costcalculation();
            });
        </script>
        <script>
            function havcost() {
                var havtotalcost = 0;
                if (!isNaN(parseInt($('.txthavqty').val()))) {
                    havtotalcost = parseFloat($('.txthavqty').val()) * parseFloat($('#hdnEnhancedavelementcost').val());
                    $('.havunitcost').html($('#hdnEnhancedReadaloudcost').val());
                    $('.havtotalcost').html(havtotalcost);
                    $('.havunitcost').val($('#hdnEnhancedReadaloudcost').val());
                    $('.havtotalcost').val(havtotalcost);
                    return havtotalcost;
                }
                else {
                    $('.havunitcost').html('');
                    $('.havtotalcost').html('');
                    $('.havunitcost').val('');
                    $('.havtotalcost').val('');
                    $('.txthavqty').val('');
                    return havtotalcost;
                }

            }
        </script>

    </form>
</body>

</html>
