<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="complexebookappsinvoice.aspx.cs" Inherits="eBooks2goV5.ebookapps.complexebookappsinvoice" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ebooks2go invoice</title>
    <style>
        #tabEbook, #tabEbook1
        {
            font-family: Verdana, Geneva, sans-serif;
            font-size: 0.8em;
            color: #5a5a5a;
            margin-left: -10px;
        }

            #tabEbook td, th, #tabEbook1 td, th
            {
                padding: 0.5em;
            }

            #tabEbook th, #tabEbook1 th
            {
                background-color: #aaaaaa;
                color: #fff;
                font-size: 12px;
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

        #tabEbook > table, #tabEbook1 > table
        {
            border: 0;
        }

        .eb2g_Additonaloption_cart
        {
            font-family: Trebuchet MS;
            color: #68b026;
            font-weight: bold;
            font-size: 20px;
            margin-bottom: 10px;
            column-span: all;
        }

        .ebook_aligncenter
        {
            color: #000;
        }
    </style>
    <link href='http://fonts.googleapis.com/css?family=Arimo' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" href="../css/invoice.css" />

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
    <form id="form1" runat="server">

        <div class="eb2g_invoice_page">
            <div class="eb2g_invoice_header">
                <img src="../images/ebooks2go-logo.jpg" alt="" />
            </div>
            <div class="eb2g_invoice_title" align="center">
                <h2>Invoice</h2>
            </div>

            <div class="eb2g_billing">
                <table width="500" border="1">
                    <tr height="40">
                        <td><strong>Bill To</strong></td>
                    </tr>
                    <tr height="120">
                        <td>
                            <asp:Label ID="lblcomplexebookappsinvoicecustomername" runat="server"></asp:Label><br />
                            <asp:Label ID="lblcomplexebookappsinvoicecustomeraddressone" runat="server"></asp:Label><br />
                            <asp:Label ID="lblcomplexebookappsinvoicecustomeraddresstwo" runat="server"></asp:Label><br />
                            <asp:Label ID="lblcomplexebookappsinvoicecustomercountry" runat="server"></asp:Label>
                            -
                            <asp:Label ID="lblcomplexebookappsinvoicecustomerzipcode" runat="server"></asp:Label>
                            <br />
                            <br />
                            <br />
                            Kind Attn: </td>
                    </tr>
                    <tr height="40">
                        <td>
                            <asp:Label ID="lblcomplexebookappsinvoicesigncustomername" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </div>

            <div class="eb2g_invoice_details" align="right">
                <table width="350" border="1">
                    <tr align="center">
                        <td>Invoice No</td>
                        <td><asp:Label ID="lblcomplexebookappsinvoicenumber" runat="server"></asp:Label></td>
                    </tr>
                    <tr align="center">
                        <td>Date</td>
                        <td><asp:Label ID="lblcomplexebookappsinvoicedate" runat="server"></asp:Label></td>
                    </tr>
                    <tr align="center">
                        <td>Inv Amount</td>
                        <td>SGD
                            <asp:Label ID="lblcomplexebookappsinvoicetotalamount" runat="server"></asp:Label></td>
                    </tr>
                    <tr align="center">
                        <td>P.O. No</td>
                        <td><asp:Label ID="lblcomplexebookappsponumber" runat="server"></asp:Label></td>
                    </tr>
                    <tr align="center">
                        <td>Invoice Send to</td>
                        <td>
                            <asp:Label ID="lblcomplexebookappsinvoiceinvoicesendtocustomername" runat="server"></asp:Label></td>
                    </tr>
                    <tr align="center">
                        <td>Sales Person</td>
                        <td>NJ</td>
                    </tr>
                    <tr align="center">
                        <td>Sales Order No</td>
                        <td>888</td>
                    </tr>
                    <tr align="center">
                        <td>Job No</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </div>

            <div class="eb2g_invoice_fulldetails">
                <table id="tabEbook1" width="910" border="1" bordercolor="#E1E1E1" cellspacing="0" cellpadding="0">
                    <tr>
                        <th scope="col">S.No</th>
                        <th scope="col">Item</th>
                        <th scope="col">Quantity</th>
                        <th scope="col">Unit Cost (USD)</th>
                        <th scope="col">Total Cost(USD)</th>
                    </tr>
                    <asp:Repeater ID="rptParent" runat="server" OnItemDataBound="rptParent_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("serialNo") %>'></asp:Label></td>
                                <td class="<%# getCSS(Eval("productid"))%>" colspan="<%# getStatus(Eval("productid"))%>"><%# Eval("productname") %></td>
                                <asp:Panel ID="pnlqty" Visible='<%# enablevisible(Eval("productid"))%>' runat="server">
                                    <td align="center">
                                        <asp:Label ID="lblcomplexebookappsepubquantity" runat="server"><%# Eval("qty") %></asp:Label></td>
                                    <td align="center">
                                        <asp:Label ID="lblcomplexebookappsepubunitcost" runat="server"><%# Eval("unitcost") %></asp:Label></td>
                                    <td align="center">
                                        <asp:Label ID="lblcomplexebookappsepubtotalcost" runat="server"><%# Eval("totalcost") %></asp:Label><asp:HiddenField ID="hdnproductId" runat="server" Value='<%# Eval("productid") %>' />
                                    </td>
                                </asp:Panel>
                            </tr>
                            <asp:Repeater ID="rptChild" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td class="subHeads"><%# Eval("alphaserial") %>.</td>
                                        <td><%# Eval("productname") %></td>
                                        <td align="center">
                                            <asp:Label ID="pagequanlblcomplexebookappstity" runat="server"><%# Eval("qty") %></asp:Label></td>
                                        <td align="center">
                                            <asp:Label ID="lblcomplexebookappspageunitcost" runat="server"><%# Eval("unitcost") %></asp:Label></td>
                                        <td align="center">
                                            <asp:Label ID="lblcomplexebookappspagetotalcost" runat="server"><%# Eval("totalcost") %></asp:Label></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td>&nbsp;</td>
                        <td colspan="3" align="right">Grand Total</td>
                        <td align="center">
                            <asp:Label ID="lblcomplexebookappsgrandtotal" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td colspan="3" align="right">Discount on Base package value @ 10% /20%...</td>
                        <td align="center">
                            <asp:Label ID="lblcomplexebookappsdiscountonbasepkg" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td colspan="3" align="right">Total - Discount</td>
                        <td align="center">
                            <asp:Label ID="lblcomplexebookappscartprice" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td colspan="3" align="right">Estimated cart value</td>
                        <td align="center">
                            <asp:Label ID="lblcomplexebookappsestimatedproductvalue" runat="server"></asp:Label></td>
                    </tr>

                </table>
            </div>

        </div>

    </form>
</body>

</html>
