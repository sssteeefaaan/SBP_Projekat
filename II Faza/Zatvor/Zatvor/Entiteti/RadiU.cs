namespace Zatvor.Entiteti
{
    public class RadiU
    {
        public virtual int ID { get; set; }
        public virtual ZatvorskaJedinica ZatvorskaJedinica { get; set; }
        public virtual Zaposleni Zaposleni { get; set; }
        public virtual System.DateTime DatumPocetkaRada { get; set; }
    }
}