using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Library.LMSystem.Models;

namespace MAUI.LMSystem.ViewModels
{
    public partial class CourseDetailsViewModel : IQueryAttributable, INotifyPropertyChanged {
        public CourseDetailsViewModel() {
        }

        public Course Course {
            get;
            set;
        }

        private Module _selectedModule;
        public Module SelectedModule {
            get {
                return _selectedModule;
            }
            set {
                _selectedModule = value;
                CurrentModuleContent = new ObservableCollection<ContentItem>(value.Content);
                NotifyPropertyChanged(nameof(CurrentModuleContent));
            }
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

        [RelayCommand]
        void GoBack() {
            Shell.Current.GoToAsync("//CoursesPage");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ApplyQueryAttributes(IDictionary<string, object> query) {
            Course = query["course"] as Course;
            Assignments = new ObservableCollection<Assignment>(Course.AssignmentGroups.SelectMany(c => c.Assignments));
            Announcements = new ObservableCollection<Announcement>(Course.Announcements);
            Modules = new ObservableCollection<Module>(Course.Modules);
            NotifyPropertyChanged(nameof(Course));
            NotifyPropertyChanged(nameof(Assignments));
            NotifyPropertyChanged(nameof(Announcements));
            NotifyPropertyChanged(nameof(Modules));
        }

        private void NotifyPropertyChanged(String propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

