using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.DTO.View
{
    public class ZatvorskaJedinicaView
    {
        public virtual string Sifra { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Adresa { get; set; }
        public virtual int Kapacitet { get; set; }

        public ZatvorskaJedinicaView(string Sifra, string Naziv, string Adresa, int Kapacitet)
        {
            this.Sifra = Sifra;
            this.Naziv = Naziv;
            this.Adresa = Adresa;
            this.Kapacitet = Kapacitet;
        }

        public ZatvorskaJedinicaView()
        { }
    }

    public class ZJOtvorenogTipaView : ZatvorskaJedinicaView
    {
        public ZJOtvorenogTipaView() : base() { }
        public ZJOtvorenogTipaView(string Sifra, string Naziv, string Adresa, int Kapacitet)
            : base(Sifra, Naziv, Adresa, Kapacitet)
        { }
    }

    public class ZJPoluotvorenogTipaView : ZatvorskaJedinicaView
    {
        public ZJPoluotvorenogTipaView() : base() { }
        public ZJPoluotvorenogTipaView(string Sifra, string Naziv, string Adresa, int Kapacitet)
            : base(Sifra, Naziv, Adresa, Kapacitet)
        { }
    }

    public class ZJStrogogTipaView : ZatvorskaJedinicaView
    {
        public ZJStrogogTipaView() : base() { }
        public ZJStrogogTipaView(string Sifra, string Naziv, string Adresa, int Kapacitet)
            : base(Sifra, Naziv, Adresa, Kapacitet)
        { }
    }

    public class ZJOtvorenoPoluotvorenogTipaView : ZatvorskaJedinicaView
    {
        public ZJOtvorenoPoluotvorenogTipaView() : base() { }
        public ZJOtvorenoPoluotvorenogTipaView(string Sifra, string Naziv, string Adresa, int Kapacitet)
            : base(Sifra, Naziv, Adresa, Kapacitet)
        { }
    }

    public class ZJOtvorenoStrogogTipaView : ZatvorskaJedinicaView
    {
        public ZJOtvorenoStrogogTipaView() : base() { }
        public ZJOtvorenoStrogogTipaView(string Sifra, string Naziv, string Adresa, int Kapacitet)
            : base(Sifra, Naziv, Adresa, Kapacitet)
        { }
    }

    public class ZJPoluotvorenoStrogogTipaView : ZatvorskaJedinicaView
    {
        public ZJPoluotvorenoStrogogTipaView() : base() { }
        public ZJPoluotvorenoStrogogTipaView(string Sifra, string Naziv, string Adresa, int Kapacitet)
            : base(Sifra, Naziv, Adresa, Kapacitet)
        { }
    }

    public class ZJSvakiTipaView : ZatvorskaJedinicaView
    {
        public ZJSvakiTipaView() : base() { }
        public ZJSvakiTipaView(string Sifra, string Naziv, string Adresa, int Kapacitet)
            : base(Sifra, Naziv, Adresa, Kapacitet)
        { }
    }
}
