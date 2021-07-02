using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.View
{
    public class RadnikObezbedjenjaView : ZaposleniView
    {
        public virtual string LPLekar { get; set; }
        public virtual DateTime? LPDatum { get; set; }
        public virtual string LPNazivUstanove { get; set; }
        public virtual string LPAdresaUstanove { get; set; }
        public virtual string DORVOSifra { get; set; }
        public virtual string DORVOPolicijskaUprava { get; set; }
        public virtual DateTime? DORVODatumIzdavanja { get; set; }

        public RadnikObezbedjenjaView()
        {
        }

        public RadnikObezbedjenjaView(string jMBG, string ime, string prezime, string pol, string radnoMesto, DateTime datumObukePPZ, DateTime datumPocetkaRada, string lPLekar, DateTime? lPDatum, string lPNazivUstanove, string lPAdresaUstanove, string dORVOSifra, string dORVOPolicijskaUprava, DateTime? dORVODatumIzdavanja)
            : base(jMBG, ime, prezime, pol, radnoMesto, datumObukePPZ, datumPocetkaRada)
        {
            LPLekar = lPLekar;
            LPDatum = lPDatum;
            LPNazivUstanove = lPNazivUstanove;
            LPAdresaUstanove = lPAdresaUstanove;
            DORVOSifra = dORVOSifra;
            DORVOPolicijskaUprava = dORVOPolicijskaUprava;
            DORVODatumIzdavanja = dORVODatumIzdavanja;
        }
    }
}
