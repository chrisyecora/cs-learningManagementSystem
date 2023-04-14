using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace MAUI.LMSystem.ViewModels
{
    public partial class ModifyCourseViewModel : IQueryAttributable
    {
        public ModifyCourseViewModel()
        {
        }

        private CourseService courseService {
            get;
            set;
        }

        public Course Course {
            get;
            set;
        }

        [RelayCommand]
        void GoBack() {
            Shell.Current.GoToAsync("//CoursesPage");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Course = query["course"] as Course;
            courseService = query["courseService"] as CourseService;
        }
    }
}

