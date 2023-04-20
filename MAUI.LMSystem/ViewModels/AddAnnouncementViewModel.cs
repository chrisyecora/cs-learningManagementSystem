using System;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace MAUI.LMSystem.ViewModels
{
    public class AddAnnouncementViewModel
    {
        private CourseService courseService;
        private Course course;
        public AddAnnouncementViewModel(CourseService svc, Course _course)
        {
            courseService = svc;
            course = _course;
        }

        public string Title {
            get;
            set;
        }

        public string Body {
            get;
            set;
        }

        public void Submit() {
            var newAnnouncement = new Announcement();
            newAnnouncement.Title = Title;
            newAnnouncement.Body = Body;
            courseService.AddAnnouncementToCourse(course, newAnnouncement);
        }
    }
}

