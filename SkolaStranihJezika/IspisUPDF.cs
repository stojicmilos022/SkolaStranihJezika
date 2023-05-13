using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using System.Xml.Linq;
using SkolaStranihJezika.DAO;
using SkolaStranihJezika.Model;
using System.Data.SqlClient;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using SkolaStranihJezika.Help;
using System.IO;

namespace SkolaStranihJezika
{
    public class IspisUPDF
    {
        public static void IzvozPdf()
        {

            Console.Write("Unesite ID kursa kreiranje pdf fajla: ");
            int idKursa = int.Parse(Console.ReadLine());
            Kurs pronadjeniKurs = KursHelp.KursPreuzmiPoId(idKursa);

            List<Ucenik> listaUcenika = PreuzmiUcenikeZaKurs(idKursa); ;

            /* Preuzimanje podataka od korisnika */
            Console.Write("Unesite zeljeno ime izlazne PDF datoteke: ");
            string imeDatoteke = Console.ReadLine();

            /* Preuzimanje svih racuna iz baze podataka */
            SqlConnection connection = ConnectionDao.NewConnection();

            /* Koriscenje MigraDoc softverske biblioteke za pravljenje PDF datoteka */
            Document document = new Document();
            MigraDoc.DocumentObjectModel.Section section = document.AddSection();

            string lepPrikaz = "";


            //Console.WriteLine("\t{0,-4} | {1,-25} | {2,-15} | {3,-15} | {4,-15} | {5,-15}", "Id", "Naziv", "Pohadja. ucenika", "Max ucenika", "strani jezik", "AktivanDN");
            //lepPrikaz += $"| {"ID",-4} | {"Naziv",-25} | {"BrojUcenika",-15}| {"Max ucenika",-15} | {"StraniJezik",-15} | {"AktivanDN",-15}  |\n";
            //lepPrikaz += String.Format("\t{0,-4} | {1,-25} | {2,-15} | {3,-15} | {4,-15} | {5,-15}", "Id", "Naziv", "Pohadja. ucenika", "Max ucenika", "strani jezik", "AktivanDN");
            lepPrikaz += $"\t | ID | Naziv | Broj ucenika | Max broj ucenika | StraniJezik | AktivanDN |\n";
            Console.WriteLine(lepPrikaz);
            lepPrikaz += "----------------------------------------------------------------\n";

            lepPrikaz += pronadjeniKurs.TabelarniPrikazKursa();
            lepPrikaz += "\n\n\n";

            lepPrikaz += $"\t| ID  | Ime | Prezime |\n";
            lepPrikaz += "----------------------------------------------------------------\n";



            foreach (Ucenik u in listaUcenika)
            {
                lepPrikaz += u.TabelarniPrikazUcenika();
                lepPrikaz += "\n"; 
            }

            Console.WriteLine(lepPrikaz);
            Console.WriteLine("PDF pod imenom -" + imeDatoteke + "- je uspesno kreiran i nalazi se u folderu DEBUG");

            section.AddParagraph(lepPrikaz);

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            string filePath = imeDatoteke + ".pdf";
            if (File.Exists(filePath))
            {
                // Delete the existing file
                File.Delete(filePath);
            }
            pdfRenderer.PdfDocument.Save(imeDatoteke+".pdf");

            connection.Close();
        }

        public static List<Ucenik> PreuzmiUcenikeZaKurs(int idKursa)
        {
            SqlConnection connection = ConnectionDao.NewConnection();

            List<Ucenik> ucenici = new List<Ucenik>();

            string upit = "SELECT Ucenik.id, ime, prezime FROM Ucenik " +
                "INNER JOIN Pohadja ON Ucenik.id = Pohadja.id_ucenik " +
                "INNER JOIN Kurs ON Pohadja.id_kurs = Kurs.id " +
                "WHERE Pohadja.id_kurs = @idKursa";

            SqlCommand cmd = new SqlCommand(upit, connection);
            cmd.Parameters.AddWithValue("@idKursa", idKursa);

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int id = (int)rdr["id"];
                string ime = (string)rdr["Ime"];
                string prezime = (string)rdr["Prezime"];
               
                Ucenik ucenik = new Ucenik(id, ime, prezime);
                ucenici.Add(ucenik);
            }

            rdr.Close();
            connection.Close();

            return ucenici;
        }
    }
}
