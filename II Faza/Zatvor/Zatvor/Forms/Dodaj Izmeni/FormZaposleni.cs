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
    public partial class FormZaposleni : Form
    {
        public string Tip { get; set; }
        private List<ZatvorskaJedinicaBasic> ZatvorskeJedinice { get; set; }
        private ZatvorskaJedinicaBasic ZatvorskaJedinica { get; set; }
        public ZaposleniBasic Zaposleni { get; set; }
        private string _view;
        public FormZaposleni()
        {
            ZatvorskeJedinice = DTOManager.ReadAllZatvorskaJedinica();
            _view = "Dodaj";
            InitializeComponent();
        }
        public FormZaposleni(ZaposleniBasic z)
        {
            Zaposleni = z;
            ZatvorskeJedinice = DTOManager.ReadAllZatvorskaJedinica();
            _view = "Izmeni";
            InitializeComponent();
        }
        public FormZaposleni(ZatvorskaJedinicaBasic z)
        {
            ZatvorskaJedinica = z;
            ZatvorskeJedinice = new List<ZatvorskaJedinicaBasic>() { z };
            _view = "Dodaj";
            InitializeComponent();
        }
        public FormZaposleni(ZatvorskaJedinicaBasic z, ZaposleniBasic zap)
        {
            ZatvorskaJedinica = z;
            ZatvorskeJedinice = new List<ZatvorskaJedinicaBasic>() { z };
            Zaposleni = zap;
            _view = "Izmeni";
            InitializeComponent();
        }
        private void FormDodajZaposlenog_Load(object sender, EventArgs e)
        {
            comboBoxPol.Items.Add("Muški");
            comboBoxPol.Items.Add("Ženski");

            comboBoxStrucnaSprema.Items.Add("Srednja");
            comboBoxStrucnaSprema.Items.Add("Viša");
            comboBoxStrucnaSprema.Items.Add("Visoka");

            ZatvorskeJedinice.ForEach(zj => comboBoxZatvorskaJedinica.Items.Add(zj.Naziv));
            if (ZatvorskaJedinica != null)
                comboBoxZatvorskaJedinica.SelectedItem = ZatvorskaJedinica.Naziv;

            buttonDodajZaposlenog.Text = _view;
            if (_view == "Izmeni")
            {
                SetView(Zaposleni.RadnoMesto);

                textBoxJMBG.Text = Zaposleni.JMBG;
                textBoxJMBG.Enabled = false;
                textBoxIme.Text = Zaposleni.Ime;
                textBoxPrezime.Text = Zaposleni.Prezime;
                comboBoxPol.SelectedIndex = Zaposleni.Pol == "M" ? 0 : 1;

                dateTimePickerPPO.Value = Zaposleni.DatumObukePPZ;
                dateTimePickerPocetakRada.Value = Zaposleni.DatumPocetkaRada;
                comboBoxZatvorskaJedinica.SelectedIndex = ZatvorskeJedinice.FindIndex(zj => zj.Sifra == Zaposleni.RadiU.Sifra);

                if (Tip == "Administracija")
                {
                    textBoxPrva.Text = Zaposleni.Zanimanje;
                    textBoxDruga.Text = Zaposleni.Pozicija;
                    comboBoxStrucnaSprema.SelectedIndex = Zaposleni.StrucnaSprema == "Srednja" ? 0 :
                        Zaposleni.StrucnaSprema == "Viša" ? 1: 2;
                }
                else
                {
                    textBoxLPLekar.Text = Zaposleni.LPLekar;
                    textBoxLPAdresa.Text = Zaposleni.LPAdresaUstanove;
                    textBoxLPUstanova.Text = Zaposleni.LPNazivUstanove;
                    dateTimePickerLP.Value = (DateTime) Zaposleni.LPDatum;

                    if (Tip == "Psiholog")
                    {
                        textBoxPrva.Text = Zaposleni.SSpecijalizacija;
                        textBoxDruga.Text = Zaposleni.SNazivUstanove;
                    }
                    else
                    {
                        textBoxPrva.Text = Zaposleni.DORVOSifra;
                        textBoxDruga.Text = Zaposleni.DORVOPolicijskaUprava;
                        dateTimePickerDORVO.Value = (DateTime)Zaposleni.DORVODatumIzdavanja;
                    }
                }
            }
            else
                SetView("Administracija");
        }
        private void radioButtonAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAdmin.Checked)
                SetView("Administracija");
        }

        private void radioButtonPsiholog_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPsiholog.Checked)
                SetView("Psiholog");
        }

        private void radioButtonObezbedjenje_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonObezbedjenje.Checked)
                SetView("Radnik obezbeđenja");
        }

        private void buttonDodajZaposlenog_Click(object sender, EventArgs e)
        {
            if (!Validacija())
                return;

            if (Tip == "Administracija")
            {
                Zaposleni = new AdministracijaBasic();
                Zaposleni.Zanimanje = textBoxPrva.Text;
                Zaposleni.Pozicija = textBoxDruga.Text;
                Zaposleni.StrucnaSprema = comboBoxStrucnaSprema.Text;
            }
            else
            {
                if (Tip == "Psiholog")
                {
                    Zaposleni = new PsihologBasic();
                    Zaposleni.SSpecijalizacija = textBoxPrva.Text;
                    Zaposleni.SNazivUstanove = textBoxDruga.Text;
                }
                else if (Tip == "Radnik obezbeđenja")
                {
                    Zaposleni = new RadnikObezbedjenjaBasic();
                    Zaposleni.DORVOSifra = textBoxPrva.Text;
                    Zaposleni.DORVOPolicijskaUprava = textBoxDruga.Text;
                    Zaposleni.DORVODatumIzdavanja = dateTimePickerDORVO.Value;
                }

                Zaposleni.LPLekar = textBoxLPLekar.Text;
                Zaposleni.LPNazivUstanove = textBoxLPUstanova.Text;
                Zaposleni.LPAdresaUstanove = textBoxLPAdresa.Text;
                Zaposleni.LPDatum = dateTimePickerLP.Value;
            }

            Zaposleni.JMBG = textBoxJMBG.Text;
            Zaposleni.Ime = textBoxIme.Text;
            Zaposleni.Prezime = textBoxPrezime.Text;
            Zaposleni.Pol = comboBoxPol.SelectedIndex == 0 ? "M" : "Ž";

            Zaposleni.RadnoMesto = Tip;
            Zaposleni.DatumObukePPZ = dateTimePickerPPO.Value;
            Zaposleni.RadiU = ZatvorskeJedinice[comboBoxZatvorskaJedinica.SelectedIndex];
            Zaposleni.DatumPocetkaRada = dateTimePickerPocetakRada.Value;

            if (_view == "Dodaj")
                DTOManager.CreateZaposleni(Zaposleni);
            else
                DTOManager.UpdateZaposleni(Zaposleni);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonOtkazi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetView(string view)
        {
            Tip = view;

            textBoxPrva.Text = 
                textBoxDruga.Text =
                textBoxTreca.Text ="";

            comboBoxStrucnaSprema.SelectedIndex = -1;
            dateTimePickerDORVO.Value = DateTime.Now;

            if (Tip == "Administracija")
            {
                radioButtonAdmin.Checked = true;
                if (groupBoxLekarskiPregled.Enabled)
                {
                    groupBoxLekarskiPregled.Enabled = false;
                    groupBoxLekarskiPregled.Hide();
                    groupBoxDetalji.Height -= groupBoxLekarskiPregled.Height;
                    buttonDodajZaposlenog.Location = new Point(buttonDodajZaposlenog.Location.X, groupBoxDetalji.Location.Y + groupBoxDetalji.Height + 5);
                    buttonOtkazi.Location = new Point(buttonOtkazi.Location.X, groupBoxDetalji.Location.Y + groupBoxDetalji.Height + 5);
                    Height -= groupBoxLekarskiPregled.Height;
                }

                groupBoxLekarskiPregled.Enabled = false;
                dateTimePickerDORVO.Hide();
                textBoxTreca.Hide();
                labelTreca.Show();
                comboBoxStrucnaSprema.Show();

                labelPrva.Text = "Zanimanje:";
                labelDruga.Text = "Pozicija:";
                labelTreca.Text = "Stručna sprema:";

                int x = (textBoxPrva.Parent.Width - textBoxPrva.Width + labelTreca.Width) / 2;
                int y = (textBoxPrva.Parent.Height - textBoxPrva.Height) / 2;

                textBoxPrva.Location = new Point(x, y - textBoxPrva.Height - 10);
                textBoxDruga.Location = new Point(x, y);
                comboBoxStrucnaSprema.Location = new Point(x, y + textBoxPrva.Height + 10);

                labelPrva.Location = new Point(x - labelTreca.Width, textBoxPrva.Location.Y + 5);
                labelDruga.Location = new Point(x - labelTreca.Width, textBoxDruga.Location.Y + 5);
                labelTreca.Location = new Point(x - labelTreca.Width, comboBoxStrucnaSprema.Location.Y + 5);
            }
            else if (Tip == "Psiholog")
            {
                radioButtonPsiholog.Checked = true;
                if (!groupBoxLekarskiPregled.Enabled)
                {
                    groupBoxLekarskiPregled.Enabled = true;
                    groupBoxLekarskiPregled.Show();
                    groupBoxDetalji.Height += groupBoxLekarskiPregled.Height;
                    buttonDodajZaposlenog.Location = new Point(buttonDodajZaposlenog.Location.X, groupBoxDetalji.Location.Y + groupBoxDetalji.Height + 5);
                    buttonOtkazi.Location = new Point(buttonOtkazi.Location.X, groupBoxDetalji.Location.Y + groupBoxDetalji.Height + 5);
                    this.Height += groupBoxLekarskiPregled.Height;
                }

                dateTimePickerDORVO.Hide();
                labelTreca.Hide();
                textBoxTreca.Hide();
                comboBoxStrucnaSprema.Hide();

                labelPrva.Text = "Specijalizacija:";
                labelDruga.Text = "Naziv ustanove:";

                int x = (textBoxPrva.Parent.Width - textBoxPrva.Width + labelDruga.Width) / 2;
                int y = (textBoxPrva.Parent.Height + textBoxPrva.Height) / 2;

                textBoxPrva.Location = new Point(x, y - textBoxPrva.Height - 10);
                textBoxDruga.Location = new Point(x, y);

                labelPrva.Location = new Point(x - labelDruga.Width, textBoxPrva.Location.Y + 5);
                labelDruga.Location = new Point(x - labelDruga.Width, textBoxDruga.Location.Y + 5);
            }
            else if (Tip == "Radnik obezbeđenja")
            {
                radioButtonObezbedjenje.Checked = true;
                if (!groupBoxLekarskiPregled.Enabled)
                {
                    groupBoxLekarskiPregled.Enabled = true;
                    groupBoxLekarskiPregled.Show();
                    groupBoxDetalji.Height += groupBoxLekarskiPregled.Height;
                    buttonDodajZaposlenog.Location = new Point(buttonDodajZaposlenog.Location.X, groupBoxDetalji.Location.Y + groupBoxDetalji.Height + 5);
                    buttonOtkazi.Location = new Point(buttonOtkazi.Location.X, groupBoxDetalji.Location.Y + groupBoxDetalji.Height + 5);
                    this.Height += groupBoxLekarskiPregled.Height;
                }

                dateTimePickerDORVO.Show();
                labelTreca.Show();
                textBoxTreca.Hide();
                comboBoxStrucnaSprema.Hide();

                labelPrva.Text = "Šifra:";
                labelDruga.Text = "Policijska uprava:";
                labelTreca.Text = "Datum izdavanja:";

                int x = (textBoxPrva.Parent.Width - textBoxPrva.Width + labelDruga.Width) / 2;
                int y = (textBoxPrva.Parent.Height - textBoxPrva.Height) / 2;

                textBoxPrva.Location = new Point(x, y - textBoxPrva.Height - 10);
                textBoxDruga.Location = new Point(x, y);
                dateTimePickerDORVO.Location = new Point(x, y + textBoxPrva.Height + 10);

                labelPrva.Location = new Point(x - labelDruga.Width, textBoxPrva.Location.Y + 5);
                labelDruga.Location = new Point(x - labelDruga.Width, textBoxDruga.Location.Y + 5);
                labelTreca.Location = new Point(x - labelDruga.Width, dateTimePickerDORVO.Location.Y + 5);
            }
        }
        private bool Validacija()
        {
            if (String.IsNullOrEmpty(textBoxJMBG.Text))
            {
                MessageBox.Show(this,
                    "Niste uneli JMBG zaposlenog!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (textBoxJMBG.Text.Length != 13)
            {
                MessageBox.Show(this,
                    "JMBG zaposlenog mora biti tačno 13 karaktera!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (String.IsNullOrEmpty(textBoxIme.Text))
            {
                MessageBox.Show(this,
                    "Niste uneli ime zaposlenog",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (String.IsNullOrEmpty(textBoxPrezime.Text))
            {
                MessageBox.Show(this,
                    "Niste uneli prezime zaposlenog!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (comboBoxPol.SelectedIndex < 0)
            {
                MessageBox.Show(this,
                    "Niste izabrali pol zaposlenog!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (dateTimePickerPPO.Value > DateTime.Now)
            {
                MessageBox.Show(this,
                    "Datum obuke o protivpožarnoj zaštiti ne može biti u budućnosti!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (comboBoxZatvorskaJedinica.SelectedIndex < 0)
            {
                MessageBox.Show(this,
                    "Niste izabrali u kojoj zatvoreskoj jedinici zaposleni započinje sa radom!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (dateTimePickerPocetakRada.Value > DateTime.Now)
            {
                MessageBox.Show(this,
                    "Početak rada ne može biti u budućnosti!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (Tip == "Administracija")
            {
                if (String.IsNullOrEmpty(textBoxPrva.Text))
                {
                    MessageBox.Show(this,
                        "Niste uneli zanimanje administracije!",
                        "Greška",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                if (String.IsNullOrEmpty(textBoxDruga.Text))
                {
                    MessageBox.Show(this,
                        "Niste uneli poziciju administracije!",
                        "Greška",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                if (comboBoxStrucnaSprema.SelectedIndex < 0)
                {
                    MessageBox.Show(this,
                        "Niste uneli stručnu spremu administracije!",
                        "Greška",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }
            else
            {
                if (String.IsNullOrEmpty(textBoxLPLekar.Text))
                {
                    MessageBox.Show(this,
                        "Niste uneli ime lekara koji je izdao lekarski pregled!",
                        "Greška",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                if (String.IsNullOrEmpty(textBoxLPUstanova.Text))
                {
                    MessageBox.Show(this,
                        "Niste uneli naziv ustanove koja je izdala lekarski pregled!",
                        "Greška",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                if (String.IsNullOrEmpty(textBoxLPAdresa.Text))
                {
                    MessageBox.Show(this,
                        "Niste uneli adresu ustanove koja je izdala lekarski pregled!",
                        "Greška",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                if (dateTimePickerLP.Value > DateTime.Now)
                {
                    MessageBox.Show(this,
                        "Datum potvrde o lekarskom pregledu ne može biti u budućnosti!",
                        "Greška",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                if (Tip == "Psiholog")
                {
                    if (String.IsNullOrEmpty(textBoxPrva.Text))
                    {
                        MessageBox.Show(this,
                            "Niste uneli specijalizaciju psihologa!",
                            "Greška",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                    if (String.IsNullOrEmpty(textBoxDruga.Text))
                    {
                        MessageBox.Show(this,
                            "Niste uneli ustanovu koja izdaje sprecijalizaciju psihologa!",
                            "Greška",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }

                    return true;
                }
                else if (Tip == "Radnik obezbeđenja")
                {
                    if (String.IsNullOrEmpty(textBoxPrva.Text))
                    {
                        MessageBox.Show(this,
                            "Niste uneli šifru dokaza o rukovanju vatrenim oružjem neophodnu za radnika obezbeđenja!",
                            "Greška",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                    if (String.IsNullOrEmpty(textBoxDruga.Text))
                    {
                        MessageBox.Show(this,
                            "Niste uneli adresu ustanove koja je izdala dokaz o rukovanju vatrenim oružjem!",
                            "Greška",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                    if (dateTimePickerDORVO.Value > DateTime.Now)
                    {
                        MessageBox.Show(this,
                            "Datum izdavanja dokaza o rukovanju vatrenim oružjem ne može biti u budućnosti!",
                            "Greška",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }

                    return true;
                }

                MessageBox.Show(this,
                    "Tip zaposlenog nevalidan!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
