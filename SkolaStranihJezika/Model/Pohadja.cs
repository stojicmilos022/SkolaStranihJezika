using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaStranihJezika.Model
{
    internal class Pohadja
    {
        int id {  get; set; }
        public Kurs kursPohadja { get; set; }
        public Ucenik ucenikPohadja { get; set; }

        public Pohadja(Kurs kursPohadja, Ucenik ucenikPohadja)
        {
            this.kursPohadja = kursPohadja;
            this.ucenikPohadja = ucenikPohadja;
        }

        public override string ToString()
        {
            return "Ucenik :" + ucenikPohadja.SkracenoUcenik() + "\t pohadja kurs :" + kursPohadja.SkracenoKurs();
        }
    }
}
