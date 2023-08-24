using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FirstWebApp_DemoMVC.DAL
{
    class DAO
    {
        public static SqlConnection GetConnection()
        {
            String sqlConnection = "server=ASUSG513;database=PRN211-DemoADO;user=sa;password=12345";
            return new SqlConnection(sqlConnection);
        }

        public static DataTable GetDataBySql(String sql, params SqlParameter[] parameters) {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            if (parameters != null || parameters.Length > 0)
                command.Parameters.AddRange(parameters);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}
