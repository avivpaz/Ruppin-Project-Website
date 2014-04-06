using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.IO;

/// <summary>
/// Summary description for Projects
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Projects : System.Web.Services.WebService {

    public Projects () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getProjectFullPath(string fullPath)
    {
        Project p = new Project();
        try
        {
            p = p.ReadXML(fullPath);
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }

        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonProject = js.Serialize(p);
        return jsonProject;
       
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getProject(string groupName) {
 
        string fname = Server.MapPath(".") + "/XmlFiles/" + groupName + ".xml";
        Project p = new Project();
        try
        {
            p = p.ReadXML(fname);
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }

        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonProject = js.Serialize(p);
        return jsonProject;
       
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getXmlFileList(string fname)
    {
        string fullName = Server.MapPath(".") + "/XmlFiles/" + fname + ".xml";
        Project p = new Project();
        List<string> fileList = p.ReadProjectsXMLList(fullName);
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonFileList = js.Serialize(fileList);
        return jsonFileList;
    }
}
