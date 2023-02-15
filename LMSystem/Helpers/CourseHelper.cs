using System;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace App.LMSystem.Helpers
{
    public class CourseHelper
    {
        private CourseService courseService;
        public CourseHelper()
        {
            courseService = new CourseService();
        }
        public void CreateCourse() {
            // Creating a course
            var newCourse = new Course();
            Console.WriteLine("\n\n******************************\n");
            Console.WriteLine("Please enter the information below.\n");
            Console.Write("Code: ");
            newCourse.CourseCode = Console.ReadLine() ?? string.Empty;
            Console.Write("Name: ");
            newCourse.Name = Console.ReadLine() ?? string.Empty;
            Console.Write("Description: ");
            newCourse.Description = Console.ReadLine() ?? string.Empty;
            courseService.AddCourse(newCourse);
            Console.WriteLine("\n....Course created successfully.\n");
        }
        public void CreateAssignment() {
            // Creating an assignment
            var newAssignment = new Assignment();

            // get course from code
            var selectedCourse = GetCourseByCode();

            // new assignment properties
            Console.WriteLine("Please enter the information below.\n");
            Console.Write("Name: ");
            newAssignment.Name = Console.ReadLine() ?? string.Empty;
            Console.Write("Description: ");
            newAssignment.Description = Console.ReadLine() ?? string.Empty;
            Console.Write("Total Available Points: ");
            var assignmentPointsString = Console.ReadLine() ?? "0";
            newAssignment.TotalPoints = int.Parse(assignmentPointsString);
            Console.Write("Due Date (format: MM/DD/YYYY): ");
            var assignmentDueDateString = Console.ReadLine() ?? DateTime.Today.ToString();
            newAssignment.DueDate = DateTime.Parse(assignmentDueDateString);

            // adding assignment to course
            courseService.AddAssignmentToCourse(selectedCourse, newAssignment);

            Console.WriteLine("\n....Assignment created successfully.\n");
        }

        public void CreateAnnouncement() {
            // Creating an announcement
            var newAnnouncement = new Announcement();

            // get course from code
            var selectedCourse = GetCourseByCode();

            // new assignment properties
            Console.WriteLine("Please enter the information below.\n");
            Console.Write("Title: ");
            newAnnouncement.Title = Console.ReadLine() ?? string.Empty;
            Console.Write("Body of announcement: ");
            newAnnouncement.Body = Console.ReadLine() ?? string.Empty;
            
            // adding announcement to course
            courseService.AddAnnouncementToCourse(selectedCourse, newAnnouncement);

            Console.WriteLine("\n....Announcement created successfully.\n");
        }

        public void UpdateCourse() {
            Console.WriteLine("How would you like to search?");
            Console.WriteLine("1. Code");
            Console.WriteLine("2. Name");
            Console.WriteLine("3. Description");
            Console.Write(">>> ");
            var userSelection = int.Parse(Console.ReadLine() ?? "1");
            Course? selectedCourse = null;
            switch (userSelection) {
                case 1:
                    selectedCourse = GetCourseByCode();
                    break;
                case 2:
                    selectedCourse = GetCourseByName();
                    break;
                case 3:
                    selectedCourse = GetCourseByDescription();
                    break;
                default:
                    selectedCourse = GetCourseByCode();
                    break;
            }

            Console.WriteLine("Please enter the information below.");
            Console.WriteLine("NOTE: If you do not wish to modify the current property, press enter.");
            Console.WriteLine($"Current code: {selectedCourse.CourseCode}");
            Console.Write("New code: ");
            var newCode = Console.ReadLine() ?? string.Empty;
            if (!newCode.Equals(string.Empty)) {
                selectedCourse.CourseCode = newCode;
            }
            Console.WriteLine($"Current name: {selectedCourse.Name}");
            Console.Write("New name: ");
            var newName = Console.ReadLine() ?? string.Empty;
            if (!newName.Equals(string.Empty)) {
                selectedCourse.Name = newName;
            }
            Console.WriteLine($"Current description: {selectedCourse.Description}");
            Console.Write("New description: ");
            var newDescription = Console.ReadLine() ?? string.Empty;
            if (!newDescription.Equals(string.Empty)) {
                selectedCourse.Description = newDescription;
            }
            Console.WriteLine("\n....Course updated successfully.\n");
        }

        public void UpdateAnnouncement() {
            var announcement = GetAnnouncement();
            Console.WriteLine("Please enter the information below.");
            Console.WriteLine("NOTE: If you do not wish to modify the current property, press enter.");
            Console.WriteLine($"Current Title: {announcement.Title}");
            Console.Write("New title: ");
            var newTitle = Console.ReadLine() ?? string.Empty;
            if (!newTitle.Equals(string.Empty)) {
                announcement.Title = newTitle;
            }
            Console.WriteLine($"Current body: {announcement.Body}");
            Console.Write("New body: ");
            var newBody = Console.ReadLine() ?? string.Empty;
            if (!newBody.Equals(string.Empty)) {
                announcement.Body = newBody;
            }
            Console.WriteLine("\n....Announcement updated successfully.\n");
        }

        public void AddStudentToCourse(StudentHelper studentHelper) {
            var student = studentHelper.GetStudentByName();
            var course = GetCourseByCode();
            course.Roster.Add(student);
            Console.WriteLine("\n....Student added successfully.\n");
        }

        public void RemoveStudentFromCourse(StudentHelper studentHelper) {
            var student = studentHelper.GetStudentByName();
            var course = GetCourseByCode();
            course.Roster.Remove(student);
            Console.WriteLine("\n....Student removed successfully.\n");
        }

        public void ListCoursesOfAStudent(StudentHelper studentHelper) {
            var student = studentHelper.GetStudentByName();
            var coursesOfStudent = courseService.QueryByStudentInRosters(student);
            Console.WriteLine($"{student.Name}'s current courses:");
            int i = 1;
            coursesOfStudent.ForEach(c => Console.WriteLine($"{i++}. {c.ShortDisplay}"));
        }

        public Course GetCourseByCode() {
            // get course code from user
            Console.WriteLine("\n******************************\n");
            Console.Write("Course code: ");
            var courseCode = Console.ReadLine() ?? string.Empty;

            // query courseList
            var queryResult = courseService.QueryByCode(courseCode);

            // List results in a menu format for user
            Console.WriteLine("Which Course?");
            int i = 1;
            queryResult.ToList().ForEach(res => Console.WriteLine($"{i++}. {res.ShortDisplay}"));
            Console.Write(">>> ");
            var userSelection = int.Parse(Console.ReadLine() ?? string.Empty);

            // get selected course
            return queryResult.ElementAt(userSelection - 1);
        }

        public Course GetCourseByName() {
            // get course code from user
            Console.WriteLine("\n******************************\n");
            Console.Write("Course name: ");
            var courseName = Console.ReadLine() ?? string.Empty;

            // query courseList
            var queryResult = courseService.QueryByName(courseName);

            // List results in a menu format for user
            Console.WriteLine("Which Course?");
            int i = 1;
            queryResult.ToList().ForEach(res => Console.WriteLine($"{i++}. {res.ShortDisplay}"));
            Console.Write(">>> ");
            var userSelection = int.Parse(Console.ReadLine() ?? string.Empty);

            // get selected course
            return queryResult.ElementAt(userSelection - 1);
        }

        public Course GetCourseByDescription() {
            // get course code from user
            Console.WriteLine("\n******************************\n");
            Console.Write("Enter some of the course's description: ");
            var courseDescription = Console.ReadLine() ?? string.Empty;

            // query courseList
            var queryResult = courseService.QueryByDescription(courseDescription);

            // List results in a menu format for user
            Console.WriteLine("Which Course?");
            int i = 1;
            queryResult.ToList().ForEach(res => Console.WriteLine($"{i++}. {res.ShortDisplay}"));
            Console.Write(">>> ");
            var userSelection = int.Parse(Console.ReadLine() ?? string.Empty);

            // get selected course
            return queryResult.ElementAt(userSelection - 1);
        }

        public Announcement GetAnnouncement() {
            var selectedCourse = GetCourseByCode();
            Console.WriteLine("\n******************************\n");
            Console.Write("Enter some of the title of the announcement: ");
            var query = Console.ReadLine() ?? string.Empty;

            // query courseList
            var queryResult = courseService.QueryForAnnouncements(selectedCourse, query);

            // List results in a menu format for user
            Console.WriteLine("Which Announcement?");
            int i = 1;
            queryResult.ToList().ForEach(res => Console.WriteLine($"{i++}. {res.Display}"));
            Console.Write(">>> ");
            var userSelection = int.Parse(Console.ReadLine() ?? string.Empty);

            // get selected course
            return queryResult.ElementAt(userSelection - 1);
        }

        public void ListAllCourses() {
            int i = 1;
            courseService.Courses.ForEach(c => Console.WriteLine($"{i++}. {c.ShortDisplay}"));
            Console.WriteLine("To show full information, select a course from the numbered list.");
            Console.WriteLine("If you do not wish to select a course, press enter to return to the main menu.");
            Console.Write(">>> ");
            var userInput = Console.ReadLine() ?? string.Empty;
            if (!userInput.Equals(string.Empty)) {
                var course = courseService.Courses[int.Parse(userInput) - 1];
                Console.WriteLine(course.Display);
                Console.WriteLine("* Roster *");
                course.Roster.ForEach(s => Console.WriteLine(s.Display));
                Console.WriteLine("* Assignments *");
                course.Assignments.ForEach(a => Console.WriteLine(a.Display));
                Console.WriteLine("* Announcements *");
                course.Announcements.ForEach(a => Console.WriteLine(a.Display));
            }
        }
    }
}