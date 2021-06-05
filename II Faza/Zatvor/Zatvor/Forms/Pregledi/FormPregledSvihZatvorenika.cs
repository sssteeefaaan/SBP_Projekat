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
using Zatvor.DTO.View;
using Zatvor.Forms.Dodaj_Izmeni;
using Zatvor.Forms.Pregledi;

namespace Zatvor.Forms
{
    public partial class FormPregledSvihZatvorenika : Form
    {
        public List<ZatvorenikBasic> Zatvorenici { get; set; }
        public FormPregledSvihZatvorenika(List<ZatvorenikBasic> z)
        {
            Zatvorenici = z;
            InitializeComponent();
        }
        public FormPregledSvihZatvorenika()
        {
            Zatvorenici = DTOManager.ReadAllZatvorenik();
            InitializeComponent();
        }

        private void FormPregledZatvorenika_Load(object sender, EventArgs e)
        {
            listViewZatvorenici.View = View.Details;
            listViewZatvorenici.Alignment = ListViewAlignment.SnapToGrid;
            listViewZatvorenici.FullRowSelect =
            listViewZatvorenici.GridLines = true;

            string[] vals = { 
                "",
                "JMBG",
                "Ime",
                "Prezime",
                "Pol",
                "Adresa",
                "Broj",
                "Datum inkareceracije",
                "Datum sledećeg saslušanja",
                "Status uslovnog otpusta",
                "Šifra zatvorske jedinice"};

            for (int i = 0; i < vals.Length; i++)
            {
                listViewZatvorenici.Columns.Add(new ColumnHeader()
                {
                    Text = vals[i],
                    TextAlign = HorizontalAlignment.Center,
                    Width = i == 0 ? 0 : (50 + vals[i].Length * (i < 6 ? 20 : 8))
                });
            }

            buttonIzmeniZatvorenika.Enabled = buttonObrisi.Enabled = false;

            OsveziPrikaz();
        }

        private void buttonDodajZatvorenika_Click(object sender, EventArgs e)
        {
            FormZatvorenik f = new FormZatvorenik();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Zatvorenici.Add(f.Zatvorenik);
                OsveziPrikaz();
            }

            ResetButtons();
        }

        private void buttonIzmeniZatvorenika_Click(object sender, EventArgs e)
        {
            ZatvorenikBasic z = Zatvorenici.Find(zat => zat.JMBG == listViewZatvorenici.SelectedItems[0].Text);
            FormZatvorenik f = new FormZatvorenik(z);
            if (f.ShowDialog() == DialogResult.OK)
                OsveziPrikaz();

            ResetButtons();
        }

        private void buttonObrisi_Click(object sender, EventArgs e)
        {
            int forDel;
            foreach (int i in listViewZatvorenici.SelectedIndices)
            {
               forDel = Zatvorenici.FindIndex(z => z.JMBG == listViewZatvorenici.Items[i].Text);
               DTOManager.DeleteZatvorenik(Zatvorenici[forDel]);
               Zatvorenici.Remove(Zatvorenici[forDel]);
            }

            OsveziPrikaz();
            ResetButtons();
        }

        private void listViewZatvorenici_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetButtons(listViewZatvorenici.SelectedIndices.Count);
        }
        private void OsveziPrikaz()
        {
            listViewZatvorenici.Items.Clear();
            Zatvorenici.ForEach(z =>
            {
                listViewZatvorenici.Items.Add(new ListViewItem(new string[]
                {
                    z.JMBG,
                    z.JMBG,
                    z.Ime,
                    z.Prezime,
                    z.Pol,
                    String.IsNullOrEmpty(z.Adresa)? "/" : z.Adresa,
                    z.Broj,
                    z.DatumInkarceracije.ToLongDateString(),
                    z.DatumSledecegSaslusanja.HasValue?((DateTime) z.DatumSledecegSaslusanja).ToLongDateString() : "/",
                    z.StatusUslovnogOtpusta,
                    z.ZatvorskaJedinica.Sifra
                }));
            });
        }

        private void listViewZatvorenici_DoubleClick(object sender, EventArgs e)
        {
            int index = Zatvorenici.FindIndex(zat => zat.JMBG == listViewZatvorenici.SelectedItems[0].Text);
            FormPregledZatvorenika f = new FormPregledZatvorenika(Zatvorenici[index]);
            if (f.ShowDialog() == DialogResult.OK)
                OsveziPrikaz();

            ResetButtons();
        }

        private void ResetButtons(int val = 0)
        {
            buttonIzmeniZatvorenika.Enabled = val == 1;
            buttonObrisi.Enabled = val >= 1;
            buttonObrisi.Text = (val <= 1) ? "Obriši zatvorenika" : "Obriši zatvorenike";
        }
    }
}
