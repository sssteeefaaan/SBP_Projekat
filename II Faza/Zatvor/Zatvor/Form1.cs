using NHibernate;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Zatvor.Entiteti;

namespace Zatvor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                ISession s = DataLayer.GetSession();

                ZatvorskaJedinica zj = s.Load<ZatvorskaJedinica>("AAA21");
                MessageBox.Show(zj.Naziv);
                foreach (Zatvorenik z in zj.Zatvorenici)
                {
                    MessageBox.Show($"{z.Ime} {z.Prezime} {z.JMBG} {z.Pol} {z.StatusUslovnogOtpusta} {z.ZatvorskaJedinica.Naziv} {z.DatumInkarceracije} {z.DatumSledecegSaslusanja}");
                }

                s.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
