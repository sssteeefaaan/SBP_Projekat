namespace Zatvor.Entiteti
{
    public class Posecuje
    {
        public virtual int ID { get; set; }
        public virtual System.DateTime DTPocetka { get; set; }
        public virtual System.DateTime DTKraja { get; set; }
        public virtual Zatvorenik Zatvorenik { get; set; }
        public virtual Advokat Advokat { get; set; }
    }
}