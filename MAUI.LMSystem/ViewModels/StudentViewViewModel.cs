using System;
using CommunityToolkit.Mvvm.Input;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace MAUI.LMSystem.ViewModels
{
    public partial class StudentViewViewModel : IQueryAttributable
    {
        public StudentViewViewModel()
        {
        }

        private StudentService studentService;
        private CourseService courseService;
        private Student student;


        public void ApplyQueryAttributes(IDictionary<string, object> query) {
            studentService = query["studentService"] as StudentService;
            courseService = query["courseService"] as CourseService;
            student = query["student"] as Student;
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

