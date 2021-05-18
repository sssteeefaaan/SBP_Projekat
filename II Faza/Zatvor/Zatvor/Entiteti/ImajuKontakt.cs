namespace Zatvor.Entiteti
{
    public abstract class ImajuKontakt : Zaposleni
    {
        public virtual string LPLekar { get; set; }
        public virtual System.DateTime LPDatum { get; set; }
        public virtual string LPNazivUstanove { get; set; }
        public virtual string LPAdresaUstanove { get; set; }

        // Discriminate Column
        public virtual string Tip { get; set; }

        // Psiholog
        public virtual string SSpecijalizacija { get; set; }
        public virtual string SNazivUstanove { get; set; }

        // Radnik Obezbeđenja
        public virtual string DORVOSifra { get; set; }
        public virtual string DOBVOPolicijskaUprava { get; set; }
        public virtual System.DateTime? DORVODatumIzdavanja { get; set; }
    }

    public class Psiholog : ImajuKontakt
    {

    }
    public class RadnikObezbedjenja : ImajuKontakt
    {

    }
}
