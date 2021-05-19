using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Zatvor.Entiteti;

namespace Zatvor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                ISession s = DataLayer.GetSession();

                List<ZatvorskaJedinica> lista = s.Query<ZatvorskaJedinica>().ToList();

                lista.ForEach(zj =>
                {
                    String info = "Zatvorska jedinica: " + zj.Naziv + "\n" +
                    "Adresa: " + zj.Adresa + "\n" +
                    "Kapacitet: " + zj.Kapacitet + "\n" +
                    "Šifra: " + zj.Sifra + "\n" +
                    "Upravnik: " + zj.Upravnik.Ime + " " + zj.Upravnik.Prezime + "\n" +
                    "Otvoren tip: " + zj.FrezimO + "\n" +
                    "Poluotvoren tip: " + zj.FrezimPO + "\n" +
                    "Zatvoren tip: " + zj.FrezimS + "\n";

                    if (zj.FrezimO == "TRUE")
                    {
                        String firme = "Firme:\n";
                        foreach (Firma f in zj.Firme)
                            firme += "\t" + f.Naziv + "\n";
                        info += firme;
                    }

                    if (zj.FrezimO == "TRUE" || zj.FrezimPO == "TRUE")
                    {
                        String celijskiPeriod = "Celijski period:\n";
                        foreach (CelijskiPeriod cp in zj.CelijskiPeriodi)
                            celijskiPeriod += "\t" + cp.Period + "\n";
                        info += celijskiPeriod;
                    }

                    if (zj.FrezimS == "TRUE")
                    {
                        String terminiSetnje = "Termini šetnje:\n";
                        foreach (TerminSetnje ts in zj.TerminiSetnje)
                            terminiSetnje += "\t" + ts.Termin + "\n";

                        String terminiPosete = "Termini posete:\n";
                        foreach (TerminPosete tp in zj.TerminiPosete)
                            terminiPosete += "\t" + tp.Dan + " " + tp.Period + "\n";

                        info += terminiSetnje + terminiPosete;
                    }

                    MessageBox.Show(info);
                });

                s.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonZJOtvoreniTip_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<ZatvorskaJedinica> lista =
                    s.Query<ZatvorskaJedinica>()
                    .Where(zj => zj.FrezimO == "TRUE")
                    .ToList();

                lista.ForEach(zj =>
                {
                    String info = "Zatvorska jedinica: " + zj.Naziv + "\n" +
                    "Adresa: " + zj.Adresa + "\n" +
                    "Kapacitet: " + zj.Kapacitet + "\n" +
                    "Šifra: " + zj.Sifra + "\n" +
                    "Upravnik: " + zj.Upravnik.Ime + " " + zj.Upravnik.Prezime + "\n" +
                    "Otvoren tip: " + zj.FrezimO + "\n" +
                    "Poluotvoren tip: " + zj.FrezimPO + "\n" +
                    "Zatvoren tip: " + zj.FrezimS + "\n";

                    if (zj.FrezimO == "TRUE")
                    {
                        String firme = "Firme:\n";
                        foreach (Firma f in zj.Firme)
                            firme += "\t" + f.Naziv + "\n";
                        info += firme;
                    }

                    if (zj.FrezimO == "TRUE" || zj.FrezimPO == "TRUE")
                    {
                        String celijskiPeriod = "Celijski period:\n";
                        foreach (CelijskiPeriod cp in zj.CelijskiPeriodi)
                            celijskiPeriod += "\t" + cp.Period + "\n";
                        info += celijskiPeriod;
                    }

                    if (zj.FrezimS == "TRUE")
                    {
                        String terminiSetnje = "Termini šetnje:\n";
                        foreach (TerminSetnje ts in zj.TerminiSetnje)
                            terminiSetnje += "\t" + ts.Termin + "\n";

                        String terminiPosete = "Termini posete:\n";
                        foreach (TerminPosete tp in zj.TerminiPosete)
                            terminiPosete += "\t" + tp.Dan + " " + tp.Period + "\n";

                        info += terminiSetnje + terminiPosete;
                    }

                    MessageBox.Show(info);
                });

                s.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonZJPoluotvorenTip_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<ZatvorskaJedinica> lista =
                    s.Query<ZatvorskaJedinica>()
                    .Where(zj => zj.FrezimPO == "TRUE")
                    .ToList();

                lista.ForEach(zj =>
                {
                    String info = "Zatvorska jedinica: " + zj.Naziv + "\n" +
                    "Adresa: " + zj.Adresa + "\n" +
                    "Kapacitet: " + zj.Kapacitet + "\n" +
                    "Šifra: " + zj.Sifra + "\n" +
                    "Upravnik: " + zj.Upravnik.Ime + " " + zj.Upravnik.Prezime + "\n" +
                    "Otvoren tip: " + zj.FrezimO + "\n" +
                    "Poluotvoren tip: " + zj.FrezimPO + "\n" +
                    "Zatvoren tip: " + zj.FrezimS + "\n";

                    if (zj.FrezimO == "TRUE")
                    {
                        String firme = "Firme:\n";
                        foreach (Firma f in zj.Firme)
                            firme += "\t" + f.Naziv + "\n";
                        info += firme;
                    }

                    if (zj.FrezimO == "TRUE" || zj.FrezimPO == "TRUE")
                    {
                        String celijskiPeriod = "Celijski period:\n";
                        foreach (CelijskiPeriod cp in zj.CelijskiPeriodi)
                            celijskiPeriod += "\t" + cp.Period + "\n";
                        info += celijskiPeriod;
                    }

                    if (zj.FrezimS == "TRUE")
                    {
                        String terminiSetnje = "Termini šetnje:\n";
                        foreach (TerminSetnje ts in zj.TerminiSetnje)
                            terminiSetnje += "\t" + ts.Termin + "\n";

                        String terminiPosete = "Termini posete:\n";
                        foreach (TerminPosete tp in zj.TerminiPosete)
                            terminiPosete += "\t" + tp.Dan + " " + tp.Period + "\n";

                        info += terminiSetnje + terminiPosete;
                    }

                    MessageBox.Show(info);
                });

                s.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonZJZatvorenTip_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<ZatvorskaJedinica> lista =
                    s.Query<ZatvorskaJedinica>()
                    .Where(zj => zj.FrezimS == "TRUE")
                    .ToList();

                lista.ForEach(zj =>
                {
                    String info = "Zatvorska jedinica: " + zj.Naziv + "\n" +
                    "Adresa: " + zj.Adresa + "\n" +
                    "Kapacitet: " + zj.Kapacitet + "\n" +
                    "Šifra: " + zj.Sifra + "\n" +
                    "Upravnik: " + zj.Upravnik.Ime + " " + zj.Upravnik.Prezime + "\n" +
                    "Otvoren tip: " + zj.FrezimO + "\n" +
                    "Poluotvoren tip: " + zj.FrezimPO + "\n" +
                    "Zatvoren tip: " + zj.FrezimS + "\n";

                    if (zj.FrezimO == "TRUE")
                    {
                        String firme = "Firme:\n";
                        foreach (Firma f in zj.Firme)
                            firme += "\t" + f.Naziv + "\n";
                        info += firme;
                    }

                    if (zj.FrezimO == "TRUE" || zj.FrezimPO == "TRUE")
                    {
                        String celijskiPeriod = "Celijski period:\n";
                        foreach (CelijskiPeriod cp in zj.CelijskiPeriodi)
                            celijskiPeriod += "\t" + cp.Period + "\n";
                        info += celijskiPeriod;
                    }

                    if (zj.FrezimS == "TRUE")
                    {
                        String terminiSetnje = "Termini šetnje:\n";
                        foreach (TerminSetnje ts in zj.TerminiSetnje)
                            terminiSetnje += "\t" + ts.Termin + "\n";

                        String terminiPosete = "Termini posete:\n";
                        foreach (TerminPosete tp in zj.TerminiPosete)
                            terminiPosete += "\t" + tp.Dan + " " + tp.Period + "\n";

                        info += terminiSetnje + terminiPosete;
                    }

                    MessageBox.Show(info);
                });

                s.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonZaposleni_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<Zaposleni> lista =
                    s.Query<Zaposleni>()
                    .ToList();

                lista.ForEach(z =>
                {

                    MessageBox.Show("Zaposleni: " + z.Ime + " " + z.Prezime + "\n" +
                        "JMBG: " + z.JMBG + "\n" +
                        "Pol: " + z.Pol + "\n" +
                        "Radno mesto: " + z.RadnoMesto + "\n" +
                        "Datum obuke protivpožarne zaštite: " + z.DatumObukePPZ.ToString() + "\n" +
                        "Naziv ustanove u kojoj radi: " + z.RadiU.Naziv + "\n" +
                        "Datum početka rada: " + z.DatumPocetkaRada);
                });

                s.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonAdministracija_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<Administracija> lista =
                    s.Query<Administracija>()
                    .ToList();

                String upravnik = "";
                lista.ForEach(z =>
                {
                    if (z.JeUpravnik != null)
                        upravnik = "\nUpravnik zatvorske jedinice: " + z.JeUpravnik.Naziv;

                    MessageBox.Show("Zaposleni: " + z.Ime + " " + z.Prezime + "\n" +
                        "JMBG: " + z.JMBG + "\n" +
                        "Pol: " + z.Pol + "\n" +
                        "Radno mesto: " + z.RadnoMesto + "\n" +
                        "Datum obuke protivpožarne zaštite: " + z.DatumObukePPZ.ToString() + "\n" +
                        "Naziv ustanove u kojoj radi: " + z.RadiU.Naziv + "\n" +
                        "Datum početka rada: " + z.DatumPocetkaRada + "\n" +
                        "Zanimanje: " + z.Zanimanje + "\n" +
                        "Pozicija: " + z.Pozicija + "\n" +
                        "Stručna sprema: " + z.StrucnaSprema + upravnik);
                });

                s.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonZatvorenici_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<Zatvorenik> lista =
                    s.Query<Zatvorenik>()
                    .ToList();

                lista.ForEach(z =>
                {
                    String prestupi = "";
                foreach (Prestup p in z.Prestupi)
                    prestupi += "\t" + p.PunNaziv + "\n";

                    String advokati = "";
                    foreach (Zastupa zast in z.Zastupa)
                        advokati += "\tIme advokata: " + zast.Advokat.Ime + " " + zast.Advokat.Prezime + "\n" +
                                   "\t\tDatum početka saradnje: " + zast.DatumPocetkaSaradnje + "\n" +
                                   "\t\tDatum poslednjeg kontakta: " + zast.DatumPoslednjegKontakta + "\n";

                    String posete = "";
                    foreach (Posecuje p in z.Posete)
                        posete += "\tIme advokata: " + p.Advokat.Ime + " " + p.Advokat.Prezime + "\n" +
                                   "\t\tOd: " + p.DTPocetka + "\n" +
                                   "\t\tDo: " + p.DTKraja + "\n";

                    String info = "Zatvorenik: " + z.Ime + " " + z.Prezime + "\n" +
                        "JMBG: " + z.JMBG + "\n" +
                        "Pol: " + z.Pol + "\n" +
                        "Adresa: " + z.Adresa + "\n" +
                        "Datum inkarceracije: " + z.DatumInkarceracije + "\n" +
                        "Datum sledećeg saslušanja: " + z.DatumSledecegSaslusanja + "\n" +
                        "Status uslovnog otpusta: " + z.StatusUslovnogOtpusta + "\n" +
                        "Zatvorska jedinica: " + z.ZatvorskaJedinica.Naziv + "\n" +
                        "Broj: " + z.Broj + "\n" +
                        "Prestupi: \n" + prestupi +
                        "Advokati: \n" + advokati +
                        "Posete advokata: \n" + posete; 

                    MessageBox.Show(info);
                });

                s.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonAdvokati_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<Advokat> lista =
                    s.Query<Advokat>()
                    .ToList();

                lista.ForEach(a =>
                {
                    String zastupa = "";
                    foreach (Zastupa z in a.Zastupa)
                        zastupa += "\tIme zatvorenika: " + z.Zatvorenik.Ime + " " + z.Zatvorenik.Prezime + "\n" +
                                   "\t\tDatum početka saradnje: " + z.DatumPocetkaSaradnje + "\n" +
                                   "\t\tDatum poslednjeg kontakta: " + z.DatumPoslednjegKontakta + "\n";
                    String posete = "";
                    foreach (Posecuje p in a.Posecuje)
                        posete += "\tIme zatvorenika: " + p.Zatvorenik.Ime + " " + p.Zatvorenik.Prezime + "\n" +
                                   "\t\tOd: " + p.DTPocetka + "\n" +
                                   "\t\tDo: " + p.DTKraja + "\n";

                    String info = "Advokat: " + a.Ime + " " + a.Prezime + "\n" +
                        "JMBG: " + a.JMBG + "\n" +
                        "Pol: " + a.Pol + "\n" +
                        "Zastupa: \n" + zastupa +
                        "Posete: \n" + posete;

                    MessageBox.Show(info);
                });

                s.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonPrestup_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<Prestup> lista =
                    s.Query<Prestup>()
                    .ToList();

                lista.ForEach(p =>
                {
                    String info = "Naziv: " + p.PunNaziv + "\n" +
                                  "Kategorija: " + p.Kategorija + "\n" +
                                  "Opis:\n\n" + p.Opis + "\n\n" +
                                  "Minimalna kazna (dani): " + p.MinKazna + "\n" +
                                  "Maksimalna kazna (dani): " + p.MaxKazna + "\n" +
                                  "Zatvorenik: " + p.Zatvorenik.Ime + " " + p.Zatvorenik.Prezime + "\n" +
                                  "Datum prestupa: " + p.DatumPrestupa + "\n" +
                                  "Mesto prestupa: " + p.MestoPrestupa;

                    MessageBox.Show(info);
                });

                s.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonPsiholozi_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<Psiholog> lista =
                    s.Query<Psiholog>()
                    .ToList();

                lista.ForEach(p =>
                {
                    MessageBox.Show("Zaposleni: " + p.Ime + " " + p.Prezime + "\n" +
                        "JMBG: " + p.JMBG + "\n" +
                        "Pol: " + p.Pol + "\n" +
                        "Radno mesto: " + p.RadnoMesto + "\n" +
                        "Datum obuke protivpožarne zaštite: " + p.DatumObukePPZ.ToString() + "\n" +
                        "Naziv ustanove u kojoj radi: " + p.RadiU.Naziv + "\n" +
                        "Datum početka rada: " + p.DatumPocetkaRada + "\n" +
                        "Lekarski pregled:\n" +
                        "\tLekar: " + p.LPLekar + "\n" +
                        "\tNaziv ustanove: " + p.LPNazivUstanove + "\n" +
                        "\tAdresa ustanove: " + p.LPAdresaUstanove + "\n" +
                        "\tDatum izdavanja: " + p.LPDatum + "\n" +
                        "Specijalizacija:\n" +
                        "\tNaziv: "+ p.SSpecijalizacija + "\n" +
                        "\tNaziv ustanove: " + p.SNazivUstanove);
                });

                s.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonObezbedjenje_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<RadnikObezbedjenja> lista =
                    s.Query<RadnikObezbedjenja>()
                    .ToList();

                lista.ForEach(ro =>
                {
                    MessageBox.Show("Zaposleni: " + ro.Ime + " " + ro.Prezime + "\n" +
                        "JMBG: " + ro.JMBG + "\n" +
                        "Pol: " + ro.Pol + "\n" +
                        "Radno mesto: " + ro.RadnoMesto + "\n" +
                        "Datum obuke protivpožarne zaštite: " + ro.DatumObukePPZ.ToString() + "\n" +
                        "Naziv ustanove u kojoj radi: " + ro.RadiU.Naziv + "\n" +
                        "Datum početka rada: " + ro.DatumPocetkaRada + "\n" +
                        "Lekarski pregled:\n" +
                        "\tLekar: " + ro.LPLekar + "\n" +
                        "\tNaziv ustanove: " + ro.LPNazivUstanove + "\n" +
                        "\tAdresa ustanove: " + ro.LPAdresaUstanove + "\n" +
                        "\tDatum izdavanja: " + ro.LPDatum + "\n" +
                        "Dozvola o obuci rada vatrenim oružjem:\n" +
                        "\tŠifra: " + ro.DORVOSifra + "\n" +
                        "\tNaziv policijske uprave: " + ro.DORVOPolicijskaUprava + "\n" +
                        "\tDatum izdavanja: " + ro.DORVODatumIzdavanja);
                });

                s.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonFirme_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<Firma> lista =
                    s.Query<Firma>()
                    .ToList();

                lista.ForEach(f =>
                {
                    String info = "Naziv: " + f.Naziv + "\n" +
                    "Adresa: " + f.Adresa + "\n" +
                    "Kontakt telefon: " + f.KontaktTelefon + "\n" +
                    "PIB: " + f.PIB + "\n" +
                    "Odgovorna lica:\n";

                    foreach (OdgovornoLice ol in f.OdgovornaLica)
                        info += "\tIme: " + ol.Ime + "\n\tPrezime: " + ol.Prezime + "\n\tJMBG: " + ol.JMBG + "\n";

                    MessageBox.Show(info);
                });

                s.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
