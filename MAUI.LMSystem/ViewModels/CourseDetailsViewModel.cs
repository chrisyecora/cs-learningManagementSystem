using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Library.LMSystem.Models;

namespace MAUI.LMSystem.ViewModels
{
    public partial class CourseDetailsViewModel : IQueryAttributable, INotifyPropertyChanged {
        public CourseDetailsViewModel()
        {
        }

        public Course Course {
            get;
            set;
        }

        private IEnumerable<Assignment> assignments;
        public IEnumerable<Assignment> Assignments {
            get {
                return assignments;
            }
        }

        [RelayCommand]
        void GoBack() {
            Shell.Current.GoToAsync("//CoursesPage");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ApplyQueryAttributes(IDictionary<string, object> query) {
            Course = query["course"] as Course;
            assignments = Course.AssignmentGroups.SelectMany(c => c.Assignments);
            NotifyPropertyChanged(nameof(Course));
        }

        private void NotifyPropertyChanged(String propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

