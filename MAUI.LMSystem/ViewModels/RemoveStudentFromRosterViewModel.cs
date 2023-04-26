using System;
using System.Collections.ObjectModel;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace MAUI.LMSystem.ViewModels
{
    public class RemoveStudentFromRosterViewModel
    {
        public RemoveStudentFromRosterViewModel(CourseService courseSvc, Course c)
        {
            courseService = courseSvc;
            course = c;
            Roster = new ObservableCollection<Person>(c.Roster);
        }

        public ObservableCollection<Person> Roster {
            get;
            set;
        }

        public Student SelectedStudent {
            get;
            set;
        }

        private CourseService courseService;
        private Course course;

        public void Submit() {
            courseService.RemovePersonFromRoster(course, SelectedStudent);
        }
    }
}

