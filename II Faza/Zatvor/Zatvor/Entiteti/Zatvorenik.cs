using System.Collections.Generic;
namespace Zatvor.Entiteti
{
    public class Zatvorenik : Osoba
    {
        public virtual string Broj { get; set; }
        public virtual string Adresa { get; set; }
        public virtual System.DateTime DatumInkarceracije { get; set; }
        public virtual System.DateTime? DatumSledecegSaslusanja { get; set; }
        public virtual string StatusUslovnogOtpusta { get; set; }
        public virtual IList<Prestup> Prestupi { get; set; }
        public virtual IList<Zastupa> Zastupa { get; set; }
        public virtual IList<Posecuje> Posete { get; set; }
        public virtual ZatvorskaJedinica ZatvorskaJedinica { get; set; }

        public Zatvorenik()
        {
            Prestupi = new List<Prestup>();
            Zastupa = new List<Zastupa>();
            Posete = new List<Posecuje>();
        }
    }
}
