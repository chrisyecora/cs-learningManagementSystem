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

        public void CreatePerson(ContentPage page) {
            var popup = new CreatePersonPopup(studentService);
            if (popup != null) {
                page.ShowPopup(popup);
            }
        }

        public async void ViewPersons(ContentPage page) {
            await page.Navigation.PushAsync(new ViewPersonsPage(studentService));
        }

        public void CreateCourse(ContentPage page) {
            var popup = new CreateCoursePopup(courseService);
            if (popup != null) {
                page.ShowPopup(popup);
            }
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

