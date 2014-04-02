
<%--currently we are not using this page, instead of this page we are using ebookfinalcart.aspx page.--%>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ebookcart.aspx.cs" Inherits="eBooks2goV5.pricing.ebookcart" %>

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
	padding:0.5em;
}
#tabEbook th, #tabEbook1 th {
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
#tabEbook > table, #tabEbook1 > table {
	border:0;
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
    <table id="tabEbook1" width="1000" border="1" bordercolor="#E1E1E1" cellspacing="0" cellpadding="0">
    <tr>
      <td colspan="5" scope="col"><table width="100%" border="0" cellspacing="0" cellpadding="5">
          <tr>
            <td width="45%" valign="bottom"><img src="../images/scart.png" width="40" height="30" alt="shoping cart" />CART ID:<asp:HiddenField ID="hdncopyrow" runat="server" /> <span style="color:#ff0000">
                <asp:Label ID="cartID" runat="server"></asp:Label></span></td>
            <td width="55%" valign="bottom">Title&nbsp;&nbsp;&nbsp; : <span class="productHold">
                <asp:Label ID="lbleBookTitle" runat="server"></asp:Label></span></td>
          </tr>
          <tr>
            <td width="45%" valign="bottom">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Product: <span class="productHold"><asp:Label ID="lbleBookproduct" runat="server"></asp:Label></span></td>
            <td width="55%" valign="bottom">Author: <span class="productHold"><asp:Label ID="lbleBookauthor" runat="server"></asp:Label></span></td>
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
      <td>ePUB</td>
      <td align="center"><asp:Label ID="lbleBookepubquantity" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID ="lbleBookepubunitcost" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID ="lbleBookepubtotalcost" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td>2.</td>
      <td>Mobi</td>
      <td align="center"><asp:Label ID="lbleBookmobiquantity" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID="lbleBookmobiunitcost" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID="lbleBookmobitotalcost" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td>3.</td>
      <td>ePDF</td>
      <td align="center"><asp:Label ID="lbleBookpdfquantity" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID="lbleBookpdfunitcost" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID="lbleBookpdftotalcost" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td>4.</td>
      <td class="eb2g_Additonaloption_cart" colspan="4">Customizations</td>
    </tr>
    <tr>
      <td class="subHeads">a.</td>
      <td>Total Number of pages in the Book</td>
      <td align="center"><asp:Label ID="lbleBookpagequantity" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID="lbleBookpageunitcost" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID="lbleBookpagetotalcost" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td class="subHeads">b.</td>
      <td>Total Number of Images in the Book</td>
      <td align="center"><asp:Label ID="lbleBookimagequantity" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID="lbleBookimageunitcost" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID="lbleBookimagetotalcost" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td class="subHeads">c.</td>
      <td> Total Number of Foot Notes &amp; End Notes Linking</td>
      <td align="center"><asp:Label ID="lbleBookfootandendnotesquantity" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID="lbleBookfootandendnotesunitcost" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID="lbleBookfootandendnotestotalcost" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td class="subHeads">d.</td>
      <td>Total Number of web links, Hyperlinks, email links</td>
      <td align="center"><asp:Label ID="lbleBooklinksquantity" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID="lbleBooklinksunitcost" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID="lbleBooklinkstotalcost" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td>5.</td>
      <td colspan="4" class="eb2g_Additonaloption_cart">Additional elements</td>
    </tr>
    <tr>
      <td class="subHeads">a.</td>
      <td>Nested TOC</td>
      <td align="center"><asp:Label ID ="lbleBooknestedtocquantity" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID ="lbleBooknestedtocunitcost" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID ="lbleBooknestedtoctotalcost" runat ="server"></asp:Label></td>
    </tr>
    <tr>
      <td class="subHeads">b.</td>
      <td> Drop Caps</td>
      <td align="center"><asp:Label ID="lbleBookdropcapsquantity" runat="server"></asp:Label></td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td class="subHeads">c.</td>
      <td>Colored Fonts</td>
      <td align="center"><asp:Label ID="lbleBookcoloredfontsquantity" runat="server"></asp:Label></td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td class="subHeads">d.</td>
      <td> Lists</td>
      <td align="center"><asp:Label ID="lbleBooklistsquantity" runat="server"></asp:Label></td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td class="subHeads">e.</td>
      <td>Multiple Sections and Sub-Sections</td>
      <td align="center"><asp:Label ID="lbleBooksectionsquantity" runat="server"></asp:Label></td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td class="subHeads">f.</td>
      <td> Call Outs</td>
      <td align="center"><asp:Label ID="lbleBookcalloutsquantity" runat="server"></asp:Label></td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td class="subHeads">g.</td>
      <td>Double Column Text</td>
      <td align="center"><asp:Label ID="lbleBookdoublecolumntextquantity" runat="server"></asp:Label></td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td class="subHeads">h.</td>
      <td> Centered Text</td>
      <td align="center"><asp:Label ID="lbleBookcenteredtextquantity" runat="server"></asp:Label></td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td class="subHeads">i.</td>
      <td>Text boxes with borders/varying colors</td>
      <td align="center"><asp:Label ID="lbleBookbordercolorquantity" runat="server"></asp:Label></td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>6.</td>
      <td>Audio &amp; Video elements</td>
      <td align="center"><asp:Label ID="lbleBookavelementsquantity" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID ="lbleBookavelementsunitcost" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID="lbleBookavelementstotalcost" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td>7.</td>
      <td>Cover design</td>
      <td align="center"><asp:Label ID="lbleBookcoverdesignquantity" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID="lbleBookcoverdesignunitcost" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID="lbleBookcoverdesigntotalcost" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td>8.</td>
      <td>EISBN</td>
      <td align="center"><asp:Label ID="lbleBookeisbnquantity" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID="lbleBookeisbnunitcost" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID="lbleBookeisbntotalcost" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td>9.</td>
      <td>Book publishing &amp; Distribution</td>
      <td align="center"><asp:Label ID="lbleBookdistributionquantity" runat="server"></asp:Label></td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>10.</td>
      <td>Marketing services</td>
      <td align="center"><asp:Label ID="lbleBookmarketingservicesquantity" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID="lbleBookmarketingservicesunitcost" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID="lbleBookmarketingservicestotalcost" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td colspan="3" align="right">Grand Total</td>
      <td align="center"><asp:Label ID="lbleBookgrandtotal" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td colspan="3" align="right">&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td colspan="3" align="right">Discount on Base package value @ 10% /20%...</td>
      <td align="center"><asp:Label ID="lbleBookdiscountonbasepkg" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td colspan="3" align="right">Total - Discount</td>
      <td align="center"><asp:Label ID="lbleBookcartprice" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td colspan="3" align="right">Estimated cart value</td>
      <td align="center"><asp:Label ID="lbleBookestimatedproductvalue" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td colspan="5" align="right"><asp:ImageButton ID="imgbtnback" runat="server" ImageUrl="../images/btnBack.jpg" PostBackUrl="~/pricing/flupload.aspx?ID=1"  width="117" height="30" alt="edit"  /> &nbsp; &nbsp; <asp:ImageButton ID="imgbtnebookcheckout" runat="server"  PostBackUrl="~/pricing/ebookfinalcart.aspx" ImageUrl="../images/checkout_btn.jpg" width="117" height="30" alt="check out" /></td>
    </tr>
  </table>
    </div>
    </form>
</body>
</html>
