using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaStranihJezika.Model
{
    internal class Kurs
    {
        public int id { get; set; }
        public string Naziv { get; set; }
        public int BrUceTre { get; set; }
        public int BrUceMaks { get; set; }
        string straniJezik { get; set; }
        string AktivanDN { get; set; }


        public Kurs (string Naziv,int BrUceTre,int BrUceMaks,string straniJezik,string AktivanDN )
        {
            
            this.Naziv = Naziv;
            this.BrUceTre = BrUceTre;
            this.BrUceMaks = BrUceMaks;
            this.straniJezik = straniJezik;
            this.AktivanDN = AktivanDN;
        }

        public Kurs(int id,string Naziv, int BrUceTre, int BrUceMaks, string straniJezik, string AktivanDN)
        {
            this.id=id;
            this.Naziv = Naziv;
            this.BrUceTre = BrUceTre;
            this.BrUceMaks = BrUceMaks;
            this.straniJezik = straniJezik;
            this.AktivanDN = AktivanDN;
        }

        public override string ToString()
        {
            return "\tId : " + id + "\tNaziv kursa : " + Naziv + "\tUcenika na kursu : " + BrUceTre+"\t max broj ucenika :"+BrUceMaks+
                "\t strani jezik :"+straniJezik+"\tKurs AktivanDN :"+AktivanDN;
        }

        public string TabelarniPrikazKursa()
        {
            return string.Format("\t{0,-4} | {1,-25} | {2,-15} | {3,-15} | {4,-15} | {5,-15}", id, Naziv, BrUceTre,BrUceMaks,straniJezik,AktivanDN);
        }

        public string SkracenoKurs()
        {
            return id + " " + Naziv;
        }
    }
}
