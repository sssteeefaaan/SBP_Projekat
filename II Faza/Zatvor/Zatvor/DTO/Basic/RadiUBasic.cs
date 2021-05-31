using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.Basic
{
    public class RadiUBasic
    {
        public virtual int ID { get; set; }
        public virtual ZatvorskaJedinicaBasic ZatvorskaJedinica { get; set; }
        public virtual ZaposleniBasic Zaposleni { get; set; }
        public virtual DateTime DatumPocetkaRada { get; set; }

        public RadiUBasic()
        { }
        public RadiUBasic(int ID, ZatvorskaJedinicaBasic ZJ, ZaposleniBasic Z, DateTime DatumPocetkaRada)
        {
            this.ID = ID;
            this.ZatvorskaJedinica = ZJ;
            this.Zaposleni = Z;
            this.DatumPocetkaRada = DatumPocetkaRada;
        }

    }
}
