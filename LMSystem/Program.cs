﻿using System;
using Library.LMSystem.Models;
namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program {
        static void Main(string[] args) {
            // master courses list
            List<Course> courseList = new List<Course>();
            // master student list
            List<Person> studentList = new List<Person>();
            Console.WriteLine("Welcome to the Learning Management System.");
            Console.WriteLine("Please select from the following options:");
            // loop control
            bool cont = true;
            while (cont) {
                Console.WriteLine("*******************************************");
                Console.WriteLine("1. Create course, student, assignment");
                Console.WriteLine("2. List students, courses, or a specific student's courses");
                Console.WriteLine("3. Add an existing student to a course's roster");
                Console.WriteLine("4. Search for student or course");
                Console.WriteLine("5. Update information for course or student");
                Console.WriteLine("6. Remove a student from a course’s roster");
                Console.WriteLine("7. Exit program");
                Console.WriteLine("*******************************************\n\n");

                Console.Write(">>> ");
                var userInput = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(userInput, out int userInt)) {
                    if (userInt == 1) {
                        // Create course, student, assignment
                        Console.WriteLine("\n**********************************\n");
                        Console.WriteLine("Create a...");
                        Console.WriteLine("1. Course");
                        Console.WriteLine("2. Student");
                        Console.WriteLine("3. Assignment");
                        Console.Write(">>> ");
                        userInput = Console.ReadLine() ?? string.Empty;
                        if (int.TryParse(userInput, out userInt)) {
                            if (userInt == 1) {
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
                                courseList.Add(newCourse);
                                Console.WriteLine("\n\n....Course created successfully.");
                            } else if (userInt == 2) {
                                // Creating a student
                                var newPerson = new Person();
                                Console.WriteLine("\n\n******************************\n");
                                Console.WriteLine("Please enter the information below.\n");
                                Console.Write("Name: ");
                                newPerson.Name = Console.ReadLine() ?? string.Empty;
                                Console.Write("Classification: ");
                                newPerson.Classification = Console.ReadLine() ?? string.Empty;
                                studentList.Add(newPerson);
                                Console.WriteLine("\n\n....Student created successfully.");
                            } else if (userInt == 3) {
                                // Creating an assignment
                                var newAssignment = new Assignment();
                                Console.WriteLine("\n\n******************************\n");
                                Console.Write("Course code of course to add assignment to: ");
                                var courseCode = Console.ReadLine() ?? string.Empty;
                                // TODO: Search for course in courseList. Make sure it exists.
                                var queryResult = courseList
                                    .Where(c => c.Name
                                    .Equals(courseCode, StringComparison.InvariantCultureIgnoreCase));
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
                                // TODO: Add assignment to correct course.

                            } else {
                                // Invalid input
                                Console.WriteLine("Invalid input. Please try again.");
                            }
                        } else {
                            // Invalid input
                            Console.WriteLine("Invalid input. Please try again.");
                        }
                    } else if (userInt == 2) {
                        // List students, courses, or a specific student's courses
                        Console.WriteLine("\n**********************************\n");
                        Console.WriteLine("1. List of students");
                        Console.WriteLine("2. List of courses");
                        Console.WriteLine("3. List all courses a student is taking");
                        Console.Write(">>>");
                        userInput = Console.ReadLine() ?? string.Empty;
                        if (int.TryParse(userInput, out userInt)) {
                            Console.WriteLine("");
                            if (userInt == 1) {
                                // List of students
                                studentList.ForEach(s => Console.WriteLine(s.Display));
                            } else if (userInt == 2) {
                                // List of courses
                                courseList.ForEach(c => Console.WriteLine(c.Display));
                            } else if (userInt == 3) {
                                // List all courses a student is taking
                                Console.Write("Student Name: ");
                                var query = Console.ReadLine() ?? string.Empty;
                                // TODO: Find student in roster of courses from courseList
                            } else {
                                // Invalid input
                                Console.WriteLine("Invalid input. Please try again.");
                            }
                            Console.WriteLine("");
                        } else {
                            // Invalid input
                            Console.WriteLine("\nInvalid input. Please try again.\n");
                        }
                    } else if (userInt == 3) {
                        // Add an existing student to a course's roster
                        Console.WriteLine("\n\n******************************\n");
                        Console.Write("Course code of course to add student to: ");
                        var courseCode = Console.ReadLine() ?? string.Empty;
                        // TODO: query for course in courseList
                        Console.Write("Student name: ");
                        var studentName = Console.ReadLine() ?? string.Empty;
                        // TODO: query for student in studentList
                    } else if (userInt == 4) {
                        // Search for student or course
                        Console.WriteLine("\n\n******************************\n");
                        Console.WriteLine("1. Search for a student");
                        Console.WriteLine("2. Search for a course");
                        Console.Write(">>>");
                        userInput = Console.ReadLine() ?? string.Empty;
                        if (int.TryParse(userInput, out userInt)) {
                            if (userInt == 1) {
                                // student search
                                Console.Write("Student name: ");
                                var studentName = Console.ReadLine() ?? string.Empty;
                                // TODO: query for students
                            } else if (userInt == 2) {
                                // course search
                                Console.WriteLine("1. Search by code");
                                Console.WriteLine("2. Search by name");
                                Console.WriteLine("3. Search by description");
                                userInput = Console.ReadLine() ?? string.Empty;
                                if (int.TryParse(userInput, out userInt)) {
                                    if (userInt == 1) {
                                        // search by code
                                        Console.Write("Course code: ");
                                        var courseCode = Console.ReadLine() ?? string.Empty;
                                        // TODO: query for courses
                                    } else if (userInt == 2) {
                                        // search by name
                                        Console.Write("Course name: ");
                                        var courseName = Console.ReadLine() ?? string.Empty;
                                        // TODO: query for courses
                                    } else if (userInt == 3) {
                                        // search by description
                                        Console.Write("Description: ");
                                        var courseDescription = Console.ReadLine() ?? string.Empty;
                                        // TODO: query for courses
                                    } else {
                                        // Invalid input
                                        Console.WriteLine("Invalid input. Please try again.");
                                    }
                                } else {
                                    // Invalid input
                                    Console.WriteLine("Invalid input. Please try again.");
                                }
                            } else {
                                // Invalid input
                                Console.WriteLine("Invalid input. Please try again.");
                            }
                        } else {
                            // Invalid input
                            Console.WriteLine("Invalid input. Please try again.");
                        }
                    } else if (userInt == 5) {
                        // Update information for course or student
                        Console.WriteLine("\n\n******************************\n");
                        Console.WriteLine("1. Update a course");
                        Console.WriteLine("2. Update a student");
                        userInput = Console.ReadLine() ?? string.Empty;
                        if (int.TryParse(userInput, out userInt)) {
                            if (userInt == 1) {
                                // update a course
                                Console.Write("Course code: ");
                                var courseCode = Console.ReadLine() ?? string.Empty;
                                // TODO: query for course code, confirm specific course
                            } else if (userInt == 2) {
                                // update a student
                                Console.Write("Student name: ");
                                var studentName = Console.ReadLine() ?? string.Empty;
                                // TODO: query for student, confirm specific student
                            } else {
                                // Invalid input
                                Console.WriteLine("Invalid input. Please try again.");
                            }
                        } else {
                            // Invalid input
                            Console.WriteLine("Invalid input. Please try again.");
                        }
                    } else if (userInt == 6) {
                        // Remove a student from a course’s roster
                        Console.WriteLine("\n\n******************************\n");
                        Console.Write("Course code: ");
                        var courseCode = Console.ReadLine() ?? string.Empty;
                        // TODO: query for course code, confirm specific course
                        Console.Write("Student name: ");
                        var studentName = Console.ReadLine() ?? string.Empty;
                        // TODO: query for student, confirm specific student

                        // TODO: remove student from course's roster
                    } else if (userInt == 7) {
                        // Exit
                        cont = false;
                    } else {
                        Console.WriteLine("Invalid input. Please try again");
                    }
                } else {
                    Console.WriteLine("Invalid input. Please try again");
                }
            }
        }
    }
}
