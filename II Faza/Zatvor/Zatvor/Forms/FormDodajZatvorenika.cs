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

namespace Zatvor.Forms
{
    public partial class FormDodajZatvorenika : Form
    {
        public virtual ZatvorenikBasic Zatvorenik { get; set; }
        public virtual List<ZatvorskaJedinicaBasic> ZatvorskeJedinice { get; set; }
        public virtual List<AdvokatBasic> Advokati { get; set; }
        public FormDodajZatvorenika(ref ZatvorenikBasic z)
        {
            z = this.Zatvorenik = new ZatvorenikBasic();
            InitializeComponent();
        }

        private void FormDodajZatvorenika_Load(object sender, EventArgs e)
        {
            buttonDodajZatvorenika.Enabled =
            buttonIzaberiAdvokata.Enabled = 
            buttonIzmeniPrestup.Enabled = 
            buttonUkloniPrestup.Enabled = 
            buttonIzmeniAdvokata.Enabled = 
            buttonPregledPoseta.Enabled = 
            buttonUkloniAdvokata.Enabled = false;

            buttonSacuvajIzmeneAdvokata.Hide();
            buttonSacuvajIzmenePrestup.Hide();

            comboBoxPol.Items.Add("Muški");
            comboBoxPol.Items.Add("Ženski");

            comboBoxStatusUslovnogOtpusta.Items.Add("PRIHVAĆEN");
            comboBoxStatusUslovnogOtpusta.Items.Add("ODBIJEN");
            comboBoxStatusUslovnogOtpusta.Items.Add("RAZMATRA SE");

            ZatvorskeJedinice = DTOManager.ReadAllZatvorskeJedinice();
            ZatvorskeJedinice.ForEach(zj => comboBoxZatvorskaJedinica.Items.Add(zj.Naziv));
            Advokati = DTOManager.ReadAllAdvokati();
            Advokati.ForEach(a => comboBoxAdvokati.Items.Add(a.Ime + " " + a.Prezime + " [" + a.JMBG + "]"));
        }

        private void buttonDodajPrestup_Click(object sender, EventArgs e)
        {
            if (!ValidacijaPrestupa())
                return;

            int i = this.Zatvorenik.Prestupi.Count;
            this.Zatvorenik.Prestupi.Add(new PrestupBasic());

            this.Zatvorenik.Prestupi[i].Zatvorenik = this.Zatvorenik;

            listViewPrestupi.Items.Add(new ListViewItem(new string[]
            {
                this.Zatvorenik.Prestupi[i].PunNaziv = textBoxPunNaziv.Text,
                this.Zatvorenik.Prestupi[i].Kategorija = textBoxKategorija.Text,
                this.Zatvorenik.Prestupi[i].MestoPrestupa = textBoxMestoPrestupa.Text,
                (this.Zatvorenik.Prestupi[i].MinKazna = (int)numericUpDownMinKazna.Value).ToString(),
                (this.Zatvorenik.Prestupi[i].MaxKazna = (int)numericUpDownMaxKazna.Value).ToString(),
                (this.Zatvorenik.Prestupi[i].DatumPrestupa = dateTimePickerDatumPrestupa.Value).ToString(),
                this.Zatvorenik.Prestupi[i].Opis = richTextBoxOpis.Text
            }));

            listViewPrestupi.Focus();
        }

        private void buttonIzaberiAdvokata_Click(object sender, EventArgs e)
        {
            if (!ValidacijaAdvokata())
                return;

            AdvokatBasic a = Advokati[comboBoxAdvokati.SelectedIndex];
            ZastupaBasic z = new ZastupaBasic(dateTimePickerDatumPocetkaSaradnje.Value, dateTimePickerDatumPoslednjegKontakta.Value, this.Zatvorenik, a);

            if (this.Zatvorenik.Zastupa.Contains(z))
            {
                MessageBox.Show(this,
                    "Advokat već zastupa zatvorenika!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            comboBoxAdvokati.SelectedIndex = -1;
            dateTimePickerDatumPocetkaSaradnje.Value = DateTime.Now;
            dateTimePickerDatumPoslednjegKontakta.Value = DateTime.Now;

            this.Zatvorenik.Zastupa.Add(z);
            listViewAdvokati.Items.Add(new ListViewItem(new string[] {
                a.JMBG,
                a.Ime,
                a.Prezime,
                a.Pol,
                z.DatumPocetkaSaradnje.ToString(),
                z.DatumPoslednjegKontakta.ToString()
            }));

            listViewAdvokati.Focus();
        }

        private void buttonOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDodajZatvorenika_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (DialogResult != DialogResult.OK && 
                MessageBox.Show(this,
                "Jeste li sigurni da želite otkazati unos novog zatvorenika?\nUneti podaci neće biti sačuvani!",
                "Pitanje",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No);
        }

        private void comboBoxAdvokati_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonIzaberiAdvokata.Enabled = comboBoxAdvokati.SelectedIndex >= 0;
        }

        private void listViewAdvokati_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonIzmeniAdvokata.Enabled =
            buttonPregledPoseta.Enabled = 
            listViewAdvokati.SelectedItems.Count == 1;
            buttonUkloniAdvokata.Enabled = listViewAdvokati.SelectedItems.Count >= 1;
            buttonUkloniAdvokata.Text = listViewAdvokati.SelectedItems.Count <= 1 ? "Ukloni advokata" : "Ukloni advokate";
        }

