using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using Library.LMSystem.Models;
using Library.LMSystem.Services;
using System.Runtime.CompilerServices;

namespace MAUI.LMSystem.ViewModels
{
    public partial class ViewCoursesViewModel : IQueryAttributable, INotifyPropertyChanged
    {
        private CourseService courseService {
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

        public IEnumerable<Course> Courses {
            get; set;
        }

        public string SearchQuery {
            get; set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [RelayCommand]
        async Task GoBack() {
            await Shell.Current.GoToAsync("//Instructor");
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
            parameters.Add("course", SelectedCourse);
            Shell.Current.GoToAsync("//ModifyCoursePage", parameters);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query) {
            courseService = query["courseService"] as CourseService;
            Courses = courseService.GetCourses();
            NotifyPropertyChanged(nameof(Courses));
        }

        private void NotifyPropertyChanged(String propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

