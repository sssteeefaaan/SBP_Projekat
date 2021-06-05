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

namespace Zatvor.Forms.Pregledi
{
    public partial class FormPregledAdvokata : Form
    {
        private List<AdvokatBasic> Advokati { get; set; }
        public FormPregledAdvokata(List<AdvokatBasic> a)
        {
            Advokati = a;
            InitializeComponent();
        }
        public FormPregledAdvokata()
        {
            Advokati = DTOManager.ReadAllAdvokat();
            InitializeComponent();
        }

        private void FormPregledAdvokata_Load(object sender, EventArgs e)
        {
            listViewAdvokati.View = View.Details;
            listViewAdvokati.GridLines =
                listViewAdvokati.FullRowSelect = true;

            SetView();
            RefreshData();
            ResetButtons();
        }

        private void SetView()
        {
            listViewAdvokati.Columns.Clear();

            string[] columns = {
                "",
                "JMBG",
                "Ime",
                "Prezime",
                "Pol",
                "Broj zastupanja",
                "Broj poseta"
            };
            int[] vals = { 0, 150, 150, 150, 50, 150, 100 };

            for (int i = 0; i < columns.Length; i++)
                listViewAdvokati.Columns.Add(new ColumnHeader(i)
                {
                    Text = columns[i],
                    TextAlign = HorizontalAlignment.Center,
                    Width = vals[i]
                });
        }
        private void RefreshData()
        {
            listViewAdvokati.Items.Clear();

            Advokati.ForEach(a => listViewAdvokati.Items.Add(new ListViewItem(new string[]
                {
                    a.JMBG,
                    a.JMBG,
                    a.Ime,
                    a.Prezime,
                    a.Pol,
                    a.Zastupa.Count.ToString(),
                    a.Posecuje.Count.ToString()
                })));
        }
        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            FormAdvokat f = new FormAdvokat();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Advokati.Add(f.Advokat);
                RefreshData();
            }
            ResetButtons();
        }
        private void buttonIzmeni_Click(object sender, EventArgs e)
        {
            FormAdvokat f = new FormAdvokat(Advokati.Find(a => a.JMBG == listViewAdvokati.SelectedItems[0].Text));
            if (f.ShowDialog() == DialogResult.OK)
                RefreshData();

            ResetButtons();
        }

        private void buttonObrisi_Click(object sender, EventArgs e)
        {
            int forDel;
            foreach (ListViewItem lvi in listViewAdvokati.SelectedItems)
            {
                forDel = Advokati.FindIndex(a => a.JMBG == lvi.Text);
                DTOManager.DeleteAdvokat(Advokati[forDel]);
                Advokati.RemoveAt(forDel);
            }

            ResetButtons();
            RefreshData();
        }

        private void listViewAdvokati_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetButtons(listViewAdvokati.SelectedItems.Count);
        }

        private void ResetButtons(int val = 0)
        {
            buttonIzmeni.Enabled = val == 1;
            buttonObrisi.Enabled = val >= 1;
            buttonObrisi.Text = val <= 1 ? "Obriši advokata" : "Obriši advokate";
        }
    }
}
