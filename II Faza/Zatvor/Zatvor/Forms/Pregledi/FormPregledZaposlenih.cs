using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zatvor.DTO;
using Zatvor.DTO.Basic;
using Zatvor.Forms.Dodavanja;

namespace Zatvor.Forms
{
    public partial class FormPregledZaposlenih : Form
    {
        private List<ZaposleniBasic> Zaposleni { get; set; }
        private string _view;
        public FormPregledZaposlenih(List<ZaposleniBasic> z)
        {
            Zaposleni = z;
            _view = "Svi";
            InitializeComponent();
        }
        public FormPregledZaposlenih()
        {
            Zaposleni = DTOManager.ReadAllZaposleni();
            _view = "Svi";
            InitializeComponent();
        }

        private void FormPregledZaposlenih_Load(object sender, EventArgs e)
        {
            listViewZaposleni.View = View.Details;
            listViewZaposleni.Alignment = ListViewAlignment.SnapToGrid;
            listViewZaposleni.FullRowSelect =
            listViewZaposleni.GridLines = true;

            SetView("Svi");

            buttonIzmeniZaposlenog.Enabled = buttonObrisi.Enabled = false;
        }

        private void buttonDodajZaposlenog_Click(object sender, EventArgs e)
        {
            FormZaposleni f = new FormZaposleni();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Zaposleni.Add(f.Zaposleni);
                OsveziPrikaz();
            }

            ResetButtons();
        }

        private void buttonIzmeniZaposlenog_Click(object sender, EventArgs e)
        {
            int val = Zaposleni.FindIndex(z => z.JMBG == listViewZaposleni.SelectedItems[0].Text);

            FormZaposleni f = new FormZaposleni(Zaposleni[val]);
            if (f.ShowDialog() == DialogResult.OK)
                OsveziPrikaz();

            ResetButtons();
        }

        private void buttonObrisiZaposlenog_Click(object sender, EventArgs e)
        {
            int forDel;
            foreach (ListViewItem lvi in listViewZaposleni.SelectedItems)
            {
                forDel = Zaposleni.FindIndex(z => z.JMBG == lvi.Text);
                DTOManager.DeleteZaposleni(Zaposleni[forDel]);
                Zaposleni.RemoveAt(forDel);
            }

            OsveziPrikaz();
        }

