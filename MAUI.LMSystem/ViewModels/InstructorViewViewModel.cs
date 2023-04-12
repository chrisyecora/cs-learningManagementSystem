using System;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using Library.LMSystem.Services;
using MAUI.LMSystem.Popups;
using MAUI.LMSystem.Views;

namespace MAUI.LMSystem.ViewModels
{
    public partial class InstructorViewViewModel : IQueryAttributable
    {
        public InstructorViewViewModel()
        {
        }

        private StudentService studentService {
            get;
            set;
        }
        private CourseService courseService {
            get;
            set;
        }

        public void CreatePerson(ContentPage page) {
            var popup = new CreatePersonPopup(studentService);
            if (popup != null) {
                page.ShowPopup(popup);
            }
        }

        public void ViewPersons(ContentPage page) {
            
        }

        public void CreateCourse(ContentPage page) {
            var popup = new CreateCoursePopup(courseService);
            if (popup != null) {
                page.ShowPopup(popup);
            }
        }

        [RelayCommand]
        void ViewCourses() {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("courseService", courseService);
            Shell.Current.GoToAsync("//CoursesPage", parameters);
        }

        [RelayCommand]
        void ViewPersons() {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studentService", studentService);
            Shell.Current.GoToAsync("//PersonsPage", parameters);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            studentService = query["studentService"] as StudentService;
            courseService = query["courseService"] as CourseService;
        }
    }
}

