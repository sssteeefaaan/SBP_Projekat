using System.Collections.Generic;

namespace Zatvor.Entiteti
{
    public class Advokat : Osoba
    {
        public virtual IList<Zastupa> Zastupa { get; set; }
        public virtual IList<Posecuje> Posecuje { get; set; }

        public Advokat()
        {
            Zastupa = new List<Zastupa>();
            Posecuje = new List<Posecuje>();
        }
    }
}
