using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.Entiteti
{
    public class Zatvorska_Jedinica
    {
        public virtual string Sifra { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string JMBG_Upravnik { get; set; }
        public virtual int Kapacitet { get; set; }
        public virtual string Frezim_O { get; set; }
        public virtual string Frezim_S { get; set; }
        public virtual string Frezim_PO { get; set; }
    }
}
