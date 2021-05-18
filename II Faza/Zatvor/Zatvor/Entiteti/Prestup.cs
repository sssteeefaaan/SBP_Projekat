namespace Zatvor.Entiteti
{
    public class Prestup
    {
        public virtual string ID { get; set; }
        public virtual string PunNaziv { get; set; }
        public virtual string Kategorija { get; set; }
        public virtual string Opis { get; set; }
        public virtual int MinKazna { get; set; }
        public virtual int MaxKazna { get; set; }
        public virtual string MestoPrestupa { get; set; }
        public virtual System.DateTime DatumPrestupa { get; set; }
        public virtual Zatvorenik Zatvorenik { get; set; }

        public Prestup()
        {
            // Zatvorenik = new Zatvorenik();
        }
    }
}
