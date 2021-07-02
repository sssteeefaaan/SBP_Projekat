using Zatvor.Entiteti;
using FluentNHibernate.Mapping;

namespace Zatvor.Mapiranja
{
    public class PosecujeMapiranja : ClassMap<Posecuje>
    {
        public PosecujeMapiranja()
        {
            // Naziv tabele u bazi podataka
            Table("POSECUJE");

            // Mapiranje primarnog ključa
            Id(p => p.ID)
                .Column("ID")
                .GeneratedBy.TriggerIdentity();

            // Mapiranje atributa
            Map(p => p.DTPocetka)
                .Column("DT_POCETKA")
                .Not.Nullable();
            Map(p => p.DTKraja)
                .Column("DT_KRAJA")
                .Not.Nullable();

            // Provera constraints-a
            CheckConstraint("DT_POCETKA <= DT_KRAJA");
            CheckConstraint("UNIQUE (JMBG_ZAT, JMBG_ADV, DT_POCETKA)");

            // Strani ključ ka advokatu
            References(p => p.Advokat)
                .Column("JMBG_ADV")
                .Not.Nullable()
                .LazyLoad();

            // Strani ključ ka zatvoreniku
            References(p => p.Zatvorenik)
                .Column("JMBG_ZAT")
                .Not.Nullable()
                .LazyLoad();
        }
    }
}
