using System;
using Library.LMSystem.Models;
using Library.LMSystem.Services;
using MyApp;

namespace App.LMSystem.Helpers
{
    public class StudentHelper
    {
        private StudentService studentService;
        private ListNavigator<Person> listNavigator;
        public StudentHelper() {
            studentService = new StudentService();
            listNavigator = new ListNavigator<Person>(studentService.People);
        }

        public void CreatePerson() {
            Console.WriteLine("\n\n******************************\n");
            int i = 1;
            Console.WriteLine($"{i++}. Create Student");
            Console.WriteLine($"{i++}. Create Teaching Assistant");
            Console.WriteLine($"{i++}. Create Instructor");
            var userChoice = userIntPrompt();
            Console.WriteLine("\n\n******************************\n");
            Console.WriteLine("Please enter the information below.\n");
            var newPerson = new Person();
            Console.Write("Name: ");
            newPerson.Name = Console.ReadLine() ?? string.Empty;
            if (userChoice == 1) {
                // Creating a student
                var newStudent = new Student(newPerson);
                Console.Write("Classification (Freshman = F, Sophomore = P, Junior = J, Senior = S): ");
                var classification = Console.ReadLine() ?? string.Empty;
                newStudent.Classification = SetClassification(classification);
                if (studentService.AddPerson(newStudent)) {
                    Console.WriteLine("\n....Student created successfully.");
                } else {
                    Console.WriteLine("\n....Error creating student. Most likely, this id is taken.");
                }
            } else if (userChoice == 2) {
                // creating Teaching Assistant. Nothing to add here yet
                var newTA = new TeachingAssistant(newPerson);
                if (studentService.AddPerson(newTA)) {
                    Console.WriteLine("\n....Teaching Assistant created successfully.");
                } else {
                    Console.WriteLine("\n....Error creating teaching assistant. Most likely, this id is taken.");
                }
            } else {
                // creating Teaching Assistant. Nothing to add here yet
                var newInstructor = new Instructor(newPerson);
                if (studentService.AddPerson(newInstructor)) {
                    Console.WriteLine("\n....Instructor created successfully.");
                } else {
                    Console.WriteLine("\n....Error creating instructor. Most likely, this id is taken.");
                }
            }
        }

        public void UpdatePerson() {
            var selectedPerson = GetPersonByName();
            Console.WriteLine("Please enter the information below.");
            Console.WriteLine("NOTE: If you do not wish to modify the current property, press enter.");
            Console.WriteLine($"Current name: {selectedPerson.Name}");
            Console.Write("New name: ");
            var newName = Console.ReadLine() ?? string.Empty;

            var student = selectedPerson as Student;
            if (student != null) {
                Console.WriteLine($"Current Classification: {student.Classification}");
                Console.Write("New Classification (Freshman = F, Sophomore = P, Junior = J, Senior = S): ");
                var newClassification = Console.ReadLine() ?? string.Empty;
                newClassification = SetClassification(newClassification);
                studentService.UpdatePerson(student, newName, newClassification);
            } else {
                studentService.UpdatePerson(selectedPerson, newName);
            }
            Console.WriteLine("\n....Person updated successfully.\n");
        }

        public void GradeAssignment(CourseHelper courseHelper) {
            // find course
            var course = courseHelper.GetCourseByCode();
            // find student from course's roster
            var student = GetStudentFromRoster(course);
            // find assignment
            var assignment = courseHelper.GetAssignmentFromCourse(course);
            // update grade
            Console.Write($"Enter points earned ({assignment.TotalPoints} points possible): ");
            var grade = double.Parse(Console.ReadLine() ?? "0.00") / (double)assignment.TotalPoints;
            studentService.AddGrade(student, assignment.Id, grade);
            Console.WriteLine("\n....Grade successfully recorded.\n");
        }

        public void CalculateGPA(CourseHelper courseHelper) {
            var person = GetPersonByName();
            var student = person as Student;
            if (student != null) {
                var studentCourses = courseHelper.CoursesStudentIsTaking(student);
                var gpa = studentService.CalcStudentGPA(studentCourses, student);
                Console.WriteLine($"{student.Name}'s Term GPA: {String.Format("{0:0.00}", gpa.ToString())}");
            } else {
                Console.WriteLine($"Error. {person.Name} is not a student");
            }
        }

        private void NavigatePersons(List<Person>? queryList = null) {
            ListNavigator<Person> currentNavigator;
            if (queryList != null) {
                currentNavigator = new ListNavigator<Person>(queryList);
            } else {
                currentNavigator = listNavigator;
            }
            bool keepPaging = true;
            while (keepPaging) {
                foreach (var pair in currentNavigator.GetCurrentPage()) {
                    Console.WriteLine($"{pair.Value.Display}");
                }
                if (currentNavigator.HasPreviousPage) {
                    Console.Write("  p: previous  ");
                }
                if (currentNavigator.HasNextPage) {
                    Console.Write("  n: next  ");
                }
                Console.WriteLine("  x: exit  ");
                var userChoice = userStringPrompt();
                if (userChoice.Equals("p", StringComparison.InvariantCultureIgnoreCase)) {
                    currentNavigator.GoBackward();
                } else if (userChoice.Equals("n", StringComparison.InvariantCultureIgnoreCase)) {
                    currentNavigator.GoForward();
                } else {
                    keepPaging = false;
                } 
            }
        }

        public void ListAllStudents() {
            NavigatePersons(studentService.People.Where(p => p is Student).ToList());
        }

        public void ListAllPersons() {
            NavigatePersons();
        }

        public Person GetPersonByName() {
            // get course code from user
            Console.WriteLine("\n******************************\n");
            Console.Write("Enter person's first or last name: ");
            var name = Console.ReadLine() ?? string.Empty;

            // query
            var queryResult = studentService.QueryByName(name);

            // List results in a menu format for user
            Console.WriteLine("Which Person?");
            int i = 1;
            queryResult.ToList().ForEach(res => Console.WriteLine($"{i++}. {res.Display}"));
            Console.Write(">>> ");
            var userSelection = int.Parse(Console.ReadLine() ?? string.Empty);

            // get selected course
            return queryResult.ElementAt(userSelection - 1);
        }
        public Student GetStudentFromRoster(Course course) {
            int i = 1;
            var students = studentService.GetRoster(course).Where(person => person is Student);
            Console.WriteLine("Which student?");
            students.ToList().ForEach(stu => Console.WriteLine($"{i++}. {stu.Name}"));
            Console.Write(">>> ");
            var choice = int.Parse(Console.ReadLine() ?? "0");
            return (Student)students.ElementAt(choice - 1);
        }

        public string SetClassification(string value) {
            string returnVal = "";
            if (value.Equals("F", StringComparison.InvariantCultureIgnoreCase)) {
                returnVal = "Freshman";
            } else if (value.Equals("P", StringComparison.InvariantCultureIgnoreCase)) {
                returnVal = "Sophomore";
            } else if (value.Equals("J", StringComparison.InvariantCultureIgnoreCase)) {
                returnVal = "Junior";
            } else if (value.Equals("S", StringComparison.InvariantCultureIgnoreCase)) {
                returnVal = "Senior";
            } else {
                returnVal = string.Empty;
            }

            return returnVal;
        }

        public int userIntPrompt() {
            Console.Write(">>> ");
            return int.Parse(Console.ReadLine() ?? "1");
        }

        public string userStringPrompt() {
            Console.Write(">>> ");
            return Console.ReadLine() ?? string.Empty;
        }
    }
}