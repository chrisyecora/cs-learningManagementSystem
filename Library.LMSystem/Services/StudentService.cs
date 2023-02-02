using System;
using Library.LMSystem.Models;

namespace Library.LMSystem.Services
{
    public class StudentService
    {
        public List<Person> Students {
            get;
            set;
        }

        public StudentService()
        {
            Students = new List<Person>();
        }

        public void AddStudent(Person person) {
            Students.Add(person);
        }

        public IEnumerable<Person> QueryByName(String name) {
            return Students.Where(s => s.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}

