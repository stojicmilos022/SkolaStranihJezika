using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaStranihJezika.Model
{
    internal class Ucenik
    {
        int id { get; set; }
        string Ime { get; set; }
        string Prezime { get; set; }

        public Ucenik(string ime, string prezime)
        {
            this.Ime = ime;
            this.Prezime = prezime;
        }

        public override string ToString()
        {
            return "\tId : " + id + "\tIme : " + Ime + "\tPrezime : " + Prezime;
        }

        public string TabelarniPrikazUcenika()
        {
            return string.Format("\t{0,-4} | {1,-15} | {2,-15}", id, Ime, Prezime);
        }

        public string SkracenoUcenik()
        {
            return Ime + " " + Prezime;
        }

    }
}
