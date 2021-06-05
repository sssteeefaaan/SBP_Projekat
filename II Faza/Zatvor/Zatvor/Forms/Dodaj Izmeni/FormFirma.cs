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
    public partial class FormFirma : Form
    {
        public FirmaBasic Firma { get; set; }
        private string _view;
        public FormFirma()
        {
            Firma = new FirmaBasic();
            _view = "Dodaj";
            InitializeComponent();
        }
        public FormFirma(FirmaBasic f)
        {
            Firma = f;
            _view = "Izmeni";
            InitializeComponent();
        }

        private void FormDodajFirmu_Load(object sender, EventArgs e)
        {
            Text = buttonDodaj.Text = _view + " firmu";

            if (_view.Equals("Izmeni"))
            {
                textBoxPIB.Enabled = false;
                textBoxPIB.Text = Firma.PIB;
                textBoxNaziv.Text = Firma.Naziv;
                textBoxAdresa.Text = Firma.Adresa;
                textBoxKontaktTelefon.Text = Firma.KontaktTelefon;
            }
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            if (!Validacija())
                return;

            Firma.PIB = textBoxPIB.Text;
            Firma.Naziv = textBoxNaziv.Text;
            Firma.Adresa = textBoxAdresa.Text;
            Firma.KontaktTelefon = textBoxKontaktTelefon.Text;

            if (_view == "Dodaj")
                DTOManager.CreateFirma(Firma);
            else
                DTOManager.UpdateFirma(Firma);

            DialogResult = DialogResult.OK;
            Close();
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private bool Validacija()
        {
            if (String.IsNullOrEmpty(textBoxPIB.Text))
            {
                MessageBox.Show(this,
                    "Niste uneli PIB firme!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            if (textBoxPIB.Text.Length != 9)
            {
                MessageBox.Show(this,
                    "PIB mora biti tačno 9 karaktera!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            if (String.IsNullOrEmpty(textBoxNaziv.Text))
            {
                MessageBox.Show(this,
                    "Niste uneli naziv firme!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            if (String.IsNullOrEmpty(textBoxAdresa.Text))
            {
                MessageBox.Show(this,
                    "Niste uneli adresu firme!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            if (String.IsNullOrEmpty(textBoxKontaktTelefon.Text))
            {
                MessageBox.Show(this,
                    "Niste uneli konrakt telefon firme!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            try
            {
                long.Parse(textBoxKontaktTelefon.Text);
            }
            catch
            {
                MessageBox.Show(this,
                    "Neispravan broj telefona!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            return true;
        }
    }
}
