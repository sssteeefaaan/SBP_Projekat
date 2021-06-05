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
    public partial class FormTerminPosete : Form
    {
        public TerminPoseteBasic TerminPosete { get; set; }
        private string _tip;
        public FormTerminPosete(ZatvorskaJedinicaBasic zj)
        {
            TerminPosete = new TerminPoseteBasic();
            TerminPosete.ZatvorskaJedinica = zj;
            _tip = "Dodaj";
            InitializeComponent();
        }
        public FormTerminPosete(TerminPoseteBasic tp)
        {
            TerminPosete = tp;
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
            if (comboBoxDan.SelectedIndex < 0)
            {
                MessageBox.Show(this,
                    "Niste uneli dan posete!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
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

            TerminPosete.Period = comboBoxOdSati.Text + ":" +
                comboBoxOdMinuti.Text + " - " +
                comboBoxDoSati.Text + ":" +
                comboBoxDoMinuti.Text + "h";
            TerminPosete.Dan = comboBoxDan.Text;

            if (_tip == "Dodaj")
                DTOManager.CreateTerminPosete(TerminPosete);
            else
                DTOManager.UpdateTerminPosete(TerminPosete);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void FormDodajTerminPosete_Load(object sender, EventArgs e)
        {
            comboBoxDan.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (string str in new string[] { "Ponedeljak", "Utorak", "Sreda", "Četvrtak", "Petak", "Subota", "Nedelja" })
                comboBoxDan.Items.Add(str);

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

            comboBoxDan.SelectedIndex =
                comboBoxOdSati.SelectedIndex =
                comboBoxOdMinuti.SelectedIndex =
                comboBoxDoMinuti.SelectedIndex =
                comboBoxDoSati.SelectedIndex = 0;

            buttonDodaj.Text = _tip + " termin";

            if (_tip == "Izmeni")
            {
                comboBoxDan.SelectedItem = TerminPosete.Dan;
                comboBoxOdSati.SelectedItem = TerminPosete.Period.Substring(0, 2);
                comboBoxOdMinuti.SelectedItem = TerminPosete.Period.Substring(3, 2);
                comboBoxDoSati.SelectedItem = TerminPosete.Period.Substring(8, 2);
                comboBoxDoMinuti.SelectedItem = TerminPosete.Period.Substring(11, 2);
            }
        }
    }
}
