using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.Basic
{
    public class AdvokatBasic : OsobaBasic
    {
        public virtual IList<ZastupaBasic> Zastupa { get; set; }
        public virtual IList<PosecujeBasic> Posecuje { get; set; }

        public AdvokatBasic()
            : base()
        {
            Zastupa = new List<ZastupaBasic>();
            Posecuje = new List<PosecujeBasic>();
        }
        public AdvokatBasic(string JMBG, string Ime, string Prezime, string Pol)
            : base(JMBG, Ime, Prezime, Pol)
        { }
    }
}
