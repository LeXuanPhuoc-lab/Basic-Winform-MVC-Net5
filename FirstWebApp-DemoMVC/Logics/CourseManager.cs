using FirstWebApp_DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp_DemoMVC.Logics
{
    public class CourseManager
    {
        public static PRN211DemoADOContext context = new PRN211DemoADOContext();
        public List<Course> GetCoursesBySubjectId(int SubjectId)
        {
            return context.Courses.Where(x => x.SubjectId == SubjectId).ToList();
        }

        public List<Course> GetAllCourses()
        {
            return context.Courses.ToList();
        }

        public Course GetCourseById(int CourseId)
        {
            return context.Courses.Where(x => x.CourseId == CourseId).FirstOrDefault();
        }

        public void UpdateCourse(Course course)
        {
            if (course == null) return;

            Course prevCourse = context.Courses.Where(x => x.CourseId == course.CourseId).FirstOrDefault();
            if (prevCourse == null) return;

            // Update Course Info
            prevCourse.CourseCode = course.CourseCode;
            prevCourse.CourseDescription = course.CourseDescription;
            prevCourse.InstructorId = course.InstructorId;
            prevCourse.SubjectId = course.SubjectId;
            prevCourse.TempId = course.TempId;
            prevCourse.CampusId = course.CampusId;

            // update to DB
            context.SaveChanges();
        }

        public void AddCouse(Course course)
        {
            if (course == null) return;
            context.Courses.Add(course);
            context.SaveChanges();
        }

        public void DeleteCourseById(int CourseId)
        {
            Course course = context.Courses.Where(x => x.CourseId == CourseId).FirstOrDefault();
            if (course == null) return;

            // remove course in StudentCourse
            var studentCourses
                = context.StudentCourses.Where(x => x.CourseId == course.CourseId).ToList();
            if (studentCourses.Count > 0) context.StudentCourses.RemoveRange(studentCourses);
            // remove course schedules
            var courseSchedules
                = context.CourseSchedules.Where(x => x.CourseId == course.CourseId).ToList();
            // remove course in Roll call Book
            foreach (CourseSchedule cs in courseSchedules)
            {
                List<RollCallBook> rollCallBooks
                    = context.RollCallBooks.Where(x => x.TeachingScheduleId == cs.TeachingScheduleId).ToList();
                context.RollCallBooks.RemoveRange(rollCallBooks);
            }
            if (courseSchedules.Count > 0) context.CourseSchedules.RemoveRange(courseSchedules);
            // remove course in Course Schedule
            context.Courses.Remove(course);
            context.SaveChanges();
        }
    }
}
