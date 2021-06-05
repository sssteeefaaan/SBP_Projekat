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

namespace Zatvor.Forms.Pregledi
{
    public partial class FormPregledFirmi : Form
    {
        public List<FirmaBasic> Firme { get; set; }
        public ZatvorskaJedinicaBasic ZatvorskaJedinica { get; set; }
        public FormPregledFirmi()
        {
            Firme = DTOManager.ReadAllFirma();
            InitializeComponent();
        }
        public FormPregledFirmi(List<FirmaBasic> f)
        {
            Firme = f;
            InitializeComponent();
        }
        public FormPregledFirmi(ZatvorskaJedinicaBasic zj)
        {
            ZatvorskaJedinica = zj;
            Firme = DTOManager.ReadAllFirmaNotFor(zj);
            InitializeComponent();
        }
        public FormPregledFirmi(ZatvorskaJedinicaBasic zj, List<FirmaBasic> f)
        {
            ZatvorskaJedinica = zj;
            Firme = f;
            InitializeComponent();
        }

        private void FormPregledFirmi_Load(object sender, EventArgs e)
        {
            listViewFirme.GridLines =
                listViewFirme.MultiSelect =
                listViewFirme.FullRowSelect = true;

            listViewFirme.View = View.Details;

            if (ZatvorskaJedinica == null)
            {
                buttonClose.Hide();
                buttonIzaberi.Hide();
                listViewFirme.BringToFront();
                listViewFirme.Height += buttonClose.Height;
            }

            SetView();
            RefreshData();
            ResetButtons();
        }
        private void SetView()
        {
            listViewFirme.Columns.Clear();

            string[] columns =
            {
                "",
                "PIB",
                "Naziv",
                "Adresa",
                "Kontakt telefon",
                "Broj odgovornih lica"
            };

            int[] vals =
            {
                0, 100, 200, 300, 200, 200
            };

            for (int i = 0; i < columns.Length; i++)
                listViewFirme.Columns.Add(new ColumnHeader(i)
                {
                    Text = columns[i],
                    TextAlign = HorizontalAlignment.Center,
                    Width = vals[i]
                });

            if (ZatvorskaJedinica == null)
                listViewFirme.Columns.Add(new ColumnHeader(columns.Length)
                {
                    Text = "Broj zatvorskih jedinica",
                    TextAlign = HorizontalAlignment.Center,
                    Width = 200
                });
        }
        private void RefreshData()
        {
            listViewFirme.Items.Clear();

            Firme.ForEach(f =>
            {
                listViewFirme.Items.Add(new ListViewItem(new string[]
               {
                f.PIB,
                f.PIB,
                f.Naziv,
                f.Adresa,
                f.KontaktTelefon,
                f.OdgovornaLica.Count.ToString()
               }));

                if (ZatvorskaJedinica == null)
                    listViewFirme.Items[listViewFirme.Items.Count - 1].SubItems.Add(f.ZatvorskeJedinice.Count.ToString());
            });
        }

        private void listViewFirme_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetButtons(listViewFirme.SelectedItems.Count);
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            FormFirma f = new FormFirma();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Firme.Add(f.Firma);
                RefreshData();
            }

            ResetButtons();
        }

        private void buttonIzmeni_Click(object sender, EventArgs e)
        {
            int val = Firme.FindIndex(firma => firma.PIB == listViewFirme.SelectedItems[0].Text);

            FormFirma f = new FormFirma(Firme[val]);
            if (f.ShowDialog() == DialogResult.OK)
                RefreshData();

            ResetButtons();
        }

        private void buttonObrisi_Click(object sender, EventArgs e)
        {
            int forDel;

            foreach (ListViewItem lvi in listViewFirme.SelectedItems)
            {
                forDel = Firme.FindIndex(f => f.PIB == lvi.Text);
                DTOManager.DeleteFirma(Firme[forDel]);
                Firme.RemoveAt(forDel);
            }

            ResetButtons();
            RefreshData();
        }

        private void listViewFirme_DoubleClick(object sender, EventArgs e)
        {
            int val = Firme.FindIndex(firma => firma.PIB == listViewFirme.SelectedItems[0].Text);

            FormPregledLica f = new FormPregledLica(Firme[val]);
            f.ShowDialog();

            ResetButtons();
            RefreshData();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonIzaberi_Click(object sender, EventArgs e)
        {
            int forAdd;

            foreach (ListViewItem lvi in listViewFirme.SelectedItems)
            {
                forAdd = Firme.FindIndex(f => f.PIB == lvi.Text);
                DTOManager.CreateMozeDaAngazuje(ZatvorskaJedinica, Firme[forAdd]);
                ZatvorskaJedinica.Firme.Add(Firme[forAdd]);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ResetButtons(int val = 0)
        {
            buttonIzmeni.Enabled = val == 1;
            buttonObrisi.Enabled = val >= 1;
            buttonObrisi.Text = val <= 1 ? "Obriši firmu" : "Obriši firme";

            buttonIzaberi.Enabled = ZatvorskaJedinica != null && val >= 1;
            buttonIzaberi.Text = val <= 1 ? "Izaberi firmu" : "Izaberi firme";
        }
    }
}
