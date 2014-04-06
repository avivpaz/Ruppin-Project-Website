/***************************/
//@Author: Adrian "yEnS" Mato Gondelle
//@website: www.yensdesign.com
//@email: yensamg@gmail.com
//@license: Feel free to use it, but keep this credits please!					
/***************************/
//About Page Pop Up
var popupAboutStatus = 0;
var projects;
var projectsList;
function loadPopupAbout() {
    if (popupAboutStatus == 0) {
        $("#popupAbout").fadeIn("slow");
        popupAboutStatus = 1;
    }
}

function disablePopupAbout() {
    if (popupAboutStatus == 1) {
        $("#popupAbout").fadeOut("slow");
        popupAboutStatus = 0;
    }
}

function centerPopupAbout() {
    var windowWidth = document.documentElement.clientWidth;
    var windowHeight = document.documentElement.clientHeight;
    var popupAboutHeight = $("#popupAbout").height();
    var popupAboutWidth = $("#popupAbout").width();
    $("#popupAbout").css({
        "position": "absolute",
        "top": windowHeight / 2 - popupAboutHeight / 2,
        "left": windowWidth / 2 - popupAboutWidth / 2
    });
}

function getFilesList() {
    $.ajax({ // ajax call starts
        url: 'Projects.asmx/getXmlFileList',   // JQuery loads serverside.php
        data: '{fname:"projectsFiles"}',    // name without the xml extension
        type: 'POST',
        dataType: 'json', // Choosing a JSON datatype
        contentType: 'application/json; charset = utf-8',
        success: function (data) // Variable data contains the data we get from serverside
        {
            var list = $.parseJSON(data.d);
            buildProjectsPage(list);
        }, // end of success
        error: function (e) {
            alert("failed in getXmlFileList :( " + e.responseText);
        } // end of error
    }) // end of ajax call
}
//----------------------------------------------------------------------------
function buildProjectsPage(list) {

    projects = new Array();
    projectsList = new Array();
    for (i = 0; i < list.length; i++) { // run on all the files in the list
        $.ajax({ // ajax call start
            url: 'Projects.asmx/getProject',
            data: '{groupName:"' + list[i] + '"}', // Send value of the group name
            dataType: 'json', // Choosing a JSON datatype for the data sent
            type: 'POST',
            async: false, // this is a synchronous call
            contentType: 'application/json; charset = utf-8', // for the data received
            success: function (data) // this method is called upon       success. Variable data contains the data we get from serverside
            {
                p = $.parseJSON(data.d); // parse the data as json
                projects[p.name.trim()] = p; // add it to the projects associative array
                projectsList.push(p);
            }, // end of success
            error: function (e) { // this function will be called upon failure
                alert("failed :( " + e.responseText);
            } // end of error
        }) // end of ajax call
    } // end of loop on all the projects
}
/**
* Array.prototype.[method name] allows you to define/overwrite an objects method
* needle is the item you are searching for
* this is a special variable that refers to "this" instance of an Array.
* returns true if needle is in the array, and false otherwise
*/
Array.prototype.contains = function (needle) {
    for (i in this) {
        if (this[i] === needle) return true;
    }
    return false;
}
function UploadingProjectInfo(name) {

    var p = projects[name];
    var str = "";
    var movie = movieReplaceer(p.movie);
    str += "<ul style='list-style-type: none'>";
    str += "<li><h3> קוד קבוצה </h3> " + p.groupCode + "</li>";
    str += "<li><h3> מחלקה </h3>" + p.faculty + "</li>";
    str += movie;
    str += "<li> " + p.shortDescription + "</li>";
    str += "</ul>";
    var input = document.createElement("input");
    input.id = "asas";
    input.name = "asas";
    input.type = "text";
    input.value = p.name;
    input.setAttribute("type", "hidden");
    $("h1.h1Name").empty();
    $("h1.h1Name").append(p.name);
    $("div.dataProject").empty();
    $("div.dataProject").append(input);
    $("div.dataProject").append(str);
}
function movieReplaceer(strMov) {
    var res = strMov.replace("watch?v=", "embed/");
    var res1 = res.replace("http:", "");
    res1 = "<iframe width='460' height='194'   src='" + res1 + "'></iframe>";
    return res1;
}
function UpdateDDL() {
    var list = new Array();
    var ddl = $("#valuesDDL");
    var ddl1 = $("#subjectDDl");
    ddl.empty();
    ddl.append("<option> בחר</option>");
    for (var i = 0; i < projectsList.length; i++) {
        switch (ddl1.val()) {
            case "1":
                {
                    for (var s = 0; s < projectsList[i].customers.length; s++) {
                        list.push(projectsList[i].customers[s].name);
                    }
                }
                break;
            case "2":
                {
                    for (var s = 0; s < projectsList[i].technologies.length; s++) {
                        var value = projectsList[i].technologies[s];
                        if (list.contains(value)) {
                        }
                        else {
                            list.push(projectsList[i].technologies[s]);
                        }
                    }
                }
                break;
            case "3":
                {
                    for (var s = 0; s < projectsList[i].students.length; s++) {
                        list.push(projectsList[i].students[s].name);
                    }
                }
                break;
            case "4":
                {
                    if (list.contains("BA") || list.contains("IE")) {
                    }
                    else {
                        list.push("BA");
                        list.push("IE");
                    }
                }
                break;
            default:
        }
    }
    list.sort();
    for (var i = 0; i < list.length; i++) {
        ddl.append("<option value='" + list[i] + "'>" + list[i] + "</option>");
    }
}
function upDateImages() {
    var ddl = $("#valuesDDL");
    var ddl1 = $("#subjectDDl");
    var bool
    switch (ddl1.val()) {
        case "1":
            for (var i = 0; i < projectsList.length; i++) {
                bool = 0;
                for (var s = 0; s < projectsList[i].customers.length; s++) {
                    if (projectsList[i].customers[s].name == ddl.val()) {
                        bool = 1;
                    }
                }
                if (bool == 0) {
                    var element = document.getElementById(projectsList[i].groupCode);
                    element.parentNode.removeChild(element);
                }
            }
            break;
        case 2:
            for (var i = 0; i < projectsList.length; i++) {

            }
            break;
        default:
    }
}
$(document).ready(function () {
    assas();
    getFilesList();
    $("#popupAbout").fadeOut();
    popupAboutStatus = 0;
    $(".bottomImg").click(function () {
        $("#popupAbout").css({
            "visibility": "visible"
        });
        UploadingProjectInfo($(this).find("img").attr("title").trim());
        centerPopupAbout();
        loadPopupAbout();
        $("#popupAbout").mCustomScrollbar("vertical", 400, "easeOutCirc", 1.05, "auto", "yes", "yes", 10);
    });
    $("#popupAboutClose").click(function () {
        disablePopupAbout();
    });
    $("#bg").click(function () {
        disablePopupAbout();
    });
    $(document).keyup(function (e) {
        if (e.keyCode === 27)
            disablePopupAbout();
    });
});

