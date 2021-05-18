using Zatvor.Entiteti;
using FluentNHibernate.Mapping;

namespace Zatvor.Mapiranja
{
    public class ZaposleniMapiranja : ClassMap<Zaposleni>
    {
        public ZaposleniMapiranja()
        {
            // Table-Per-Concrete-Class
            // B-tip nasleđivanja
            // Osvnovna klasa
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
            Map(z => z.RadnoMesto)
                .Column("RADNO_MESTO")
                .Not.Nullable();
            Map(z => z.DatumObukePPZ)
                .Column("DATUM_OBUKE_PPZ")
                .Not.Nullable();

            // Veza M:N sa atributima
            HasMany(z => z.RadiU)
                .KeyColumn("JMBG_ZAP")
                .LazyLoad()
                .Cascade.All();
        }
    }
}
