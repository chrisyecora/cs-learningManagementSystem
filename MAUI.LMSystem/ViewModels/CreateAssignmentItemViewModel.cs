using System;
using System.Collections.ObjectModel;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace MAUI.LMSystem.ViewModels
{
    public class CreateAssignmentItemViewModel
    {
        public CreateAssignmentItemViewModel(CourseService svc, Module mod, Course course)
        {
            courseService = svc;
            module = mod;
            Assignments = new ObservableCollection<Assignment>(course.AssignmentGroups
                .SelectMany(group => group.Assignments));
        }

        private CourseService courseService;
        private Module module;

        public string Name {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public Assignment SelectedAssignment {
            get;
            set;
        }

        public ObservableCollection<Assignment> Assignments {
            get;
            set;
        }

        public void Submit() {
            var assignmentItem = new AssignmentItem();
            assignmentItem.Assignment = SelectedAssignment;
            assignmentItem.Name = Name;
            assignmentItem.Description = Description;
            courseService.AddAssignmentItemToModule(module, assignmentItem);
        }
    }
}

