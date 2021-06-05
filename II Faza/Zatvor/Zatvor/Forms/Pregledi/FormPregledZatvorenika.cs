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
using Zatvor.Forms.Pregledi;

namespace Zatvor.Forms.Pregledi
{
    public partial class FormPregledZatvorenika : Form
    {
        public ZatvorenikBasic Zatvorenik { get; set; }
        private List<AdvokatBasic> Advokati { get; set; }
        public FormPregledZatvorenika(ZatvorenikBasic z)
        {
            Zatvorenik = z;
            InitializeComponent();
        }
        private void FormPregledZatvorenika_Load(object sender, EventArgs e)
        {
            Text = "Pregled zatvorenika '" + Zatvorenik.Broj + "'";
            buttonIzmeniPrestup.Enabled =
            buttonUkloniPrestup.Enabled =
            buttonIzmeniAdvokata.Enabled =
            buttonPregledPoseta.Enabled =
            buttonUkloniAdvokata.Enabled = false;

            UcitajPodatke();
            SetView();
            OsveziPrikaz();
        }

        private void buttonDodajPrestup_Click(object sender, EventArgs e)
        {
            if (!ValidacijaPrestupa())
                return;

            if (buttonDodajPrestup.Text == "Dodaj prestup")
            {
                PrestupBasic p = new PrestupBasic();

                p.Zatvorenik = Zatvorenik;
                p.PunNaziv = textBoxPunNaziv.Text;
                p.Kategorija = textBoxKategorija.Text;
                p.MestoPrestupa = textBoxMestoPrestupa.Text;
                p.MinKazna = (int)numericUpDownMinKazna.Value;
                p.MaxKazna = (int)numericUpDownMaxKazna.Value;
                p.DatumPrestupa = dateTimePickerDatumPrestupa.Value;
                p.Opis = richTextBoxOpis.Text;

                DTOManager.CreatePrestup(p);
                Zatvorenik.Prestupi.Add(p);
            }
            else
            {
                int val = Zatvorenik.Prestupi.FindIndex(p => p.ID == int.Parse(listViewPrestupi.SelectedItems[0].Text));

                Zatvorenik.Prestupi[val].PunNaziv = textBoxPunNaziv.Text;
                Zatvorenik.Prestupi[val].Kategorija = textBoxKategorija.Text;
                Zatvorenik.Prestupi[val].MestoPrestupa = textBoxMestoPrestupa.Text;
                Zatvorenik.Prestupi[val].MinKazna = (int)numericUpDownMinKazna.Value;
                Zatvorenik.Prestupi[val].MaxKazna = (int)numericUpDownMaxKazna.Value;
                Zatvorenik.Prestupi[val].DatumPrestupa = dateTimePickerDatumPrestupa.Value;
                Zatvorenik.Prestupi[val].Opis = richTextBoxOpis.Text;

                buttonIzmeniPrestup.Enabled =
                buttonUkloniPrestup.Enabled =
                listViewPrestupi.Enabled = true;

                buttonDodajPrestup.Text = "Dodaj prestup";
            }

            OsveziPrikazPrestupa();
        }

