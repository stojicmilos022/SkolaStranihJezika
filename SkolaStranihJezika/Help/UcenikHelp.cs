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
    internal class UcenikHelp
    {
        internal static Ucenik ProveraUnosaUcenika()
        {
            Ucenik noviUcenik = null;
            string ime, prezime;

            Console.WriteLine("Unesi ime novog ucenika ");
            ime = Console.ReadLine();
            Console.WriteLine("Unesi prezime novog ucenika");
            prezime = Console.ReadLine();
            if (!string.IsNullOrEmpty(ime) && !string.IsNullOrEmpty(prezime))
            {
                noviUcenik = new Ucenik(ime, prezime);
            }
            else
            {
                Console.WriteLine("Los unos podataka");
            }

            return noviUcenik;
        }

        internal static bool TestDodavanjaUcenika(Ucenik noviUcenik)
        {
            SqlConnection connection = ConnectionDao.NewConnection();

            bool Izvrseno;

            string sQuerry = "insert into Ucenik (Ime,Prezime) values (@ime,@prezime)";

            SqlCommand cmd = new SqlCommand(sQuerry, connection);
            cmd.Parameters.AddWithValue("ime", noviUcenik.Ime);
            cmd.Parameters.AddWithValue("prezime", noviUcenik.Prezime);
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
