using System;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace MAUI.LMSystem.ViewModels
{
    public class AddAssignmentViewModel
    {
        private Course course;
        private CourseService courseService;
        public AddAssignmentViewModel(Course course, CourseService courseService)
        {
            this.course = course;
            this.courseService = courseService;
        }

        public String Name {
            get;
            set;
        }
        public String Description {
            get;
            set;
        }
        public int TotalPoints {
            get;
            set;
        }
        public string DueDate {
            get;
            set;
        }

        public void Submit() {
            var assignment = new Assignment {
                Name = this.Name,
                Description = this.Description,
                TotalPoints = this.TotalPoints,
                DueDate = DateTime.Parse(this.DueDate)
            };

        }
    }
}

