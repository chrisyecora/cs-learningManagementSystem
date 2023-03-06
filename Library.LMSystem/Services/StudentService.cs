using System;
using Library.LMSystem.Models;

namespace Library.LMSystem.Services
{
    public class StudentService
    {
        private static int personId = 0;
        public List<Person> People {
            get;
            set;
        }

       
        private HashSet<int> PersonIds {
            get;
            set;
        }

        public StudentService()
        {
            People = new List<Person>();
            PersonIds = new HashSet<int>();
        }

        public bool AddPerson(Person person) {
            person.Id = personId++;
            if (PersonIds.Add(person.Id)) {
                People.Add(person);
                return true;
            }
            return false;
        }

        public void UpdatePerson(Person person, string name, string? classification = null) {
            if (!name.Equals(string.Empty)) {
                person.Name = name;
            }

            var student = person as Student;
            if (classification != null && !classification.Equals(string.Empty) && student != null) {
                student.Classification = classification;
            }
        }

        public void AddGrade(Person person, int assignmentId, double grade) {
            var student = person as Student;
            if (student != null) {
                student.Grades.Add(assignmentId, grade);
            }
        }

        public Dictionary<int, double> GetStudentGrades(Student student) {
            return student.Grades;
        }

        public IEnumerable<Person> GetRoster(Course course) {
            return course.Roster;
        }
        public IEnumerable<Person> QueryByName(String name) {
            return People.Where(s => s.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}

