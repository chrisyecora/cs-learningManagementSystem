using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace MAUI.LMSystem.ViewModels
{
    public class GradeAssignmentViewModel : INotifyPropertyChanged
    {
        public GradeAssignmentViewModel(Course c, StudentService svc)
        {
            Course = c;
            studentService = svc;
            Assignments = new ObservableCollection<Assignment>(Course.AssignmentGroups.SelectMany(c => c.Assignments));
            Roster = new ObservableCollection<Person>(Course.Roster);
            NotifyPropertyChanged(nameof(Assignments));
            NotifyPropertyChanged(nameof(Roster));
        }

        public Assignment SelectedAssignment {
            get;
            set;
        }

        public Person SelectedPerson {
            get;
            set;
        }

        public ObservableCollection<Assignment> Assignments {
            get;
            set;
        }

        public ObservableCollection<Person> Roster {
            get;
            set;
        }

        public string PointsEarned {
            get;
            set;
        }

        public Course Course {
            get;
            set;
        }
        private StudentService studentService;

        public event PropertyChangedEventHandler PropertyChanged;

        public void Submit() {
            var grade = double.Parse(PointsEarned) / (double)SelectedAssignment.TotalPoints;
            studentService.AddGrade(SelectedPerson, SelectedAssignment.Id, grade);
        }

        private void NotifyPropertyChanged(String propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

