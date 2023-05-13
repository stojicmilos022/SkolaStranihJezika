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
    public class UcenikHelp
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

        public static Ucenik ProveriDaliUcenikVecPostoji(string ime,string prezime)
        {
            /*
            SqlConnection connection = ConnectionDao.NewConnection();

            bool Izvrseno;
            string Ime = noviUcenik.Ime;
            string Prezime= noviUcenik.Prezime;
            string sQuerry = @"select * from ucenik where ime="+"\'"+Ime+"\' and prezime="+"\'"+Prezime+ "\'";

            SqlCommand cmd = new SqlCommand(sQuerry, connection);
            //cmd.Parameters.AddWithValue("ime", noviUcenik.Ime);
            //cmd.Parameters.AddWithValue("prezime", noviUcenik.Prezime);
            try
            {
                cmd.ExecuteReader();
                Izvrseno = true;
            }
            catch
            {
                Izvrseno = false;
            }

            connection.Close();
            return Izvrseno;
            */
            SqlConnection conn = ConnectionDao.NewConnection();

            Ucenik ucenik;

            string sQuerry = @"select id,ime,prezime from ucenik where ime=" + "\'" + ime + "\' and prezime=" + "\'" + prezime + "\'";
            SqlCommand cmd = new SqlCommand(sQuerry, conn);


            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int Clan_Id = (int)dr[0];
                string Ime = (string)dr[1];
                string Prezime = (string)dr[2];
                Ucenik ucenikNadjen = new Ucenik(Clan_Id, ime, prezime);
                ucenik = ucenikNadjen;

            }
            else
            {
                ucenik = null;
            }
            conn.Close();
            dr.Close();
            return ucenik;
        }

        public static Ucenik PreuzmiUcenikaAkoPostoji()
        {
            Ucenik pronadji = null;
            int userInput;
            Console.Clear();
            UcenikDao.UcenikIspisiSve();
            Console.WriteLine("Unesite id ucenika :");
            string unetiTekst = Console.ReadLine();
            if (int.TryParse(unetiTekst, out userInput) == false)
            {
                Console.WriteLine("Id nije integer");
            }
            else
            {
                userInput = int.Parse(unetiTekst);

                pronadji = UcenikPreuzmiPoId(userInput);

                if (pronadji == null)
                {
                    Console.WriteLine("Nepostojeci clan");
                }
            }

            return pronadji;
        }

        public static Ucenik PreuzmiUcenikaAkoPostojiPoId(int Id)
        {
            Ucenik pronadji = null;
            int userInput=Id;
            Console.Clear();
            UcenikDao.UcenikIspisiSve();
            Console.WriteLine("Unesite id ucenika :");
            string unetiTekst = Console.ReadLine();
            if (int.TryParse(unetiTekst, out Id) == false)
            {
                Console.WriteLine("Id nije integer");
            }
            else
            {
                userInput = int.Parse(unetiTekst);

                pronadji = UcenikPreuzmiPoId(userInput);

                if (pronadji == null)
                {
                    Console.WriteLine("Nepostojeci clan");
                }
            }

            return pronadji;
        }


        public static Ucenik UcenikPreuzmiPoId(int id)
        {
            SqlConnection conn = ConnectionDao.NewConnection();

            Ucenik ucenikPreuzmi;
            string sQuerry = "select id,ime,prezime from ucenik where  id=@id";
            SqlCommand cmd = new SqlCommand(sQuerry, conn);
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int Clan_Id = (int)dr[0];
                string ime = (string)dr[1];
                string prezime = (string)dr[2];
                Ucenik u = new Ucenik(id, ime, prezime);
                ucenikPreuzmi = u;

            }
            else
            {
                ucenikPreuzmi = null;
            }
            conn.Close();
            dr.Close();
            return ucenikPreuzmi;
        }


    }
}
