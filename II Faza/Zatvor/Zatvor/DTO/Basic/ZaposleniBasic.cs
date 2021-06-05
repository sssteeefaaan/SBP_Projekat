using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.Basic
{
    public class ZaposleniBasic : IEquatable<ZaposleniBasic>
    {
        public virtual string JMBG { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Pol { get; set; }
        public virtual string RadnoMesto { get; set; }
        public virtual DateTime DatumObukePPZ { get; set; }
        public virtual ZatvorskaJedinicaBasic RadiU { get; set; }
        public virtual DateTime DatumPocetkaRada { get; set; }
        public virtual string Zanimanje { get; set; }
        public virtual string Pozicija { get; set; }
        public virtual string StrucnaSprema { get; set; }
        public virtual string LPLekar { get; set; }
        public virtual DateTime? LPDatum { get; set; }
        public virtual string LPNazivUstanove { get; set; }
        public virtual string LPAdresaUstanove { get; set; }
        public virtual string SSpecijalizacija { get; set; }
        public virtual string SNazivUstanove { get; set; }
        public virtual string DORVOSifra { get; set; }
        public virtual string DORVOPolicijskaUprava { get; set; }
        public virtual DateTime? DORVODatumIzdavanja { get; set; }

        public ZaposleniBasic()
        {
        }
        public ZaposleniBasic(string jMBG, string ime, string prezime, string pol, string radnoMesto, DateTime datumObukePPZ, ZatvorskaJedinicaBasic radiU, DateTime datumPocetkaRada, string zanimanje, string pozicija, string strucnaSprema, string lPLekar, DateTime? lPDatum, string lPNazivUstanove, string lPAdresaUstanove, string sSpecijalizacija, string sNazivUstanove, string dORVOSifra, string dORVOPolicijskaUprava, DateTime? dORVODatumIzdavanja)
        {
            JMBG = jMBG;
            Ime = ime;
            Prezime = prezime;
            Pol = pol;
            RadnoMesto = radnoMesto;
            DatumObukePPZ = datumObukePPZ;
            RadiU = radiU;
            DatumPocetkaRada = datumPocetkaRada;
            Zanimanje = zanimanje;
            Pozicija = pozicija;
            StrucnaSprema = strucnaSprema;
            LPLekar = lPLekar;
            LPDatum = lPDatum;
            LPNazivUstanove = lPNazivUstanove;
            LPAdresaUstanove = lPAdresaUstanove;
            SSpecijalizacija = sSpecijalizacija;
            SNazivUstanove = sNazivUstanove;
            DORVOSifra = dORVOSifra;
            DORVOPolicijskaUprava = dORVOPolicijskaUprava;
            DORVODatumIzdavanja = dORVODatumIzdavanja;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ZaposleniBasic);
        }

        public bool Equals(ZaposleniBasic other)
        {
            return other != null &&
                   JMBG == other.JMBG;
        }
    }
}
