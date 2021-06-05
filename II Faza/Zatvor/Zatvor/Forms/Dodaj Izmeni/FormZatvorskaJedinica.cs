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

namespace Zatvor.Forms.Dodavanja
{
    public partial class FormZatvorskaJedinica : Form
    {
        public ZatvorskaJedinicaBasic ZatvorskaJedinica { get; set; }
        private string _tip;
        public FormZatvorskaJedinica()
        {
            ZatvorskaJedinica = new ZatvorskaJedinicaBasic();
            _tip = "Dodaj";
            InitializeComponent();
        }
        public FormZatvorskaJedinica(ZatvorskaJedinicaBasic zj)
        {
            ZatvorskaJedinica = zj;
            _tip = "Izmeni";
            InitializeComponent();
        }

        private void FormZatvorskaJedinica_Load(object sender, EventArgs e)
        {
            if (_tip == "Izmeni")
            {
                textBoxSifra.Text = ZatvorskaJedinica.Sifra;
                textBoxSifra.Enabled = false;
                textBoxNaziv.Text = ZatvorskaJedinica.Naziv;
                textBoxAdresa.Text = ZatvorskaJedinica.Adresa;
                numericUpDownKapacitet.Value = ZatvorskaJedinica.Kapacitet;

                checkBoxOtvoren.Checked = ZatvorskaJedinica.ORezim;
                checkBoxPoluotvoren.Checked = ZatvorskaJedinica.PORezim;
                checkBoxStrogi.Checked = ZatvorskaJedinica.SRezim;
            }

            buttonDodaj.Text = _tip;
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            if (!Validacija())
                return;

            ZatvorskaJedinica.Sifra = textBoxSifra.Text;
            ZatvorskaJedinica.Naziv = textBoxNaziv.Text;
            ZatvorskaJedinica.Adresa = textBoxAdresa.Text;
            ZatvorskaJedinica.Kapacitet = (int) numericUpDownKapacitet.Value;

            ZatvorskaJedinica.ORezim = checkBoxOtvoren.Checked;
            ZatvorskaJedinica.PORezim = checkBoxPoluotvoren.Checked;
            ZatvorskaJedinica.SRezim = checkBoxStrogi.Checked;

            if (_tip == "Dodaj")
                DTOManager.CreateZatvorskaJedinica(ZatvorskaJedinica);
            else
                DTOManager.UpdateZatvorskaJedinica(ZatvorskaJedinica);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonZatvori_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool Validacija()
        {
            if (String.IsNullOrEmpty(textBoxSifra.Text))
            {
                MessageBox.Show(this,
                    "Niste uneli šifru zatvorske jedinice!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (textBoxSifra.Text.Length != 5)
            {
                MessageBox.Show(this,
                    "Šifra zatvorske jedinice mora da bude tačno 5 karaktera",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (String.IsNullOrEmpty(textBoxNaziv.Text))
            {
                MessageBox.Show(this,
                    "Niste uneli naziv zatvorske jedinice!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (String.IsNullOrEmpty(textBoxAdresa.Text))
            {
                MessageBox.Show(this,
                    "Niste uneli adresu zatvorske jedinice!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (numericUpDownKapacitet.Value <= 1)
            {
                MessageBox.Show(this,
                    "Niste uneli kapacitet zatvorske jedinice!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (!checkBoxOtvoren.Checked && !checkBoxPoluotvoren.Checked && !checkBoxStrogi.Checked)
            {
                MessageBox.Show(this,
                    "Zatvorska jedinica mora da radi u nekom režimu!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
