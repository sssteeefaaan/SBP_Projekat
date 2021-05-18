using FluentNHibernate.Mapping;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    public class ImajuKontaktMapiranja : ClassMap<ImajuKontakt>
    {
        public ImajuKontaktMapiranja()
        {
            // Naziv tabele u bazi podataka
            Table("IMAJU_KONTAKT");

            // Mapiranje primarnog ključa
            Abstract();

            DiscriminateSubClassesOnColumn("TIP");
            // Mapiranje atributa
            Map(ik => ik.LPLekar)
                .Column("LP_LEKAR")
                .Not.Nullable();
            Map(ik => ik.LPDatum)
                .Column("LP_DATUM")
                .Not.Nullable();
            Map(ik => ik.LPNazivUstanove)
                .Column("LP_NAZIV_USTANOVE")
                .Not.Nullable();

            Map(ik => ik.SSpecijalizacija)
                .Column("S_SPECIJALIZACIJA");
            Map(ik => ik.SNazivUstanove)
                .Column("S_NAZIV_USTANOVE");

            Map(ik => ik.DORVOSifra)
                .Column("DORVO_SIFRA");
            Map(ik => ik.DOBVOPolicijskaUprava)
                .Column("DORVO_POLICIJSKA_UPRAVA");
            Map(ik => ik.DORVODatumIzdavanja)
                .Column("DORVO_DATUM_IZDAVANJA");
        }
    }
}
