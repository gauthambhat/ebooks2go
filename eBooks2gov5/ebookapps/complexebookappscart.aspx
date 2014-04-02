
<%--currently we are not using this page instead of this we are using complexebookappsfinalcart.aspx--%>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="complexebookappscart.aspx.cs" Inherits="eBooks2goV5.ebookapps.complexebookappscart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <table id="tabEbook1"  width="990" border="1" bordercolor="#E1E1E1" cellspacing="0" cellpadding="0">
            <tr>
                <td colspan="5" scope="col">
                    <table width="100%" border="0" cellspacing="0" cellpadding="5">
                        <tr>
                            <td width="45%" valign="bottom">
                                <img src="images/scart.png" width="40" height="30" alt="shoping cart" />CART ID: <span style="color: #ff0000"><asp:Label ID="lblcomplexebookappscartid" runat="server"></asp:Label></span></td>
                            <td width="55%" valign="bottom">
                                title:&nbsp;&nbsp;&nbsp;: <span class="ProductHold"><asp:Label ID="lblcomplexebookappstitle" runat="server"></asp:Label></span>
                            </td>
                        </tr>
                        <tr>
                            <td width="45%" valign="bottom">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Product: <span class="productHold"><asp:Label ID="lblcomplexebookappsproduct" runat="server"></asp:Label></span></td>
                            <td width="55%" valign="bottom">
                                Author: <span class="productHold"><asp:Label ID="lblcomplexebookappsauthor" runat="server"></asp:Label></span>
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
                <td><asp:Label ID="lblcomplexebookappsipadquantity" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblcomplexebookappsipadunitcost" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblcomplexebookappsipadtotalcost" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>2.</td>
                <td>IPhone</td>
                <td><asp:Label ID="lblcomplexebookappsiphonequantity" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblcomplexebookappsiphoneunitcost" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblcomplexebookappsiphonetotalcost" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>3.</td>
                <td>Android Tablets</td>
                <td><asp:Label ID="lblcomplexebookappsandroidtabletsquantity" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblcomplexebookappsandroidtabletsunitcost" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblcomplexebookappsandroidtabletstotalcost" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>4.</td>
                <td>Android Phones</td>
                <td><asp:Label ID="lblcomplexebookappsandroidphonesquantity" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblcomplexebookappsandroidphonesunitcost" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblcomplexebookappsandroidphonestotalcost" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>5.</td>
                <td class="eb2g_Additonaloption_cart" colspan="4">Customizations</td>
            </tr>
            <tr>
                <td class="subHeads">a.</td>
                <td>Total Number of pages in the Book</td>
                <td><asp:Label ID="lblcomplexebookappscustpagesquantity" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblcomplexebookappscustpagesunitcost" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblcomplexebookappscustpagestotalcost" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="subHeads">b.</td>
                <td>Total Number of Animation pages</td>
                <td><asp:Label ID="lblcomplexebookappscustanimationpagesquantity" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblcomplexebookappscustanimationpagesunitcost" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblcomplexebookappscustanimationpagestotalcost" runat="server"></asp:Label></td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td colspan="3" align="right">Grand Total</td>
                <td><asp:Label ID="lblcomplexebookappsgrandtotal" runat="server"></asp:Label></td>
            </tr>
            
            <tr>
                <td>&nbsp;</td>
                <td colspan="3" align="right">Discount on Base package value @ 10% /20%...</td>
                <td><asp:Label ID="lblcomplexebookappsdiscountonbasepkg" runat="server"></asp:Label></td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td colspan="3" align="right">Total - Discount</td>
                <td><asp:Label ID="lblcomplexebookappscartprice" runat="server"></asp:Label></td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td colspan="3" align="right">Estimated product value</td>
                <td><asp:Label ID="lblcomplexebookappsestimatedproductvalue" runat="server"></asp:Label></td>
            </tr>

            <tr>
                <td colspan="5" align="right">
                   <asp:ImageButton ID="Imgbtnback" runat="server" ImageUrl="../images/btnBack.jpg"
                            PostBackUrl="~/ebookapps/flupload.aspx?ID=4" />
                    &nbsp; &nbsp;
                        <img src="images/checkout_btn.jpg" width="117" height="30" alt="check out" /></td>
            </tr>

        </table>
    </div>
    </form>
</body>
</html>
