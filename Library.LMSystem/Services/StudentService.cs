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
        public double CalcCourseGrade(Course course, Student student) {
            // list will hold key val pairs of <groupWeight, avgGradeForGroup>
            List<KeyValuePair<double, double>> grades = new List<KeyValuePair<double, double>>();
            
            // loop through all groups
            foreach (var group in course.AssignmentGroups) {
                // skip uncategorized (default) assignment group)
                if (group.Name.Equals("Uncategorized")) {
                    continue;
                }
                int numAssignments = group.Assignments.Count();
                double groupGrades = 0;
                // loop through all assignments and find student's grades
                foreach (var assignment in group.Assignments) {
                    groupGrades += student.Grades[assignment.Id];
                }
                // cacluate averageForGroup and add the KV pair to list
                var averageForGroup = groupGrades / numAssignments;
                grades.Add(new KeyValuePair<double, double>(group.Weight, averageForGroup));
            }

            // compute total grade (represented as a raw percentage, ex: 0.95)
            double totalGrade = 0;
            grades.ForEach(pair => totalGrade += (pair.Key * pair.Value));
            return totalGrade;
        }
    }
}

