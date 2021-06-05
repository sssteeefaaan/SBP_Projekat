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
using Zatvor.Forms.Dodaj_Izmeni;
using Zatvor.Forms.Dodavanja;

namespace Zatvor.Forms.Pregledi
{
    public partial class FormPregledZatvorskeJedinice : Form
    {
        public ZatvorskaJedinicaBasic ZatvorskaJedinica { get; set; }
        private string _zapView;
        public FormPregledZatvorskeJedinice(ZatvorskaJedinicaBasic zj)
        {
            ZatvorskaJedinica = zj;
            _zapView = "Svi";
            InitializeComponent();
        }
        private void FormPregledZatvorskeJedinice_Load(object sender, EventArgs e)
        {
            Text = "Pregled zatvorske jedinice '" + ZatvorskaJedinica.Naziv + "'";
            checkBoxOtvoren.Checked = ZatvorskaJedinica.ORezim;
            checkBoxPoluotvoren.Checked = ZatvorskaJedinica.PORezim;
            checkBoxStrogi.Checked = ZatvorskaJedinica.SRezim;

            radioButtonSvi.Checked = true;

            listViewCelijskiPeriodi.View =
            listViewFirme.View =
            listViewTerminiPosete.View =
            listViewTerminiSetnje.View =
            listViewZatvorenici.View =
            listViewZaposleni.View =
            View.Details;

            listViewCelijskiPeriodi.GridLines =
            listViewFirme.GridLines =
            listViewTerminiPosete.GridLines =
            listViewTerminiSetnje.GridLines =
            listViewZaposleni.GridLines =
            listViewZatvorenici.GridLines =
            listViewCelijskiPeriodi.FullRowSelect =
            listViewFirme.FullRowSelect =
            listViewTerminiPosete.FullRowSelect =
            listViewTerminiSetnje.FullRowSelect =
            listViewZaposleni.FullRowSelect =
            listViewZatvorenici.FullRowSelect =
            listViewCelijskiPeriodi.MultiSelect =
            listViewFirme.MultiSelect =
            listViewTerminiPosete.MultiSelect =
            listViewTerminiSetnje.MultiSelect =
            listViewZaposleni.MultiSelect =
            listViewZatvorenici.MultiSelect =
            true;

            buttonIzmeniZaposlenog.Enabled =
            buttonObrisiZaposlenog.Enabled =
            buttonIzmeniZatvorenika.Enabled =
            buttonObrisiZatvorenika.Enabled =
            buttonIzmeniCP.Enabled =
            buttonIzmeniFirmu.Enabled =
            buttonIzmeniTP.Enabled =
            buttonIzmeniTS.Enabled =
            buttonObrisiCP.Enabled =
            buttonObrisiFirmu.Enabled =
            buttonObrisiTP.Enabled =
            buttonObrisiTS.Enabled = false;


            SetViewAll();
            RefreshViewAll();
            RefreshDataAll();
            ResetButtonsAll();
        }
        private void checkBoxPoluotvoren_CheckedChanged(object sender, EventArgs e)
        {
            ZatvorskaJedinica.PORezim = checkBoxPoluotvoren.Checked;
            RefreshViewRezim();
        }

        private void checkBoxStrogi_CheckedChanged(object sender, EventArgs e)
        {
            ZatvorskaJedinica.SRezim = checkBoxStrogi.Checked;
            RefreshViewRezim();
        }

        private void checkBoxOtvoren_CheckedChanged(object sender, EventArgs e)
        {
            ZatvorskaJedinica.ORezim= checkBoxOtvoren.Checked;
            RefreshViewRezim();
        }
        private void listViewTerminiSetnje_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetButtonsTerminiSetnje(listViewTerminiSetnje.SelectedItems.Count);
        }

