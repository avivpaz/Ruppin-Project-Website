using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
    public string   name;
    public string   logoUrl;
    public string   shortDescription;
    public List<string> interstedParties = new List<string>();
    public List<string> users = new List<string>();

    
	public Customer()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}