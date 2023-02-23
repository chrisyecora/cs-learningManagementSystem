using System;
namespace Library.LMSystem.Models;
public class Assignment
{
    public Assignment()
    {
        Name = string.Empty;
        Description = string.Empty;
    }
    // Id
    public int Id {
        get;
        set;
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
    // Total available points
    public int TotalPoints {
        get;
        set;
    }
    // Due date
    public DateTime DueDate {
        get;
        set;
    }

    public String Display => $"[{Id}] {Name}: {TotalPoints} points. Due {DueDate.Date}";
}

