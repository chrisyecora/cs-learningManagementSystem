using System;
namespace Library.LMSystem.Models;
public class Course {
    public Course() {
        Assignments = new List<Assignment>();
        Roster = new List<Person>();
        Modules = new List<Module>();
        CourseCode = string.Empty;
        Name = string.Empty;
        Description = string.Empty;
    }
    // Course code
    public String CourseCode {
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
    // Roster
    public List<Person> Roster {
        get;
        set;
    }
    // Assignments
    public List<Assignment> Assignments {
        get;
        set;
    }
    // Modules
    public List<Module> Modules {
        get;
        set;
    }
    // Announcements
    public List<Announcement> Announcements {
        get;
        set;
    }

    public String Display => $"{CourseCode}: {Name} - {Description}";

    public String ShortDisplay => $"{CourseCode}: {Name}";
}

