using System;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace MAUI.LMSystem.ViewModels
{
    public class CreateCourseViewModel
    {
        public string Code {
            get; set;
        }
        public string Name {
            get; set;
        }
        public string Description {
            get; set;
        }
        public int CreditHours {
            get; set;
        }
        public CreateCourseViewModel()
        {
        }
        public void CreateCourse(CourseService courseService) {
            var course = new Course();
            course.CourseCode = Code;
            course.Name = Name;
            course.Description = Description;
            course.CreditHours = CreditHours;
            courseService.AddCourse(course);
        }
    }
}

