using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace MAUI.LMSystem.ViewModels
{
    public class AddStudentToRosterViewModel
    {
        public AddStudentToRosterViewModel(CourseService courseSvc, StudentService studentSvc, Course c)
        {
            courseService = courseSvc;
            studentService = studentSvc;
            course = c;
            Students = new ObservableCollection<Person>(studentService.GetPeople());
        }

        public ObservableCollection<Person> Students {
            get;
            set;
        }

        public Student SelectedStudent {
            get;
            set;
        }

        private CourseService courseService;
        private StudentService studentService;
        private Course course;

        public void Submit() {
            courseService.AddStudent(course, SelectedStudent);
        }
    }
}

