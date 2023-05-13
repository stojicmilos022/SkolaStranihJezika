using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaStranihJezika.Model
{
    public class Ucenik
    {
        public int id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public Ucenik(string ime, string prezime)
        {
            this.Ime = ime;
            this.Prezime = prezime;
        }

        public Ucenik(int id,string ime, string prezime)
        {
            this.id = id;
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
