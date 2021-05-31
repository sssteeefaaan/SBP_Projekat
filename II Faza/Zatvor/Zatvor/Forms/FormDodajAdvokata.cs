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
    public partial class FormDodajAdvokata : Form
    {
        public List<AdvokatBasic> Advokati { get; set; }
        public FormDodajAdvokata()
        {
            InitializeComponent();
        }

        private void FormDodajAdvokata_Load(object sender, EventArgs e)
        {
            buttonSacuvaj.Hide();
            buttonIzmeni.Enabled =
            buttonObrisi.Enabled = false;

            comboBoxPol.Items.Add("Muški");
            comboBoxPol.Items.Add("Ženski");

            listViewAdvokati.View = View.Details;
            listViewAdvokati.GridLines = true;
            listViewAdvokati.FullRowSelect = true;

            listViewAdvokati.Columns.Add(new ColumnHeader(0)
            {
                Text = "JMBG",
                TextAlign = HorizontalAlignment.Center,
                Width = listViewAdvokati.Width * 3 / 10
            }) ;
            listViewAdvokati.Columns.Add(new ColumnHeader(1)
            {
                Text = "Ime",
                TextAlign = HorizontalAlignment.Center,
                Width = listViewAdvokati.Width * 3 / 10
            });
            listViewAdvokati.Columns.Add(new ColumnHeader(2)
            {
                Text = "Prezime",
                TextAlign = HorizontalAlignment.Center,
                Width = listViewAdvokati.Width * 3 / 10
            });
            listViewAdvokati.Columns.Add(new ColumnHeader(3)
            {
                Text = "Pol",
                TextAlign = HorizontalAlignment.Center,
                Width = listViewAdvokati.Width / 10
            });

            textBoxIme.Focus();

            UcitajAdvokate();
        }

        private void listViewAdvokati_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = listViewAdvokati.SelectedItems.Count;
            buttonIzmeni.Enabled = count == 1;
            buttonObrisi.Enabled = count >= 1;
            buttonObrisi.Text = count > 1 ? "Obriši advokate" : "Obriši advokata";
        }

        private void buttonEvidentiraj_Click(object sender, EventArgs e)
        {
            if (!Validacija())
                return;

            AdvokatBasic a = new AdvokatBasic(
                textBoxJMBG.Text,
                textBoxIme.Text,
                textBoxPrezime.Text,
                comboBoxPol.Text == "Muško" ? "M" : "Ž");

            if (Advokati.Contains(a))
            {
                MessageBox.Show(this,
                    "Advokat je već unešen!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Advokati.Add(a);
            listViewAdvokati.Items.Add(new ListViewItem(new string[]
            {
                a.JMBG,
                a.Ime,
                a.Prezime,
                a.Pol
            }));

            DTOManager.CreateAdvokat(a);
        }

        private void buttonSacuvaj_Click(object sender, EventArgs e)
        {
            if (!Validacija())
                return;

            int ind = listViewAdvokati.SelectedIndices[0];

            Advokati[ind].Ime = textBoxIme.Text;
            Advokati[ind].Prezime = textBoxPrezime.Text;
            Advokati[ind].Pol = comboBoxPol.Text == "Muško" ? "M" : "Ž";

            listViewAdvokati.Items[ind] = new ListViewItem(new string[]
            {
                Advokati[ind].JMBG,
                Advokati[ind].Ime,
                Advokati[ind].Prezime,
                Advokati[ind].Pol
            });

            DTOManager.UpdateAdvokat(Advokati[ind]);

            buttonSacuvaj.Hide();
            buttonEvidentiraj.Show();

            textBoxJMBG.Enabled =
            buttonIzmeni.Enabled =
            buttonObrisi.Enabled =
            listViewAdvokati.Enabled = true;
        }

        private void buttonObrisi_Click(object sender, EventArgs e)
        {
            List<ListViewItem> lvi = new List<ListViewItem>();
            List<AdvokatBasic> forDel = new List<AdvokatBasic>();

            foreach (int index in listViewAdvokati.SelectedIndices)
            {
                lvi.Add(listViewAdvokati.Items[index]);
                forDel.Add(Advokati[index]);
            }

            int i = 0;
            foreach (AdvokatBasic a in forDel)
            {
                listViewAdvokati.Items.Remove(lvi[i++]);
                Advokati.Remove(a);
                DTOManager.DeleteAdvokat(a);
            }
        }

        private void buttonIzmeni_Click(object sender, EventArgs e)
        {
            buttonSacuvaj.Show();
            buttonEvidentiraj.Hide();

            textBoxJMBG.Enabled =
            buttonIzmeni.Enabled =
            buttonObrisi.Enabled =
            listViewAdvokati.Enabled = false;

            int ind = listViewAdvokati.SelectedIndices[0];

            textBoxJMBG.Text = Advokati[ind].JMBG;
            textBoxIme.Text = Advokati[ind].Ime;
            textBoxPrezime.Text = Advokati[ind].Prezime;
            comboBoxPol.SelectedIndex = Advokati[ind].Pol == "M" ? 0 : 1;
        }
        private void UcitajAdvokate()
        {
            Advokati = DTOManager.ReadAllAdvokati();

            Advokati.ForEach(a =>
            {
                listViewAdvokati.Items.Add(new ListViewItem(new string[]
                {
                    a.JMBG,
                    a.Ime,
                    a.Prezime,
                    a.Pol
                }));
            });
        }

        private bool Validacija()
        {
            if (String.IsNullOrEmpty(textBoxJMBG.Text))
            {
                MessageBox.Show(this,
                    "Niste uneli JMBG advokata!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (textBoxJMBG.Text.Length != 13)
            {
                MessageBox.Show(this,
                    "JMBG mora da bude tačno 13 karaktera!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (String.IsNullOrEmpty(textBoxIme.Text))
            {
                MessageBox.Show(this,
                      "Niste uneli ime advokata!",
                      "Greška",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                return false;
            }
            if (String.IsNullOrEmpty(textBoxPrezime.Text))
            {
                MessageBox.Show(this,
                      "Niste uneli prezime advokata",
                      "Greška",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                return false;
            }
            if (comboBoxPol.SelectedIndex < 0)
            {
                MessageBox.Show(this,
                      "Niste odabrali pol advokata!",
                      "Greška",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
