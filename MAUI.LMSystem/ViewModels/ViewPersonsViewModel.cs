using System;
using Library.LMSystem.Services;
using Library.LMSystem.Models;
namespace MAUI.LMSystem.ViewModels
{
    public class ViewPersonsViewModel
    {
        private StudentService studentService;
        public ViewPersonsViewModel(StudentService service)
        {
            studentService = service;
            Persons = studentService.GetPeople();
        }

        public IEnumerable<Person> Persons {
            get; set;
        }

        public string SearchQuery {
            get; set;
        }
    }
}

