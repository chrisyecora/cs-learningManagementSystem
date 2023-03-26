using System;
namespace Library.LMSystem.Models;
public class Person
{
    public Person() {
        Name = string.Empty;
    }
    public int Id {
        get;
        set;
    }
    // Name
    public String Name {
        get;
        set;
    }
    
    
    // Display
    public virtual String Display => $"[{Id}] {Name}";
}