        private void buttonIzaberiAdvokata_Click(object sender, EventArgs e)
        {
            if (!ValidacijaAdvokata())
                return;

            if (buttonIzaberiAdvokata.Text == "Izaberi advokata")
            {
                ZastupaBasic z = new ZastupaBasic(dateTimePickerDatumPocetkaSaradnje.Value,
                    dateTimePickerDatumPoslednjegKontakta.Value,
                    Zatvorenik,
                    Advokati[comboBoxAdvokati.SelectedIndex]);

                if (Zatvorenik.Zastupa.Contains(z))
                {
                    MessageBox.Show(this,
                        "Advokat već zastupa zatvorenika!",
                        "Greška",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                DTOManager.CreateZastupa(z);
                Zatvorenik.Zastupa.Add(z);
            }
            else
            {
                int val = Zatvorenik.Zastupa.FindIndex(z => z.ID == int.Parse(listViewAdvokati.SelectedItems[0].Text));

                Zatvorenik.Zastupa[val].DatumPocetkaSaradnje = dateTimePickerDatumPocetkaSaradnje.Value;
                Zatvorenik.Zastupa[val].DatumPoslednjegKontakta = dateTimePickerDatumPoslednjegKontakta.Value;

                DTOManager.UpdateZastupa(Zatvorenik.Zastupa[val]);

                comboBoxAdvokati.Enabled =
                buttonIzmeniAdvokata.Enabled =
                buttonUkloniAdvokata.Enabled =
                listViewAdvokati.Enabled = true;

                buttonIzaberiAdvokata.Text = "Izaberi advokata";
            }

            OsveziPrikazZastupanja();
        }

        private void buttonOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxAdvokati_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonIzaberiAdvokata.Enabled = comboBoxAdvokati.SelectedIndex >= 0;
        }

        private void listViewAdvokati_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val = listViewAdvokati.SelectedItems.Count;
            buttonIzmeniAdvokata.Enabled =
            buttonPregledPoseta.Enabled = val == 1;
            buttonUkloniAdvokata.Enabled = val >= 1;
            buttonUkloniAdvokata.Text = val <= 1 ? "Ukloni advokata" : "Ukloni advokate";
        }

        private void listViewPrestupi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val = listViewPrestupi.SelectedItems.Count;
            buttonIzmeniPrestup.Enabled = val == 1;
            buttonUkloniPrestup.Enabled = val >= 1;
            buttonUkloniPrestup.Text = val <= 1 ? "Ukloni prestup" : "Ukloni prestupe";
        }

        private void buttonIzmeniAdvokata_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(listViewAdvokati.SelectedItems[0].Text);
            int val = Zatvorenik.Zastupa.FindIndex(z => z.ID == ID);

            comboBoxAdvokati.SelectedIndex = Advokati.IndexOf(Zatvorenik.Zastupa[val].Advokat);
            dateTimePickerDatumPocetkaSaradnje.Value = Zatvorenik.Zastupa[val].DatumPocetkaSaradnje;
            dateTimePickerDatumPoslednjegKontakta.Value = (DateTime)Zatvorenik.Zastupa[val].DatumPoslednjegKontakta != null ? (DateTime)Zatvorenik.Zastupa[val].DatumPoslednjegKontakta : DateTime.Now;

            comboBoxAdvokati.Enabled =
            buttonIzmeniAdvokata.Enabled =
            buttonUkloniAdvokata.Enabled =
            listViewAdvokati.Enabled = false;

