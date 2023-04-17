using System;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace MAUI.LMSystem.ViewModels
{
    public class CreateAssignmentGroupViewModel
    {
        public CreateAssignmentGroupViewModel(Course course, CourseService service)
        {
            this.course = course;
            courseService = service;
        }

        private Course course;
        private CourseService courseService;

        public string Name {
            get;
            set;
        }

        private double weight;
        public double Weight {
            get {
                return weight;
            }
            set {
                weight = value / 100;
            }
        }

        
        public void Submit() {
            var newGroup = new AssignmentGroup { Name = this.Name, Weight = weight };
            courseService.AddAssignmentGroup(course, newGroup);
        }

    }
}

