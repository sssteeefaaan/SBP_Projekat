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

namespace Zatvor.Forms.Dodaj_Izmeni
{
    public partial class FormOdgovornoLice : Form
    {
        public OdgovornoLiceBasic Lice { get; set; }
        public FirmaBasic Firma { get; set; }
        private string _view;
        public FormOdgovornoLice(FirmaBasic f)
        {
            Firma = f;
            Lice = new OdgovornoLiceBasic();
            _view = "Dodaj";
            InitializeComponent();
        }
        public FormOdgovornoLice(OdgovornoLiceBasic l)
        {
            Lice = l;
            _view = "Izmeni";
            InitializeComponent();
        }

        private void FormOdgovornoLice_Load(object sender, EventArgs e)
        {
            Text = _view + " odgovorno lice";
            buttonDodaj.Text = _view + " lice";

            if (_view == "Izmeni")
            {
                textBoxJMBG.Enabled = false;
                textBoxJMBG.Text = Lice.JMBG;
                textBoxIme.Text = Lice.Ime;
                textBoxPrezime.Text = Lice.Prezime;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            if (!Validacija())
                return;

            Lice.JMBG = textBoxJMBG.Text;
            Lice.Ime = textBoxIme.Text;
            Lice.Prezime = textBoxPrezime.Text;

            if (_view == "Dodaj")
            {
                Lice.Firma = Firma;
                DTOManager.CreateOdgovornoLice(Lice);
            }
            else
                DTOManager.UpdateOdgovornoLice(Lice);

            DialogResult = DialogResult.OK;
            Close();
        }
        private bool Validacija()
        {
            if (String.IsNullOrEmpty(textBoxJMBG.Text))
            {
                MessageBox.Show(this,
                    "Niste uneli JMBG lica!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            if (textBoxJMBG.Text.Length != 13)
            {
                MessageBox.Show(this,
                    "JMBG odgovornog lica mora biti tačno 13 karaktera!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            if (String.IsNullOrEmpty(textBoxIme.Text))
            {
                MessageBox.Show(this,
                    "Niste uneli ime odgovornog lica!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            if (String.IsNullOrEmpty(textBoxPrezime.Text))
            {
                MessageBox.Show(this,
                    "Niste uneli prezime odgovornog lica!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            return true;
        }
    }
}
