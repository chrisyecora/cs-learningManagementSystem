using System;
using Library.LMSystem.Models;
using Library.LMSystem.Services;
namespace MAUI.LMSystem.ViewModels
{
    public class CreateFileItemViewModel
    {
        public CreateFileItemViewModel(CourseService svc, Module mod)
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
            var fileItem = new FileItem();
            fileItem.Name = Name;
            fileItem.Description = Description;
            courseService.AddFileItemToModule(module, fileItem);
        }
    }
}

