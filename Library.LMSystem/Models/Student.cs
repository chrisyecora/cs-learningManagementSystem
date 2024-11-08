﻿using System;
namespace Library.LMSystem.Models
{
    public class Student : Person
    {
        // Grades
        public Dictionary<int, double> Grades {
            get;
            set;
        }

        // Classification
        public string Classification {
            get;
            set;
        }

        public override String Display => $"[{Id}] {Name} - {Classification}";

        public Student()
        {
            Grades = new Dictionary<int, double>();
            Classification = string.Empty;
        }

        public Student(Person person) {
            Name = person.Name;
            Grades = new Dictionary<int, double>();
            Classification = string.Empty;
        }
    }
}

