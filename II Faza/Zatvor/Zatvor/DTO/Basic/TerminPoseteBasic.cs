using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.Basic
{
    public class TerminPoseteBasic
    {
        public virtual int ID { get; set; }
        public virtual ZatvorskaJedinicaBasic ZatvorskaJedinica { get; set; }
        public virtual string Dan { get; set; }
        public virtual string Period { get; set; }

        public TerminPoseteBasic()
        { }
        public TerminPoseteBasic(int ID, ZatvorskaJedinicaBasic ZJ, string Dan, string Period)
        {
            this.ID = ID;
            this.ZatvorskaJedinica = ZJ;
            this.Dan = Dan;
            this.Period = Period;
        }

    }
}
