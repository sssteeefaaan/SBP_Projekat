using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.View
{
    public class OsobaView
    {
        public virtual string JMBG { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Pol { get; set; }

        public OsobaView()
        { }
        public OsobaView(string JMBG, string Ime, string Prezime, string Pol)
        {
            this.JMBG = JMBG;
            this.Ime = Ime;
            this.Prezime = Prezime;
            this.Pol = Pol;
        }

        public override string ToString()
        {
            return $"{JMBG} {Ime} {Prezime}";
        }
    }
}
