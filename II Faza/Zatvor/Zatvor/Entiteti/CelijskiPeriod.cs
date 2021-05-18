namespace Zatvor.Entiteti
{
    public class CelijskiPeriod
    {
        public virtual int ID { get; set; }
        public virtual ZatvorskaJedinica ZatvorskaJedinica { get; set; }
        public virtual string Period { get; set; }
    }
}