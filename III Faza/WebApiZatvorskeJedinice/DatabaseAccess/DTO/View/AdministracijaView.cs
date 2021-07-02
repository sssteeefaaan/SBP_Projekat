using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.View
{
    public class AdministracijaView : ZaposleniView
    {
        public virtual string Zanimanje { get; set; }
        public virtual string Pozicija { get; set; }
        public virtual string StrucnaSprema { get; set; }
        //public virtual ZatvorskaJedinicaBasic JeUpravnik { get; set; }
        public AdministracijaView()
        {
        }

        public AdministracijaView(string jMBG, string ime, string prezime, string pol, string radnoMesto, DateTime datumObukePPZ, DateTime datumPocetkaRada, string Zanimanje, string Pozicija, string StrucnaSprema)
            : base(jMBG, ime, prezime, pol, radnoMesto, datumObukePPZ, datumPocetkaRada)
        {
            this.Zanimanje = Zanimanje;
            this.Pozicija = Pozicija;
            this.StrucnaSprema = StrucnaSprema;
        }
    }
}
