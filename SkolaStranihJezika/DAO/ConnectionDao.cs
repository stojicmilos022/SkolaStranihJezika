using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaStranihJezika.DAO
{
    internal class ConnectionDao
    {
        private static string connString = "Server=localhost;Database=SkolaStranihJezika;Integrated security=True;MultipleActiveResultSets=True";

        public static SqlConnection NewConnection()
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            return conn;
        }
    }
}
