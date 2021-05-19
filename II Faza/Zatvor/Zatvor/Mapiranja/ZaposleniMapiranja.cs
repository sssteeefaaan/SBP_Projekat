using Zatvor.Entiteti;
using FluentNHibernate.Mapping;

namespace Zatvor.Mapiranja
{
    public class ZaposleniMapiranja : ClassMap<Zaposleni>
    {
        public ZaposleniMapiranja()
        {
            // Naziv tabele u bazi podataka
            Table("ZAPOSLENI");

            // Mapiranje primarnog ključa
            Id(z => z.JMBG)
                .Column("JMBG")
                .GeneratedBy.Assigned();

            // Type-Per-Hierarchy (C-tip) nasleđivanja
            // Kolona po kojoj se prepoznaju
            DiscriminateSubClassesOnColumn("")
                .Formula("CASE WHEN (TIP = 'ADMINISTRACIJA') THEN 'A' " +
                              "WHEN (TIP = 'PSIHOLOG') THEN 'P' " +
                              "WHEN (TIP = 'RADNIK OBEZBEĐENJA') THEN 'RO' " +
                         "END");

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

            // Mapiranje atributa za specifikaciju zaposlenog
            Map(z => z.RadnoMesto)
                .Column("RADNO_MESTO")
                .Not.Nullable();
            Map(z => z.DatumObukePPZ)
                .Column("DATUM_OBUKE_PPZ")
                .Not.Nullable();
            References(z => z.RadiU)
                .Column("RADI_U_ZJ")
                .Not.Nullable()
                .LazyLoad();
            Map(z => z.DatumPocetkaRada)
                .Column("DATUM_POCETKA_RADA")
                .Not.Nullable();


            // Administracija specijalizacija
            Map(a => a.Pozicija)
               .Column("POZICIJA");
            Map(a => a.Zanimanje)
                .Column("ZANIMANJE");
            Map(a => a.StrucnaSprema)
                .Column("STRUCNA_SPREMA")
                .Check("STRUCNA_SPREMA IN ('SREDNJA', 'VIŠA', 'VISOKA')");
            References(a => a.JeUpravnik)
                .Column("UPRAVNIK_ZJ")
                .Nullable()
                .LazyLoad();

            // ImajuKontakt specijalizacija
            Map(ik => ik.LPLekar)
                .Column("LP_LEKAR");
            Map(ik => ik.LPDatum)
                .Column("LP_DATUM");
            Map(ik => ik.LPNazivUstanove)
                .Column("LP_NAZIV_USTANOVE");
            Map(ik => ik.LPAdresaUstanove)
                .Column("LP_ADRESA_USTANOVE");

            // Psiholog specijalizacija
            Map(p => p.SSpecijalizacija)
                .Column("S_SPECIJALIZACIJA");
            Map(p => p.SNazivUstanove)
                .Column("S_NAZIV_USTANOVE");

            // RadnikObezbedjenja specijalizacija
            Map(ro => ro.DORVOSifra)
                .Column("DORVO_SIFRA");
            Map(ro => ro.DORVOPolicijskaUprava)
                .Column("DORVO_POLICIJSKA_UPRAVA");
            Map(ro => ro.DORVODatumIzdavanja)
                .Column("DORVO_DATUM_IZDAVANJA");

        }
    }
    public class AdministracijaMapiranja: SubclassMap<Administracija>
    {
        public AdministracijaMapiranja()
        {
            DiscriminatorValue("A");
        }
    }
    public class PsihologMapiranja : SubclassMap<Psiholog>
    {
        public PsihologMapiranja()
        {
            DiscriminatorValue("P");
        }
    }
    public class RadnikObezbedjenjaMapiranja : SubclassMap<RadnikObezbedjenja>
    {
        public RadnikObezbedjenjaMapiranja()
        {
            DiscriminatorValue("RO");
        }
    }
}
