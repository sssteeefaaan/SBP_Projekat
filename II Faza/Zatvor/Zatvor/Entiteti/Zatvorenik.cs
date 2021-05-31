using System;
using System.Collections.Generic;
using Zatvor.DTO.Basic;

namespace Zatvor.Entiteti
{
    public class Zatvorenik : Osoba
    {
        public virtual string Broj { get; set; }
        public virtual string Adresa { get; set; }
        public virtual DateTime DatumInkarceracije { get; set; }
        public virtual DateTime? DatumSledecegSaslusanja { get; set; }
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
