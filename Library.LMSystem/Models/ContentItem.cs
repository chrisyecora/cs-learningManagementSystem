namespace Library.LMSystem.Models;
public class ContentItem
{
    public int Id {
        get;
        set;
    }

    public string? Name {
        get;
        set;
    }

    public string? Description {
        get;
        set;
    }

    public virtual string Display => $"{Name}: {Description}";
}
