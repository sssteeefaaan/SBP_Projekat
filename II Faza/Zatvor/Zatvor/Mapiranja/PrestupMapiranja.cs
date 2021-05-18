using Zatvor.Entiteti;
using FluentNHibernate.Mapping;

namespace Zatvor.Mapiranja
{
    public class PrestupMapiranja : ClassMap<Prestup>
    {
        public PrestupMapiranja()
        { 
            // Naziv tabele u bazi podataka
            Table("PRESTUP");

            // Mapiranje primarnog ključa
            Id(p => p.ID).GeneratedBy.TriggerIdentity();

            // Mapiranje atributa
            Map(p => p.PunNaziv)
                .Column("PUN_NAZIV")
                .Not.Nullable();
            Map(p => p.DatumPrestupa)
                .Column("DATUM_PRESTUPA")
                .Not.Nullable();
            Map(p => p.MestoPrestupa)
                .Column("MESTO_PRESTUPA")
                .Not.Nullable();
            Map(p => p.Kategorija)
                .Column("KATEGORIJA")
                .Not.Nullable();
            Map(p => p.Opis)
                .Column("OPIS");
            Map(p => p.MinKazna)
                .Column("MIN_KAZNA_DANI");
            Map(p => p.MaxKazna)
                .Column("MAKS_KAZNA_DANI");

            CheckConstraint("MIN_KAZNA_DANI <= MAKS_KAZNA_DANI");
            CheckConstraint("UNIQUE (JMBG_ZAT, PUN_NAZIV, DATUM_PRESTUPA)");

            // Veza N:1
            References(p => p.Zatvorenik)
                .Column("JMBG_ZAT")
                .LazyLoad(); // LazyLoad je po defaultu ukljucen
        }
    }
}
