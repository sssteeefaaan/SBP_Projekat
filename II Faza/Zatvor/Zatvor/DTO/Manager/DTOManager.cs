using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zatvor.DTO.Basic;
using Zatvor.Entiteti;

namespace Zatvor.DTO
{
    public static class DTOManager
    {
        #region Zatvorenik
        public static List<ZatvorenikBasic> ReadAllZatvorenici()
        {
            List<ZatvorenikBasic> ret = new List<ZatvorenikBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<ZatvorskaJedinica> lista = s.Query<ZatvorskaJedinica>().ToList();

                ZatvorskaJedinicaBasic zatvorskaJedinica = null;
                lista.ForEach(zj =>
                {
                    zatvorskaJedinica = new ZatvorskaJedinicaBasic(zj.Sifra, zj.Naziv, zj.Adresa, zj.Kapacitet);
                    foreach (Zatvorenik z in zj.Zatvorenici)
                        ret.Add(new ZatvorenikBasic(z.JMBG, z.Ime, z.Prezime, z.Pol, z.Broj, z.Adresa, z.DatumInkarceracije, z.DatumSledecegSaslusanja, z.StatusUslovnogOtpusta, zatvorskaJedinica));
                
                });

                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }

            return ret;
        }

        public static ZatvorenikBasic ReadZatvorenik(string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Zatvorenik zat = s.Query<Zatvorenik>().Where(zatvorenik => zatvorenik.JMBG == JMBG).FirstOrDefault();

                s.Close();
                return new ZatvorenikBasic(zat.JMBG, zat.Ime, zat.Prezime, zat.Pol, zat.Broj, zat.Adresa, zat.DatumInkarceracije, zat.DatumSledecegSaslusanja, zat.StatusUslovnogOtpusta, new ZatvorskaJedinicaBasic(zat.ZatvorskaJedinica.Sifra, zat.ZatvorskaJedinica.Naziv, zat.ZatvorskaJedinica.Adresa, zat.ZatvorskaJedinica.Kapacitet));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }

