using System.Collections.Generic;

namespace Zatvor.Entiteti
{
    public class Firma
    {
        public virtual string PIB { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string KontaktTelefon { get; set; }
        public virtual IList<OdgovornoLice> OdgovornaLica { get; set; }
        public virtual IList<ZatvorskaJedinica> ZatvorskeJedinice { get; set; }

        public Firma()
        {
            OdgovornaLica = new List<OdgovornoLice>();
            ZatvorskeJedinice = new List<ZatvorskaJedinica>();
        }
    }
}
