using Zatvor.Entiteti;
using FluentNHibernate.Mapping;

namespace Zatvor.Mapiranja
{
    public class AdvokatMapiranja : SubclassMap<Advokat> // Table-Per-Concrete-Class nasleđivanje
    {
        public AdvokatMapiranja()
        {
            // Naziv tabele
            Table("ADVOKAT");

            // Table-Per-Concrete-Class nasleđivanje
            Abstract();

            // Veza N:M sa atributima
            HasMany(a => a.Zastupa)
                .KeyColumn("JMBG_ADV")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            // Veza N:M sa atributima
            HasMany(a => a.Posecuje)
                .KeyColumn("JMBG_ADV")
                .LazyLoad()
                .Cascade.All()
                .Inverse();
        }
    }
}
