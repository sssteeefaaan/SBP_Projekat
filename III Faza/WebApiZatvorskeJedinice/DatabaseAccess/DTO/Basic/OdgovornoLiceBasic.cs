using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.Basic
{
    public class OdgovornoLiceBasic
    {
        public virtual int ID { get; set; }
        public virtual string JMBG { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual FirmaBasic Firma { get; set; }

        public OdgovornoLiceBasic()
        { }
        public OdgovornoLiceBasic(int ID, string JMBG, string Ime, string Prezime)
        {
            this.ID = ID;
            this.JMBG = JMBG;
            this.Ime = Ime;
            this.Prezime = Prezime;
        }
    }
}