        private void listViewPrestupi_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonIzmeniPrestup.Enabled = listViewPrestupi.SelectedItems.Count == 1;
            buttonUkloniPrestup.Enabled = listViewPrestupi.SelectedItems.Count >= 1;
            buttonUkloniPrestup.Text = listViewPrestupi.SelectedItems.Count <= 1 ? "Ukloni prestup" : "Ukloni prestupe";
        }

        private void buttonDodajZatvorenika_Click(object sender, EventArgs e)
        {
            if (!ValidacijaZatvorenika())
                return;

            Zatvorenik.JMBG = textBoxJMBG.Text;
            Zatvorenik.Ime = textBoxIme.Text;
            Zatvorenik.Prezime = textBoxPrezime.Text;
            Zatvorenik.Pol = comboBoxPol.SelectedIndex == 0 ? "M" : "Ž";
            Zatvorenik.Adresa = textBoxAdresa.Text;

            Zatvorenik.Broj = textBoxBroj.Text;
            Zatvorenik.DatumInkarceracije = dateTimePickerInkarceracija.Value;
            Zatvorenik.DatumSledecegSaslusanja = dateTimePickerSledeceSaslusanje.Value;
            Zatvorenik.StatusUslovnogOtpusta = comboBoxStatusUslovnogOtpusta.Text;

            Zatvorenik.ZatvorskaJedinica = ZatvorskeJedinice[comboBoxZatvorskaJedinica.SelectedIndex];

            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void comboBoxZatvorskaJedinica_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDodajZatvorenika.Enabled = comboBoxZatvorskaJedinica.SelectedIndex >= 0;
        }

        private void buttonIzmeniAdvokata_Click(object sender, EventArgs e)
        {
            int val = listViewAdvokati.SelectedIndices[0];

            comboBoxAdvokati.SelectedIndex = Advokati.IndexOf(Zatvorenik.Zastupa[val].Advokat);
            dateTimePickerDatumPocetkaSaradnje.Value = Zatvorenik.Zastupa[val].DatumPocetkaSaradnje;
            dateTimePickerDatumPoslednjegKontakta.Value = (DateTime) Zatvorenik.Zastupa[val].DatumPoslednjegKontakta;

            comboBoxAdvokati.Enabled =
            buttonIzmeniAdvokata.Enabled =
            buttonUkloniAdvokata.Enabled =
            listViewAdvokati.Enabled = false;

            buttonSacuvajIzmeneAdvokata.Show();
            buttonEvidentirajAdvokata.Hide();

            dateTimePickerDatumPocetkaSaradnje.Focus();
        }

        private void buttonIzmeniPrestup_Click(object sender, EventArgs e)
        {
            int val = listViewPrestupi.SelectedIndices[0];

            textBoxPunNaziv.Text = Zatvorenik.Prestupi[val].PunNaziv;
            textBoxKategorija.Text = Zatvorenik.Prestupi[val].Kategorija;
            textBoxMestoPrestupa.Text = Zatvorenik.Prestupi[val].MestoPrestupa;
            numericUpDownMinKazna.Value = Zatvorenik.Prestupi[val].MinKazna;
            numericUpDownMaxKazna.Value = Zatvorenik.Prestupi[val].MaxKazna;
            dateTimePickerDatumPrestupa.Value = Zatvorenik.Prestupi[val].DatumPrestupa;
            richTextBoxOpis.Text = Zatvorenik.Prestupi[val].Opis;

            listViewPrestupi.Enabled =
            buttonIzmeniPrestup.Enabled =
            buttonUkloniPrestup.Enabled = false;

            buttonSacuvajIzmenePrestup.Show();
            buttonDodajPrestup.Hide();

            textBoxPunNaziv.Focus();
        }

