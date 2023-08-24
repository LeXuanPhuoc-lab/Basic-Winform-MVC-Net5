using FirstWebApp_DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp_DemoMVC.Logics
{
    public class CourseScheduleManager
    {
        public static PRN211DemoADOContext context = new PRN211DemoADOContext();
        public List<CourseSchedule> GetAllCourseScheduleByCourseId(int CourseId)
        {
            var courseSchedules = 
                context.CourseSchedules.Where(x => x.CourseId == CourseId).ToList();
            foreach(CourseSchedule cs in courseSchedules)
            {
                Room Room =
                    context.Rooms.Where(x => x.RoomId == cs.RoomId).FirstOrDefault();
                if(Room != null) cs.Room = Room;
            }
            return courseSchedules;
        }

        public void AddCourseScheduleById(int CourseId, int month)
        {
            int currMonth = DateTime.Now.Month;
            for(int i= currMonth; i<= currMonth + month; ++i)
            {
                List<DateTime> dateTimes = GetDates(DateTime.Now.Year, i);
                foreach(DateTime dt in dateTimes)
                {
                    CourseSchedule courseSchedule = new CourseSchedule() 
                    { 
                        CourseId = CourseId, TeachingDate =  dt, Slot = 2, RoomId = 3
                    };
                    context.CourseSchedules.Add(courseSchedule);
                }
            }
            context.SaveChanges();
        }

        public static List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(year, month, day)) // Map each day to a date
                             .ToList(); // Load dates into a list
        }
    }
}
