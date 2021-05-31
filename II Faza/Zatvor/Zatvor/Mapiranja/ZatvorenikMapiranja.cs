using Zatvor.Entiteti;
using FluentNHibernate.Mapping;

namespace Zatvor.Mapiranja
{
    public class ZatvorenikMapiranja : SubclassMap<Zatvorenik> // Table-Per-Concrete-Class
    {
        public ZatvorenikMapiranja()
        {
            // Naziv tabele u bazi podataka
            Table("ZATVORENIK");

            // Type-Per-Concrete-Class (B tip) nasleđivanja
            // Govori da je osnovna klasa abstraktna
            Abstract();

            // Mapiranja atributa
            Map(z => z.Adresa)
                .Column("ADRESA");
            Map(z => z.Broj)
                .Column("BROJ")
                .Unique()
                .Not.Nullable();
            Map(z => z.DatumInkarceracije)
                .Column("DATUM_INKARCERACIJE")
                .Not.Nullable();
            Map(z => z.DatumSledecegSaslusanja)
                .Column("DATUM_SLEDECEG_SASLUSANJA");
            Map(z => z.StatusUslovnogOtpusta)
                .Column("STATUS_USLOVNOG_OTPUSTA")
                .Check("STATUS_USLOVNOG_OTPUSTA IN('PRIHVAĆEN', 'ODBIJEN', 'RAZMATRA SE')");

            // Veza N:1
            References(z => z.ZatvorskaJedinica)
                .Column("SIFRA_ZJ")
                .Not.Nullable()
                .LazyLoad();

            // Veza 1:N
            HasMany(z => z.Prestupi)
                .KeyColumn("JMBG_ZAT")
                .LazyLoad()
                .Cascade.All();

            // Veza N:M sa atributima
            HasMany(z => z.Zastupa)
                .KeyColumn("JMBG_ZAT")
                .LazyLoad()
                .Cascade.All();

            // Veza N:M sa atributima
            HasMany(z => z.Posete)
                .KeyColumn("JMBG_ZAT")
                .LazyLoad()
                .Cascade.All();
        }
    }
}
