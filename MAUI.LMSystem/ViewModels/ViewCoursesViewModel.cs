using System;
using Library.LMSystem.Services;
using Library.LMSystem.Models;
namespace MAUI.LMSystem.ViewModels
{
    public class ViewCoursesViewModel
    {
        private CourseService courseService;
        public ViewCoursesViewModel(CourseService service)
        {
            courseService = service;
            Courses = courseService.GetCourses();
        }

        public IEnumerable<Course> Courses {
            get; set;
        }

        public string SearchQuery {
            get; set;
        }
    }
}

