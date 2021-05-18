using FluentNHibernate.Mapping;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    public class RadiUMapiranja : ClassMap<RadiU>
    {
        public RadiUMapiranja()
        {
            // Naziv tabele u bazi podataka
            Table("RADI_U");

            // Mapiranje primarnog ključa
            Id(ru => ru.ID)
                .Column("ID")
                .GeneratedBy.TriggerIdentity();

            // Mapiranje atributa
            Map(ru => ru.DatumPocetkaRada)
                .Column("DATUM_POCETKA_RADA")
                .Not.Nullable();

            // Strani ključ ka zatvorskoj jedinici
            References(ru => ru.ZatvorskaJedinica)
                .Column("SIFRA_ZJ")
                .Not.Nullable()
                .LazyLoad();

            // Strani ključ ka zaposlenom u zatvorskoj jedinici
            References(ru => ru.Zaposleni)
                .Column("JMBG_ZAP")
                .Not.Nullable()
                .LazyLoad();
        }
    }
}
