using System;
namespace Library.LMSystem.Models;
public class Module
{
    public Module()
    {
        Content = new List<ContentItem>();
        Name = string.Empty;
        Description = string.Empty;
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

    public string ShortDisplay => $"{Name}: {Description}";

    public string Display =>
    $"{Name}: {Description}\n\t{string.Join("\n  ", Content.Select(content => content.Display))}";
}

