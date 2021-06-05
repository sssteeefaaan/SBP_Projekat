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

namespace Zatvor.Forms
{
    public partial class FormZatvorenik : Form
    {
        public ZatvorenikBasic Zatvorenik { get; set; }
        public List<ZatvorskaJedinicaBasic> ZatvorskeJedinice { get; set; }
        private ZatvorskaJedinicaBasic ZatvorskaJedinica { get; set; }
        private string _view;
        public FormZatvorenik()
        {
            Zatvorenik = new ZatvorenikBasic();
            ZatvorskaJedinica = null;
            _view = "Dodaj";
            ZatvorskeJedinice = DTOManager.ReadAllZatvorskaJedinica();
            InitializeComponent();
        }
        public FormZatvorenik(ZatvorenikBasic z)
        {
            Zatvorenik = z;
            ZatvorskaJedinica = null;
            _view = "Izmeni";
            ZatvorskeJedinice = DTOManager.ReadAllZatvorskaJedinica();
            InitializeComponent();
        }
        public FormZatvorenik(ZatvorskaJedinicaBasic zat)
        {
            Zatvorenik = new ZatvorenikBasic();
            ZatvorskaJedinica = zat;
            _view = "Dodaj";
            ZatvorskeJedinice = new List<ZatvorskaJedinicaBasic>() { ZatvorskaJedinica };
            InitializeComponent();
        }
        public FormZatvorenik(ZatvorskaJedinicaBasic zat, ZatvorenikBasic z)
        {
            Zatvorenik = z;
            ZatvorskaJedinica = zat;
            _view = "Izmeni";
            ZatvorskeJedinice = new List<ZatvorskaJedinicaBasic>() { ZatvorskaJedinica };
            InitializeComponent();
        }

        private void FormDodajZatvorenika_Load(object sender, EventArgs e)
        {
            buttonDodajZatvorenika.Text = _view + " zatvorenika";

            comboBoxPol.Items.Add("Muški");
            comboBoxPol.Items.Add("Ženski");

            comboBoxStatusUslovnogOtpusta.Items.Add("Prihvaćen");
            comboBoxStatusUslovnogOtpusta.Items.Add("Odbijen");
            comboBoxStatusUslovnogOtpusta.Items.Add("Razmatra se");

            ZatvorskeJedinice.ForEach(zj => comboBoxZatvorskaJedinica.Items.Add(zj.Naziv));

            if (_view == "Izmeni")
            {
                textBoxJMBG.Text = Zatvorenik.JMBG;
                textBoxJMBG.Enabled = false;
                textBoxIme.Text = Zatvorenik.Ime;
                textBoxPrezime.Text = Zatvorenik.Prezime;
                comboBoxPol.SelectedIndex = Zatvorenik.Pol == "M" ? 0 : 1;

                textBoxBroj.Text = Zatvorenik.Broj;
                textBoxAdresa.Text = Zatvorenik.Adresa;
                dateTimePickerInkarceracija.Value = Zatvorenik.DatumInkarceracije;
                dateTimePickerSledeceSaslusanje.Value = Zatvorenik.DatumSledecegSaslusanja != null ? (DateTime) Zatvorenik.DatumSledecegSaslusanja : DateTime.Now;

                comboBoxStatusUslovnogOtpusta.SelectedIndex = 
                    Zatvorenik.StatusUslovnogOtpusta == "Prihvaćen" ? 0
                    : Zatvorenik.StatusUslovnogOtpusta == "Odbijen" ? 1
                    : 2;
            }

            if (ZatvorskaJedinica != null)
            {
                comboBoxZatvorskaJedinica.SelectedIndex = 0;
                comboBoxZatvorskaJedinica.Enabled = false;
            }
        }
        private void buttonOdustani_Click(object sender, EventArgs e)
        {
            Close();
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

            if (_view == "Dodaj")
                DTOManager.CreateZatvorenik(Zatvorenik);
            else
                DTOManager.UpdateZatvorenik(Zatvorenik);

            DialogResult = DialogResult.OK;
            Close();
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
    }
}
