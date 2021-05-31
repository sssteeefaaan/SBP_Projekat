using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.DTO.Basic;

namespace Zatvor.DTO.View
{
    public class TerminPoseteView
    {
        public virtual string Dan { get; set; }
        public virtual string Period { get; set; }

        public TerminPoseteView()
        { }
        public TerminPoseteView(int ID, ZatvorskaJedinicaBasic ZJ, string Dan, string Period)
        {
            this.Dan = Dan;
            this.Period = Period;
        }

    }
}
