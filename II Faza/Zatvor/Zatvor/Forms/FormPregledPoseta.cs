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

        private bool _commit;
        private bool _browse;
        public FormPregledPoseta(ZatvorenikBasic Z, AdvokatBasic A, bool Commit = false, bool Browse = false)
        {
            Zatvorenik = Z;
            Advokat = A;
            _commit = Commit;
            _browse = Browse;
            InitializeComponent();
        }
        public FormPregledPoseta(bool Commit = true, bool Browse = true)
        {
            Zatvorenik = null; 
            Advokat = null;
            _commit = Commit;
            _browse = Browse;
            InitializeComponent();
        }

        private void FormPregledPoseta_Load(object sender, EventArgs e)
        {
            buttonSacuvajIzmene.Hide();
            buttonIzmeniPosetu.Enabled =
            buttonObrisiPosetu.Enabled = false;

            dateTimePickerKraj.Format =
            dateTimePickerPocetak.Format =
            DateTimePickerFormat.Time;

            listViewPosete.View = View.Details;
            listViewPosete.GridLines = true;
            listViewPosete.FullRowSelect = true;
            listViewPosete.Alignment = ListViewAlignment.SnapToGrid;
            listViewPosete.Columns.Add(new ColumnHeader(0)
            {
                Text = "Datum posete",
                TextAlign = HorizontalAlignment.Center,
                Width = listViewPosete.Width / 3
            });
            listViewPosete.Columns.Add(new ColumnHeader(1)
            {
                Text = "Vreme početka posete",
                TextAlign = HorizontalAlignment.Center,
                Width = listViewPosete.Width / 3
            });
            listViewPosete.Columns.Add(new ColumnHeader(2)
            {
                Text = "Vreme kraja posete",
                TextAlign = HorizontalAlignment.Center,
                Width = listViewPosete.Width / 3
            });

            if (_browse)
            {
                Zatvorenici = DTOManager.ReadAllZatvorenici();
                Zatvorenici.ForEach(z =>
                {
                    comboBoxZatvorenik.Items.Add(z.Ime + " " + z.Prezime + " [" + z.JMBG + "]");
                    z.Posete = DTOManager.ReadAllPoseteForZatvorenik(z);
                });

                Advokati = DTOManager.ReadAllAdvokati();
                Advokati.ForEach(a => comboBoxAdvokat.Items.Add(a.Ime + " " + a.Prezime + " [" + a.JMBG + "]"));
            }
            else
            {
                comboBoxZatvorenik.Items.Add(Zatvorenik.Ime + " " + Zatvorenik.Prezime + " [" + Zatvorenik.JMBG + "]");
                comboBoxAdvokat.Items.Add(Advokat.Ime + " " + Advokat.Prezime + " [" + Advokat.JMBG + "]");

                comboBoxAdvokat.SelectedIndex = 0;
                comboBoxZatvorenik.SelectedIndex = 0;

                UcitajPosete();
            }

            comboBoxAdvokat.Enabled =
                comboBoxZatvorenik.Enabled =
                buttonUcitajPosete.Enabled = _browse;
        }

        private void buttonUcitajPosete_Click(object sender, EventArgs e)
        {
            if (!ValidniPodaci())
                return;

            Advokat = Advokati[comboBoxAdvokat.SelectedIndex];
            Zatvorenik = Zatvorenici[comboBoxZatvorenik.SelectedIndex];

            UcitajPosete();
        }

        private void listViewPosete_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val = listViewPosete.SelectedItems.Count;
            buttonIzmeniPosetu.Enabled = val == 1;
            buttonObrisiPosetu.Enabled = val >= 1;
            buttonObrisiPosetu.Text = val > 1 ? "Obriši posete" : "Obriši posetu";
        }

        private void buttonDodajPosetu_Click(object sender, EventArgs e)
        {
            if (!ValidniPodaci())
                return;

            DateTime pocetak, kraj;
            UcitajDatume(out pocetak, out kraj);

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

            if (_commit == true)
                DTOManager.CreatePoseta(poseta);
            
            Zatvorenik.Posete.Add(poseta);
            listViewPosete.Items.Add(new ListViewItem(new string[]
            {
                poseta.DTPocetka.ToLongDateString(),
                poseta.DTPocetka.ToLongTimeString(),
                poseta.DTKraja.ToLongTimeString()
            }));
        }

        private void buttonIzmeniPosetu_Click(object sender, EventArgs e)
        {
            buttonDodajPosetu.Hide();
            buttonSacuvajIzmene.Show();

            buttonUcitajPosete.Enabled =
            comboBoxAdvokat.Enabled =
            comboBoxZatvorenik.Enabled =
            buttonObrisiPosetu.Enabled = false;

            dateTimePickerDan.Value = DateTime.Parse(listViewPosete.SelectedItems[0].SubItems[0].Text);
            dateTimePickerPocetak.Value = DateTime.Parse(listViewPosete.SelectedItems[0].SubItems[1].Text);
            dateTimePickerKraj.Value = DateTime.Parse(listViewPosete.SelectedItems[0].SubItems[2].Text); 
        }

        private void buttonSacuvajIzmene_Click(object sender, EventArgs e)
        {
            if (!ValidniPodaci())
                return;

            DateTime pocetak, kraj;
            UcitajDatume(out pocetak, out kraj);

            int val = listViewPosete.SelectedIndices[0];

            Zatvorenik.Posete[val].DTPocetka = pocetak;
            Zatvorenik.Posete[val].DTKraja = kraj;

            listViewPosete.SelectedItems[0].SubItems[0].Text = dateTimePickerDan.Value.ToLongDateString();
            listViewPosete.SelectedItems[0].SubItems[1].Text = dateTimePickerKraj.Value.ToLongTimeString();
            listViewPosete.SelectedItems[0].SubItems[2].Text = dateTimePickerPocetak.Value.ToLongTimeString();

            if (_commit)
                DTOManager.UpdatePoseta(Zatvorenik.Posete[val]);

            buttonDodajPosetu.Show();
            buttonSacuvajIzmene.Hide();

            buttonUcitajPosete.Enabled =
            comboBoxAdvokat.Enabled =
            comboBoxZatvorenik.Enabled = _commit;
            buttonObrisiPosetu.Enabled = true;
        }

        private void buttonObrisiPosetu_Click(object sender, EventArgs e)
        {
            List<PosecujeBasic> forDel = new List<PosecujeBasic>();
            List<ListViewItem> lvi = new List<ListViewItem>();
            foreach (int i in listViewPosete.SelectedIndices)
            {
                forDel.Add(Zatvorenik.Posete[i]);
                lvi.Add(listViewPosete.Items[i]);
            }

            int ind = 0;
            foreach (PosecujeBasic p in forDel)
            {
                Zatvorenik.Posete.Remove(p);
                listViewPosete.Items.Remove(lvi[ind++]);
                if(_commit)
                    DTOManager.DeletePoseta(p);
            }
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
            if (dateTimePickerDan.Value > DateTime.Now)
            {
                MessageBox.Show(this,
                    "Datum ne može biti u budućnosti!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (dateTimePickerDan.Value.Year == DateTime.Now.Year
                && dateTimePickerDan.Value.Month == DateTime.Now.Month
                && dateTimePickerDan.Value.Day == DateTime.Now.Day)
            {
                if (dateTimePickerPocetak.Value.Hour * 3600
                    + dateTimePickerPocetak.Value.Minute * 60
                    + dateTimePickerPocetak.Value.Second >
                    DateTime.Now.Hour * 3600
                    + DateTime.Now.Minute * 60
                    + DateTime.Now.Second)
                {
                    MessageBox.Show(this,
                        "Vreme početka posete ne može biti u budućnosti!",
                        "Greška",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                if (dateTimePickerKraj.Value.Hour * 3600
                    + dateTimePickerKraj.Value.Minute * 60
                    + dateTimePickerKraj.Value.Second >
                    DateTime.Now.Hour * 3600
                    + DateTime.Now.Minute * 60
                    + DateTime.Now.Second)
                {
                    MessageBox.Show(this,
                        "Vreme kraja posete ne može biti u budućnosti!",
                        "Greška",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private void UcitajDatume(out DateTime pocetak, out DateTime kraj)
        {
            pocetak = new DateTime(
                dateTimePickerDan.Value.Year,
                dateTimePickerDan.Value.Month,
                dateTimePickerDan.Value.Day,
                dateTimePickerPocetak.Value.Hour,
                dateTimePickerPocetak.Value.Minute,
                dateTimePickerPocetak.Value.Second);

            kraj = new DateTime(
                dateTimePickerDan.Value.Year,
                dateTimePickerDan.Value.Month,
                dateTimePickerDan.Value.Day,
                dateTimePickerKraj.Value.Hour,
                dateTimePickerKraj.Value.Minute,
                dateTimePickerKraj.Value.Second);
        }

        private void UcitajPosete()
        {
            listViewPosete.Items.Clear();

            bool test = false;
            foreach (PosecujeBasic p in Zatvorenik.Posete)
            {
                if (test |= p.Advokat.JMBG == Advokat.JMBG)
                    listViewPosete.Items.Add(new ListViewItem(new string[]
                    {
                        p.DTPocetka.ToLongDateString(),
                        p.DTPocetka.ToLongTimeString(),
                        p.DTKraja.ToLongTimeString()
                    }));
            }

            if (!test)
                MessageBox.Show("Izabrani par zatvorenika i advokata nemaju nijednu posetu!");
        }
    }
}
