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
    internal class KursHelp
    {
        public static Kurs PreuzmiKursAkoPostoji()
        {
            Kurs pronadji = null;
            int userInput;
            Console.Clear();
            KursDao.KursIspisiSve();
            Console.WriteLine("Unesite id Kursa :");
            string unetiTekst = Console.ReadLine();
            if (int.TryParse(unetiTekst, out userInput) == false)
            {
                Console.WriteLine("Id nije integer");
            }
            else
            {
                userInput = int.Parse(unetiTekst);

                pronadji = KursPreuzmiPoId(userInput);

                if (pronadji == null)
                {
                    Console.WriteLine("Nepostojeci kurs ili je kurs pun");
                    
                }
            }

            return pronadji;
        }


        public static Kurs KursPreuzmiPoId(int id)
        {
            SqlConnection conn = ConnectionDao.NewConnection();

            Kurs KursPreuzmi;
            // integrisana i provera dali ima mesta 
            string sQuerry = "select id,naziv,BrUceTre,BrUceMaks,straniJezik,AktivanDN from Kurs where id=@id and BrUceTre<BrUceMaks";
            SqlCommand cmd = new SqlCommand(sQuerry, conn);
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                int id_kurs = (int)rdr["id"];
                string naziv = (string)rdr["naziv"];
                int BrUceTre = (int)rdr["BrUceTre"];
                int BrUceMaks = (int)rdr["BrUceMaks"];
                string straniJezik = (string)rdr["straniJezik"];
                string AktivanDN = (string)rdr["AktivanDN"];
                Kurs k = new Kurs(id_kurs, naziv, BrUceTre, BrUceMaks, straniJezik, AktivanDN);
                KursPreuzmi = k;

            }
            else
            {
                KursPreuzmi = null;
                //Console.WriteLine("Ili nema kursa ili nema mesta na kursu ");
            }
            conn.Close();
            rdr.Close();
            return KursPreuzmi;
        }

        public static bool KursUpdateTrenutnoClanova(int pohadjaKurs)
        {
            SqlConnection connection = ConnectionDao.NewConnection();

            bool Izvrseno;

            string sQuerry = "update kurs set BrUceTre=(select count(*) from pohadja  where kurs.id=id_kurs  )";
            //int id_kurs = pohadjaKurs.id;
            //int id_clan = pohadjaUcenik.id;
            SqlCommand cmd = new SqlCommand(sQuerry, connection);
            //cmd.Parameters.AddWithValue("kurs", pohadjaKurs);

            try
            {
                cmd.ExecuteNonQuery();
                Izvrseno = true;
            }
            catch
            {
                Izvrseno = false;
                Console.WriteLine("Neuspesan updejt trenutnog broja ucenika");
            }

            connection.Close();
            return Izvrseno;
        }


    }  
}