        private void listViewZaposleni_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetButtons(listViewZaposleni.SelectedIndices.Count);
        }
        private void OsveziPrikaz()
        {
            listViewZaposleni.Items.Clear();

            if (_view == "Svi")
            {
                Zaposleni.ForEach(z =>
                {
                    listViewZaposleni.Items.Add(new ListViewItem(new string[]
                    {
                        z.JMBG,
                        z.JMBG,
                        z.Ime,
                        z.Prezime,
                        z.Pol,
                        z.RadnoMesto,
                        z.DatumObukePPZ.ToLongDateString(),
                        z.RadiU.Naziv,
                        z.DatumPocetkaRada.ToLongDateString(),
                        String.IsNullOrEmpty(z.Zanimanje) ? "/" : z.Zanimanje,
                        String.IsNullOrEmpty(z.Pozicija) ? "/" : z.Pozicija,
                        String.IsNullOrEmpty(z.StrucnaSprema) ? "/" : z.StrucnaSprema,
                        String.IsNullOrEmpty(z.LPLekar) ? "/" : z.LPLekar,
                        z.LPDatum != null ? ((DateTime) z.LPDatum).ToLongDateString() : "/",
                        String.IsNullOrEmpty(z.LPNazivUstanove) ? "/" : z.LPNazivUstanove,
                        String.IsNullOrEmpty(z.LPAdresaUstanove) ? "/" : z.LPAdresaUstanove,
                        String.IsNullOrEmpty(z.SSpecijalizacija) ? "/" : z.SSpecijalizacija,
                        String.IsNullOrEmpty(z.SNazivUstanove) ? "/" : z.SNazivUstanove,
                        String.IsNullOrEmpty(z.DORVOSifra) ? "/" : z.DORVOSifra,
                        String.IsNullOrEmpty(z.DORVOPolicijskaUprava) ? "/" : z.DORVOPolicijskaUprava,
                        z.DORVODatumIzdavanja != null ? ((DateTime) z.DORVODatumIzdavanja).ToLongDateString() : "/"
                    }));
                });
            }
            else if (_view == "Administracija")
            {
                Zaposleni.FindAll(z => z.RadnoMesto == "Administracija").ForEach(a =>
                {
                    listViewZaposleni.Items.Add(new ListViewItem(new string[]
                    {
                        a.JMBG,
                        a.JMBG,
                        a.Ime,
                        a.Prezime,
                        a.Pol,
                        a.RadnoMesto,
                        a.DatumObukePPZ.ToLongDateString(),
                        a.RadiU.Naziv,
                        a.DatumPocetkaRada.ToLongDateString(),
                        String.IsNullOrEmpty(a.Zanimanje) ? "/" : a.Zanimanje,
                        String.IsNullOrEmpty(a.Pozicija) ? "/" : a.Pozicija,
                        String.IsNullOrEmpty(a.StrucnaSprema) ? "/" : a.StrucnaSprema
                    }));
                });
            }
            else if (_view == "Psiholozi")
            {
                Zaposleni.FindAll(z=>z.RadnoMesto == "Psiholog").ForEach(p =>
                {
                    listViewZaposleni.Items.Add(new ListViewItem(new string[]
                    {
                        p.JMBG,
                        p.JMBG,
                        p.Ime,
                        p.Prezime,
                        p.Pol,
                        p.RadnoMesto,
                        p.DatumObukePPZ.ToLongDateString(),
                        p.RadiU.Naziv,
                        p.DatumPocetkaRada.ToLongDateString(),
                        String.IsNullOrEmpty(p.LPLekar) ? "/" : p.LPLekar,
                        p.LPDatum != null ? ((DateTime) p.LPDatum).ToLongDateString() : "/",
                        String.IsNullOrEmpty(p.LPNazivUstanove) ? "/" : p.LPNazivUstanove,
                        String.IsNullOrEmpty(p.LPAdresaUstanove) ? "/" : p.LPAdresaUstanove,
                        String.IsNullOrEmpty(p.SSpecijalizacija) ? "/" : p.SSpecijalizacija,
                        String.IsNullOrEmpty(p.SNazivUstanove) ? "/" : p.SNazivUstanove,
                    }));
                });
            }
            else if (_view == "Obezbeđenje")
            {
                Zaposleni.FindAll(z => z.RadnoMesto == "Radnik obezbeđenja").ForEach(o =>
                {
                    listViewZaposleni.Items.Add(new ListViewItem(new string[]
                    {
                        o.JMBG,
                        o.JMBG,
                        o.Ime,
                        o.Prezime,
                        o.Pol,
                        o.RadnoMesto,
                        o.DatumObukePPZ.ToLongDateString(),
                        o.RadiU.Naziv,
                        o.DatumPocetkaRada.ToLongDateString(),
                        String.IsNullOrEmpty(o.LPLekar) ? "/" : o.LPLekar,
                        o.LPDatum != null ? ((DateTime) o.LPDatum).ToLongDateString() : "/",
                        String.IsNullOrEmpty(o.LPNazivUstanove) ? "/" : o.LPNazivUstanove,
                        String.IsNullOrEmpty(o.LPAdresaUstanove) ? "/" : o.LPAdresaUstanove,
                        String.IsNullOrEmpty(o.DORVOSifra) ? "/" : o.DORVOSifra,
                        String.IsNullOrEmpty(o.DORVOPolicijskaUprava) ? "/" : o.DORVOPolicijskaUprava,
                        o.DORVODatumIzdavanja != null ? ((DateTime) o.DORVODatumIzdavanja).ToLongDateString() : "/"
                    }));
                });
            }
        }

        private void FormPregledZaposlenih_Shown(object sender, EventArgs e)
        {
            OsveziPrikaz();
        }

        private void SetView(string view)
        {
            _view = view;
            listViewZaposleni.Columns.Clear();

            string[] vals = { 
                "",
                "JMBG",
                "Ime",
                "Prezime",
                "Pol",
                "Radno mesto",
                "Datum obuke protivpožarne zaštite",
                "Naziv zatvorske jedinice",
                "Datum početka rada" };

            string[] choice;

            if (view == "Svi")
            {
                choice = new string[] {
                "Zanimanje",
                "Pozicija",
                "Stručna sprema",
                "Lekar koji je izvršio lekarski pregled",
                "Datum lekarskog pregled",
                "Ustanova koja je izdala lekarski pregled",
                "Adresa ustanove koja je izdala lekarski pregled",
                "Specijalizacija",
                "Naziv ustanove koja izdaje specijalizaciju",
                "Šifra dokaza o rukovanju vatrenim oružjem",
                "Policijska uprava koja izdaje dokaz",
                "Datum izdavanja dokaza o protivpožarnoj zaštiti"};
            }
            else if (view == "Administracija")
            {
                choice = new string[] {
                "Zanimanje",
                "Pozicija",
                "Stručna sprema"};
            }
            else if (view == "Obezbeđenje")
            {
                choice = new string[] {
                "Lekar koji je izvršio lekarski pregled",
                "Datum lekarskog pregled",
                "Ustanova koja je izdala lekarski pregled",
                "Adresa ustanove koja je izdala lekarski pregled",
                "Šifra dokaza o rukovanju vatrenim oružjem",
                "Policijska uprava koja izdaje dokaz",
                "Datum izdavanja dokaza o protivpožarnoj zaštiti"};
            }
            else if (view == "Psiholozi")
            {
                choice = new string[] {
                "Lekar koji je izvršio lekarski pregled",
                "Datum lekarskog pregled",
                "Ustanova koja je izdala lekarski pregled",
                "Adresa ustanove koja je izdala lekarski pregled",
                "Specijalizacija",
                "Naziv ustanove koja izdaje specijalizaciju"};
            }
            else
                choice = new string[] { };

            vals = vals.Concat(choice).ToArray();

            for (int i = 0; i < vals.Length; i++)
            {
                listViewZaposleni.Columns.Add(new ColumnHeader(i)
                {
                    Text = vals[i],
                    TextAlign = HorizontalAlignment.Center,
                    Width = i == 0 ? 0 : (50 + vals[i].Length * (i < 5 ? 20 : 8))
                });
            }
        }

        private void buttonPrikaziSve_Click(object sender, EventArgs e)
        {
            if (_view != "Svi")
            {
                SetView("Svi");
                OsveziPrikaz();
            }
            ResetButtons();
        }

        private void buttonPrikaziAdministraciju_Click(object sender, EventArgs e)
        {
            if (_view != "Administracija")
            {
                SetView("Administracija");
                OsveziPrikaz();
            }
            ResetButtons();
        }

        private void buttonPrikaziPsihologe_Click(object sender, EventArgs e)
        {
            if (_view != "Psiholozi")
            {
                SetView("Psiholozi");
                OsveziPrikaz();
            }
            ResetButtons();
        }

        private void buttonPrikaziObezbedjenje_Click(object sender, EventArgs e)
        {
            if (_view != "Obezbeđenje")
            {
                SetView("Obezbeđenje");
                OsveziPrikaz();
            }
            ResetButtons();
        }

        private void ResetButtons(int val = 0)
        {
            buttonIzmeniZaposlenog.Enabled = val == 1;
            buttonObrisi.Enabled = val >= 1;
            buttonObrisi.Text = (val <= 1) ? "Obriši zaposlenog" : "Obriši zaposlene";
        }
    }
}
