using SkolaStranihJezika.DAO;
using SkolaStranihJezika.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaStranihJezika.Help
{
    internal class PohadjaHelp
    {
        internal static bool ProveriDaliUcenikVecPohadjajKurs(int kursPohadja,int ucenikPohadja)
        {
            SqlConnection connection = ConnectionDao.NewConnection();

            bool Izvrseno;

            string sQuerry = "select * from pohadja where id_kurs=@id and id_ucenik=@id_uc";

            SqlCommand cmd = new SqlCommand(sQuerry, connection);
            cmd.Parameters.AddWithValue("id", kursPohadja);
            cmd.Parameters.AddWithValue("prezime", ucenikPohadja);
            try
            {
                cmd.ExecuteNonQuery();
                Izvrseno = true;
            }
            catch
            {
                Izvrseno = false;
            }

            connection.Close();
            return Izvrseno;
        }
    }
}
