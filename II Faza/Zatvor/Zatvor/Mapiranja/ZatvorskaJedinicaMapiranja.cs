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
            Map(zj => zj.Naziv, "NAZIV").Not.Nullable();
            Map(zj => zj.Adresa, "ADRESA").Not.Nullable();
            Map(zj => zj.Kapacitet, "KAPACITET").Not.Nullable();
            Map(zj => zj.FrezimO, "FREZIM_O").Not.Nullable();
            Map(zj => zj.FrezimPO, "FREZIM_PO").Not.Nullable();
            Map(zj => zj.FrezimS, "FREZIM_S").Not.Nullable();

            DiscriminateSubClassesOnColumn("")
                .Formula("CASE WHEN (FREZIM_O = 'TRUE' AND FREZIM_S = 'FALSE' AND FREZIM_PO = 'FALSE') THEN 'O' " +
                             " WHEN (FREZIM_O = 'FALSE' AND FREZIM_S = 'FALSE' AND FREZIM_PO = 'TRUE') THEN 'PO' " +
                             " WHEN (FREZIM_O = 'FALSE' AND FREZIM_S = 'TRUE' AND FREZIM_PO = 'FALSE') THEN 'S' " +
                             " WHEN (FREZIM_O = 'TRUE' AND FREZIM_S = 'TRUE' AND FREZIM_PO = 'FALSE') THEN 'OS' " +
                             " WHEN (FREZIM_O = 'TRUE' AND FREZIM_S = 'FALSE' AND FREZIM_PO = 'TRUE') THEN 'OPO' " +
                             " WHEN (FREZIM_O = 'FALSE' AND FREZIM_S = 'TRUE' AND FREZIM_PO = 'TRUE') THEN 'POS' " +
                             " WHEN (FREZIM_O = 'TRUE' AND FREZIM_S = 'TRUE' AND FREZIM_PO = 'TRUE') THEN 'OPOS' " +
                              //"ELSE 'NEVALIDNO'" +
                         " END");

            // Veza N:1
            References(zj => zj.Upravnik)
                .Column("JMBG_UPRAVNIKA")
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

    public class ZJOtvorenogTipaMapiranja : SubclassMap<ZJOtvorenogTipa>
    {
        public ZJOtvorenogTipaMapiranja()
        {
            DiscriminatorValue("O");
        }
    }
    public class ZJPoluotvorenogTipaMapiranja : SubclassMap<ZJPoluotvorenogTipa>
    {
        public ZJPoluotvorenogTipaMapiranja()
        {
            DiscriminatorValue("PO");
        }
    }
    public class ZJStrogogTipaMapiranja : SubclassMap<ZJStrogogTipa>
    {
        public ZJStrogogTipaMapiranja()
        {
            DiscriminatorValue("S");
        }
    }
    public class ZJOtvorenoPoluotvorenogTipaMapiranja : SubclassMap<ZJOtvorenoPoluotvorenogTipa>
    {
        public ZJOtvorenoPoluotvorenogTipaMapiranja()
        {
            DiscriminatorValue("OPO");
        }
    }
    public class ZJOtvorenoStrogogTipaMapiranja : SubclassMap<ZJOtvorenoStrogogTipa>
    {
        public ZJOtvorenoStrogogTipaMapiranja()
        {
            DiscriminatorValue("OS");
        }
    }
    public class ZJPoluotvorenoStrogogTipaMapiranja : SubclassMap<ZJPoluotvorenoStrogogTipa>
    {
        public ZJPoluotvorenoStrogogTipaMapiranja()
        {
            DiscriminatorValue("POS");
        }
    }
    public class ZJSvakiTipMapiranja : SubclassMap<ZJSvakiTip>
    {
        public ZJSvakiTipMapiranja()
        {
            DiscriminatorValue("OPOS");
        }
    }
}
