using System;
using Library.LMSystem.Services;
using Library.LMSystem.Models;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MAUI.LMSystem.ViewModels
{
    public partial class ViewPersonsViewModel : INotifyPropertyChanged, IQueryAttributable
    {
        private StudentService studentService;
        public ViewPersonsViewModel()
        {
        }

        public IEnumerable<Person> Persons {
            get; set;
        }

        public string SearchQuery {
            get; set;
        }

        [RelayCommand]
        void GoBack() {
            Shell.Current.GoToAsync("//Instructor");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ApplyQueryAttributes(IDictionary<string, object> query) {
            studentService = query["studentService"] as StudentService;
            Persons = studentService.GetPeople();
            NotifyPropertyChanged(nameof(Persons));
        }

        private void NotifyPropertyChanged(String propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

