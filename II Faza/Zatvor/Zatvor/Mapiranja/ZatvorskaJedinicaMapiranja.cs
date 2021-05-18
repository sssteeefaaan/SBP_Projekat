using FluentNHibernate.Mapping;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    public class ZatvorskaJedinicaMapiranja: ClassMap<ZatvorskaJedinica>
    {
        public ZatvorskaJedinicaMapiranja()
        {
            // Mapiranje Tabele
            Table("ZATVORSKA_JEDINICA");

            // Mapiranje primarnog ključa
            Id(zj => zj.Sifra, "SIFRA")
                .GeneratedBy.Assigned();

            // Mapiranje atributa
            Map(zj => zj.Naziv, "NAZIV");
            Map(zj => zj.Adresa, "ADRESA");
            Map(zj => zj.Kapacitet, "KAPACITET");
            Map(zj => zj.FrezimO, "FREZIM_O");
            Map(zj => zj.FrezimS, "FREZIM_S");
            Map(zj => zj.FrezimPO, "FREZIM_PO");

            // Veza N:1
            References(zj => zj.Upravnik)
                .Column("JMBG_UPRAVNIK")
                .Not.Nullable()
                .LazyLoad();

            // Viševrednosni kompozitni atribut
            HasMany(zj => zj.TerminiPosete)
                .KeyColumn("SIFRA_ZJ")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            // Viševrednosni kompozitni atribut
            HasMany(zj => zj.TerminiSetnje)
                .KeyColumn("SIFRA_ZJ")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            // Viševrednosni kompozitni atribut
            HasMany(zj => zj.CelijskiPeriodi)
                .KeyColumn("SIFRA_ZJ")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            // Veza 1:N
            HasMany(zj => zj.Zatvorenici)
                .KeyColumn("SIFRA_ZJ")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            // Veza N:M bez atributa
            HasManyToMany(zj => zj.Firme)
                .Table("MOZE_DA_ANGAZUJE")
                .ParentKeyColumn("SIFRA_ZJ")
                .ChildKeyColumn("PIB_FIRME")
                .Cascade.All()
                .LazyLoad()
                .Inverse();

            // Veza N:M sa atributima
            HasMany(zj => zj.RadiU)
                .KeyColumn("SIFRA_ZJ")
                .LazyLoad()
                .Cascade.All()
                .Inverse();
        }
    }
}
