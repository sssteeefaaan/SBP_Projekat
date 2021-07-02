using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.View
{
    public class PsihologView : ZaposleniView
    {
        public virtual string LPLekar { get; set; }
        public virtual DateTime? LPDatum { get; set; }
        public virtual string LPNazivUstanove { get; set; }
        public virtual string LPAdresaUstanove { get; set; }
        public virtual string SSpecijalizacija { get; set; }
        public virtual string SNazivUstanove { get; set; }

        public PsihologView()
        {
        }

        public PsihologView(string jMBG, string ime, string prezime, string pol, string radnoMesto, DateTime datumObukePPZ, DateTime datumPocetkaRada, string lPLekar, DateTime? lPDatum, string lPNazivUstanove, string lPAdresaUstanove, string sSpecijalizacija, string sNazivUstanove)
            : base(jMBG, ime, prezime, pol, radnoMesto, datumObukePPZ, datumPocetkaRada)
        {
            LPLekar = lPLekar;
            LPDatum = lPDatum;
            LPNazivUstanove = lPNazivUstanove;
            LPAdresaUstanove = lPAdresaUstanove;
            SSpecijalizacija = sSpecijalizacija;
            SNazivUstanove = sNazivUstanove;
        }
    }
}
