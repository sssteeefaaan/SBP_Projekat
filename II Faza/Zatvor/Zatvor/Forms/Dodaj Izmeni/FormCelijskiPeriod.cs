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
    public partial class FormCelijskiPeriod : Form
    {
        public CelijskiPeriodBasic CelijskiPeriod { get; set; }
        private string _tip;
        public FormCelijskiPeriod(ZatvorskaJedinicaBasic zj)
        {
            CelijskiPeriod = new CelijskiPeriodBasic();
            CelijskiPeriod.ZatvorskaJedinica = zj;
            _tip = "Dodaj";
            InitializeComponent();
        }
        public FormCelijskiPeriod(CelijskiPeriodBasic cp)
        {
            CelijskiPeriod = cp;
            _tip = "Izmeni";
            InitializeComponent();
        }

        private void buttonZatvori_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            if (comboBoxOdSati.SelectedIndex < 0 || comboBoxDoSati.SelectedIndex < 0)
            {
                MessageBox.Show(this,
                    "Niste izabrali sate!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            if (comboBoxOdMinuti.SelectedIndex < 0 || comboBoxDoMinuti.SelectedIndex < 0)
            {
                MessageBox.Show(this,
                    "Niste uneli minute!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            if (int.Parse(comboBoxOdSati.Text) > int.Parse(comboBoxDoSati.Text) ||
                (int.Parse(comboBoxOdSati.Text) == int.Parse(comboBoxDoSati.Text) &&
                int.Parse(comboBoxOdMinuti.Text) > int.Parse(comboBoxDoMinuti.Text)))
            {
                MessageBox.Show(this,
                    "Vreme od je manje od vremena do!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            if (int.Parse(comboBoxOdSati.Text) == int.Parse(comboBoxDoSati.Text) &&
                int.Parse(comboBoxOdMinuti.Text) == int.Parse(comboBoxDoMinuti.Text))
            {
                MessageBox.Show(this,
                    "Vremena su ista!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            CelijskiPeriod.Period = comboBoxOdSati.Text + ":" +
                comboBoxOdMinuti.Text + " - " +
                comboBoxDoSati.Text + ":" +
                comboBoxDoMinuti.Text + "h";
            if (_tip == "Dodaj")
                DTOManager.CreateCelijskiPeriod(CelijskiPeriod);
            else
                DTOManager.UpdateCelijskiPeriod(CelijskiPeriod);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void FormDodajCelijskiPeriod_Load(object sender, EventArgs e)
        {
            comboBoxOdSati.MaxDropDownItems =
                comboBoxDoSati.MaxDropDownItems = 24;
            comboBoxOdMinuti.MaxDropDownItems =
                comboBoxDoMinuti.MaxDropDownItems = 12;

            string s, m;
            for (int i = 0; i < 24; i++)
            {
                s = i.ToString();

                if (i < 10)
                    s = "0" + s;

                comboBoxOdSati.Items.Add(s);
                comboBoxDoSati.Items.Add(s);
                if (i < 12)
                {
                    m = (i * 5).ToString();
                    if (i < 2)
                        m = "0" + m;
                    comboBoxOdMinuti.Items.Add(m);
                    comboBoxDoMinuti.Items.Add(m);
                }
            }

            comboBoxOdSati.SelectedIndex =
            comboBoxOdMinuti.SelectedIndex =
            comboBoxDoMinuti.SelectedIndex =
            comboBoxDoSati.SelectedIndex = 0;

            buttonDodaj.Text = _tip + " period";

            if (_tip == "Izmeni")
            {
                comboBoxOdSati.SelectedItem = CelijskiPeriod.Period.Substring(0, 2);
                comboBoxOdMinuti.SelectedItem = CelijskiPeriod.Period.Substring(3, 2);
                comboBoxDoSati.SelectedItem = CelijskiPeriod.Period.Substring(8, 2);
                comboBoxDoMinuti.SelectedItem = CelijskiPeriod.Period.Substring(11, 2);
            }
        }
    }
}
