using System;
using System.ComponentModel;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace MAUI.LMSystem.ViewModels
{
    public class ModifyPersonViewModel : INotifyPropertyChanged
    {
        public ModifyPersonViewModel(Person p, StudentService svc)
        {
            person = p;
            studentService = svc;
            if (p is Student) {
                IsStudent = true;
            }
            Name = person.Name;
            if (IsStudent) {
                Classification = (person as Student).Classification;
                NotifyPropertyChanged(nameof(Classification));
            }
            NotifyPropertyChanged(nameof(IsStudent));
            NotifyPropertyChanged(nameof(Name));
        }

        private StudentService studentService;
        private Person person;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name {
            get;
            set;
        }

        public string Classification {
            get;
            set;
        }

        public bool IsStudent {
            get;
            set;
        }

        public void Submit() {
            if (person is Student) {
                studentService.UpdatePerson(person, Name, Classification);
            } else {
                studentService.UpdatePerson(person, Name, null);
            }
        }

        private void NotifyPropertyChanged(String propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

