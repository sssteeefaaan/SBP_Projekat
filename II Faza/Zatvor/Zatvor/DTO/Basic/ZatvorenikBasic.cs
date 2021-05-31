using System;
using System.Collections.Generic;

namespace Zatvor.DTO.Basic
{
    public class ZatvorenikBasic : OsobaBasic
    {
        public virtual string Broj { get; set; }
        public virtual string Adresa { get; set; }
        public virtual DateTime DatumInkarceracije { get; set; }
        public virtual DateTime? DatumSledecegSaslusanja { get; set; }
        public virtual string StatusUslovnogOtpusta { get; set; }
        public virtual IList<PrestupBasic> Prestupi { get; set; }
        public virtual IList<ZastupaBasic> Zastupa { get; set; }
        public virtual IList<PosecujeBasic> Posete { get; set; }
        public virtual ZatvorskaJedinicaBasic ZatvorskaJedinica { get; set; }

        public ZatvorenikBasic()
        {
            Prestupi = new List<PrestupBasic>();
            Zastupa = new List<ZastupaBasic>();
            Posete = new List<PosecujeBasic>();
        }

        public ZatvorenikBasic(string JMBG, string Ime, string Prezime, string Pol, string Broj, string Adresa, DateTime DatumInkarceracije, DateTime? DatumSledecegSaslusanja, string StatusUslovnogOtpusta, ZatvorskaJedinicaBasic ZatvorskaJedinica)
            : base(JMBG, Ime, Prezime, Pol)
        {
            this.Broj = Broj;
            this.Adresa = Adresa;
            this.DatumInkarceracije = DatumInkarceracije;
            this.DatumSledecegSaslusanja = DatumSledecegSaslusanja;
            this.StatusUslovnogOtpusta = StatusUslovnogOtpusta;
            this.ZatvorskaJedinica = ZatvorskaJedinica;
        }
    }
}
