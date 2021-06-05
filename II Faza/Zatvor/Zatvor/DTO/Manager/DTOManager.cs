using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
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
        #region Zatvorska Jedinica

        #region Zatvorska Jedinica General
        public static void CreateZatvorskaJedinica(ZatvorskaJedinicaBasic zatvorskaJedinicaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZatvorskaJedinica zNew = new ZatvorskaJedinica();

                zNew.Sifra = zatvorskaJedinicaBasic.Sifra;
                zNew.Kapacitet = zatvorskaJedinicaBasic.Kapacitet;
                zNew.Naziv = zatvorskaJedinicaBasic.Naziv;
                zNew.Adresa = zatvorskaJedinicaBasic.Adresa;

                zNew.ORezim = zatvorskaJedinicaBasic.ORezim;
                zNew.SRezim = zatvorskaJedinicaBasic.SRezim;
                zNew.PORezim = zatvorskaJedinicaBasic.PORezim;

                s.Save(zNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
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
                MessageBox.Show(e.StackTrace);
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
                MessageBox.Show(e.StackTrace);
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
                MessageBox.Show(e.StackTrace);
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
                MessageBox.Show(e.StackTrace);
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
            { MessageBox.Show(e.StackTrace); }

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

                zjOld.Kapacitet = zj.Kapacitet;
                zjOld.Naziv = zj.Naziv;
                zjOld.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    zjOld.Upravnik = s.Query<Administracija>()
                    .Where(a => a.JMBG == zj.Upravnik.JMBG)
                    .FirstOrDefault();
                }

                zjOld.ORezim = zj.ORezim;
                zjOld.SRezim = zj.SRezim;
                zjOld.PORezim = zj.PORezim;

                s.SaveOrUpdate(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        public static void DeleteZatvorskaJedinica(ZatvorskaJedinicaBasic zj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZatvorskaJedinica zjOld = s
                    .Query<ZatvorskaJedinica>()
                    .Where(z => z.Sifra == zj.Sifra)
                    .FirstOrDefault();

                s.Delete(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        #endregion

        #region Zatvorska Jedinica Otvoren Režim
        public static void CreateZJOtvorenogTipa(ZatvorskaJedinicaBasic zatvorskaJedinicaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZJOtvorenogTipa zNew = new ZJOtvorenogTipa();

                zNew.Sifra = zatvorskaJedinicaBasic.Sifra;
                zNew.Kapacitet = zatvorskaJedinicaBasic.Kapacitet;
                zNew.Naziv = zatvorskaJedinicaBasic.Naziv;
                zNew.Adresa = zatvorskaJedinicaBasic.Adresa;

                zNew.ORezim = zatvorskaJedinicaBasic.ORezim;
                zNew.SRezim = zatvorskaJedinicaBasic.SRezim;
                zNew.PORezim = zatvorskaJedinicaBasic.PORezim;

                s.Save(zNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        public static void UpdateZJOtvorenogTipa(ZatvorskaJedinicaBasic zj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJOtvorenogTipa zjOld = s
                    .Query<ZJOtvorenogTipa>()
                    .Where(z => z.Sifra == zj.Sifra)
                    .FirstOrDefault();

                zjOld.Kapacitet = zj.Kapacitet;
                zjOld.Naziv = zj.Naziv;
                zjOld.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    zjOld.Upravnik = s.Query<Administracija>()
                    .Where(a => a.JMBG == zj.Upravnik.JMBG)
                    .FirstOrDefault();
                }

                zjOld.ORezim = zj.ORezim;
                zjOld.SRezim = zj.SRezim;
                zjOld.PORezim = zj.PORezim;

                s.SaveOrUpdate(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        #endregion

        #region Zatvorska Jedinica Poluotvoren Režim
        public static void CreateZJPoluotvorenogTipa(ZatvorskaJedinicaBasic zatvorskaJedinicaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZJPoluotvorenogTipa zNew = new ZJPoluotvorenogTipa();

                zNew.Sifra = zatvorskaJedinicaBasic.Sifra;
                zNew.Kapacitet = zatvorskaJedinicaBasic.Kapacitet;
                zNew.Naziv = zatvorskaJedinicaBasic.Naziv;
                zNew.Adresa = zatvorskaJedinicaBasic.Adresa;

                zNew.ORezim = zatvorskaJedinicaBasic.ORezim;
                zNew.SRezim = zatvorskaJedinicaBasic.SRezim;
                zNew.PORezim = zatvorskaJedinicaBasic.PORezim;

                s.Save(zNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        public static void UpdateZJPoluotvorenogTipa(ZatvorskaJedinicaBasic zj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJPoluotvorenogTipa zjOld = s
                    .Query<ZJPoluotvorenogTipa>()
                    .Where(z => z.Sifra == zj.Sifra)
                    .FirstOrDefault();

                zjOld.Kapacitet = zj.Kapacitet;
                zjOld.Naziv = zj.Naziv;
                zjOld.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    zjOld.Upravnik = s.Query<Administracija>()
                    .Where(a => a.JMBG == zj.Upravnik.JMBG)
                    .FirstOrDefault();
                }

                zjOld.ORezim = zj.ORezim;
                zjOld.SRezim = zj.SRezim;
                zjOld.PORezim = zj.PORezim;

                s.SaveOrUpdate(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        #endregion

        #region Zatvorska Jedinica Strogi Režim
        public static void CreateZJStrogogTipa(ZatvorskaJedinicaBasic zatvorskaJedinicaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZJStrogogTipa zNew = new ZJStrogogTipa();

                zNew.Sifra = zatvorskaJedinicaBasic.Sifra;
                zNew.Kapacitet = zatvorskaJedinicaBasic.Kapacitet;
                zNew.Naziv = zatvorskaJedinicaBasic.Naziv;
                zNew.Adresa = zatvorskaJedinicaBasic.Adresa;

                zNew.ORezim = zatvorskaJedinicaBasic.ORezim;
                zNew.SRezim = zatvorskaJedinicaBasic.SRezim;
                zNew.PORezim = zatvorskaJedinicaBasic.PORezim;

                s.Save(zNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        public static void UpdateZJStrogogTipa(ZatvorskaJedinicaBasic zj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJStrogogTipa zjOld = s
                    .Query<ZJStrogogTipa>()
                    .Where(z => z.Sifra == zj.Sifra)
                    .FirstOrDefault();

                zjOld.Kapacitet = zj.Kapacitet;
                zjOld.Naziv = zj.Naziv;
                zjOld.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    zjOld.Upravnik = s.Query<Administracija>()
                    .Where(a => a.JMBG == zj.Upravnik.JMBG)
                    .FirstOrDefault();
                }

                zjOld.ORezim = zj.ORezim;
                zjOld.SRezim = zj.SRezim;
                zjOld.PORezim = zj.PORezim;

                s.SaveOrUpdate(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
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

                zNew.Sifra = zatvorskaJedinicaBasic.Sifra;
                zNew.Kapacitet = zatvorskaJedinicaBasic.Kapacitet;
                zNew.Naziv = zatvorskaJedinicaBasic.Naziv;
                zNew.Adresa = zatvorskaJedinicaBasic.Adresa;

                zNew.ORezim = zatvorskaJedinicaBasic.ORezim;
                zNew.SRezim = zatvorskaJedinicaBasic.SRezim;
                zNew.PORezim = zatvorskaJedinicaBasic.PORezim;

                s.Save(zNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        public static void UpdateZJOtvorenoStrogogTipa(ZatvorskaJedinicaBasic zj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJOtvorenoStrogogTipa zjOld = s
                    .Query<ZJOtvorenoStrogogTipa>()
                    .Where(z => z.Sifra == zj.Sifra)
                    .FirstOrDefault();

                zjOld.Kapacitet = zj.Kapacitet;
                zjOld.Naziv = zj.Naziv;
                zjOld.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    zjOld.Upravnik = s.Query<Administracija>()
                    .Where(a => a.JMBG == zj.Upravnik.JMBG)
                    .FirstOrDefault();
                }

                zjOld.ORezim = zj.ORezim;
                zjOld.SRezim = zj.SRezim;
                zjOld.PORezim = zj.PORezim;

                s.SaveOrUpdate(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        #endregion

        #region Zatvorska Jedinica Otvoren Poluotvoren Režim
        public static void CreateZJOtvorenoPoluotvorenogTipa(ZatvorskaJedinicaBasic zatvorskaJedinicaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZJOtvorenoPoluotvorenogTipa zNew = new ZJOtvorenoPoluotvorenogTipa();

                zNew.Sifra = zatvorskaJedinicaBasic.Sifra;
                zNew.Kapacitet = zatvorskaJedinicaBasic.Kapacitet;
                zNew.Naziv = zatvorskaJedinicaBasic.Naziv;
                zNew.Adresa = zatvorskaJedinicaBasic.Adresa;

                zNew.ORezim = zatvorskaJedinicaBasic.ORezim;
                zNew.SRezim = zatvorskaJedinicaBasic.SRezim;
                zNew.PORezim = zatvorskaJedinicaBasic.PORezim;

                s.Save(zNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        public static void UpdateZJOtvorenoPoluotvorenogTipa(ZatvorskaJedinicaBasic zj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJOtvorenoPoluotvorenogTipa zjOld = s
                    .Query<ZJOtvorenoPoluotvorenogTipa>()
                    .Where(z => z.Sifra == zj.Sifra)
                    .FirstOrDefault();

                zjOld.Kapacitet = zj.Kapacitet;
                zjOld.Naziv = zj.Naziv;
                zjOld.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    zjOld.Upravnik = s.Query<Administracija>()
                    .Where(a => a.JMBG == zj.Upravnik.JMBG)
                    .FirstOrDefault();
                }

                zjOld.ORezim = zj.ORezim;
                zjOld.SRezim = zj.SRezim;
                zjOld.PORezim = zj.PORezim;

                s.SaveOrUpdate(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        #endregion

        #region Zatvorska Jedinica Poluotvoren Strogi Režim
        public static void CreateZJPoluotvorenoStrogogTipa(ZatvorskaJedinicaBasic zatvorskaJedinicaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZJPoluotvorenoStrogogTipa zNew = new ZJPoluotvorenoStrogogTipa();

                zNew.Sifra = zatvorskaJedinicaBasic.Sifra;
                zNew.Kapacitet = zatvorskaJedinicaBasic.Kapacitet;
                zNew.Naziv = zatvorskaJedinicaBasic.Naziv;
                zNew.Adresa = zatvorskaJedinicaBasic.Adresa;

                zNew.ORezim = zatvorskaJedinicaBasic.ORezim;
                zNew.SRezim = zatvorskaJedinicaBasic.SRezim;
                zNew.PORezim = zatvorskaJedinicaBasic.PORezim;

                s.Save(zNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        public static void UpdateZJPoluotvorenoStrogogTipa(ZatvorskaJedinicaBasic zj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJPoluotvorenoStrogogTipa zjOld = s
                    .Query<ZJPoluotvorenoStrogogTipa>()
                    .Where(z => z.Sifra == zj.Sifra)
                    .FirstOrDefault();

                zjOld.Kapacitet = zj.Kapacitet;
                zjOld.Naziv = zj.Naziv;
                zjOld.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    zjOld.Upravnik = s.Query<Administracija>()
                    .Where(a => a.JMBG == zj.Upravnik.JMBG)
                    .FirstOrDefault();
                }

                zjOld.ORezim = zj.ORezim;
                zjOld.SRezim = zj.SRezim;
                zjOld.PORezim = zj.PORezim;

                s.SaveOrUpdate(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        #endregion

        #region Zatvorska Jedinica Svi Režimi
        public static void CreateZJSvakiTip(ZatvorskaJedinicaBasic zatvorskaJedinicaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZJSvakiTip zNew = new ZJSvakiTip();

                zNew.Sifra = zatvorskaJedinicaBasic.Sifra;
                zNew.Kapacitet = zatvorskaJedinicaBasic.Kapacitet;
                zNew.Naziv = zatvorskaJedinicaBasic.Naziv;
                zNew.Adresa = zatvorskaJedinicaBasic.Adresa;

                zNew.ORezim = zatvorskaJedinicaBasic.ORezim;
                zNew.SRezim = zatvorskaJedinicaBasic.SRezim;
                zNew.PORezim = zatvorskaJedinicaBasic.PORezim;

                s.Save(zNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        public static void UpdateZJSvakiTip(ZatvorskaJedinicaBasic zj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZJSvakiTip zjOld = s
                    .Query<ZJSvakiTip>()
                    .Where(z => z.Sifra == zj.Sifra)
                    .FirstOrDefault();

                zjOld.Kapacitet = zj.Kapacitet;
                zjOld.Naziv = zj.Naziv;
                zjOld.Adresa = zj.Adresa;

                if (zj.Upravnik != null)
                {
                    zjOld.Upravnik = s.Query<Administracija>()
                    .Where(a => a.JMBG == zj.Upravnik.JMBG)
                    .FirstOrDefault();
                }

                zjOld.ORezim = zj.ORezim;
                zjOld.SRezim = zj.SRezim;
                zjOld.PORezim = zj.PORezim;

                s.SaveOrUpdate(zjOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
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
            { MessageBox.Show(e.StackTrace); }
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
            { MessageBox.Show(e.StackTrace); }

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
            { MessageBox.Show(e.StackTrace); }

            return ret;
        }
        public static List<TerminPoseteBasic> ReadAllTerminPoseteFor(ZatvorskaJedinicaBasic zatvoskaJedinicaBasic)
        {
            List<TerminPoseteBasic> ret = new List<TerminPoseteBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<TerminPosete> list = s.Query<TerminPosete>()
                    .Where(tp=>tp.ZatvorskaJedinica.Sifra == zatvoskaJedinicaBasic.Sifra)
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
            { MessageBox.Show(e.StackTrace); }

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

                p.Dan = terminPoseteBasic.Dan;
                p.Period = terminPoseteBasic.Period;

                s.SaveOrUpdate(p);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
        }
        public static void DeleteTerminPosete(TerminPoseteBasic terminPoseteBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                TerminPosete p = s.Query<TerminPosete>()
                    .Where(tp => tp.ID == terminPoseteBasic.ID)
                    .FirstOrDefault();
                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
        }
        #endregion

        #region Termin Šetnje
        public static void CreateTerminSetnje(TerminSetnjeBasic terminSetnjeBasic)
        {
            try {
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
            { MessageBox.Show(e.StackTrace); }
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
            { MessageBox.Show(e.StackTrace); }

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
            { MessageBox.Show(e.StackTrace); }

            return ret;
        }
        public static List<TerminSetnjeBasic> ReadAllTerminSetnjeFor(ZatvorskaJedinicaBasic zatvorskaJedinicaBasic)
        {
            List<TerminSetnjeBasic> ret = new List<TerminSetnjeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                List<TerminSetnje> lista = s.Query<TerminSetnje>()
                    .Where(ts=>ts.ZatvorskaJedinica.Sifra==zatvorskaJedinicaBasic.Sifra)
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
            { MessageBox.Show(e.StackTrace); }

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

                ts.Termin = terminSetnjeBasic.Termin;

                s.SaveOrUpdate(ts);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
        }
        public static void DeleteTerminSetnje(TerminSetnjeBasic terminSetnjeBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                TerminSetnje ts = s.Query<TerminSetnje>()
                    .Where(termin => termin.ID == terminSetnjeBasic.ID)
                    .FirstOrDefault();

                s.Delete(ts);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
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
            { MessageBox.Show(e.StackTrace); }
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
            { MessageBox.Show(e.StackTrace); }

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
            { MessageBox.Show(e.StackTrace); }

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
            { MessageBox.Show(e.StackTrace); }

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

                cp.Period = celijskiPeriodBasic.Period;

                s.SaveOrUpdate(cp);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
        }
        public static void DeleteCelijskiPeriod(CelijskiPeriodBasic celijskiPeriodBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                CelijskiPeriod cp = s.Query<CelijskiPeriod>()
                    .Where(termin => termin.ID == celijskiPeriodBasic.ID)
                    .FirstOrDefault();

                s.Delete(cp);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
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
                zNew.DatumObukePPZ = zaposleniBasic.DatumObukePPZ;
                zNew.RadiU = s.Query<ZatvorskaJedinica>().Where(zj => zj.Sifra == zaposleniBasic.RadiU.Sifra).FirstOrDefault();
                zNew.DatumPocetkaRada = zaposleniBasic.DatumPocetkaRada;

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
            { MessageBox.Show(e.StackTrace); }
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
            { MessageBox.Show(e.StackTrace); }

            return ret;
        }
        public static List<ZaposleniBasic> ReadAllZaposleniFor(ZatvorskaJedinicaBasic zatvorskaJedinicaBasic)
        {
            List<ZaposleniBasic> ret = new List<ZaposleniBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<Zaposleni> list = s.Query<Zaposleni>()
                    .Where(z=>z.RadiU.Sifra==zatvorskaJedinicaBasic.Sifra)
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
            { MessageBox.Show(e.StackTrace); }

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
            { MessageBox.Show(e.StackTrace); }

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

                zOld.Ime = zaposleniBasic.Ime;
                zOld.Prezime = zaposleniBasic.Prezime;
                zOld.Pol = zaposleniBasic.Pol;

                zOld.RadnoMesto = zaposleniBasic.RadnoMesto;
                zOld.DatumObukePPZ = zaposleniBasic.DatumObukePPZ;
                zOld.DatumPocetkaRada = zaposleniBasic.DatumPocetkaRada;

                zOld.Zanimanje = zaposleniBasic.Zanimanje;
                zOld.Pozicija = zaposleniBasic.Pozicija;
                zOld.StrucnaSprema = zaposleniBasic.StrucnaSprema;

                zOld.LPLekar = zaposleniBasic.LPLekar;
                zOld.LPDatum = zaposleniBasic.LPDatum;
                zOld.LPNazivUstanove = zaposleniBasic.LPNazivUstanove;
                zOld.LPAdresaUstanove = zaposleniBasic.LPAdresaUstanove;

                zOld.SSpecijalizacija = zaposleniBasic.SSpecijalizacija;
                zOld.SNazivUstanove = zaposleniBasic.SNazivUstanove;

                zOld.DORVOSifra = zaposleniBasic.DORVOSifra;
                zOld.DORVOPolicijskaUprava = zaposleniBasic.DORVOPolicijskaUprava;
                zOld.DORVODatumIzdavanja = zaposleniBasic.DORVODatumIzdavanja;

                s.SaveOrUpdate(zOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
        }
        public static void DeleteZaposleni(ZaposleniBasic zaposleniBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Zaposleni z = s.Query<Zaposleni>()
                    .Where(zap => zap.JMBG == zaposleniBasic.JMBG)
                    .FirstOrDefault();
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
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
                aNew.DatumObukePPZ = administracijaBasic.DatumObukePPZ;
                aNew.RadiU = s.Query<ZatvorskaJedinica>().Where(zj => zj.Sifra == administracijaBasic.RadiU.Sifra).FirstOrDefault();
                aNew.DatumPocetkaRada = administracijaBasic.DatumPocetkaRada;

                aNew.Zanimanje = administracijaBasic.Zanimanje;
                aNew.Pozicija = administracijaBasic.Pozicija;
                aNew.StrucnaSprema = administracijaBasic.StrucnaSprema;

                s.Save(aNew);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
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
            { MessageBox.Show(e.StackTrace); }

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
            { MessageBox.Show(e.StackTrace); }

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
            { MessageBox.Show(e.StackTrace); }

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

                aOld.Ime = administracijaBasic.Ime;
                aOld.Prezime = administracijaBasic.Prezime;
                aOld.Pol = administracijaBasic.Pol;

                aOld.RadnoMesto = administracijaBasic.RadnoMesto;
                aOld.DatumObukePPZ = administracijaBasic.DatumObukePPZ;
                aOld.DatumPocetkaRada = administracijaBasic.DatumPocetkaRada;

                aOld.Zanimanje = administracijaBasic.Zanimanje;
                aOld.Pozicija = administracijaBasic.Pozicija;
                aOld.StrucnaSprema = administracijaBasic.StrucnaSprema;

                s.SaveOrUpdate(aOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
        }
        public static void DeleteAdministracija(AdministracijaBasic administracijaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Administracija a = s.Query<Administracija>()
                    .Where(admin => admin.JMBG == administracijaBasic.JMBG)
                    .FirstOrDefault();
                s.Delete(a);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
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
                pNew.DatumObukePPZ = psihologBasic.DatumObukePPZ;
                pNew.RadiU = s.Query<ZatvorskaJedinica>().Where(zj => zj.Sifra == psihologBasic.RadiU.Sifra).FirstOrDefault();
                pNew.DatumPocetkaRada = psihologBasic.DatumPocetkaRada;

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
            { MessageBox.Show(e.StackTrace); }
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
            { MessageBox.Show(e.StackTrace); }

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
            { MessageBox.Show(e.StackTrace); }

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

                pOld.Ime = psihologBasic.Ime;
                pOld.Prezime = psihologBasic.Prezime;
                pOld.Pol = psihologBasic.Pol;

                pOld.RadnoMesto = psihologBasic.RadnoMesto;
                pOld.DatumObukePPZ = psihologBasic.DatumObukePPZ;
                pOld.DatumPocetkaRada = psihologBasic.DatumPocetkaRada;

                pOld.LPLekar = psihologBasic.LPLekar;
                pOld.LPDatum = psihologBasic.LPDatum;
                pOld.LPNazivUstanove = psihologBasic.LPNazivUstanove;
                pOld.LPAdresaUstanove = psihologBasic.LPAdresaUstanove;

                pOld.SSpecijalizacija = psihologBasic.SSpecijalizacija;
                pOld.SNazivUstanove = psihologBasic.SNazivUstanove;

                s.SaveOrUpdate(pOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
        }
        public static void DeletePsiholog(PsihologBasic psihologBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Psiholog p = s.Query<Psiholog>()
                    .Where(psih => psih.JMBG == psihologBasic.JMBG)
                    .FirstOrDefault();
                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
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
                roNew.DatumObukePPZ = obezbedjenjeBasic.DatumObukePPZ;
                roNew.RadiU = s.Query<ZatvorskaJedinica>().Where(zj => zj.Sifra == obezbedjenjeBasic.RadiU.Sifra).FirstOrDefault();
                roNew.DatumPocetkaRada = obezbedjenjeBasic.DatumPocetkaRada;

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
            { MessageBox.Show(e.StackTrace); }
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
            { MessageBox.Show(e.StackTrace); }

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
            { MessageBox.Show(e.StackTrace); }

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

                roOld.Ime = obezbedjenjeBasic.Ime;
                roOld.Prezime = obezbedjenjeBasic.Prezime;
                roOld.Pol = obezbedjenjeBasic.Pol;

                roOld.RadnoMesto = obezbedjenjeBasic.RadnoMesto;
                roOld.DatumObukePPZ = obezbedjenjeBasic.DatumObukePPZ;
                roOld.DatumPocetkaRada = obezbedjenjeBasic.DatumPocetkaRada;

                roOld.LPLekar = obezbedjenjeBasic.LPLekar;
                roOld.LPDatum = obezbedjenjeBasic.LPDatum;
                roOld.LPNazivUstanove = obezbedjenjeBasic.LPNazivUstanove;
                roOld.LPAdresaUstanove = obezbedjenjeBasic.LPAdresaUstanove;

                roOld.DORVOSifra = obezbedjenjeBasic.DORVOSifra;
                roOld.DORVOPolicijskaUprava = obezbedjenjeBasic.DORVOPolicijskaUprava;
                roOld.DORVODatumIzdavanja = obezbedjenjeBasic.DORVODatumIzdavanja;

                s.SaveOrUpdate(roOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
        }
        public static void DeleteRadnikObezbedjenja(RadnikObezbedjenjaBasic obezbedjenjeBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                RadnikObezbedjenja rO = s.Query<RadnikObezbedjenja>()
                    .Where(r => r.JMBG == obezbedjenjeBasic.JMBG)
                    .FirstOrDefault();

                s.Delete(rO);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
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
                zat.DatumInkarceracije = z.DatumInkarceracije;
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
                        .Where(a => a.JMBG == zast.Advokat.JMBG)
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
                MessageBox.Show(e.StackTrace);
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
                    .Where(z=>z.ZatvorskaJedinica.Sifra==zatvorskaJedinicaBasic.Sifra)
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
                MessageBox.Show(e.StackTrace);
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
                    zOld.ZatvorskaJedinica = s.Query<ZatvorskaJedinica>()
                        .Where(zat => zat.Sifra == z.ZatvorskaJedinica.Sifra)
                        .FirstOrDefault();

                s.SaveOrUpdate(zOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        public static void DeleteZatvorenik(ZatvorenikBasic z)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zatvorenik zOld = s.Query<Zatvorenik>().Where(zat => zat.JMBG == z.JMBG).FirstOrDefault();

                s.Delete(zOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
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
                MessageBox.Show(e.StackTrace);
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
                MessageBox.Show(e.StackTrace);
            }

            return ret;
        }
        public static AdvokatBasic ReadAdvokat(string JMBG)
        {
            AdvokatBasic ret = new AdvokatBasic();

            try {
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
        public static void CreateZastupa(ZastupaBasic z)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zastupa zNew = new Zastupa();

                zNew.DatumPocetkaSaradnje = z.DatumPocetkaSaradnje;
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
                MessageBox.Show(e.StackTrace);
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
                MessageBox.Show(e.StackTrace);
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
                    .Where(z=>z.Zatvorenik.JMBG == zatvorenikBasic.JMBG)
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
                MessageBox.Show(e.StackTrace);
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
                MessageBox.Show(e.StackTrace);
            }

            return ret;
        }
        public static ZastupaBasic ReadZastupa(int ID)
        {
            ZastupaBasic ret = new ZastupaBasic();

            try {
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
            { MessageBox.Show(e.StackTrace); }

            return ret;
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
                s.Flush();

                poseta.ID = pNew.ID;

                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
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
            { MessageBox.Show(e.StackTrace); }

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
            { MessageBox.Show(e.StackTrace); }

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
                MessageBox.Show(e.StackTrace);
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
                MessageBox.Show(e.StackTrace);
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
                pNew.MinKazna = prestupBasic.MinKazna;
                pNew.MaxKazna = prestupBasic.MaxKazna;

                pNew.MestoPrestupa = prestupBasic.MestoPrestupa;
                pNew.DatumPrestupa = prestupBasic.DatumPrestupa;
                pNew.Opis = prestupBasic.Opis;

                pNew.Zatvorenik = s.Query<Zatvorenik>().Where(z => z.JMBG == prestupBasic.Zatvorenik.JMBG).FirstOrDefault();

                s.Save(pNew);
                s.Flush();

                prestupBasic.ID = pNew.ID;

                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
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
                MessageBox.Show(e.StackTrace);
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
                MessageBox.Show(e.StackTrace);
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
                MessageBox.Show(e.StackTrace);
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

                Prestup pNew = s
                    .Query<Prestup>()
                    .Where(p => p.ID == prestupBasic.ID)
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
            { MessageBox.Show(e.StackTrace); }
        }
        public static void CreateMozeDaAngazuje(ZatvorskaJedinicaBasic zatvorskaJedinicaBasic, FirmaBasic firmaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Firma f = s.Query<Firma>().Where(firm => firm.PIB == firmaBasic.PIB).SingleOrDefault();

                f.ZatvorskeJedinice.Add(s.Load<ZatvorskaJedinica>(zatvorskaJedinicaBasic.Sifra));

                s.SaveOrUpdate(f);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
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
            { MessageBox.Show(e.StackTrace); }

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
            { MessageBox.Show(e.StackTrace); }

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

                foreach(Firma p in list)
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
            { MessageBox.Show(e.StackTrace); }

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
                        //retSingle.ZatvorskeJedinice = ReadAllZatvorskaJedinicaFor(retSingle);

                        ret.Add(retSingle);
                    }
                }

                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }

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

                f.Naziv = firmaBasic.Naziv;
                f.Adresa = firmaBasic.Adresa;
                f.KontaktTelefon = firmaBasic.KontaktTelefon;

                s.SaveOrUpdate(f);

                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
        }
        public static void DeleteFirma(FirmaBasic firmaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Firma p = s.Query<Firma>()
                    .Where(tp => tp.PIB == firmaBasic.PIB)
                    .FirstOrDefault();

                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
        }
        public static void DeleteMozeDaAngazuje(ZatvorskaJedinicaBasic zj, FirmaBasic firmaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Firma f = s.QueryOver<Firma>()
                    .Where(firm => firm.PIB == firmaBasic.PIB)
                    .SingleOrDefault();

                f.ZatvorskeJedinice.Remove(f.ZatvorskeJedinice
                    .Where(z=>z.Sifra == zj.Sifra)
                    .SingleOrDefault());

                s.Save(f);
                s.Flush();

                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
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
            { MessageBox.Show(e.StackTrace); }
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
            { MessageBox.Show(e.StackTrace); }

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
            { MessageBox.Show(e.StackTrace); }

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
            { MessageBox.Show(e.StackTrace); }

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
            { MessageBox.Show(e.StackTrace); }

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

                olOld.JMBG = odgovornoLiceBasic.JMBG;
                olOld.Ime = odgovornoLiceBasic.Ime;
                olOld.Prezime = odgovornoLiceBasic.Prezime;

                s.SaveOrUpdate(olOld);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
        }
        public static void DeleteOdgovornoLice(OdgovornoLiceBasic odgovornoLiceBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                OdgovornoLice p = s.Query<OdgovornoLice>()
                    .Where(tp => tp.ID == odgovornoLiceBasic.ID)
                    .FirstOrDefault();
                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.StackTrace); }
        }
        #endregion
    }
}
