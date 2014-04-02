<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xebook.aspx.cs" Inherits="eBooks2goV5.pricing.xebook" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Ajax Tab Container</title>
    <%-- Tab Container Css Begin--%>
    <style type="text/css">
        .fancy-green .ajax__tab_header {
            background: url(../green_bg_Tab.gif) repeat-x;
            cursor: pointer;
        }

        .fancy-green .ajax__tab_hover .ajax__tab_outer, .fancy-green .ajax__tab_active .ajax__tab_outer {
            background: url(../green_left_Tab.gif) no-repeat left top;
        }

        .fancy-green .ajax__tab_hover .ajax__tab_inner, .fancy-green .ajax__tab_active .ajax__tab_inner {
            background: url(../green_right_Tab.gif) no-repeat right top;
        }

        .fancy .ajax__tab_header {
            font-size: 13px;
            font-weight: bold;
            color: #000;
            font-family: sans-serif;
        }

            .fancy .ajax__tab_active .ajax__tab_outer, .fancy .ajax__tab_header .ajax__tab_outer, .fancy .ajax__tab_hover .ajax__tab_outer {
                height: 46px;
            }

            .fancy .ajax__tab_active .ajax__tab_inner, .fancy .ajax__tab_header .ajax__tab_inner, .fancy .ajax__tab_hover .ajax__tab_inner {
                height: 46px;
                margin-left: 16px; /* offset the width of the left image */
            }

            .fancy .ajax__tab_active .ajax__tab_tab, .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_header .ajax__tab_tab {
                margin: 16px 16px 0px 0px;
            }

        .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_active .ajax__tab_tab {
            color: #fff;
        }

        .fancy .ajax__tab_body {
            font-family: Arial;
            font-size: 10pt;
            border-top: 0;
            border: 1px solid #999999;
            padding: 8px;
            background-color: #ffffff;
        }

        .eb2g_test {
            width: 1000px;
            margin: auto;
        }
    </style>
    <%-- Tab Container Css End--%>
    <%--eBooks2go css begin--%>
    <link href='http://fonts.googleapis.com/css?family=TrebuchetMS' rel='stylesheet' type='text/css' />
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

  
    <style type="text/css">
        .divstyle {
            display: none;
            height: auto;
            width: auto;
        }
    </style>
    <link type='text/css' href='../css/pricingpage.css' rel='stylesheet' media='screen' />
    <link href='http://fonts.googleapis.com/css?family=Arimo' rel='stylesheet' type='text/css'>
    <style>
        body {
            font-family: Verdana, Geneva, sans-serif;
        }

        @font-face {
            font-family: "Droid Sans";
            src: url(../DroidSans.ttf) format("truetype");
        }

        @font-face {
            font-family: "Trebuchet MS";
            src: url(../trebuc.ttf) format("truetype");
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
            float: left;
            margin-left: -30px;
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
            width: 235px;
            height: 235px;
            float: none;
            background-image: url(../images/best.png);
            background-repeat: no-repeat;
            color: #FFF; /* [disabled]padding: 6px; */ /* [disabled]padding-top: 20px; */
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
            position: absolute;
            left: 5px;
            top: 40px;
            width: 300px;
            height: 100px;
            z-index: 0;
        }

        #apDiv3 {
            position: absolute;
            left: 300px;
            top: 120px;
            width: 64px;
            height: 55px;
            z-index: 1;
        }

        .ebooks_discount {
            color: #000;
            font-size: 1.2em;
            padding: 10px;
            padding-top: 5px;
        }

            .ebooks_discount ul {
                margin-left: -10px;
                font-size: 13px;
                font-weight: normal;
                margin-right: 10px;
                list-style-image: url(../images/star.png);
                list-style-position: inside;
            }

                .ebooks_discount ul li {
                    font-family: 'Gloria Hallelujah', cursive;
                    color: #000;
                    text-align: left;
                }

        #tabEbook {
            font-family: Verdana, Geneva, sans-serif;
            font-weight: bold;
            font-size: 0.8em;
            color: #000;
        }
        .hdnisdollar {
            display:none;
        }
            #tabEbook td, th {
                padding: 0.5em;
            }

            #tabEbook th {
                background-color: #000;
                color: #fff;
                font-size: 1.2em;
            }

        .tabHeads {
            color: ##68b026;
            font-size: 20px;
            line-height: 40px;
            margin-left: 2px;
        }

        .subHeads {
            text-align: right;
            color: #999;
        }

        .cartHold {
            display: inline-block;
            float: left;
        }

            .cartHold img {
                display: inline-block;
                width: 50px;
                height: auto;
            }

        .productHold {
            display: inline-block;
            margin-left: 10px;
            color: #ff0000;
        }

        #tabEbook > table {
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
        function confirmPay() {
            $('#Div4').hide(1000);
            $('#tabEbook').show(1000, function () {
                $("html, body").animate({ scrollTop: 0 }, "slow");

            });

        }
        function editPay() {
            $('#Div4').show(1000);
            $('#tabEbook').hide(1000, function () {
                $("html, body").animate({ scrollTop: 0 }, "slow");

            });
        }
