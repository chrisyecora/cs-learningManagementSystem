using System;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace App.LMSystem.Helpers
{
    public class StudentHelper
    {
        private StudentService studentService;
        public StudentHelper() {
            studentService = new StudentService();
        }

        public void CreateStudent() {
            // Creating a student
            var newPerson = new Student();
            Console.WriteLine("\n\n******************************\n");
            Console.WriteLine("Please enter the information below.\n");
            Console.Write("ID: ");
            newPerson.Id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Name: ");
            newPerson.Name = Console.ReadLine() ?? string.Empty;
            Console.Write("Classification: ");
            newPerson.Classification = Console.ReadLine() ?? string.Empty;
            if (studentService.AddStudent(newPerson)) {
                Console.WriteLine("\n....Student created successfully.");
            } else {
                Console.WriteLine("\n....Error creating student. Most likely, this id is taken.");
            }
            
        }

        public void UpdateStudent() {
            var selectedStudent = GetStudentByName();
            Console.WriteLine("Please enter the information below.");
            Console.WriteLine("NOTE: If you do not wish to modify the current property, press enter.");
            Console.WriteLine($"Current name: {selectedStudent.Name}");
            Console.Write("New name: ");
            var newName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine($"Current Classification: {selectedStudent.Classification}");
            Console.Write("New classification: ");
            var newClassification = Console.ReadLine() ?? string.Empty;

            studentService.UpdateStudent(selectedStudent, newName, newClassification);
            Console.WriteLine("\n....Student updated successfully.\n");
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

        public void ListAllStudents() {
            studentService.Students.ForEach(s => Console.WriteLine(s.Display));
        }

        public Student GetStudentByName() {
            // get course code from user
            Console.WriteLine("\n******************************\n");
            Console.Write("Enter student's first or last name: ");
            var name = Console.ReadLine() ?? string.Empty;

            // query
            var queryResult = studentService.QueryByName(name);

            // List results in a menu format for user
            Console.WriteLine("Which Student?");
            int i = 1;
            queryResult.ToList().ForEach(res => Console.WriteLine($"{i++}. {res.Display}"));
            Console.Write(">>> ");
            var userSelection = int.Parse(Console.ReadLine() ?? string.Empty);

            // get selected course
            return queryResult.ElementAt(userSelection - 1);
        }
        public Student GetStudentFromRoster(Course course) {
            int i = 1;
            var students = course.Roster.Where(person => person is Student).ToList();
            Console.WriteLine("Which student?");
            students.ForEach(stu => Console.WriteLine($"{i++}. {stu.Name}"));
            Console.Write(">>> ");
            var choice = int.Parse(Console.ReadLine() ?? "0");
            return (Student)students[choice - 1];
        }
    }
}