using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AndroidService
{
    public class DataBase
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlDataReader;

        private string connectionString = @"Data Source=GREENSHADOW-PC\SQLEXPRESS;Initial Catalog=GreenShadow;User ID=sa;Password=a5638491";
        private string sql = null;

        public DataBase()
        {
            if (sqlConnection == null)
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
            }
        }

        public void Dispose()
        {
            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        /// <returns>所有货物信息</returns>
        public List<string> AllInfo(int X,int Y)
        {
            List<string> list = new List<string>();
            sql = "select * from NEWS_TABLE";
            int i;
            try
            {
                sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();

                for (i = 0; i < X; i++)
                    if (!sqlDataReader.Read())
                        break;
                while (sqlDataReader.Read())
                {
                    list.Add(sqlDataReader[0].ToString().Trim());
                    list.Add(sqlDataReader[1].ToString().Trim());
                    list.Add(sqlDataReader[2].ToString().Trim());
                    i++;
                    if (i == Y)
                        break;
                }

                if (list.Count < (Y - X)*3)
                    list.Add(null);

                sqlDataReader.Close();
                sqlCommand.Dispose();
            }
            catch (Exception)
            {
                return null;
            }

            return list;
        }
    }
}