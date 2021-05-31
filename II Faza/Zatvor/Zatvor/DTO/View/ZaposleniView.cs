using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.View
{
    public class ZaposleniView
    {
        public virtual string JMBG { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Pol { get; set; }
        public virtual string RadnoMesto { get; set; }
        public virtual DateTime DatumObukePPZ { get; set; }
        public virtual DateTime DatumPocetkaRada { get; set; }
        public ZaposleniView()
        {
        }

        public ZaposleniView(string jMBG, string ime, string prezime, string pol, string radnoMesto, DateTime datumObukePPZ, DateTime datumPocetkaRada)
        {
            JMBG = jMBG;
            Ime = ime;
            Prezime = prezime;
            Pol = pol;
            RadnoMesto = radnoMesto;
            DatumObukePPZ = datumObukePPZ;
            DatumPocetkaRada = datumPocetkaRada;
        }
    }
}
