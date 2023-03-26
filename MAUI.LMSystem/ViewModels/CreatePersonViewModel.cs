using System;
using System.ComponentModel;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace MAUI.LMSystem.ViewModels
{
    public class CreatePersonViewModel : INotifyPropertyChanged {
        public string Name {
            get; set;
        }

        private bool isStudent;
        public bool IsStudent {
            get {
                return isStudent;
            }
            set {
                isStudent = value;
                OnPropertyChanged(nameof(IsStudent));
            }
        }

        private bool isTA;
        public bool IsTA {
            get {
                return isTA;
            }
            set {
                isTA = value;
                OnPropertyChanged(nameof(IsTA));
            }
        }

        private bool isProf;
        public bool IsProfessor {
            get {
                return isProf;
            }
            set {
                isProf = value;
                OnPropertyChanged(nameof(IsProfessor));
            }
        } 

        public string Classification {
            get;set;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public CreatePersonViewModel()
        {
            isStudent = true;
            isTA = false;
            isProf = false;
            Classification = string.Empty;
        }

        public void CreatePerson(StudentService studentService) {
            var person = new Person();
            person.Name = Name;
            if (IsStudent) {
                var student = new Student(person);
                student.Classification = Classification;
                studentService.AddPerson(student);
            } else {
                studentService.AddPerson(person);
            }
        }
    }
}

