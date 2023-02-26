using System;
using Library.LMSystem.Models;

namespace Library.LMSystem.Services
{
    public class StudentService
    {
        public List<Student> Students {
            get;
            set;
        }

        private HashSet<int> StudentIds {
            get;
            set;
        }

        public StudentService()
        {
            Students = new List<Student>();
            StudentIds = new HashSet<int>();
        }

        public bool AddStudent(Student student) {
            if (StudentIds.Add(student.Id)) {
                Students.Add(student);
                return true;
            }
            return false;
        }

        public void AddGrade(Student student, int assignmentId, double grade) {
            student.Grades.Add(assignmentId, grade);
        }

        public IEnumerable<Student> QueryByName(String name) {
            return Students.Where(s => s.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}

