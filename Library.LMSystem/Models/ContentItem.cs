namespace Library.LMSystem.Models;
public class ContentItem
{
    private protected static int id = 0;
    public int Id {
        get;
        private protected set;
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
