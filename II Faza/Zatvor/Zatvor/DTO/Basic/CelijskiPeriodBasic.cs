using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.Basic
{
    public class CelijskiPeriodBasic
    {
        public virtual int ID { get; set; }
        public virtual ZatvorskaJedinicaBasic ZatvorskaJedinica { get; set; }
        public virtual string Period { get; set; }

        public CelijskiPeriodBasic()
        { }
        public CelijskiPeriodBasic(int ID, ZatvorskaJedinicaBasic ZJ, string Period)
        {
            this.ID = ID;
            this.ZatvorskaJedinica = ZJ;
            this.Period = Period;
        }
    }
}
