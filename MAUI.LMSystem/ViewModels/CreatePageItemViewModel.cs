using System;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace MAUI.LMSystem.ViewModels
{
    public class CreatePageItemViewModel
    {
        public CreatePageItemViewModel(CourseService svc, Module mod)
        {
            courseService = svc;
            module = mod;
        }

        private Module module;
        private CourseService courseService;

        public string Name {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public void Submit() {
            var pageItem = new PageItem();
            pageItem.Name = Name;
            pageItem.Description = Description;
            courseService.AddPageItemToModule(module, pageItem);
        }
    }
}

