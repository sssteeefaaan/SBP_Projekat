using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Zatvor.Entiteti;
using Zatvor.Forms;
using System.Drawing;
using Zatvor.DTO;
using Zatvor.DTO.Basic;
using Zatvor.Forms.Pregledi;

namespace Zatvor
{
    public partial class FormGlavna : Form
    {
        private List<ZatvorskaJedinicaBasic> ZatvorskeJedinice { get; set; }
        private List<ZaposleniBasic> Zaposleni { get; set; }
        private List<ZatvorenikBasic> Zatvorenici { get; set; }
        private List<AdvokatBasic> Advokati { get; set; }
        public FormGlavna()
        {
           InitializeComponent();
           //UcitajPodatke();
        }
        private void buttonZatvorskeJedinice_Click(object sender, EventArgs e)
        {
            Form f = new FormPregledZatvorskihJedinica();// ZatvorskeJedinice);
            f.ShowDialog();
        }

        private void buttonZaposleni_Click(object sender, EventArgs e)
        {
            Form f = new FormPregledZaposlenih();// Zaposleni);
            f.ShowDialog();
        }

        private void buttonZatvorenici_Click(object sender, EventArgs e)
        {
            Form f = new FormPregledSvihZatvorenika();// Zatvorenici);
            f.ShowDialog();
        }
        private void buttonAdvokati_Click(object sender, EventArgs e)
        {
            Form f = new FormPregledAdvokata();//Advokati);
            f.ShowDialog();
        }
        private void buttonFirme_Click(object sender, EventArgs e)
        {
            Form f = new FormPregledFirmi();
            f.ShowDialog();
        }
        private void UcitajPodatke()
        {
            ZatvorskeJedinice = DTOManager.ReadAllZatvorskaJedinicaFULL();
            Zatvorenici = DTOManager.ReadAllZatvorenik();
            Zaposleni = DTOManager.ReadAllZaposleni();
            Advokati = DTOManager.ReadAllAdvokat();
        }

    }
}
