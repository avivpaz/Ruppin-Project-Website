using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.XPath;

/// <summary>
/// Summary description for groupsNames
/// </summary>
public class groupsNames
{
    List<string> l;
	public groupsNames()
	{
	l=new List<string>();
	}
    public List<string> ReadXML(string fname)
    {

        XPathNavigator nav;
        XPathDocument docNav;

        // Open the XML.
        docNav = new XPathDocument(fname);

        // Create a navigator to query with XPath.
        nav = docNav.CreateNavigator();
        XPathNodeIterator NodeIter;
        NodeIter = nav.Select("/files/file");
        while (NodeIter.MoveNext())
        {
           l.Add(NodeIter.Current.InnerXml);
        }

        return l;


    }
}