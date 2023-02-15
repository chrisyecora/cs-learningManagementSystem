using System;
using App.LMSystem.Helpers;
using Library.LMSystem.Models;
using Library.LMSystem.Services;
namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program {
        static void Main(string[] args) {
            StudentHelper studentHelper = new StudentHelper();
            CourseHelper courseHelper = new CourseHelper();
            Console.WriteLine("Welcome to the Learning Management System.");
            Console.WriteLine("Please select from the following options:");

            bool cont = true;
            while (cont) {
                Console.WriteLine("\n");
                Console.WriteLine("* Student Services *");
                Console.WriteLine("1. Create a student.");
                Console.WriteLine("2. Update a student.");
                Console.WriteLine("3. Add a student to a course's roster.");
                Console.WriteLine("4. Remove a student from a course's roster.");
                Console.WriteLine("5. List a student's courses.");
                Console.WriteLine("6. List all students.");
                Console.WriteLine("");
                Console.WriteLine("* Course Services *");
                Console.WriteLine("7. Create a course.");
                Console.WriteLine("8. Update a course.");
                Console.WriteLine("9. Create an assignment for a course.");
                Console.WriteLine("10. Create an announcement for a course");
                Console.WriteLine("11. Update an annoucement from a course");
                Console.WriteLine("12. List all courses");
                Console.WriteLine("13. Exit program\n\n");
                Console.Write(">>> ");
                var userInput = int.Parse(Console.ReadLine() ?? "11");
                switch (userInput) {
                    case 1:
                        studentHelper.CreateStudent();
                        break;
                    case 2:
                        studentHelper.UpdateStudent();
                        break;
                    case 3:
                        courseHelper.AddStudentToCourse(studentHelper);
                        break;
                    case 4:
                        courseHelper.RemoveStudentFromCourse(studentHelper);
                        break;
                    case 5:
                        courseHelper.ListCoursesOfAStudent(studentHelper);
                        break;
                    case 6:
                        studentHelper.ListAllStudents();
                        break;
                    case 7:
                        courseHelper.CreateCourse();
                        break;
                    case 8:
                        courseHelper.UpdateCourse();
                        break;
                    case 9:
                        courseHelper.CreateAssignment();
                        break;
                    case 10:
                        courseHelper.CreateAnnouncement();
                        break;
                    case 11:
                        // update an announcement
                        courseHelper.UpdateAnnouncement();
                        break;
                    case 12:
                        courseHelper.ListAllCourses();
                        break;
                    case 13:
                        cont = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            }
        }
    }
}