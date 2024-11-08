﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace MAUI.LMSystem.ViewModels
{
    public partial class AddAssignmentViewModel : IQueryAttributable, INotifyPropertyChanged
    {
        private Course course;
        private CourseService courseService;
        private StudentService studentService;
        public AddAssignmentViewModel()
        {
            
        }

        public AssignmentGroup SelectedAssignmentGroup {
            get;
            set;
        }

        public ObservableCollection<AssignmentGroup> AssignmentGroups {
            get;
            set;
        }

        public String Name {
            get;
            set;
        }
        public String Description {
            get;
            set;
        }
        public int TotalPoints {
            get;
            set;
        }
        public string DueDate {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ApplyQueryAttributes(IDictionary<string, object> query) {
            course = query["course"] as Course;
            courseService = query["courseService"] as CourseService;
            studentService = query["studentService"] as StudentService;
            AssignmentGroups = new ObservableCollection<AssignmentGroup>(this.course.AssignmentGroups);
            NotifyPropertyChanged(nameof(AssignmentGroups));
        }

        [RelayCommand]
        void Cancel() {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studentService", studentService);
            parameters.Add("courseService", courseService);
            parameters.Add("course", course);
            Shell.Current.GoToAsync("//ModifyCoursePage", parameters);
        }

        [RelayCommand]
        void Submit() {
            var assignment = new Assignment {
                Name = this.Name,
                Description = this.Description,
                TotalPoints = this.TotalPoints,
                DueDate = DateTime.Parse(this.DueDate)
            };
            courseService.AddAssignmentToCourse(course, assignment, SelectedAssignmentGroup);

            // reset fields
            Name = string.Empty;
            Description = string.Empty;
            TotalPoints = 0;
            DueDate = string.Empty;
            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Description));
            NotifyPropertyChanged(nameof(TotalPoints));
            NotifyPropertyChanged(nameof(DueDate));

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studentService", studentService);
            parameters.Add("courseService", courseService);
            parameters.Add("course", course);
            Shell.Current.GoToAsync("//ModifyCoursePage", parameters);

        }

        private void NotifyPropertyChanged(String propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

