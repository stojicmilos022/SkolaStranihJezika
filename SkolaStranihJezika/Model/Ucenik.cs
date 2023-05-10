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
        public string ime { get; set; }

        public string prezime { get; set; }


        public Ucenik(string ime, string prezime)
        {
            this.ime = ime;
            this.prezime = prezime;
        }

        public override string ToString() 
        {
            return " Ucenik : "+ime+" "+prezime+" ";
        }
        
    }
}
