using System;
namespace Library.LMSystem.Models;
public class Module
{
    public Module()
    {
        Content = new List<ContentItem>();
    }
    // Name
    public String Name {
        get;
        set;
    }
    // Description
    public String Description {
        get;
        set;
    }
    public List<ContentItem> Content {
        get;
        set;
    }
}

