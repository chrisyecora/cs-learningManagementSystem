using CommunityToolkit.Maui.Views;
using Library.LMSystem.Services;
using MAUI.LMSystem.Popups;
namespace MAUI.LMSystem.ViewModels
{
    public class MainViewModel
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
    }
}

