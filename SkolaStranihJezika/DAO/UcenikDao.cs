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
                Ucenik ucenikPostoji=UcenikHelp.ProveriDaliUcenikVecPostoji(novi.Ime,novi.Prezime);
                if (ucenikPostoji == null)
                {
                    bool uspesno = UcenikHelp.TestDodavanjaUcenika(novi);

                    if (uspesno == false)
                    {
                        Console.WriteLine("Greska pri unosu clana...");
                    }
                    else
                    {
                        Console.WriteLine("Ucenik {0} {1} je uspesno dodat\n", novi.Ime,novi.Prezime);
                    }
                }
                else
                {
                    Console.WriteLine("Ucenik {0} {1} vec postoji unet je pod Id brojem : {2}\n" +
                        "nije moguce uneti dva puta istog ucenika....\n",ucenikPostoji.Ime,ucenikPostoji.Prezime,ucenikPostoji.id);
                    return;
                }
            }
        }

        public static void UcenikDodajUcenikaNaKurs()
        {
            Ucenik ucenik = UcenikHelp.PreuzmiUcenikaAkoPostoji();

            Console.WriteLine(ucenik);

            Kurs kurs = KursHelp.PreuzmiKursAkoPostoji();
            if (kurs != null)
            {
                int pohadjaKurs = kurs.id;
                int pohadjaUcenik = ucenik.id;

                Pohadja postoji = PohadjaHelp.ProveriDaliUcenikVecPohadjajKurs(pohadjaKurs, pohadjaUcenik);
                //
                if (postoji == null)
                {
                    KursHelp.KursUpdateTrenutnoClanova(pohadjaKurs);
                    bool uspesno = PohadjaHelp.TestDodavanjaUcenikaNaKurs(pohadjaKurs, pohadjaUcenik);

                    if (uspesno == false)
                    {
                        Console.WriteLine("Greska pri unosu ucenika {0} {1} na kurs {2} {3} ...", ucenik.Ime, ucenik.Prezime, kurs.id, kurs.Naziv);
                        //KursHelp.KursUpdateTrenutnoClanova(pohadjaKurs);
                    }
                    else
                    {
                        //KursHelp.KursUpdateTrenutnoClanova(pohadjaKurs);
                        Console.WriteLine("Ucenik {0} {1} je uspesno dodat na kurs {2} {3} ...", ucenik.Ime, ucenik.Prezime, kurs.id, kurs.Naziv);
                        //bool trenutno = KursHelp.KursUpdateTrenutnoClanova(pohadjaKurs);
                        KursHelp.KursUpdateTrenutnoClanova(pohadjaKurs);

                        /*
                         * Console.WriteLine("Uspesno je updejtovan broj trenutnih ucenika na kursu : {0} {1} ,\n" +
                                "Maksimalni broj ucenika je : {2} a kurs trenutno pohadja : {3} ucenika", kurs.id, kurs.Naziv, kurs.BrUceMaks, kurs.BrUceTre);
                        */
                    }
                }
                else
                {
                    Console.WriteLine("Ucenik vec pohadja izabrani kurs, \nnije moguce dva puta dodati istog ucenika na kurs");
                    
                    return;
                }
            }
            else
            {
                Console.WriteLine("Greska pri dodavanju ucenika na kurs \n" +
                    "( nije moguce dodati ucenika na kurs na kome je dostignut maksimalni broj ucenika) \n ");
                KursDao.KursIspisiSve();
                Console.WriteLine();
                return;
            }









        }
        
    }
}
