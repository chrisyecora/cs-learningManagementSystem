using System;
using Library.LMSystem.Models;

namespace Library.LMSystem.Services
{
    public class CourseService
    {
        public List<Course> Courses {
            get;
            set;
        }

        private HashSet<string> CourseCodes {
            get;
            set;
        }
        public CourseService()
        {
            Courses = new List<Course>();
            CourseCodes = new HashSet<string>();
        }

        public bool AddCourse(Course course) {
            if (CourseCodes.Add(course.CourseCode)) {
                Courses.Add(course);
                return true;
            }
            return false;
        }

        public void AddAssignmentToCourse(Course course, Assignment assignment) {
            if (course.Assignments.Count > 0) {
                assignment.Id = course.Assignments.Max(a => a.Id) + 1;
            } else {
                assignment.Id = 1;
            }
            course.Assignments.Add(assignment);
        }

        public void AddAnnouncementToCourse(Course course, Announcement announcement) {
            course.Announcements.Add(announcement);
        }

        public IEnumerable<Course> QueryByCode(String code) {
            return Courses.Where(c => c.CourseCode.Equals(code, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<Course> QueryByName(String name) {
            return Courses.Where(c => c.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<Course> QueryByDescription(String description) {
            return Courses.Where(c => c.Description.Contains(description, StringComparison.InvariantCultureIgnoreCase));
        }

        public List<Course> QueryByStudentInRosters(Person student){
            var courses = new List<Course>();
            foreach (var course in Courses) {
                var query = course.Roster.Where(stu => stu.Name.Contains(student.Name, StringComparison.InvariantCultureIgnoreCase));
                if (query.ToList().Count() > 0) {
                    courses.Add(course);
                }
            }
            return courses;
        }

        public IEnumerable<Announcement> QueryForAnnouncements(Course course, String query) {
            return course.Announcements.Where(announcement => announcement.Title.Contains(query));
        }

        public IEnumerable<Module> QueryForModules(Course course, String query) {
            return course.Modules.Where(announcement => announcement.Name.Contains(query));
        }
    }
}

