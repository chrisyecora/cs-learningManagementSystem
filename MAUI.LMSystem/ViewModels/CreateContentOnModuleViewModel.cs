using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using Library.LMSystem.Models;
using Library.LMSystem.Services;
using MAUI.LMSystem.Popups;

namespace MAUI.LMSystem.ViewModels
{
    public partial class CreateContentOnModuleViewModel : IQueryAttributable, INotifyPropertyChanged
    {
        public CreateContentOnModuleViewModel()
        {
        }

        private CourseService courseService;
        private StudentService studentService;
        private Course Course {
            get;
            set;
        }

        public Module SelectedModule {
            get;
            set;
        }

        public ObservableCollection<Module> Modules {
            get;
            set;
        }

        [RelayCommand]
        void GoBack() {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studentService", studentService);
            parameters.Add("courseService", courseService);
            parameters.Add("course", Course);
            Shell.Current.GoToAsync("//ModifyCoursePage", parameters);
        }

        [RelayCommand]
        void CreateAssignmentItem() {
            var assignments = Course.AssignmentGroups.SelectMany(group => group.Assignments);
            var popup = new CreateAssignmentItemPopup(courseService, SelectedModule, Course);
            Shell.Current.ShowPopup(popup);
        }

        [RelayCommand]
        void CreateFileItem() {
            var popup = new CreateFileItemPopup(courseService, SelectedModule);
            Shell.Current.ShowPopup(popup);
        }

        [RelayCommand]
        void CreatePageItem() {
            var popup = new CreatePageItemPopup(courseService, SelectedModule);
            Shell.Current.ShowPopup(popup);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ApplyQueryAttributes(IDictionary<string, object> query) {
            Course = query["course"] as Course;
            courseService = query["courseService"] as CourseService;
            studentService = query["studentService"] as StudentService;
            Modules = new ObservableCollection<Module>(Course.Modules);
            NotifyPropertyChanged(nameof(Modules));
        }

        private void NotifyPropertyChanged(String propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

