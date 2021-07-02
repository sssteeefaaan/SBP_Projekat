using System.Collections.Generic;

namespace Zatvor.Entiteti
{
    public class Zaposleni
    {
        // Osnovna klasa Osoba
        public virtual string JMBG { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Pol { get; set; }

        // Specifikacija Zaposleni
        // Kolona za diskriminaciju
        public virtual string RadnoMesto { get; set; }
        public virtual System.DateTime DatumObukePPZ { get; set; }
        public virtual ZatvorskaJedinica RadiU { get; set; }
        public virtual System.DateTime DatumPocetkaRada { get; set; }

        // Specifikacija Administracija
        public virtual string Zanimanje { get; set; }
        public virtual string Pozicija { get; set; }
        public virtual string StrucnaSprema { get; set; }

        // Specifikacija ImajuKontakt
        public virtual string LPLekar { get; set; }
        public virtual System.DateTime? LPDatum { get; set; }
        public virtual string LPNazivUstanove { get; set; }
        public virtual string LPAdresaUstanove { get; set; }

        // Psiholog
        public virtual string SSpecijalizacija { get; set; }
        public virtual string SNazivUstanove { get; set; }

        // Radnik Obezbeđenja
        public virtual string DORVOSifra { get; set; }
        public virtual string DORVOPolicijskaUprava { get; set; }
        public virtual System.DateTime? DORVODatumIzdavanja { get; set; }

        public Zaposleni()
        { }
    }
    public class Administracija : Zaposleni
    {
        public Administracija()
        { }
    }
    public class Psiholog : Zaposleni
    {
        public Psiholog()
        { }
    }
    public class RadnikObezbedjenja : Zaposleni
    {
        public RadnikObezbedjenja()
        { }
    }
}