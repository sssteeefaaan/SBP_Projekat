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
    public partial class FormPregledPoseta : Form
    {
        private ZatvorenikBasic Zatvorenik { get; set; }
        private AdvokatBasic Advokat { get; set; }
        private List<AdvokatBasic> Advokati { get; set; }
        private List<ZatvorenikBasic> Zatvorenici { get; set; }
        public FormPregledPoseta(ZatvorenikBasic Z, AdvokatBasic A)
        {
            Zatvorenik = Z;
            Advokat = A;
            Zatvorenik.Posete = DTOManager.ReadAllPosecujeFor(Zatvorenik);
            Advokati = new List<AdvokatBasic>() { A };
            Zatvorenici = new List<ZatvorenikBasic>() { Z };
            InitializeComponent();
        }
        public FormPregledPoseta()
        {
            Zatvorenik = null; 
            Advokat = null;
            Advokati = DTOManager.ReadAllAdvokat();
            Zatvorenici = DTOManager.ReadAllZatvorenik();
            InitializeComponent();
        }

        private void FormPregledPoseta_Load(object sender, EventArgs e)
        {
            buttonSacuvajIzmene.Hide();
            buttonUcitajPosete.Enabled =
            buttonDodajPosetu.Enabled =
            buttonIzmeniPosetu.Enabled =
            buttonObrisiPosetu.Enabled =
            listViewPosete.Enabled = false;

            dateTimePickerKraj.Format =
            dateTimePickerPocetak.Format =
            DateTimePickerFormat.Custom;

            dateTimePickerKraj.CustomFormat =
                dateTimePickerPocetak.CustomFormat = "HH:mm  dd.MMM.yyyy";

            listViewPosete.View = View.Details;
            listViewPosete.GridLines =
            listViewPosete.FullRowSelect =
            listViewPosete.MultiSelect = true;

            listViewPosete.Alignment = ListViewAlignment.SnapToGrid;
            SetView();

            if (Advokat != null && Zatvorenik != null)
            {
                comboBoxAdvokat.SelectedItem = Advokat.Ime + " " + Advokat.Prezime + " [" + Advokat.JMBG + "]"; 
                comboBoxZatvorenik.SelectedItem = Zatvorenik.Ime + " " + Zatvorenik.Prezime + " [" + Zatvorenik.JMBG + "]";

                OsveziPrikaz();
                buttonUcitajPosete.Enabled = false;
            }

            comboBoxAdvokat.Enabled =
            comboBoxZatvorenik.Enabled = Advokat == null || Zatvorenik == null;
        }
        private void SetView()
        {
            listViewPosete.Columns.Clear();

            listViewPosete.Columns.Add(new ColumnHeader(0)
            {
                Text = "",
                TextAlign = HorizontalAlignment.Center,
                Width = 0
            });
            listViewPosete.Columns.Add(new ColumnHeader(1)
            {
                Text = "Vreme početka posete",
                TextAlign = HorizontalAlignment.Center,
                Width = listViewPosete.Width / 2 - 5
            });
            listViewPosete.Columns.Add(new ColumnHeader(2)
            {
                Text = "Vreme kraja posete",
                TextAlign = HorizontalAlignment.Center,
                Width = listViewPosete.Width / 2 - 5
            });


            Zatvorenici.ForEach(z =>
            {
                comboBoxZatvorenik.Items.Add(z.Ime + " " + z.Prezime + " [" + z.JMBG + "]");
                z.Posete = DTOManager.ReadAllPosecujeFor(z);
            });

            Advokati.ForEach(a => comboBoxAdvokat.Items.Add(a.Ime + " " + a.Prezime + " [" + a.JMBG + "]"));
        }
        private void buttonUcitajPosete_Click(object sender, EventArgs e)
        {
            if (!ValidniPodaci())
                return;

            Advokat = Advokati[comboBoxAdvokat.SelectedIndex];
            Zatvorenik = Zatvorenici[comboBoxZatvorenik.SelectedIndex];

            OsveziPrikaz();
            buttonUcitajPosete.Enabled = false;
        }

        private void listViewPosete_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetButtons(listViewPosete.SelectedItems.Count);
        }

        private void buttonDodajPosetu_Click(object sender, EventArgs e)
        {
            if (!ValidniPodaci())
                return;

            DateTime pocetak = dateTimePickerPocetak.Value;
            DateTime kraj = dateTimePickerKraj.Value;

            PosecujeBasic poseta = new PosecujeBasic(pocetak, kraj, Zatvorenik, Advokat);
            if (Zatvorenik.Posete.Contains(poseta))
            {
                MessageBox.Show(this,
                    "Poseta je već unešena!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            DTOManager.CreatePoseta(poseta);
            
            Zatvorenik.Posete.Add(poseta);
            listViewPosete.Items.Add(new ListViewItem(new string[]
            {
                poseta.ID.ToString(),
                poseta.DTPocetka.ToString(),
                poseta.DTKraja.ToString()
            })) ;

            ResetButtons();
        }

        private void buttonIzmeniPosetu_Click(object sender, EventArgs e)
        {
            buttonDodajPosetu.Hide();
            buttonSacuvajIzmene.Show();

            comboBoxAdvokat.Enabled =
            comboBoxZatvorenik.Enabled =
            buttonIzmeniPosetu.Enabled =
            buttonObrisiPosetu.Enabled = false;

            dateTimePickerPocetak.Value = DateTime.Parse(listViewPosete.SelectedItems[0].SubItems[1].Text);
            dateTimePickerKraj.Value = DateTime.Parse(listViewPosete.SelectedItems[0].SubItems[2].Text);
        }

        private void buttonSacuvajIzmene_Click(object sender, EventArgs e)
        {
            if (!ValidniPodaci())
                return;

            DateTime pocetak = dateTimePickerPocetak.Value;
            DateTime kraj = dateTimePickerKraj.Value;

            int val = listViewPosete.SelectedIndices[0];

            PosecujeBasic p = Zatvorenik.Posete.Find(poseta => poseta.ID == int.Parse(listViewPosete.SelectedItems[0].Text));

            p.DTPocetka = pocetak;
            p.DTKraja = kraj;

            listViewPosete.SelectedItems[0].SubItems[1].Text = dateTimePickerPocetak.Value.ToString();
            listViewPosete.SelectedItems[0].SubItems[2].Text = dateTimePickerKraj.Value.ToString();

            DTOManager.UpdatePoseta(p);

            buttonDodajPosetu.Show();
            buttonSacuvajIzmene.Hide();

            comboBoxAdvokat.Enabled =
            comboBoxZatvorenik.Enabled =
            listViewPosete.Enabled = true;
        }

        private void buttonObrisiPosetu_Click(object sender, EventArgs e)
        {
            int forDel;
            foreach (ListViewItem lvi in listViewPosete.SelectedItems)
            {
                forDel = Zatvorenik.Posete.FindIndex(p => p.ID == int.Parse(lvi.Text));
                DTOManager.DeletePoseta(Zatvorenik.Posete[forDel]);
                Zatvorenik.Posete.RemoveAt(forDel);
            }

            OsveziPrikaz();
            ResetButtons();
        }
        private bool ValidniPodaci()
        {
            if (comboBoxAdvokat.SelectedIndex < 0)
            {
                MessageBox.Show(this,
                      "Nevalidno selektovan advokat!",
                      "Greška",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                return false;
            }
            if (comboBoxZatvorenik.SelectedIndex < 0)
            {
                MessageBox.Show(this,
                      "Nevalidno selektovan zatvorenik!",
                      "Greška",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                return false;
            }
            if (dateTimePickerPocetak.Value > DateTime.Now || dateTimePickerKraj.Value > DateTime.Now)
            {
                MessageBox.Show(this,
                    "Datum ne može biti u budućnosti!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (dateTimePickerPocetak.Value > dateTimePickerKraj.Value)
            {
                MessageBox.Show(this,
                    "Vreme početka je nakon vremena kraja!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (dateTimePickerKraj.Value - dateTimePickerPocetak.Value > new TimeSpan(5,0,0))
            {
                MessageBox.Show(this,
                    "Poseta ne sme biti duža od 5 sati!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void OsveziPrikaz()
        {
            listViewPosete.Items.Clear();
            buttonDodajPosetu.Enabled = 
            listViewPosete.Enabled = true;

            bool test = false;
            foreach (PosecujeBasic p in Zatvorenik.Posete)
            {
                if (test |= p.Advokat.JMBG == Advokat.JMBG)
                    listViewPosete.Items.Add(new ListViewItem(new string[]
                    {
                        p.ID.ToString(),
                        p.DTPocetka.ToString(),
                        p.DTKraja.ToString()
                    }));
            }

            if (!test)
                MessageBox.Show("Izabrani par zatvorenika i advokata nemaju nijednu posetu!");
        }

        private void comboBoxZatvorenik_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewPosete.Items.Clear();
            buttonDodajPosetu.Enabled = false;
            buttonUcitajPosete.Enabled = true;
        }

        private void comboBoxAdvokat_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewPosete.Items.Clear();
            buttonDodajPosetu.Enabled = false;
            buttonUcitajPosete.Enabled = true;
        }
        private void ResetButtons(int val = 0)
        {
            buttonIzmeniPosetu.Enabled = val == 1;
            buttonObrisiPosetu.Enabled = val >= 1;
            buttonObrisiPosetu.Text = val > 1 ? "Obriši posete" : "Obriši posetu";
        }
    }
}