        private void buttonSacuvajIzmenePrestup_Click(object sender, EventArgs e)
        {
            if (ValidacijaPrestupa())
            {
                int val = listViewPrestupi.SelectedIndices[0];

                listViewPrestupi.Items[listViewPrestupi.SelectedIndices[0]] = new ListViewItem(new string[]
                {
                    Zatvorenik.Prestupi[val].PunNaziv = textBoxPunNaziv.Text,
                    Zatvorenik.Prestupi[val].Kategorija = textBoxKategorija.Text,
                    Zatvorenik.Prestupi[val].MestoPrestupa = textBoxMestoPrestupa.Text,
                    (Zatvorenik.Prestupi[val].MinKazna = (int) numericUpDownMinKazna.Value).ToString(),
                    (Zatvorenik.Prestupi[val].MaxKazna = (int) numericUpDownMaxKazna.Value).ToString(),
                    (Zatvorenik.Prestupi[val].DatumPrestupa = dateTimePickerDatumPrestupa.Value).ToString(),
                    Zatvorenik.Prestupi[val].Opis = richTextBoxOpis.Text
                });

                OcistiPrestup();

                buttonIzmeniPrestup.Enabled =
                buttonUkloniPrestup.Enabled =
                listViewPrestupi.Enabled = true;

                buttonSacuvajIzmenePrestup.Hide();
                buttonDodajPrestup.Show();

                listViewPrestupi.Focus();
            }
        }

        private void buttonUkloniPrestup_Click(object sender, EventArgs e)
        {
            List<PrestupBasic> forRemove = new List<PrestupBasic>();
            List<ListViewItem> lvi = new List<ListViewItem>();
            foreach (int i in listViewPrestupi.SelectedIndices)
            {
                forRemove.Add(Zatvorenik.Prestupi[i]);
                lvi.Add(listViewPrestupi.Items[i]);
            }

            int index = 0;
            foreach (PrestupBasic fR in forRemove)
            {
                Zatvorenik.Prestupi.Remove(fR);
                listViewPrestupi.Items.Remove(lvi[index++]);
            }

            listViewPrestupi.Focus();
        }

        private void buttonSacuvajIzmeneAdvokata_Click(object sender, EventArgs e)
        {
            if (!ValidacijaAdvokata())
                return;

            int val = listViewAdvokati.SelectedIndices[0];

            Zatvorenik.Zastupa[val].DatumPocetkaSaradnje = dateTimePickerDatumPocetkaSaradnje.Value;
            Zatvorenik.Zastupa[val].DatumPoslednjegKontakta = dateTimePickerDatumPoslednjegKontakta.Value;

            AdvokatBasic a = Zatvorenik.Zastupa[val].Advokat;

            listViewAdvokati.Items[val] = new ListViewItem(new string[] {
                a.JMBG,
                a.Ime,
                a.Prezime,
                a.Pol,
                Zatvorenik.Zastupa[val].DatumPocetkaSaradnje.ToString(),
                Zatvorenik.Zastupa[val].DatumPoslednjegKontakta.ToString()
            });

            comboBoxAdvokati.Enabled =
            buttonIzmeniAdvokata.Enabled =
            buttonUkloniAdvokata.Enabled =
            listViewAdvokati.Enabled = true;

            buttonSacuvajIzmeneAdvokata.Hide();
            buttonEvidentirajAdvokata.Show();

            listViewAdvokati.Focus();
        }

        private void buttonUkloniAdvokata_Click(object sender, EventArgs e)
        {
            List<ZastupaBasic> forDel = new List<ZastupaBasic>();
            List<ListViewItem> lvi = new List<ListViewItem>();
            foreach (int i in listViewAdvokati.SelectedIndices)
            {
              forDel.Add(Zatvorenik.Zastupa[i]);
              lvi.Add(listViewAdvokati.Items[i]);
            }

            int ind = 0;
            foreach (ZastupaBasic z in forDel)
            {
                Zatvorenik.Zastupa.Remove(z);
                listViewAdvokati.Items.Remove(lvi[ind++]);
            }

            listViewAdvokati.Focus();
        }



