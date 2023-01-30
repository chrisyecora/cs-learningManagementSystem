using System;
namespace Library.LMSystem.Models;
public class Module
{
    public Module()
    {
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

