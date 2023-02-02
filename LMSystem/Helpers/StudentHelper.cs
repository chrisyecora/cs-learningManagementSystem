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
            var newPerson = new Person();
            Console.WriteLine("\n\n******************************\n");
            Console.WriteLine("Please enter the information below.\n");
            Console.Write("Name: ");
            newPerson.Name = Console.ReadLine() ?? string.Empty;
            Console.Write("Classification: ");
            newPerson.Classification = Console.ReadLine() ?? string.Empty;
            studentService.AddStudent(newPerson);
            Console.WriteLine("\n....Student created successfully.");
        }

        public void UpdateStudent() {
            var selectedStudent = GetStudentByName();
            Console.WriteLine("Please enter the information below.");
            Console.WriteLine("NOTE: If you do not wish to modify the current property, press enter.");
            Console.WriteLine($"Current name: {selectedStudent.Name}");
            Console.Write("New name: ");
            var newName = Console.ReadLine() ?? string.Empty;
            if (!newName.Equals(string.Empty)) {
                selectedStudent.Name = newName;
            }
            Console.WriteLine($"Current Classification: {selectedStudent.Classification}");
            Console.Write("New classification: ");
            var newClassification = Console.ReadLine() ?? string.Empty;
            if (!newClassification.Equals(string.Empty)) {
                selectedStudent.Classification = newClassification;
            }
            Console.WriteLine("\n....Student updated successfully.\n");
        }

        public void ListAllStudents() {
            studentService.Students.ForEach(s => Console.WriteLine(s.Display));
        }

        public Person GetStudentByName() {
            // get course code from user
            Console.WriteLine("\n******************************\n");
            Console.Write("Enter student's first or last name: ");
            var name = Console.ReadLine() ?? string.Empty;

            // query
            var queryResult = studentService.QueryByName(name);

            // List results in a menu format for user
            Console.WriteLine("Which Student?");
            int i = 1;
            queryResult.ToList().ForEach(res => Console.WriteLine($"{i++}. {res.Name}"));
            Console.WriteLine(">>> ");
            var userSelection = int.Parse(Console.ReadLine() ?? string.Empty);

            // get selected course
            return queryResult.ElementAt(userSelection - 1);
        }

    }
}