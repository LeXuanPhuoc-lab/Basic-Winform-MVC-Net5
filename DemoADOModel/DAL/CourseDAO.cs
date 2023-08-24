using DemoADOModel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADOModel.DAL
{
    class CourseDAO
    {
        public static List<Courses> GetAllCourse()
        {
            // init result
            List<Courses> courses = null;
            //1. SQL Query
            String sql = "SELECT * FROM COURSES ";
            //2. SqlParamaters (if any)
            //2.1 Call GetDataBySql, pass sql query
            DataTable dt = DAO.GetDataBySql(sql);
            //3. Process result
            if(dt != null) // if query data found
            {
                // new Course List
                courses = new List<Courses>();
                // loop each DataRow in DataTable
                foreach(DataRow dr in dt.Rows)
                {
                    // add Course to Course List
                    courses.Add(
                        // new Course Obj with param construtors
                        new Courses(
                            // Convert dr obj to Properties DataType
                            // Id
                            Convert.ToInt32(dr["CourseId"]),
                            // Course Code
                            dr["CourseCode"].ToString(),
                            // Code Description
                            dr["CourseDescription"].ToString(),
                            // Subject Id
                            Convert.ToInt32(dr["SubjectId"])
                            )
                        );
                }
            }
            // not found -> return null

            return courses;
        }

        public static List<CourseSchedules> GetCourseSchedulesByCourseCode(String CourseCode)
        {
            // init result
            List<CourseSchedules> courseSchedules = null;
            //1. SQL Query
            String sql = "SELECT * FROM COURSES c "
                        + "LEFT JOIN COURSE_SCHEDULES cs " 
                        + "ON c.CourseId = cs.CourseId "
                        + "WHERE c.CourseCode = @CourseCode";
            //2. Paramerters (if any)
            SqlParameter parameter1 = new SqlParameter("@CourseCode", DbType.String);
            parameter1.Value = CourseCode;
            //2.1 Call GetDataBySql
            DataTable dt = DAO.GetDataBySql(sql, parameter1);
            //3.Process Result
            if(dt != null) // data found
            {
                // new List of Course Schedules
                courseSchedules = new List<CourseSchedules>();
                // loop each DataRow in DataTable
                foreach (DataRow dr in dt.Rows)
                {
                    courseSchedules.Add(
                        new CourseSchedules(
                            Convert.ToInt32(dr["TeachingScheduleId"]),
                            Convert.ToInt32(dr["CourseId"]),
                            Convert.ToDateTime(dr["TeachingDate"].ToString()),
                            Convert.ToInt32(dr["Slot"]),
                            Convert.ToInt32(dr["RoomId"]),
                            dr["Description"].ToString()
                            ));
                }
            }
            return courseSchedules;
        }
    }
}
