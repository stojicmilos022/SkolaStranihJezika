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
        internal static Pohadja ProveriDaliUcenikVecPohadjajKurs(int kursPohadja,int ucenikPohadja)
        {
            SqlConnection conn = ConnectionDao.NewConnection();


            Pohadja pohadja;
            string sQuerry = @"select * from pohadja where id_kurs=" + "\'" + kursPohadja + "\' and id_Ucenik=" + "\'" + ucenikPohadja + "\'";
            SqlCommand cmd = new SqlCommand(sQuerry, conn);


            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int id = (int)dr[0];
                int id_kurs = (int)dr[1];
                int id_ucenik = (int)dr[2];
                Pohadja pronadjen = new Pohadja(id, id_kurs, id_ucenik);
                pohadja = pronadjen;

            }
            else
            {
                pohadja = null;
            }
            conn.Close();
            dr.Close();
            return pohadja;
        }

        public static bool TestDodavanjaUcenikaNaKurs(int pohadjaKurs,int pohadjaUcenik)
        {
            SqlConnection connection = ConnectionDao.NewConnection();

            bool Izvrseno;

            string sQuerry = "insert into Pohadja (Id_Kurs,Id_Ucenik) values (@kurs,@ucenik)";
            //int id_kurs = pohadjaKurs.id;
            //int id_clan = pohadjaUcenik.id;
            SqlCommand cmd = new SqlCommand(sQuerry, connection);
            cmd.Parameters.AddWithValue("kurs", pohadjaKurs);
            cmd.Parameters.AddWithValue("ucenik", pohadjaUcenik);
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
