using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.DTO.Basic;
using Zatvor.Entiteti;

namespace Zatvor.DTO
{
    public static class DTOManager
    {
        #region Zatvorska Jedinica

        #region Zatvorska Jedinica General
        public static void CreateZatvorskaJedinica(ZatvorskaJedinicaBasic zatvorskaJedinicaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZatvorskaJedinica zNew = new ZatvorskaJedinica();

                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Sifra)) zNew.Sifra = zatvorskaJedinicaBasic.Sifra;
                if (zatvorskaJedinicaBasic.Kapacitet != null) zNew.Kapacitet = (int)zatvorskaJedinicaBasic.Kapacitet;
                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Naziv)) zNew.Naziv = zatvorskaJedinicaBasic.Naziv;
                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Adresa)) zNew.Adresa = zatvorskaJedinicaBasic.Adresa;

                if (zatvorskaJedinicaBasic.ORezim != null) zNew.ORezim = (bool)zatvorskaJedinicaBasic.ORezim;
                if (!zatvorskaJedinicaBasic.SRezim != null) zNew.SRezim = (bool)zatvorskaJedinicaBasic.SRezim;
                if (!zatvorskaJedinicaBasic.PORezim != null) zNew.PORezim = (bool)zatvorskaJedinicaBasic.PORezim;

                s.Save(zNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static ZatvorskaJedinicaBasic ReadZatvorskaJedinica(string sifra)
        {
            ZatvorskaJedinicaBasic ret = new ZatvorskaJedinicaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ZatvorskaJedinica zj = s.Query<ZatvorskaJedinica>()
                    .Where(z => z.Sifra == sifra)
                    .FirstOrDefault();

                ret.Sifra = zj.Sifra;
                ret.Kapacitet = zj.Kapacitet;
                ret.Naziv = zj.Naziv;
                ret.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    ret.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                    if (ret.Upravnik.RadiU != null)
                        ret.Upravnik.RadiU = ret;
                }

                ret.ORezim = zj.ORezim;
                ret.SRezim = zj.SRezim;
                ret.PORezim = zj.PORezim;
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<ZatvorskaJedinicaBasic> ReadAllZatvorskaJedinica()
        {
            List<ZatvorskaJedinicaBasic> ret = new List<ZatvorskaJedinicaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<ZatvorskaJedinica> lista = s.Query<ZatvorskaJedinica>().ToList();

                ZatvorskaJedinicaBasic retSingle;
                lista.ForEach(zj =>
                {
                    retSingle = new ZatvorskaJedinicaBasic();

                    retSingle.Sifra = zj.Sifra;
                    retSingle.Kapacitet = zj.Kapacitet;
                    retSingle.Naziv = zj.Naziv;
                    retSingle.Adresa = zj.Adresa;

                    if (zj.Upravnik != null)
                    {
                        retSingle.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                        if (retSingle.Upravnik.RadiU != null)
                            retSingle.Upravnik.RadiU = retSingle;
                    }

                    retSingle.ORezim = zj.ORezim;
                    retSingle.SRezim = zj.SRezim;
                    retSingle.PORezim = zj.PORezim;

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static ZatvorskaJedinicaBasic ReadZatvorskaJedinicaFULL(string sifra)
        {
            ZatvorskaJedinicaBasic ret = new ZatvorskaJedinicaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ZatvorskaJedinica zj = s.Query<ZatvorskaJedinica>()
                    .Where(z => z.Sifra == sifra)
                    .FirstOrDefault();

                ret.Sifra = zj.Sifra;
                ret.Kapacitet = zj.Kapacitet;
                ret.Naziv = zj.Naziv;
                ret.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    ret.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                    if (ret.Upravnik.RadiU != null)
                        ret.Upravnik.RadiU = ret;
                }

                ret.Zaposleni = ReadAllZaposleniFor(ret);
                ret.Zatvorenici = ReadAllZatvorenikFor(ret);

                ret.ORezim = zj.ORezim;
                ret.SRezim = zj.SRezim;
                ret.PORezim = zj.PORezim;

                ret.TerminiPosete = ReadAllTerminPoseteFor(ret);
                ret.TerminiSetnje = ReadAllTerminSetnjeFor(ret);

                ret.CelijskiPeriodi = ReadAllCelijskiPeriodFor(ret);

                ret.Firme = ReadAllFirmaFor(ret);
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<ZatvorskaJedinicaBasic> ReadAllZatvorskaJedinicaFULL()
        {
            List<ZatvorskaJedinicaBasic> ret = new List<ZatvorskaJedinicaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<ZatvorskaJedinica> lista = s.Query<ZatvorskaJedinica>().ToList();

                ZatvorskaJedinicaBasic retSingle;
                lista.ForEach(zj =>
                {
                    retSingle = new ZatvorskaJedinicaBasic();

                    retSingle.Sifra = zj.Sifra;
                    retSingle.Kapacitet = zj.Kapacitet;
                    retSingle.Naziv = zj.Naziv;
                    retSingle.Adresa = zj.Adresa;

                    if (zj.Upravnik != null)
                    {
                        retSingle.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                        if (retSingle.Upravnik.RadiU != null)
                            retSingle.Upravnik.RadiU = retSingle;
                    }

                    retSingle.Zaposleni = ReadAllZaposleniFor(retSingle);
                    retSingle.Zatvorenici = ReadAllZatvorenikFor(retSingle);

                    retSingle.ORezim = zj.ORezim;
                    retSingle.SRezim = zj.SRezim;
                    retSingle.PORezim = zj.PORezim;

                    retSingle.TerminiPosete = ReadAllTerminPoseteFor(retSingle);
                    retSingle.TerminiSetnje = ReadAllTerminSetnjeFor(retSingle);

                    retSingle.CelijskiPeriodi = ReadAllCelijskiPeriodFor(retSingle);

                    retSingle.Firme = ReadAllFirmaFor(retSingle);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<ZatvorskaJedinicaBasic> ReadAllZatvorskaJedinicaFor(FirmaBasic firmaBasic)
        {
            List<ZatvorskaJedinicaBasic> ret = new List<ZatvorskaJedinicaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IList<ZatvorskaJedinica> list = s.QueryOver<ZatvorskaJedinica>()
                    .Inner.JoinQueryOver<Firma>(z => z.Firme)
                    .Where(f => f.PIB == firmaBasic.PIB)
                    .List();

                ZatvorskaJedinicaBasic retSingle;

                foreach (ZatvorskaJedinica zj in list)
                {
                    retSingle = new ZatvorskaJedinicaBasic();

                    retSingle.Sifra = zj.Sifra;
                    retSingle.Kapacitet = zj.Kapacitet;
                    retSingle.Naziv = zj.Naziv;
                    retSingle.Adresa = zj.Adresa;

                    if (zj.Upravnik != null)
                    {
                        retSingle.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                        if (retSingle.Upravnik.RadiU != null)
                            retSingle.Upravnik.RadiU = retSingle;
                    }

                    retSingle.Zaposleni = ReadAllZaposleniFor(retSingle);
                    retSingle.Zatvorenici = ReadAllZatvorenikFor(retSingle);

                    retSingle.ORezim = zj.ORezim;
                    retSingle.SRezim = zj.SRezim;
                    retSingle.PORezim = zj.PORezim;

                    retSingle.TerminiPosete = ReadAllTerminPoseteFor(retSingle);
                    retSingle.TerminiSetnje = ReadAllTerminSetnjeFor(retSingle);

                    retSingle.CelijskiPeriodi = ReadAllCelijskiPeriodFor(retSingle);

                    //retSingle.Firme = ReadAllFirmaFor(retSingle);

                    ret.Add(retSingle);
                }

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static void UpdateZatvorskaJedinica(ZatvorskaJedinicaBasic zj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZatvorskaJedinica zjOld = s
                    .Query<ZatvorskaJedinica>()
                    .Where(z => z.Sifra == zj.Sifra)
                    .FirstOrDefault();

                if (zj.Kapacitet != null) zjOld.Kapacitet = (int)zj.Kapacitet;
                if (!String.IsNullOrEmpty(zj.Naziv)) zjOld.Naziv = zj.Naziv;
                if (!String.IsNullOrEmpty(zj.Adresa)) zjOld.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    zjOld.Upravnik = s.Query<Administracija>()
                    .Where(a => a.JMBG == zj.Upravnik.JMBG)
                    .FirstOrDefault();
                }

                if (zj.ORezim != null) zjOld.ORezim = (bool)zj.ORezim;
                if (zj.SRezim != null) zjOld.SRezim = (bool)zj.SRezim;
                if (zj.PORezim != null) zjOld.PORezim = (bool)zj.PORezim;

                s.SaveOrUpdate(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static void DeleteZatvorskaJedinica(string Sifra)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZatvorskaJedinica zjOld = s
                    .Query<ZatvorskaJedinica>()
                    .Where(z => z.Sifra == Sifra)
                    .FirstOrDefault();

                s.Delete(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        #endregion

        #region Zatvorska Jedinica Otvoren Režim
        public static void CreateZJOtvorenogTipa(ZJOtvorenogTipaBasic zatvorskaJedinicaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZJOtvorenogTipa zNew = new ZJOtvorenogTipa();

                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Sifra)) zNew.Sifra = zatvorskaJedinicaBasic.Sifra;
                if (zatvorskaJedinicaBasic.Kapacitet != null) zNew.Kapacitet = (int)zatvorskaJedinicaBasic.Kapacitet;
                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Naziv)) zNew.Naziv = zatvorskaJedinicaBasic.Naziv;
                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Adresa)) zNew.Adresa = zatvorskaJedinicaBasic.Adresa;

                zNew.ORezim = true;
                zNew.SRezim = false;
                zNew.PORezim = false;

                s.Save(zNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static void UpdateZJOtvorenogTipa(ZJOtvorenogTipaBasic zj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJOtvorenogTipa zjOld = s
                    .Query<ZJOtvorenogTipa>()
                    .Where(z => z.Sifra == zj.Sifra)
                    .FirstOrDefault();

                if (zj.Kapacitet != null) zjOld.Kapacitet = (int)zj.Kapacitet;
                if (!String.IsNullOrEmpty(zj.Naziv)) zjOld.Naziv = zj.Naziv;
                if (!String.IsNullOrEmpty(zj.Adresa)) zjOld.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    zjOld.Upravnik = s.Query<Administracija>()
                    .Where(a => a.JMBG == zj.Upravnik.JMBG)
                    .FirstOrDefault();
                }

                s.SaveOrUpdate(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static ZJOtvorenogTipaBasic ReadZJOtvorenogTipa(string sifra)
        {
            ZJOtvorenogTipaBasic ret = new ZJOtvorenogTipaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ZJOtvorenogTipa zj = s.Query<ZJOtvorenogTipa>()
                    .Where(z => z.Sifra == sifra)
                    .FirstOrDefault();

                ret.Sifra = zj.Sifra;
                ret.Kapacitet = zj.Kapacitet;
                ret.Naziv = zj.Naziv;
                ret.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    ret.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                    if (ret.Upravnik.RadiU != null)
                        ret.Upravnik.RadiU = ret;
                }

                ret.ORezim = zj.ORezim;
                ret.SRezim = zj.SRezim;
                ret.PORezim = zj.PORezim;
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<ZJOtvorenogTipaBasic> ReadAllZJOtvorenogTipa()
        {
            List<ZJOtvorenogTipaBasic> ret = new List<ZJOtvorenogTipaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<ZJOtvorenogTipa> lista = s.Query<ZJOtvorenogTipa>().ToList();

                ZJOtvorenogTipaBasic retSingle;
                lista.ForEach(zj =>
                {
                    retSingle = new ZJOtvorenogTipaBasic();

                    retSingle.Sifra = zj.Sifra;
                    retSingle.Kapacitet = zj.Kapacitet;
                    retSingle.Naziv = zj.Naziv;
                    retSingle.Adresa = zj.Adresa;

                    if (zj.Upravnik != null)
                    {
                        retSingle.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                        if (retSingle.Upravnik.RadiU != null)
                            retSingle.Upravnik.RadiU = retSingle;
                    }

                    retSingle.ORezim = zj.ORezim;
                    retSingle.SRezim = zj.SRezim;
                    retSingle.PORezim = zj.PORezim;

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static ZJOtvorenogTipaBasic ReadZJOtvorenogTipaFULL(string sifra)
        {
            ZJOtvorenogTipaBasic ret = new ZJOtvorenogTipaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ZJOtvorenogTipa zj = s.Query<ZJOtvorenogTipa>()
                    .Where(z => z.Sifra == sifra)
                    .FirstOrDefault();

                ret.Sifra = zj.Sifra;
                ret.Kapacitet = zj.Kapacitet;
                ret.Naziv = zj.Naziv;
                ret.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    ret.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                    if (ret.Upravnik.RadiU != null)
                        ret.Upravnik.RadiU = ret;
                }

                ret.Zaposleni = ReadAllZaposleniFor(ret);
                ret.Zatvorenici = ReadAllZatvorenikFor(ret);

                ret.ORezim = zj.ORezim;
                ret.SRezim = zj.SRezim;
                ret.PORezim = zj.PORezim;

                ret.TerminiPosete = ReadAllTerminPoseteFor(ret);
                ret.TerminiSetnje = ReadAllTerminSetnjeFor(ret);

                ret.CelijskiPeriodi = ReadAllCelijskiPeriodFor(ret);

                ret.Firme = ReadAllFirmaFor(ret);
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<ZJOtvorenogTipaBasic> ReadAllZJOtvorenogTipaFULL()
        {
            List<ZJOtvorenogTipaBasic> ret = new List<ZJOtvorenogTipaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<ZJOtvorenogTipa> lista = s.Query<ZJOtvorenogTipa>().ToList();

                ZJOtvorenogTipaBasic retSingle;
                lista.ForEach(zj =>
                {
                    retSingle = new ZJOtvorenogTipaBasic();

                    retSingle.Sifra = zj.Sifra;
                    retSingle.Kapacitet = zj.Kapacitet;
                    retSingle.Naziv = zj.Naziv;
                    retSingle.Adresa = zj.Adresa;

                    if (zj.Upravnik != null)
                    {
                        retSingle.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                        if (retSingle.Upravnik.RadiU != null)
                            retSingle.Upravnik.RadiU = retSingle;
                    }

                    retSingle.Zaposleni = ReadAllZaposleniFor(retSingle);
                    retSingle.Zatvorenici = ReadAllZatvorenikFor(retSingle);

                    retSingle.ORezim = zj.ORezim;
                    retSingle.SRezim = zj.SRezim;
                    retSingle.PORezim = zj.PORezim;

                    retSingle.TerminiPosete = ReadAllTerminPoseteFor(retSingle);
                    retSingle.TerminiSetnje = ReadAllTerminSetnjeFor(retSingle);

                    retSingle.CelijskiPeriodi = ReadAllCelijskiPeriodFor(retSingle);

                    retSingle.Firme = ReadAllFirmaFor(retSingle);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static void DeleteZJOtvorenogTipa(string Sifra)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJOtvorenogTipa zjOld = s
                    .Query<ZJOtvorenogTipa>()
                    .Where(z => z.Sifra == Sifra)
                    .FirstOrDefault();

                s.Delete(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        #endregion

        #region Zatvorska Jedinica Poluotvoren Režim
        public static void CreateZJPoluotvorenogTipa(ZJPoluotvorenogTipaBasic zatvorskaJedinicaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZJPoluotvorenogTipa zNew = new ZJPoluotvorenogTipa();

                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Sifra)) zNew.Sifra = zatvorskaJedinicaBasic.Sifra;
                if (zatvorskaJedinicaBasic.Kapacitet != null) zNew.Kapacitet = (int)zatvorskaJedinicaBasic.Kapacitet;
                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Naziv)) zNew.Naziv = zatvorskaJedinicaBasic.Naziv;
                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Adresa)) zNew.Adresa = zatvorskaJedinicaBasic.Adresa;

                zNew.ORezim = false;
                zNew.SRezim = false;
                zNew.PORezim = true;

                s.Save(zNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static void UpdateZJPoluotvorenogTipa(ZJPoluotvorenogTipaBasic zj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJPoluotvorenogTipa zjOld = s
                    .Query<ZJPoluotvorenogTipa>()
                    .Where(z => z.Sifra == zj.Sifra)
                    .FirstOrDefault();

                if (zj.Kapacitet != null) zjOld.Kapacitet = (int)zj.Kapacitet;
                if (!String.IsNullOrEmpty(zj.Naziv)) zjOld.Naziv = zj.Naziv;
                if (!String.IsNullOrEmpty(zj.Adresa)) zjOld.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    zjOld.Upravnik = s.Query<Administracija>()
                    .Where(a => a.JMBG == zj.Upravnik.JMBG)
                    .FirstOrDefault();
                }

                //if (zj.ORezim != null) zjOld.ORezim = (bool)zj.ORezim;
                //if (zj.SRezim != null) zjOld.SRezim = (bool)zj.SRezim;
                //if (zj.PORezim != null) zjOld.PORezim = (bool)zj.PORezim;

                s.SaveOrUpdate(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static ZJPoluotvorenogTipaBasic ReadZJPoluotvorenogTipa(string sifra)
        {
            ZJPoluotvorenogTipaBasic ret = new ZJPoluotvorenogTipaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ZJPoluotvorenogTipa zj = s.Query<ZJPoluotvorenogTipa>()
                    .Where(z => z.Sifra == sifra)
                    .FirstOrDefault();

                ret.Sifra = zj.Sifra;
                ret.Kapacitet = zj.Kapacitet;
                ret.Naziv = zj.Naziv;
                ret.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    ret.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                    if (ret.Upravnik.RadiU != null)
                        ret.Upravnik.RadiU = ret;
                }

                ret.ORezim = zj.ORezim;
                ret.SRezim = zj.SRezim;
                ret.PORezim = zj.PORezim;
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<ZJPoluotvorenogTipaBasic> ReadAllZJPoluotvorenogTipa()
        {
            List<ZJPoluotvorenogTipaBasic> ret = new List<ZJPoluotvorenogTipaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<ZJPoluotvorenogTipa> lista = s.Query<ZJPoluotvorenogTipa>().ToList();

                ZJPoluotvorenogTipaBasic retSingle;
                lista.ForEach(zj =>
                {
                    retSingle = new ZJPoluotvorenogTipaBasic();

                    retSingle.Sifra = zj.Sifra;
                    retSingle.Kapacitet = zj.Kapacitet;
                    retSingle.Naziv = zj.Naziv;
                    retSingle.Adresa = zj.Adresa;

                    if (zj.Upravnik != null)
                    {
                        retSingle.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                        if (retSingle.Upravnik.RadiU != null)
                            retSingle.Upravnik.RadiU = retSingle;
                    }

                    retSingle.ORezim = zj.ORezim;
                    retSingle.SRezim = zj.SRezim;
                    retSingle.PORezim = zj.PORezim;

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static ZJPoluotvorenogTipaBasic ReadZJPoluotvorenogTipaFULL(string sifra)
        {
            ZJPoluotvorenogTipaBasic ret = new ZJPoluotvorenogTipaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ZJPoluotvorenogTipa zj = s.Query<ZJPoluotvorenogTipa>()
                    .Where(z => z.Sifra == sifra)
                    .FirstOrDefault();

                ret.Sifra = zj.Sifra;
                ret.Kapacitet = zj.Kapacitet;
                ret.Naziv = zj.Naziv;
                ret.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    ret.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                    if (ret.Upravnik.RadiU != null)
                        ret.Upravnik.RadiU = ret;
                }

                ret.Zaposleni = ReadAllZaposleniFor(ret);
                ret.Zatvorenici = ReadAllZatvorenikFor(ret);

                ret.ORezim = zj.ORezim;
                ret.SRezim = zj.SRezim;
                ret.PORezim = zj.PORezim;

                ret.TerminiPosete = ReadAllTerminPoseteFor(ret);
                ret.TerminiSetnje = ReadAllTerminSetnjeFor(ret);

                ret.CelijskiPeriodi = ReadAllCelijskiPeriodFor(ret);

                ret.Firme = ReadAllFirmaFor(ret);
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<ZJPoluotvorenogTipaBasic> ReadAllZJPoluotvorenogTipaFULL()
        {
            List<ZJPoluotvorenogTipaBasic> ret = new List<ZJPoluotvorenogTipaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<ZJPoluotvorenogTipa> lista = s.Query<ZJPoluotvorenogTipa>().ToList();

                ZJPoluotvorenogTipaBasic retSingle;
                lista.ForEach(zj =>
                {
                    retSingle = new ZJPoluotvorenogTipaBasic();

                    retSingle.Sifra = zj.Sifra;
                    retSingle.Kapacitet = zj.Kapacitet;
                    retSingle.Naziv = zj.Naziv;
                    retSingle.Adresa = zj.Adresa;

                    if (zj.Upravnik != null)
                    {
                        retSingle.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                        if (retSingle.Upravnik.RadiU != null)
                            retSingle.Upravnik.RadiU = retSingle;
                    }

                    retSingle.Zaposleni = ReadAllZaposleniFor(retSingle);
                    retSingle.Zatvorenici = ReadAllZatvorenikFor(retSingle);

                    retSingle.ORezim = zj.ORezim;
                    retSingle.SRezim = zj.SRezim;
                    retSingle.PORezim = zj.PORezim;

                    retSingle.TerminiPosete = ReadAllTerminPoseteFor(retSingle);
                    retSingle.TerminiSetnje = ReadAllTerminSetnjeFor(retSingle);

                    retSingle.CelijskiPeriodi = ReadAllCelijskiPeriodFor(retSingle);

                    retSingle.Firme = ReadAllFirmaFor(retSingle);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static void DeleteZJPoluotvorenogTipa(string Sifra)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJPoluotvorenogTipa zjOld = s
                    .Query<ZJPoluotvorenogTipa>()
                    .Where(z => z.Sifra == Sifra)
                    .FirstOrDefault();

                s.Delete(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        #endregion

        #region Zatvorska Jedinica Strogi Režim
        public static void CreateZJStrogogTipa(ZJStrogogTipaBasic zatvorskaJedinicaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZJStrogogTipa zNew = new ZJStrogogTipa();

                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Sifra)) zNew.Sifra = zatvorskaJedinicaBasic.Sifra;
                if (zatvorskaJedinicaBasic.Kapacitet != null) zNew.Kapacitet = (int)zatvorskaJedinicaBasic.Kapacitet;
                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Naziv)) zNew.Naziv = zatvorskaJedinicaBasic.Naziv;
                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Adresa)) zNew.Adresa = zatvorskaJedinicaBasic.Adresa;

                zNew.ORezim = false;
                zNew.SRezim = true;
                zNew.PORezim = false;

                s.Save(zNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static void UpdateZJStrogogTipa(ZJStrogogTipaBasic zj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJStrogogTipa zjOld = s
                    .Query<ZJStrogogTipa>()
                    .Where(z => z.Sifra == zj.Sifra)
                    .FirstOrDefault();

                if (zj.Kapacitet != null) zjOld.Kapacitet = (int)zj.Kapacitet;
                if (!String.IsNullOrEmpty(zj.Naziv)) zjOld.Naziv = zj.Naziv;
                if (!String.IsNullOrEmpty(zj.Adresa)) zjOld.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    zjOld.Upravnik = s.Query<Administracija>()
                    .Where(a => a.JMBG == zj.Upravnik.JMBG)
                    .FirstOrDefault();
                }

                s.SaveOrUpdate(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static ZJStrogogTipaBasic ReadZJStrogogTipa(string sifra)
        {
            ZJStrogogTipaBasic ret = new ZJStrogogTipaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ZJStrogogTipa zj = s.Query<ZJStrogogTipa>()
                    .Where(z => z.Sifra == sifra)
                    .FirstOrDefault();

                ret.Sifra = zj.Sifra;
                ret.Kapacitet = zj.Kapacitet;
                ret.Naziv = zj.Naziv;
                ret.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    ret.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                    if (ret.Upravnik.RadiU != null)
                        ret.Upravnik.RadiU = ret;
                }

                ret.ORezim = zj.ORezim;
                ret.SRezim = zj.SRezim;
                ret.PORezim = zj.PORezim;
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<ZJStrogogTipaBasic> ReadAllZJStrogogTipa()
        {
            List<ZJStrogogTipaBasic> ret = new List<ZJStrogogTipaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<ZJStrogogTipa> lista = s.Query<ZJStrogogTipa>().ToList();

                ZJStrogogTipaBasic retSingle;
                lista.ForEach(zj =>
                {
                    retSingle = new ZJStrogogTipaBasic();

                    retSingle.Sifra = zj.Sifra;
                    retSingle.Kapacitet = zj.Kapacitet;
                    retSingle.Naziv = zj.Naziv;
                    retSingle.Adresa = zj.Adresa;

                    if (zj.Upravnik != null)
                    {
                        retSingle.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                        if (retSingle.Upravnik.RadiU != null)
                            retSingle.Upravnik.RadiU = retSingle;
                    }

                    retSingle.ORezim = zj.ORezim;
                    retSingle.SRezim = zj.SRezim;
                    retSingle.PORezim = zj.PORezim;

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static ZJStrogogTipaBasic ReadZJStrogogTipaFULL(string sifra)
        {
            ZJStrogogTipaBasic ret = new ZJStrogogTipaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ZJStrogogTipa zj = s.Query<ZJStrogogTipa>()
                    .Where(z => z.Sifra == sifra)
                    .FirstOrDefault();

                ret.Sifra = zj.Sifra;
                ret.Kapacitet = zj.Kapacitet;
                ret.Naziv = zj.Naziv;
                ret.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    ret.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                    if (ret.Upravnik.RadiU != null)
                        ret.Upravnik.RadiU = ret;
                }

                ret.Zaposleni = ReadAllZaposleniFor(ret);
                ret.Zatvorenici = ReadAllZatvorenikFor(ret);

                ret.ORezim = zj.ORezim;
                ret.SRezim = zj.SRezim;
                ret.PORezim = zj.PORezim;

                ret.TerminiPosete = ReadAllTerminPoseteFor(ret);
                ret.TerminiSetnje = ReadAllTerminSetnjeFor(ret);

                ret.CelijskiPeriodi = ReadAllCelijskiPeriodFor(ret);

                ret.Firme = ReadAllFirmaFor(ret);
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<ZJStrogogTipaBasic> ReadAllZJStrogogTipaFULL()
        {
            List<ZJStrogogTipaBasic> ret = new List<ZJStrogogTipaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<ZJStrogogTipa> lista = s.Query<ZJStrogogTipa>().ToList();

                ZJStrogogTipaBasic retSingle;
                lista.ForEach(zj =>
                {
                    retSingle = new ZJStrogogTipaBasic();

                    retSingle.Sifra = zj.Sifra;
                    retSingle.Kapacitet = zj.Kapacitet;
                    retSingle.Naziv = zj.Naziv;
                    retSingle.Adresa = zj.Adresa;

                    if (zj.Upravnik != null)
                    {
                        retSingle.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                        if (retSingle.Upravnik.RadiU != null)
                            retSingle.Upravnik.RadiU = retSingle;
                    }

                    retSingle.Zaposleni = ReadAllZaposleniFor(retSingle);
                    retSingle.Zatvorenici = ReadAllZatvorenikFor(retSingle);

                    retSingle.ORezim = zj.ORezim;
                    retSingle.SRezim = zj.SRezim;
                    retSingle.PORezim = zj.PORezim;

                    retSingle.TerminiPosete = ReadAllTerminPoseteFor(retSingle);
                    retSingle.TerminiSetnje = ReadAllTerminSetnjeFor(retSingle);

                    retSingle.CelijskiPeriodi = ReadAllCelijskiPeriodFor(retSingle);

                    retSingle.Firme = ReadAllFirmaFor(retSingle);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static void DeleteZJStrogogTipa(string Sifra)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJStrogogTipa zjOld = s
                    .Query<ZJStrogogTipa>()
                    .Where(z => z.Sifra == Sifra)
                    .FirstOrDefault();

                s.Delete(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        #endregion

        #region Zatvorska Jedinica Otvoreni Strogi Režim
        public static void CreateZJOtvorenoStrogogTipa(ZatvorskaJedinicaBasic zatvorskaJedinicaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZJOtvorenoStrogogTipa zNew = new ZJOtvorenoStrogogTipa();

                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Sifra)) zNew.Sifra = zatvorskaJedinicaBasic.Sifra;
                if (zatvorskaJedinicaBasic.Kapacitet != null) zNew.Kapacitet = (int)zatvorskaJedinicaBasic.Kapacitet;
                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Naziv)) zNew.Naziv = zatvorskaJedinicaBasic.Naziv;
                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Adresa)) zNew.Adresa = zatvorskaJedinicaBasic.Adresa;

               zNew.ORezim = true;
                zNew.SRezim = true;
                zNew.PORezim = false;

                s.Save(zNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static void UpdateZJOtvorenoStrogogTipa(ZJOtvorenoStrogogTipaBasic zj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJOtvorenoStrogogTipa zjOld = s
                    .Query<ZJOtvorenoStrogogTipa>()
                    .Where(z => z.Sifra == zj.Sifra)
                    .FirstOrDefault();

                if (zj.Kapacitet != null) zjOld.Kapacitet = (int)zj.Kapacitet;
                if (!String.IsNullOrEmpty(zj.Naziv)) zjOld.Naziv = zj.Naziv;
                if (!String.IsNullOrEmpty(zj.Adresa)) zjOld.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    zjOld.Upravnik = s.Query<Administracija>()
                    .Where(a => a.JMBG == zj.Upravnik.JMBG)
                    .FirstOrDefault();
                }

                s.SaveOrUpdate(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static ZJOtvorenoStrogogTipaBasic ReadZJOtvorenoStrogogTipa(string sifra)
        {
            ZJOtvorenoStrogogTipaBasic ret = new ZJOtvorenoStrogogTipaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ZJOtvorenoStrogogTipa zj = s.Query<ZJOtvorenoStrogogTipa>()
                    .Where(z => z.Sifra == sifra)
                    .FirstOrDefault();

                ret.Sifra = zj.Sifra;
                ret.Kapacitet = zj.Kapacitet;
                ret.Naziv = zj.Naziv;
                ret.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    ret.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                    if (ret.Upravnik.RadiU != null)
                        ret.Upravnik.RadiU = ret;
                }

                ret.ORezim = zj.ORezim;
                ret.SRezim = zj.SRezim;
                ret.PORezim = zj.PORezim;
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<ZJOtvorenoStrogogTipaBasic> ReadAllZJOtvorenoStrogogTipa()
        {
            List<ZJOtvorenoStrogogTipaBasic> ret = new List<ZJOtvorenoStrogogTipaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<ZJOtvorenoStrogogTipa> lista = s.Query<ZJOtvorenoStrogogTipa>().ToList();

                ZJOtvorenoStrogogTipaBasic retSingle;
                lista.ForEach(zj =>
                {
                    retSingle = new ZJOtvorenoStrogogTipaBasic();

                    retSingle.Sifra = zj.Sifra;
                    retSingle.Kapacitet = zj.Kapacitet;
                    retSingle.Naziv = zj.Naziv;
                    retSingle.Adresa = zj.Adresa;

                    if (zj.Upravnik != null)
                    {
                        retSingle.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                        if (retSingle.Upravnik.RadiU != null)
                            retSingle.Upravnik.RadiU = retSingle;
                    }

                    retSingle.ORezim = zj.ORezim;
                    retSingle.SRezim = zj.SRezim;
                    retSingle.PORezim = zj.PORezim;

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static ZJOtvorenoStrogogTipaBasic ReadZJOtvorenoStrogogTipaFULL(string sifra)
        {
            ZJOtvorenoStrogogTipaBasic ret = new ZJOtvorenoStrogogTipaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ZJOtvorenoStrogogTipa zj = s.Query<ZJOtvorenoStrogogTipa>()
                    .Where(z => z.Sifra == sifra)
                    .FirstOrDefault();

                ret.Sifra = zj.Sifra;
                ret.Kapacitet = zj.Kapacitet;
                ret.Naziv = zj.Naziv;
                ret.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    ret.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                    if (ret.Upravnik.RadiU != null)
                        ret.Upravnik.RadiU = ret;
                }

                ret.Zaposleni = ReadAllZaposleniFor(ret);
                ret.Zatvorenici = ReadAllZatvorenikFor(ret);

                ret.ORezim = zj.ORezim;
                ret.SRezim = zj.SRezim;
                ret.PORezim = zj.PORezim;

                ret.TerminiPosete = ReadAllTerminPoseteFor(ret);
                ret.TerminiSetnje = ReadAllTerminSetnjeFor(ret);

                ret.CelijskiPeriodi = ReadAllCelijskiPeriodFor(ret);

                ret.Firme = ReadAllFirmaFor(ret);
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<ZJOtvorenoStrogogTipaBasic> ReadAllZJOtvorenoStrogogTipaFULL()
        {
            List<ZJOtvorenoStrogogTipaBasic> ret = new List<ZJOtvorenoStrogogTipaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<ZJOtvorenoStrogogTipa> lista = s.Query<ZJOtvorenoStrogogTipa>().ToList();

                ZJOtvorenoStrogogTipaBasic retSingle;
                lista.ForEach(zj =>
                {
                    retSingle = new ZJOtvorenoStrogogTipaBasic();

                    retSingle.Sifra = zj.Sifra;
                    retSingle.Kapacitet = zj.Kapacitet;
                    retSingle.Naziv = zj.Naziv;
                    retSingle.Adresa = zj.Adresa;

                    if (zj.Upravnik != null)
                    {
                        retSingle.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                        if (retSingle.Upravnik.RadiU != null)
                            retSingle.Upravnik.RadiU = retSingle;
                    }

                    retSingle.Zaposleni = ReadAllZaposleniFor(retSingle);
                    retSingle.Zatvorenici = ReadAllZatvorenikFor(retSingle);

                    retSingle.ORezim = zj.ORezim;
                    retSingle.SRezim = zj.SRezim;
                    retSingle.PORezim = zj.PORezim;

                    retSingle.TerminiPosete = ReadAllTerminPoseteFor(retSingle);
                    retSingle.TerminiSetnje = ReadAllTerminSetnjeFor(retSingle);

                    retSingle.CelijskiPeriodi = ReadAllCelijskiPeriodFor(retSingle);

                    retSingle.Firme = ReadAllFirmaFor(retSingle);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static void DeleteZJOtvorenoStrogogTipa(string Sifra)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJOtvorenoStrogogTipa zjOld = s
                    .Query<ZJOtvorenoStrogogTipa>()
                    .Where(z => z.Sifra == Sifra)
                    .FirstOrDefault();

                s.Delete(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        #endregion

        #region Zatvorska Jedinica Otvoren Poluotvoren Režim
        public static void CreateZJOtvorenoPoluotvorenogTipa(ZJOtvorenoPoluotvorenogTipaBasic zatvorskaJedinicaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZJOtvorenoPoluotvorenogTipa zNew = new ZJOtvorenoPoluotvorenogTipa();

                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Sifra)) zNew.Sifra = zatvorskaJedinicaBasic.Sifra;
                if (zatvorskaJedinicaBasic.Kapacitet != null) zNew.Kapacitet = (int)zatvorskaJedinicaBasic.Kapacitet;
                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Naziv)) zNew.Naziv = zatvorskaJedinicaBasic.Naziv;
                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Adresa)) zNew.Adresa = zatvorskaJedinicaBasic.Adresa;

                zNew.ORezim = true;
                zNew.SRezim = false;
                zNew.PORezim = true;

                s.Save(zNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static void UpdateZJOtvorenoPoluotvorenogTipa(ZJOtvorenoPoluotvorenogTipaBasic zj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJOtvorenoPoluotvorenogTipa zjOld = s
                    .Query<ZJOtvorenoPoluotvorenogTipa>()
                    .Where(z => z.Sifra == zj.Sifra)
                    .FirstOrDefault();

                if (zj.Kapacitet != null) zjOld.Kapacitet = (int)zj.Kapacitet;
                if (!String.IsNullOrEmpty(zj.Naziv)) zjOld.Naziv = zj.Naziv;
                if (!String.IsNullOrEmpty(zj.Adresa)) zjOld.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    zjOld.Upravnik = s.Query<Administracija>()
                    .Where(a => a.JMBG == zj.Upravnik.JMBG)
                    .FirstOrDefault();
                }

                //if (zj.ORezim != null) zjOld.ORezim = (bool)zj.ORezim;
                //if (zj.SRezim != null) zjOld.SRezim = (bool)zj.SRezim;
                //if (zj.PORezim != null) zjOld.PORezim = (bool)zj.PORezim;

                s.SaveOrUpdate(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static ZJOtvorenoPoluotvorenogTipaBasic ReadZJOtvorenoPoluotvorenogTipa(string sifra)
        {
            ZJOtvorenoPoluotvorenogTipaBasic ret = new ZJOtvorenoPoluotvorenogTipaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ZJOtvorenoPoluotvorenogTipa zj = s.Query<ZJOtvorenoPoluotvorenogTipa>()
                    .Where(z => z.Sifra == sifra)
                    .FirstOrDefault();

                ret.Sifra = zj.Sifra;
                ret.Kapacitet = zj.Kapacitet;
                ret.Naziv = zj.Naziv;
                ret.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    ret.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                    if (ret.Upravnik.RadiU != null)
                        ret.Upravnik.RadiU = ret;
                }

                ret.ORezim = zj.ORezim;
                ret.SRezim = zj.SRezim;
                ret.PORezim = zj.PORezim;
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<ZJOtvorenoPoluotvorenogTipaBasic> ReadAllZJOtvorenoPoluotvorenogTipa()
        {
            List<ZJOtvorenoPoluotvorenogTipaBasic> ret = new List<ZJOtvorenoPoluotvorenogTipaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<ZJOtvorenoPoluotvorenogTipa> lista = s.Query<ZJOtvorenoPoluotvorenogTipa>().ToList();

                ZJOtvorenoPoluotvorenogTipaBasic retSingle;
                lista.ForEach(zj =>
                {
                    retSingle = new ZJOtvorenoPoluotvorenogTipaBasic();

                    retSingle.Sifra = zj.Sifra;
                    retSingle.Kapacitet = zj.Kapacitet;
                    retSingle.Naziv = zj.Naziv;
                    retSingle.Adresa = zj.Adresa;

                    if (zj.Upravnik != null)
                    {
                        retSingle.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                        if (retSingle.Upravnik.RadiU != null)
                            retSingle.Upravnik.RadiU = retSingle;
                    }

                    retSingle.ORezim = zj.ORezim;
                    retSingle.SRezim = zj.SRezim;
                    retSingle.PORezim = zj.PORezim;

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static ZJOtvorenoPoluotvorenogTipaBasic ReadZJOtvorenoPoluotvorenogTipaFULL(string sifra)
        {
            ZJOtvorenoPoluotvorenogTipaBasic ret = new ZJOtvorenoPoluotvorenogTipaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ZJOtvorenoPoluotvorenogTipa zj = s.Query<ZJOtvorenoPoluotvorenogTipa>()
                    .Where(z => z.Sifra == sifra)
                    .FirstOrDefault();

                ret.Sifra = zj.Sifra;
                ret.Kapacitet = zj.Kapacitet;
                ret.Naziv = zj.Naziv;
                ret.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    ret.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                    if (ret.Upravnik.RadiU != null)
                        ret.Upravnik.RadiU = ret;
                }

                ret.Zaposleni = ReadAllZaposleniFor(ret);
                ret.Zatvorenici = ReadAllZatvorenikFor(ret);

                ret.ORezim = zj.ORezim;
                ret.SRezim = zj.SRezim;
                ret.PORezim = zj.PORezim;

                ret.TerminiPosete = ReadAllTerminPoseteFor(ret);
                ret.TerminiSetnje = ReadAllTerminSetnjeFor(ret);

                ret.CelijskiPeriodi = ReadAllCelijskiPeriodFor(ret);

                ret.Firme = ReadAllFirmaFor(ret);
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<ZJOtvorenoPoluotvorenogTipaBasic> ReadAllZJOtvorenoPoluotvorenogTipaFULL()
        {
            List<ZJOtvorenoPoluotvorenogTipaBasic> ret = new List<ZJOtvorenoPoluotvorenogTipaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<ZJOtvorenoPoluotvorenogTipa> lista = s.Query<ZJOtvorenoPoluotvorenogTipa>().ToList();

                ZJOtvorenoPoluotvorenogTipaBasic retSingle;
                lista.ForEach(zj =>
                {
                    retSingle = new ZJOtvorenoPoluotvorenogTipaBasic();

                    retSingle.Sifra = zj.Sifra;
                    retSingle.Kapacitet = zj.Kapacitet;
                    retSingle.Naziv = zj.Naziv;
                    retSingle.Adresa = zj.Adresa;

                    if (zj.Upravnik != null)
                    {
                        retSingle.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                        if (retSingle.Upravnik.RadiU != null)
                            retSingle.Upravnik.RadiU = retSingle;
                    }

                    retSingle.Zaposleni = ReadAllZaposleniFor(retSingle);
                    retSingle.Zatvorenici = ReadAllZatvorenikFor(retSingle);

                    retSingle.ORezim = zj.ORezim;
                    retSingle.SRezim = zj.SRezim;
                    retSingle.PORezim = zj.PORezim;

                    retSingle.TerminiPosete = ReadAllTerminPoseteFor(retSingle);
                    retSingle.TerminiSetnje = ReadAllTerminSetnjeFor(retSingle);

                    retSingle.CelijskiPeriodi = ReadAllCelijskiPeriodFor(retSingle);

                    retSingle.Firme = ReadAllFirmaFor(retSingle);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static void DeleteZJOtvorenoPoluotvorenogTipa(string Sifra)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJOtvorenoPoluotvorenogTipa zjOld = s
                    .Query<ZJOtvorenoPoluotvorenogTipa>()
                    .Where(z => z.Sifra == Sifra)
                    .FirstOrDefault();

                s.Delete(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        #endregion

        #region Zatvorska Jedinica Poluotvoren Strogi Režim
        public static void CreateZJPoluotvorenoStrogogTipa(ZJPoluotvorenoStrogogTipaBasic zatvorskaJedinicaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZJPoluotvorenoStrogogTipa zNew = new ZJPoluotvorenoStrogogTipa();

                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Sifra)) zNew.Sifra = zatvorskaJedinicaBasic.Sifra;
                if (zatvorskaJedinicaBasic.Kapacitet != null) zNew.Kapacitet = (int)zatvorskaJedinicaBasic.Kapacitet;
                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Naziv)) zNew.Naziv = zatvorskaJedinicaBasic.Naziv;
                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Adresa)) zNew.Adresa = zatvorskaJedinicaBasic.Adresa;

                zNew.ORezim = false;
                zNew.SRezim = true;
                zNew.PORezim = true;

                s.Save(zNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static void UpdateZJPoluotvorenoStrogogTipa(ZJPoluotvorenoStrogogTipaBasic zj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJPoluotvorenoStrogogTipa zjOld = s
                    .Query<ZJPoluotvorenoStrogogTipa>()
                    .Where(z => z.Sifra == zj.Sifra)
                    .FirstOrDefault();

                if (zj.Kapacitet != null) zjOld.Kapacitet = (int)zj.Kapacitet;
                if (!String.IsNullOrEmpty(zj.Naziv)) zjOld.Naziv = zj.Naziv;
                if (!String.IsNullOrEmpty(zj.Adresa)) zjOld.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    zjOld.Upravnik = s.Query<Administracija>()
                    .Where(a => a.JMBG == zj.Upravnik.JMBG)
                    .FirstOrDefault();
                }

                //if (zj.ORezim != null) zjOld.ORezim = (bool)zj.ORezim;
                //if (zj.SRezim != null) zjOld.SRezim = (bool)zj.SRezim;
                //if (zj.PORezim != null) zjOld.PORezim = (bool)zj.PORezim;

                s.SaveOrUpdate(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static ZJPoluotvorenoStrogogTipaBasic ReadZJPoluotvorenoStrogogTipa(string sifra)
        {
            ZJPoluotvorenoStrogogTipaBasic ret = new ZJPoluotvorenoStrogogTipaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ZJPoluotvorenoStrogogTipa zj = s.Query<ZJPoluotvorenoStrogogTipa>()
                    .Where(z => z.Sifra == sifra)
                    .FirstOrDefault();

                ret.Sifra = zj.Sifra;
                ret.Kapacitet = zj.Kapacitet;
                ret.Naziv = zj.Naziv;
                ret.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    ret.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                    if (ret.Upravnik.RadiU != null)
                        ret.Upravnik.RadiU = ret;
                }

                ret.ORezim = zj.ORezim;
                ret.SRezim = zj.SRezim;
                ret.PORezim = zj.PORezim;
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<ZJPoluotvorenoStrogogTipaBasic> ReadAllZJPoluotvorenoStrogogTipa()
        {
            List<ZJPoluotvorenoStrogogTipaBasic> ret = new List<ZJPoluotvorenoStrogogTipaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<ZJPoluotvorenoStrogogTipa> lista = s.Query<ZJPoluotvorenoStrogogTipa>().ToList();

                ZJPoluotvorenoStrogogTipaBasic retSingle;
                lista.ForEach(zj =>
                {
                    retSingle = new ZJPoluotvorenoStrogogTipaBasic();

                    retSingle.Sifra = zj.Sifra;
                    retSingle.Kapacitet = zj.Kapacitet;
                    retSingle.Naziv = zj.Naziv;
                    retSingle.Adresa = zj.Adresa;

                    if (zj.Upravnik != null)
                    {
                        retSingle.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                        if (retSingle.Upravnik.RadiU != null)
                            retSingle.Upravnik.RadiU = retSingle;
                    }

                    retSingle.ORezim = zj.ORezim;
                    retSingle.SRezim = zj.SRezim;
                    retSingle.PORezim = zj.PORezim;

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static ZJPoluotvorenoStrogogTipaBasic ReadZJPoluotvorenoStrogogTipaFULL(string sifra)
        {
            ZJPoluotvorenoStrogogTipaBasic ret = new ZJPoluotvorenoStrogogTipaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ZJPoluotvorenoStrogogTipa zj = s.Query<ZJPoluotvorenoStrogogTipa>()
                    .Where(z => z.Sifra == sifra)
                    .FirstOrDefault();

                ret.Sifra = zj.Sifra;
                ret.Kapacitet = zj.Kapacitet;
                ret.Naziv = zj.Naziv;
                ret.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    ret.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                    if (ret.Upravnik.RadiU != null)
                        ret.Upravnik.RadiU = ret;
                }

                ret.Zaposleni = ReadAllZaposleniFor(ret);
                ret.Zatvorenici = ReadAllZatvorenikFor(ret);

                ret.ORezim = zj.ORezim;
                ret.SRezim = zj.SRezim;
                ret.PORezim = zj.PORezim;

                ret.TerminiPosete = ReadAllTerminPoseteFor(ret);
                ret.TerminiSetnje = ReadAllTerminSetnjeFor(ret);

                ret.CelijskiPeriodi = ReadAllCelijskiPeriodFor(ret);

                ret.Firme = ReadAllFirmaFor(ret);
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<ZJPoluotvorenoStrogogTipaBasic> ReadAllZJPoluotvorenoStrogogTipaFULL()
        {
            List<ZJPoluotvorenoStrogogTipaBasic> ret = new List<ZJPoluotvorenoStrogogTipaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<ZJPoluotvorenoStrogogTipa> lista = s.Query<ZJPoluotvorenoStrogogTipa>().ToList();

                ZJPoluotvorenoStrogogTipaBasic retSingle;
                lista.ForEach(zj =>
                {
                    retSingle = new ZJPoluotvorenoStrogogTipaBasic();

                    retSingle.Sifra = zj.Sifra;
                    retSingle.Kapacitet = zj.Kapacitet;
                    retSingle.Naziv = zj.Naziv;
                    retSingle.Adresa = zj.Adresa;

                    if (zj.Upravnik != null)
                    {
                        retSingle.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                        if (retSingle.Upravnik.RadiU != null)
                            retSingle.Upravnik.RadiU = retSingle;
                    }

                    retSingle.Zaposleni = ReadAllZaposleniFor(retSingle);
                    retSingle.Zatvorenici = ReadAllZatvorenikFor(retSingle);

                    retSingle.ORezim = zj.ORezim;
                    retSingle.SRezim = zj.SRezim;
                    retSingle.PORezim = zj.PORezim;

                    retSingle.TerminiPosete = ReadAllTerminPoseteFor(retSingle);
                    retSingle.TerminiSetnje = ReadAllTerminSetnjeFor(retSingle);

                    retSingle.CelijskiPeriodi = ReadAllCelijskiPeriodFor(retSingle);

                    retSingle.Firme = ReadAllFirmaFor(retSingle);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static void DeleteZJPoluotvorenoStrogogTipa(string Sifra)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJPoluotvorenoStrogogTipa zjOld = s
                    .Query<ZJPoluotvorenoStrogogTipa>()
                    .Where(z => z.Sifra == Sifra)
                    .FirstOrDefault();

                s.Delete(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        #endregion

        #region Zatvorska Jedinica Svi Režimi
        public static void CreateZJSvakiTip(ZJSvakiTipBasic zatvorskaJedinicaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZJSvakiTip zNew = new ZJSvakiTip();

                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Sifra)) zNew.Sifra = zatvorskaJedinicaBasic.Sifra;
                if (zatvorskaJedinicaBasic.Kapacitet != null) zNew.Kapacitet = (int)zatvorskaJedinicaBasic.Kapacitet;
                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Naziv)) zNew.Naziv = zatvorskaJedinicaBasic.Naziv;
                if (!String.IsNullOrEmpty(zatvorskaJedinicaBasic.Adresa)) zNew.Adresa = zatvorskaJedinicaBasic.Adresa;

                zNew.ORezim = true;
                zNew.SRezim = true;
                zNew.PORezim = true;

                s.Save(zNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static void UpdateZJSvakiTip(ZJSvakiTipBasic zj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJSvakiTip zjOld = s
                    .Query<ZJSvakiTip>()
                    .Where(z => z.Sifra == zj.Sifra)
                    .FirstOrDefault();

                if (zj.Kapacitet != null) zjOld.Kapacitet = (int)zj.Kapacitet;
                if (!String.IsNullOrEmpty(zj.Naziv)) zjOld.Naziv = zj.Naziv;
                if (!String.IsNullOrEmpty(zj.Adresa)) zjOld.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    zjOld.Upravnik = s.Query<Administracija>()
                    .Where(a => a.JMBG == zj.Upravnik.JMBG)
                    .FirstOrDefault();
                }

                s.SaveOrUpdate(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static ZJSvakiTipBasic ReadZJSvakiTip(string sifra)
        {
            ZJSvakiTipBasic ret = new ZJSvakiTipBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ZJSvakiTip zj = s.Query<ZJSvakiTip>()
                    .Where(z => z.Sifra == sifra)
                    .FirstOrDefault();

                ret.Sifra = zj.Sifra;
                ret.Kapacitet = zj.Kapacitet;
                ret.Naziv = zj.Naziv;
                ret.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    ret.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                    if (ret.Upravnik.RadiU != null)
                        ret.Upravnik.RadiU = ret;
                }

                ret.ORezim = zj.ORezim;
                ret.SRezim = zj.SRezim;
                ret.PORezim = zj.PORezim;
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<ZJSvakiTipBasic> ReadAllZJSvakiTip()
        {
            List<ZJSvakiTipBasic> ret = new List<ZJSvakiTipBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<ZJSvakiTip> lista = s.Query<ZJSvakiTip>().ToList();

                ZJSvakiTipBasic retSingle;
                lista.ForEach(zj =>
                {
                    retSingle = new ZJSvakiTipBasic();

                    retSingle.Sifra = zj.Sifra;
                    retSingle.Kapacitet = zj.Kapacitet;
                    retSingle.Naziv = zj.Naziv;
                    retSingle.Adresa = zj.Adresa;

                    if (zj.Upravnik != null)
                    {
                        retSingle.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                        if (retSingle.Upravnik.RadiU != null)
                            retSingle.Upravnik.RadiU = retSingle;
                    }

                    retSingle.ORezim = zj.ORezim;
                    retSingle.SRezim = zj.SRezim;
                    retSingle.PORezim = zj.PORezim;

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static ZJSvakiTipBasic ReadZJSvakiTipFULL(string sifra)
        {
            ZJSvakiTipBasic ret = new ZJSvakiTipBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ZJSvakiTip zj = s.Query<ZJSvakiTip>()
                    .Where(z => z.Sifra == sifra)
                    .FirstOrDefault();

                ret.Sifra = zj.Sifra;
                ret.Kapacitet = zj.Kapacitet;
                ret.Naziv = zj.Naziv;
                ret.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    ret.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                    if (ret.Upravnik.RadiU != null)
                        ret.Upravnik.RadiU = ret;
                }

                ret.Zaposleni = ReadAllZaposleniFor(ret);
                ret.Zatvorenici = ReadAllZatvorenikFor(ret);

                ret.ORezim = zj.ORezim;
                ret.SRezim = zj.SRezim;
                ret.PORezim = zj.PORezim;

                ret.TerminiPosete = ReadAllTerminPoseteFor(ret);
                ret.TerminiSetnje = ReadAllTerminSetnjeFor(ret);

                ret.CelijskiPeriodi = ReadAllCelijskiPeriodFor(ret);

                ret.Firme = ReadAllFirmaFor(ret);
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<ZJSvakiTipBasic> ReadAllZJSvakiTipFULL()
        {
            List<ZJSvakiTipBasic> ret = new List<ZJSvakiTipBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<ZJSvakiTip> lista = s.Query<ZJSvakiTip>().ToList();

                ZJSvakiTipBasic retSingle;
                lista.ForEach(zj =>
                {
                    retSingle = new ZJSvakiTipBasic();

                    retSingle.Sifra = zj.Sifra;
                    retSingle.Kapacitet = zj.Kapacitet;
                    retSingle.Naziv = zj.Naziv;
                    retSingle.Adresa = zj.Adresa;

                    if (zj.Upravnik != null)
                    {
                        retSingle.Upravnik = ReadAdministracijaUpravnik(zj.Upravnik.JMBG);
                        if (retSingle.Upravnik.RadiU != null)
                            retSingle.Upravnik.RadiU = retSingle;
                    }

                    retSingle.Zaposleni = ReadAllZaposleniFor(retSingle);
                    retSingle.Zatvorenici = ReadAllZatvorenikFor(retSingle);

                    retSingle.ORezim = zj.ORezim;
                    retSingle.SRezim = zj.SRezim;
                    retSingle.PORezim = zj.PORezim;

                    retSingle.TerminiPosete = ReadAllTerminPoseteFor(retSingle);
                    retSingle.TerminiSetnje = ReadAllTerminSetnjeFor(retSingle);

                    retSingle.CelijskiPeriodi = ReadAllCelijskiPeriodFor(retSingle);

                    retSingle.Firme = ReadAllFirmaFor(retSingle);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static void DeleteZJSvakiTip(string Sifra)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJSvakiTip zjOld = s
                    .Query<ZJSvakiTip>()
                    .Where(z => z.Sifra == Sifra)
                    .FirstOrDefault();

                s.Delete(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        #endregion

        #endregion

        #region Termin Posete
        public static void CreateTerminPosete(TerminPoseteBasic terminPoseteBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                TerminPosete tNew = new TerminPosete();

                tNew.Dan = terminPoseteBasic.Dan;
                tNew.Period = terminPoseteBasic.Period;
                tNew.ZatvorskaJedinica = s.Query<ZatvorskaJedinica>()
                    .Where(zj => zj.Sifra == terminPoseteBasic.ZatvorskaJedinica.Sifra)
                    .FirstOrDefault();

                s.Save(tNew);
                s.Flush();

                terminPoseteBasic.ID = tNew.ID;

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        public static TerminPoseteBasic ReadTerminPosete(int ID)
        {
            TerminPoseteBasic ret = new TerminPoseteBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                TerminPosete p = s.Query<TerminPosete>()
                    .Where(tp => tp.ID == ID)
                    .FirstOrDefault();

                ret.ID = p.ID;
                ret.Dan = p.Dan;
                ret.Period = p.Period;
                ret.ZatvorskaJedinica = ReadZatvorskaJedinica(p.ZatvorskaJedinica.Sifra);

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static List<TerminPoseteBasic> ReadAllTerminPosete()
        {
            List<TerminPoseteBasic> ret = new List<TerminPoseteBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<TerminPosete> list = s.Query<TerminPosete>().ToList();

                TerminPoseteBasic retSingle;

                list.ForEach(p =>
                {
                    retSingle = new TerminPoseteBasic();

                    retSingle.ID = p.ID;
                    retSingle.Dan = p.Dan;
                    retSingle.Period = p.Period;
                    retSingle.ZatvorskaJedinica = ReadZatvorskaJedinica(p.ZatvorskaJedinica.Sifra);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static List<TerminPoseteBasic> ReadAllTerminPoseteFor(ZatvorskaJedinicaBasic zatvoskaJedinicaBasic)
        {
            List<TerminPoseteBasic> ret = new List<TerminPoseteBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<TerminPosete> list = s.Query<TerminPosete>()
                    .Where(tp => tp.ZatvorskaJedinica.Sifra == zatvoskaJedinicaBasic.Sifra)
                    .ToList();

                TerminPoseteBasic retSingle;

                list.ForEach(p =>
                {
                    retSingle = new TerminPoseteBasic();

                    retSingle.ID = p.ID;
                    retSingle.Dan = p.Dan;
                    retSingle.Period = p.Period;
                    retSingle.ZatvorskaJedinica = ReadZatvorskaJedinica(p.ZatvorskaJedinica.Sifra);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static void UpdateTerminPosete(TerminPoseteBasic terminPoseteBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                TerminPosete p = s.Query<TerminPosete>()
                    .Where(tp => tp.ID == terminPoseteBasic.ID)
                    .FirstOrDefault();

                if (!String.IsNullOrEmpty(terminPoseteBasic.Dan)) p.Dan = terminPoseteBasic.Dan;
                if (!String.IsNullOrEmpty(terminPoseteBasic.Period)) p.Period = terminPoseteBasic.Period;

                s.SaveOrUpdate(p);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        public static void DeleteTerminPosete(int ID)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                TerminPosete p = s.Query<TerminPosete>()
                    .Where(tp => tp.ID == ID)
                    .FirstOrDefault();
                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        #endregion

        #region Termin Šetnje
        public static void CreateTerminSetnje(TerminSetnjeBasic terminSetnjeBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                TerminSetnje ts = new TerminSetnje();

                ts.Termin = terminSetnjeBasic.Termin;
                ts.ZatvorskaJedinica = s.Query<ZatvorskaJedinica>()
                    .Where(zj => zj.Sifra == terminSetnjeBasic.ZatvorskaJedinica.Sifra)
                    .FirstOrDefault();

                s.Save(ts);
                s.Flush();

                terminSetnjeBasic.ID = ts.ID;

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        public static TerminSetnjeBasic ReadTerminSetnje(int ID)
        {
            TerminSetnjeBasic ret = new TerminSetnjeBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                TerminSetnje ts = s.Query<TerminSetnje>()
                    .Where(termin => termin.ID == ID)
                    .FirstOrDefault();

                ret.ID = ts.ID;
                ret.Termin = ts.Termin;
                ret.ZatvorskaJedinica = ReadZatvorskaJedinica(ts.ZatvorskaJedinica.Sifra);

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static List<TerminSetnjeBasic> ReadAllTerminSetnje()
        {
            List<TerminSetnjeBasic> ret = new List<TerminSetnjeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                List<TerminSetnje> lista = s.Query<TerminSetnje>().ToList();

                TerminSetnjeBasic retSingle;

                lista.ForEach(ts =>
                {
                    retSingle = new TerminSetnjeBasic();

                    retSingle.ID = ts.ID;
                    retSingle.Termin = ts.Termin;
                    retSingle.ZatvorskaJedinica = ReadZatvorskaJedinica(ts.ZatvorskaJedinica.Sifra);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static List<TerminSetnjeBasic> ReadAllTerminSetnjeFor(ZatvorskaJedinicaBasic zatvorskaJedinicaBasic)
        {
            List<TerminSetnjeBasic> ret = new List<TerminSetnjeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                List<TerminSetnje> lista = s.Query<TerminSetnje>()
                    .Where(ts => ts.ZatvorskaJedinica.Sifra == zatvorskaJedinicaBasic.Sifra)
                    .ToList();

                TerminSetnjeBasic retSingle;

                lista.ForEach(ts =>
                {
                    retSingle = new TerminSetnjeBasic();

                    retSingle.ID = ts.ID;
                    retSingle.Termin = ts.Termin;
                    retSingle.ZatvorskaJedinica = ReadZatvorskaJedinica(ts.ZatvorskaJedinica.Sifra);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static void UpdateTerminSetnje(TerminSetnjeBasic terminSetnjeBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                TerminSetnje ts = s.Query<TerminSetnje>()
                    .Where(termin => termin.ID == terminSetnjeBasic.ID)
                    .FirstOrDefault();

                if (!String.IsNullOrEmpty(terminSetnjeBasic.Termin)) ts.Termin = terminSetnjeBasic.Termin;

                s.SaveOrUpdate(ts);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        public static void DeleteTerminSetnje(int ID)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                TerminSetnje ts = s.Query<TerminSetnje>()
                    .Where(termin => termin.ID == ID)
                    .FirstOrDefault();

                s.Delete(ts);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        #endregion

        #region CelijskiPeriod
        public static void CreateCelijskiPeriod(CelijskiPeriodBasic celijskiPeriodBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                CelijskiPeriod cp = new CelijskiPeriod();

                cp.Period = celijskiPeriodBasic.Period;
                cp.ZatvorskaJedinica = s.Query<ZatvorskaJedinica>()
                    .Where(zj => zj.Sifra == celijskiPeriodBasic.ZatvorskaJedinica.Sifra)
                    .FirstOrDefault();

                s.Save(cp);
                s.Flush();

                celijskiPeriodBasic.ID = cp.ID;

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        public static CelijskiPeriodBasic ReadCelijskiPeriod(int ID)
        {
            CelijskiPeriodBasic ret = new CelijskiPeriodBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                CelijskiPeriod cp = s.Query<CelijskiPeriod>()
                    .Where(termin => termin.ID == ID)
                    .FirstOrDefault();

                ret.ID = cp.ID;
                ret.Period = cp.Period;
                ret.ZatvorskaJedinica = ReadZatvorskaJedinica(cp.ZatvorskaJedinica.Sifra);

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static List<CelijskiPeriodBasic> ReadAllCelijskiPeriod()
        {
            List<CelijskiPeriodBasic> ret = new List<CelijskiPeriodBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                List<CelijskiPeriod> lista = s.Query<CelijskiPeriod>().ToList();

                CelijskiPeriodBasic retSingle;

                lista.ForEach(cp =>
                {
                    retSingle = new CelijskiPeriodBasic();

                    retSingle.ID = cp.ID;
                    retSingle.Period = cp.Period;
                    retSingle.ZatvorskaJedinica = ReadZatvorskaJedinica(cp.ZatvorskaJedinica.Sifra);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static List<CelijskiPeriodBasic> ReadAllCelijskiPeriodFor(ZatvorskaJedinicaBasic zatvorskaJedinicaBasic)
        {
            List<CelijskiPeriodBasic> ret = new List<CelijskiPeriodBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                List<CelijskiPeriod> lista = s.Query<CelijskiPeriod>()
                    .Where(cp => cp.ZatvorskaJedinica.Sifra == zatvorskaJedinicaBasic.Sifra)
                    .ToList();

                CelijskiPeriodBasic retSingle;

                lista.ForEach(cp =>
                {
                    retSingle = new CelijskiPeriodBasic();

                    retSingle.ID = cp.ID;
                    retSingle.Period = cp.Period;
                    retSingle.ZatvorskaJedinica = ReadZatvorskaJedinica(cp.ZatvorskaJedinica.Sifra);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static void UpdateCelijskiPeriod(CelijskiPeriodBasic celijskiPeriodBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                CelijskiPeriod cp = s.Query<CelijskiPeriod>()
                    .Where(termin => termin.ID == celijskiPeriodBasic.ID)
                    .FirstOrDefault();

                if (!String.IsNullOrEmpty(celijskiPeriodBasic.Period)) cp.Period = celijskiPeriodBasic.Period;

                s.SaveOrUpdate(cp);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        public static void DeleteCelijskiPeriod(int ID)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                CelijskiPeriod cp = s.Query<CelijskiPeriod>()
                    .Where(termin => termin.ID == ID)
                    .FirstOrDefault();

                s.Delete(cp);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        #endregion

        #region Zaposleni

        #region Zaposleni General
        public static void CreateZaposleni(ZaposleniBasic zaposleniBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zaposleni zNew = new Zaposleni();

                zNew.JMBG = zaposleniBasic.JMBG;
                zNew.Ime = zaposleniBasic.Ime;
                zNew.Prezime = zaposleniBasic.Prezime;
                zNew.Pol = zaposleniBasic.Pol;

                zNew.RadnoMesto = zaposleniBasic.RadnoMesto;
                if (zaposleniBasic.DatumObukePPZ != null) zNew.DatumObukePPZ = (DateTime)zaposleniBasic.DatumObukePPZ;
                if (zaposleniBasic.DatumPocetkaRada != null) zNew.DatumPocetkaRada = (DateTime)zaposleniBasic.DatumPocetkaRada;
                zNew.RadiU = s.Query<ZatvorskaJedinica>().Where(zj => zj.Sifra == zaposleniBasic.RadiU.Sifra).FirstOrDefault();

                zNew.Zanimanje = zaposleniBasic.Zanimanje;
                zNew.Pozicija = zaposleniBasic.Pozicija;
                zNew.StrucnaSprema = zaposleniBasic.StrucnaSprema;

                zNew.LPLekar = zaposleniBasic.LPLekar;
                zNew.LPDatum = zaposleniBasic.LPDatum;
                zNew.LPNazivUstanove = zaposleniBasic.LPNazivUstanove;
                zNew.LPAdresaUstanove = zaposleniBasic.LPAdresaUstanove;

                zNew.SSpecijalizacija = zaposleniBasic.SSpecijalizacija;
                zNew.SNazivUstanove = zaposleniBasic.SNazivUstanove;

                zNew.DORVOSifra = zaposleniBasic.DORVOSifra;
                zNew.DORVOPolicijskaUprava = zaposleniBasic.DORVOPolicijskaUprava;
                zNew.DORVODatumIzdavanja = zaposleniBasic.DORVODatumIzdavanja;

                s.Save(zNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        public static List<ZaposleniBasic> ReadAllZaposleni()
        {
            List<ZaposleniBasic> ret = new List<ZaposleniBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<Zaposleni> list = s.Query<Zaposleni>().ToList();

                ZaposleniBasic retSingle;

                list.ForEach(z =>
                {
                    retSingle = new ZaposleniBasic();

                    retSingle.JMBG = z.JMBG;
                    retSingle.Ime = z.Ime;
                    retSingle.Prezime = z.Prezime;
                    retSingle.Pol = z.Pol;

                    retSingle.RadnoMesto = z.RadnoMesto;
                    retSingle.DatumObukePPZ = z.DatumObukePPZ;
                    retSingle.RadiU = ReadZatvorskaJedinica(z.RadiU.Sifra);
                    retSingle.DatumPocetkaRada = z.DatumPocetkaRada;

                    retSingle.Zanimanje = z.Zanimanje;
                    retSingle.Pozicija = z.Pozicija;
                    retSingle.StrucnaSprema = z.StrucnaSprema;

                    retSingle.LPLekar = z.LPLekar;
                    retSingle.LPDatum = z.LPDatum;
                    retSingle.LPNazivUstanove = z.LPNazivUstanove;
                    retSingle.LPAdresaUstanove = z.LPAdresaUstanove;

                    retSingle.SSpecijalizacija = z.SSpecijalizacija;
                    retSingle.SNazivUstanove = z.SNazivUstanove;

                    retSingle.DORVOSifra = z.DORVOSifra;
                    retSingle.DORVOPolicijskaUprava = z.DORVOPolicijskaUprava;
                    retSingle.DORVODatumIzdavanja = z.DORVODatumIzdavanja;

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static List<ZaposleniBasic> ReadAllZaposleniFor(ZatvorskaJedinicaBasic zatvorskaJedinicaBasic)
        {
            List<ZaposleniBasic> ret = new List<ZaposleniBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<Zaposleni> list = s.Query<Zaposleni>()
                    .Where(z => z.RadiU.Sifra == zatvorskaJedinicaBasic.Sifra)
                    .ToList();

                ZaposleniBasic retSingle;

                list.ForEach(z =>
                {
                    retSingle = new ZaposleniBasic();

                    retSingle.JMBG = z.JMBG;
                    retSingle.Ime = z.Ime;
                    retSingle.Prezime = z.Prezime;
                    retSingle.Pol = z.Pol;

                    retSingle.RadnoMesto = z.RadnoMesto;
                    retSingle.DatumObukePPZ = z.DatumObukePPZ;
                    retSingle.RadiU = zatvorskaJedinicaBasic;
                    retSingle.DatumPocetkaRada = z.DatumPocetkaRada;

                    retSingle.Zanimanje = z.Zanimanje;
                    retSingle.Pozicija = z.Pozicija;
                    retSingle.StrucnaSprema = z.StrucnaSprema;

                    retSingle.LPLekar = z.LPLekar;
                    retSingle.LPDatum = z.LPDatum;
                    retSingle.LPNazivUstanove = z.LPNazivUstanove;
                    retSingle.LPAdresaUstanove = z.LPAdresaUstanove;

                    retSingle.SSpecijalizacija = z.SSpecijalizacija;
                    retSingle.SNazivUstanove = z.SNazivUstanove;

                    retSingle.DORVOSifra = z.DORVOSifra;
                    retSingle.DORVOPolicijskaUprava = z.DORVOPolicijskaUprava;
                    retSingle.DORVODatumIzdavanja = z.DORVODatumIzdavanja;

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static ZaposleniBasic ReadZaposleni(string JMBG)
        {
            ZaposleniBasic ret = new ZaposleniBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Zaposleni z = s.Query<Zaposleni>()
                    .Where(zap => zap.JMBG == JMBG)
                    .FirstOrDefault();

                ret.JMBG = z.JMBG;
                ret.Ime = z.Ime;
                ret.Prezime = z.Prezime;
                ret.Pol = z.Pol;

                ret.RadnoMesto = z.RadnoMesto;
                ret.DatumObukePPZ = z.DatumObukePPZ;
                ret.RadiU = ReadZatvorskaJedinica(z.RadiU.Sifra);
                ret.DatumPocetkaRada = z.DatumPocetkaRada;

                ret.Zanimanje = z.Zanimanje;
                ret.Pozicija = z.Pozicija;
                ret.StrucnaSprema = z.StrucnaSprema;

                ret.LPLekar = z.LPLekar;
                ret.LPDatum = z.LPDatum;
                ret.LPNazivUstanove = z.LPNazivUstanove;
                ret.LPAdresaUstanove = z.LPAdresaUstanove;

                ret.SSpecijalizacija = z.SSpecijalizacija;
                ret.SNazivUstanove = z.SNazivUstanove;

                ret.DORVOSifra = z.DORVOSifra;
                ret.DORVOPolicijskaUprava = z.DORVOPolicijskaUprava;
                ret.DORVODatumIzdavanja = z.DORVODatumIzdavanja;

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static void UpdateZaposleni(ZaposleniBasic zaposleniBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zaposleni zOld = s.Query<Zaposleni>()
                    .Where(zap => zap.JMBG == zaposleniBasic.JMBG)
                    .FirstOrDefault();

                if (!String.IsNullOrEmpty(zaposleniBasic.Ime)) zOld.Ime = zaposleniBasic.Ime;
                if (!String.IsNullOrEmpty(zaposleniBasic.Prezime)) zOld.Prezime = zaposleniBasic.Prezime;
                if (!String.IsNullOrEmpty(zaposleniBasic.Pol)) zOld.Pol = zaposleniBasic.Pol;

                if (!String.IsNullOrEmpty(zaposleniBasic.RadnoMesto)) zOld.RadnoMesto = zaposleniBasic.RadnoMesto;
                if (zaposleniBasic.DatumObukePPZ != null) zOld.DatumObukePPZ = (DateTime)zaposleniBasic.DatumObukePPZ;
                if (zaposleniBasic.DatumPocetkaRada != null) zOld.DatumPocetkaRada = (DateTime)zaposleniBasic.DatumPocetkaRada;

                if (!String.IsNullOrEmpty(zaposleniBasic.Zanimanje)) zOld.Zanimanje = zaposleniBasic.Zanimanje;
                if (!String.IsNullOrEmpty(zaposleniBasic.Pozicija)) zOld.Pozicija = zaposleniBasic.Pozicija;
                if (!String.IsNullOrEmpty(zaposleniBasic.StrucnaSprema)) zOld.StrucnaSprema = zaposleniBasic.StrucnaSprema;

                if (!String.IsNullOrEmpty(zaposleniBasic.LPLekar)) zOld.LPLekar = zaposleniBasic.LPLekar;
                if (zaposleniBasic.LPDatum != null) zOld.LPDatum = zaposleniBasic.LPDatum;
                if (!String.IsNullOrEmpty(zaposleniBasic.LPNazivUstanove)) zOld.LPNazivUstanove = zaposleniBasic.LPNazivUstanove;
                if (!String.IsNullOrEmpty(zaposleniBasic.LPAdresaUstanove)) zOld.LPAdresaUstanove = zaposleniBasic.LPAdresaUstanove;

                if (!String.IsNullOrEmpty(zaposleniBasic.SSpecijalizacija)) zOld.SSpecijalizacija = zaposleniBasic.SSpecijalizacija;
                if (!String.IsNullOrEmpty(zaposleniBasic.SNazivUstanove)) zOld.SNazivUstanove = zaposleniBasic.SNazivUstanove;

                if (!String.IsNullOrEmpty(zaposleniBasic.DORVOSifra)) zOld.DORVOSifra = zaposleniBasic.DORVOSifra;
                if (!String.IsNullOrEmpty(zaposleniBasic.DORVOPolicijskaUprava)) zOld.DORVOPolicijskaUprava = zaposleniBasic.DORVOPolicijskaUprava;
                if (zaposleniBasic.DORVODatumIzdavanja != null) zOld.DORVODatumIzdavanja = zaposleniBasic.DORVODatumIzdavanja;

                s.SaveOrUpdate(zOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        public static void DeleteZaposleni(string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Zaposleni z = s.Query<Zaposleni>()
                    .Where(zap => zap.JMBG == JMBG)
                    .FirstOrDefault();
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        #endregion

        #region Administracija
        public static void CreateAdministracija(AdministracijaBasic administracijaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Administracija aNew = new Administracija();

                aNew.JMBG = administracijaBasic.JMBG;
                aNew.Ime = administracijaBasic.Ime;
                aNew.Prezime = administracijaBasic.Prezime;
                aNew.Pol = administracijaBasic.Pol;

                aNew.RadnoMesto = "Administracija";
                if (administracijaBasic.DatumObukePPZ != null) aNew.DatumObukePPZ = (DateTime)administracijaBasic.DatumObukePPZ;
                if (administracijaBasic.DatumPocetkaRada != null) aNew.DatumPocetkaRada = (DateTime)administracijaBasic.DatumPocetkaRada;

                aNew.RadiU = s.Query<ZatvorskaJedinica>().Where(zj => zj.Sifra == administracijaBasic.RadiU.Sifra).FirstOrDefault();
                if (administracijaBasic.DatumPocetkaRada != null) aNew.DatumPocetkaRada = (DateTime)administracijaBasic.DatumPocetkaRada;

                aNew.Zanimanje = administracijaBasic.Zanimanje;
                aNew.Pozicija = administracijaBasic.Pozicija;
                aNew.StrucnaSprema = administracijaBasic.StrucnaSprema;

                s.Save(aNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        public static List<AdministracijaBasic> ReadAllAdministracija()
        {
            List<AdministracijaBasic> ret = new List<AdministracijaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<Administracija> list = s.Query<Administracija>().ToList();

                AdministracijaBasic retSingle;

                list.ForEach(a =>
                {
                    retSingle = new AdministracijaBasic();

                    retSingle.JMBG = a.JMBG;
                    retSingle.Ime = a.Ime;
                    retSingle.Prezime = a.Prezime;
                    retSingle.Pol = a.Pol;

                    retSingle.RadnoMesto = a.RadnoMesto;
                    retSingle.DatumObukePPZ = a.DatumObukePPZ;
                    retSingle.RadiU = ReadZatvorskaJedinica(a.RadiU.Sifra);
                    retSingle.DatumPocetkaRada = a.DatumPocetkaRada;

                    retSingle.Zanimanje = a.Zanimanje;
                    retSingle.Pozicija = a.Pozicija;
                    retSingle.StrucnaSprema = a.StrucnaSprema;

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static AdministracijaBasic ReadAdministracija(string JMBG)
        {
            AdministracijaBasic ret = new AdministracijaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Administracija a = s.Query<Administracija>()
                    .Where(admin => admin.JMBG == JMBG)
                    .FirstOrDefault();

                ret.JMBG = a.JMBG;
                ret.Ime = a.Ime;
                ret.Prezime = a.Prezime;
                ret.Pol = a.Pol;

                ret.RadnoMesto = a.RadnoMesto;
                ret.DatumObukePPZ = a.DatumObukePPZ;
                ret.RadiU = ReadZatvorskaJedinica(a.RadiU.Sifra);
                ret.DatumPocetkaRada = a.DatumPocetkaRada;

                ret.Zanimanje = a.Zanimanje;
                ret.Pozicija = a.Pozicija;
                ret.StrucnaSprema = a.StrucnaSprema;

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static AdministracijaBasic ReadAdministracijaUpravnik(string JMBG)
        {
            AdministracijaBasic ret = new AdministracijaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Administracija a = s.Query<Administracija>()
                    .Where(admin => admin.JMBG == JMBG)
                    .FirstOrDefault();

                ret.JMBG = a.JMBG;
                ret.Ime = a.Ime;
                ret.Prezime = a.Prezime;
                ret.Pol = a.Pol;

                ret.RadnoMesto = a.RadnoMesto;
                ret.DatumObukePPZ = a.DatumObukePPZ;
                // ret.RadiU = ReadZatvorskaJedinica(a.RadiU.Sifra);
                ret.DatumPocetkaRada = a.DatumPocetkaRada;

                ret.Zanimanje = a.Zanimanje;
                ret.Pozicija = a.Pozicija;
                ret.StrucnaSprema = a.StrucnaSprema;

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static void UpdateAdministracija(AdministracijaBasic administracijaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Administracija aOld = s.Query<Administracija>()
                    .Where(admin => admin.JMBG == administracijaBasic.JMBG)
                    .FirstOrDefault();

                if (!String.IsNullOrEmpty(administracijaBasic.Ime)) aOld.Ime = administracijaBasic.Ime;
                if (!String.IsNullOrEmpty(administracijaBasic.Prezime)) aOld.Prezime = administracijaBasic.Prezime;
                if (!String.IsNullOrEmpty(administracijaBasic.Pol)) aOld.Pol = administracijaBasic.Pol;

                if (!String.IsNullOrEmpty(administracijaBasic.RadnoMesto)) aOld.RadnoMesto = administracijaBasic.RadnoMesto;
                if (administracijaBasic.DatumObukePPZ != null) aOld.DatumObukePPZ = (DateTime)administracijaBasic.DatumObukePPZ;
                if (administracijaBasic.DatumPocetkaRada != null) aOld.DatumPocetkaRada = (DateTime)administracijaBasic.DatumPocetkaRada;

                if (!String.IsNullOrEmpty(administracijaBasic.Zanimanje)) aOld.Zanimanje = administracijaBasic.Zanimanje;
                if (!String.IsNullOrEmpty(administracijaBasic.Pozicija)) aOld.Pozicija = administracijaBasic.Pozicija;
                if (!String.IsNullOrEmpty(administracijaBasic.StrucnaSprema)) aOld.StrucnaSprema = administracijaBasic.StrucnaSprema;

                s.SaveOrUpdate(aOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        public static void DeleteAdministracija(string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Administracija a = s.Query<Administracija>()
                    .Where(admin => admin.JMBG == JMBG)
                    .FirstOrDefault();
                s.Delete(a);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        #endregion

        #region Psiholog
        public static void CreatePsiholog(PsihologBasic psihologBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Psiholog pNew = new Psiholog();

                pNew.JMBG = psihologBasic.JMBG;
                pNew.Ime = psihologBasic.Ime;
                pNew.Prezime = psihologBasic.Prezime;
                pNew.Pol = psihologBasic.Pol;

                pNew.RadnoMesto = "Psiholog";
                if (psihologBasic.DatumObukePPZ != null) pNew.DatumObukePPZ = (DateTime)psihologBasic.DatumObukePPZ;
                if (psihologBasic.DatumPocetkaRada != null) pNew.DatumPocetkaRada = (DateTime)psihologBasic.DatumPocetkaRada;

                pNew.RadiU = s.Query<ZatvorskaJedinica>().Where(zj => zj.Sifra == psihologBasic.RadiU.Sifra).FirstOrDefault();


                pNew.LPLekar = psihologBasic.LPLekar;
                pNew.LPDatum = psihologBasic.LPDatum;
                pNew.LPNazivUstanove = psihologBasic.LPNazivUstanove;
                pNew.LPAdresaUstanove = psihologBasic.LPAdresaUstanove;

                pNew.SSpecijalizacija = psihologBasic.SSpecijalizacija;
                pNew.SNazivUstanove = psihologBasic.SNazivUstanove;

                s.Save(pNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        public static List<PsihologBasic> ReadAllPsiholog()
        {
            List<PsihologBasic> ret = new List<PsihologBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<Psiholog> list = s.Query<Psiholog>().ToList();

                PsihologBasic retSingle;

                list.ForEach(z =>
                {
                    retSingle = new PsihologBasic();

                    retSingle.JMBG = z.JMBG;
                    retSingle.Ime = z.Ime;
                    retSingle.Prezime = z.Prezime;
                    retSingle.Pol = z.Pol;

                    retSingle.RadnoMesto = z.RadnoMesto;
                    retSingle.DatumObukePPZ = z.DatumObukePPZ;
                    retSingle.RadiU = ReadZatvorskaJedinica(z.RadiU.Sifra);
                    retSingle.DatumPocetkaRada = z.DatumPocetkaRada;

                    retSingle.LPLekar = z.LPLekar;
                    retSingle.LPDatum = z.LPDatum;
                    retSingle.LPNazivUstanove = z.LPNazivUstanove;
                    retSingle.LPAdresaUstanove = z.LPAdresaUstanove;

                    retSingle.SSpecijalizacija = z.SSpecijalizacija;
                    retSingle.SNazivUstanove = z.SNazivUstanove;

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static PsihologBasic ReadPsiholog(string JMBG)
        {
            PsihologBasic ret = new PsihologBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Psiholog z = s.Query<Psiholog>()
                    .Where(psih => psih.JMBG == JMBG)
                    .FirstOrDefault();

                ret.JMBG = z.JMBG;
                ret.Ime = z.Ime;
                ret.Prezime = z.Prezime;
                ret.Pol = z.Pol;

                ret.RadnoMesto = z.RadnoMesto;
                ret.DatumObukePPZ = z.DatumObukePPZ;
                ret.RadiU = ReadZatvorskaJedinica(z.RadiU.Sifra);
                ret.DatumPocetkaRada = z.DatumPocetkaRada;

                ret.LPLekar = z.LPLekar;
                ret.LPDatum = z.LPDatum;
                ret.LPNazivUstanove = z.LPNazivUstanove;
                ret.LPAdresaUstanove = z.LPAdresaUstanove;

                ret.SSpecijalizacija = z.SSpecijalizacija;
                ret.SNazivUstanove = z.SNazivUstanove;

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static void UpdatePsiholog(PsihologBasic psihologBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Psiholog pOld = s.Query<Psiholog>()
                    .Where(psih => psih.JMBG == psihologBasic.JMBG)
                    .FirstOrDefault();

                if (!String.IsNullOrEmpty(psihologBasic.Ime)) pOld.Ime = psihologBasic.Ime;
                if (!String.IsNullOrEmpty(psihologBasic.Prezime)) pOld.Prezime = psihologBasic.Prezime;
                if (!String.IsNullOrEmpty(psihologBasic.Pol)) pOld.Pol = psihologBasic.Pol;

                if (!String.IsNullOrEmpty(psihologBasic.RadnoMesto)) pOld.RadnoMesto = psihologBasic.RadnoMesto;
                if (psihologBasic.DatumObukePPZ != null) pOld.DatumObukePPZ = (DateTime)psihologBasic.DatumObukePPZ;
                if (psihologBasic.DatumPocetkaRada != null) pOld.DatumPocetkaRada = (DateTime)psihologBasic.DatumPocetkaRada;


                if (!String.IsNullOrEmpty(psihologBasic.LPLekar)) pOld.LPLekar = psihologBasic.LPLekar;
                if (psihologBasic.LPDatum != null) pOld.LPDatum = psihologBasic.LPDatum;
                if (!String.IsNullOrEmpty(psihologBasic.LPNazivUstanove)) pOld.LPNazivUstanove = psihologBasic.LPNazivUstanove;
                if (!String.IsNullOrEmpty(psihologBasic.LPAdresaUstanove)) pOld.LPAdresaUstanove = psihologBasic.LPAdresaUstanove;

                if (!String.IsNullOrEmpty(psihologBasic.SSpecijalizacija)) pOld.SSpecijalizacija = psihologBasic.SSpecijalizacija;
                if (!String.IsNullOrEmpty(psihologBasic.SNazivUstanove)) pOld.SNazivUstanove = psihologBasic.SNazivUstanove;

                s.SaveOrUpdate(pOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        public static void DeletePsiholog(string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Psiholog p = s.Query<Psiholog>()
                    .Where(psih => psih.JMBG == JMBG)
                    .FirstOrDefault();
                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        #endregion

        #region Obezbeđenje
        public static void CreateRadnikObezbedjenja(RadnikObezbedjenjaBasic obezbedjenjeBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadnikObezbedjenja roNew = new RadnikObezbedjenja();

                roNew.JMBG = obezbedjenjeBasic.JMBG;
                roNew.Ime = obezbedjenjeBasic.Ime;
                roNew.Prezime = obezbedjenjeBasic.Prezime;
                roNew.Pol = obezbedjenjeBasic.Pol;

                roNew.RadnoMesto = "Radnik obezbeđenja";
                if (obezbedjenjeBasic.DatumObukePPZ != null) roNew.DatumObukePPZ = (DateTime)obezbedjenjeBasic.DatumObukePPZ;
                if (obezbedjenjeBasic.DatumPocetkaRada != null) roNew.DatumPocetkaRada = (DateTime)obezbedjenjeBasic.DatumPocetkaRada;

                roNew.RadiU = s.Query<ZatvorskaJedinica>().Where(zj => zj.Sifra == obezbedjenjeBasic.RadiU.Sifra).FirstOrDefault();

                roNew.LPLekar = obezbedjenjeBasic.LPLekar;
                roNew.LPDatum = obezbedjenjeBasic.LPDatum;
                roNew.LPNazivUstanove = obezbedjenjeBasic.LPNazivUstanove;
                roNew.LPAdresaUstanove = obezbedjenjeBasic.LPAdresaUstanove;

                roNew.DORVOSifra = obezbedjenjeBasic.DORVOSifra;
                roNew.DORVOPolicijskaUprava = obezbedjenjeBasic.DORVOPolicijskaUprava;
                roNew.DORVODatumIzdavanja = obezbedjenjeBasic.DORVODatumIzdavanja;

                s.Save(roNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        public static List<RadnikObezbedjenjaBasic> ReadAllRadnikObezbedjenja()
        {
            List<RadnikObezbedjenjaBasic> ret = new List<RadnikObezbedjenjaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<RadnikObezbedjenja> list = s.Query<RadnikObezbedjenja>().ToList();

                RadnikObezbedjenjaBasic retSingle;

                list.ForEach(z =>
                {
                    retSingle = new RadnikObezbedjenjaBasic();

                    retSingle.JMBG = z.JMBG;
                    retSingle.Ime = z.Ime;
                    retSingle.Prezime = z.Prezime;
                    retSingle.Pol = z.Pol;

                    retSingle.RadnoMesto = z.RadnoMesto;
                    retSingle.DatumObukePPZ = z.DatumObukePPZ;
                    retSingle.RadiU = ReadZatvorskaJedinica(z.RadiU.Sifra);
                    retSingle.DatumPocetkaRada = z.DatumPocetkaRada;

                    retSingle.LPLekar = z.LPLekar;
                    retSingle.LPDatum = z.LPDatum;
                    retSingle.LPNazivUstanove = z.LPNazivUstanove;
                    retSingle.LPAdresaUstanove = z.LPAdresaUstanove;

                    retSingle.DORVOSifra = z.DORVOSifra;
                    retSingle.DORVOPolicijskaUprava = z.DORVOPolicijskaUprava;
                    retSingle.DORVODatumIzdavanja = z.DORVODatumIzdavanja;

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static RadnikObezbedjenjaBasic ReadRadnikObezbedjenja(string JMBG)
        {
            RadnikObezbedjenjaBasic ret = new RadnikObezbedjenjaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                RadnikObezbedjenja z = s.Query<RadnikObezbedjenja>()
                    .Where(radnikO => radnikO.JMBG == JMBG)
                    .FirstOrDefault();

                ret.JMBG = z.JMBG;
                ret.Ime = z.Ime;
                ret.Prezime = z.Prezime;
                ret.Pol = z.Pol;

                ret.RadnoMesto = z.RadnoMesto;
                ret.DatumObukePPZ = z.DatumObukePPZ;
                ret.RadiU = ReadZatvorskaJedinica(z.RadiU.Sifra);
                ret.DatumPocetkaRada = z.DatumPocetkaRada;

                ret.LPLekar = z.LPLekar;
                ret.LPDatum = z.LPDatum;
                ret.LPNazivUstanove = z.LPNazivUstanove;
                ret.LPAdresaUstanove = z.LPAdresaUstanove;

                ret.DORVOSifra = z.DORVOSifra;
                ret.DORVOPolicijskaUprava = z.DORVOPolicijskaUprava;
                ret.DORVODatumIzdavanja = z.DORVODatumIzdavanja;

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static void UpdateRadnikObezbedjenja(RadnikObezbedjenjaBasic obezbedjenjeBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadnikObezbedjenja roOld = s.Query<RadnikObezbedjenja>()
                    .Where(radnikO => radnikO.JMBG == obezbedjenjeBasic.JMBG)
                    .FirstOrDefault();

                if (!String.IsNullOrEmpty(obezbedjenjeBasic.Ime)) roOld.Ime = obezbedjenjeBasic.Ime;
                if (!String.IsNullOrEmpty(obezbedjenjeBasic.Prezime)) roOld.Prezime = obezbedjenjeBasic.Prezime;
                if (!String.IsNullOrEmpty(obezbedjenjeBasic.Pol)) roOld.Pol = obezbedjenjeBasic.Pol;

                if (!String.IsNullOrEmpty(obezbedjenjeBasic.RadnoMesto)) roOld.RadnoMesto = obezbedjenjeBasic.RadnoMesto;
                if (obezbedjenjeBasic.DatumObukePPZ != null) roOld.DatumObukePPZ = (DateTime)obezbedjenjeBasic.DatumObukePPZ;
                if (obezbedjenjeBasic.DatumPocetkaRada != null) roOld.DatumPocetkaRada = (DateTime)obezbedjenjeBasic.DatumPocetkaRada;

                if (!String.IsNullOrEmpty(obezbedjenjeBasic.LPLekar)) roOld.LPLekar = obezbedjenjeBasic.LPLekar;
                if (obezbedjenjeBasic.LPDatum != null) roOld.LPDatum = obezbedjenjeBasic.LPDatum;
                if (!String.IsNullOrEmpty(obezbedjenjeBasic.LPNazivUstanove)) roOld.LPNazivUstanove = obezbedjenjeBasic.LPNazivUstanove;
                if (!String.IsNullOrEmpty(obezbedjenjeBasic.LPAdresaUstanove)) roOld.LPAdresaUstanove = obezbedjenjeBasic.LPAdresaUstanove;

                if (!String.IsNullOrEmpty(obezbedjenjeBasic.DORVOSifra)) roOld.DORVOSifra = obezbedjenjeBasic.DORVOSifra;
                if (!String.IsNullOrEmpty(obezbedjenjeBasic.DORVOPolicijskaUprava)) roOld.DORVOPolicijskaUprava = obezbedjenjeBasic.DORVOPolicijskaUprava;
                if (obezbedjenjeBasic.DORVODatumIzdavanja != null) roOld.DORVODatumIzdavanja = obezbedjenjeBasic.DORVODatumIzdavanja;

                s.SaveOrUpdate(roOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        public static void DeleteRadnikObezbedjenja(string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                RadnikObezbedjenja rO = s.Query<RadnikObezbedjenja>()
                    .Where(r => r.JMBG == JMBG)
                    .FirstOrDefault();

                s.Delete(rO);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        #endregion

        #endregion

        #region Zatvorenik
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
                if (z.DatumInkarceracije != null) zat.DatumInkarceracije = (DateTime)z.DatumInkarceracije;
                zat.DatumSledecegSaslusanja = z.DatumSledecegSaslusanja;

                zat.ZatvorskaJedinica = s
                        .Query<ZatvorskaJedinica>()
                        .Where(zj => zj.Sifra == z.ZatvorskaJedinica.Sifra)
                        .FirstOrDefault();

                foreach (PrestupBasic p in z.Prestupi)
                {
                    Prestup prest = new Prestup();

                    prest.PunNaziv = p.PunNaziv;
                    prest.Kategorija = p.Kategorija;

                    if (p.DatumPrestupa != null) prest.DatumPrestupa = (DateTime)p.DatumPrestupa;
                    prest.MestoPrestupa = p.MestoPrestupa;

                    if (p.MaxKazna != null) prest.MaxKazna = (int)p.MaxKazna;
                    if (p.MinKazna != null) prest.MinKazna = (int)p.MinKazna;

                    prest.Opis = p.Opis;
                    prest.Zatvorenik = zat;

                    zat.Prestupi.Add(prest);
                }

                foreach (ZastupaBasic zast in z.Zastupa)
                {
                    Zastupa zastupa = new Zastupa();

                    zastupa.Advokat = s
                        .Query<Advokat>()
                        .Where(a => a.JMBG == zast.Advokat.JMBG)
                        .FirstOrDefault();

                    zastupa.Zatvorenik = zat;

                    if (zast.DatumPocetkaSaradnje != null) zastupa.DatumPocetkaSaradnje = (DateTime)zast.DatumPocetkaSaradnje;
                    zastupa.DatumPoslednjegKontakta = zast.DatumPoslednjegKontakta;

                    zat.Zastupa.Add(zastupa);
                }

                foreach (PosecujeBasic p in z.Posete)
                {
                    Posecuje pos = new Posecuje();

                    if (p.DTPocetka != null) pos.DTPocetka = (DateTime)p.DTPocetka;
                    if (p.DTKraja != null) pos.DTKraja = (DateTime)p.DTKraja;
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
                Console.Write(e.StackTrace);
            }
            return ret;
        }
        public static List<ZatvorenikBasic> ReadAllZatvorenik()
        {
            List<ZatvorenikBasic> ret = new List<ZatvorenikBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<Zatvorenik> lista = s.Query<Zatvorenik>().ToList();

                ZatvorenikBasic retSingle;
                lista.ForEach(zat =>
                {
                    retSingle = new ZatvorenikBasic();

                    retSingle.JMBG = zat.JMBG;
                    retSingle.JMBG = zat.JMBG;
                    retSingle.Ime = zat.Ime;
                    retSingle.Prezime = zat.Prezime;
                    retSingle.Pol = zat.Pol;

                    retSingle.Broj = zat.Broj;
                    retSingle.Adresa = zat.Adresa;
                    retSingle.StatusUslovnogOtpusta = zat.StatusUslovnogOtpusta;
                    retSingle.DatumInkarceracije = zat.DatumInkarceracije;
                    retSingle.DatumSledecegSaslusanja = zat.DatumSledecegSaslusanja;

                    retSingle.ZatvorskaJedinica = ReadZatvorskaJedinica(zat.ZatvorskaJedinica.Sifra);
                    retSingle.Prestupi = ReadAllPrestupFor(retSingle);
                    retSingle.Zastupa = ReadAllZastupaFor(retSingle);
                    retSingle.Posete = ReadAllPosecujeFor(retSingle);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<ZatvorenikBasic> ReadAllZatvorenikFor(ZatvorskaJedinicaBasic zatvorskaJedinicaBasic)
        {
            List<ZatvorenikBasic> ret = new List<ZatvorenikBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<Zatvorenik> lista = s
                    .Query<Zatvorenik>()
                    .Where(z => z.ZatvorskaJedinica.Sifra == zatvorskaJedinicaBasic.Sifra)
                    .ToList();

                ZatvorenikBasic retSingle;
                lista.ForEach(z =>
                {
                    retSingle = new ZatvorenikBasic();

                    retSingle.JMBG = z.JMBG;
                    retSingle.Ime = z.Ime;
                    retSingle.Prezime = z.Prezime;
                    retSingle.Pol = z.Pol;
                    retSingle.Adresa = z.Adresa;

                    retSingle.Broj = z.Broj;
                    retSingle.DatumInkarceracije = z.DatumInkarceracije;
                    retSingle.DatumSledecegSaslusanja = z.DatumSledecegSaslusanja;
                    retSingle.StatusUslovnogOtpusta = z.StatusUslovnogOtpusta;

                    retSingle.ZatvorskaJedinica = zatvorskaJedinicaBasic;

                    retSingle.Prestupi = ReadAllPrestupFor(retSingle);
                    retSingle.Zastupa = ReadAllZastupaFor(retSingle);
                    retSingle.Posete = ReadAllPosecujeFor(retSingle);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static ZatvorenikBasic ReadZatvorenik(string JMBG)
        {
            ZatvorenikBasic ret = new ZatvorenikBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                Zatvorenik zat = s.Query<Zatvorenik>().Where(zatvorenik => zatvorenik.JMBG == JMBG).FirstOrDefault();

                ret.JMBG = zat.JMBG;
                ret.Ime = zat.Ime;
                ret.Prezime = zat.Prezime;
                ret.Pol = zat.Pol;
                ret.Adresa = zat.Adresa;

                ret.Broj = zat.Broj;
                ret.DatumInkarceracije = zat.DatumInkarceracije;
                ret.DatumSledecegSaslusanja = zat.DatumSledecegSaslusanja;
                ret.StatusUslovnogOtpusta = zat.StatusUslovnogOtpusta;

                ret.ZatvorskaJedinica = ReadZatvorskaJedinica(zat.ZatvorskaJedinica.Sifra);

                ret.Prestupi = ReadAllPrestupFor(ret);
                ret.Zastupa = ReadAllZastupaFor(ret);
                ret.Posete = ReadAllPosecujeFor(ret);

                s.Close();

            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static void UpdateZatvorenik(ZatvorenikBasic z)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zatvorenik zOld = s.Query<Zatvorenik>().Where(zat => zat.JMBG == z.JMBG).FirstOrDefault();

                if (!String.IsNullOrEmpty(z.Ime)) zOld.Ime = z.Ime;
                if (!String.IsNullOrEmpty(z.Prezime)) zOld.Prezime = z.Prezime;
                if (!String.IsNullOrEmpty(z.Pol)) zOld.Pol = z.Pol;
                if (!String.IsNullOrEmpty(z.Adresa)) zOld.Adresa = z.Adresa;

                if (!String.IsNullOrEmpty(z.Broj)) zOld.Broj = z.Broj;
                if (z.DatumInkarceracije != null) zOld.DatumInkarceracije = (DateTime)z.DatumInkarceracije;
                if (z.DatumSledecegSaslusanja != null) zOld.DatumSledecegSaslusanja = z.DatumSledecegSaslusanja;
                if (!String.IsNullOrEmpty(z.StatusUslovnogOtpusta)) zOld.StatusUslovnogOtpusta = z.StatusUslovnogOtpusta;

                if (zOld.ZatvorskaJedinica.Sifra != z.ZatvorskaJedinica?.Sifra)
                    zOld.ZatvorskaJedinica = s.Query<ZatvorskaJedinica>()
                        .Where(zat => zat.Sifra == z.ZatvorskaJedinica.Sifra)
                        .FirstOrDefault();

                s.SaveOrUpdate(zOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static void DeleteZatvorenik(string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zatvorenik zOld = s.Query<Zatvorenik>().Where(zat => zat.JMBG == JMBG).FirstOrDefault();

                s.Delete(zOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        #endregion

        #region Advokat
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

                s.Save(a);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static List<AdvokatBasic> ReadAllAdvokat()
        {
            List<AdvokatBasic> ret = new List<AdvokatBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<Advokat> lista = s.Query<Advokat>().ToList();

                AdvokatBasic retSingle;
                lista.ForEach(a =>
                {
                    retSingle = new AdvokatBasic();

                    retSingle.JMBG = a.JMBG;
                    retSingle.Ime = a.Ime;
                    retSingle.Prezime = a.Prezime;
                    retSingle.Pol = a.Pol;
                    retSingle.Posecuje = ReadAllPosecujeFor(retSingle);
                    retSingle.Zastupa = ReadAllZastupaFor(retSingle);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static AdvokatBasic ReadAdvokat(string JMBG)
        {
            AdvokatBasic ret = new AdvokatBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Advokat a = s.Query<Advokat>().Where(adv => adv.JMBG == JMBG).FirstOrDefault();

                ret.JMBG = a.JMBG;
                ret.Ime = a.Ime;
                ret.Prezime = a.Prezime;
                ret.Pol = a.Pol;

                ret.Posecuje = ReadAllPosecujeFor(ret);
                ret.Zastupa = ReadAllZastupaFor(ret);

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static void UpdateAdvokat(AdvokatBasic a)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Advokat aOld = s.Query<Advokat>().Where(adv => adv.JMBG == a.JMBG).FirstOrDefault();

                if (!String.IsNullOrEmpty(a.Ime)) aOld.Ime = a.Ime;
                if (!String.IsNullOrEmpty(a.Prezime)) aOld.Prezime = a.Prezime;
                if (!String.IsNullOrEmpty(a.Pol)) aOld.Pol = a.Pol;

                s.Update(aOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static void DeleteAdvokat(string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Advokat aOld = s.Query<Advokat>().Where(adv => adv.JMBG == JMBG).FirstOrDefault();

                s.Delete(aOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        #endregion

        #region Zastupa
        public static void CreateZastupa(ZastupaBasic z)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zastupa zNew = new Zastupa();

                if (z.DatumPocetkaSaradnje != null) zNew.DatumPocetkaSaradnje = (DateTime)z.DatumPocetkaSaradnje;
                zNew.DatumPoslednjegKontakta = z.DatumPoslednjegKontakta;
                zNew.Zatvorenik = s.Query<Zatvorenik>().Where(zat => zat.JMBG == z.Zatvorenik.JMBG).FirstOrDefault();
                zNew.Advokat = s.Query<Advokat>().Where(zat => zat.JMBG == z.Advokat.JMBG).FirstOrDefault();

                s.Save(zNew);
                s.Flush();

                z.ID = zNew.ID;

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static List<ZastupaBasic> ReadAllZastupa()
        {
            List<ZastupaBasic> ret = new List<ZastupaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<Zastupa> lista = s
                    .Query<Zastupa>()
                    .ToList();

                ZastupaBasic retSingle;

                lista.ForEach(z =>
                {
                    retSingle = new ZastupaBasic();

                    retSingle.ID = z.ID;
                    retSingle.DatumPocetkaSaradnje = z.DatumPocetkaSaradnje;
                    retSingle.DatumPoslednjegKontakta = z.DatumPoslednjegKontakta;
                    retSingle.Advokat = ReadAdvokat(z.Advokat.JMBG);
                    retSingle.Zatvorenik = ReadZatvorenik(z.Zatvorenik.JMBG);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<ZastupaBasic> ReadAllZastupaFor(ZatvorenikBasic zatvorenikBasic)
        {
            List<ZastupaBasic> ret = new List<ZastupaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();
                List<Zastupa> lista = s
                    .Query<Zastupa>()
                    .Where(z => z.Zatvorenik.JMBG == zatvorenikBasic.JMBG)
                    .ToList();

                ZastupaBasic retSingle;
                lista.ForEach(z =>
                {
                    retSingle = new ZastupaBasic();

                    retSingle.ID = z.ID;
                    retSingle.DatumPocetkaSaradnje = z.DatumPocetkaSaradnje;
                    retSingle.DatumPoslednjegKontakta = z.DatumPoslednjegKontakta;
                    retSingle.Zatvorenik = zatvorenikBasic;
                    retSingle.Advokat = ReadAdvokat(z.Advokat.JMBG);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<ZastupaBasic> ReadAllZastupaFor(AdvokatBasic advokatBasic)
        {
            List<ZastupaBasic> ret = new List<ZastupaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();
                List<Zastupa> lista = s
                    .Query<Zastupa>()
                    .Where(z => z.Advokat.JMBG == advokatBasic.JMBG)
                    .ToList();

                ZastupaBasic retSingle;
                lista.ForEach(z =>
                {
                    retSingle = new ZastupaBasic();

                    retSingle.ID = z.ID;
                    retSingle.DatumPocetkaSaradnje = z.DatumPocetkaSaradnje;
                    retSingle.DatumPoslednjegKontakta = z.DatumPoslednjegKontakta;
                    //retSingle.Zatvorenik = ReadZatvorenik(z.Zatvorenik.JMBG);
                    retSingle.Advokat = advokatBasic;

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static ZastupaBasic ReadZastupa(int ID)
        {
            ZastupaBasic ret = new ZastupaBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Zastupa zastupa = s.Query<Zastupa>().Where(z => z.ID == ID).FirstOrDefault();

                ret.ID = zastupa.ID;
                ret.DatumPocetkaSaradnje = zastupa.DatumPocetkaSaradnje;
                ret.DatumPoslednjegKontakta = zastupa.DatumPoslednjegKontakta;
                ret.Advokat = ReadAdvokat(zastupa.Advokat.JMBG);
                ret.Zatvorenik = ReadZatvorenik(zastupa.Zatvorenik.JMBG);

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static void UpdateZastupa(ZastupaBasic zastupaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zastupa z = s.Query<Zastupa>().Where(zast => zast.ID == zastupaBasic.ID).FirstOrDefault();

                if (zastupaBasic.DatumPocetkaSaradnje != null) z.DatumPocetkaSaradnje = (DateTime)zastupaBasic.DatumPocetkaSaradnje;
                if (zastupaBasic.DatumPoslednjegKontakta != null) z.DatumPoslednjegKontakta = zastupaBasic.DatumPoslednjegKontakta;

                s.SaveOrUpdate(z);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static void DeleteZastupa(int ID)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zastupa zastupa = s.Query<Zastupa>().Where(zast => zast.ID == ID).FirstOrDefault();

                s.Delete(zastupa);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        #endregion

        #region Posecuje
        public static void CreatePoseta(PosecujeBasic poseta)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Posecuje pNew = new Posecuje();

                if (poseta.DTPocetka != null) pNew.DTPocetka = (DateTime)poseta.DTPocetka;
                if (poseta.DTKraja != null) pNew.DTKraja = (DateTime)poseta.DTKraja;
                pNew.Advokat = s.Query<Advokat>().Where(a => a.JMBG == poseta.Advokat.JMBG).FirstOrDefault();
                pNew.Zatvorenik = s.Query<Zatvorenik>().Where(z => z.JMBG == poseta.Zatvorenik.JMBG).FirstOrDefault();

                s.Save(pNew);
                s.Flush();

                poseta.ID = pNew.ID;

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static PosecujeBasic ReadPosecuje(int ID)
        {
            PosecujeBasic ret = new PosecujeBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Posecuje poseta = s.Query<Posecuje>().Where(z => z.ID == ID).FirstOrDefault();

                ret.ID = poseta.ID;
                ret.DTPocetka = poseta.DTPocetka;
                ret.DTKraja = poseta.DTKraja;
                ret.Advokat = new AdvokatBasic(poseta.Advokat.JMBG, poseta.Advokat.Ime, poseta.Advokat.Prezime, poseta.Advokat.Pol);
                ret.Zatvorenik = ReadZatvorenik(poseta.Zatvorenik.JMBG);

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static List<PosecujeBasic> ReadAllPosecuje()
        {
            List<PosecujeBasic> ret = new List<PosecujeBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<Posecuje> lista = s.Query<Posecuje>().ToList();

                PosecujeBasic retSingle;
                lista.ForEach(poseta =>
                {
                    retSingle = new PosecujeBasic();
                    retSingle.ID = poseta.ID;
                    retSingle.DTPocetka = poseta.DTPocetka;
                    retSingle.DTKraja = poseta.DTKraja;
                    retSingle.Advokat = new AdvokatBasic(poseta.Advokat.JMBG, poseta.Advokat.Ime, poseta.Advokat.Prezime, poseta.Advokat.Pol);
                    retSingle.Zatvorenik = ReadZatvorenik(poseta.Zatvorenik.JMBG);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static List<PosecujeBasic> ReadAllPosecujeFor(ZatvorenikBasic zatvorenikBasic)
        {
            List<PosecujeBasic> ret = new List<PosecujeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<Posecuje> lista = s
                    .Query<Posecuje>()
                    .Where(p => p.Zatvorenik.JMBG == zatvorenikBasic.JMBG)
                    .ToList();

                PosecujeBasic retSingle;
                lista.ForEach(p =>
                {
                    retSingle = new PosecujeBasic();

                    retSingle.ID = p.ID;
                    retSingle.DTPocetka = p.DTPocetka;
                    retSingle.DTKraja = p.DTKraja;
                    retSingle.Zatvorenik = zatvorenikBasic;
                    retSingle.Advokat = ReadAdvokat(p.Advokat.JMBG);

                    ret.Add(retSingle);
                });
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static List<PosecujeBasic> ReadAllPosecujeFor(AdvokatBasic advokatBasic)
        {
            List<PosecujeBasic> ret = new List<PosecujeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<Posecuje> lista = s
                    .Query<Posecuje>()
                    .Where(p => p.Advokat.JMBG == advokatBasic.JMBG)
                    .ToList();

                PosecujeBasic retSingle;
                lista.ForEach(p =>
                {
                    retSingle = new PosecujeBasic();

                    retSingle.ID = p.ID;
                    retSingle.DTPocetka = p.DTPocetka;
                    retSingle.DTKraja = p.DTKraja;
                    // retSingle.Zatvorenik = ReadZatvorenik(p.Zatvorenik.JMBG);
                    retSingle.Advokat = advokatBasic;

                    ret.Add(retSingle);
                });
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
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

                if (poseta.DTPocetka != null) pNew.DTPocetka = (DateTime)poseta.DTPocetka;
                if (poseta.DTKraja != null) pNew.DTKraja = (DateTime)poseta.DTKraja;

                s.SaveOrUpdate(pNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static void DeletePoseta(int ID)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Posecuje pNew = s
                    .Query<Posecuje>()
                    .Where(p => p.ID == ID)
                    .FirstOrDefault();

                s.Delete(pNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        #endregion

        #region Prestup
        public static void CreatePrestup(PrestupBasic prestupBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prestup pNew = new Prestup();

                pNew.PunNaziv = prestupBasic.PunNaziv;
                pNew.Kategorija = prestupBasic.Kategorija;
                if (prestupBasic.MinKazna != null) pNew.MinKazna = (int)prestupBasic.MinKazna;
                if (prestupBasic.MaxKazna != null) pNew.MaxKazna = (int)prestupBasic.MaxKazna;

                pNew.MestoPrestupa = prestupBasic.MestoPrestupa;
                if (prestupBasic.DatumPrestupa != null) pNew.DatumPrestupa = (DateTime)prestupBasic.DatumPrestupa;
                pNew.Opis = prestupBasic.Opis;

                pNew.Zatvorenik = s.Query<Zatvorenik>().Where(z => z.JMBG == prestupBasic.Zatvorenik.JMBG).FirstOrDefault();

                s.Save(pNew);
                s.Flush();

                prestupBasic.ID = pNew.ID;

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static PrestupBasic ReadPrestup(int ID)
        {
            PrestupBasic ret = new PrestupBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Prestup p = s.Query<Prestup>().Where(prest => prest.ID == ID).FirstOrDefault();

                ret.ID = p.ID;
                ret.PunNaziv = p.PunNaziv;
                ret.Kategorija = p.Kategorija;
                ret.MinKazna = p.MinKazna;
                ret.MaxKazna = p.MaxKazna;

                ret.MestoPrestupa = p.MestoPrestupa;
                ret.DatumPrestupa = p.DatumPrestupa;
                ret.Opis = p.Opis;

                ret.Zatvorenik = ReadZatvorenik(p.Zatvorenik.JMBG);

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
            return ret;
        }
        public static List<PrestupBasic> ReadAllPrestup()
        {
            List<PrestupBasic> ret = new List<PrestupBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                List<Prestup> lista = s.Query<Prestup>().ToList();

                PrestupBasic retSingle;

                lista.ForEach(p =>
                {
                    retSingle = new PrestupBasic();

                    retSingle.ID = p.ID;
                    retSingle.PunNaziv = p.PunNaziv;
                    retSingle.Kategorija = p.Kategorija;
                    retSingle.MinKazna = p.MinKazna;
                    retSingle.MaxKazna = p.MaxKazna;

                    retSingle.MestoPrestupa = p.MestoPrestupa;
                    retSingle.DatumPrestupa = p.DatumPrestupa;
                    retSingle.Opis = p.Opis;

                    retSingle.Zatvorenik = ReadZatvorenik(p.Zatvorenik.JMBG);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
            return ret;
        }
        public static List<PrestupBasic> ReadAllPrestupFor(ZatvorenikBasic zatvorenikBasic)
        {
            List<PrestupBasic> ret = new List<PrestupBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                List<Prestup> lista = s
                    .Query<Prestup>()
                    .Where(p => p.Zatvorenik.JMBG == zatvorenikBasic.JMBG)
                    .ToList();

                PrestupBasic retSingle;
                lista.ForEach(p =>
                {
                    retSingle = new PrestupBasic();

                    retSingle.ID = p.ID;
                    retSingle.PunNaziv = p.PunNaziv;
                    retSingle.Kategorija = p.Kategorija;
                    retSingle.Opis = p.Opis;
                    retSingle.MinKazna = p.MinKazna;
                    retSingle.MaxKazna = p.MaxKazna;
                    retSingle.MestoPrestupa = p.MestoPrestupa;
                    retSingle.DatumPrestupa = p.DatumPrestupa;
                    retSingle.Zatvorenik = zatvorenikBasic;

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return ret;
        }
        public static void UpdatePrestup(PrestupBasic prestupBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prestup pNew = s.Query<Prestup>()
                    .Where(p => p.ID == prestupBasic.ID)
                    .FirstOrDefault();

                if (!String.IsNullOrEmpty(prestupBasic.PunNaziv)) pNew.PunNaziv = prestupBasic.PunNaziv;
                if (!String.IsNullOrEmpty(prestupBasic.Kategorija)) pNew.Kategorija = prestupBasic.Kategorija;
                if (prestupBasic.MinKazna != null) pNew.MinKazna = (int)prestupBasic.MinKazna;
                if (prestupBasic.MaxKazna != null) pNew.MaxKazna = (int)prestupBasic.MaxKazna;

                if (!String.IsNullOrEmpty(prestupBasic.MestoPrestupa)) pNew.MestoPrestupa = prestupBasic.MestoPrestupa;
                if (prestupBasic.DatumPrestupa != null) pNew.DatumPrestupa = (DateTime)prestupBasic.DatumPrestupa;
                if (!String.IsNullOrEmpty(prestupBasic.Opis)) pNew.Opis = prestupBasic.Opis;

                s.SaveOrUpdate(pNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        public static void DeletePrestup(int ID)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prestup pNew = s
                    .Query<Prestup>()
                    .Where(p => p.ID == ID)
                    .FirstOrDefault();

                s.Delete(pNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }
        #endregion

        #region Firma
        public static void CreateFirma(FirmaBasic firmaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Firma fNew = new Firma();

                fNew.PIB = firmaBasic.PIB;
                fNew.Naziv = firmaBasic.Naziv;
                fNew.KontaktTelefon = firmaBasic.KontaktTelefon;
                fNew.Adresa = firmaBasic.Adresa;

                s.Save(fNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        public static void CreateMozeDaAngazuje(string Sifra, string PIB)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Firma f = s.Query<Firma>().Where(firm => firm.PIB == PIB).SingleOrDefault();

                f.ZatvorskeJedinice.Add(s.Load<ZatvorskaJedinica>(Sifra));

                s.SaveOrUpdate(f);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        public static List<FirmaBasic> ReadAllFirma()
        {
            List<FirmaBasic> ret = new List<FirmaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<Firma> list = s.Query<Firma>().ToList();

                FirmaBasic retSingle;

                list.ForEach(p =>
                {
                    retSingle = new FirmaBasic();

                    retSingle.PIB = p.PIB;
                    retSingle.Naziv = p.Naziv;
                    retSingle.Adresa = p.Adresa;
                    retSingle.KontaktTelefon = p.KontaktTelefon;
                    retSingle.OdgovornaLica = ReadAllOdgovornoLiceFor(retSingle);
                    retSingle.ZatvorskeJedinice = ReadAllZatvorskaJedinicaFor(retSingle);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static FirmaBasic ReadFirma(string PIB)
        {
            FirmaBasic ret = new FirmaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Firma p = s.Query<Firma>()
                    .Where(tp => tp.PIB == PIB)
                    .FirstOrDefault();

                ret.PIB = p.PIB;
                ret.Naziv = p.Naziv;
                ret.Adresa = p.Adresa;
                ret.KontaktTelefon = p.KontaktTelefon;
                ret.OdgovornaLica = ReadAllOdgovornoLiceFor(ret);
                ret.ZatvorskeJedinice = ReadAllZatvorskaJedinicaFor(ret);

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static List<FirmaBasic> ReadAllFirmaFor(ZatvorskaJedinicaBasic zatvorskaJedinicaBasic)
        {
            List<FirmaBasic> ret = new List<FirmaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IList<Firma> list = s.QueryOver<Firma>()
                                    .Inner.JoinQueryOver<ZatvorskaJedinica>(x => x.ZatvorskeJedinice)
                                    .Where(x => x.Sifra == zatvorskaJedinicaBasic.Sifra)
                                    .List();

                FirmaBasic retSingle;

                foreach (Firma p in list)
                {
                    retSingle = new FirmaBasic();

                    retSingle.PIB = p.PIB;
                    retSingle.Naziv = p.Naziv;
                    retSingle.Adresa = p.Adresa;
                    retSingle.KontaktTelefon = p.KontaktTelefon;
                    retSingle.OdgovornaLica = ReadAllOdgovornoLiceFor(retSingle);
                    //retSingle.ZatvorskeJedinice = ReadAllZatvorskaJedinicaFor(retSingle);

                    ret.Add(retSingle);
                }

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static List<FirmaBasic> ReadAllFirmaNotFor(ZatvorskaJedinicaBasic zatvorskaJedinicaBasic)
        {
            List<FirmaBasic> ret = new List<FirmaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IList<Firma> list = s.QueryOver<Firma>().List();
                IList<Firma> list2 = s.QueryOver<Firma>()
                                    .Inner.JoinQueryOver<ZatvorskaJedinica>(x => x.ZatvorskeJedinice)
                                    .Where(x => x.Sifra == zatvorskaJedinicaBasic.Sifra)
                                    .List();


                FirmaBasic retSingle;

                foreach (Firma p in list)
                {
                    if (!list2.Contains(p))
                    {
                        retSingle = new FirmaBasic();

                        retSingle.PIB = p.PIB;
                        retSingle.Naziv = p.Naziv;
                        retSingle.Adresa = p.Adresa;
                        retSingle.KontaktTelefon = p.KontaktTelefon;
                        retSingle.OdgovornaLica = ReadAllOdgovornoLiceFor(retSingle);
                        // retSingle.ZatvorskeJedinice = ReadAllZatvorskaJedinicaFor(retSingle);

                        ret.Add(retSingle);
                    }
                }

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static void UpdateFirma(FirmaBasic firmaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Firma f = s.Query<Firma>()
                    .Where(tp => tp.PIB == firmaBasic.PIB)
                    .FirstOrDefault();

                if (!String.IsNullOrEmpty(firmaBasic.Naziv)) f.Naziv = firmaBasic.Naziv;
                if (!String.IsNullOrEmpty(firmaBasic.Adresa)) f.Adresa = firmaBasic.Adresa;
                if (!String.IsNullOrEmpty(firmaBasic.KontaktTelefon)) f.KontaktTelefon = firmaBasic.KontaktTelefon;

                s.SaveOrUpdate(f);

                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        public static void DeleteFirma(string PIB)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Firma p = s.Query<Firma>()
                    .Where(tp => tp.PIB == PIB)
                    .FirstOrDefault();

                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        public static void DeleteMozeDaAngazuje(string Sifra, string PIB)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Firma f = s.QueryOver<Firma>()
                    .Where(firm => firm.PIB == PIB)
                    .SingleOrDefault();

                f.ZatvorskeJedinice.Remove(f.ZatvorskeJedinice
                    .Where(z => z.Sifra == Sifra)
                    .SingleOrDefault());

                s.Save(f);
                s.Flush();

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        #endregion

        #region Odgovorno Lice
        public static void CreateOdgovornoLice(OdgovornoLiceBasic odgovornoLiceBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                OdgovornoLice olNew = new OdgovornoLice();

                olNew.Ime = odgovornoLiceBasic.Ime;
                olNew.Prezime = odgovornoLiceBasic.Prezime;
                olNew.JMBG = odgovornoLiceBasic.JMBG;
                olNew.Firma = s.Query<Firma>().Where(f => f.PIB == odgovornoLiceBasic.Firma.PIB).FirstOrDefault();

                s.Save(olNew);
                s.Flush();

                odgovornoLiceBasic.ID = olNew.ID;

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        public static List<OdgovornoLiceBasic> ReadAllOdgovornoLice()
        {
            List<OdgovornoLiceBasic> ret = new List<OdgovornoLiceBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<OdgovornoLice> list = s.Query<OdgovornoLice>().ToList();

                OdgovornoLiceBasic retSingle;

                list.ForEach(p =>
                {
                    retSingle = new OdgovornoLiceBasic();

                    retSingle.ID = p.ID;
                    retSingle.JMBG = p.JMBG;
                    retSingle.Ime = p.Ime;
                    retSingle.Prezime = p.Prezime;
                    retSingle.Firma = ReadFirma(p.Firma.PIB);

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static List<OdgovornoLiceBasic> ReadAllOdgovornoLiceFor(FirmaBasic firmaBasic)
        {
            List<OdgovornoLiceBasic> ret = new List<OdgovornoLiceBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<OdgovornoLice> list = s.Query<OdgovornoLice>()
                    .Where(ol => ol.Firma.PIB == firmaBasic.PIB)
                    .ToList();

                OdgovornoLiceBasic retSingle;

                list.ForEach(p =>
                {
                    retSingle = new OdgovornoLiceBasic();

                    retSingle.ID = p.ID;
                    retSingle.JMBG = p.JMBG;
                    retSingle.Ime = p.Ime;
                    retSingle.Prezime = p.Prezime;
                    retSingle.Firma = firmaBasic;

                    ret.Add(retSingle);
                });

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static OdgovornoLiceBasic ReadOdgovornoLice(int ID)
        {
            OdgovornoLiceBasic ret = new OdgovornoLiceBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                OdgovornoLice p = s.Query<OdgovornoLice>()
                    .Where(tp => tp.ID == ID)
                    .FirstOrDefault();

                ret.ID = p.ID;
                ret.JMBG = p.JMBG;
                ret.Ime = p.Ime;
                ret.Prezime = p.Prezime;
                ret.Firma = ReadFirma(p.Firma.PIB);

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static OdgovornoLiceBasic ReadOdgovornoLice(string JMBG)
        {
            OdgovornoLiceBasic ret = new OdgovornoLiceBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                OdgovornoLice p = s.Query<OdgovornoLice>()
                    .Where(tp => tp.JMBG == JMBG)
                    .FirstOrDefault();

                ret.ID = p.ID;
                ret.JMBG = p.JMBG;
                ret.Ime = p.Ime;
                ret.Prezime = p.Prezime;
                ret.Firma = ReadFirma(p.Firma.PIB);

                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }

            return ret;
        }
        public static void UpdateOdgovornoLice(OdgovornoLiceBasic odgovornoLiceBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                OdgovornoLice olOld = s.Query<OdgovornoLice>()
                    .Where(tp => tp.ID == odgovornoLiceBasic.ID)
                    .FirstOrDefault();

                if (!String.IsNullOrEmpty(odgovornoLiceBasic.JMBG)) olOld.JMBG = odgovornoLiceBasic.JMBG;
                if (!String.IsNullOrEmpty(odgovornoLiceBasic.Ime)) olOld.Ime = odgovornoLiceBasic.Ime;
                if (!String.IsNullOrEmpty(odgovornoLiceBasic.Prezime)) olOld.Prezime = odgovornoLiceBasic.Prezime;

                s.SaveOrUpdate(olOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        public static void DeleteOdgovornoLice(int ID)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                OdgovornoLice p = s.Query<OdgovornoLice>()
                    .Where(tp => tp.ID == ID)
                    .FirstOrDefault();
                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { Console.Write(e.StackTrace); }
        }
        #endregion
    }
}
