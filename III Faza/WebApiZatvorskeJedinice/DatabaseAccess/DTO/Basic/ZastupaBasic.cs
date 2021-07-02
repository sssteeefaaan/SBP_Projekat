using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.Basic
{
    public class ZastupaBasic
    {
        public virtual int ID { get; set; }
        public virtual DateTime? DatumPocetkaSaradnje { get; set; }
        public virtual DateTime? DatumPoslednjegKontakta { get; set; }
        public virtual ZatvorenikBasic Zatvorenik { get; set; }
        public virtual AdvokatBasic Advokat { get; set; }

        public ZastupaBasic()
        {
        }

        public ZastupaBasic(int iD, DateTime datumPocetkaSaradnje, DateTime? datumPoslednjegKontakta, ZatvorenikBasic zatvorenik, AdvokatBasic advokat)
        {
            ID = iD;
            DatumPocetkaSaradnje = datumPocetkaSaradnje;
            DatumPoslednjegKontakta = datumPoslednjegKontakta;
            Zatvorenik = zatvorenik;
            Advokat = advokat;
        }

        public ZastupaBasic(DateTime datumPocetkaSaradnje, DateTime? datumPoslednjegKontakta, ZatvorenikBasic zatvorenik, AdvokatBasic advokat)
        {
            DatumPocetkaSaradnje = datumPocetkaSaradnje;
            DatumPoslednjegKontakta = datumPoslednjegKontakta;
            Zatvorenik = zatvorenik;
            Advokat = advokat;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ZastupaBasic))
                return false;
            ZastupaBasic z = obj as ZastupaBasic;

            return z.Advokat.JMBG == this.Advokat.JMBG && z.Zatvorenik.JMBG == this.Zatvorenik.JMBG;
        }
    }
}