        private void listViewTerminiPosete_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetButtonsTerminiPosete(listViewTerminiPosete.SelectedItems.Count);
        }

        private void listViewCelijskiPeriodi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetButtonsCelijskiPeriod(listViewCelijskiPeriodi.SelectedItems.Count);
        }

        private void listViewFirme_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetButtonsFirme(listViewFirme.SelectedItems.Count);
        }

        private void buttonDodajFirmu_Click(object sender, EventArgs e)
        {
            FormPregledFirmi f = new FormPregledFirmi(ZatvorskaJedinica);
            if (f.ShowDialog() == DialogResult.OK)
                RefreshDataFirme();

            ResetButtonsFirme();
        }

        private void buttonIzmeniFirmu_Click(object sender, EventArgs e)
        {
            int index = ZatvorskaJedinica.Firme.FindIndex(firma => firma.PIB == listViewFirme.SelectedItems[0].Text);
            FormFirma f = new FormFirma(ZatvorskaJedinica.Firme[index]);
            if (f.ShowDialog() == DialogResult.OK)
                RefreshDataFirme();

            ResetButtonsFirme();
        }

        private void buttonObrisiFirmu_Click(object sender, EventArgs e)
        {
            int index;
            foreach (ListViewItem lvi in listViewFirme.SelectedItems)
            {
                index = ZatvorskaJedinica.Firme.FindIndex(firma => firma.PIB == lvi.Text);
                DTOManager.DeleteMozeDaAngazuje(ZatvorskaJedinica, ZatvorskaJedinica.Firme[index]);
                ZatvorskaJedinica.Firme.RemoveAt(index);
            }

            RefreshDataFirme();
            ResetButtonsFirme();
        }

        private void buttonDodajCP_Click(object sender, EventArgs e)
        {
            FormCelijskiPeriod f = new FormCelijskiPeriod(ZatvorskaJedinica);
            if (f.ShowDialog() == DialogResult.OK)
            {
                ZatvorskaJedinica.CelijskiPeriodi.Add(f.CelijskiPeriod);
                RefreshDataCelijskiPeriodi();
            }

            ResetButtonsCelijskiPeriod();
        }

        private void buttonIzmeniCP_Click(object sender, EventArgs e)
        {
            FormCelijskiPeriod f = new FormCelijskiPeriod(ZatvorskaJedinica.CelijskiPeriodi[listViewCelijskiPeriodi.SelectedIndices[0]]);
            if (f.ShowDialog() == DialogResult.OK)
            {
                ZatvorskaJedinica.CelijskiPeriodi[listViewCelijskiPeriodi.SelectedIndices[0]] = f.CelijskiPeriod;
                RefreshDataCelijskiPeriodi();
            }

            ResetButtonsCelijskiPeriod();
        }

        private void buttonObrisiCP_Click(object sender, EventArgs e)
        {
            foreach (int index in listViewCelijskiPeriodi.SelectedIndices)
            {
                DTOManager.DeleteCelijskiPeriod(ZatvorskaJedinica.CelijskiPeriodi[index]);
                ZatvorskaJedinica.CelijskiPeriodi.RemoveAt(index);
            }

            RefreshDataCelijskiPeriodi();
            ResetButtonsCelijskiPeriod();
        }

        private void buttonDodajTP_Click(object sender, EventArgs e)
        {
            FormTerminPosete f = new FormTerminPosete(ZatvorskaJedinica);
            if (f.ShowDialog() == DialogResult.OK)
            {
                ZatvorskaJedinica.TerminiPosete.Add(f.TerminPosete);
                RefreshDataTerminiPosete();
            }

            ResetButtonsTerminiPosete();
        }

        private void buttonIzmeniTP_Click(object sender, EventArgs e)
        {
            FormTerminPosete f = new FormTerminPosete(ZatvorskaJedinica.TerminiPosete[listViewTerminiPosete.SelectedIndices[0]]);
            if (f.ShowDialog() == DialogResult.OK)
            {
                ZatvorskaJedinica.TerminiPosete[listViewTerminiPosete.SelectedIndices[0]] = f.TerminPosete;
                RefreshDataTerminiPosete();
            }

            ResetButtonsTerminiPosete();
        }

        private void buttonObrisiTP_Click(object sender, EventArgs e)
        {
            foreach (int index in listViewTerminiPosete.SelectedIndices)
            {
                DTOManager.DeleteTerminPosete(ZatvorskaJedinica.TerminiPosete[index]);
                ZatvorskaJedinica.TerminiPosete.RemoveAt(index);
            }

            RefreshDataTerminiPosete();
            ResetButtonsTerminiPosete();
        }

        private void buttonDodajTS_Click(object sender, EventArgs e)
        {
            FormTerminSetnje f = new FormTerminSetnje(ZatvorskaJedinica);
            if (f.ShowDialog() == DialogResult.OK)
            {
                ZatvorskaJedinica.TerminiSetnje.Add(f.TerminSetnje);
                RefreshDataTerminiSetnje();
            }

            ResetButtonsTerminiSetnje();
        }

        private void buttonIzmeniTS_Click(object sender, EventArgs e)
        {
            FormTerminSetnje f = new FormTerminSetnje(ZatvorskaJedinica.TerminiSetnje[listViewTerminiSetnje.SelectedIndices[0]]);
            if (f.ShowDialog() == DialogResult.OK)
            {
                ZatvorskaJedinica.TerminiSetnje[listViewTerminiSetnje.SelectedIndices[0]] = f.TerminSetnje;
                RefreshDataTerminiSetnje();
            }

            ResetButtonsTerminiSetnje();
        }

        private void buttonObrisiTS_Click(object sender, EventArgs e)
        {
            foreach (int index in listViewTerminiSetnje.SelectedIndices)
            {
                DTOManager.DeleteTerminSetnje(ZatvorskaJedinica.TerminiSetnje[index]);
                ZatvorskaJedinica.TerminiSetnje.RemoveAt(index);
            }

            RefreshDataTerminiSetnje();
            ResetButtonsTerminiSetnje();
        }

        private void buttonDodajZaposlenog_Click(object sender, EventArgs e)
        {
            FormZaposleni f = new FormZaposleni(ZatvorskaJedinica);
            if (f.ShowDialog() == DialogResult.OK)
            {
                ZatvorskaJedinica.Zaposleni.Add(f.Zaposleni);
                RefreshDataZaposleni();
                SetViewUpravnik();
            }

            ResetButtonsZaposleni();
        }

        private void buttonIzmeniZaposlenog_Click(object sender, EventArgs e)
        {
            int val = ZatvorskaJedinica.Zaposleni.FindIndex(z => z.JMBG == listViewZaposleni.SelectedItems[0].Text);
            FormZaposleni f = new FormZaposleni(ZatvorskaJedinica.Zaposleni[val]);
            if (f.ShowDialog() == DialogResult.OK)
                RefreshDataZaposleni();

            ResetButtonsZaposleni();
        }

        private void buttonObrisiZaposlenog_Click(object sender, EventArgs e)
        {
            int forDel;
            foreach (ListViewItem lvi in listViewZaposleni.SelectedItems)
            {
                forDel = ZatvorskaJedinica.Zaposleni.FindIndex(z => z.JMBG == lvi.Text);
                DTOManager.DeleteZaposleni(ZatvorskaJedinica.Zaposleni[forDel]);
                ZatvorskaJedinica.Zaposleni.RemoveAt(forDel);
            }

            RefreshDataZaposleni();
            ResetButtonsZaposleni();
        }

        private void listViewZaposleni_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetButtonsZaposleni(listViewZaposleni.SelectedItems.Count);
        }

        private void radioButtonSvi_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSvi.Checked)
            {
                SetViewZaposleni("Svi");
                RefreshDataZaposleni();
                ResetButtonsZaposleni();
            }
        }

        private void radioButtonAdministracija_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAdministracija.Checked)
            {
                SetViewZaposleni("Administracija");
                RefreshDataZaposleni();
                ResetButtonsZaposleni();
            }
        }

        private void radioButtonPsiholozi_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPsiholozi.Checked)
            {
                SetViewZaposleni("Psiholozi");
                RefreshDataZaposleni();
                ResetButtonsZaposleni();
            }
        }

        private void radioButtonObezbedjenje_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonObezbedjenje.Checked)
            {
                SetViewZaposleni("Obezbeđenje");
                RefreshDataZaposleni();
                ResetButtonsZaposleni();
            }
        }

        private void buttonDodajZatvorenika_Click(object sender, EventArgs e)
        {
            FormZatvorenik f = new FormZatvorenik(ZatvorskaJedinica);
            if (f.ShowDialog() == DialogResult.OK)
            {
                ZatvorskaJedinica.Zatvorenici.Add(f.Zatvorenik);
                RefreshDataZatvorenici();
            }

            ResetButtonsZatvorenici();
        }

        private void buttonIzmeniZatvorenika_Click(object sender, EventArgs e)
        {
            FormZatvorenik f = new FormZatvorenik(ZatvorskaJedinica, ZatvorskaJedinica.Zatvorenici.Find(z=>z.JMBG == listViewZatvorenici.SelectedItems[0].Text));
            if (f.ShowDialog() == DialogResult.OK)
                RefreshDataZatvorenici();

            ResetButtonsZatvorenici();
        }

        private void buttonObrisiZatvorenika_Click(object sender, EventArgs e)
        {
            int forDel;
            foreach (ListViewItem lvi in listViewZatvorenici.SelectedItems)
            {
                forDel = ZatvorskaJedinica.Zatvorenici.FindIndex(z => z.JMBG == lvi.Text);
                DTOManager.DeleteZatvorenik(ZatvorskaJedinica.Zatvorenici[forDel]);
                ZatvorskaJedinica.Zatvorenici.RemoveAt(forDel);
            }

            RefreshDataZatvorenici();
            ResetButtonsZatvorenici();
        }
        private void listViewZatvorenici_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetButtonsZatvorenici(listViewZatvorenici.SelectedItems.Count);
        }

        private void SetViewAll()
        {
            SetViewZaposleni("Svi");
            SetViewUpravnik();
            SetViewZatvorenici();
            SetViewFirme();
            SetViewCelisjkiPeriodi();
            SetViewSetnje();
            SetViewPosete();
        }
        private void SetViewZaposleni(string view)
        {
            _zapView = view;
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
        private void SetViewUpravnik()
        {
            ZatvorskaJedinica
                .Zaposleni
                .FindAll(z => z.RadnoMesto == "Administracija")
                .ForEach(a => comboBox1.Items.Add(a.Ime + " " + a.Prezime + " [" + a.JMBG + "]"));

            if (ZatvorskaJedinica.Upravnik != null)
                comboBox1.SelectedItem = ZatvorskaJedinica.Upravnik.Ime + " " + ZatvorskaJedinica.Upravnik.Prezime + " [" + ZatvorskaJedinica.Upravnik.JMBG + "]";
        }
        private void SetViewZatvorenici()
        {
            int[] vals = { 0, 200, 100, 100, 50, 350, 100, 300, 300, 200, 100, 100 };
            int index = 0;
            foreach (string s in new string[] { 
                "",
                "JMBG",
                "Ime",
                "Prezime",
                "Pol",
                "Adresa",
                "Broj",
                "Datum inkarceracije",
                "Datum sledećeg saslušanja",
                "Status uslovnog otpusta",
                "Broj zastupanja",
                "Broj poseta" })
                listViewZatvorenici.Columns.Add(new ColumnHeader()
                {
                    Text = s,
                    TextAlign = HorizontalAlignment.Center,
                    Width = vals[index++]
                });
        }
        private void SetViewFirme()
        {
            int[] vals = { 0, 100, 300, 300, 150, 150 };
            int index = 0;
            foreach (string s in new string[] { 
                "", 
                "PIB", 
                "Naziv",
                "Adresa",
                "Kontakt telefon", 
                "Odgovorna lica" })
                listViewFirme.Columns.Add(new ColumnHeader(index)
                {
                    Text = s,
                    TextAlign = HorizontalAlignment.Center,
                    Width = vals[index++]
                });
        }
        private void SetViewCelisjkiPeriodi()
        {
            foreach (string s in new string[] { "", "Period" })
                listViewCelijskiPeriodi.Columns.Add(new ColumnHeader()
                {
                    Text = s,
                    TextAlign = HorizontalAlignment.Center,
                    Width = s == "" ? 0 : listViewCelijskiPeriodi.Width - 5
                });
        }
        private void SetViewSetnje()
        {
            foreach (string s in new string[] { "", "Period" })
                listViewTerminiSetnje.Columns.Add(new ColumnHeader()
                {
                    Text = s,
                    TextAlign = HorizontalAlignment.Center,
                    Width = s == "" ? 0 : listViewCelijskiPeriodi.Width - 5
                });
        }
        private void SetViewPosete()
        {
            foreach (string s in new string[] {
                "",
                "Dan",
                "Period" })
                listViewTerminiPosete.Columns.Add(new ColumnHeader()
                {
                    Text = s,
                    TextAlign = HorizontalAlignment.Center,
                    Width = s == "" ? 0 : (listViewTerminiPosete.Width - 2) / 2
                });  
        }
        private void RefreshViewAll()
        {
            RefreshViewRezim();
        }
        private void RefreshViewRezim()
        {
            if (ZatvorskaJedinica.ORezim)
            {
                groupBoxFirme.Show();
                groupBoxCelijskiPeriod.Show();
            }
            else if (ZatvorskaJedinica.PORezim)
            {
                groupBoxCelijskiPeriod.Show();
                groupBoxFirme.Hide();
            }
            else
            {
                groupBoxFirme.Hide();
                groupBoxCelijskiPeriod.Hide();
            }

            if (ZatvorskaJedinica.SRezim)
            {
                groupBoxTerminiPosete.Show();
                groupBoxTerminiSetnje.Show();
            }
            else
            {
                groupBoxTerminiPosete.Hide();
                groupBoxTerminiSetnje.Hide();
            }

            if (groupBoxFirme.Visible)
            {
                groupBoxCelijskiPeriod.Location = new Point(groupBoxFirme.Location.X, groupBoxFirme.Location.Y + groupBoxFirme.Height + 10);
                if (groupBoxTerminiPosete.Visible && groupBoxTerminiSetnje.Visible)
                {
                    groupBoxTerminiPosete.Location = new Point(groupBoxCelijskiPeriod.Location.X, groupBoxCelijskiPeriod.Location.Y + groupBoxCelijskiPeriod.Height + 10);
                    groupBoxTerminiSetnje.Location = new Point(groupBoxTerminiPosete.Location.X, groupBoxTerminiPosete.Location.Y + groupBoxTerminiPosete.Height + 10);
                }
            }
            else
            {
                if (groupBoxCelijskiPeriod.Visible)
                {
                    groupBoxCelijskiPeriod.Location = new Point(groupBoxFirme.Location.X, groupBoxFirme.Location.Y);
                    if (groupBoxTerminiPosete.Visible && groupBoxTerminiSetnje.Visible)
                    {
                        groupBoxTerminiPosete.Location = new Point(groupBoxCelijskiPeriod.Location.X, groupBoxCelijskiPeriod.Location.Y + groupBoxCelijskiPeriod.Height + 10);
                        groupBoxTerminiSetnje.Location = new Point(groupBoxTerminiPosete.Location.X, groupBoxTerminiPosete.Location.Y + groupBoxTerminiPosete.Height + 10);
                    }
                }
                else if (groupBoxTerminiPosete.Visible && groupBoxTerminiSetnje.Visible)
                {
                    groupBoxTerminiPosete.Location = new Point(groupBoxFirme.Location.X, groupBoxFirme.Location.Y);
                    groupBoxTerminiSetnje.Location = new Point(groupBoxTerminiPosete.Location.X, groupBoxTerminiPosete.Location.Y + groupBoxTerminiPosete.Height + 10);
                }
            }
        }
        private void RefreshDataAll()
        {
            RefreshDataZaposleni();
            RefreshDataZatvorenici();
            RefreshDataFirme();
            RefreshDataCelijskiPeriodi();
            RefreshDataTerminiPosete();
            RefreshDataTerminiSetnje();
        }
        private void RefreshDataZaposleni()
        {
            listViewZaposleni.Items.Clear();

            if (_zapView == "Svi")
            {
                ZatvorskaJedinica.Zaposleni.ForEach(z =>
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
            else if (_zapView == "Administracija")
            {
                ZatvorskaJedinica.Zaposleni.FindAll(z => z.RadnoMesto == "Administracija").ForEach(a =>
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
            else if (_zapView == "Psiholozi")
            {
                ZatvorskaJedinica.Zaposleni.FindAll(z => z.RadnoMesto == "Psiholog").ForEach(p =>
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
            else if (_zapView == "Obezbeđenje")
            {
                ZatvorskaJedinica.Zaposleni.FindAll(z => z.RadnoMesto == "Radnik obezbeđenja").ForEach(o =>
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
        private void RefreshDataZatvorenici()
        {
            listViewZatvorenici.Items.Clear();
            foreach (ZatvorenikBasic z in ZatvorskaJedinica.Zatvorenici)
                listViewZatvorenici.Items.Add(new ListViewItem(new string[] {
                    z.JMBG,
                    z.JMBG,
                    z.Ime,
                    z.Prezime,
                    z.Pol,
                    String.IsNullOrEmpty(z.Adresa) ? "/":z.Adresa,
                    z.Broj,
                    z.DatumInkarceracije.ToString(),
                    z.DatumSledecegSaslusanja != null ? z.DatumSledecegSaslusanja.ToString() : "/",
                    z.StatusUslovnogOtpusta,
                    z.Zastupa.Count.ToString(),
                    z.Posete.Count.ToString(),
                }));
        }
        private void RefreshDataFirme()
        {
            listViewFirme.Items.Clear();
            foreach (FirmaBasic f in ZatvorskaJedinica.Firme)
                listViewFirme.Items.Add(new ListViewItem(new string[]
                {
                    f.PIB,
                    f.PIB,
                    f.Naziv,
                    f.Adresa,
                    f.KontaktTelefon,
                    f.OdgovornaLica.Count.ToString()
                }));
        }
        private void RefreshDataCelijskiPeriodi()
        {
            listViewCelijskiPeriodi.Items.Clear();
            foreach (CelijskiPeriodBasic c in ZatvorskaJedinica.CelijskiPeriodi)
                listViewCelijskiPeriodi.Items.Add(new ListViewItem(new string[] { c.ID.ToString(), c.Period }));
        }
        private void RefreshDataTerminiSetnje()
        {
            listViewTerminiSetnje.Items.Clear();
            foreach (TerminSetnjeBasic s in ZatvorskaJedinica.TerminiSetnje)
                listViewTerminiSetnje.Items.Add(new ListViewItem(new string[] { s.ID.ToString(), s.Termin }));
        }
        private void RefreshDataTerminiPosete()
        {
            listViewTerminiPosete.Items.Clear();
            foreach (TerminPoseteBasic p in ZatvorskaJedinica.TerminiPosete)
                listViewTerminiPosete.Items.Add(new ListViewItem(new string[] {
                    p.ID.ToString(),
                    p.Dan,
                    p.Period
                }));
        }

        private void listViewZatvorenici_DoubleClick(object sender, EventArgs e)
        {
            int val = ZatvorskaJedinica.Zatvorenici.FindIndex(z => z.JMBG == listViewZatvorenici.SelectedItems[0].Text);

            FormPregledZatvorenika f = new FormPregledZatvorenika(ZatvorskaJedinica.Zatvorenici[val]);
            if (f.ShowDialog() == DialogResult.OK)
                RefreshDataZatvorenici();

            ResetButtonsZatvorenici();
        }

        private void listViewFirme_DoubleClick(object sender, EventArgs e)
        {
            int index = ZatvorskaJedinica.Firme.FindIndex(firma => firma.PIB == listViewFirme.SelectedItems[0].Text);
            FormPregledLica f = new FormPregledLica(ZatvorskaJedinica.Firme[index]);
            f.ShowDialog();

            ResetButtonsFirme();
        }

        private void FormPregledZatvorskeJedinice_FormClosing(object sender, FormClosingEventArgs e)
        {
            ZatvorskaJedinica.ORezim = checkBoxOtvoren.Checked;
            ZatvorskaJedinica.PORezim = checkBoxPoluotvoren.Checked;
            ZatvorskaJedinica.SRezim = checkBoxStrogi.Checked;

            if(comboBox1.SelectedIndex >= 0)
                ZatvorskaJedinica.Upravnik = ZatvorskaJedinica.Zaposleni.Find(z => z.JMBG == comboBox1.Text.Substring(comboBox1.Text.Length - 14, 13));

            DTOManager.UpdateZatvorskaJedinica(ZatvorskaJedinica);
        }
        private void ResetButtonsAll()
        {
            ResetButtonsCelijskiPeriod();
            ResetButtonsFirme();
            ResetButtonsTerminiPosete();
            ResetButtonsTerminiSetnje();
            ResetButtonsZaposleni();
            ResetButtonsZatvorenici();
        }

        private void ResetButtonsZaposleni(int val = 0)
        {
            buttonIzmeniZaposlenog.Enabled = val == 1;
            buttonObrisiZaposlenog.Enabled = val >= 1;
        }
        private void ResetButtonsZatvorenici(int val = 0)
        {
            buttonIzmeniZatvorenika.Enabled = val == 1;
            buttonObrisiZatvorenika.Enabled = val >= 1;
        }
        private void ResetButtonsFirme(int val = 0)
        {
            buttonIzmeniFirmu.Enabled = val == 1;
            buttonObrisiFirmu.Enabled = val >= 1;
        }
        private void ResetButtonsCelijskiPeriod(int val = 0)
        {
            buttonIzmeniCP.Enabled = val == 1;
            buttonObrisiCP.Enabled = val >= 1;
        }
        private void ResetButtonsTerminiPosete(int val = 0)
        {
            buttonIzmeniTP.Enabled = val == 1;
            buttonObrisiTP.Enabled = val >= 1;
        }
        private void ResetButtonsTerminiSetnje(int val = 0)
        {
            buttonIzmeniTS.Enabled = val == 1;
            buttonObrisiTS.Enabled = val >= 1;
        }
    }
}
