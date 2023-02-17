namespace Library.LMSystem.Models;
public class ContentItem
{
    public ContentItem() {
        Name = string.Empty;
        Description = string.Empty;
        Path = string.Empty;
    }

    public String Name {
        get;
        set;
    }

    public String Description {
        get;
        set;
    }

    public String Path {
        get;
        set;
    }

    public virtual string Display => $"{Name}: {Description}";
}
