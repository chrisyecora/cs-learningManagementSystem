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

        private HashSet<int> StudentIds {
            get;
            set;
        }

        public StudentService()
        {
            Students = new List<Person>();
            StudentIds = new HashSet<int>();
        }

        public bool AddStudent(Person person) {
            if (StudentIds.Add(person.Id)) {
                Students.Add(person);
                return true;
            }
            return false;
        }

        public IEnumerable<Person> QueryByName(String name) {
            return Students.Where(s => s.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}