</script>
    <style>
        .tabEbook { width:1000px; height:1000px; float:left; background-color:#fff;
        }

    </style>
      <script type='text/javascript' src='https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js'></script>

    <%--eBooks2go Css End--%>

    <%--back button disable start--%>
    <script type="text/javascript">
        function preventBack() {
            window.history.forward();
        }
        window.onunload = function () {
            null;
        };
        setTimeout("preventBack()", 0);
        </script>
    <%--back button disable complete--%>

</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="uppnl" runat="server">
            <ContentTemplate>
        <div>
            <div id="view1" runat="server" class="tabcontent default">
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
                                <img src="../images/ebooksformating.png" alt="" />
                            </div>
                            <div class="eb2g_discountprice">
                                <div class="blueclock">
                                    <div style="transform: rotate(0deg) scale(1, 1); display: block;" class="pendulum-parent">
                                        <div class="ebooks_discount" align="center">
                                            <b>Offers</b>
                                            <ul>
                                                <li>Select any '
                                                                <asp:Label ID="lblebookoffer1" class="offer1" runat="server"></asp:Label>
                                                    ' products get
                                                                <asp:Label ID="lblebookoffer1dis" class="offer1discount" runat="server"></asp:Label>
                                                    Discount on base price </li>
                                                <li>Select any '
                                                                <asp:Label ID="lblebookoffer2" class="offer2" runat="server"></asp:Label>
                                                    ' products get
                                                                <asp:Label ID="lblebookoffer2dis" class="offer2discount" runat="server"></asp:Label>
                                                    Discount on base price</li>
                                            </ul>
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
                                    <asp:Panel ID="pnleBookproducts" runat="server">
                                        <div class="eb2g_products_details_eup">
                                            <table class="products">
                                                <tr class="store_name">
                                                    <td width="93" rowspan="2" valign="middle">
                                                        <asp:CheckBox ID="chkeBookePub" class="checkboxproduct" runat="server" />
                                                        <label for="epub2">
                                                            <img src="../images/epub.png" alt="epub" /></label>
                                                    </td>
                                                    <td width="222">
                                                        <span class="product_details">Works on 90 percent of the devices available in the market.
                                                                    Doesn't work on Amazon devices.</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="productPrice">$<asp:Label ID="lblebookepubprodcost" class="pprice"  runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="eb2g_products_details_mobi">
                                            <table width="319" class="products">
                                                <tr class="store_name">
                                                    <td style="padding-top: 8px;" width="93" rowspan="2">
                                                        <asp:CheckBox ID="chkeBookKindle" class="checkboxproduct" runat="server" />
                                                        <label for="kindle">
                                                            <img src="../images/kindle.png" width="511" height="511" alt="kindle" /></label>
                                                    </td>
                                                    <td width="214">
                                                        <span class="product_details">Works only with Amazon kindle fire devices.</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="productPrice">$<asp:Label ID="lblebookkindleprodcost" class="pprice" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="eb2g_products_details_epdf">
                                            <table class="products">
                                                <tr class="store_name">
                                                    <td width="93" rowspan="2">
                                                        <asp:CheckBox ID="chkeBookePDF" class="checkboxproduct" runat="server" />
                                                        <label for="epdf">
                                                            <img src="../images/PDF.png" width="512" height="512" alt="epdf" /></label>
                                                    </td>
                                                    <td>
                                                        <span class="product_details">Works on 90 percent of the devices available in the market.
                                                                    Doesn't work on Amazon devices.</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="productPrice">$<asp:Label ID="lblebookpdfprodcost" class="pprice"  runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </asp:Panel>
                                </div>
                                <div class="eb2g_products_cost">
                                    <div class="eb2g_PackageCost">
                                        Package Cost
                                                    <br />
                                        <asp:TextBox ID="txteBookPckCst" class="totalpackagecost" ReadOnly="true" runat="server"></asp:TextBox>
                                        <asp:TextBox ID="txteBookhdnPckCst" class="totalpackagecost" style="display:none;" runat="server"></asp:TextBox>
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
                        &nbsp;
                    </div>
                    <hr>
                    <span class="Customizeyourproduct">
                        <h3>Customize your product</h3>
                    </span>
                    <label>
                    </label>
                    <div class="Customize_pricing">
                        <table width="1000" cellspacing="0" class="customize_products">
                            <tr>
                                <th>&nbsp;
                                </th>
                                <th align="center">Total Units
                                </th>
                                <th>Additional Units
                                </th>
                                <th>Unit Cost(USD)
                                </th>
                                <th>Additional Cost(USD)
                                </th>
                            </tr>
                            <tr>
                                <td width="490">
                                    <h4>Total Number of pages in the Book</h4>
                                    <span class="Customize_totalnumber">Upto
                                        <asp:Label runat="server" class="hdnisdollar">0</asp:Label>
                                                    <asp:Label ID="lblebookcustpcdpages" class="Custdefault" runat="server"></asp:Label>
                                        pages are included in the base price.<br />
                                        Additional pages will be billed at.
                                                    <asp:Label ID="lblebookperpagecost" class="Custcost" runat="server"></asp:Label>
                                         cents per page Please include front & back covers in the total page count</span>
                                </td>
                                <td width="100" align="center">
                                    <asp:TextBox ID="txtebookcustpcdpages"  class="Custqty"   runat="server"></asp:TextBox>
                                     <ajax:FilteredTextBoxExtender ID="fteebookcustpcdpages" runat="server" FilterType="Numbers"
    TargetControlID="txtebookcustpcdpages" />
                                </td>
                                <td width="135" align="center">
                                    <label>
                                        <asp:Label ID="lbleBookadditonalpages" class="Custadditional" runat="server"></asp:Label></label>
                                </td>
                                <td width="135" align="center">
                                    <label>
                                        <asp:Label ID="lbleBookadditonalpagesunitcost" class="Custadditionalunitcost"   runat="server"></asp:Label>
                                        <asp:TextBox  ID="hdneBookadditonalpagesunitcost" class="Custadditionalunitcost" style="display:none;" runat="server"></asp:TextBox>
                                    </label>
                                </td>
                                <td width="135" align="center">
                                    <label>
                                        <asp:Label ID="lbleBookpageadditionalcost" class="Custadditionaltotalcost" runat="server"></asp:Label>
                                        <asp:TextBox ID="hdneBookpageadditionalcost" class="Custadditionaltotalcost" style="display:none;" runat="server" />
                                    </label>
                                    </label>
                                </td>
                            </tr>
                            <tr>
                                <td width="490">
                                    <h4>Total Number of Images in the Book
                                    </h4>
                                    <span class="Customize_totalnumber">Upto
                                         <asp:Label  runat="server" class="hdnisdollar">1</asp:Label>
                                                    <asp:Label ID="lblebookcustpcdimages" class="Custdefault" runat="server"></asp:Label>
                                        images are included in the Base price.
                                                    <br />
                                        Additional images will be billed at $<asp:Label ID="lblebookperimagecost" class="Custcost" runat="server"></asp:Label>
                                        per images</span>
                                </td>
                                <td width="100" align="center">
                                    <asp:TextBox ID="txteBookcustpcdimages" runat="server" class="Custqty"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="fteeBookcustpcdimages" runat="server" FilterType="Numbers"
    TargetControlID="txteBookcustpcdimages" />
                                </td>
                                <td align="center">
                                    <asp:Label ID="lbleBookadditionalimages" class="Custadditional" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lbleBookadditionalimagesunitcost" class="Custadditionalunitcost"  runat="server"></asp:Label>
                                    <asp:TextBox ID="hdneBookadditionalimagesunitcost" class="Custadditionalunitcost" style="display:none;"  runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Label ID="lbleBookimagesadditionalcost"  class="Custadditionaltotalcost" runat="server"></asp:Label>
                                    <asp:TextBox ID="hdneBookimagesadditionalcost" class="Custadditionaltotalcost" style="display:none;" runat="server" />

                                </td>
                            </tr>
                            <tr>
                                <td width="490">
                                    <h4>Total Number of Foot Notes & End Notes Linking
                                    </h4>
                                    <span class="Customize_totalnumber">Additional links will be billed at
                                    <asp:Label ID="lblebookfootnotesandendnotescost" class="Custcost" runat="server"></asp:Label>
                                        cents per link</span>
                                      <asp:Label   runat="server" class="hdnisdollar">0</asp:Label>
                                </td>
                                <td width="100" align="center">
                                     <asp:Label ID="lblfootandnotedefaultqty" class="Custdefault" style="display:none;" runat="server"></asp:Label>
                                    <asp:TextBox ID="txteBookfootnotesandendnotes" runat="server" class="Custqty"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="fteeBookfootnotesandendnotes" runat="server" FilterType="Numbers"
    TargetControlID="txteBookfootnotesandendnotes" />
                                </td>
                                <td align="center">
                                    <asp:Label ID="lbleBookadditionalfootandendnotes" class="Custadditional" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lbleBookadditionalfootandendnotesunitcost" class="Custadditionalunitcost"  runat="server"></asp:Label>
                                     <asp:TextBox ID="hdneBookadditionalfootandendnotesunitcost" class="Custadditionalunitcost" style="display:none;" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Label ID="lbleBookfootandendnotesadditionalcost"  class="Custadditionaltotalcost" runat="server"></asp:Label>
                                     <asp:TextBox ID="hdneBookfootandendnotesadditionalcost" class="Custadditionaltotalcost" style="display:none;"   runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td width="490">
                                    <h4>Total Number of web links, Hyperlinks, email links etc
                                    </h4>
                                    <span class="Customize_totalnumber">Upto
                                                    <asp:Label ID="lblebookcustpcdhplinks" class="Custdefault" runat="server"></asp:Label>
                                        links are included in the base price.
                                                    <br />
                                        Additional Hyperlinks will be billed at
                                                    <asp:Label ID="lblebookweblinkscost" class="Custcost" runat="server"></asp:Label>
                                        cents per link</span>
                                     <asp:Label   runat="server" class="hdnisdollar">0</asp:Label>
                                </td>
                                <td width="100" align="center">
                                    <asp:TextBox ID="txteBookcustpcdhplinks" runat="server" class="Custqty"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="fteeBookcustpcdhplinks" runat="server" FilterType="Numbers"
    TargetControlID="txteBookcustpcdhplinks" />
                                </td>
                                <td align="center">
                                    <asp:Label ID="lbleBookadditionalpcdhplinks" class="Custadditional" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lbleBookadditionalpcdhplinksunitcost" class="Custadditionalunitcost"  runat="server"></asp:Label>
                                    <asp:TextBox ID="hdneBookadditionalpcdhplinksunitcost" class="Custadditionalunitcost" style="display:none;"  runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Label ID="lbleBookpcdhplinksadditionalcost"  class="Custadditionaltotalcost" runat="server"></asp:Label>
                                    <asp:TextBox ID="hdneBookpcdhplinksadditionalcost" class="Custadditionaltotalcost" style="display:none;"   runat="server" />
                                </td>
                            </tr>
                        </table>

                        <h3>Does Your Book contain any of the following elements</h3>
                        <asp:Panel ID="pnleBookelements" runat="server">
                            <div class="Customize_Bookcontain_content">
                                <span class="Customize_Bookcontain">When 2 to 4 elements are selected,it adds
                                            <asp:Label ID="lblebooktwotofourelementscost" class="twoelementcost" runat="server"></asp:Label>
                                    to the bace cost,</span><br />
                                <span class="Customize_Bookcontain">When 5 & Above elements are selected,it adds
                                            <asp:Label ID="lblebookfourpluselementscost"  class="fourelementcost" runat="server"></asp:Label>
                                    to the bace cost</span>
                            </div>
                            <div class="Customize_Bookcontain_total">
                                <asp:TextBox ID="txtelemadditonalbasecost" class="basecost" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                            <br />
                            <table width="1000" cellspacing="0">
                                <tr>
                                    <td width="350">
                                        <h4>Nested TOC</h4>
                                    </td>
                                    <td width="150" align="center">
                                        <asp:CheckBox ID="chkeBooknestedtoc" runat="server" class="elements" />
                                    </td>
                                    <td width="350">
                                        <h4>Drop Caps</h4>
                                    </td>
                                    <td width="150" align="center">
                                        <asp:CheckBox ID="chkeBookdropcaps" runat="server" class="elements" />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="350">
                                        <h4>Colored Fonts</h4>
                                    </td>
                                    <td width="150" align="center">
                                        <asp:CheckBox ID="chkeBookcoloredfonts" runat="server" class="elements" />
                                    </td>
                                    <td width="350">
                                        <h4>Lists</h4>
                                    </td>
                                    <td width="150" align="center">
                                        <asp:CheckBox ID="chkeBooklists" runat="server" class="elements" />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="350">
                                        <h4>Multiple Sections and Sub-Sections</h4>
                                    </td>
                                    <td width="150" align="center">
                                        <asp:CheckBox ID="chkeBooksections" runat="server" class="elements" />
                                    </td>
                                    <td width="350">
                                        <h4>Call Outs</h4>
                                    </td>
                                    <td width="150" align="center">
                                        <asp:CheckBox ID="chkeBookcallouts" runat="server" class="elements" />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="350">
                                        <h4>Double Column Text</h4>
                                    </td>
                                    <td width="150" align="center">
                                        <asp:CheckBox ID="chkeBookdoublecolumntext" runat="server" class="elements"/>
                                    </td>
                                    <td width="350">
                                        <h4>Centered Text</h4>
                                    </td>
                                    <td width="150" align="center">
                                        <asp:CheckBox ID="chkeBookcenteredtext" runat="server" class="elements" />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="350">
                                        <h4>Text boxes with borders/varying colors</h4>
                                    </td>
                                    <td width="150" align="center">
                                        <asp:CheckBox ID="chkeBooktextboxescolors" runat="server" class="elements" />
                                    </td>
                                    <td width="350">
                                        <h4></h4>
                                    </td>
                                    <td width="150" align="center"></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <h3>Does Your Book Need Audio/Video Elements</h3>
                        <table width="1000" cellspacing="0">
                            <tr>
                                <td width="450" valign="top">
                                    <h4>Total Number of Audio/Video Elements in the book.
                                                    <img class="helpTip"  id="imgeBookAVelement"  
                                                        src="../images/help2.png" width="32" runat="server" height="32" alt="help" />
                                        <asp:HiddenField ID="hdnavelementcost"  runat="server" />
                                    </h4>
                                </td>
                                <td width="100" align="center">
                                  <asp:TextBox ID ="txteBookeachavcost" runat="server" class="avqty"></asp:TextBox>
                                     <ajax:FilteredTextBoxExtender ID="fteeBookeachavcost" runat="server" FilterType="Numbers"
    TargetControlID="txteBookeachavcost" />
                                </td>
                                <td align="center">
                                    <asp:Label ID="lbleBookavunitcost" class="avunitcost" runat="server"></asp:Label>
                                    <asp:TextBox ID="hdneBookavunitcost" class="avunitcost" style="display:none;"  runat="server"/>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lbleBookavtotalcost" class="avtotalcost" runat="server"></asp:Label>
                                         <asp:TextBox ID="hdneBookavtotalcost" class="avtotalcost" style="display:none;"  runat="server"/>
                                </td>
                            </tr>
                        </table>
                        <h3>Does your Book need Cover design?</h3>
                        <table width="1000" cellspacing="0" class="tblcover">
                            <tr>
                                <td width="468">
                                    <h4>Simple Cover Design</h4>
                                </td>
                                <td width="171" align="left">
                                    <asp:RadioButton ID="rbeBookSimpleDesign" runat="server" value="simple"   GroupName="Coverdesign" />
                                </td>
                                <td colspan="3">
                                    <span class="store_format_isbn">$<asp:Label ID="lblebookscoverdesigncost" class="covercost" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td width="468">
                                    <h4>High Impact Cover Design</h4>
                                </td>
                                <td width="171" align="left">
                                    <asp:RadioButton ID="rbeBookHIDesign" runat="server"  value="complex"  GroupName="Coverdesign"   />
                                     <%-- <input type="radio" name="bedStatus" id="allot" checked="checked" value="allot"/>Allot
