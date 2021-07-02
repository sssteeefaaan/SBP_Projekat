using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.View
{
    public class PrestupView
    {
        public virtual string PunNaziv { get; set; }
        public virtual string Kategorija { get; set; }
        public virtual string Opis { get; set; }
        public virtual int MinKazna { get; set; }
        public virtual int MaxKazna { get; set; }
        public virtual string MestoPrestupa { get; set; }
        public virtual DateTime DatumPrestupa { get; set; }

        public PrestupView(string punNaziv, string kategorija, string opis, int minKazna, int maxKazna, string mestoPrestupa, DateTime datumPrestupa)
        {
            PunNaziv = punNaziv;
            Kategorija = kategorija;
            Opis = opis;
            MinKazna = minKazna;
            MaxKazna = maxKazna;
            MestoPrestupa = mestoPrestupa;
            DatumPrestupa = datumPrestupa;
        }
        public PrestupView()
        {
        }

    }
}
