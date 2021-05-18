namespace Zatvor.Entiteti
{
    public class TerminSetnje
    {
        public virtual int ID { get; set; }
        public virtual ZatvorskaJedinica ZatvorskaJedinica { get; set; }
        public virtual string Termin { get; set; }
    }
}