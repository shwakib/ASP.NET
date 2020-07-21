using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

namespace dbpractice.Models
{
    public class DataAccess
    {
        SqlConnection connection;
        SqlCommand command;

        public DataAccess()
        {
            this.connection = new SqlConnection(ConfigurationManager.ConnectionStrings["atppracticedb"].ConnectionString);
            this.connection.Open();
        }

        public SqlDataReader GetData(string sql)
        {
            this.command = new SqlCommand(sql, connection);
            return command.ExecuteReader();
        }

        public int ExecuteQuery(string sql)
        {
            this.command = new SqlCommand(sql, connection);
            return command.ExecuteNonQuery();
        }

        ~DataAccess()
        {
            this.connection.Close();
        }

        
    }
}