using FluentNHibernate.Mapping;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    public class TerminPoseteMapiranja : ClassMap<TerminPosete>
    {

        public TerminPoseteMapiranja()
        {
            // Naziv tabele
            Table("TERMIN_POSETE");

            // Primarni ključ
            Id(tp => tp.ID)
                .Column("ID")
                .GeneratedBy.TriggerIdentity();

            // Mapiranje atributa
            Map(tp => tp.Dan)
                .Column("DAN")
                .Not.Nullable();
            Map(tp => tp.Period)
                .Column("PERIOD")
                .Not.Nullable();

            // Strani ključ ka zatvorskoj jedinici
            References(tp => tp.ZatvorskaJedinica)
                .Column("SIFRA_ZJ")
                .Not.Nullable()
                .LazyLoad();
        }
    }
}
