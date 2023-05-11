using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaStranihJezika.Model
{
    internal class Pohadja
    {
        public int id {  get; set; }
        public int kursPohadja { get; set; }
        public int ucenikPohadja { get; set; }


        public Pohadja()
        {

        }
        public Pohadja(int kursPohadja, int ucenikPohadja)
        {
            this.kursPohadja = kursPohadja;
            this.ucenikPohadja = ucenikPohadja;
        }

        public Pohadja(int id,int kursPohadja, int ucenikPohadja)
        {
            this.id = id;
            this.kursPohadja = kursPohadja;
            this.ucenikPohadja = ucenikPohadja;
        }

        public override string ToString()
        {
            return "Ucenik :" +ucenikPohadja+ "\t pohadja kurs :" + kursPohadja;
        }
    }
}