            return null;
        }

        public static bool CreateZatvorenik(ZatvorenikBasic z)
        {
            bool ret = false;
            try
            {
                ISession s = DataLayer.GetSession();

                Zatvorenik zat = new Zatvorenik();

                zat.JMBG = z.JMBG;
                zat.Ime = z.Ime;
                zat.Prezime = z.Prezime;
                zat.Pol = z.Pol;

                zat.Broj = z.Broj;
                zat.Adresa = z.Adresa;
                zat.StatusUslovnogOtpusta = z.StatusUslovnogOtpusta;
                zat.DatumInkarceracije = z.DatumInkarceracije;
                zat.DatumSledecegSaslusanja = z.DatumSledecegSaslusanja;

                zat.ZatvorskaJedinica = s
                        .Query<ZatvorskaJedinica>()
                        .Where(zj=> zj.Sifra == z.ZatvorskaJedinica.Sifra)
                        .FirstOrDefault();
                
                foreach (PrestupBasic p in z.Prestupi)
                {
                    Prestup prest = new Prestup();

                    prest.PunNaziv = p.PunNaziv;
                    prest.Kategorija = p.Kategorija;
                    prest.DatumPrestupa = p.DatumPrestupa;
                    prest.MestoPrestupa = p.MestoPrestupa;

                    prest.MaxKazna = p.MaxKazna;
                    prest.MinKazna = p.MinKazna;

                    prest.Opis = p.Opis;
                    prest.Zatvorenik = zat;

                    zat.Prestupi.Add(prest);
                }

                foreach (ZastupaBasic zast in z.Zastupa)
                {
                    Zastupa zastupa = new Zastupa();

                    zastupa.Advokat = s
                        .Query<Advokat>()
                        .Where(a=>a.JMBG == zast.Advokat.JMBG)
                        .FirstOrDefault();

                    zastupa.Zatvorenik = zat;

                    zastupa.DatumPocetkaSaradnje = zast.DatumPocetkaSaradnje;
                    zastupa.DatumPoslednjegKontakta = zast.DatumPoslednjegKontakta;

                    zat.Zastupa.Add(zastupa);
                }

                foreach (PosecujeBasic p in z.Posete)
                {
                    Posecuje pos = new Posecuje();

                    pos.DTPocetka = p.DTPocetka;
                    pos.DTKraja = p.DTKraja;
                    pos.Advokat = s.Query<Advokat>().Where(a => a.JMBG == p.Advokat.JMBG).FirstOrDefault();
                    pos.Zatvorenik = zat;

                    zat.Posete.Add(pos);
                }

                s.Save(zat);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            return ret;
        }

        public static void UpdateZatvorenik(ZatvorenikBasic z)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zatvorenik zOld = s.Query<Zatvorenik>().Where(zat => zat.JMBG == z.JMBG).FirstOrDefault();

                zOld.Ime = z.Ime;
                zOld.Prezime = z.Prezime;
                zOld.Pol = z.Pol;
                zOld.Adresa = z.Adresa;

                zOld.Broj = z.Broj;
                zOld.DatumInkarceracije = z.DatumInkarceracije;
                zOld.DatumSledecegSaslusanja = z.DatumSledecegSaslusanja;
                zOld.StatusUslovnogOtpusta = z.StatusUslovnogOtpusta;

                if (zOld.ZatvorskaJedinica.Sifra != z.ZatvorskaJedinica.Sifra)
                    zOld.ZatvorskaJedinica = DTOManager.ReadZatvorskaJedinicaEntity(z.ZatvorskaJedinica.Sifra);

                //zOld.Zastupa = new List<Zastupa>();
                //Zastupa zast;
                //foreach (ZastupaBasic zastupa in z.Zastupa)
                //{
                //    zast = new Zastupa();

                //    zast.ID = zastupa.ID;
                //    zast.DatumPocetkaSaradnje = zastupa.DatumPocetkaSaradnje;
                //    zast.DatumPoslednjegKontakta = zastupa.DatumPoslednjegKontakta;
                //    zast.Zatvorenik = zOld;
                //    zast.Advokat = DTOManager.ReadAdvokatWith(zastupa.Advokat.JMBG);

                //    zOld.Zastupa.Add(zast);
                //}


                //zOld.Posete = new List<Posecuje>();
                //Posecuje pos;
                //foreach (PosecujeBasic posecuje in z.Posete)
                //{
                //    pos = new Posecuje();

                //    pos.ID = posecuje.ID;
                //    pos.DTPocetka = posecuje.DTPocetka;
                //    pos.DTKraja = posecuje.DTKraja;
                //    pos.Advokat = DTOManager.ReadAdvokatWith(posecuje.Advokat.JMBG);
                //    pos.Zatvorenik = zOld;

                //    zOld.Posete.Add(pos);
                //}

                //zOld.Prestupi = new List<Prestup>();
                //Prestup p;
                //foreach (PrestupBasic prestup in z.Prestupi)
                //{
                //    p = new Prestup();

                //    p.ID = prestup.ID;
                //    p.PunNaziv = prestup.PunNaziv;
                //    p.Kategorija = prestup.Kategorija;
                //    p.Opis = prestup.Opis;
                //    p.MestoPrestupa = prestup.MestoPrestupa;
                //    p.DatumPrestupa = prestup.DatumPrestupa;
                //    p.MaxKazna = prestup.MaxKazna;
                //    p.MinKazna = prestup.MinKazna;
                //    p.Zatvorenik = zOld;

                //    zOld.Prestupi.Add(p);
                //}

                s.SaveOrUpdate(zOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        #endregion

        #region Zatvorska Jedinica
        public static ZatvorskaJedinica ReadZatvorskaJedinicaEntity(string sifra)
        {
            ZatvorskaJedinica ret = new ZatvorskaJedinica();
            try
            {
                ISession s = DataLayer.GetSession();

                ret = s.Query<ZatvorskaJedinica>().Where(z => z.Sifra == sifra).FirstOrDefault();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }

            return ret;
        }
        public static List<ZatvorskaJedinicaBasic> ReadAllZatvorskeJedinice()
        {
            List<ZatvorskaJedinicaBasic> ret = new List<ZatvorskaJedinicaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();
                List<ZatvorskaJedinica> lista = s.Query<ZatvorskaJedinica>().ToList();
                lista.ForEach(zj => ret.Add(new ZatvorskaJedinicaBasic(zj.Sifra, zj.Naziv, zj.Adresa, zj.Kapacitet)));

                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }

            return ret;
        }
        #endregion

        #region Advokat
        public static List<AdvokatBasic> ReadAllAdvokati()
        {
            List<AdvokatBasic> ret = new List<AdvokatBasic>();

            try
            {
                ISession s = DataLayer.GetSession();
                List<Advokat> lista = s.Query<Advokat>().ToList();
                lista.ForEach(a => ret.Add(new AdvokatBasic(a.JMBG, a.Ime, a.Prezime, a.Pol)));
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }

            return ret;
        }
        public static void UpdateAdvokat(AdvokatBasic a)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Advokat aOld = s.Query<Advokat>().Where(adv => adv.JMBG == a.JMBG).FirstOrDefault();

                aOld.Ime = a.Ime;
                aOld.Prezime = a.Prezime;
                aOld.Pol = a.Pol;

                s.Update(aOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        public static Advokat ReadAdvokatWith(string JMBG)
        {
            Advokat a = new Advokat();

            try {
                ISession s = DataLayer.GetSession();

                a = s.Query<Advokat>().Where(adv => adv.JMBG == JMBG).FirstOrDefault();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }

            return a;
        }
        public static void CreateAdvokat(AdvokatBasic adv)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Advokat a = new Advokat();

                a.JMBG = adv.JMBG;
                a.Ime = adv.Ime;
                a.Prezime = adv.Prezime;
                a.Pol = adv.Pol;

                s.Update(a);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        public static void DeleteAdvokat(AdvokatBasic a)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Advokat aOld = s.Query<Advokat>().Where(adv => adv.JMBG == a.JMBG).FirstOrDefault();

                s.Delete(aOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        #endregion

        #region Zastupa
        public static List<ZastupaBasic> ReadAllZastupaFor(ZatvorenikBasic zatvorenik)
        {
            List<ZastupaBasic> ret = new List<ZastupaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();
                List<Zastupa> lista = s
                    .Query<Zastupa>()
                    .Where(z=>z.Zatvorenik.JMBG == zatvorenik.JMBG)
                    .ToList();

                lista.ForEach(z => ret.Add(new ZastupaBasic(z.ID, z.DatumPocetkaSaradnje, z.DatumPoslednjegKontakta, zatvorenik, new AdvokatBasic(z.Advokat.JMBG, z.Advokat.Ime, z.Advokat.Prezime, z.Advokat.Pol))));
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }

            return ret;
        }
        public static void CreateZastupa(ZastupaBasic z)
        {
            try {
                ISession s = DataLayer.GetSession();

                Zastupa zNew = new Zastupa();

                zNew.DatumPocetkaSaradnje = z.DatumPocetkaSaradnje;
                zNew.DatumPoslednjegKontakta = z.DatumPoslednjegKontakta;
                zNew.Zatvorenik = s.Query<Zatvorenik>().Where(zat => zat.JMBG == z.Zatvorenik.JMBG).FirstOrDefault();
                zNew.Advokat = s.Query<Advokat>().Where(zat => zat.JMBG == z.Advokat.JMBG).FirstOrDefault();

                s.Save(zNew);
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        public static void UpdateZastupa(ZastupaBasic zastupaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zastupa z = s.Query<Zastupa>().Where(zast => zast.ID == zastupaBasic.ID).FirstOrDefault();

                z.DatumPocetkaSaradnje = zastupaBasic.DatumPocetkaSaradnje;
                z.DatumPoslednjegKontakta = zastupaBasic.DatumPoslednjegKontakta;

                s.SaveOrUpdate(z);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        public static void DeleteZastupa(ZastupaBasic z)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zastupa zastupa = s.Query<Zastupa>().Where(zast => zast.ID == z.ID).FirstOrDefault();

                s.Delete(zastupa);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        #endregion

        #region Posecuje
        public static List<PosecujeBasic> ReadAllPoseteForZatvorenik(ZatvorenikBasic z)
        {
            List<PosecujeBasic> ret = new List<PosecujeBasic>();
            try {
                ISession s = DataLayer.GetSession();
                List<Posecuje> lista = s
                    .Query<Posecuje>()
                    .Where(p => p.Zatvorenik.JMBG == z.JMBG)
                    .ToList();

                lista.ForEach(p => ret.Add(new PosecujeBasic(p.ID, p.DTPocetka, p.DTKraja, z, new AdvokatBasic(p.Advokat.JMBG, p.Advokat.Ime, p.Advokat.Prezime, p.Advokat.Pol))));
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }

            return ret;
        }
        public static void CreatePoseta(PosecujeBasic poseta)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Posecuje pNew = new Posecuje();

                pNew.DTPocetka = poseta.DTPocetka;
                pNew.DTKraja = poseta.DTKraja;
                pNew.Advokat = s.Query<Advokat>().Where(a => a.JMBG == poseta.Advokat.JMBG).FirstOrDefault();
                pNew.Zatvorenik = s.Query<Zatvorenik>().Where(z => z.JMBG == poseta.Zatvorenik.JMBG).FirstOrDefault();

                s.Save(pNew);
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        public static void DeletePoseta(PosecujeBasic poseta)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Posecuje pNew = s
                    .Query<Posecuje>()
                    .Where(p => p.ID == poseta.ID)
                    .FirstOrDefault();

                s.Delete(pNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        public static void UpdatePoseta(PosecujeBasic poseta)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Posecuje pNew = s
                    .Query<Posecuje>()
                    .Where(p => p.ID == poseta.ID)
                    .FirstOrDefault();

                pNew.DTPocetka = poseta.DTPocetka;
                pNew.DTKraja = poseta.DTKraja;

                s.SaveOrUpdate(pNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        #endregion

        #region Prestup
        public static List<PrestupBasic> ReadAllPrestupiFor(ZatvorenikBasic zatvorenik)
        {
            List<PrestupBasic> ret = new List<PrestupBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<Prestup> lista = s
                    .Query<Prestup>()
                    .Where(p => p.Zatvorenik.JMBG == zatvorenik.JMBG)
                    .ToList();

                lista.ForEach(p => ret.Add(new PrestupBasic(p.ID, p.PunNaziv, p.Kategorija, p.Opis, p.MinKazna, p.MaxKazna, p.MestoPrestupa, p.DatumPrestupa, zatvorenik)));
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }

            return ret;
        }
        public static void CreatePrestup(PrestupBasic prestupBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prestup pNew = new Prestup();

                pNew.PunNaziv = prestupBasic.PunNaziv;
                pNew.Kategorija = prestupBasic.Kategorija;
                pNew.MinKazna = prestupBasic.MinKazna;
                pNew.MaxKazna = prestupBasic.MaxKazna;

                pNew.MestoPrestupa = prestupBasic.MestoPrestupa;
                pNew.DatumPrestupa = prestupBasic.DatumPrestupa;
                pNew.Opis = prestupBasic.Opis;

                pNew.Zatvorenik = s.Query<Zatvorenik>().Where(z => z.JMBG == prestupBasic.Zatvorenik.JMBG).FirstOrDefault();

                s.Save(pNew);
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        public static void UpdatePrestup(PrestupBasic prestupBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prestup pNew = s.Query<Prestup>().Where(p => p.ID == prestupBasic.ID).FirstOrDefault();

                pNew.PunNaziv = prestupBasic.PunNaziv;
                pNew.Kategorija = prestupBasic.Kategorija;
                pNew.MinKazna = prestupBasic.MinKazna;
                pNew.MaxKazna = prestupBasic.MaxKazna;

                pNew.MestoPrestupa = prestupBasic.MestoPrestupa;
                pNew.DatumPrestupa = prestupBasic.DatumPrestupa;
                pNew.Opis = prestupBasic.Opis;

                s.SaveOrUpdate(pNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        public static void DeletePrestup(PrestupBasic prestupBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prestup pNew = s.Query<Prestup>().Where(p => p.ID == prestupBasic.ID).FirstOrDefault();

                s.Delete(pNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        #endregion
    }
}
