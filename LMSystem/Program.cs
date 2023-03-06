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
                Console.WriteLine("* Person Services *");
                Console.WriteLine("1. Create a person");
                Console.WriteLine("2. Update a person");
                Console.WriteLine("3. Add a student to a course's roster");
                Console.WriteLine("4. Remove a student from a course's roster");
                Console.WriteLine("5. Grade a student's assignemnt");
                Console.WriteLine("6. List a student's courses");
                Console.WriteLine("7. List all students");
                Console.WriteLine("8. List all persons");
                Console.WriteLine("");
                Console.WriteLine("* Course Services *");
                Console.WriteLine("9. Create a course");
                Console.WriteLine("10. Update a course");
                Console.WriteLine("11. Create an assignment for a course.");
                Console.WriteLine("12. Create, Update, or Delete an Announcement");
                Console.WriteLine("13. Create, Update, or Delete a Module");
                Console.WriteLine("14. Create, Update, or Delete Content on an Existing Module");
                Console.WriteLine("15. List all courses");
                Console.WriteLine("16. Exit program\n\n");
                Console.WriteLine("17. Show a student's course grades");
                Console.Write(">>> ");
                var userInput = int.Parse(Console.ReadLine() ?? "11");
                switch (userInput) {
                    case 1:
                        studentHelper.CreatePerson();
                        break;
                    case 2:
                        studentHelper.UpdatePerson();
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
                        studentHelper.ListAllPersons();
                        break;
                    case 9:
                        courseHelper.CreateCourse();
                        break;
                    case 10:
                        courseHelper.UpdateCourse();
                        break;
                    case 11:
                        courseHelper.CreateAssignment();
                        break;
                    case 12:
                        courseHelper.CUDAnnouncement();
                        break;
                    case 13:
                        courseHelper.CUDModule();
                        break;
                    case 14:
                        courseHelper.CUDContentItem();
                        break;
                    case 15:
                        courseHelper.ListAllCourses();
                        break;
                    case 16:
                        cont = false;
                        break;
                    case 17:
                        studentHelper.CalculateGPA(courseHelper);
                        break;
                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            }
        }
    }
}