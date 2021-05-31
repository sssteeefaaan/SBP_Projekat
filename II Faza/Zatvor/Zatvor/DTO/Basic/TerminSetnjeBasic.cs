using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.Basic
{
    public class TerminSetnjeBasic
    {
        public virtual int ID { get; set; }
        public virtual ZatvorskaJedinicaBasic ZatvorskaJedinica { get; set; }
        public virtual string Termin { get; set; }

        public TerminSetnjeBasic()
        { }
        public TerminSetnjeBasic(int ID, ZatvorskaJedinicaBasic ZJ, string Termin)
        {
            this.ID = ID;
            this.ZatvorskaJedinica = ZJ;
            this.Termin = Termin;
        }
    }
}
