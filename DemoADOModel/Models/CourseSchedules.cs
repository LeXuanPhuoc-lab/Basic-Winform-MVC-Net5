using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADOModel.Models
{
    class CourseSchedules
    {
        public int TeachingScheduleId { get; set; }
        public int CourseId { get; set; }
        public DateTime TeachingDate { get; set; }
        public int Slot { get; set; }
        public int RoomId { get; set; }
        public String Description { get; set; }

        public CourseSchedules() { }

        public CourseSchedules(int teachingScheduleId, int courseId,
            DateTime teachingDate, int slot,
            int roomId, string description)
        {
            TeachingScheduleId = teachingScheduleId;
            CourseId = courseId;
            TeachingDate = teachingDate;
            Slot = slot;
            RoomId = roomId;
            Description = description;
        }

        
    }
}
