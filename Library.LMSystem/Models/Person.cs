using System;
namespace Library.LMSystem.Models;
public class Person
{
    public Person() {
        Name = "JOHN DOE";
        Classification = "N/A";
        Grades = new Dictionary<string, float>();
    }
    // Name
    public String Name {
        get;
        set;
    }
    // Classification
    public String Classification {
        get;
        set;
    }
    // Grades
    public Dictionary<String, float> Grades {
        get;
        set;
    }
    // Display
    public String Display => $"{Name} - {Classification}";
}

