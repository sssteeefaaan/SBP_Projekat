using System.Collections.Generic;

namespace Zatvor.Entiteti
{
    public class Zaposleni
    {
        // Trebalo je da se nasledi iz osobe, ali s obzirom da nemamo mogućnost višestrukog nasleđivanja, atributi osobe su jednostavno prekopirani :D
        public virtual string JMBG { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Pol { get; set; }
        
        // Specifikacija Zaposleni
        public virtual string RadnoMesto { get; set; }
        public virtual System.DateTime DatumObukePPZ { get; set; }
        public virtual IList<RadiU> RadiU { get; set; }

        public Zaposleni()
        {
            RadiU = new List<RadiU>();
        }
    }
}