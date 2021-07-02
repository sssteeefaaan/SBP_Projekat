using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.Basic
{
    public class OsobaBasic : IEquatable<OsobaBasic>
    {
        public virtual string JMBG { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Pol { get; set; }

        public OsobaBasic()
        { }
        public OsobaBasic(string JMBG, string Ime, string Prezime, string Pol)
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

        public override bool Equals(object obj)
        {
            return Equals(obj as OsobaBasic);
        }

        public bool Equals(OsobaBasic other)
        {
            return other != null &&
                   JMBG == other.JMBG;
        }
    }
}
