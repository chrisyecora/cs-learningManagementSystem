using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace MAUI.LMSystem.ViewModels
{
    [QueryProperty(nameof(CourseService), "courseService")]
    [QueryProperty(nameof(Courses), "courses")]
    public partial class ViewCoursesViewModel : ObservableObject
    {
        [ObservableProperty]
        private CourseService courseService; 
        public ViewCoursesViewModel()
        {
        }

        [ObservableProperty]
        public IEnumerable<Course> courses;

        public string SearchQuery {
            get; set;
        }

        [RelayCommand]
        async Task GoBack() {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}

