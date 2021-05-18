using System.Collections.Generic;

namespace Zatvor.Entiteti
{
    public class Administracija : Zaposleni
    {
        public virtual string Zanimanje { get; set; }
        public virtual string Pozicija { get; set; }
        public virtual string StrucnaSprema { get; set; }
        public virtual IList<ZatvorskaJedinica> UpravnikZJ { get; set; }
        
        public Administracija()
        {
            UpravnikZJ = new List<ZatvorskaJedinica>();
        }
    }
}