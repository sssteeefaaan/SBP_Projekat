﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.Basic
{
    public class FirmaBasic
    {
        public virtual string PIB { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string KontaktTelefon { get; set; }
        public virtual List<OdgovornoLiceBasic> OdgovornaLica { get; set; }
        public virtual List<ZatvorskaJedinicaBasic> ZatvorskeJedinice { get; set; }

        public FirmaBasic()
        {
            OdgovornaLica = new List<OdgovornoLiceBasic>();
            ZatvorskeJedinice = new List<ZatvorskaJedinicaBasic>();
        }
        public FirmaBasic(string PIB, string Naziv, string Adresa, string KontaktTelefon)
        {
            this.PIB = PIB;
            this.Naziv = Naziv;
            this.Adresa = Adresa;
            this.KontaktTelefon = KontaktTelefon;
        }
    }
}
