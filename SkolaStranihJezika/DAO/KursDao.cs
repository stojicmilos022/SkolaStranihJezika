using SkolaStranihJezika.Help;
using SkolaStranihJezika.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SkolaStranihJezika.DAO
{
    internal class KursDao
    {
        public static List<Kurs> PreuzmiKursIzSql()
        {
            SqlConnection connection = ConnectionDao.NewConnection();

            List<Kurs> sviKursevi = new List<Kurs>();

            string sQuerry = "select id,naziv,BrUceTre,BrUceMaks,straniJezik,AktivanDN from Kurs";

            SqlCommand cmd = new SqlCommand(sQuerry, connection);

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int id = (int)rdr["id"];
                string naziv = (string)rdr["naziv"];
                int BrUceTre = (int)rdr["BrUceTre"];
                int BrUceMaks = (int)rdr["BrUceMaks"];
                string straniJezik = (string)rdr["straniJezik"];
                string AktivanDN = (string)rdr["AktivanDN"];


                Kurs noviKurs = new Kurs(id,naziv, BrUceTre, BrUceMaks,  straniJezik,  AktivanDN);
                sviKursevi.Add(noviKurs);
            }
            rdr.Close();
            connection.Close();
            return sviKursevi;
        }

        public static void KursIspisiSve()
        {
            List<Kurs> sviKursevi = KursDao.PreuzmiKursIzSql();
            Console.WriteLine("\tSvi kursevi u skoli :");
            Console.WriteLine("\t_____________________________________________________________________________________________________________");
            Console.WriteLine("\t{0,-4} | {1,-25} | {2,-15} | {3,-15} | {4,-15} | {5,-15}","Id","Naziv","Pohadja. ucenika","Max ucenika","strani jezik","AktivanDN");
            Console.WriteLine("\t_____________________________________________________________________________________________________________");
            foreach (Kurs k in sviKursevi)
            {
                Console.WriteLine(k.TabelarniPrikazKursa());
            }
            Console.WriteLine();
        }

        internal static void KursIspisiSveZaZeljeniJezik()
        {
            List<Kurs> sviKurseviZaJezik = PreuzmiKursIzSql();
            Console.WriteLine();
            Console.WriteLine("Unesi jezik za pretragu kurseva:");
            string tempJezik = Console.ReadLine();
            Console.WriteLine("\tSvi kursevi u skoli na kojima se uci : {0}",tempJezik);
            Console.WriteLine("\t_____________________________________________________________________________________________________________");
            Console.WriteLine("\t{0,-4} | {1,-25} | {2,-15} | {3,-15} | {4,-15} | {5,-15}", "Id", "Naziv", "Pohadja. ucenika", "Max ucenika", "strani jezik", "AktivanDN");
            Console.WriteLine("\t_____________________________________________________________________________________________________________");

            foreach (Kurs k in sviKurseviZaJezik)
            {
                string temp = k.straniJezik;
                //bool isti = string.Equals(tempJezik, temp, StringComparison.OrdinalIgnoreCase);
                bool sadrzi = temp.IndexOf(tempJezik, StringComparison.OrdinalIgnoreCase) >= 0;
                if (sadrzi==true)
                {
                    Console.WriteLine(k.TabelarniPrikazKursa());
                }
                else { continue; }
            }

        }

        public static void KursIzmenaMaksimalnogBrojaUcenika()
        {
            Kurs kurs = KursHelp.PreuzmiKursAkoPostojiSviKursevi();
            int kursId = kurs.id;
            bool izvrseno=KursHelp.KursIzmenaMaksimalnogBrojaUcenikaHelp(kursId);

            if (izvrseno == true)
            {
                Console.WriteLine("Uspesno je izmenjen broj maksimalnih ucenika na kursu : {0} {1}", kurs.id,kurs.Naziv);
            }
            else
            {
                Console.WriteLine("Greska prilikom maximalnog broja ucenika na kursu : {0} {1}", kurs.id, kurs.Naziv);
                
            }
            return;
            
        }

    }
}
