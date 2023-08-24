using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DemoADOModel.Models;
using System.Data;

namespace DemoADOModel.DAL
{
    class StudentDAO
    {
        public static List<Student> GetAllStudent() 
        {
            String sql = "SELECT * FROM STUDENTS";
            DataTable dt = DAO.GetDataBySql(sql);
            List<Student> students = new List<Student>();
            foreach(DataRow dr in dt.Rows)
            {
                students.Add(
                    new Student(
                        Convert.ToInt32(dr["StudentId"]),
                        dr["Roll#"].ToString(),
                        dr["Firstname"].ToString(),
                        dr["MidName"].ToString(),
                        dr["LastName"].ToString()
                        ));
            }
            return students;
        }

        public static Student GetStudentByID(int StudentID)
        {
            // sql parame ters ~ @sid
            String sql = "SELECT * FROM STUDENTS WHERE StudentId = @sid";
            //SqlParameter[] parameters = new SqlParameter[1];
            //parameters[0] = new SqlParameter("@sid", DbType.Int32);
            //parameters[0].Value = StudentID;
            SqlParameter parameter1 = new SqlParameter("@sid", DbType.Int32);
            parameter1.Value = StudentID;
            //SqlParameter parameter2 = null;
            DataTable dt = DAO.GetDataBySql(sql, parameter1);
            if (dt.Rows.Count == 0) return null;
            DataRow dr = dt.Rows[0];
            return new Student(
                Convert.ToInt32(dr["StudentId"]),
                dr["Roll#"].ToString(),
                dr["FirstName"].ToString(),
                dr["MidName"].ToString(),
                dr["LastName"].ToString()
                );
        }

        public static List<Student> SearchByName(String txtSearch) 
        {
            // return List<Student> if search value found
            List<Student> students = null;

            // SQL Query 
            String sql = "SELECT * FROM STUDENTS " +
                         " WHERE FirstName LIKE @txtSearch " +
                         " OR MidName LIKE @txtSearch " +
                         " OR LastName LIKE @txtSearch ";
            SqlParameter parameter1 = new SqlParameter("@txtSearch", DbType.String);
            parameter1.Value = "%" + txtSearch + "%";

            DataTable dt = DAO.GetDataBySql(sql, parameter1);
            if (dt != null)
            {
                students = new List<Student>();
                foreach (DataRow dr in dt.Rows)
                {
                    students.Add(
                        new Student(
                            Convert.ToInt32(dr["StudentId"]),
                            dr["Roll#"].ToString(),
                            dr["FirstName"].ToString(),
                            dr["MidName"].ToString(),
                            dr["LastName"].ToString()
                            )
                        );
                }
            }

            return students;
        }
    }
}
