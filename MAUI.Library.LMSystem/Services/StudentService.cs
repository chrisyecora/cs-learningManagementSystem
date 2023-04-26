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

        public IEnumerable<Person> GetPeople() {
            return (IEnumerable<Person>)People;
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

        // RETURNS THE NUMBER OF QUALITY POINTS EARNED FOR A GIVEN COURSE
        // EX: 95% ==> A ==> 4 quality points
        public double CalcQualityPointsEarned(Course course, Student student) {
            // list will hold key val pairs of <groupWeight, avgGradeForGroup>
            List<KeyValuePair<double, double>> grades = new List<KeyValuePair<double, double>>();
            
            // loop through all groups
            foreach (var group in course.AssignmentGroups) {
                // skip uncategorized (default) assignment group)
                if (group.Name.Equals("Uncategorized")) {
                    continue;
                }
                int sumOfTotalPoints = 0;
                double groupGrades = 0;
                // loop through all assignments and find student's grades
                foreach (var assignment in group.Assignments) {
                    if (student.Grades.ContainsKey(assignment.Id)) {
                        groupGrades += student.Grades[assignment.Id];
                        sumOfTotalPoints += assignment.TotalPoints;
                    }
                }
                // cacluate averageForGroup and add the KV pair to list
                var averageForGroup = groupGrades / (double)sumOfTotalPoints;
                grades.Add(new KeyValuePair<double, double>(group.Weight, averageForGroup));
            }

            // compute total grade (represented as a raw percentage, ex: 0.95)
            double totalGrade = 0;
            grades.ForEach(pair => totalGrade += (pair.Key * pair.Value));
            totalGrade *= 100;
            double qualityPoints = 0;
            if (totalGrade >= 94) {
                // A
                qualityPoints = 4;
            } else if (totalGrade >= 90) {
                // A-
                qualityPoints = 3.75;
            } else if (totalGrade >= 87) {
                // B+
                qualityPoints = 3.25;
            } else if (totalGrade >= 84) {
                // B
                qualityPoints = 3;
            } else if (totalGrade >= 80) {
                // B-
                qualityPoints = 2.75;
            } else if (totalGrade >= 77) {
                // C+
                qualityPoints = 2.25;
            } else if (totalGrade >= 74) {
                // C
                qualityPoints = 2.00;
            } else if (totalGrade >= 70) {
                // C-
                qualityPoints = 1.75;
            } else if (totalGrade >= 67) {
                // D+
                qualityPoints = 1.25;
            } else if (totalGrade >= 63) {
                // D
                qualityPoints = 1.00;
            } else if (totalGrade >= 60) {
                // D-
                qualityPoints = 0.75;
            } else {
                // F
                qualityPoints = 0;
            }

            return qualityPoints;
        }

        public double CalcStudentGPA(List<Course> courses, Student student) {
            double gradeSum = 0;
            int totalCreditHours = 0;
            foreach (var course in courses) {
                totalCreditHours += course.CreditHours;
                var courseQualityPointsEarned = CalcQualityPointsEarned(course, student);
                gradeSum += (courseQualityPointsEarned * course.CreditHours);
            }

            double gpa = gradeSum / totalCreditHours;
            return gpa;
        }
    }
}

