using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Library.LMSystem.Models;
using Library.LMSystem.Services;
using CommunityToolkit.Maui.Views;
using MAUI.LMSystem.Popups;
using MAUI.LMSystem.Views;

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

        private StudentService studentService {
            get;
            set;
        }

        public Course Course {
            get;
            set;
        }

        [RelayCommand]
        void AddAssignment() {
            var parameters = new Dictionary<string, object>();
            parameters.Add("course", Course);
            parameters.Add("courseService", courseService);
            parameters.Add("studentService", studentService);
            Shell.Current.GoToAsync("//AddAssignmentPage", parameters);
        }

        [RelayCommand]
        void CreateAssignmentGroup() {
            var popup = new CreateAssignmentGroupPopup(Course, courseService);
            Shell.Current.ShowPopup(popup);
        }

        [RelayCommand]
        void AddAnnouncement() {
            var popup = new AddAnnouncementPopup(courseService, Course);
            Shell.Current.ShowPopup(popup);
        }

        [RelayCommand]
        void CreateModule() {
            var popup = new CreateModulePopup(courseService, Course);
            Shell.Current.ShowPopup(popup);
        }
        [RelayCommand]
        void CreateContentOnModule() {
            var parameters = new Dictionary<string, object>();
            parameters.Add("course", Course);
            parameters.Add("courseService", courseService);
            parameters.Add("studentService", studentService);
            Shell.Current.GoToAsync("//CreateContentOnModulePage", parameters);
        }

        [RelayCommand]
        void AddStudentToRoster() {
            var popup = new AddStudentToRosterPopup(courseService, studentService, Course);
            Shell.Current.ShowPopup(popup);
        }

        [RelayCommand]
        void GoBack() {
            Shell.Current.GoToAsync("//CoursesPage");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Course = query["course"] as Course;
            courseService = query["courseService"] as CourseService;
            studentService = query["studentService"] as StudentService;
        }
    }
}