<input type="radio" name="bedStatus" id="transfer" value="transfer"/>Transfer--%>

                                </td>
                                <td colspan="3">
                                    <span class="store_format_isbn">$<asp:Label ID="lblebookhcoverdesigncost" class="covercost" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td width="468">
                                    <h4>EISBN Cost
                                    </h4>
                                </td>
                                <asp:Panel ID="pnleBookeisbn" runat="server">
                                <td colspan="2" align="center">
                                    <span class="store_format">ePUB</span> <span class="store_format_checkbox">
                                        
                                        <asp:CheckBox ID="chkeBookepubeisbn" runat="server" class="ebookisbn" />
                                    </span><span class="store_format_isbn">$<asp:Label ID="lblebookepubprodisbncost" class="isbncost"
                                        runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td width="154">
                                    <span class="store_format">Mobi</span> <span class="store_format_checkbox">
                                         <asp:CheckBox ID="chkeBookmobieisbn" runat="server" class="ebookisbn" />
                                    </span><span class="store_format_isbn">$<asp:Label ID="lblebookmobiprodisbncost" class="isbncost"
                                        runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td width="154">
                                    <span class="store_format">Nook</span> <span class="store_format_checkbox">
                                      <asp:CheckBox ID="chkeBookenookeisbn" runat="server" class="ebookisbn" />
                                    </span><span class="store_format_isbn">$<asp:Label ID="lblebooknookprodisbncost" class="isbncost"
                                        runat="server"></asp:Label>
                                    </span>
                                </td>
                                    </asp:Panel>
                            </tr>
                        </table>
                        <h3>eBook Publishing, Distribution and Royalties</h3>
                        <table width="1000" cellspacing="0">
                            <tr>
                                <td width="450" valign="top">
                                    <h4>I will take care of the distribution myself</h4>
                                </td>
                                <td align="left">
                                    <asp:RadioButton ID="rbeBookdistmyself" runat="server" GroupName="distribution" />
                                </td>

                            </tr>
                            <tr>
                                <td width="450">
                                    <h4>I would like eBooks2go to be my distribution agent..
                                                    <img src="../images/PDFdownload.png" alt="view/download odf" width="24" /></h4>
                                </td>
                                <td align="left">
                                    <asp:RadioButton ID="rbeBookdistagent" runat="server"  GroupName="distribution" />
                                </td>
                            </tr>
                        </table>
                        <h3>Marketing Services
                        </h3>
                        <asp:Panel ID="pnleBookmarketingservices" runat="server">
                        <table width="1000" cellspacing="0" class="ebookmarket">
                            <tr>
                                <td width="450">
                                    <h4>Social Media Setup</h4>
                                </td>
                                <td width="100" align="left">
                                    <asp:CheckBox ID="chkeBooksocialmediasetup" runat="server" class="market" />
                                </td>
                                <td align="center">
                                    <span class="store_format_isbn">$<asp:Label ID="lblebooksocialmediacost" class="marketcost" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <h4>Press Release</h4>
                                </td>
                                <td align="left">
                                     <asp:CheckBox ID="chkeBookpressrelease" runat="server" class="market" />
                                </td>
                                <td align="center">
                                    <span class="store_format_isbn">$<asp:Label ID="lblebookpressreleasecost" class="marketcost" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <h4>Email Campaign</h4>
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="chkeBookemailcampaign" runat="server" class="market"  />
                                </td>
                                <td align="center">
                                    <span class="store_format_isbn">$<asp:Label ID="lblebookemailcampaincost" class="marketcost" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <h4>Website and Blog Promotion</h4>
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="chkeBookwebsitepromotion" runat="server" class="market" />
                                </td>
                                <td align="center">
                                    <span class="store_format_isbn">$<asp:Label ID="lblebookwebsiteblogpromotioncost" class="marketcost"
                                        runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <h4>Select all of marketing and get $<asp:Label ID="lblebookmarketingdiscount"  runat="server"></asp:Label>
                                        percent off</h4>
                                </td>
                                <td align="left">
                                   <asp:CheckBox ID="chkeBookmarketing" runat="server"  class="market"/>
                                </td>
                                <td align="center">
                                    <span class="store_format_isbn">$<asp:Label ID="lblmktamt" class="marketcost" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                        </table>
                            </asp:Panel>
                    </div>
                   <%-- <img src="../images/proceed.jpg" alt="proceed" width="117" height="30" align="right"
                        onclick="confirmPay()" />--%>
                    <asp:ImageButton ID="imgbtnproceed" ImageUrl="../images/proceed.jpg" ImageAlign="Right"  OnClick="imgbtnproceed_Click"  runat="server" />
                </div>
              
            </div>
             
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        <script>
            jQuery('.Custqty').on('keyup', function () {
                costcalculation();
                //var $row = jQuery(this).closest('tr');
                //var $columns = $row.find('td');

                //$columns.addClass('row-highlight');
                //var values = "";
                //var count = productcount();
                //jQuery.each($columns, function (i, item) {
                //    //values = values + 'td' + (i + 1) + ':' + item.innerHTML + '<br/>';
                //    //if (i == 0) {
                //    if (!isNaN(parseInt($row.find('.Custqty').val()))) {
                //        if (parseInt($row.find('.Custqty').val()) > parseInt($row.find('.Custdefault').html())) {
                //            $row.find('.Custadditional').html(parseInt($row.find('.Custqty').val()) - parseInt($row.find('.Custdefault').html()));
                //            $row.find('.Custadditionalunitcost').html($row.find('.Custcost').html());
                //            $row.find('.Custadditionaltotalcost').html((parseInt($row.find('.Custqty').val()) - parseInt($row.find('.Custdefault').html()))*parseFloat($row.find('.Custcost').html())*parseInt(count));
                          
                //        }
                //        else {
                //            $row.find('.Custadditional').html('');
                //            $row.find('.Custadditionalunitcost').html('');
                //            $row.find('.Custadditionaltotalcost').html('');
                //        }
                //    }
                //    else {
                //        $row.find('.Custadditional').html('');
                //        $row.find('.Custadditionalunitcost').html('');
                //        $row.find('.Custadditionaltotalcost').html('');
                //    }

                //    //}
                //});
                //console.log(values);
            });
            </script>
        <script>
            function productcount() {
                var i = 0;
                $("#pnleBookproducts input:checked").each(function () {
                    i++;
                });
                return i; 
            }
        </script>
        <script>
            function productcost() {
                var productcost = 0;
                var count = productcount();
                $('.products tr').each(function (i, row) {

                    // reference all the stuff you need first
                    var $row = $(row);
                    Custdefault = $row.find('.Custdefault').html();
                    rowcheckbox = $row.find('input:checked');
                    if (rowcheckbox.is(':checked')) {
                        productcost = parseFloat(productcost)+parseFloat($row.next().find('.pprice').html());
                    }
                    
                    });
                if (productcost > 0) {
                    if(count < parseInt($('.offer1').html()))
                    {
                        productcost = productcost;
                    }
                     else if (count < parseInt($('.offer2').html())) {
                       
                        productcost =  (productcost*(100 - parseFloat($('.offer1discount').html())) / 100);

                    }
                    else if (count >= parseInt($('.offer2').html())) {
                        
                        productcost =  (productcost*(100 - parseFloat($('.offer2discount').html())) / 100);

                    }
                    return productcost;
                }
                else {
                    return 0;
                }
            }
        </script>
        <script>
           

            $(".checkboxproduct").change(function () {
                costcalculation();
                });  //run through each row
               
            
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
                var baseprice = productcost();
                baseprice = elementcostbaseprice(baseprice);
                ebookisbncost = getISBNCost();
                marketcost=getmarketcost();
                avideocost = avcost();
                covercost = getcovercost();
                var totalpackagecost = 0;
                if (count > 0) {
                    $('.customize_products tr:gt(0)').each(function (i, row) {

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
                                    $row.find('.Custadditionalunitcost').val($row.find('.Custcost').html());
                                    $row.find('.Custadditionaltotalcost').html((parseInt($row.find('.Custqty').val()) - parseInt($row.find('.Custdefault').html())) * parseFloat($row.find('.Custcost').html()) * parseInt(count));
                                    $row.find('.Custadditionaltotalcost').val((parseInt($row.find('.Custqty').val()) - parseInt($row.find('.Custdefault').html())) * parseFloat($row.find('.Custcost').html()) * parseInt(count));
                                    Customisationcost = (parseFloat(Customisationcost) + parseFloat((parseInt($row.find('.Custqty').val()) - parseInt($row.find('.Custdefault').html())) * parseFloat($row.find('.Custcost').html()) * parseInt(count))).toFixed(2);

                                }
                                else {
                                    $row.find('.Custadditionalunitcost').html((parseFloat($row.find('.Custcost').html())/100).toFixed(2));
                                    $row.find('.Custadditionaltotalcost').html((parseInt($row.find('.Custqty').val()) - parseInt($row.find('.Custdefault').html())) * (parseFloat($row.find('.Custcost').html()) * parseInt(count) / 100));
                                    $row.find('.Custadditionalunitcost').val((parseFloat($row.find('.Custcost').html()) / 100).toFixed(2));
                                    $row.find('.Custadditionaltotalcost').val((parseInt($row.find('.Custqty').val()) - parseInt($row.find('.Custdefault').html())) * (parseFloat($row.find('.Custcost').html()) * parseInt(count) / 100));
                                    Customisationcost = (parseFloat(Customisationcost) + parseFloat((parseInt($row.find('.Custqty').val()) - parseInt($row.find('.Custdefault').html())) * (parseFloat($row.find('.Custcost').html()) * parseInt(count)/100))).toFixed(2);
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
                    $('#imgbtnproceed').prop('disabled', false);
                    $('.totalpackagecost').val((parseFloat(Customisationcost) + parseFloat(baseprice) + parseFloat(avideocost) + parseFloat(marketcost) + parseFloat(covercost) + parseFloat(ebookisbncost)).toFixed(2));
                    $('.basecost').val(parseFloat(baseprice).toFixed(2));
                    $('.hdntotalpackagecost').val((parseFloat(Customisationcost) + parseFloat(baseprice) + parseFloat(avideocost) + parseFloat(marketcost) + parseFloat(covercost) + parseFloat(ebookisbncost)).toFixed(2));
                }
                else {
                    clearcustomisations();
                    $('.totalpackagecost').val('');
                    $('.avunitcost').html('');
                    $('.avtotalcost').html('');
                    $('.avqty').val('');
                    $('.basecost').val('');
                    $('.hdntotalpackagecost').val('');
                    $('input:checkbox').removeAttr('checked');
                    $("input:radio").attr("checked", false);
                    $('#imgbtnproceed').prop('disabled', true);
                    $('input').val('');
                }
            }

        </script>
        <script>
            function clearcustomisations() {
                $('.customize_products tr:gt(0)').each(function (i, row) {
                    var $row = $(row);
                    $row.find('.Custadditional').html('');
                    $row.find('.Custadditionalunitcost').html('');
                    $row.find('.Custadditionaltotalcost').html('');
                    $row.find('.Custqty').val('');
                   
                });
            }
        </script>
        <script>
             function elementcostbaseprice(baseprice)
             {
                 var elementcount = getelementcount();
                 if (parseInt(elementcount) == parseInt(2) || parseInt(elementcount) == parseInt(3) || parseInt(elementcount) == parseInt(4)) {
                     baseprice = (parseFloat(baseprice)*(100 + parseFloat($('.twoelementcost').html().replace('%', ''))) / 100)
                     return baseprice;
                     }
                 else if (parseInt(elementcount) >= parseInt(5)) {
                     baseprice = (parseFloat(baseprice)*(100 + parseFloat($('.fourelementcost').html().replace('%', ''))) / 100);
                     return baseprice;
                 }
                 else {
                     return baseprice;
                 }
               
                     
                 
             }
               </script>
        <script>
             function getelementcount() {
                 var i = 0;
                 $("#pnleBookelements input:checked").each(function () {
                     i++;
                 });
                 return i;
             }

         </script>
        <script>
            $(".elements").change(function () {
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
                    avcost = parseFloat($('.avqty').val()) * parseFloat($('#hdnavelementcost').val());
                    $('.avunitcost').html($('#hdnavelementcost').val());
                    $('.avtotalcost').html(avcost);
                    $('.avunitcost').val($('#hdnavelementcost').val());
                    $('.avtotalcost').val(avcost);
                    return avcost;
                }
                else {
                    $('.avunitcost').html('');
                    $('.avtotalcost').html('');
                    $('.avqty').val('');
                    $('.avunitcost').val('');
                    $('.avtotalcost').val('');
                    return avcost;
                }

            }
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
               count=getISBNcount();
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
            function getmarketcost() {
                var totalmarketcost = 0;
                var count=0;
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
                if ($('#chkeBookmarketing').is(':checked')) {
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
        <%-- <script>
            $(document).ready(function () {
                $('input:radio[name=bedStatus]').change(function () {
                    if (this.value == 'allot') {
                        alert("Allot Thai Gayo Bhai");
                    }
                    else if (this.value == 'transfer') {
                        alert("Transfer Thai Gayo");
                    }
                });
               
            });
        </script>--%>
        <script>
            $(document).ready(function () {
           $('input:radio[name=Coverdesign]').change(function () {
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
                   rowradiobutton = $row.find('input:radio[name=Coverdesign]:checked');
                    if (rowradiobutton.is(':checked')) {
                        totalcovercost = parseFloat(covercost);
                    }

                });
                return totalcovercost;
            }
        </script>
       
    </form>
   
</body>
</html>
