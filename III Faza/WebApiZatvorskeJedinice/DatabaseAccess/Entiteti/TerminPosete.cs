namespace Zatvor.Entiteti
{
    public class TerminPosete
    {
        public virtual int ID {get;set;}
        public virtual ZatvorskaJedinica ZatvorskaJedinica { get; set; }
        public virtual string Dan { get; set; }
        public virtual string Period { get; set; }
    }
}