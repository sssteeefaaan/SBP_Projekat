using FluentNHibernate.Mapping;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    public class TerminSetnjeMapiranja : ClassMap<TerminSetnje>
    {
        public TerminSetnjeMapiranja()
        {
            // Naziv tabele
            Table("TERMIN_SETNJE");

            // Primarni ključ
            Id(ts => ts.ID)
                .Column("ID")
                .GeneratedBy.TriggerIdentity();

            // Mapiranja atributa
            Map(ts => ts.Termin)
                .Column("TERMIN")
                .Not.Nullable();

            // Strani ključ ka zatvorskoj jedinici
            References(ts => ts.ZatvorskaJedinica)
                .Column("SIFRA_ZJ")
                .Not.Nullable()
                .LazyLoad();
        }
    }
}
