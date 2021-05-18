using Zatvor.Entiteti;
using FluentNHibernate.Mapping;

namespace Zatvor.Mapiranja
{
    public class FirmaMapiranja : ClassMap<Firma>
    {

        public FirmaMapiranja()
        {
            // Naziv tabele u bazi
            Table("FIRMA");

            // Mapiranje primarnog ključa
            Id(f => f.PIB)
                .Column("PIB")
                .GeneratedBy.Assigned();

            // Mapiranja atributa
            Map(f => f.Naziv)
                .Column("NAZIV")
                .Not.Nullable();
            Map(f => f.Adresa)
                .Column("ADRESA")
                .Not.Nullable();
            Map(f => f.KontaktTelefon)
                .Column("KONTAKT_TELEFON")
                .Not.Nullable();

            // Viševrednosni kompozitni atribut
            HasMany(f => f.OdgovornaLica)
                .KeyColumn("PIB_FIRME")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            // Veza M:N bez atributa
            HasManyToMany(f => f.ZatvorskeJedinice)
            .Table("MOZE_DA_ANGAZUJE")
            .ParentKeyColumn("PIB_FIRME")
            .ChildKeyColumn("SIFRA_ZJ")
            .LazyLoad()
            .Cascade.All();
        }
    }
}
