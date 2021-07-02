using FluentNHibernate.Mapping;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    public class ZastupaMapiranja : ClassMap<Zastupa>
    {
        public ZastupaMapiranja()
        {
            // Naziv tabele u bazi
            Table("ZASTUPA");

            // Mapiranje primarnog ključa
            Id(z => z.ID)
                .Column("ID")
                .GeneratedBy.TriggerIdentity();

            // Mapiranje atributa
            Map(z => z.DatumPocetkaSaradnje)
                .Column("DATUM_POCETKA_SARADNJE")
                .Not.Nullable();
            Map(z => z.DatumPoslednjegKontakta)
                .Column("DATUM_POSLEDNJEG_KONTAKTA");

            CheckConstraint("UNIQUE (JMBG_ZAT, JMBG_ADV)");

            References(z => z.Advokat)
                .Column("JMBG_ADV")
                .Not.Nullable()
                .LazyLoad();

            References(z => z.Zatvorenik)
                .Column("JMBG_ZAT")
                .Not.Nullable()
                .LazyLoad();
        }
    }
}
