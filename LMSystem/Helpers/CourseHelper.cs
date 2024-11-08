﻿using System;
using Library.LMSystem.Models;
using Library.LMSystem.Services;
using MyApp;

namespace App.LMSystem.Helpers
{
    public class CourseHelper
    {
        private CourseService courseService;
        private ListNavigator<Course> courseNavigator;
        public CourseHelper()
        {
            courseService = new CourseService();
            courseNavigator = new ListNavigator<Course>(courseService.Courses);
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
            Console.Write("Credit Hours: ");
            newCourse.CreditHours = int.Parse(Console.ReadLine() ?? "0");
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
            Course? selectedCourse;
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

            Console.WriteLine($"Current name: {selectedCourse.Name}");
            Console.Write("New name: ");
            var newName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine($"Current description: {selectedCourse.Description}");
            Console.Write("New description: ");
            var newDescription = Console.ReadLine() ?? string.Empty;

            courseService.UpdateCourse(selectedCourse, newCode, newName, newDescription);
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

                Console.WriteLine($"Current body: {announcement.Body}");
                Console.Write("New body: ");
                var newBody = Console.ReadLine() ?? string.Empty;

                courseService.UpdateAnnouncement(announcement, newTitle, newBody);
                Console.WriteLine("\n....Announcement updated successfully.\n");
            } else if (userChoice == 3) {
                // Deleting an announcement
                var announcement = GetAnnouncement(selectedCourse);
                Console.Write("Are you sure you would like to delete this announcement? (y/n): ");
                var userConfirmation = Console.ReadLine() ?? "n";
                if (userConfirmation.Equals("y", StringComparison.InvariantCultureIgnoreCase)) {
                    courseService.DeleteAnnouncement(selectedCourse, announcement);
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

                Console.WriteLine($"Current description: {module.Description}");
                Console.Write("New description: ");
                var newDesc = Console.ReadLine() ?? string.Empty;

                courseService.UpdateModule(module, newName, newDesc);
                Console.WriteLine("\n....Module updated successfully.\n");
            } else if (userChoice == 3) {
                // Deleting a module
                var module = GetModuleFromCourse(selectedCourse);
                // delete module
                Console.Write("Are you sure you would like to delete this module? (y/n): ");
                var userConfirmation = Console.ReadLine() ?? "n";
                if (userConfirmation.Equals("y", StringComparison.InvariantCultureIgnoreCase)) {
                    courseService.DeleteModule(selectedCourse, module);
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
                Console.WriteLine("Enter the following information for the content item.");
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
                userChoice = userIntPrompt();
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
            } else if (userChoice == 2 || userChoice == 3) {
                // find the ContentItem
                var items = courseService.GetContentItems(selectedModule);
                Console.WriteLine("Please select an item from the list below.");
                int i = 1;
                items.ForEach(item => Console.WriteLine($"{i++}. {item.Display}"));
                var userSelection = userIntPrompt();
                var selectedItem = items[userSelection - 1];
                if (userChoice == 2) {
                    // update
                    Console.WriteLine("Please enter the information below.");
                    Console.WriteLine("NOTE: If you do not wish to modify the current property, press enter.");
                    Console.WriteLine($"Current Name: {selectedItem.Name}");
                    Console.Write("New Name: ");
                    var newName = Console.ReadLine() ?? string.Empty;

                    Console.WriteLine($"Current description: {selectedItem.Description}");
                    Console.Write("New description: ");
                    var newDesc = Console.ReadLine() ?? string.Empty;

                    courseService.UpdateContentItem(selectedItem, newName, newDesc);
                    Console.WriteLine("\n....Item updated successfully.\n");
                } else {
                    // delete
                    Console.Write("Are you sure you would like to delete this item? (y/n): ");
                    var userConfirmation = Console.ReadLine() ?? "n";
                    if (userConfirmation.Equals("y", StringComparison.InvariantCultureIgnoreCase)) {
                        courseService.DeleteContentItem(selectedModule, selectedItem);
                        Console.WriteLine("....Item has been deleted successfully.\n");
                    } else {
                        Console.WriteLine("....Item deletion aborted.\n");
                    }
                }
            }
        }

        public int PromptCUD(string topic) {
            // Choose between Create, Update, or Delete option
            Console.WriteLine("\n\n******************************\n");
            Console.WriteLine($"1. Create {topic}");
            Console.WriteLine($"2. Update {topic}");
            Console.WriteLine($"3. Delete {topic}");
            var userChoice = userIntPrompt();
            return userChoice;
        }

        public void AddStudentToCourse(StudentHelper studentHelper) {
            var student = studentHelper.GetPersonByName();
            var course = GetCourseByCode();
            courseService.AddStudent(course, student);
            Console.WriteLine("\n....Student added successfully.\n");
        }

        public void RemoveStudentFromCourse(StudentHelper studentHelper) {
            var student = studentHelper.GetPersonByName();
            var course = GetCourseByCode();
            course.Roster.Remove(student);
            Console.WriteLine("\n....Student removed successfully.\n");
        }

        public void ListCoursesOfAStudent(StudentHelper studentHelper) {
            var student = studentHelper.GetPersonByName();
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
            var userSelection = userIntPrompt();

            // get selected course
            return queryResult.ElementAt(userSelection - 1);
        }

        public List<Course> CoursesStudentIsTaking(Student student) {
            return courseService.QueryByStudentInRosters(student);
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
            var userSelection = userIntPrompt();

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
            var userSelection = userIntPrompt();

            // get selected course
            return queryResult.ElementAt(userSelection - 1);
        }

        public Announcement GetAnnouncement(Course course) {
            Console.WriteLine("\n******************************\n");
            var announcements = courseService.GetAnnouncements(course);
            Console.WriteLine("Please select an announcement.");
            int i = 1;
            announcements.ForEach(ann => Console.WriteLine($"{i++}. {ann.Display}"));
            var selection = userIntPrompt();
            return announcements[selection - 1];
        }

        public Module GetModuleFromCourse(Course course) {
            var modules = courseService.GetModules(course);
            Console.WriteLine("\n******************************\n");
            Console.WriteLine("Please select a module.");
            int i = 1;
            modules.ForEach(mod => Console.WriteLine($"{i++}. {mod.Display}"));
            var selection = userIntPrompt();
            return modules[selection - 1];
        }

        public Assignment GetAssignmentFromCourse(Course course) {
            var assignments = courseService.GetAssignments(course);
            Console.WriteLine("Please select an assignment.");
            int i = 1;
            assignments.ToList().ForEach(a => Console.WriteLine($"{i++}. {a.Display}"));
            var selection = userIntPrompt();
            return assignments.ElementAt(selection - 1);
        }

        public AssignmentGroup FindOrCreateAssignmentGroup(Course course) {
            int i = 1;
            course.AssignmentGroups.ForEach(group => Console.WriteLine($"{i++}. {group.Name}"));
            Console.WriteLine($"{i}. Create a new group");
            var choice = userIntPrompt();
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

        private void NavigateCourses(List<Course>? queryList = null) {
            ListNavigator<Course> currentNavigator;
            if (queryList != null) {
                currentNavigator = new ListNavigator<Course>(queryList);
            } else {
                currentNavigator = courseNavigator;
            }

            bool keepPaging = true;
            while (keepPaging) {
                foreach (var pair in currentNavigator.GetCurrentPage()) {
                    Console.WriteLine($"{pair.Key}. {pair.Value.ShortDisplay}");
                }
                if (currentNavigator.HasPreviousPage) {
                    Console.Write("  p: previous  ");
                }
                if (currentNavigator.HasNextPage) {
                    Console.Write("  n: next  ");
                }
                Console.WriteLine("  x: exit ");
                Console.WriteLine("To show full information, select a course from the numbered list.");
                var userInput = userStringPrompt();
                if (userInput.Equals("x", StringComparison.InvariantCultureIgnoreCase)) {
                    keepPaging = false;
                } else if (userInput.Equals("p", StringComparison.InvariantCultureIgnoreCase)) {
                    currentNavigator.GoBackward();
                } else if (userInput.Equals("n", StringComparison.InvariantCultureIgnoreCase)) {
                    currentNavigator.GoForward();
                } else if (int.TryParse(userInput, out int userNumInput)) {
                    var course = currentNavigator.GetCurrentPage()[userNumInput];
                    Console.WriteLine(course.Display);
                    Console.WriteLine("* Roster *");
                    courseService.GetRoster(course).ForEach(s => Console.WriteLine(s.Display));
                    Console.WriteLine("\n");
                    Console.WriteLine("* Assignments *");
                    foreach (var group in course.AssignmentGroups) {
                        Console.WriteLine($"Group: {group.Display}");
                        group.Assignments.ForEach(a => Console.WriteLine(a.Display));
                        Console.WriteLine("\n");
                    }
                    Console.WriteLine("* Announcements *");
                    courseService.GetAnnouncements(course).ToList().ForEach(a => Console.WriteLine(a.Display));
                    Console.WriteLine("\n");
                    Console.WriteLine("* Modules *");
                    courseService.GetModules(course).ToList().ForEach(module => Console.WriteLine(module.Display));
                    Console.WriteLine("\n\n");
                }
            }
        }

        public void ListAllCourses() {
            NavigateCourses();
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