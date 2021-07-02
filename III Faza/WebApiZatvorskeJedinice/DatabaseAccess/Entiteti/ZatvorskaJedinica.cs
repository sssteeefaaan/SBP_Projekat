using System.Collections.Generic;
namespace Zatvor.Entiteti
{
    public class ZatvorskaJedinica
    {
        public virtual string Sifra { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Adresa { get; set; }
        public virtual Administracija Upravnik { get; set; }
        public virtual int Kapacitet { get; set; }
        public virtual bool ORezim { get; set; }
        public virtual bool SRezim { get; set; }
        public virtual bool PORezim { get; set; }

        public virtual IList<Zatvorenik> Zatvorenici { get; set; }
        public virtual IList<Zaposleni> Zaposleni { get; set; }
        public virtual IList<TerminSetnje> TerminiSetnje { get; set; }
        public virtual IList<TerminPosete> TerminiPosete { get; set; }
        public virtual IList<CelijskiPeriod> CelijskiPeriodi { get; set; }
        public virtual IList<Firma> Firme { get; set; }

        public ZatvorskaJedinica()
        {
            Zatvorenici = new List<Zatvorenik>();
            Firme = new List<Firma>();
            Zaposleni = new List<Zaposleni>();
            TerminiSetnje = new List<TerminSetnje>();
            TerminiPosete = new List<TerminPosete>();
            CelijskiPeriodi = new List<CelijskiPeriod>();
        }
    }

    public class ZJOtvorenogTipa : ZatvorskaJedinica
    {
        public ZJOtvorenogTipa()
            :base()
        { }
    }
    public class ZJPoluotvorenogTipa : ZatvorskaJedinica
    {
        public ZJPoluotvorenogTipa()
            : base()
        { }
    }
    public class ZJStrogogTipa : ZatvorskaJedinica
    {
        public ZJStrogogTipa()
            : base()
        { }
    }
    public class ZJOtvorenoPoluotvorenogTipa : ZatvorskaJedinica
    {
        public ZJOtvorenoPoluotvorenogTipa()
            : base()
        { }
    }
    public class ZJOtvorenoStrogogTipa : ZatvorskaJedinica
    {
        public ZJOtvorenoStrogogTipa()
            : base()
        { }
    }
    public class ZJPoluotvorenoStrogogTipa : ZatvorskaJedinica
    {
        public ZJPoluotvorenoStrogogTipa()
            : base()
        { }
    }
    public class ZJSvakiTip: ZatvorskaJedinica
    {
        public ZJSvakiTip()
            : base()
        { }
    }
}
