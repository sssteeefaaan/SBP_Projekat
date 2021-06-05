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
using Zatvor.Forms.Dodavanja;
using Zatvor.Forms.Pregledi;

namespace Zatvor.Forms
{
    public partial class FormPregledZatvorskihJedinica : Form
    {
        public List<ZatvorskaJedinicaBasic> ZatvorskeJedinice { get; set; }
        public bool OTip { get; set; }
        public bool POTip { get; set; }
        public bool STip { get; set; }
        public FormPregledZatvorskihJedinica(List<ZatvorskaJedinicaBasic> lista)
        {
            ZatvorskeJedinice = lista;
            OTip = POTip = STip = false;
            InitializeComponent();
        }
        public FormPregledZatvorskihJedinica()
        {
            ZatvorskeJedinice = DTOManager.ReadAllZatvorskaJedinicaFULL();
            OTip = POTip = STip = false;

            InitializeComponent();
        }

        private void checkBoxOtvoren_CheckedChanged(object sender, EventArgs e)
        {
            OTip = checkBoxOtvoren.Checked;

            ResetButtons();
            RefreshData();
        }

        private void checkBoxPoluotvoren_CheckedChanged(object sender, EventArgs e)
        {
            POTip = checkBoxPoluotvoren.Checked;

            ResetButtons();
            RefreshData();
        }

        private void checkBoxStrogi_CheckedChanged(object sender, EventArgs e)
        {
            STip = checkBoxStrogi.Checked;

            ResetButtons();
            RefreshData();
        }
        private void FormPregledZatvorskihJedinica_Load(object sender, EventArgs e)
        {
            listViewZatvorskeJedinice.View = View.Details;
            listViewZatvorskeJedinice.Alignment = ListViewAlignment.SnapToGrid;
            listViewZatvorskeJedinice.FullRowSelect =
            listViewZatvorskeJedinice.GridLines = true;
            checkBoxOtvoren.Checked =
            checkBoxPoluotvoren.Checked =
            checkBoxStrogi.Checked =
            false;

            SetView();
            RefreshData();
            ResetButtons();
        }
        private void listViewZatvorskeJedinice_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val = listViewZatvorskeJedinice.SelectedIndices.Count;
            ResetButtons(val);
        }
        private void ResetButtons(int val = 0)
        {
            buttonIzmeni.Enabled = val == 1;
            buttonObrisi.Enabled = val >= 1;
            buttonObrisi.Text = (val <= 1) ? "Obriši zatvorsku jedinicu" : "Obriši zatvorske jedinice";
        }
        private void SetView()
        {
            listViewZatvorskeJedinice.Columns.Clear();

            string[] columns =
                {
                "",
                "Šifra",
                "Naziv",
                "Adresa",
                "Upravnik",
                "Kapacitet",
                "Broj zaposlenih",
                "Broj zatvorenika",
                "Režim"
            };
            int[] vals =
            {
                0,
                100,
                300,
                500,
                300,
                100,
                100,
                100,
                300
            };

            for(int i = 0; i < columns.Length;i++)
            {
                listViewZatvorskeJedinice.Columns.Add(new ColumnHeader()
                {
                    Text = columns[i],
                    TextAlign = HorizontalAlignment.Center,
                    Width = columns[i].Length + vals[i]
                });
            }
        }
        private void LoadData()
        {
            ZatvorskeJedinice = DTOManager.ReadAllZatvorskaJedinicaFULL();
        }
        private void RefreshData()
        {
            listViewZatvorskeJedinice.Items.Clear();

            int i = 0;
            string rezim = "";
            List<ZatvorskaJedinicaBasic> show = (OTip || POTip || STip) ? ZatvorskeJedinice.FindAll(zat => zat.ORezim == OTip && zat.PORezim == POTip && zat.SRezim == STip) : ZatvorskeJedinice;
            
            foreach (ZatvorskaJedinicaBasic zj in show)
            {
                if (zj.ORezim)
                    rezim = "Otvoren";
                if (zj.PORezim)
                {
                    if (String.IsNullOrEmpty(rezim))
                        rezim = "Poluotvoren";
                    else
                        rezim += " - Poluotvoren";
                }
                if (zj.SRezim)
                {
                    if (String.IsNullOrEmpty(rezim))
                        rezim = "Strogi";
                    else
                        rezim += " - Strogi";
                }

                listViewZatvorskeJedinice.Items.Add(new ListViewItem(zj.Sifra));
                listViewZatvorskeJedinice.Items[i].SubItems.Add(zj.Sifra);
                listViewZatvorskeJedinice.Items[i].SubItems.Add(zj.Naziv);
                listViewZatvorskeJedinice.Items[i].SubItems.Add(zj.Adresa);
                listViewZatvorskeJedinice.Items[i].SubItems.Add(zj.Upravnik != null ? (zj.Upravnik.Ime + " " + zj.Upravnik.Prezime) : "/");
                listViewZatvorskeJedinice.Items[i].SubItems.Add(zj.Kapacitet.ToString());
                listViewZatvorskeJedinice.Items[i].SubItems.Add(zj.Zaposleni.Count.ToString());
                listViewZatvorskeJedinice.Items[i].SubItems.Add(zj.Zatvorenici.Count.ToString());
                listViewZatvorskeJedinice.Items[i].SubItems.Add(rezim);

                i++;
                rezim = "";
            }
        }

        private void buttonObrisi_Click(object sender, EventArgs e)
        {
            int forDel;
            foreach (ListViewItem lvi in listViewZatvorskeJedinice.SelectedItems)
            {
                forDel = ZatvorskeJedinice.FindIndex(zj => zj.Sifra == lvi.Text);
                DTOManager.DeleteZatvorskaJedinica(ZatvorskeJedinice[forDel]);
                ZatvorskeJedinice.RemoveAt(forDel);
            }

            ResetButtons();
            RefreshData();
        }

        private void listViewZatvorskeJedinice_DoubleClick(object sender, EventArgs e)
        {
            if (listViewZatvorskeJedinice.SelectedIndices.Count != 1)
                return;

            int val = listViewZatvorskeJedinice.SelectedIndices[0];
            Form f = new FormPregledZatvorskeJedinice(ZatvorskeJedinice.Find(zj => zj.Sifra == listViewZatvorskeJedinice.Items[val].Text));
            f.ShowDialog();

            ResetButtons();
            RefreshData();
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
           FormZatvorskaJedinica f = new FormZatvorskaJedinica();
           if (f.ShowDialog() == DialogResult.OK)
           {
                ZatvorskeJedinice.Add(f.ZatvorskaJedinica);
                RefreshData();
           }
        }

        private void buttonIzmeni_Click(object sender, EventArgs e)
        {
            int val = listViewZatvorskeJedinice.SelectedIndices[0];

            FormZatvorskaJedinica f = new FormZatvorskaJedinica(ZatvorskeJedinice.Find(zj => zj.Sifra == listViewZatvorskeJedinice.Items[val].Text));
            if (f.ShowDialog() == DialogResult.OK)
                RefreshData();
            ResetButtons();
        }
    }
}
