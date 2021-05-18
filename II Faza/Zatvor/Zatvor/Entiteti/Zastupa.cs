
namespace Zatvor.Entiteti
{
    public class Zastupa
    {
        public virtual int ID { get; set; }
        public virtual System.DateTime DatumPocetkaSaradnje { get; set; }
        public virtual System.DateTime? DatumPoslednjegKontakta { get; set; }
        public virtual Zatvorenik Zatvorenik { get; set; }
        public virtual Advokat Advokat { get; set; }
    }
}