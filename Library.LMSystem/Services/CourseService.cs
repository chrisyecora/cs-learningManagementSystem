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

        public void AddStudent(Course course, Person person) {
            if (!course.Roster.Contains(person)) {
                course.Roster.Add(person);
            }
        }

        public void UpdateCourse(Course course, string code, string name, string desc) {
            if (!code.Equals(string.Empty)) {
                course.CourseCode = code;
            }
            if (!name.Equals(string.Empty)) {
                course.Name = name;
            }
            if (!desc.Equals(string.Empty)) {
                course.Description = desc;
            }
        }

        public void AddAssignmentToCourse(Course course, Assignment assignment, AssignmentGroup? assignmentGroup = null) {
            if (assignmentGroup == null) {
                var defaultGroup = course.AssignmentGroups.Find(group => group.Name == "Uncategorized");
                defaultGroup?.Assignments.Add(assignment);
            } else {
                assignmentGroup.Assignments.Add(assignment);
            }
        }

        public void AddAssignmentGroup(Course course, AssignmentGroup assignmentGroup) {
            course.AssignmentGroups.Add(assignmentGroup);
        }

        public void AddAnnouncementToCourse(Course course, Announcement announcement) {
            course.Announcements.Add(announcement);
        }

        public void UpdateAnnouncement(Announcement announcement, string title, string body) {
            if (!title.Equals(string.Empty)) {
                announcement.Title = title;
            }
            if (!body.Equals(string.Empty)) {
                announcement.Body = body;
            }
        }

        public void DeleteAnnouncement(Course course, Announcement announcement) {
            course.Announcements.Remove(announcement);
        }

        public void AddModuleToCourse(Course course, Module module) {
            course.Modules.Add(module);
        }

        public void UpdateModule(Module module, string name, string desc) {
            if (!name.Equals(string.Empty)) {
                module.Name = name;
            }
            if (!desc.Equals(string.Empty)) {
                module.Description = desc;
            }
        }

        public void DeleteModule(Course course, Module module) {
            course.Modules.Remove(module);
        }

        public void AddAssignmentItemToModule(Module module, AssignmentItem item) {
            module.Content.Add(item);
        }
        public void AddPageItemToModule(Module module, PageItem item) {
            module.Content.Add(item);
        }
        public void AddFileItemToModule(Module module, FileItem item) {
            module.Content.Add(item);
        }

        public void UpdateContentItem(ContentItem item, string name, string desc) {
            if (!name.Equals(string.Empty)) {
                item.Name = name;
            }
            if (!desc.Equals(string.Empty)) {
                item.Description = desc;
            }
        }

        public void DeleteContentItem(Module module, ContentItem item) {
            module.Content.Remove(item);
        }

        public List<ContentItem> GetContentItems(Module module) {
            return module.Content;
        }

        public IEnumerable<Assignment> GetAssignments(Course course) {
            return course.AssignmentGroups.SelectMany(c => c.Assignments);
        }

        public List<Module> GetModules(Course course) {
            return course.Modules;
        }

        public List<Announcement> GetAnnouncements(Course course) {
            return course.Announcements;
        }

        public List<Person> GetRoster(Course course) {
            return course.Roster;
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