        private bool ValidacijaPrestupa()
        {
            if (String.IsNullOrEmpty(textBoxPunNaziv.Text))
            {
                MessageBox.Show(this,
                    "Naziv prestupa ne sme biti prazan!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(textBoxKategorija.Text))
            {
                MessageBox.Show(this,
                    "Kategorija prestupa ne sme biti prazna!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(textBoxMestoPrestupa.Text))
            {
                MessageBox.Show(this,
                    "Mesto prestupa ne sme biti prazno!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (numericUpDownMaxKazna.Value < 0 || numericUpDownMinKazna.Value < 0)
            {
                MessageBox.Show(this,
                    "Kazna mora biti veća od 0!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (numericUpDownMaxKazna.Value < numericUpDownMinKazna.Value)
            {
                MessageBox.Show(this,
                    "Maksimalna kazna ne sme biti manja od minimalne!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (dateTimePickerDatumPrestupa.Value > DateTime.Now)
            {
                MessageBox.Show(this,
                   "Datum prestupa ne može biti u budućnosti!",
                   "Greška",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(richTextBoxOpis.Text))
            {
                MessageBox.Show(this,
                   "Niste uneli opis prestupa!",
                   "Greška",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void OcistiPrestup()
        {
            textBoxPunNaziv.Clear();
            textBoxKategorija.Clear();
            textBoxMestoPrestupa.Clear();
            numericUpDownMinKazna.Value = 0;
            numericUpDownMaxKazna.Value = 0;
            dateTimePickerDatumPrestupa.Value = DateTime.Now;
            richTextBoxOpis.Clear();
        }

        private bool ValidacijaAdvokata()
        {
            if (comboBoxAdvokati.SelectedIndex < 0)
            {
                MessageBox.Show(this,
                    "Uzaberite advokata iz liste evidentiranih advokata ili evidentirajte novog advokata",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (dateTimePickerDatumPocetkaSaradnje.Value > DateTime.Now)
            {
                MessageBox.Show(this,
                    "Datum početka saradnje ne može biti u budućnosti!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (dateTimePickerDatumPoslednjegKontakta.Value > DateTime.Now)
            {
                MessageBox.Show(this,
                    "Datum poslednjeg kontakta ne može biti u budućnosti!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool ValidacijaZatvorenika()
        {
            if (comboBoxPol.SelectedIndex < 0)
            {
                MessageBox.Show(this,
                    "Niste izabrali pol!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (comboBoxStatusUslovnogOtpusta.SelectedIndex < 0)
            {
                MessageBox.Show(this,
                     "Niste izabrali status uslovnog otpusta!",
                     "Greška",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
                return false;
            }
            if (comboBoxZatvorskaJedinica.SelectedIndex < 0)
            {
                MessageBox.Show(this,
                    "Niste izabrali zatvorsku jedinicu!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (Zatvorenik.Prestupi.Count < 1)
            {
                MessageBox.Show(this,
                    "Niste uneli nijedan prestup zatvoreniku!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (Zatvorenik.Zastupa.Count < 1)
            {
                MessageBox.Show(this,
                    "Niste evidentirali nijednog advokata zatvoreniku!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(textBoxJMBG.Text))
            {
                MessageBox.Show(this,
                      "Niste uneli JMBG zatvorenika!",
                      "Greška",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                return false;
            }
            if (textBoxJMBG.Text.Length != 13)
            {
                MessageBox.Show(this,
                      "JMBG mora biti 13 karaktera!",
                      "Greška",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                return false;
            }
            if (String.IsNullOrEmpty(textBoxIme.Text))
            {
                MessageBox.Show(this,
                       "Niste uneli ime zatvorenika!",
                       "Greška",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                return false;
            }
            if (String.IsNullOrEmpty(textBoxPrezime.Text))
            {
                MessageBox.Show(this,
                      "Niste uneli prezime zatvorenika!",
                      "Greška",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                return false;
            }
            if (String.IsNullOrEmpty(textBoxBroj.Text))
            {
                MessageBox.Show(this,
                      "Niste uneli broj zatvorenika!",
                      "Greška",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                return false;
            }
            if (textBoxBroj.Text.Length != 5)
            {
                MessageBox.Show(this,
                      "Broj zatvorenika je 5 karaktera!",
                      "Greška",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void buttonEvidentirajAdvokata_Click(object sender, EventArgs e)
        {
            Form f = new FormDodajAdvokata();
            f.ShowDialog();
        }

        private void buttonPregledPoseta_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Zatvorenik.Ime = textBoxIme.Text))
            {
                MessageBox.Show(this,
                    "Morate uneti ime zatvorenika da biste pristupili ovoj opciji!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(Zatvorenik.Prezime = textBoxPrezime.Text))
            {
                MessageBox.Show(this,
                       "Morate uneti prezime zatvorenika da biste pristupili ovoj opciji!",
                       "Greška",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(Zatvorenik.JMBG = textBoxJMBG.Text) || Zatvorenik.JMBG.Length != 13)
            {
                MessageBox.Show(this,
                      "Morate uneti ispravan JMBG zatvorenika da biste pristupili ovoj opciji!",
                      "Greška",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                return;
            }

            textBoxJMBG.Enabled = textBoxIme.Enabled = textBoxPrezime.Enabled = false;

            Form f = new FormPregledPoseta(Zatvorenik, Zatvorenik.Zastupa[listViewAdvokati.SelectedIndices[0]].Advokat, false);
            f.ShowDialog();
        }
    }
}
