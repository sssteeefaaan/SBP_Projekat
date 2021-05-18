using FluentNHibernate.Mapping;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    public class CelijskiPeriodMapiranja : ClassMap<CelijskiPeriod>
    {
        public CelijskiPeriodMapiranja()
        {
            // Naziv tabele
            Table("CELIJSKI_PERIOD");

            // Primarni ključ
            Id(cp => cp.ID)
                .Column("ID")
                .GeneratedBy.TriggerIdentity();

            // Mapiranja atributa
            Map(cp => cp.Period)
                .Column("PERIOD")
                .Not.Nullable();

            // Strani ključ ka zatvorskoj jedinici
            References(cp => cp.ZatvorskaJedinica)
                .Column("SIFRA_ZJ")
                .Not.Nullable()
                .LazyLoad();
        }
    }
}
