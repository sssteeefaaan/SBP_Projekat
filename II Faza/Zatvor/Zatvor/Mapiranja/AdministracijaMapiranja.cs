using FluentNHibernate.Mapping;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    public class AdministracijaMapiranja : SubclassMap<Administracija> // B-tip nasleđivanja Table-Per-Concrete-Class
    {
        public AdministracijaMapiranja()
        {
            // Naziv tabele
            Table("ADMINISTRACIJA");

            // Govori da se nasleđuje osnovna tabela i njena mapiranja i da je ona apstraktna,
            // tj. da ne postoji u bazi
            Abstract();

            // Mapiranje atributa specijalizacije
            Map(a => a.Pozicija)
                .Column("POZICIJA");
            Map(a => a.Zanimanje)
                .Column("ZANIMANJE");
            Map(a => a.StrucnaSprema)
                .Column("STRUCNA_SPREMA")
                .Check("STRUCNA_SPREMA IN ('SREDNJA', 'VIŠA', 'VISOKA')");

            // Veza 1:N
            HasMany(a => a.UpravnikZJ)
                .KeyColumn("JMBG_UPRAVNIK")
                .LazyLoad()
                .Cascade.All()
                .Inverse();
        }
    }
}
