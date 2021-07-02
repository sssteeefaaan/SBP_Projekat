using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.View
{
    public class FirmaView
    {
        public virtual string PIB { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string KontaktTelefon { get; set; }

        public FirmaView()
        { }
        public FirmaView(string PIB, string Naziv, string Adresa, string KontaktTelefon)
        {
            this.PIB = PIB;
            this.Naziv = Naziv;
            this.Adresa = Adresa;
            this.KontaktTelefon = KontaktTelefon;
        }
    }
}
