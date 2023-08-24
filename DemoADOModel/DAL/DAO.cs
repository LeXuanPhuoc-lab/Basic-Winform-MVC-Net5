using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADOModel.DAL
{
    class DAO
    {
        public static SqlConnection GetConnection() 
        {
            String connectionStr = "server=ASUSG513;database=PRN211-DemoADO;user=sa;password=12345";
            return new SqlConnection(connectionStr);
        }

        public static DataTable GetDataBySql(String sql, params SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            if(parameters != null 
                || parameters.Length > 0) 
                command.Parameters.AddRange(parameters);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public static int RowEffectSql(String sql, params SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            if(parameters.Length > 0 
                || parameters != null)
                command.Parameters.AddRange(parameters);
            command.Connection.Open();
            return command.ExecuteNonQuery();
        }
    }
}
