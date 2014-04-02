<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addcustomer.aspx.cs" Inherits="eBooks2goV5.customer.addcustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>

    <script src="SpryAssets/SpryValidationSelect.js" type="text/javascript"></script>
    <script src="js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="SpryAssets/SpryValidationTextField.js" type="text/javascript"></script>
    <script src="SpryAssets/SpryValidationPassword.js" type="text/javascript"></script>
    <script src="SpryAssets/SpryValidationConfirm.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/duplicateinfo.js"></script>
    <script type="text/javascript" src="js/forms.js"></script>
    <script type="text/javascript" src="js/unfold.js"></script>


    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/tooltipster.css" />
    <link href="css/media.css" rel="stylesheet" type="text/css" />
    <link href="css/users.css" rel="stylesheet" type="text/css" />


    <link href="SpryAssets/SpryValidationTextField.css" rel="stylesheet" type="text/css" />
    <link href="SpryAssets/SpryValidationPassword.css" rel="stylesheet" type="text/css" />
    <link href="SpryAssets/SpryValidationConfirm.css" rel="stylesheet" type="text/css" />
    <link href="SpryAssets/SpryValidationSelect.css" rel="stylesheet" type="text/css" />

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
    <style>
       .ErrorMsg
        {
            color:#CC3333; font-size:14px;
        }
        .customermsg
        {
            color: #8BA820;
    font-size: 14px;
    font-weight: bold;
    line-height: 90px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="users" width="100%" border="0" cellspacing="0" cellpadding="0">
                 <tr>
                    <th valign="middle" scope="row"> </th>
                    <td colspan="3" align="left">
                     <asp:Label ID="lblebookcustomermsg"  CssClass="ErrorMsg" runat="server"></asp:Label>
                         </td>
                </tr>
                <tr>
                    <th valign="middle" scope="row">Email: </th>
                    <td colspan="3" align="left"><span id="sprytextfield3">
                        <label for="email"></label>
                       <%-- <input type="text" name="email" id="email" />--%>
                        <asp:TextBox ID ="txtcustomeremail" runat="server" ></asp:TextBox>
                         <span class="textfieldInvalidFormatMsg">Invalid format.</span></span></td>
                </tr>
                <tr>
                    <th valign="middle" scope="row">Password: </th>
                    <td colspan="3" align="left"><span id="sprypassword1">
                        <label for="password"></label>
                       <%-- <input type="password" name="password" id="password" />--%>
                        <asp:TextBox ID="txtcustomerpassword" type="password" runat="server"></asp:TextBox>
                    </span></td>
                </tr>
                <tr>
                    <th valign="middle" scope="row">Repeat Password: </th>
                    <td colspan="3" align="left"><span id="spryconfirm1">
                        <label for="password_confirm"></label>
                       <%-- <input type="password" name="password_confirm" id="password_confirm" />--%>
                        <asp:TextBox ID="txtcustomerconfirmpassword"  type="password" runat="server"></asp:TextBox>
                        <span class="confirmInvalidMsg">The values don't match.</span></span></td>
                </tr>
                <tr>
                    <th valign="middle" scope="row">First Name: </th>
                    <td colspan="3" align="left"><span id="sprytextfield1">
                        <label for="f_name"></label>
                        <%--<input type="text" name="f_name" id="f_name" />--%>
                        <asp:TextBox ID="txtcustomerfirstname" runat="server"></asp:TextBox>
                    </span></td>
                </tr>
                <tr>
                    <th valign="middle" scope="row">Last Name: </th>
                    <td colspan="3" align="left"><span id="sprytextfield2">
                        <label for="l_name"></label>
                        <%--<input type="text" name="l_name" id="l_name" />--%>
                        <asp:TextBox ID="txtcustomerlastname" runat="server"></asp:TextBox>
                    </span></td>
                </tr>
                <tr>
                    <th valign="middle" scope="row">Company<span class="optional">(Optional)</span>: </th>
                    <td colspan="3" align="left">
                        <label for="comapny_name"></label>
                        <%--<input type="text" name="comapny_name" id="comapny_name" />--%>
                        <asp:TextBox ID="txtcustomercompany" runat="server"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <th valign="middle" scope="row">Mailing Address 1: </th>
                    <td colspan="3" align="left"><span id="sprytextfield4">
                        <label for="mail1"></label>
                        <%--<input type="text" name="mail1" id="mail1" />--%>
                        <asp:TextBox ID="txtcustomeraddressone" runat="server"></asp:TextBox>
                    </span></td>
                </tr>
                <tr>
                    <th valign="middle" scope="row">Mailing Address 2: </th>
                    <td colspan="3" align="left"><span id="sprytextfield5">
                        <label for="mailing2"></label>
                        <%--<input type="text" name="mailing2" id="mail2" />--%>
                        <asp:TextBox ID="txtcustomeraddresstwo" runat="server"></asp:TextBox>
                    </span></td>
                </tr>
                <tr>
                    <th valign="middle" scope="row">City: </th>
                    <td colspan="3" align="left"><span id="sprytextfield6">
                        <label for="city"></label>
                        <%--<input type="text" name="city" id="city" />--%>
                        <asp:TextBox ID="txtcustomercity" runat="server"></asp:TextBox>
                    </span></td>
                </tr>
                <tr>
                    <th valign="middle" scope="row">Country: </th>
                    <td colspan="3" align="left">
                        <span id="spryselect1">
                           <%-- <select name="country" id="countrySelect" onchange="displayPayTypes();">
                                <option value="-1">-Select Country-</option>
                                <option value="0">United States</option>
                                <option value="1">India</option>
                            </select>--%>
                            <asp:DropDownList ID="ddlcustomercountry" runat="server">
                                <asp:ListItem Text="-Select Country-" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="United States" Value="0"></asp:ListItem>
                                <asp:ListItem Text="India" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </span></td>
                </tr>
                <tr>
                    <th valign="middle" scope="row">State: </th>
                    <td colspan="3" align="left">
                        <label for="state"></label>
                        <span id="spryselect2">
                            <label for="state"></label>
                            <%--<select name="state" id="state">
                                <option value="-1">-Select State-</option>
                                <option value="0">California</option>
                                <option value="1">Arizona</option>
                            </select>--%>
                             <asp:DropDownList ID="ddlcustomerstate" runat="server">
                                <asp:ListItem Text="-Select State-" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="California" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Arizona" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </span></td>
                </tr>
                <tr>
                    <th height="40" valign="middle" scope="row">Zip: </th>
                    <td colspan="3" align="left"><span id="sprytextfield7">
                        <label for="zip"></label>
                        <%--<input type="text" name="zip" id="zip" />--%>
                        <asp:TextBox ID="txtcustomerzip" runat="server"></asp:TextBox>
                    </span></td>
                </tr>
                <tr>
                    <th valign="middle" scope="row">Phone: </th>
                    <td colspan="3" align="left"><span id="sprytextfield8">
                        <label for="phone"></label>
                        <%--<input type="text" name="phone" id="phone" />--%>
                        <asp:TextBox ID="txtcustomerphone" runat="server"></asp:TextBox>
                    </span></td>
                </tr>
                <tr>
                    <th valign="middle" scope="row">Fax: </th>
                    <td colspan="3" align="left"><span id="sprytextfield9">
                        <label for="fax"></label>
                       <%-- <input type="text" name="fax" id="fax" />--%>
                        <asp:TextBox ID="txtcustomerfax" runat="server"></asp:TextBox>
                    </span></td>
                </tr>
                <tr>
                    <th valign="middle" scope="row">Customer Type: </th>
                    <td colspan="3" align="left">
                        <label for="type"></label>
                        <%--<select name="type" id="type" onchange=" userTypeChange()">
                            <option value="0" selected="selected">Conversion</option>
                            <option value="1">Conversion &amp; Distribution</option>
                        </select>--%>
                        <asp:DropDownList ID="ddlcustomertype" runat="server">
                                <asp:ListItem Text="Conversion" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Conversion &amp; Distribution" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                       <%-- <input type="submit" name="btnSubmit" id="btnSubmit" runat="server" value="Add Customer" />--%>
                        <asp:Button ID="btncustomersubmit" runat="server" OnClick="btncustomersubmit_Click" name="btnSubmit" Text="Add Customer" value="Add Customer" />
                        <input type="reset" name="btnReset" id="btnReset" value="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
       
         <%--jquery dialog start--%>
           <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <%--<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"    rel="stylesheet" type="text/css" />--%>

        <link href="../signin/css/jquery-ui.css" rel="stylesheet" />
        <style>
            .no-close .ui-dialog-titlebar-close {
display: none;
}
        </style>
    <div>
     <script type="text/javascript">
         $(document).ready(function () {
             if ($('#hdnregistrationvalue').val() == '1') {
                 $("#modal_dialog").dialog({
                     title: "Registration",
                  dialogClass: 'no-close' ,
                     minWidth: 400,
                     position: ['center', 100],
                     modal: true,
                     buttons: {
                         OK: function () {
                             //$(this).dialog("close");
                             switch (getUrlVars()["ID"])
                             {
                                 case "1": window.location.href = "../../pricing/ebookinvoice.aspx";
                                     break;
                                 case "2": window.location.href = "../../pricing/enhancedebookinvoice.aspx";
                                     break;
                                 case "3": window.location.href = "../../ebookapps/simpleebookappsinvoice.aspx";
                                     break;
                                 case "4": window.location.href = "../../ebookapps/complexebookappsinvoice.aspx";
                                     break;
                                 case "5": window.location.href = "../../ebookapps/textbooksinvoice.aspx";
                                     break;
                                 default: $(this).dialog("close");

                             }
                             
                         }
                     },
                     
                 });
                 return false;
             }
         });
    </script>

        <script type="text/javascript">
            function getUrlVars()
            {
                var vars = [], hash;
                var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
                for(var i = 0; i < hashes.length; i++)
                {
                    hash = hashes[i].split('=');
                    vars.push(hash[0]);
                    vars[hash[0]] = hash[1];
                }
                return vars;
            }
        </script>
        
    <div id="modal_dialog" style="display: none;height:320px; width:800px;" align="center">
        <asp:Label ID="lbladdcustomermsg" CssClass="customermsg" runat="server"></asp:Label>
    </div>
        <asp:HiddenField Value="0" ID="hdnregistrationvalue" runat="server" />
    </div>
        <%--jquery dialog complete--%>

    </form>

    <script type="text/javascript">
        var sprytextfield3 = new Spry.Widget.ValidationTextField("sprytextfield3", "email", { validateOn: ["blur"] });
        var sprypassword1 = new Spry.Widget.ValidationPassword("sprypassword1", { validateOn: ["blur"] });
        var spryconfirm1 = new Spry.Widget.ValidationConfirm("spryconfirm1", "txtcustomerpassword", { validateOn: ["blur"] });
        var sprytextfield1 = new Spry.Widget.ValidationTextField("sprytextfield1", "none");
        var sprytextfield2 = new Spry.Widget.ValidationTextField("sprytextfield2", "none", { isRequired: false });
        var sprytextfield4 = new Spry.Widget.ValidationTextField("sprytextfield4", "none", { validateOn: ["blur"] });
        var sprytextfield5 = new Spry.Widget.ValidationTextField("sprytextfield5", "none", { isRequired: false });
        var sprytextfield6 = new Spry.Widget.ValidationTextField("sprytextfield6", "none", { validateOn: ["blur"] });
        var sprytextfield7 = new Spry.Widget.ValidationTextField("sprytextfield7", "none", { validateOn: ["blur"] });
        var sprytextfield8 = new Spry.Widget.ValidationTextField("sprytextfield8", "none", { validateOn: ["blur"] });
        var sprytextfield9 = new Spry.Widget.ValidationTextField("sprytextfield9", "none", { isRequired: false });
        var spryselect1 = new Spry.Widget.ValidationSelect("spryselect1", { validateOn: ["blur"], invalidValue: "-1" });
        var spryselect2 = new Spry.Widget.ValidationSelect("spryselect2", { validateOn: ["blur"], invalidValue: "-1" });
        var sprytextfield10 = new Spry.Widget.ValidationTextField("sprytextfield10", "none", { validateOn: ["blur"] });
        var sprytextfield11 = new Spry.Widget.ValidationTextField("sprytextfield11", "none", { validateOn: ["blur"] });
        var sprytextfield12 = new Spry.Widget.ValidationTextField("sprytextfield12", "none", { validateOn: ["blur"] });
        var sprytextfield13 = new Spry.Widget.ValidationTextField("sprytextfield13", "none", { validateOn: ["blur"] });
        var sprytextfield14 = new Spry.Widget.ValidationTextField("sprytextfield14", "none", { validateOn: ["blur"] });
        var sprytextfield15 = new Spry.Widget.ValidationTextField("sprytextfield15");
        var spryselect4 = new Spry.Widget.ValidationSelect("spryselect4", { invalidValue: "-1", validateOn: ["blur"] });
        var sprytextfield16 = new Spry.Widget.ValidationTextField("sprytextfield16", "none", { validateOn: ["blur"] });
        var sprytextfield17 = new Spry.Widget.ValidationTextField("sprytextfield17", "none", { isRequired: false });
        var sprytextfield18 = new Spry.Widget.ValidationTextField("sprytextfield18", "none", { validateOn: ["blur"] });
        var spryselect5 = new Spry.Widget.ValidationSelect("spryselect5", { validateOn: ["blur"], invalidValue: "-1" });
        var spryselect6 = new Spry.Widget.ValidationSelect("spryselect6", { validateOn: ["blur"], invalidValue: "-1" });
        var sprytextfield19 = new Spry.Widget.ValidationTextField("sprytextfield19", "none", { validateOn: ["blur"] });
        var sprytextfield20 = new Spry.Widget.ValidationTextField("sprytextfield20", "none", { validateOn: ["blur"] });
        var sprytextfield21 = new Spry.Widget.ValidationTextField("sprytextfield21", "none", { isRequired: false });
        var sprytextfield22 = new Spry.Widget.ValidationTextField("sprytextfield22", "none", { validateOn: ["blur"] });
        var sprytextfield23 = new Spry.Widget.ValidationTextField("sprytextfield23", "none", { validateOn: ["blur"] });

        var sprytextfield25 = new Spry.Widget.ValidationTextField("sprytextfield25", "none", { validateOn: ["blur"] });
        var sprytextfield26 = new Spry.Widget.ValidationTextField("sprytextfield26");
    </script>
    <script type="text/javascript" src="js/main.js"></script>
    <script src="js/jquery.tooltipster.js" type="text/javascript"></script>


</body>
</html>
