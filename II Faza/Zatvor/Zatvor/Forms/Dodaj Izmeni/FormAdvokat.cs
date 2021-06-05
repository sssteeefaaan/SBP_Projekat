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
    public partial class FormAdvokat : Form
    {
        public List<AdvokatBasic> Advokati { get; set; }
        public AdvokatBasic Advokat { get; set; }
        private string _view;
        public FormAdvokat(List<AdvokatBasic> a)
        {
            Advokat = new AdvokatBasic();
            Advokati = a;
            _view = "Dodaj";
            InitializeComponent();
        }
        public FormAdvokat(List<AdvokatBasic> a, AdvokatBasic adv)
        {
            Advokat = adv;
            Advokati = a;
            _view = "Izmeni";
            InitializeComponent();
        }
        public FormAdvokat()
        {
            Advokat = new AdvokatBasic();
            Advokati = DTOManager.ReadAllAdvokat();
            _view = "Dodaj";
            InitializeComponent();
        }
        public FormAdvokat(AdvokatBasic adv)
        {
            Advokat = adv;
            Advokati = DTOManager.ReadAllAdvokat();
            _view = "Izmeni";
            InitializeComponent();
        }

        private void FormDodajAdvokata_Load(object sender, EventArgs e)
        {
            comboBoxPol.Items.Add("Muški");
            comboBoxPol.Items.Add("Ženski");

            buttonEvidentiraj.Text = _view + " advokata";
            if (_view == "Izmeni")
            {
                textBoxJMBG.Text = Advokat.JMBG;
                textBoxJMBG.Enabled = false;
                comboBoxPol.SelectedIndex = Advokat.Pol == "M" ? 0 : 1;

                textBoxIme.Text = Advokat.Ime;
                textBoxPrezime.Text = Advokat.Prezime;
            }
        }

        private void buttonEvidentiraj_Click(object sender, EventArgs e)
        {
            if (!Validacija())
                return;

            Advokat.JMBG = textBoxJMBG.Text;
            Advokat.Ime = textBoxIme.Text;
            Advokat.Prezime = textBoxPrezime.Text;
            Advokat.Pol = comboBoxPol.Text == "Muški" ? "M" : "Ž";

            if (_view == "Izmeni")
                DTOManager.UpdateAdvokat(Advokat);
            else if (_view == "Dodaj" && !Advokati.Contains(Advokat))
                DTOManager.CreateAdvokat(Advokat);
            else
            {
                MessageBox.Show(this,
                    "Advokat je već unešen!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
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
