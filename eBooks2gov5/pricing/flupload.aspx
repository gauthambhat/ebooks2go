<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="flupload.aspx.cs" Inherits="eBooks2goV5.pricing.flupload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html>

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
    <link href='http://fonts.googleapis.com/css?family=Gloria+Hallelujah' rel='stylesheet'
        type='text/css'>
    <link href="../css/pricingpage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type='text/javascript' src="../js/jquery-css-transform.js"></script>
    <script type="text/javascript" src="../js/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../js/jquery.ui.accordion.js"></script>
    <style type="text/css">
        .divstyle {
            display: none;
            height: auto;
            width: auto;
        }
    </style>
    <link type='text/css' href='../css/pricingpage.css' rel='stylesheet' media='screen' />
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
                font-size: 0.8em;
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
            font-size: 0.8em;
            color: #000;
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

        .eb2g_space {
            float: left;
            margin-left: 100px;
            width: 170px;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="../js/modernizr.custom.53451.js"></script>
    <script type="text/javascript" src="../js/jquery.gallery.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
    <script src="../js/date.js"></script>
    <script src="../js/jquery.datePicker.js"></script>
    <script type="text/javascript" src="../js/jquery.datePicker.js"></script>
    <link href="../css/datePicker.css" rel="stylesheet" />
    <link href="../css/calendar.css" rel="stylesheet" />
    <script type="text/javascript" charset="utf-8">
        $(function () {
            $('.date-pick').datePicker({ clickInput: true })
        });
    </script>
    <%--eBooks2go Css End--%>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <table class="eb2g_uploadspcdoc" id="tabEbook" width="998" border="0" cellspacing="0" cellpadding="0" bordercolor="#E1E1E1">
                <tr>
                    <th scope="col" colspan="3">Upload Manuscript Documents</th>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblflmsg" ForeColor="Red" runat="server"></asp:Label></td>
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
                        <asp:TextBox ID="txtfltitle" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvfltitle" runat="server"
                            ErrorMessage="Please enter Title." ControlToValidate="txtfltitle" ForeColor="Red" ValidationGroup="flupload">
                        </asp:RequiredFieldValidator>


                    </td>
                </tr>
                <tr class="eb2g_slede">
                    <td>
                        <div class="eb2g_space">Author</div>
                    </td>
                    <td>: </td>
                    <td class="eb2g_uploaddocumentlist">
                        <asp:TextBox ID="txtflauthor" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvflauthor" runat="server"
                            ErrorMessage="Please enter Author." ControlToValidate="txtflauthor" ForeColor="Red" ValidationGroup="flupload">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="eb2g_slede">
                    <td>
                        <div class="eb2g_space">Color</div>
                    </td>
                    <td>: </td>
                    <td class="eb2g_uploaddocuments">
                        <asp:RadioButton ID="rbflcolor" Checked="true" runat="server" GroupName="color" />
                        Color &nbsp; &nbsp;
        <asp:RadioButton ID="rbflbandwcolor" runat="server" GroupName="color" />
                        Black & White</td>

                </tr>
                <tr class="eb2g_slede">
                    <td>
                        <div class="eb2g_space">Book Language</div>
                    </td>
                    <td>: </td>
                    <td class="eb2g_uploaddocument">
                        <asp:DropDownList ID="ddlflbooklang" runat="server">
                            <asp:ListItem Text="-- Select --" Value="0"></asp:ListItem>
                            <asp:ListItem Text="English" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Spanish" Value="2"></asp:ListItem>
                            <asp:ListItem Text="French" Value="3"></asp:ListItem>
                            <asp:ListItem Text="German" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Arabic" Value="5"></asp:ListItem>
                            <asp:ListItem Text="Hebrew" Value="6"></asp:ListItem>
                            <asp:ListItem Text="Other" Value="7"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvbooklang" runat="server"
                            ErrorMessage="Please Select Book Language." ControlToValidate="ddlflbooklang" ForeColor="Red" ValidationGroup="flupload">
                        </asp:RequiredFieldValidator>
                    </td>
                    <tr class="eb2g_slede">
                        <td>
                            <div class="eb2g_space">Project Completion Date</div>
                        </td>
                        <td>: </td>
                        <td class="eb2g_uploaddocument">
                            <%-- <input name="date1" id="date1" type="text" class="date-pick" /></td>--%>
                            <asp:TextBox ID="txtprojectdate" runat="server" CssClass="date-pick"></asp:TextBox>
                            <%-- <asp:ImageButton ID="imgbtnflcompletedate" runat="server" Height="25"  Width="25"  ImageUrl="~/images/calen.gif" />
          <ajax:CalendarExtender ID="ceflcompletedate" runat="server" TargetControlID="txtprojectdate" PopupButtonID="imgbtnflcompletedate" PopupPosition="BottomLeft"></ajax:CalendarExtender>--%>
                            <asp:RequiredFieldValidator ID="rfvprojectdate" runat="server"
                                ErrorMessage="Please Select Project Completion Date" ControlToValidate="txtprojectdate" ForeColor="Red" ValidationGroup="flupload">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr class="eb2g_slede">
                        <td width="287">
                            <div class="eb2g_space">Enter File Name</div>
                        </td>
                        <td width="32">: </td>
                        <td width="671" class="eb2g_uploaddocumentlist">
                            <asp:TextBox ID="txtflfilename" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvflfilename" runat="server"
                                ErrorMessage="Please Enter File Name" ControlToValidate="txtflfilename" ForeColor="Red" ValidationGroup="flupload">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr class="eb2g_slede">
                        <td>
                            <div class="eb2g_space">Select File</div>
                        </td>
                        <td>: </td>
                        <td>
                            <asp:FileUpload ID="flupselectfile" runat="server" /><asp:HiddenField ID="hdnflupload" runat="server" />
                            <asp:RequiredFieldValidator ID="rfvselectfile" runat="server"
                                ErrorMessage="Please Select File" ControlToValidate="flupselectfile" ForeColor="Red" ValidationGroup="flupload">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr class="eb2g_slede">
                        <td>
                            <div class="eb2g_space">File Description</div>
                        </td>
                        <td>: </td>
                        <td class="eb2g_uploaddocument">
                            <asp:TextBox ID="txtflfiledescription" runat="server" TextMode="MultiLine" Columns="32" Rows="7"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvflfiledescription" runat="server"
                                ErrorMessage="Please Enter File Description" ControlToValidate="txtflfiledescription" ForeColor="Red" ValidationGroup="flupload">
                            </asp:RequiredFieldValidator>
                            <div class="eb2g_maxcha" align="right"><font size="1.75px" color="gray"> <i>Max 250 characters only allowed.</i> </font><span style="color: Gray"></div>
                        </td>
                    </tr>
                    <tr class="eb2g_numberofmanuscripts">
                        <td colspan="3" align="right">
                            <asp:ImageButton ID="imgbtnflproceed" OnClick="imgbtnflproceed_Click" ValidationGroup="flupload" runat="server" ImageUrl="../images/proceed.jpg" alt="proceed" Width="117" Height="30" Style="margin-right: 20px;" align="right" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="imgbtnback" ImageUrl="~/images/btnBack.jpg" ImageAlign="Right" Style="margin-right: 20px;" runat="server" />
                        </td>
                    </tr>
            </table>

        </div>
    </form>
</body>
</html>
