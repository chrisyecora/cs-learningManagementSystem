using System;
namespace Library.LMSystem.Models
{
    public class AssignmentGroup
    {
        public AssignmentGroup()
        {
            Assignments = new List<Assignment>();
        }
        public List<Assignment> Assignments {
            get;
            set;
        }
        public double Weight {
            get;
            set;
        }
        public string? Name {
            get;
            set;
        }

        public string Display => $"{Name} - {Weight * 100}%";
    }
}

