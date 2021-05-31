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

namespace Zatvor.Forms
{
    public partial class FormZatvorenici : Form
    {
        public List<ZatvorenikBasic> Zatvorenici { get; set; }
        public FormZatvorenici()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<ZatvorenikView> lista = new List<ZatvorenikView>();
            Zatvorenici = DTOManager.ReadAllZatvorenici();
            Zatvorenici.ForEach(z => lista.Add(new ZatvorenikView(z.JMBG, z.Ime, z.Prezime, z.Pol, z.Broj, z.Adresa, z.DatumInkarceracije, z.DatumSledecegSaslusanja, z.StatusUslovnogOtpusta, z.ZatvorskaJedinica.Naziv)));
            dataGridView1.DataSource = lista;

            buttonIzmeniZatvorenika.Enabled = buttonObrisi.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZatvorenikBasic z = null;
            Form f = new FormDodajZatvorenika(ref z);
            if (f.ShowDialog() == DialogResult.OK)
                DTOManager.CreateZatvorenik(z);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int selected = dataGridView1.SelectedRows.Count;
            buttonIzmeniZatvorenika.Enabled = selected == 1;
            buttonObrisi.Enabled = selected >= 1;
            buttonObrisi.Text = (selected <= 1) ? "Obriši zatvorenika" : "Obriši zatvorenike";
        }

        private void buttonIzmeniZatvorenika_Click(object sender, EventArgs e)
        {
            ZatvorenikBasic z = Zatvorenici[dataGridView1.CurrentCell.RowIndex];
            z.Zastupa = DTOManager.ReadAllZastupaFor(z);
            z.Prestupi = DTOManager.ReadAllPrestupiFor(z);
            z.Posete = DTOManager.ReadAllPoseteForZatvorenik(z);
            Form f = new FormIzmeniZatvorenika(ref z);
            if (f.ShowDialog() == DialogResult.OK)
                DTOManager.UpdateZatvorenik(z);
        }
    }
}
