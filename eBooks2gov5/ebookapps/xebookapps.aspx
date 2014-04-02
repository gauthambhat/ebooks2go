<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xebookapps.aspx.cs" Inherits="eBooks2goV5.ebookapps.xebookapps" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=7, IE=8, IE=9, chrome=1" />
    <title>eBook Pricing | eBook Packages</title>
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type='text/javascript' src="js/jquery-css-transform.js"></script>
    <script type='text/javascript' src="js/jquery-animate-css-rotate-scale.js"></script>
    <script type="text/javascript" src="js/jquery.ui.core.js"></script>
    <script type="text/javascript" src="js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="js/jquery.ui.accordion.js"></script>
    <link href="css/styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-latest.pack.js"></script>
    <script type="text/javascript" src="js/scroolscript.js"></script>

    <script type="text/javascript">
        function loadnext(divout, divin) {
            $("." + divout).hide();
            $("." + divin).fadeIn("fast");
        }
       
    </script>
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
        $('input:radio').click(
          function (e) {
              if ($(this).is(':checked')) {
                  $('#div1').show();
              }
          });
    </script>
    <script type='text/javascript'>//<![CDATA[
        $(window).load(function () {
            // Short-form of `document.ready`
            $(function () {
                $("#div1").show();
                $("#preview").click("click", function () {
                    $("#div1").toggle("slow");
                });
            });
        });//]]>  

    </script>
    <script type="text/javascript">
        $(document).ready(function () {
        document.getElementById('div1').style.display = "block";
        document.getElementById('div2').style.display = "none";
        document.getElementById('div3').style.display = "none";  
        });
    </script>
    <script type="text/javascript">
        function showMe(it, hide1, hide2, hide3, box) {
            document.getElementById(it).style.display = "block";
            document.getElementById('hdnfieldcat').value = it;
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
            width: 230px;
            height: 208px;
            float: left;
            background-image: url(images/discount_img.png);
            background-repeat: no-repeat;
        }

        .ebooks_discount_titles {
            width: 200px;
            float: left;
            margin-left: 15px;
            margin-top: 32px;
        }

        #apDiv2 {
            position: absolute;
            left: 5px;
            top: 40px;
            width: 300px;
            height: 100px;
            z-index: 0;
        }

        #tabEbook, #tabEbook1, #complexeBookcart, #eBookAppsTextbookscart {
            font-family: Verdana, Geneva, sans-serif;
            font-size: 0.8em;
            color: #5a5a5a;
        }

            #tabEbook td, th, #tabEbook1 td, th, #complexeBook td, th, #complexeBookcart td, th, #eBookTextbooks td, th, #eBookAppsTextbookscart td, th {
                padding: 0.5em;
            }

            #tabEbook th, #tabEbook1 th, #complexeBookcart th, #eBookAppsTextbookscart th {
                background-color: #aaaaaa;
                color: #fff;
                font-size: 12px;
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

        #tabEbook > table, #tabEbook1 > table, #complexeBookcart > table, #eBookAppsTextbookscart > table {
            border: 0;
        }

        .eb2g_space {
            width: 170px;
            float: left;
            margin-left: 100px;
        }
    </style>
    <link href="css/jquery.mCustomScrollbar.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <script type="text/javascript" src="js/modernizr.custom.53451.js"></script>
    <style type="text/css">
        .divstyle {
            display: none;
            height: auto;
            width: auto;
        }
    </style>
    <link type='text/css' href='css/pricingpage.css' rel='stylesheet' media='screen' />
    <style>
        body {
            font-family: Verdana, Geneva, sans-serif;
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
            background-image: url(images/best.png);
            background-repeat: no-repeat;
            margin-left: 192px;
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

        .ebooks_discount {
            color: #000;
            font-size: 1.2em;
            padding: 10px;
            padding-top: 5px;
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
                    color: #000;
                    text-align: left;
                    width: 200px;
                    font-size: 13px;
                    margin-left: 35px;
                    margin-bottom: 10px;
                }

        .ebookapps {
            width: 1000px;
            margin: auto;
        }

        .eb2g_space {
            width: 170px;
            float: left;
            margin-left: 100px;
        }
    </style>



    <%--/*asp Accordion style start*/--%>

    <style type="text/css">
        .accordion {
            width: 250px;
        }

        .accordionHeader {
            border: 1px solid #2F4F4F;
            color: white;
            background-color: #2E4d7B;
            font-family: Arial, Sans-Serif;
            font-size: 12px;
            font-weight: bold;
           
            margin-top: 5px;
            cursor: pointer;
        }

        .accordionHeaderSelected {
            border: 1px solid #2F4F4F;
            color: white;
            background-color: #5078B3;
            font-family: Arial, Sans-Serif;
            font-size: 12px;
            font-weight: bold;
            padding: 5px;
            margin-top: 5px;
            cursor: pointer;
        }

        .accordionContent {
            background-color: #D3DEEF;
            border: 1px dashed #2F4F4F;
            border-top: none;
            padding: 5px;
            padding-top: 10px;
        }
    </style>
    <script type="text/javascript">
        function pageLoad() {
            var accCtrl = $find('accebookapps');
            accCtrl.add_selectedIndexChanged(onAccordionPaneChanged);
        }




        function onAccordionPaneChanged(sender, eventArgs) {
            var selectedPane = sender.get_SelectedIndex();
            if (selectedPane == 1) {
                alert(1);
            }
            if (selectedPane == 2) {
                alert(2);
            }
        }
    </script>
    <%--/*asp Accordion style end*/--%>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="apDiv2">
            <span class="ebookappstyps">
                 <asp:Accordion
                        ID="accebookapps" SuppressHeaderPostbacks="false"
                        CssClass="accordion" 
                        HeaderCssClass="accordionHeader" 
                        HeaderSelectedCssClass="accordionHeaderSelected"
                        ContentCssClass="accordionContent"
                        runat="server">
                        <Panes>
                            <asp:AccordionPane ID="accpaneebookapps"  runat="server">
                                <Header>
<asp:RadioButton ID="rbebookappssimpleebookapps" runat="server" AutoPostBack="true" GroupName="ebookapps" OnCheckedChanged="rbebookappssimpleebookapps_CheckedChanged" /> 
<asp:LinkButton ID="lnkbtnebookappssimpleebookapps"  Width="222" CssClass="eb2g_tabs" OnClick="lnkbtnebookappssimpleebookapps_Click" runat="server">Simple eBook Apps</asp:LinkButton></Header>
                                <Content>
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

                                </Content>
                            </asp:AccordionPane>
                            <asp:AccordionPane ID="AccordionPane2" runat="server">
                                <Header>
<asp:RadioButton ID="rbebookappscomplexebookapps" runat="server" AutoPostBack="true" GroupName="ebookapps" OnCheckedChanged="rbebookappscomplextebookapps_CheckedChanged" />
                                    <asp:LinkButton ID="lnkbtnebookappscomplexebookapps" Width="222"  OnClick="lnkbtnebookappscomplexebookapps_Click"   runat="server">Complex eBook Apps</asp:LinkButton>
                                </Header>
                                <Content>
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
                                    </div>
                                </Content>
                            </asp:AccordionPane>
                            <asp:AccordionPane ID="AccordionPane3" runat="server">
                                <Header>
<asp:RadioButton ID="rbebookappsfortextbooks" runat="server" AutoPostBack="true" GroupName="ebookapps" OnCheckedChanged="rbebookappsfortextbooks_CheckedChanged" />
                                    <asp:LinkButton ID="lnkbtneBookAppstextbook" Width="222"  OnClick="lnkbtneBookAppstextbook_Click"   runat="server"> eBook Apps for Textbooks</asp:LinkButton>
                                </Header>
                                <Content>
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
                                </Content>
                            </asp:AccordionPane>
                        </Panes>
                    </asp:Accordion>
            </span>
        </div>
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
                                        <table>
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="epub" type="checkbox" service="1" title="ePUB Package" value="449" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappssimpleebookappsipad" runat="server" AutoPostBack="true" OnCheckedChanged="chkebookappssimpleebookappsipad_CheckedChanged" />
                                                    IPad </td>
                                                <td>$<asp:Label ID="lblebookappssimpleebookappsipadproductcost" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; Works only with IPad & IPad mini </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="eb2g_products_details_mobi">
                                        <table>
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="Mobi" type="checkbox" service="2" title="Mobi Package" value="449" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappssimpleebookappsiphone" runat="server" AutoPostBack="true" OnCheckedChanged="chkebookappssimpleebookappsipad_CheckedChanged" />
                                                    IPhone</td>
                                                <td>$<asp:Label ID="lblebookappssimpleebookappsiphoneproductcost" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; Works only with IPhone 3,4,5 </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="eb2g_products_details_epdf">
                                        <table>
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="ePDF" type="checkbox" service="3" title="ePDF Package" value="449" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappssimpleebookappsandroidtablets" runat="server" AutoPostBack="true" OnCheckedChanged="chkebookappssimpleebookappsipad_CheckedChanged" />
                                                    Android Tablets</td>
                                                <td>$<asp:Label ID="lblebookappssimpleebookappsandroidtabletsproductcost" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; Works only with 10 inch and 7 inch</td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="eb2g_products_details_andriodphone">
                                        <table>
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="Checkbox1" type="checkbox" service="4" title="ePDF Package" value="449" name="PackageName" style="margin-left: 15px;" />--%>
                                                     <asp:CheckBox ID="chkebookappssimpleebookappsandroidphones" runat="server" AutoPostBack="true" OnCheckedChanged="chkebookappssimpleebookappsipad_CheckedChanged" />
                                                    Android Phones</td>
                                                <td>$<asp:Label ID="lblebookappssimpleebookappsandroidphonesproductcost" runat="server"></asp:Label></td>
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
                                    <asp:TextBox ID="txtebookappssimpleebookappspackagecost" runat="server" ReadOnly="true"></asp:TextBox>
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
                    <table width="1000" cellspacing="0" class="customize_products">
                        <tr>
                            <td width="490">
                                <h4>Total Number of pages in the Book</h4>
                                <span class="Customize_totalnumber">Upto
                                    <asp:Label ID="lblebookappssimpleebookappscustpages" runat="server"></asp:Label>
                                    pages are included in the base price.<br />
                                    &nbsp;&nbsp;&nbsp;Each Additonal pages be billed at. $<asp:Label ID="lblebookappssimpleebookappscustpagescost" runat="server"></asp:Label>
                                </span>
                            </td>
                            <td width="100" align="center">
                               <%-- <input type="text" />--%>
                                <asp:TextBox ID="txtebookappssimpleebookappscustpages" runat="server" AutoPostBack="true" OnTextChanged="chkebookappssimpleebookappsipad_CheckedChanged"></asp:TextBox>
                                  <asp:FilteredTextBoxExtender ID="fteebookappssimpleebookappscustpages" runat="server" FilterType="Numbers"
    TargetControlID="txtebookappssimpleebookappscustpages" />
                            </td>
                            <td><asp:Label ID="lblebookappssimpleebookappsadditionalpages" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappssimpleebookappsadditonalpagesunitcost" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappssimpleebookappsadditionaltotalcost" runat="server"></asp:Label></td>
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

                                <a href="#">
                                    <img src="images/SimpleeBookApps1.png" alt="SimpleeBookApps">
                                    <div>Ellyn Satter </div>
                                </a>

                                <a href="#">
                                    <img src="images/SimpleeBookApps2.png" alt="SimpleeBookApps">
                                    <div>Ellyn Satter </div>
                                </a>

                                <a href="#">
                                    <img src="images/SimpleeBookApps4.png" alt="SimpleeBookApps">
                                    <div>Ellyn Satter </div>
                                </a>

                                <a href="#">
                                    <img src="images/SimpleeBookApps5.png" alt="SimpleeBookApps">
                                    <div>Ellyn Satter </div>
                                </a>

                            </div>
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

        <%--<table class="eb2g_uploadspcdoc" id="tabEbook" width="990" border="0" cellspacing="0" cellpadding="0" bordercolor="#E1E1E1" style="z-index:+1">
    <tr>
      <th scope="col" colspan="3">Upload Manuscript Documents</th>
    </tr>
    <tr class="eb2g_slede">
      <td><br />
        <div class="eb2g_space">Title</div></td>
      <td><br />
        : </td>
      <td class="eb2g_uploaddocumentlist"><br />
        <input type="text" /></td>
    </tr>
    <tr class="eb2g_slede">
      <td><div class="eb2g_space">Author</div></td>
      <td> : </td>
      <td class="eb2g_uploaddocumentlist"><input type="text" /></td>
    </tr>
    <tr class="eb2g_slede">
      <td><div class="eb2g_space">Color</div></td>
      <td> : </td>
      <td class="eb2g_uploaddocuments"><input name="Color" type="radio" />
        Color &nbsp; &nbsp;
        <input name="Color" type="radio" />
        Black & White</td>
    </tr>
    <tr class="eb2g_slede">
      <td><div class="eb2g_space">Book Language</div></td>
      <td> : </td>
      <td class="eb2g_uploaddocument"><select name="ctl00$ContentPlaceHolder1$ddlBookLanguage" id="ctl00_ContentPlaceHolder1_ddlBookLanguage" tabindex="16" class="textbox1">
          <option value="0">-- Select --</option>
          <option value="1">English</option>
          <option value="2">Spanish</option>
          <option value="3">French</option>
          <option value="4">German</option>
          <option value="5">Arabic</option>
          <option value="6">Hebrew</option>
          <option value="7">Other</option>
        </select></td>
    <tr class="eb2g_slede">
      <td><div class="eb2g_space">Project Completion Date</div></td>
      <td> : </td>
      <td class="eb2g_uploaddocument"><input name="date1" id="date1" class="date-pick" /></td>
    </tr>
    <tr class="eb2g_slede">
      <td width="287"><div class="eb2g_space">Enter File Name</div></td>
      <td width="32"> : </td>
      <td width="671" class="eb2g_uploaddocumentlist"><input type="text" /></td>
    </tr>
    <tr class="eb2g_slede">
      <td><div class="eb2g_space">Select File</div></td>
      <td> : </td>
      <td><input type="file" /></td>
    </tr>
    <tr class="eb2g_slede">
      <td><div class="eb2g_space">File Description</div></td>
      <td> : </td>
      <td class="eb2g_uploaddocument"><textarea cols="32" rows="7" name="content" id="content"></textarea>
        <div class="eb2g_maxcha" align="right"> <font size="1.75px" color="gray"> <i>Max 250 characters only allowed.</i> </font> <span style="color:Gray"></div></td>
    </tr>
    <tr class="eb2g_numberofmanuscripts">
      <td colspan="3" align="right"><img src="images/btnBack.jpg" width="117" height="30" alt="edit"  value="Reload Page" onClick="window.location.reload();editPay();" /> &nbsp; &nbsp; <img src="images/proceed.jpg" alt="proceed" width="117" height="30" style=" margin-right:20px;" align="right" onclick="con();resizeIframe()" /> </td>
    </tr>
  </table>--%>
        <%--<table id="tabEbook1" width="990" border="1" bordercolor="#E1E1E1" cellspacing="0" cellpadding="0">
    <tr>
      <td colspan="5" scope="col"><table width="100%" border="0" cellspacing="0" cellpadding="5">
          <tr>
            <td width="45%" valign="bottom"><img src="images/scart.png" width="40" height="30" alt="shoping cart" />CART ID: <span style="color:#ff0000">xxxxxxxx</span></td>
            <td width="55%" valign="bottom"><!--Title&nbsp;&nbsp;&nbsp; : <span class="productHold">Mango Masala</span>--></td>
          </tr>
          <tr>
            <td width="45%" valign="bottom">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Product: <span class="productHold">Simple eBook Apps</span></td>
            <td width="55%" valign="bottom"><!--Author: <span class="productHold">Ranjini Rao</span>--></td>
          </tr>
        </table></td>
    </tr>
    <tr>
      <th scope="col">S.No</th>
      <th scope="col">Item</th>
      <th scope="col">Quantity</th>
      <th scope="col">Unit Cost (USD)</th>
      <th scope="col">Total Cost(USD)</th>
    </tr>
    <tr>
      <td>1.</td>
      <td>IPad </td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>2.</td>
      <td>IPhone</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>3.</td>
      <td>Android Tablets</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>4.</td>
      <td>Android Phones</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>5.</td>
      <td class="eb2g_Additonaloption_cart" colspan="4">Customizations</td>
    </tr>
    <tr>
      <td class="subHeads">a.</td>
      <td>Total Number of pages in the Book</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td class="subHeads">b.</td>
      <td>App Icon Creation</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td class="subHeads">c.</td>
      <td>Splash Page creation</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td class="subHeads">d.</td>
      <td>Read Aloud - Voice Integration</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td class="subHeads">e.</td>
      <td>Share with Social Media / Twitter</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td class="subHeads">f.</td>
      <td>Help with upload to App Store</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td colspan="3" align="right">Grand Total</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td colspan="3" align="right">&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td colspan="3" align="right">Discount on Base package value @ 10% /20%...</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td colspan="3" align="right">Total - Discount</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td colspan="3" align="right">Estimated product value</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td colspan="5" align="right"><img src="images/btnBack.jpg" width="117" height="30" alt="edit"  onclick="editPay1();"/> &nbsp; &nbsp; <img src="images/checkout_btn.jpg" width="117" height="30" alt="check out" /></td>
    </tr>
  </table>--%>
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
                                                <asp:Label ID="lblebookappscomplexebookappsoffer1" runat="server"></asp:Label>
                                                ' products get
                                                <asp:Label ID="lblebookappscomplexebookappsoffer1discount" runat="server"></asp:Label> Discount on base price' </li>
                                            <li>Select any '
                                                <asp:Label ID="lblebookappscomplexebookappsoffer2" runat="server"></asp:Label>
                                                ' products get
                                                <asp:Label ID="lblebookappscomplexebookappsoffer2discount" runat="server"></asp:Label> Discount on base price</li>
                                            <li>Select any '
                                                <asp:Label ID="lblebookappscomplexebookappsoffer3" runat="server"></asp:Label>
                                                ' products get
                                                <asp:Label ID="lblebookappscomplexebookappsoffer3discount" runat="server"></asp:Label> Discount on base price</li>
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
                                        <table>
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="Checkbox2" type="checkbox" service="1" title="ePUB Package" value="999" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappscomplexebookappsipad" runat="server" AutoPostBack="true" OnCheckedChanged="chkebookappssimpleebookappsipad_CheckedChanged" />
                                                    IPad </td>
                                                <td>$<asp:Label ID="lblebookappscomplexebookappsipadproductcost" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; Works only with IPad & IPad mini </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="eb2g_products_details_mobi">
                                        <table>
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="Checkbox3" type="checkbox" service="2" title="Mobi Package" value="999" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappscomplexebookappsiphone" runat="server" AutoPostBack="true" OnCheckedChanged="chkebookappssimpleebookappsipad_CheckedChanged" />
                                                    IPhone</td>
                                                <td>$<asp:Label ID="lblebookappscomplexebookappsiphoneproductcost" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; Works only with IPhone 3,4,5 </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="eb2g_products_details_epdf">
                                        <table>
                                            <tr class="store_name">
                                                <td width="220">
                                                   <%-- <input id="Checkbox4" type="checkbox" service="3" title="ePDF Package" value="999" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappscomplexebookappsandroidtablets" runat="server" AutoPostBack="true" OnCheckedChanged="chkebookappssimpleebookappsipad_CheckedChanged" />
                                                    Android Tablets</td>
                                                <td>$<asp:Label ID="lblebookappscomplexebookappsandroidtabletsproductcost" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; Works only with 10 inch and 7 inch</td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="eb2g_products_details_andriodphone">
                                        <table>
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="Checkbox5" type="checkbox" service="4" title="ePDF Package" value="999" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappscomplexebookappsandroidphones" runat="server" AutoPostBack="true" OnCheckedChanged="chkebookappssimpleebookappsipad_CheckedChanged" />
                                                    Android Phones</td>
                                                <td>$<asp:Label ID="lblebookappscomplexebookappsandroidphonesproductcost" runat="server"></asp:Label></td>
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
                                    <asp:TextBox ID="txtebookappscomplexebookappspackagecost" runat="server" ReadOnly="true"></asp:TextBox>
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
                    <table width="1000" cellspacing="0" class="customize_products">
                        <tr>
                            <td width="490">
                                <h4>Total Number of pages in the Book</h4>
                                <span class="Customize_totalnumber">Upto
                                    <asp:Label ID="lblebookappscomplexebookappscustpages" runat="server"></asp:Label>
                                    pages are included in the base price. <br />&nbsp;&nbsp;&nbsp;Each Additonal Animation pages will be billed at. $<asp:Label ID="lblebookappscomplexebookappscustpagescost" runat="server"></asp:Label>
                                    , either device </span></td>
                            <td width="100" align="center">
                               <%-- <input type="text" />--%>
                            <asp:TextBox ID="txtebookappscomplexebookappscustpages" runat="server" AutoPostBack="true" OnTextChanged="chkebookappssimpleebookappsipad_CheckedChanged"></asp:TextBox>
                              <asp:FilteredTextBoxExtender ID="fteebookappscomplexebookappscustpages" runat="server" FilterType="Numbers"
    TargetControlID="txtebookappscomplexebookappscustpages" />
                            </td>
                            <td><asp:Label ID="lblebookappscomplexebookappsadditionalpages" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappscomplexebookappsaddtionalpagesunitcost" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappscomplexebookappsadditionalpagestotalcost" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="490">
                                <h4>Total Number of Animation pages</h4>
                                <span class="Customize_totalnumber">Upto
                                    <asp:Label ID="lblebookappscomplexebookappscustanimationpages" runat="server"></asp:Label>
                                    pages are included in the base price.<br />
                                    &nbsp;&nbsp;&nbsp;Each Additonal Animation pages will be billed at. $<asp:Label ID="lblebookappscomplexebookappscustanimationpagescost" runat="server"></asp:Label>
                                    , either device </span></td>
                            <td width="100" align="center">
                                <%--<input type="text" />--%>
                                <asp:TextBox ID="txtebookappscomplexebookappscustanimationpages" runat="server" AutoPostBack="true" OnTextChanged="chkebookappssimpleebookappsipad_CheckedChanged"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="fteebookappscomplexebookappscustanimationpages" runat="server" FilterType="Numbers"
    TargetControlID="txtebookappscomplexebookappscustanimationpages" />
                            </td>
                            <td><asp:Label ID="lblebookappscomplexebookappsadditionalanimationpages" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappscomplexebookappsadditionalanimationpagesunitcost" runat="server"></asp:Label></td> 
                            <td><asp:Label ID="lblebookappscomplexebookappsadditionalanimationpagestotalcost" runat="server"></asp:Label></td>
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
                                    <img src="images/2.png" alt="image02">
                                    <div>Time Soldiers</div>
                                </a>


                                <a href="#">
                                    <img src="images/3.png" alt="image03">
                                    <div>Time Soldiers</div>
                                </a>

                                <a href="#">
                                    <img src="images/4.png" alt="Pearl Harbor ">
                                    <div>Pearl Harbor </div>
                                </a>

                                <a href="#">
                                    <img src="images/5.png" alt="Pearl Harbor ">
                                    <div>Pearl Harbor </div>
                                </a>
                                <a href="#">
                                    <img src="images/6.png" alt="Pearl Harbor ">
                                    <div>Pearl Harbor </div>
                                </a>
                                <a href="#">
                                    <img src="images/7.png" alt="Pearl Harbor ">
                                    <div>Pearl Harbor </div>
                                </a>
                                <a href="#">
                                    <img src="images/8.png" alt="Pearl Harbor ">
                                    <div>Pearl Harbor </div>
                                </a>
                                <a href="#">
                                    <img src="images/9.png" alt="Pearl Harbor ">
                                    <div>Pearl Harbor </div>
                                </a>

                            </div>
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
        
        <%--<table class="eb2g_uploadspcdoc" style="display: none;" id="complexeBook" width="990" border="0" cellspacing="0" cellpadding="0" bordercolor="#E1E1E1">
            <tr>
                <th scope="col" colspan="3">Upload Manuscript Documents</th>
            </tr>
            <tr class="eb2g_slede">
                <td>
                    <br />
                    <div class="eb2g_space">Title</div>
                </td>
                <td>
                    <br />
                    : </td>
                <td class="eb2g_uploaddocumentlist">
                    <br />
                    <input type="text" /></td>
            </tr>
            <tr class="eb2g_slede">
                <td>
                    <div class="eb2g_space">Author</div>
                </td>
                <td>: </td>
                <td class="eb2g_uploaddocumentlist">
                    <input type="text" /></td>
            </tr>
            <tr class="eb2g_slede">
                <td>
                    <div class="eb2g_space">Color</div>
                </td>
                <td>: </td>
                <td class="eb2g_uploaddocuments">
                    <input name="Color" type="radio" />
                    Color &nbsp; &nbsp;
        <input name="Color" type="radio" />
                    Black & White</td>
            </tr>
            <tr class="eb2g_slede">
                <td>
                    <div class="eb2g_space">Book Language</div>
                </td>
                <td>: </td>
                <td class="eb2g_uploaddocument">
                    <select name="ctl00$ContentPlaceHolder1$ddlBookLanguage" id="Select1" tabindex="16" class="textbox1">
                        <option value="0">-- Select --</option>
                        <option value="1">English</option>
                        <option value="2">Spanish</option>
                        <option value="3">French</option>
                        <option value="4">German</option>
                        <option value="5">Arabic</option>
                        <option value="6">Hebrew</option>
                        <option value="7">Other</option>
                    </select></td>
                <tr class="eb2g_slede">
                    <td>
                        <div class="eb2g_space">Project Completion Date</div>
                    </td>
                    <td>: </td>
                    <td class="eb2g_uploaddocument">
                        <input name="date1" id="Text2" class="date-pick" /></td>
                </tr>
                <tr class="eb2g_slede">
                    <td width="287">
                        <div class="eb2g_space">Enter File Name</div>
                    </td>
                    <td width="32">: </td>
                    <td width="671" class="eb2g_uploaddocumentlist">
                        <input type="text" /></td>
                </tr>
                <tr class="eb2g_slede">
                    <td>
                        <div class="eb2g_space">Select File</div>
                    </td>
                    <td>: </td>
                    <td>
                        <input type="file" /></td>
                </tr>
                <tr class="eb2g_slede">
                    <td>
                        <div class="eb2g_space">File Description</div>
                    </td>
                    <td>: </td>
                    <td class="eb2g_uploaddocument">
                        <textarea cols="32" rows="7" name="content" id="Textarea1"></textarea>
                        <div class="eb2g_maxcha" align="right"><font size="1.75px" color="gray"> <i>Max 250 characters only allowed.</i> </font><span style="color: Gray"></div>
                    </td>
                </tr>
                <tr class="eb2g_numberofmanuscripts">
                    <td colspan="3" align="right">
                        <img src="images/btnBack.jpg" width="117" height="30" alt="edit" value="Reload Page" onclick="window.location.reload();complexeditPay();" />
                        &nbsp; &nbsp;
                            <img src="images/proceed.jpg" alt="proceed" width="117" height="30" style="margin-right: 20px;" align="right" onclick="complexecart();resizeIframe()" />
                    </td>
                </tr>
        </table>--%>
        <%--<table id="complexeBookcart" style="display: none;" width="990" border="1" bordercolor="#E1E1E1" cellspacing="0" cellpadding="0">
            <tr>
                <td colspan="5" scope="col">
                    <table width="100%" border="0" cellspacing="0" cellpadding="5">
                        <tr>
                            <td width="45%" valign="bottom">
                                <img src="images/scart.png" width="40" height="30" alt="shoping cart" />CART ID: <span style="color: #ff0000">xxxxxxxx</span></td>
                            <td width="55%" valign="bottom">
                                <!--Title&nbsp;&nbsp;&nbsp; : <span class="productHold">Mango Masala</span>-->
                            </td>
                        </tr>
                        <tr>
                            <td width="45%" valign="bottom">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Product: <span class="productHold">Complex eBook Apps</span></td>
                            <td width="55%" valign="bottom">
                                <!--Author: <span class="productHold">Ranjini Rao</span>-->
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <th scope="col">S.No</th>
                <th scope="col">Item</th>
                <th scope="col">Quantity</th>
                <th scope="col">Unit Cost (USD)</th>
                <th scope="col">Total Cost(USD)</th>
            </tr>
            <tr>
                <td>1.</td>
                <td>IPad </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>2.</td>
                <td>IPhone</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>3.</td>
                <td>Android Tablets</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>4.</td>
                <td>Android Phones</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>5.</td>
                <td class="eb2g_Additonaloption_cart" colspan="4">Customizations</td>
            </tr>
            <tr>
                <td class="subHeads">a.</td>
                <td>Total Number of pages in the Book</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="subHeads">b.</td>
                <td>Total Number of Animation pages</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="3" align="right">Grand Total</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="3" align="right">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="3" align="right">Discount on Base package value @ 10% /20%...</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="3" align="right">Total - Discount</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="3" align="right">Estimated product value</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="5" align="right">
                    <img src="images/btnBack.jpg" width="117" height="30" alt="edit" onclick="complexeBookedit();" />
                    &nbsp; &nbsp;
                        <img src="images/checkout_btn.jpg" width="117" height="30" alt="check out" /></td>
            </tr>
        </table>--%>

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
                                                <asp:Label ID="lblebookappsfortextbooksoffer1" runat="server"></asp:Label>
                                                ' products get
                                                <asp:Label ID="lblebookappsfortextbooksoffer1discount" runat="server"></asp:Label>
                                                Discount on base price' </li>
                                            <li>Select any '
                                                <asp:Label ID="lblebookappsfortextbooksoffer2" runat="server"></asp:Label>
                                                ' products get
                                                <asp:Label ID="lblebookappsfortextbooksoffer2discount" runat="server"></asp:Label>
                                                Discount on base price</li>
                                            <li>Select any '
                                                <asp:Label ID="lblebookappsfortextbooksoffer3" runat="server"></asp:Label>
                                                ' products get
                                                <asp:Label ID="lblebookappsfortextbooksoffer3discount" runat="server"></asp:Label>
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
                                        <table>
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="Checkbox6" type="checkbox" service="1" title="ePUB Package" value="999" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappsfortextbooksipad" runat="server" AutoPostBack="true" OnCheckedChanged="chkebookappssimpleebookappsipad_CheckedChanged" />
                                                    IPad </td>
                                                <td>$<asp:Label ID="lblebookappsfortextbooksipadproductcost" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; Works only with IPad & IPad mini </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="eb2g_products_details_mobi">
                                        <table>
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="Checkbox7" type="checkbox" service="2" title="Mobi Package" value="999" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappsfortextbooksiphone" runat="server" AutoPostBack="true" OnCheckedChanged="chkebookappssimpleebookappsipad_CheckedChanged" />
                                                    IPhone</td>
                                                <td>$<asp:Label ID="lblebookappsfortextbooksiphoneproductcost" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; Works only with IPhone 3,4,5 </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="eb2g_products_details_epdf">
                                        <table>
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="Checkbox8" type="checkbox" service="3" title="ePDF Package" value="999" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappsfortextbooksandroidtablets" runat="server" AutoPostBack="true" OnCheckedChanged="chkebookappssimpleebookappsipad_CheckedChanged" />
                                                    Android Tablets</td>
                                                <td>$<asp:Label ID="lblebookappsfortextbooksandroidtabletsproductcost" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="product_details">&nbsp; Works only with 10 inch and 7 inch</td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="eb2g_products_details_andriodphone">
                                        <table>
                                            <tr class="store_name">
                                                <td width="220">
                                                    <%--<input id="Checkbox9" type="checkbox" service="4" title="ePDF Package" value="999" name="PackageName" style="margin-left: 15px;" />--%>
                                                    <asp:CheckBox ID="chkebookappsfortextbooksandroidphones" runat="server" AutoPostBack="true" OnCheckedChanged="chkebookappssimpleebookappsipad_CheckedChanged" />
                                                    Android Phones</td>
                                                <td>$<asp:Label ID="lblebookappsfortextbooksandroidphonesproductcost" runat="server"></asp:Label></td>
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
                                    <%--<input type="text" id="Text3" />--%>
                                    <asp:TextBox ID="txtebookappsfortextbookspackagecost" runat="server" ReadOnly="true"></asp:TextBox>
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
                    <table width="1000" cellspacing="0" class="customize_products">
                        <tr>
                            <td width="490">
                                <h4>Total Number of pages in the Book</h4>
                                <span class="Customize_totalnumber">Upto
                                    <asp:Label ID="lblebookappsfortextbookscustpages" runat="server"></asp:Label>
                                    pages are included in the base price  <br />&nbsp;&nbsp;&nbsp;Each Additonal Animation pages will be billed at. $<asp:Label ID="lblebookappsfortextbookscustpagescost" runat="server"></asp:Label>
                                    , either device </span></td>
                            <td width="100" align="center">
                               <%-- <input type="text" />--%>
                             <asp:TextBox ID="txtebookappsfortextbookscustpages" runat="server" AutoPostBack="true" OnTextChanged="chkebookappssimpleebookappsipad_CheckedChanged"></asp:TextBox>
                             <asp:FilteredTextBoxExtender ID="fteebookappsfortextbookscustpages" runat="server" FilterType="Numbers"
    TargetControlID="txtebookappsfortextbookscustpages" />
                            </td>
                            <td><asp:Label ID="lblebookappsfortextbooksadditionalpages" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappsfortextbooksadditionalpagesunitcost" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappsfortextbooksadditionalpagestotalcost" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="490">
                                <h4>Interactive Self Assessments,Q & A</h4>
                                <span class="Customize_totalnumber">Upto
                                    <asp:Label ID="lblebookappsfortextbookscustinteractiveselfassessmentpages" runat="server"></asp:Label>
                                    pages are included in the base price.<br />
                                    &nbsp;&nbsp;&nbsp;Each Additonal Interactive Self Assessments,Q & A will be billed at. $<asp:Label ID="lblebookappsfortextbookscustinteractiveselfassessmentpagescost" runat="server"></asp:Label></span></td>
                            <td width="100" align="center">
                               <%-- <input type="text" />--%>
                            <asp:TextBox ID="txtebookappsfortextbookscustinteractiveandselfassessmentpages" runat="server" AutoPostBack="true" OnTextChanged="chkebookappssimpleebookappsipad_CheckedChanged"></asp:TextBox>
                             <asp:FilteredTextBoxExtender ID="fteebookappsfortextbooksinteractiveassessement" runat="server" FilterType="Numbers"
    TargetControlID="txtebookappsfortextbookscustinteractiveandselfassessmentpages" />
                            </td>
                            <td><asp:Label ID="lblebookappsfortextbooksadditionalinteractiveselfassessmentpages" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappsfortextbooksadditionalinteractiveselfassessmentunitcost" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappsfortextbooksadditionalinteractiveselfassessmenttotalcost" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="490">
                                <h4>Video & Audio Integration</h4>
                                <span class="Customize_totalnumber">Upto
                                    <asp:Label ID="lblebookappsfortextbookscustavintergrationpages" runat="server"></asp:Label>
                                    pages are included in the base price.
              <br />
                                    &nbsp;&nbsp;&nbsp;Each Additonal Video & Audio Integration will be billed at. $<asp:Label ID="lblebookappsfortextbookscustavintergrationpagescost" runat="server"></asp:Label>
                                </span></td>
                            <td width="100" align="center">
                                
                                <asp:TextBox ID="txtebookappsfortextbookscustavelements" runat="server" AutoPostBack="true" OnTextChanged="chkebookappssimpleebookappsipad_CheckedChanged"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="fteebookappsfortextbooksaudioandvideo" runat="server" FilterType="Numbers"
    TargetControlID="txtebookappsfortextbookscustavelements" />
                            </td>
                            <td><asp:Label ID="lblebookappstextbooksadditionalavelements" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappstextbooksadditionalavelementsunitcost" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblebookappstextbooksadditionalavelementstotalcost" runat="server"></asp:Label></td>
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
                                    <img src="images/2.png" alt="image02">
                                    <div>Time Soldiers</div>
                                </a><a href="#">
                                    <img src="images/3.png" alt="image03">
                                    <div>Time Soldiers</div>
                                </a>
                            </div>
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
    </form>
</body>
</html>
