using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADOModel.DAL
{
    class RollCallBackDAO
    {
        public static DataTable GetRollCallBackByCourseScheduleId(int TeachingScheduleId)
        {
            String sql = "SELECT rcb.RollCallBookId as 'Id',"
                        +"c.CourseCode,"
                        + "s.FirstName + ' ' + s.MidName + ' ' + s.LastName as 'FullName', "
                        + "rcb.isAbsence, "
                        + "rcb.Comment "
                        + "FROM ROLL_CALL_BOOKS rcb "
                        + "LEFT JOIN COURSE_SCHEDULES cs ON rcb.TeachingScheduleId = cs.TeachingScheduleId "
                        + "LEFT JOIN COURSES c ON cs.CourseId = c.CourseId "
                        + "LEFT JOIN STUDENTS s ON rcb.StudentId = s.StudentId "
                        + "WHERE rcb.TeachingScheduleId = @TeachingScheduleId ";
            SqlParameter parameter = new SqlParameter("@TeachingScheduleId", DbType.Int32);
            parameter.Value = TeachingScheduleId;
            DataTable dt = DAO.GetDataBySql(sql, parameter);
            return dt;
        }

        public static int UpdateAttendencyById(int RollCallBookId, int isAbsence)
        {
            String sql = "UPDATE ROLL_CALL_BOOKS "
                        + "SET isAbsence = @isAbsence "
                        + "WHERE RollCallBookId = @RollCallBookId ";
            SqlParameter parameter1 = new SqlParameter("@isAbsence", DbType.Int32);
            parameter1.Value = isAbsence;
            SqlParameter parameter2 = new SqlParameter("@RollCallBookId", DbType.Int32);
            parameter2.Value = RollCallBookId;
            return DAO.RowEffectSql(sql, parameter1, parameter2);
        }
    }
}
