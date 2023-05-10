using SkolaStranihJezika.Help;
using SkolaStranihJezika.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaStranihJezika.DAO
{
    internal class UcenikDao
    {
        public static List<Ucenik> PreuzmiClanoveIzSql()
        {
            SqlConnection connection = ConnectionDao.NewConnection();

            List<Ucenik> sviUcenici= new List<Ucenik>();

            string sQuerry = "select id,ime,prezime from Ucenik";

            SqlCommand cmd = new SqlCommand(sQuerry, connection);

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int id = (int)rdr["Id"];
                string ime = (string)rdr["ime"];
                string prezime = (string)rdr["prezime"];
                Ucenik noviUcenik = new Ucenik(id, ime, prezime);
                sviUcenici.Add(noviUcenik);
            }
            rdr.Close();
            connection.Close();
            return sviUcenici;
        }

        public static void UcenikIspisiSve()
        {
            List<Ucenik> sviUcenici = UcenikDao.PreuzmiClanoveIzSql();
            Console.WriteLine("\tPregled svih ucenika :");
            Console.WriteLine("\t________________________________________________");
            Console.WriteLine("\t{0,-4} | {1,-15} | {2,-15}", "ID", "Ime", "Prezime");
            Console.WriteLine("\t________________________________________________");
            foreach (Ucenik u in sviUcenici)
            {
                Console.WriteLine(u.TabelarniPrikazUcenika());
            }
            Console.WriteLine();
        }

        public static void UcenikDodajNovog()
        {
            Ucenik novi = UcenikHelp.ProveraUnosaUcenika();
            if (novi != null)
            {
                bool ucenikPostoji=UcenikHelp.ProveriDaliUcenikVecPostoji(novi);
                if (ucenikPostoji == false)
                {
                    bool uspesno = UcenikHelp.TestDodavanjaUcenika(novi);

                    if (uspesno == false)
                    {
                        Console.WriteLine("Greska pri unosu clana...");
                    }
                    else
                    {
                        Console.WriteLine("Ucenik {0} je uspesno dodat", novi);
                    }
                }
                else
                {
                    Console.WriteLine("Ucenik vec postoji : {0} nemozete dva puta prijaviti istog ucenika",novi);
                    return;
                }
            }
        }

        public static void UcenikDodajUcenikaNaKurs()
        {
            UcenikIspisiSve();

        }
        
    }
}
