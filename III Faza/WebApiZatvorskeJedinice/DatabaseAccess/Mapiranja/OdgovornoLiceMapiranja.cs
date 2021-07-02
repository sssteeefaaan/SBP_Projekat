using FluentNHibernate.Mapping;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    public class OdgovornoLiceMapiranja : ClassMap<OdgovornoLice>
    {
        public OdgovornoLiceMapiranja()
        {
            // Naziv tabele u bazi podataka
            Table("ODGOVORNO_LICE");

            // Primarni ključ
            Id(ol => ol.ID)
                .Column("ID")
                .GeneratedBy.TriggerIdentity();

            // Mapiranja atributa
            Map(ol => ol.JMBG)
                .Column("JMBG")
                .Not.Nullable();
            Map(ol => ol.Ime)
                .Column("Ime")
                .Not.Nullable();
            Map(ol => ol.Prezime)
                .Column("Prezime")
                .Not.Nullable();

            // Provera constraint-a
            CheckConstraint("UNIQUE (PIB_FIRME, JMBG)");

            // Strani ključ ka firmi
            References(ol => ol.Firma)
                .Column("PIB_FIRME")
                .Not.Nullable()
                .LazyLoad();       }
    }
}
