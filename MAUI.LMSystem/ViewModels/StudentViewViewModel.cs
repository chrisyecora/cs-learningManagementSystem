using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace MAUI.LMSystem.ViewModels
{
    public partial class StudentViewViewModel : IQueryAttributable, INotifyPropertyChanged
    {
        public StudentViewViewModel()
        {
        }

        public ObservableCollection<Course> Courses {
            get;
            set;
        }

        private StudentService studentService;
        private CourseService courseService;
        private Student student;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query) {
            studentService = query["studentService"] as StudentService;
            courseService = query["courseService"] as CourseService;
            student = query["student"] as Student;
            Courses = new ObservableCollection<Course>(courseService.QueryByStudentInRosters(student));
            NotifyPropertyChanged(nameof(Courses));
        }

        [RelayCommand]
        static void GoHome() => Shell.Current.GoToAsync("//MainPage");

        [RelayCommand]
        void SomeoneElse() {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studentService", studentService);
            parameters.Add("courseService", courseService);
            Shell.Current.GoToAsync("//BufferStudent", parameters);
        }
    }
}

