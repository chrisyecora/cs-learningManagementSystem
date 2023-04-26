using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace MAUI.LMSystem.ViewModels
{
    public partial class BufferStudentViewModel : IQueryAttributable, INotifyPropertyChanged
    {
        public BufferStudentViewModel()
        {
        }

        private StudentService studentService;
        private CourseService courseService;
        public ObservableCollection<Person> Students {
            get;
            set;
         }

        public Student SelectedStudent {
            get;
            set;
        }

        [RelayCommand]
        void ThisIsMe() {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studentService", studentService);
            parameters.Add("courseService", courseService);
            parameters.Add("student", SelectedStudent);
            Shell.Current.GoToAsync("//Student", parameters);
        }

        [RelayCommand]
        void GoBack() {
            Shell.Current.GoToAsync("//MainPage");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query) {
            studentService = query["studentService"] as StudentService;
            courseService = query["courseService"] as CourseService;
            Students = new ObservableCollection<Person>(
                studentService.GetPeople().Where(person => person is Student)
            );
            NotifyPropertyChanged(nameof(Students));
        }
    }
}

