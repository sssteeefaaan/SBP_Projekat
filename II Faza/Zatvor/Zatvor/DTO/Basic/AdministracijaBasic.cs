using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.Basic
{
    public class AdministracijaBasic : ZaposleniBasic
    {
        public AdministracijaBasic()
        {
        }

        public AdministracijaBasic(string jMBG, string ime, string prezime, string pol, string radnoMesto, DateTime datumObukePPZ, ZatvorskaJedinicaBasic radiU, DateTime datumPocetkaRada, string tip, string zanimanje, string pozicija, string strucnaSprema, ZatvorskaJedinicaBasic jeUpravnik, string lPLekar, DateTime? lPDatum, string lPNazivUstanove, string lPAdresaUstanove, string sSpecijalizacija, string sNazivUstanove, string dORVOSifra, string dORVOPolicijskaUprava, DateTime? dORVODatumIzdavanja)
            : base(jMBG, ime, prezime, pol, radnoMesto, datumObukePPZ, radiU, datumPocetkaRada, tip, zanimanje, pozicija, strucnaSprema, jeUpravnik, lPLekar, lPDatum, lPNazivUstanove, lPAdresaUstanove, sSpecijalizacija, sNazivUstanove, dORVOSifra, dORVOPolicijskaUprava, dORVODatumIzdavanja)
        {
        }
    }
}
