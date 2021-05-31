using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FluentNHibernate;
using NHibernate;
using Zatvor.Entiteti;

namespace Zatvor
{
    public partial class ZatvorskaJedinicaForm : Form
    {
        public object Messagebox { get; private set; }

        public ZatvorskaJedinicaForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ZatvorskaJedinicaForm_Load_1(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<ZatvorskaJedinica> lista = s.Query<ZatvorskaJedinica>().ToList();

                dataGridView1.DataSource = lista;

                s.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {

        }

        private void buttonIzmeni_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                String Sifra = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                String Naziv = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                String Upravnik = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                String Kapacitet = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }
        }

        private void buttonObrisi_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
