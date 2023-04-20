using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using Library.LMSystem.Models;
using MAUI.LMSystem.Popups;

namespace MAUI.LMSystem.ViewModels
{
    public partial class CourseDetailsViewModel : IQueryAttributable, INotifyPropertyChanged {
        public CourseDetailsViewModel() {
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

        public ObservableCollection<Module> Modules {
            get;
            set;
        }

        public ObservableCollection<ContentItem> CurrentModuleContent {
            get;
            set;
        }

        public ObservableCollection<Person> Roster {
            get;
            set;
        }

        public Module SelectedModule {
            get;
            set;
        }

        [RelayCommand]
        void GoBack() {
            Shell.Current.GoToAsync("//CoursesPage");
        }

        [RelayCommand]
        void ViewModule() {
            var popup = new ModuleDetailsPopup(SelectedModule);
            Shell.Current.ShowPopup(popup);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ApplyQueryAttributes(IDictionary<string, object> query) {
            Course = query["course"] as Course;
            Assignments = new ObservableCollection<Assignment>(Course.AssignmentGroups.SelectMany(c => c.Assignments));
            Announcements = new ObservableCollection<Announcement>(Course.Announcements);
            Modules = new ObservableCollection<Module>(Course.Modules);
            Roster = new ObservableCollection<Person>(Course.Roster);
            NotifyPropertyChanged(nameof(Course));
            NotifyPropertyChanged(nameof(Assignments));
            NotifyPropertyChanged(nameof(Announcements));
            NotifyPropertyChanged(nameof(Modules));
            NotifyPropertyChanged(nameof(Roster));
        }

        private void NotifyPropertyChanged(String propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

