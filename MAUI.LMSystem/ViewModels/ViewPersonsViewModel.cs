using System;
using Library.LMSystem.Services;
using Library.LMSystem.Models;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using MAUI.LMSystem.Popups;
using CommunityToolkit.Maui.Views;

namespace MAUI.LMSystem.ViewModels
{
    public partial class ViewPersonsViewModel : INotifyPropertyChanged, IQueryAttributable
    {
        private StudentService studentService;
        public ViewPersonsViewModel()
        {
        }

        public ObservableCollection<Person> Persons {
            get; set;
        }

        public string SearchQuery {
            get; set;
        }

        public string ActiveSearchMessage {
            get;
            set;
        }

        public Person SelectedPerson {
            get;
            set;
        }

        [RelayCommand]
        void ModifyPerson() {
            var popup = new ModifyPersonPopup(SelectedPerson, studentService);
            Shell.Current.ShowPopup(popup);
        }

        [RelayCommand]
        void Refresh() {
            Persons = new ObservableCollection<Person>(studentService.GetPeople());
            NotifyPropertyChanged(nameof(Persons));
        }

        [RelayCommand]
        void Search() {
            var results = studentService.QueryByName(SearchQuery);
            Persons = new ObservableCollection<Person>(results);
            ActiveSearchMessage = $"Showing results for '{SearchQuery}'";
            NotifyPropertyChanged(nameof(ActiveSearchMessage));
            NotifyPropertyChanged(nameof(Persons));
        }

        [RelayCommand]
        void ClearSearch() {
            SearchQuery = string.Empty;
            Persons = new ObservableCollection<Person>(studentService.GetPeople());
            ActiveSearchMessage = string.Empty;
            NotifyPropertyChanged(nameof(Persons));
            NotifyPropertyChanged(nameof(SearchQuery));
            NotifyPropertyChanged(nameof(ActiveSearchMessage));
        }

        [RelayCommand]
        void GoBack() {
            Shell.Current.GoToAsync("//Instructor");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ApplyQueryAttributes(IDictionary<string, object> query) {
            studentService = query["studentService"] as StudentService;
            Persons = new ObservableCollection<Person>(studentService.GetPeople());
            NotifyPropertyChanged(nameof(Persons));
        }

        private void NotifyPropertyChanged(String propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

