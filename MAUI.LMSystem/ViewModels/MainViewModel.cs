using System;
using Library.LMSystem.Services;
using MAUI.LMSystem.Popups;
using CommunityToolkit.Maui.Views;

namespace MAUI.LMSystem.ViewModels
{
    public class MainViewModel
    {
        private StudentService studentService;
        private CourseService courseService;
        public MainViewModel()
        {
            studentService = new StudentService();
            courseService = new CourseService();
        }

        public void CreatePerson(ContentPage page) {
            var popup = new CreatePersonPopup(studentService);
            if (popup != null) {
                page.ShowPopup(popup);
            }
        }
    }
}

