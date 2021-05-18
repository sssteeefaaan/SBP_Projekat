namespace Zatvor.Entiteti
{
    public abstract class Osoba
    {
        public virtual string JMBG { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Pol { get; set; }
    }
}
