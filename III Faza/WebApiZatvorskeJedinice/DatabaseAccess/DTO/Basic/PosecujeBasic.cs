using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.Basic
{
    public class PosecujeBasic : IEquatable<PosecujeBasic>
    {
        public virtual int ID { get; set; }
        public virtual DateTime? DTPocetka { get; set; }
        public virtual DateTime? DTKraja { get; set; }
        public virtual ZatvorenikBasic Zatvorenik { get; set; }
        public virtual AdvokatBasic Advokat { get; set; }

        public PosecujeBasic()
        {
        }
        public PosecujeBasic(int iD, DateTime dTPocetka, DateTime dTKraja, ZatvorenikBasic zatvorenik, AdvokatBasic advokat)
        {
            ID = iD;
            DTPocetka = dTPocetka;
            DTKraja = dTKraja;
            Zatvorenik = zatvorenik;
            Advokat = advokat;
        }
        public PosecujeBasic( DateTime dTPocetka, DateTime dTKraja, ZatvorenikBasic zatvorenik, AdvokatBasic advokat)
        {
            DTPocetka = dTPocetka;
            DTKraja = dTKraja;
            Zatvorenik = zatvorenik;
            Advokat = advokat;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PosecujeBasic);
        }

        public bool Equals(PosecujeBasic other)
        {
            return other != null &&
                   (ID == other.ID) ||
                   (DTPocetka == other.DTPocetka &&
                   Zatvorenik.JMBG == other.Zatvorenik.JMBG &&
                   Advokat.JMBG == other.Advokat.JMBG);
        }
    }
}
