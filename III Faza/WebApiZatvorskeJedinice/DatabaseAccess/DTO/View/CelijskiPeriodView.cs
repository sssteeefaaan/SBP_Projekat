using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.View
{
    public class CelijskiPeriodView
    {
        public virtual string Period { get; set; }
        public CelijskiPeriodView()
        { }
        public CelijskiPeriodView(string Period)
        {
            this.Period = Period;
        }
    }
}
