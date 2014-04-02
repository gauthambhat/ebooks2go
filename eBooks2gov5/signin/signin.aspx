<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="eBooks2goV5.signin.signin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eBooks2go :: SignIn</title>
    <style type="text/css">
        @font-face
        {
            font-family: "Droid Sans";
            src: url('../DroidSans.ttf') format("truetype");
        }

        .errormessage
        {
            font-size:12px;
            font-family: "Droid Sans";
        }
    </style>
    <script  type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
  
    <link href="../signin/css/newSignIn.css" rel="stylesheet" type="text/css" />
  
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
<body class="container_bg">
    <form id="form1" runat="server" autocomplete="off">
        <div class="chromed-list-browser" style="height: 310px; width:400px; margin: 0 auto;">
            <div>
                <div align="center" style="width: 980px; margin: 0 auto;">
                    <p align="center" style="display: block;">
                        Sign in with your eBooks2go account.
                    <br />
                        Don't have a eBooks2go account? <span class="ebooks2go_createonaccount">
                            <asp:LinkButton ID="lnkSignUp"   OnClick="lnkSignUp_Click"  runat="server">Create one now!</asp:LinkButton></span>
                    </p>
                </div>
                <div align="center" style="width: 980px; float: left;">
                    <div class="ebooks2go_loginform">
                        <table>
                            <tr>
                                <tr align="center" width="100%" style="padding-left: 40px; color: #ff0000;">
                                    <asp:Label ID="lblmsg" Style="color: #ff0000;" runat="server"></asp:Label>
                                </tr>
                            </tr>
                            <tr>
                                <td colspan="4" class="ebooks2go_loginform_ItemName">
                                    <asp:TextBox ID="txtUserID" runat="server" autocomplete="Off" MaxLength="100" type="text"
                                        TabIndex="1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ValidationGroup="Register"
                                        ControlToValidate="txtUserID" ErrorMessage="Please Enter User Name(Email)" Display="Dynamic"
                                        SetFocusOnError="true" CssClass="errormessage"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ValidationGroup="Register"
                                        ControlToValidate="txtUserID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ErrorMessage="Please Enter Valid Email Address" Display="Dynamic" SetFocusOnError="true"
                                        CssClass="errormessage"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" class="ebooks2go_loginform_ItemName">
                                    <asp:TextBox ID="txtPWD" runat="server" Off="autocomplete" MaxLength="100" TextMode="Password"
                                        CssClass="textbox1" TabIndex="2"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ValidationGroup="Register"
                                        ControlToValidate="txtPWD" ErrorMessage="Please Enter Password" Display="Dynamic"
                                        SetFocusOnError="true" CssClass="errormessage"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td width="120">
                                    <asp:CheckBox ID="chkRememberMe" runat="server" TabIndex="3" Text="Remember Me" />
                                </td>
                                <td>&nbsp;
                                </td>
                                <td align="right">
                                    <a href="../forgot-password.html" target="_top" style="color: #147398; font-weight: normal; text-decoration: none;">Forgot your password?</a>
                                </td>
                                <td width="5">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="ebooks2go_submit" colspan="4">
                                    <asp:ImageButton ID="btnLogIn" runat="server" ImageUrl="../signin/images/login_btn.png" Text="LogIn&raquo;"
                                        ValidationGroup="Register" TabIndex="4" OnClick="btnLogIn_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
