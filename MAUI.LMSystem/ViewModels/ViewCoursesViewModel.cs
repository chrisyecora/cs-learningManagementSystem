using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using Library.LMSystem.Models;
using Library.LMSystem.Services;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace MAUI.LMSystem.ViewModels
{
    public partial class ViewCoursesViewModel : IQueryAttributable, INotifyPropertyChanged
    {
        private CourseService courseService {
            get;
            set;
        }

        private StudentService studentService {
            get;
            set;
        }

        public ViewCoursesViewModel()
        {
        }

        public Course SelectedCourse {
            get;
            set;
        }

        public ObservableCollection<Course> Courses {
            get; set;
        }

        public string SearchQuery {
            get; set;
        }

        public string ActiveSearchMessage {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [RelayCommand]
        async Task GoBack() {
            await Shell.Current.GoToAsync("//Instructor");
        }

        [RelayCommand]
        void Search() {
            var results = courseService.SearchCourses(SearchQuery);
            Courses = new ObservableCollection<Course>(results);
            ActiveSearchMessage = $"Showing results for '{SearchQuery}'";
            NotifyPropertyChanged(nameof(ActiveSearchMessage));
            NotifyPropertyChanged(nameof(Courses));
        }

        [RelayCommand]
        void ClearSearch() {
            SearchQuery = string.Empty;
            Courses = new ObservableCollection<Course>(courseService.GetCourses());
            ActiveSearchMessage = string.Empty;
            NotifyPropertyChanged(nameof(Courses));
            NotifyPropertyChanged(nameof(SearchQuery));
            NotifyPropertyChanged(nameof(ActiveSearchMessage));
        }

        [RelayCommand]
        void CourseDetails() {
            var parameters = new Dictionary<string, object>();
            parameters.Add("course", SelectedCourse);
            Shell.Current.GoToAsync("//CourseDetailsPage", parameters);
        }

        [RelayCommand]
        void ModifyCourse() {
            var parameters = new Dictionary<string, object>();
            parameters.Add("courseService", courseService);
            parameters.Add("studentService", studentService);
            parameters.Add("course", SelectedCourse);
            Shell.Current.GoToAsync("//ModifyCoursePage", parameters);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query) {
            courseService = query["courseService"] as CourseService;
            studentService = query["studentService"] as StudentService;
            Courses = new ObservableCollection<Course>(courseService.GetCourses());
            NotifyPropertyChanged(nameof(Courses));
        }

        private void NotifyPropertyChanged(String propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

