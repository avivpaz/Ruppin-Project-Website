<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainPageProjects.aspx.cs"
    Inherits="MainPageProjects" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Projects</title>
    <link rel="stylesheet" href="style.css" type="text/css" media="screen" />
    <link href="jquery.mCustomScrollbar.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <script src="scripts/jquery.easing.1.3.js" type="text/javascript"></script>
    <script src="scripts/jquery.mousewheel.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="scripts/nav.js"></script>
    <script src="Scripts/MovieReplace.js" type="text/javascript"></script>
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
</head>
<body id="bodyId" runat="server">
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <hgroup id="hgroup" runat="server">
        <h1>
            פרוייקטי גמר - מערכות מידע</h1>
    </hgroup>
    <div runat="server">
        <div id="mainDivMain" runat="server">
            <div>
                <table id="tableDLL">
                    <tr>
                        <td>
                            <select id="subjectDDl" class="styled-select" onchange="UpdateDDL()" runat="server">
                                <option value="0" selected>בחר קטגוריה לסינון</option>
                                <option value="1">שם לקוח</option>
                                <option value="2">טכנולוגיה</option>
                                <option value="3">שם סטודנט</option>
                                <option value="4">שם מחלקה</option>
                            </select>
                        </td>
                        <td>
                            <select class="styled-select" id="valuesDDL" runat="server" name="valuesDDL">
                            </select>
                        </td>
                        <td>
                            <asp:Button ID="sBtn" runat="server" Text="לסינון" OnClick="sBtn_Click" Font-Names="Times New Roman" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:LinkButton ID="noSBTN" runat="server" ForeColor="Gray" Font-Names="Times New Roman"
                                Font-Size="X-Large" OnClick="noSBTN_Click">בטל סינון</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <section id="bg">
        <section id="overlay">
        </section>
        <img src="images/gallery/bg.jpg" alt="Title of this pic" id="bgimg" /></section>
    <div id="preloader">
        <img src="images/ajax-loader_dark.gif" width="32" height="32" alt="" /></div>
    <div id="toolbar">
    </div>
    <div id="thumbnails_wrapper" runat="server">
        <div id="outer_container" runat="server">
            <div id="Div1" class="thumbScroller" runat="server">
                <div id="container" class="container" runat="server">
                    <asp:PlaceHolder ID="imagesPH" runat="server"></asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>
    <article id="popupAbout" class="popupAbout">
        <div class="customScrollBox">
            <div class="container">
                <div id="Div2" class="content" runat="server">
                    <h1 id="h1Name" class="h1Name" runat="server">
                    </h1>
                    <div class="dataProject">
                    </div>
                </div>
                <div id="divBtn">
                    <asp:Button ID="goToPBTN" runat="server" Text="למעבר לדף הפרוייקט" OnClick="goToPBTN_Click" />
                </div>  
            </div>
            <div class="dragger_container">
                <div class="dragger">
                </div>
            </div>
            <a class="scrollUpBtn" href="#"></a><a class="scrollDownBtn" href="#"></a>
        </div>
    </article>
    <script type="text/javascript" src="scripts/gallery.js"></script>
    <script type="text/javascript" src="scripts/jquery.mCustomScrollbar.js"></script>
    <script src="Scripts/popupMainPage.js" type="text/javascript"></script>
    </form>
</body>
</html>
