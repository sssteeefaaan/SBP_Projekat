using System.Collections.Generic;
namespace Zatvor.Entiteti
{
    public class ZatvorskaJedinica
    {
        public virtual string Sifra { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual string Adresa { get; set; }
        public virtual Administracija Upravnik { get; set; }
        public virtual int Kapacitet { get; set; }
        public virtual string FrezimO { get; set; }
        public virtual string FrezimS { get; set; }
        public virtual string FrezimPO { get; set; }

        public virtual IList<Zatvorenik> Zatvorenici { get; set; }
        public virtual IList<RadiU> RadiU { get; set; }
        public virtual IList<TerminSetnje> TerminiSetnje { get; set; }
        public virtual IList<TerminPosete> TerminiPosete { get; set; }
        public virtual IList<CelijskiPeriod> CelijskiPeriodi { get; set; }
        public virtual IList<Firma> Firme { get; set; }

        public ZatvorskaJedinica()
        {
            Zatvorenici = new List<Zatvorenik>();
            Firme = new List<Firma>();
            RadiU = new List<RadiU>();
            TerminiSetnje = new List<TerminSetnje>();
            TerminiPosete = new List<TerminPosete>();
            CelijskiPeriodi = new List<CelijskiPeriod>();

            //Upravnik = new Administracija();
        }
    }
}
