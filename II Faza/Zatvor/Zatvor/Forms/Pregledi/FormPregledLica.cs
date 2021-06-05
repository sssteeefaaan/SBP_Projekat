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
using Zatvor.Forms.Dodaj_Izmeni;

namespace Zatvor.Forms.Pregledi
{
    public partial class FormPregledLica : Form
    {
        private FirmaBasic Firma { get; set; }
        public FormPregledLica(FirmaBasic f)
        {
            Firma = f;
            InitializeComponent();
        }
        private void FormPregledLica_Load(object sender, EventArgs e)
        {
            buttonIzmeni.Enabled =
                buttonObrisi.Enabled = false;

            listViewLica.GridLines =
                listViewLica.FullRowSelect =
                listViewLica.MultiSelect = true;

            listViewLica.View = View.Details;

            SetView();
            RefreshData();
            ResetButtons();
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            FormOdgovornoLice f = new FormOdgovornoLice(Firma);
            if (f.ShowDialog() == DialogResult.OK)
            {
                Firma.OdgovornaLica.Add(f.Lice);
                RefreshData();
            }
            ResetButtons();
        }

        private void buttonIzmeni_Click(object sender, EventArgs e)
        {
            int val = Firma.OdgovornaLica.FindIndex(ol => ol.ID == int.Parse(listViewLica.SelectedItems[0].Text));

            FormOdgovornoLice f = new FormOdgovornoLice(Firma.OdgovornaLica[val]);
            if (f.ShowDialog() == DialogResult.OK)
                RefreshData();

            ResetButtons();
        }

        private void buttonObrisi_Click(object sender, EventArgs e)
        {
            int forDel;

            foreach(ListViewItem lvi in listViewLica.SelectedItems)
            {
                forDel = Firma.OdgovornaLica.FindIndex(ol => ol.ID == int.Parse(lvi.Text));
                DTOManager.DeleteOdgovornoLice(Firma.OdgovornaLica[forDel]);
                Firma.OdgovornaLica.RemoveAt(forDel);
            }

            ResetButtons();
            RefreshData();
        }

        private void listViewLica_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetButtons(listViewLica.SelectedItems.Count);
        }
        private void SetView()
        {
            listViewLica.Columns.Clear();

            string[] columns =
            {
                "",
                "JMBG",
                "Ime",
                "Prezime"
            };
            int[] vals = { 0, 150, 100, 100 };

            for (int i = 0; i < columns.Length; i++)
                listViewLica.Columns.Add(new ColumnHeader(i)
                {
                    Text = columns[i],
                    TextAlign = HorizontalAlignment.Center,
                    Width = vals[i]
                });
        }
        private void RefreshData()
        {
            listViewLica.Items.Clear();

            Firma.OdgovornaLica.ForEach(ol => listViewLica.Items.Add(new ListViewItem(new string[]
            {
                ol.ID.ToString(),
                ol.JMBG,
                ol.Ime,
                ol.Prezime
            })));
        }

        private void ResetButtons(int val = 0)
        {
            buttonIzmeni.Enabled = val == 1;
            buttonObrisi.Enabled = val >= 1;
            buttonObrisi.Text = val <= 1 ? "Obriši odgovorno lice" : "Obriši odgovorna lica";
        }
    }
}
