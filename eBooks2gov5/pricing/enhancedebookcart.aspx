<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enhancedebookcart.aspx.cs"
    Inherits="eBooks2goV5.pricing.enhancedebookcart" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #tabEbook, #tabEbook1 {
            font-family: Verdana, Geneva, sans-serif;
            font-size: 0.8em;
            color: #5a5a5a;
            margin-left: -10px;
        }

            #tabEbook td, th, #tabEbook1 td, th {
                padding: 0.5em;
            }

            #tabEbook th, #tabEbook1 th {
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

        #tabEbook > table, #tabEbook1 > table {
            border: 0;
        }

        .eb2g_Additonaloption_cart {
            font-family: Trebuchet MS;
            color: #68b026;
            font-weight: bold;
            font-size: 20px;
            margin-bottom: 10px;
        }
    </style>
    <link href='http://fonts.googleapis.com/css?family=Arimo' rel='stylesheet' type='text/css'>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="tabEbook1" width="100%" border="1" bordercolor="#E1E1E1" cellspacing="0"
                cellpadding="0">
                <tr>
                    <td colspan="5" scope="col">
                        <table width="100%" border="0" cellspacing="0" cellpadding="5">
                            <tr>
                                <td width="45%" valign="bottom">
                                    <img src="../images/scart.png" width="40" height="30" alt="shoping cart" />CART
                                ID: <span style="color: #ff0000">
                                    <asp:Label ID="lblcartid" runat="server"></asp:Label></span>
                                </td>
                                <td width="55%" valign="bottom">Title&nbsp;&nbsp;&nbsp; : <span class="productHold">
                                    <asp:Label ID="lblEnhancedeBooktitle" runat="server"></asp:Label></span>
                                </td>
                            </tr>
                            <tr>
                                <td width="45%" valign="bottom">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Product: <span class="productHold">
                                    <asp:Label ID="lblEnhancedeBookproduct" runat="server"></asp:Label></span>
                                </td>
                                <td width="55%" valign="bottom">Author: <span class="productHold">
                                    <asp:Label ID="lblEnhancedeBookauthor" runat="server"></asp:Label></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <th scope="col">S.No
                    </th>
                    <th scope="col">Item
                    </th>
                    <th scope="col">Quantity
                    </th>
                    <th scope="col">Unit Cost (USD)
                    </th>
                    <th scope="col">Total Cost(USD)
                    </th>
                </tr>
                <tr>
                    <td>1.
                    </td>
                    <td>ePUB
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookepubquantity" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookepubunitcost" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookepubtotalcost" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>2.
                    </td>
                    <td>Mobi
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookmobiquantity" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookmobiunitcost" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookmobitotalcost" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>3.
                    </td>
                    <td>Nook
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBooknookquantity" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBooknookunitcost" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBooknooktotalcost" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>4.
                    </td>
                    <td class="eb2g_Additonaloption_cart" colspan="4">Customizations
                    </td>
                </tr>
                <tr>
                    <td class="subHeads">a.
                    </td>
                    <td>Total Number of pages in the Book
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookcustpagesquantity" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookcustpagesunitcost" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookcustpagestotalcost" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="subHeads">b.
                    </td>
                    <td>Total Number of web links, Hyperlinks, email links
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookcustlinksquantity" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookcustlinksunitcost" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookcustlinkstotalcost" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>5.
                    </td>
                    <td colspan="4" class="eb2g_Additonaloption_cart">Additional elements
                    </td>
                </tr>
                <tr>
                    <td class="subHeads">a.
                    </td>
                    <td>Nested TOC
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBooknestedtocquantity" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="subHeads">b.
                    </td>
                    <td>Drop Caps
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookdropcapsquantity" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="subHeads">c.
                    </td>
                    <td>Colored Fonts
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookcoloredfontsquantity" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="subHeads">d.
                    </td>
                    <td>Lists
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBooklistsquantity" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="subHeads">e.
                    </td>
                    <td>Multiple Sections and Sub-Sections
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBooksectionsquantity" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="subHeads">f.
                    </td>
                    <td>Call Outs
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookcalloutsquantity" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="subHeads">g.
                    </td>
                    <td>Double Column Text
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookdoublecolumntextquantity" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="subHeads">h.
                    </td>
                    <td>Centered Text
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookcenteredtextquantity" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="subHeads">i.
                    </td>
                    <td>Text boxes with borders/varying colors
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBooktextboxcolorsquantity" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>6.
                    </td>
                    <td>Audio &amp; Video elements
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookavelementsquantity" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookavelementsunitcost" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookavelementstotalcost" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>7.
                    </td>
                    <td>Text High Lights
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBooktexthighlightsquantity" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBooktexthighlightsunitcost" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBooktexthighlightstotalcost" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>8.
                    </td>
                    <td>Cover design
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookcoverdesignquantity" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookcoverdesignunitcost" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookcoverdesigntotalcost" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>9.
                    </td>
                    <td>EISBN
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookeisbnquantity" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookeisbnunitcost" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookeisbntotalcost" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>10.
                    </td>
                    <td>Book publishing &amp; Distribution
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookdistributionquantity" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>11.
                    </td>
                    <td>Marketing services
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookmarketingservicesquantity" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookmarketingservicesunitcost" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookmarketingservicestotalcost" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                    <td colspan="3" align="right">Grand Total
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookgrandtotal" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                    <td colspan="3" align="right">&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                    <td colspan="3" align="right">Discount on Base package value @ 10% /20%...
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookdiscountonbasepkg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                    <td colspan="3" align="right">Total - Discount
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBooktotaldiscount" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                    <td colspan="3" align="right">Estimated cart value
                    </td>
                    <td>
                        <asp:Label ID="lblEnhancedeBookestimatedcartvalue" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="right">
                        <asp:ImageButton ID="Imgbtnback" runat="server" ImageUrl="../images/btnBack.jpg"
                            PostBackUrl="~/pricing/flupload.aspx?ID=2" />&nbsp; &nbsp;<asp:ImageButton ImageUrl="../images/checkout_btn.jpg" PostBackUrl="~/pricing/enhancedebookfinalcart.aspx"
                                Width="117" runat="server" Height="30" alt="check out" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
