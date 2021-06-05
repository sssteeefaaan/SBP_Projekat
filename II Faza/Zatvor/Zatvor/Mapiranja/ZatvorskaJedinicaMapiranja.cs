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
                .GeneratedBy
                .Assigned();

            // Mapiranje atributa
            Map(zj => zj.Naziv, "NAZIV").Not.Nullable();
            Map(zj => zj.Adresa, "ADRESA").Not.Nullable();
            Map(zj => zj.Kapacitet, "KAPACITET").Not.Nullable();
            Map(zj => zj.ORezim, "O_REZIM").Not.Nullable();
            Map(zj => zj.PORezim, "PO_REZIM").Not.Nullable();
            Map(zj => zj.SRezim, "S_REZIM").Not.Nullable();

            DiscriminateSubClassesOnColumn("")
                .Formula("CASE WHEN (O_REZIM = 1 AND S_REZIM = 0 AND PO_REZIM = 0) THEN 'O' " +
                             " WHEN (O_REZIM = 0 AND S_REZIM = 0 AND PO_REZIM = 1) THEN 'PO' " +
                             " WHEN (O_REZIM = 0 AND S_REZIM = 1 AND PO_REZIM = 0) THEN 'S' " +
                             " WHEN (O_REZIM = 1 AND S_REZIM = 1 AND PO_REZIM = 0) THEN 'OS' " +
                             " WHEN (O_REZIM = 1 AND S_REZIM = 0 AND PO_REZIM = 1) THEN 'OPO' " +
                             " WHEN (O_REZIM = 0 AND S_REZIM = 1 AND PO_REZIM = 1) THEN 'POS' " +
                             " WHEN (O_REZIM = 1 AND S_REZIM = 1 AND PO_REZIM = 1) THEN 'OPOS' " +
                              //"ELSE 'NEVALIDNO'" +
                         " END");

            // Veza N:1
            References(zj => zj.Upravnik)
                .Column("JMBG_UPRAVNIKA")
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
                .LazyLoad();

            // Veza N:M sa atributima
            HasMany(zj => zj.Zaposleni)
                .KeyColumn("RADI_U_ZJ")
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
