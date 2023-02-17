using System;
namespace Library.LMSystem.Models
{
    public class Student : Person
    {
        // Grades
        public Dictionary<String, float> Grades {
            get;
            set;
        }

        // Classification
        public String Classification {
            get;
            set;
        }

        public override String Display => $"[{Id}] {Name} - {Classification}";

        public Student()
        {
            Grades = new Dictionary<string, float>();
            Classification = string.Empty;
        }
    }
}

