using System;
namespace Library.LMSystem.Models;
public class Assignment
{
    private static int id = 0;
    public Assignment()
    {
        Name = string.Empty;
        Description = string.Empty;
        Id = id++;
    }
    // Id
    public int Id {
        get;
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

