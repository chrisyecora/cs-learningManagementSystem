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
                Console.WriteLine("1. Create a student");
                Console.WriteLine("2. Update a student");
                Console.WriteLine("3. Add a student to a course's roster");
                Console.WriteLine("4. Remove a student from a course's roster");
                Console.WriteLine("5. Grade a student's assignemnt");
                Console.WriteLine("6. List a student's courses");
                Console.WriteLine("7. List all students");
                Console.WriteLine("");
                Console.WriteLine("* Course Services *");
                Console.WriteLine("8. Create a course");
                Console.WriteLine("9. Update a course");
                Console.WriteLine("10. Create an assignment for a course.");
                Console.WriteLine("11. Create an announcement for a course");
                Console.WriteLine("12. Update an annoucement from a course");
                Console.WriteLine("13. Delete an annoucement from a course");
                Console.WriteLine("14. Create, Update, or Delete a Module in a course");
                Console.WriteLine("15. List all courses");
                Console.WriteLine("16. Exit program\n\n");
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
                         studentHelper.GradeAssignment(courseHelper);
                        break;
                    case 6:
                        courseHelper.ListCoursesOfAStudent(studentHelper);
                        break;
                    case 7:
                        studentHelper.ListAllStudents();
                        break;
                    case 8:
                        courseHelper.CreateCourse();
                        break;
                    case 9:
                        courseHelper.UpdateCourse();
                        break;
                    case 10:
                        courseHelper.CreateAssignment();
                        break;
                    case 11:
                        courseHelper.CreateAnnouncement();
                        break;
                    case 12:
                        courseHelper.UpdateAnnouncement();
                        break;
                    case 13:
                        courseHelper.DeleteAnnouncement();
                        break;
                    case 14:
                        courseHelper.CUDModule();
                        break;
                    case 15:
                        courseHelper.ListAllCourses();
                        break;
                    case 16:
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