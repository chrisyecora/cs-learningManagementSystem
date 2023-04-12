using CommunityToolkit.Maui.Views;
using Library.LMSystem.Services;
using CommunityToolkit.Mvvm.Input;
using MAUI.LMSystem.Popups;
using MAUI.LMSystem.Views;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MAUI.LMSystem.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private StudentService studentService;
        private CourseService courseService;
        public MainViewModel()
        {
            studentService = new StudentService();
            courseService = new CourseService();
        }

        [RelayCommand]
        void InstructorView() {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studentService", studentService);
            parameters.Add("courseService", courseService);
            Shell.Current.GoToAsync("//Instructor", parameters);
        }

        

        [RelayCommand]
        async Task ViewCoursesAsync() {
            var navParam = new Dictionary<string, object>();
            navParam.Add("courseService", courseService);
            navParam.Add("courses", courseService.GetCourses());
            await Shell.Current.GoToAsync("//CoursesPage", navParam);
        }
    }
}

