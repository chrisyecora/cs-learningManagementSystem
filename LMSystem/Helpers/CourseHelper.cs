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
            if (courseService.AddCourse(newCourse)) {
                Console.WriteLine("\n....Course created successfully.\n");
            } else {
                Console.WriteLine("\n....Error adding course. Most probably this course code is taken.");
            }
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

            Console.Write("Would you like to add this assignment to a group? (y/n):");
            var addToGroup = Console.ReadLine() ?? string.Empty;
            if (addToGroup.Equals("y", StringComparison.InvariantCultureIgnoreCase)) {
                var assignmentGroup = FindOrCreateAssignmentGroup(selectedCourse);
                courseService.AddAssignmentToCourse(selectedCourse, newAssignment, assignmentGroup);
            } else {
                // adding assignment to course
                courseService.AddAssignmentToCourse(selectedCourse, newAssignment);
            }
            Console.WriteLine("\n....Assignment created successfully.\n");
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

        public void CUDAnnouncement() {
            var userChoice = PromptCUD("Announcement");
            var selectedCourse = GetCourseByCode();
            if (userChoice == 1) {
                // Creating an announcement
                var newAnnouncement = new Announcement();

                // new assignment properties
                Console.WriteLine("Please enter the information below.\n");
                Console.Write("Title: ");
                newAnnouncement.Title = Console.ReadLine() ?? string.Empty;
                Console.Write("Body of announcement: ");
                newAnnouncement.Body = Console.ReadLine() ?? string.Empty;

                // adding announcement to course
                courseService.AddAnnouncementToCourse(selectedCourse, newAnnouncement);

                Console.WriteLine("\n....Announcement created successfully.\n");
            } else if (userChoice == 2) {
                // Updating an announcement
                var announcement = GetAnnouncement(selectedCourse);
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
            } else if (userChoice == 3) {
                // Deleting an announcement
                var announcement = GetAnnouncement(selectedCourse);
                Console.Write("Are you sure you would like to delete this announcement? (y/n): ");
                var userConfirmation = Console.ReadLine() ?? "n";
                if (userConfirmation.Equals("y", StringComparison.InvariantCultureIgnoreCase)) {
                    selectedCourse.Announcements.Remove(announcement);
                    Console.WriteLine("....Announcement has been deleted successfully.\n");
                } else {
                    Console.WriteLine("....Announcement deletion aborted.\n");
                }
            }
        }

        public void CUDModule() {
            var userChoice = PromptCUD("Module");
            var selectedCourse = GetCourseByCode();
            if (userChoice == 1) {
                // Creating a module
                var newModule = new Module();
                Console.WriteLine("Please enter the following information.");
                Console.Write("Name: ");
                newModule.Name = Console.ReadLine() ?? string.Empty;
                Console.Write("Description: ");
                newModule.Description = Console.ReadLine() ?? string.Empty;
                courseService.AddModuleToCourse(selectedCourse, newModule);
                Console.WriteLine("....Module has been created successfully.\n");
            } else if (userChoice == 2) {
                // Updating a module
                var module = GetModuleFromCourse(selectedCourse);
                Console.WriteLine("Please enter the information below.");
                Console.WriteLine("NOTE: If you do not wish to modify the current property, press enter.");
                Console.WriteLine($"Current Name: {module.Name}");
                Console.Write("New Name: ");
                var newName = Console.ReadLine() ?? string.Empty;
                if (!newName.Equals(string.Empty)) {
                    module.Name = newName;
                }
                Console.WriteLine($"Current description: {module.Description}");
                Console.Write("New description: ");
                var newDesc = Console.ReadLine() ?? string.Empty;
                if (!newDesc.Equals(string.Empty)) {
                    module.Description = newDesc;
                }
                Console.WriteLine("\n....Module updated successfully.\n");
            } else if (userChoice == 3) {
                // Deleting a module
                var module = GetModuleFromCourse(selectedCourse);
                // delete module
                Console.Write("Are you sure you would like to delete this module? (y/n): ");
                var userConfirmation = Console.ReadLine() ?? "n";
                if (userConfirmation.Equals("y", StringComparison.InvariantCultureIgnoreCase)) {
                    selectedCourse.Modules.Remove(module);
                    Console.WriteLine("....Module has been deleted successfully.\n");
                } else {
                    Console.WriteLine("....Module deletion aborted.\n");
                }
            }
        }

        public void CUDContentItem() {
            var userChoice = PromptCUD("Content");
            var selectedCourse = GetCourseByCode();
            var selectedModule = GetModuleFromCourse(selectedCourse);
            if (userChoice == 1) {
                // Creating a ContentItem
                var newContentItem = new ContentItem();
                // name and description can be set here
                Console.Write("Name: ");
                newContentItem.Name = Console.ReadLine() ?? string.Empty;
                Console.Write("Description: ");
                newContentItem.Description = Console.ReadLine() ?? string.Empty;
                // choose between creating an AssignmentItem, FileItem, or PageItem
                Console.WriteLine("Which of the following would you like to create?");
                int i = 1;
                Console.WriteLine($"{i++}. Assignment Item");
                Console.WriteLine($"{i++}. Page Item");
                Console.WriteLine($"{i++}. File Item");
                Console.Write(">>> ");
                userChoice = int.Parse(Console.ReadLine() ?? "0");
                if (userChoice == 1) {
                    // Assignment Item
                    var newAssignmentItem = new AssignmentItem(newContentItem);
                    newAssignmentItem.Assignment = GetAssignmentFromCourse(selectedCourse);
                    courseService.AddAssignmentItemToModule(selectedModule, newAssignmentItem);
                } else if (userChoice == 2) {
                    // Page item
                    var newPageItem = new PageItem(newContentItem);
                    courseService.AddPageItemToModule(selectedModule, newPageItem);
                } else if (userChoice == 3) {
                    // File item
                    var newFileItem = new FileItem(newContentItem);
                    courseService.AddFileItemToModule(selectedModule, newFileItem);
                }

                Console.WriteLine("....Content created successfully.\n");
            } else if (userChoice == 2) {
                // Updating a ContentItem
            } else if (userChoice == 3) {
                // Deleting a ContentItem
            }
        }

        public int PromptCUD(string topic) {
            // Choose between Create, Update, or Delete option
            Console.WriteLine("\n\n******************************\n");
            Console.WriteLine($"1. Create {topic}");
            Console.WriteLine($"2. Update {topic}");
            Console.WriteLine($"3. Delete {topic}");
            Console.Write(">>> ");
            var userChoice = int.Parse(Console.ReadLine() ?? string.Empty);
            return userChoice;
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

        public Announcement GetAnnouncement(Course course) {
            Console.WriteLine("\n******************************\n");
            Console.Write("Enter some of the title of the announcement: ");
            var query = Console.ReadLine() ?? string.Empty;

            // query courseList
            var queryResult = courseService.QueryForAnnouncements(course, query);

            // List results in a menu format for user
            Console.WriteLine("Which Announcement?");
            int i = 1;
            queryResult.ToList().ForEach(res => Console.WriteLine($"{i++}. {res.Display}"));
            Console.Write(">>> ");
            var userSelection = int.Parse(Console.ReadLine() ?? string.Empty);

            // get selected course
            return queryResult.ElementAt(userSelection - 1);
        }

        public Module GetModuleFromCourse(Course course) {
            Console.WriteLine("\n******************************\n");
            Console.Write("Enter the name of the Module: ");
            var query = Console.ReadLine() ?? string.Empty;

            // query courseList
            var queryResult = courseService.QueryForModules(course, query);

            // List results in a menu format for user
            Console.WriteLine("Which Module?");
            int i = 1;
            queryResult.ToList().ForEach(res => Console.WriteLine($"{i++}. {res.Display}"));
            Console.Write(">>> ");
            var userSelection = int.Parse(Console.ReadLine() ?? string.Empty);

            // get selected course
            return queryResult.ElementAt(userSelection - 1);
        }

        public Assignment GetAssignmentFromCourse(Course course) {
            Console.WriteLine("Which group is the assignment in?");
            int i = 1;
            course.AssignmentGroups.ForEach(group => Console.WriteLine($"{i++}. {group.Display}"));
            Console.WriteLine($"{i}. Forgot the group? Show all assignments");
            Console.Write(">>> ");
            var choice = int.Parse(Console.ReadLine() ?? i.ToString());
            if (choice == i) {
                foreach (var group in course.AssignmentGroups) {
                    Console.WriteLine($"Group: {group.Display}");
                    group.Assignments.ForEach(a => Console.WriteLine(a.Display));
                    Console.WriteLine("\n");
                    i = 1;
                    course.AssignmentGroups.ForEach(group => Console.WriteLine($"{i++}. {group.Display}"));
                }
                Console.WriteLine("Which group is the assignment in?");
                Console.Write(">>> ");
                choice = int.Parse(Console.ReadLine() ?? "0");
            }

            var chosenGroup = course.AssignmentGroups[choice - 1];
            Console.WriteLine("Which assignment?");
            i = 1;
            chosenGroup.Assignments.ForEach(assignment => Console.WriteLine($"{i++}. {assignment.Name}"));
            Console.Write(">>> ");
            choice = int.Parse(Console.ReadLine() ?? "0");
            return chosenGroup.Assignments[choice - 1];

        }
        public AssignmentGroup FindOrCreateAssignmentGroup(Course course) {
            int i = 1;
            course.AssignmentGroups.ForEach(group => Console.WriteLine($"{i++}. {group.Name}"));
            Console.WriteLine($"{i}. Create a new group");
            Console.Write(">>> ");
            var choice = int.Parse(Console.ReadLine()?? i.ToString());
            if (choice == i) {
                // creating a new assignment group
                var newAssignmentGroup = new AssignmentGroup();
                Console.WriteLine("Please enter the following information for the new Assignment group.");
                Console.Write("Name: ");
                newAssignmentGroup.Name = Console.ReadLine() ?? string.Empty;
                Console.Write("Weight (as a %): ");
                newAssignmentGroup.Weight = double.Parse(Console.ReadLine() ?? "0.00") / 100;
                courseService.AddAssignmentGroup(course, newAssignmentGroup);
                return newAssignmentGroup;

            } else {
                // existing assignment group
                return course.AssignmentGroups[choice - 1];
            }
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
                Console.WriteLine("\n");
                Console.WriteLine("* Assignments *");
                foreach (var group in course.AssignmentGroups) {
                    Console.WriteLine($"Group: {group.Display}");
                    group.Assignments.ForEach(a => Console.WriteLine(a.Display));
                    Console.WriteLine("\n");
                }
                Console.WriteLine("* Announcements *");
                course.Announcements.ForEach(a => Console.WriteLine(a.Display));
                Console.WriteLine("\n");
                Console.WriteLine("* Modules *");
                course.Modules.ForEach(module => Console.WriteLine(module.Display));
                Console.WriteLine("\n");
            }
        }
    }
}