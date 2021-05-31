using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.DTO.Basic;

namespace Zatvor.DTO.View
{
    public class TerminSetnjeView
    {
        public virtual int ID { get; set; }
        public virtual ZatvorskaJedinicaBasic ZatvorskaJedinica { get; set; }
        public virtual string Termin { get; set; }

        public TerminSetnjeView()
        { }
        public TerminSetnjeView(int ID, ZatvorskaJedinicaBasic ZJ, string Termin)
        {
            this.ID = ID;
            this.ZatvorskaJedinica = ZJ;
            this.Termin = Termin;
        }
    }
}
