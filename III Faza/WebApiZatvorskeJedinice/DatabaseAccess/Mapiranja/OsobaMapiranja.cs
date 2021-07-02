using Zatvor.Entiteti;
using FluentNHibernate.Mapping;

namespace Zatvor.Mapiranja
{
    public class OsobaMapiranja : ClassMap<Osoba>
    {
        public OsobaMapiranja()
        {
            // B-tip Table-Per-Concrete-Class
            // Ovo je apstraktna klasa, koja ne postoji u bazi
            UseUnionSubclassForInheritanceMapping();

            // Mapiranje primarnog ključa
            Id(o => o.JMBG)
                .Column("JMBG")
                .GeneratedBy.Assigned();

            // Mapiranje atributa
            Map(o => o.Ime)
                .Column("Ime")
                .Not.Nullable();
            Map(o => o.Prezime)
                .Column("Prezime")
                .Not.Nullable();
            Map(o => o.Pol)
                .Column("Pol")
                .Check("POL IN ('M', 'Ž')")
                .Not.Nullable();
        }
    }
}
