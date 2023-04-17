using System;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace MAUI.LMSystem.ViewModels
{
    public class CreateModuleViewModel
    {
        public CreateModuleViewModel(CourseService svc, Course c)
        {
            courseService = svc;
            course = c;
        }

        private CourseService courseService;
        private Course course;

        public string Name {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public void Submit() {
            var newModule = new Module();
            newModule.Name = Name;
            newModule.Description = Description;
            courseService.AddModuleToCourse(course, newModule);
        }
    }
}

