<%@ Page Language="C#" AutoEventWireup="true" CodeFile="projectSingle.aspx.cs" Inherits="projectSingle" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Projects</title>
    <link href="stylePageSingle.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="jquery.mCustomScrollbar.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <script src="scripts/jquery.easing.1.3.js" type="text/javascript"></script>
    <script src="scripts/jquery.mousewheel.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="scripts/pop-ups.js"></script>
    <script type="text/javascript" src="scripts/nav.js"></script>
    <script src="Scripts/MovieReplace.js" type="text/javascript"></script>
</head>
<body id="bodyId" runat="server">
    <form runat="server">
    <hgroup id="hgroup" runat="server">
        <h4>
            <a href="http://www.ruppin.ac.il" target="_blank">לאתר מכללת רופין</a></h4>
    </hgroup>
    <div>
        <div>
            <nav>
                <%--תפריט--%>
                <ul id="menu" class="menu">
                    <li><a href="#" id="about" runat="server" class="buttomImg"><span class="active"></span>
                        <span class="wrap"><span class="link">פרטים כלליים</span> <span class="descr"></span>
                        </span></a></li>
                    <li><a href="#" id="blog" runat="server"><span class="active"></span><span class="wrap">
                        <span class="link">פרטי המערכת</span> <span class="descr"></span></span></a>
                    </li>
                    <li><a href="#" id="projects" runat="server"><span class="active"></span><span class="wrap">
                        <span class="link">סטודנטים &nbsp &nbsp</span> <span class="descr"></span></span>
                    </a></li>
                    <li><a href="#" id="contact" runat="server"><span class="active"></span><span class="wrap">
                        <span class="link">הלקוח &nbsp &nbsp &nbsp &nbsp</span> <span class="descr"></span>
                    </span></a></li>
                </ul>
            </nav>
        </div>
        <div id="mainDiv" runat="server">
        </div>
    </div>
    <section id="bg">
        <section id="overlay">
        </section>
        <a href="MainPageProjects.aspx" class="nextImageBtn" title="לדף הראשי"></a>
        <img src="images/gallery/bg.jpg" alt="Title of this pic" id="bgimg" /></section>
    <div id="preloader">
        <img src="images/ajax-loader_dark.gif" width="32" height="32" alt="" /></div>
    <div id="img_title">
    </div>
    <div id="toolbar">
    </div>
    <div id="thumbnails_wrapper" runat="server">
        <div id="outer_container" runat="server">
            <div class="thumbScroller" runat="server">
                <div id="container" class="container" runat="server">
                </div>
            </div>
        </div>
    </div>
<%--    <div id="popupIMG" class="popupIMG">
    
    </div>--%>
    <article id="popupAbout" class="popupAbout">
        <div class="customScrollBox">
            <div class="container">
                <div class="content" runat="server">
                    <a id="popupAboutClose">
                        <img src="images/cross.png" width="20" alt="" /></a>
                    <h1>
                        פרטים כללים</h1>
                    <asp:PlaceHolder ID="infoProjectDiv" runat="server"></asp:PlaceHolder>
                    <div id="div2" runat="server"></div>
                </div>
            </div>
            <div class="dragger_container">
                <div class="dragger">
                </div>
            </div>
            <a class="scrollUpBtn" href="#"></a><a class="scrollDownBtn" href="#"></a>
        </div>
    </article>
    <article id="popupProjects" class="popupProjects">
        <div class="customScrollBox">
            <div class="container">
                <div class="content" id="studentsDiv" runat="server">
                    <a id="popupProjectsClose">
                        <img src="images/cross.png" width="20" alt="" /></a>
                    <h1>
                        סטודנטים</h1>
                </div>
            </div>
            <div class="dragger_container">
                <div class="dragger">
                </div>
            </div>
            <a class="scrollUpBtn" href="#"></a><a class="scrollDownBtn" href="#"></a>
        </div>
    </article><%--בחירת סטודנטים--%>
    <article id="popupContact" class="popupContact">
        <div class="customScrollBox">
            <div class="container">
                <div class="content" id="costumersDiv" runat="server">
                </div>
            </div>
            <div class="dragger_container">
                <div class="dragger">
                </div>
            </div>
            <a class="scrollUpBtn" href="#"></a><a class="scrollDownBtn" href="#"></a>
        </div>
    </article>
    <article id="popupBlog" class="popupBlog">
        <div class="customScrollBox">
            <div class="container">
                <div class="content" id="systemDiv" runat="server">
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
    </form>
</body>
</html>
