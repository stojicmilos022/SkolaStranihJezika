using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaStranihJezika.UI
{
    public class MainMenuUI
    {
        public static void MMenuUI()
        {
            int odluka = -1;
            while (odluka != 0)
            {
                Console.WriteLine("Skola stranih jezika \n");
                Console.WriteLine("Odaberi opciju za rad :\n");
                Console.WriteLine("\t1. Pregled svih kurseva koje skola nudi :");
                Console.WriteLine("\t2. Dodavanje novih ucenika u sistem :");
                Console.WriteLine("\t3. Ubacivanje postojecih ucenika na zeljeni kurs :");
                Console.WriteLine("Izaberi jednu od opcija :");
                odluka = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (odluka)
                {
                    case 0:
                        Console.WriteLine("Izlaz iz programa");
                        break;
                    case 1:
                        KursUI.KursIspisiSve();
                        break;
                    case 2:
                        UcenikUI.UcenikDodajNovog();
                        break;
                    case 3:
                        UcenikUI.UcenikDodajUcenikaNaKurs();
                        break;
                    default:
                        Console.WriteLine("Nepoznata komanda");
                        break;
                }
            }
        }
    }
}
