using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.XPath;


/// <summary>
/// Summary description for Project
/// </summary>
public class Project
{
    public string name;
    public string type;
    public List<string> tags = new List<string>();
    public string faculty;
    public Int16 year;
    public string shortDescription;
    public List<Customer> customers  = new List<Customer>();
    public string groupCode;
    public List<Student> students = new List<Student>();
    public string projectImageUrl;
    public string projectLandingPage;
    public string movie;
    public List<ScreenShot> screenshots = new List<ScreenShot>();
    public List<Module> modules = new List<Module>();
    public List<string> advisors = new List<string>();
    public List<Goal> goals = new List<Goal>();
    public List<string> technologies = new List<string>();
    public string challenges;
    public string personalNote;
    

	public Project()
	{
		//
		// TODO: Add constructor logic here
		//

	}

    public List<string> ReadProjectsXMLList(string fname)
    {
        List<string> fileNamesList = new List<string>();
        XPathNavigator nav;
        XPathDocument docNav;

        // Open the XML.
        docNav = new XPathDocument(fname);

        // Create a navigator to query with XPath.
        nav = docNav.CreateNavigator();

        XPathNodeIterator NodeIter = nav.Select("/files/file");
        while (NodeIter.MoveNext())
        {
            fileNamesList.Add(NodeIter.Current.InnerXml);
        }

        return fileNamesList;

    }

    public Project ReadXML(string fname)
    {

        XPathNavigator nav;
        XPathDocument docNav;

        // Open the XML.
        docNav = new XPathDocument(fname);

        // Create a navigator to query with XPath.
        nav = docNav.CreateNavigator();

        Project p = readProject(nav);

        return p;


    }

    protected Project readProject(XPathNavigator nav)
    {

        XPathNodeIterator NodeIter;

        Project p = new Project();



        p.name = nav.SelectSingleNode("/project/name").Value;
        p.type = nav.SelectSingleNode("/project/type").Value;
        NodeIter = nav.Select("/project/tags/tag");
        while (NodeIter.MoveNext())
        {
            p.tags.Add(NodeIter.Current.InnerXml);
        };
        p.faculty = nav.SelectSingleNode("/project/faculty").Value;
        p.year = Convert.ToInt16(nav.SelectSingleNode("/project/year").Value);
        p.shortDescription = nav.SelectSingleNode("/project/shortDescription").Value;
        try
        {
            p.projectImageUrl = nav.SelectSingleNode("/project/projectImageUrl").Value;
        }
        catch
        {
            p.projectImageUrl = "";
        }
        p.groupCode = nav.SelectSingleNode("project/students/groupCode").Value;
        p.projectLandingPage = nav.SelectSingleNode("/project/projectLandingPage").Value;
        p.movie = nav.SelectSingleNode("/project/movie").Value;
        NodeIter = nav.Select("/project/advisors/advisor");
        while (NodeIter.MoveNext())
        {
            p.advisors.Add(NodeIter.Current.InnerXml);
        }

        NodeIter = nav.Select("/project/technologies/technology");
        while (NodeIter.MoveNext())
        {
            p.technologies.Add(NodeIter.Current.GetAttribute("name", ""));
        }

        p.challenges = nav.SelectSingleNode("/project/challenges").Value;
        p.personalNote = nav.SelectSingleNode("/project/personalNote").Value;

        p.modules = readModules(nav);
        p.customers = readCustomers(nav);
        p.students = readStudents(nav);
        p.screenshots = readScreenshots(nav);
        p.goals = readGoals(nav);

        return p;
    }

    //-----------------------------------------------------------------------------------
    // Read the goals
    //-----------------------------------------------------------------------------------
    protected List<Goal> readGoals(XPathNavigator nav)
    {

        List<Goal> list = new List<Goal>();
        XPathNodeIterator NodeIter;

        NodeIter = nav.Select("/project/goals/goal");
        while (NodeIter.MoveNext())
        {
            Goal g = new Goal();
            g.description = NodeIter.Current.SelectSingleNode("description").Value;
            g.status = NodeIter.Current.SelectSingleNode("status").Value;
            list.Add(g);
        }
        return list;
    }

    //-----------------------------------------------------------------------------------
    // Read the ScreenShots
    //-----------------------------------------------------------------------------------

    protected List<ScreenShot> readScreenshots(XPathNavigator nav)
    {

        List<ScreenShot> list = new List<ScreenShot>();
        XPathNodeIterator NodeIter;

        NodeIter = nav.Select("/project/screenShots/screenShot");
        while (NodeIter.MoveNext())
        {
            ScreenShot s = new ScreenShot();
            s.description = NodeIter.Current.SelectSingleNode("description").Value;
            s.imageUrl = NodeIter.Current.SelectSingleNode("imageUrl").Value;
            list.Add(s);
        }
        return list;

    }

    //-----------------------------------------------------------------------------------
    // Read the Students
    //-----------------------------------------------------------------------------------
    protected List<Student> readStudents(XPathNavigator nav)
    {

        List<Student> list = new List<Student>();
        XPathNodeIterator NodeIter;

        NodeIter = nav.Select("/project/students/student");
        while (NodeIter.MoveNext())
        {
            Student s = new Student();
            s.name = NodeIter.Current.SelectSingleNode("name").Value;
            s.imageUrl = NodeIter.Current.SelectSingleNode("imageUrl").Value;
            list.Add(s);
        }
        return list;

    }

    //-----------------------------------------------------------------------------------
    // Read the Moduls
    //-----------------------------------------------------------------------------------

    protected List<Module> readModules(XPathNavigator nav)
    {
        List<Module> list = new List<Module>();
        XPathNodeIterator NodeIter;

        NodeIter = nav.Select("/project/modules/module");
        while (NodeIter.MoveNext())
        {
            Module m = new Module();
            m.name = NodeIter.Current.SelectSingleNode("name").Value;
            m.description = NodeIter.Current.SelectSingleNode("description").Value;
            XPathNodeIterator featureIter = NodeIter.Current.Select("features/feature");
            while (featureIter.MoveNext())
            {
                m.features.Add(featureIter.Current.InnerXml);
            }
            list.Add(m);
        }
        return list;
    }

    //-----------------------------------------------------------------------------------
    // Read the Customers
    //-----------------------------------------------------------------------------------
    protected List<Customer> readCustomers(XPathNavigator nav)
    {
        XPathNodeIterator NodeIter;
        List<Customer> list = new List<Customer>();

        NodeIter = nav.Select("/project/customer");
        while (NodeIter.MoveNext())
        {
            Customer c = new Customer();
            c.name = NodeIter.Current.SelectSingleNode("name").Value;
            c.logoUrl = NodeIter.Current.SelectSingleNode("logoUrl").Value;
            c.shortDescription = NodeIter.Current.SelectSingleNode("shortDescription").Value;
            XPathNodeIterator userIter = NodeIter.Current.Select("users/user");
            while (userIter.MoveNext())
            {
                c.users.Add(userIter.Current.InnerXml);
            }
            XPathNodeIterator partyIter = NodeIter.Current.Select("interstedParties/party");
            while (partyIter.MoveNext())
            {
                c.interstedParties.Add(partyIter.Current.InnerXml);
            }

            list.Add(c);
        }

        return list;
    }
}