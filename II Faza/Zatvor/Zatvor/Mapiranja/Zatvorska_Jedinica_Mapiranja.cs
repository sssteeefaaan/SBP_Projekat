using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    public class Zatvorska_Jedinica_Mapiranja: ClassMap<Zatvorska_Jedinica>
    {
        public Zatvorska_Jedinica_Mapiranja()
        {
            //Mapiranje Tabele
            Table("ZATVORSKA_JEDINICA");

            //Mapiranje primarnog ključa
            Id(e => e.Sifra, "SIFRA").GeneratedBy.Assigned();

            Map(e => e.Naziv, "NAZIV");
            Map(e => e.Adresa, "ADRESA");
            Map(e => e.JMBG_Upravnik, "JMBG_UPRAVNIK");
            Map(e => e.Kapacitet, "KAPACITET");
            Map(e => e.Frezim_O, "FREZIM_O");
            Map(e => e.Frezim_S, "FREZIM_S");
            Map(e => e.Frezim_PO, "FREZIM_PO");
        }
    }
}
