using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.View
{
    public class ZatvorenikView : OsobaView
    {
        public virtual string Broj { get; set; }
        public virtual string Adresa { get; set; }
        public virtual DateTime DatumInkarceracije { get; set; }
        public virtual DateTime? DatumSledecegSaslusanja { get; set; }
        public virtual string StatusUslovnogOtpusta { get; set; }
        public virtual string NazivZatvorskeJedinice { get; set; }

        public ZatvorenikView()
            : base()
        {
        }

        public ZatvorenikView(string JMBG, string Ime, string Prezime, string Pol, string Broj, string Adresa, DateTime DatumInkarceracije, DateTime? DatumSledecegSaslusanja, string StatusUslovnogOtpusta, string NazivZatvorskeJedinice)
            : base(JMBG, Ime, Prezime, Pol)
        {
            this.Broj = Broj;
            this.Adresa = Adresa;
            this.DatumInkarceracije = DatumInkarceracije;
            this.DatumSledecegSaslusanja = DatumSledecegSaslusanja;
            this.StatusUslovnogOtpusta = StatusUslovnogOtpusta;
            this.NazivZatvorskeJedinice = NazivZatvorskeJedinice;
        }
    }
}
