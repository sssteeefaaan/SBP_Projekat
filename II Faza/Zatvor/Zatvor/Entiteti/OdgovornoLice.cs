namespace Zatvor.Entiteti
{
    public class OdgovornoLice
    {
        public virtual int ID { get; set; }
        public virtual string JMBG { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual Firma Firma { get; set; }
    }
}