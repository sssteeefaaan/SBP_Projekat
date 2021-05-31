using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.View
{
    public class OdgovornoLiceView
    {
        public virtual string JMBG { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }

        public OdgovornoLiceView()
        { }
        public OdgovornoLiceView(string JMBG, string Ime, string Prezime)
        {
            this.JMBG = JMBG;
            this.Ime = Ime;
            this.Prezime = Prezime;
        }
    }
}
