using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.View
{
    public class AdvokatView : OsobaView
    {
        public AdvokatView()
            : base()
        { }
        public AdvokatView(string JMBG, string Ime, string Prezime, string Pol)
            : base(JMBG, Ime, Prezime, Pol)
        { }
    }
}