            buttonIzaberiAdvokata.Text = "Sačuvaj izmene";
        }

        private void buttonIzmeniPrestup_Click(object sender, EventArgs e)
        {
            int val = Zatvorenik.Prestupi.FindIndex(p => p.ID == int.Parse(listViewPrestupi.SelectedItems[0].Text));

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

            buttonDodajPrestup.Text = "Sačuvaj izmene";
        }

        private void buttonUkloniPrestup_Click(object sender, EventArgs e)
        {
            int forDel;
            foreach (ListViewItem lvi in listViewPrestupi.SelectedItems)
            {
                forDel = Zatvorenik.Prestupi.FindIndex(p => p.ID == int.Parse(lvi.Text));
                DTOManager.DeletePrestup(Zatvorenik.Prestupi[forDel]);
                Zatvorenik.Prestupi.RemoveAt(forDel);
            }

            OsveziPrikazPrestupa();
        }

        private void buttonUkloniAdvokata_Click(object sender, EventArgs e)
        {
            int forDel;
            foreach (ListViewItem lvi in listViewAdvokati.SelectedItems)
            {
                forDel = Zatvorenik.Zastupa.FindIndex(p => p.ID == int.Parse(lvi.Text));
                DTOManager.DeleteZastupa(Zatvorenik.Zastupa[forDel]);
                Zatvorenik.Zastupa.RemoveAt(forDel);
            }

            OsveziPrikazZastupanja();
        }
        private void buttonEvidentirajAdvokata_Click(object sender, EventArgs e)
        {
            FormPregledAdvokata f = new FormPregledAdvokata(Advokati);
            f.ShowDialog();

            OsveziListuAdvokata();
        }
        private void buttonPregledPoseta_Click(object sender, EventArgs e)
        {
            FormPregledPoseta f = new FormPregledPoseta(Zatvorenik, Zatvorenik.Zastupa.Find(z => z.ID == int.Parse(listViewAdvokati.SelectedItems[0].Text)).Advokat);
            f.ShowDialog();
        }
        private void SetView()
        {
            SetViewPrestupi();
            SetViewZastupanja();
        }
        private void SetViewPrestupi()
        {
            listViewPrestupi.Columns.Clear();
            string[] columns =
                {
                "",
                "Pun naziv",
                "Kategorija",
                "Minimalna kazna",
                "Maksimalna kazna",
                "Mesto prestupa",
                "Datum prestupa"
            };
            int[] vals = { 0, 200, 200, 100, 100, 300, 200 };
            for (int i = 0; i < columns.Length; i++)
                listViewPrestupi.Columns.Add(new ColumnHeader(i)
                {
                    Text = columns[i],
                    TextAlign = HorizontalAlignment.Center,
                    Width = vals[i]
                });
        }
        private void SetViewZastupanja()
        {
            listViewAdvokati.Columns.Clear();
            string[] columns =
                {
                "",
                "JMBG",
                "Ime",
                "Prezime",
                "Pol",
                "Datum početka saradnje",
                "Datum poslednjeg kontakta"
            };
            int[] vals = { 0, 150, 100, 100, 50, 300, 300 };
            for (int i = 0; i < columns.Length; i++)
                listViewAdvokati.Columns.Add(new ColumnHeader(i)
                {
                    Text = columns[i],
                    TextAlign = HorizontalAlignment.Center,
                    Width = vals[i]
                });
        }
        private void OsveziPrikaz()
        {
            OsveziPrikazPrestupa();
            OsveziPrikazZastupanja();
            OsveziListuAdvokata();
        }

        private void OsveziPrikazPrestupa()
        {
            listViewPrestupi.Items.Clear();
            foreach (PrestupBasic p in Zatvorenik.Prestupi)
                listViewPrestupi.Items.Add(new ListViewItem(new string[] {
                    p.ID.ToString(),
                    p.PunNaziv,
                    p.Kategorija,
                    p.MinKazna.ToString(),
                    p.MaxKazna.ToString(),
                    p.MestoPrestupa,
                    p.DatumPrestupa.ToString()
                }));
        }

        private void OsveziPrikazZastupanja()
        {
            listViewAdvokati.Items.Clear();
            foreach (ZastupaBasic z in Zatvorenik.Zastupa)
                listViewAdvokati.Items.Add(new ListViewItem(new string[] {
                    z.ID.ToString(),
                    z.Advokat.JMBG,
                    z.Advokat.Ime,
                    z.Advokat.Prezime,
                    z.Advokat.Pol,
                    z.DatumPocetkaSaradnje.ToString(),
                    z.DatumPoslednjegKontakta.ToString()
                }));
        }

        private void OsveziListuAdvokata()
        {
            Advokati = DTOManager.ReadAllAdvokat();
            comboBoxAdvokati.Items.Clear();
            Advokati.ForEach(a => comboBoxAdvokati.Items.Add(a.Ime + " " + a.Prezime + " [" + a.JMBG + "]"));
        }
        private void UcitajPodatke()
        {
            Advokati = DTOManager.ReadAllAdvokat();
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

    }
}
