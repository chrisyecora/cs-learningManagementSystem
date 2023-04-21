using System;
using System.ComponentModel;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace MAUI.LMSystem.ViewModels
{
    public class ModifyCourseDetailsViewModel : INotifyPropertyChanged
    {
        public ModifyCourseDetailsViewModel(CourseService svc, Course c)
        {
            courseService = svc;
            course = c;
            Code = course.CourseCode;
            Name = course.Name;
            Description = course.Description;
            CreditHours = course.CreditHours;
            NotifyPropertyChanged(nameof(Code));
            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Description));
            NotifyPropertyChanged(nameof(CreditHours));
        }

        private CourseService courseService;
        private Course course;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Code {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public int CreditHours {
            get;
            set;
        }

        public void Submit() {
            courseService.UpdateCourse(course, Code, Name, Description, CreditHours);
        }

        private void NotifyPropertyChanged(String propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

