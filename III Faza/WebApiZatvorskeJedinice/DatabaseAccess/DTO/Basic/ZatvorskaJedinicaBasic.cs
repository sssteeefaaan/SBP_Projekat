using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.Basic
{
    public class ZatvorskaJedinicaBasic : IEquatable<ZatvorskaJedinicaBasic>
    {
        public virtual string Sifra { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Adresa { get; set; }
        public virtual ZaposleniBasic Upravnik { get; set; }
        public virtual int? Kapacitet { get; set; }
        public virtual bool? ORezim { get; set; }
        public virtual bool? PORezim { get; set; }
        public virtual bool? SRezim { get; set; }
        public virtual List<ZatvorenikBasic> Zatvorenici { get; set; }
        public virtual List<ZaposleniBasic> Zaposleni { get; set; }
        public virtual List<TerminSetnjeBasic> TerminiSetnje { get; set; }
        public virtual List<TerminPoseteBasic> TerminiPosete { get; set; }
        public virtual List<CelijskiPeriodBasic> CelijskiPeriodi { get; set; }
        public virtual List<FirmaBasic> Firme { get; set; }


        public ZatvorskaJedinicaBasic(string Sifra, string Naziv, string Adresa, int Kapacitet)
        {
            this.Sifra = Sifra;
            this.Naziv = Naziv;
            this.Adresa = Adresa;
            this.Kapacitet = Kapacitet;
        }

        public ZatvorskaJedinicaBasic()
        {
            Zatvorenici = new List<ZatvorenikBasic>();
            Zaposleni = new List<ZaposleniBasic>();
            TerminiSetnje = new List<TerminSetnjeBasic>();
            TerminiPosete = new List<TerminPoseteBasic>();
            CelijskiPeriodi = new List<CelijskiPeriodBasic>();
            Firme = new List<FirmaBasic>();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ZatvorskaJedinicaBasic);
        }

        public bool Equals(ZatvorskaJedinicaBasic other)
        {
            return other != null &&
                   Sifra == other.Sifra;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class ZJOtvorenogTipaBasic : ZatvorskaJedinicaBasic
    {
        public ZJOtvorenogTipaBasic()
            : base()
        { }
        public ZJOtvorenogTipaBasic(string Sifra, string Naziv, string Adresa, int Kapacitet)
            : base(Sifra, Naziv, Adresa, Kapacitet)
        { }
    }

    public class ZJPoluotvorenogTipaBasic : ZatvorskaJedinicaBasic
    {
        public ZJPoluotvorenogTipaBasic()
            : base()
        { }
        public ZJPoluotvorenogTipaBasic(string Sifra, string Naziv, string Adresa, int Kapacitet)
            : base(Sifra, Naziv, Adresa, Kapacitet)
        { }
    }

    public class ZJStrogogTipaBasic : ZatvorskaJedinicaBasic
    {
        public ZJStrogogTipaBasic()
            : base()
        { }
        public ZJStrogogTipaBasic(string Sifra, string Naziv, string Adresa, int Kapacitet)
            : base(Sifra, Naziv, Adresa, Kapacitet)
        { }
    }

    public class ZJOtvorenoPoluotvorenogTipaBasic : ZatvorskaJedinicaBasic
    {
        public ZJOtvorenoPoluotvorenogTipaBasic()
            : base()
        { }
        public ZJOtvorenoPoluotvorenogTipaBasic(string Sifra, string Naziv, string Adresa, int Kapacitet)
            : base(Sifra, Naziv, Adresa, Kapacitet)
        { }
    }

    public class ZJOtvorenoStrogogTipaBasic : ZatvorskaJedinicaBasic
    {
        public ZJOtvorenoStrogogTipaBasic()
            : base()
        { }
        public ZJOtvorenoStrogogTipaBasic(string Sifra, string Naziv, string Adresa, int Kapacitet)
            : base(Sifra, Naziv, Adresa, Kapacitet)
        { }
    }

    public class ZJPoluotvorenoStrogogTipaBasic : ZatvorskaJedinicaBasic
    {
        public ZJPoluotvorenoStrogogTipaBasic()
            : base()
        { }
        public ZJPoluotvorenoStrogogTipaBasic(string Sifra, string Naziv, string Adresa, int Kapacitet)
            : base(Sifra, Naziv, Adresa, Kapacitet)
        { }
    }

    public class ZJSvakiTipBasic : ZatvorskaJedinicaBasic
    {
        public ZJSvakiTipBasic()
            : base()
        { }
        public ZJSvakiTipBasic(string Sifra, string Naziv, string Adresa, int Kapacitet)
            : base(Sifra, Naziv, Adresa, Kapacitet)
        { }
    }
}
