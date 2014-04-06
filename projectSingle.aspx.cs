using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Net;

public partial class projectSingle : System.Web.UI.Page
{
    Project p;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           p = new Project();
            p = (Project)(Session["project"]);
            AddGroupName(p);
            AddProjectdescription(p);
            UploadProjectScreenShots(p);
            UploadTheStudents(p);
            GetTheProjectPicIntoTheMenu(p);
            GetCostumers(p);
            AddProjectInfo(p);
            AddSystemInfo(p);
        }
        catch (Exception)
        {

        }
    }
    protected void AddProjectdescription(Project p)
    {
        var h4 = new HtmlGenericControl("h6");
        h4.Style.Add("color", "black");
        h4.InnerHtml = p.shortDescription;
        mainDiv.Controls.Add(h4);
    }
    protected void AddGroupName(Project p)
    {
        var h1 = new HtmlGenericControl("h2");
        h1.InnerHtml = p.name;
        hgroup.Controls.Add(h1);

    }
    protected void UploadProjectScreenShots(Project p)//uploading the screenshots
    {
        foreach (ScreenShot ss in p.screenshots)
        {
            Panel panel1 = new Panel();
            Panel panel2 = new Panel();
            panel1.CssClass = "content";
            Image img = new Image();
            img.ImageUrl = ss.imageUrl;
            img.Attributes["onerror"] = "this.src='picturs/images.jpg'";
            img.Attributes.Add("title", ss.description);
            img.CssClass = "thumb";
            panel2.Controls.Add(img);
            panel1.Controls.Add(panel2);
            container.Controls.Add(panel1);
        }
    }
    protected void UploadTheStudents(Project p)//uploading the info about the students to the students tab
    {
        foreach (Student s in p.students)
        {
            var h2 = new HtmlGenericControl("h2");
            h2.InnerHtml = s.name;
            var pl = new HtmlGenericControl("p");
            pl.Attributes.Add("class", "nomargin");
            Image img = new Image();
            img.ImageUrl = s.imageUrl;
            img.CssClass = "image";
            pl.Controls.Add(img);
            studentsDiv.Controls.Add(h2);
            studentsDiv.Controls.Add(pl);
            Panel panel1 = new Panel();
            panel1.CssClass = "border";
            studentsDiv.Controls.Add(panel1);
        }
    }
    protected void GetTheProjectPicIntoTheMenu(Project p)
    {
        Image img = new Image();
        Image img1 = new Image();
        Image img2 = new Image();
        Image img3 = new Image();
        img.ImageUrl = p.projectImageUrl;
        img1.ImageUrl = p.projectImageUrl;
        img2.ImageUrl = p.projectImageUrl;
        img3.ImageUrl = p.projectImageUrl;
        img.Attributes["onerror"] = "this.src='picturs/images.jpg'";
        img1.Attributes["onerror"] = "this.src='picturs/images.jpg'";
        img2.Attributes["onerror"] = "this.src='picturs/images.jpg'";
        img3.Attributes["onerror"] = "this.src='picturs/images.jpg'";
        about.Controls.Add(img);
        contact.Controls.Add(img1);
        projects.Controls.Add(img2);
        blog.Controls.Add(img3);
    }
    protected void GetCostumers(Project p)//add Dynamically the costumers and the modules to the tab
    {
        var h1 = new HtmlGenericControl("h1");
        h1.InnerHtml = "הלקוח";
        costumersDiv.Controls.Add(h1);
        foreach (Customer cu in p.customers)
        {
            var h2 = new HtmlGenericControl("h2");
            h2.InnerHtml = cu.name;
            var p1 = new HtmlGenericControl("p");
            HtmlGenericControl ul = new HtmlGenericControl("ul");
            ul.Style.Add("list-style-type", "none");
            HtmlGenericControl li1 = new HtmlGenericControl("li");
            li1.InnerHtml = cu.shortDescription;
            HtmlGenericControl li2 = new HtmlGenericControl("li");
            int num = cu.interstedParties.Count;
            string interstedParties1 = "";
            for (int i = 0; i < num; i++)
            {
                if (i + 1 == num)
                    interstedParties1 += cu.interstedParties[i];
                else
                    interstedParties1 += cu.interstedParties[i] + ",";
            }
            Label l1 = new Label();
            l1.Text = "מעורבים:   ";
            l1.Style.Add("font-weight", "bold");
            li2.Controls.Add(l1);
            Label l2 = new Label();
            l2.Text = interstedParties1;
            li2.Controls.Add(l2);
            HtmlGenericControl li3 = new HtmlGenericControl("li");
            num = cu.users.Count;
            string users1 = "";
            for (int i = 0; i < num; i++)
            {
                if (i + 1 == num)
                    users1 += cu.users[i];
                else
                    users1 += cu.users[i] + ",";
            }
            Label l3 = new Label();
            l3.Text = "משתמשים:   ";
            l3.Style.Add("font-weight", "bold");
            li3.Controls.Add(l3);
            Label l4 = new Label();
            l4.Text = users1;
            li3.Controls.Add(l4);
            ul.Controls.Add(li1);
            ul.Controls.Add(li2);
            ul.Controls.Add(li3);
            p1.Controls.Add(ul);
            costumersDiv.Controls.Add(h2);
            costumersDiv.Controls.Add(p1);
            Image img = new Image();
            img.ImageUrl = cu.logoUrl;
            img.CssClass = "popupContactImg";
            costumersDiv.Controls.Add(img);
            Panel panel1 = new Panel();
            panel1.CssClass = "border";
            costumersDiv.Controls.Add(panel1);
        }
    }
    protected void AddProjectInfo(Project p)//add the general deatails of the venture
    {
        HtmlGenericControl ul = new HtmlGenericControl("ul");
        ul.Style.Add("list-style-type", "none");
        HtmlGenericControl li1 = new HtmlGenericControl("li");
        HtmlGenericControl li2 = new HtmlGenericControl("li");
        HtmlGenericControl li3 = new HtmlGenericControl("li");
        HtmlGenericControl li4 = new HtmlGenericControl("li");
        Label type = new Label();
        Label faculty = new Label();
        Label year = new Label();
        Label groupCode = new Label();
        Label advisors = new Label();
        type.Text = p.type;
        faculty.Text = p.faculty;
        year.Text = Convert.ToString(p.year);
        groupCode.Text = p.groupCode;
        Label l1 = new Label();
        l1.Text = "סוג פרוייקט:   ";
        l1.Style.Add("font-weight", "bold");
        li1.Controls.Add(l1);
        li1.Controls.Add(type);
        ul.Controls.Add(li1);
        Label l2 = new Label();
        l2.Text = "מחלקה:   ";
        l2.Style.Add("font-weight", "bold");
        li2.Controls.Add(l2);
        li2.Controls.Add(faculty);
        ul.Controls.Add(li2);
        Label l3 = new Label();
        l3.Text = "שנה:   ";
        l3.Style.Add("font-weight", "bold");
        li3.Controls.Add(l3);
        li3.Controls.Add(year);
        ul.Controls.Add(li3);
        Label l4 = new Label();
        l4.Text = "קוד קבוצה:   ";
        l4.Style.Add("font-weight", "bold");
        li4.Controls.Add(l4);
        li4.Controls.Add(groupCode);
        ul.Controls.Add(li4);
        infoProjectDiv.Controls.Add(ul);
        string movie = MovieReplicer(p.movie);
        div2.Controls.Add(new LiteralControl("<iframe src='" + movie + "' width='500' height='300' frameBorder='0'></iframe>"));
        Button btn = new Button();
        btn.ID = "webAppBtn";
        btn.Click += goToWebsite_Click;
        btn.OnClientClick = "goToWebsite";
        btn.Text = "לאתר האפליקצייה";
        div2.Controls.Add(btn);

    }
    protected void goToWebsite_Click(object sender, EventArgs e)
    {
        Response.Redirect(p.projectLandingPage);
    }
    private string MovieReplicer(string movie)
    {
        string url = "";
        url = movie.Replace("watch?v=", "embed/");
        url = url.Replace("http:", "");
        return url;

    }
    protected void AddSystemInfo(Project p)// adding all the system project information
    {
        AddModules(p);
        AddBorderPabel(systemDiv);
        AddTech(p);
        AddBorderPabel(systemDiv);
        AddTags(p);
        AddBorderPabel(systemDiv);
        AddGoals(p);
        AddBorderPabel(systemDiv);
    }
    private void AddModules(Project p)
    {
        var h1a = new HtmlGenericControl("h1");
        h1a.InnerHtml = "מודלים";
        systemDiv.Controls.Add(h1a);
        foreach (Module mo in p.modules)
        {
            var h2 = new HtmlGenericControl("h2");
            h2.InnerHtml = mo.name;
            var p1 = new HtmlGenericControl("p");
            HtmlGenericControl ul = new HtmlGenericControl("ul");
            ul.Style.Add("list-style-type", "none");
            HtmlGenericControl li1 = new HtmlGenericControl("li");
            li1.InnerHtml = mo.description;
            HtmlGenericControl li2 = new HtmlGenericControl("li");
            int num = mo.features.Count;
            string features = "";
            for (int i = 0; i < num; i++)
            {
                if (i + 1 == num)
                    features += mo.features[i];
                else
                    features += mo.features[i] + ",";
            }
            Label l1 = new Label();
            l1.Text = "עזרים:   ";
            l1.Style.Add("font-weight", "bold");
            li2.Controls.Add(l1);
            Label l2 = new Label();
            l2.Text = features;
            li2.Controls.Add(l2);
            ul.Controls.Add(li1);
            ul.Controls.Add(li2);
            p1.Controls.Add(ul);
            systemDiv.Controls.Add(h2);
            systemDiv.Controls.Add(p1);
        }
    }//adding the modules to the system div
    private void AddTech(Project p)
    {
        var h1a = new HtmlGenericControl("h1");
        h1a.InnerHtml = "טכנולוגיות";
        systemDiv.Controls.Add(h1a);
        int num = p.technologies.Count;
        Label l = new Label();
        l.Text = "";
        for (int i = 0; i < num; i++)
        {
            if (i + 1 == num)
                l.Text += " " + p.technologies[i];
            else
                l.Text += " " + p.technologies[i] + " ,";
        }
        systemDiv.Controls.Add(l);
    }
    private void AddTags(Project p)
    {
        var h1a = new HtmlGenericControl("h1");
        h1a.InnerHtml = "תגיות";
        systemDiv.Controls.Add(h1a);
        int num = p.tags.Count;
        Label l = new Label();
        l.Text = "";
        for (int i = 0; i < num; i++)
        {
            if (i + 1 == num)
                l.Text += " " + p.tags[i];
            else
                l.Text += " " + p.tags[i] + " ,";
        }
        systemDiv.Controls.Add(l);
    }
    private void AddGoals(Project p)
    {
        var h1a = new HtmlGenericControl("h1");
        h1a.InnerHtml = "מטרות";
        systemDiv.Controls.Add(h1a);
        foreach (Goal go in p.goals)
        {
            var h2 = new HtmlGenericControl("h4");
            h2.InnerHtml = go.status;
            var p1 = new HtmlGenericControl("p");
            HtmlGenericControl ul = new HtmlGenericControl("ul");
            ul.Style.Add("list-style-type", "none");
            HtmlGenericControl li1 = new HtmlGenericControl("li");
            li1.InnerHtml = go.description;
            ul.Controls.Add(li1);
            p1.Controls.Add(ul);
            systemDiv.Controls.Add(h2);
            systemDiv.Controls.Add(p1);
        }
    }
    private void AddBorderPabel(Control c)
    {
        Panel panel1 = new Panel();
        panel1.CssClass = "border";
        c.Controls.Add(panel1);
    }
}