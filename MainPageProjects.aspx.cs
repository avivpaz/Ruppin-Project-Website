using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class MainPageProjects : System.Web.UI.Page
{
    List<Project> projects;
    protected void Page_Load(object sender, EventArgs e)
    {
        projects = new List<Project>();
        GetAllProjects();
        UploadAllLogoes();
    }
    private void GetAllProjects()
    {
        string fname1 = Server.MapPath(".") + "/XmlFiles/projectsFiles.xml";
        groupsNames gn = new groupsNames();
        List<string> l = new List<string>();
        l = gn.ReadXML(fname1);
        foreach (string pr in l)
        {
            projects.Add(loadProject(pr));
        }
    }
    private Project loadProject(string name)
    {

        string fname = Server.MapPath(".") + "/XmlFiles/" + name + ".xml";
        Project p = new Project();
        try
        {
            p = p.ReadXML(fname);
            return p;
        }
        catch (Exception ex)
        {
            Response.Write("There was an error in reading the XML: " + ex.Message);
            return p;
        }
    }
    protected void UploadAllLogoes()
    {
        foreach (Project pr in projects)
        {
            uploadImage(pr.name.Trim(), pr.projectImageUrl, pr.groupCode);
        }
    }//uploading all projects images to the scroller
    private void uploadImage(string name, string url, string code)
    {
        Panel panel1 = new Panel();
        Panel panel2 = new Panel();
        var a = new HtmlGenericControl("a");
        //a.ID = "about";
        a.Attributes.Add("class", "bottomImg");
        a.Attributes.Add("runat", "server");
        a.Attributes.Add("href", "#");
        panel1.CssClass = "content";
        panel1.ID = code;
        Image img = new Image();
        img.ImageUrl = url;
        img.Attributes["onerror"] = "this.src='picturs/images.jpg'";
        img.Attributes.Add("title", name.Trim());
        img.CssClass = "thumb";
        a.Controls.Add(img);
        panel2.Controls.Add(a);
        panel1.Controls.Add(panel2);
        imagesPH.Controls.Add(panel1);
    }//upload image to the page
    protected void sBtn_Click(object sender, EventArgs e)
    {
        string choose = Request.Form["valuesDDL"];
        imagesPH.Controls.Clear();
        for (int i = 0; i < projects.Count; i++)
        {
            switch (subjectDDl.SelectedIndex)
            {
                case 1:
                    foreach (Customer c in projects[i].customers)
                    {
                        if (choose == c.name)
                        {
                            uploadImage(projects[i].name, projects[i].projectImageUrl, projects[i].groupCode);
                        }
                    }
                    break;
                case 2:
                    foreach (string tech in projects[i].technologies)
                    {
                        if (choose == tech)
                        {
                            uploadImage(projects[i].name, projects[i].projectImageUrl, projects[i].groupCode);
                        }
                    }
                    break;
                case 3:
                    foreach (Student s in projects[i].students)
                    {
                        if (choose == s.name)
                        {
                            uploadImage(projects[i].name, projects[i].projectImageUrl, projects[i].groupCode);
                        }
                    }
                    break;
                case 4:
                    if (choose == projects[i].faculty)
                    {
                        uploadImage(projects[i].name, projects[i].projectImageUrl, projects[i].groupCode);
                    }
                    break;
                default:
                    break;

            }
        }
    }// filtering the projects
    protected void goToPBTN_Click(object sender, EventArgs e)
    {
        var f = Request["asas"];
        for (int i = 0; i < projects.Count; i++)
        {
            if (projects[i].name.Trim() == f)
            {
                Session["project"] = projects[i];
                Response.Redirect("projectSingle.aspx");
            }
        }
    }//redirect the page to the project page
    protected void noSBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("MainPageProjects.aspx");
    }//canceling the filter
}