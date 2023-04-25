using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Library.LMSystem.Models;
using Library.LMSystem.Services;
using CommunityToolkit.Maui.Views;
using MAUI.LMSystem.Popups;
using MAUI.LMSystem.Views;

namespace MAUI.LMSystem.ViewModels
{
    public partial class ModifyCourseViewModel : IQueryAttributable, INotifyPropertyChanged
    {
        public ModifyCourseViewModel()
        {
        }

        private CourseService courseService;

        private StudentService studentService;

        public Course Course {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [RelayCommand]
        void EditDetails() {
            var popup = new ModifyCourseDetailsPopup(courseService, Course);
            Shell.Current.ShowPopup(popup);
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
        void GradeAssignment() {
            var popup = new GradeAssignmentPopup(Course, studentService);
            Shell.Current.ShowPopup(popup);
        }

        [RelayCommand]
        void GoBack() {
            var parameters = new Dictionary<string, object>();
            parameters.Add("courseService", courseService);
            parameters.Add("studentService", studentService);
            Shell.Current.GoToAsync("//CoursesPage", parameters);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Course = query["course"] as Course;
            courseService = query["courseService"] as CourseService;
            studentService = query["studentService"] as StudentService;
        }

        private void NotifyPropertyChanged(String propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

