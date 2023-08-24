using FirstWebApp_DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp_DemoMVC.DAL
{
    class CourseDAO
    {
        public static List<Demo> GetAllCourses()
        {
            String sql = "SELECT * FROM COURSES ";
            DataTable dt = DAO.GetDataBySql(sql);
            List<Demo> list = new List<Demo>();
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(new Demo(
                    Convert.ToInt32(dr["CourseId"]),
                    // Course Code
                    dr["CourseCode"].ToString(),
                    // Code Description
                    dr["CourseDescription"].ToString(),
                    // Subject Id
                    Convert.ToInt32(dr["SubjectId"])
                    ));
            }
            return list;
        }

        public static List<Demo> GetALLCoursesBySubjectId(int subjectId)
        {
            // init value
            List<Demo> list = null;
            // SQL Query, parameters
            String sql = "SELECT * FROM COURSES WHERE SubjectId = @sid";
            SqlParameter parameter1 = new SqlParameter("@sid", DbType.Int32);
            parameter1.Value = subjectId;
            // get data query
            DataTable dt = DAO.GetDataBySql(sql, parameter1);
            if(dt != null) // found data
            {
                // new list obj
                list = new List<Demo>();
                // loop each row in DataTable to generate Course obj
                foreach(DataRow dr in dt.Rows)
                {
                    list.Add(new Demo(
                        Convert.ToInt32(dr["CourseId"]),
                        dr["CourseCode"].ToString(),
                        dr["CourseDescription"].ToString(),
                        Convert.ToInt32(dr["SubjectId"])
                        ));
                }
            }

            return list;
        }

        public static Demo GetCourseById(int CourseId)
        { 
            String sql = "SELECT * FROM COURSES WHERE CourseId = @cid";
            SqlParameter parameter = new SqlParameter("@cid", DbType.Int32);
            parameter.Value = CourseId;
            DataTable dt = DAO.GetDataBySql(sql, parameter);
            DataRow dr = dt.Rows[0];
            if (dr != null)
            {
                return new Demo(
                    Convert.ToInt32(dr["CourseId"]),
                    dr["CourseCode"].ToString(),
                    dr["CourseDescription"].ToString(),
                    Convert.ToInt32(dr["SubjectId"])
                    );
            }

            return null;
        }

    }
}
