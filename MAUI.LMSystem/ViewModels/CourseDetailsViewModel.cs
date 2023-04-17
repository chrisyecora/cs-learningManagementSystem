using System.Collections.ObjectModel;
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

        public ObservableCollection<Assignment> Assignments {
            get;
            set;
        }

        public ObservableCollection<Announcement> Announcements {
            get;
            set;
        }

        [RelayCommand]
        void GoBack() {
            Shell.Current.GoToAsync("//CoursesPage");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ApplyQueryAttributes(IDictionary<string, object> query) {
            Course = query["course"] as Course;
            Assignments = new ObservableCollection<Assignment>(Course.AssignmentGroups.SelectMany(c => c.Assignments));
            Announcements = new ObservableCollection<Announcement>(Course.Announcements);
            NotifyPropertyChanged(nameof(Course));
            NotifyPropertyChanged(nameof(Assignments));
            NotifyPropertyChanged(nameof(Announcements));
        }

        private void NotifyPropertyChanged(String propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

