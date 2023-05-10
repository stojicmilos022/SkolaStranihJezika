using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaStranihJezika.Model
{
    internal class Kurs
    {
        int id { get; set; }
        string Naziv { get; set; }
        int BrUceTre { get; set; }
        int BrUceMaks { get; set; }
        string straniJezik { get; set; }
        char AktivanDN { get; set; }


        public Kurs (string Naziv,int BrUceTre,int BrUceMaks,string straniJezik,char AktivanDN )
        {
            
            this.Naziv = Naziv;
            this.BrUceTre = BrUceTre;
            this.BrUceMaks = BrUceMaks;
            this.straniJezik = straniJezik;
            this.AktivanDN = AktivanDN;
        }

        public override string ToString()
        {
            return "\tId : " + id + "\tNaziv kursa : " + Naziv + "\tBrojUcenika trenutno na kursu : " + BrUceTre+"\t maksimalan broj ucenika :"+BrUceMaks+
                "\t strani jezik :"+straniJezik+"\tKurs AktivanDN :"+AktivanDN;
        }

        public string TabelarniPrikazUcenika()
        {
            return string.Format("\t{0,-4} | {1,-15} | {2,-15}", id, Ime, Prezime);
        }
    }
}
