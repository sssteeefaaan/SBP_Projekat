using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Mapiranja;

namespace Zatvor
{
    class DataLayer
    {
        private static ISessionFactory _factory = null;
        private static object objLock = new object();

        //Kreiranje SessionFactory objekta je vrlo skupo, tako da se primenljuje Singleton obrazac
        //Kako bi se jedna instanca delila između svih niti, odnosno sesija
        public static ISession GetSession()
        {
            if (_factory == null)
            {
                lock (objLock)
                {
                    //Thread-safe singleton
                    if (_factory == null)
                        _factory = CreateSessionFactory();
                }
            }
            return _factory.OpenSession();
        }

        //Ovo je vrlo teska funkcija, prolazi se kroz sva mapiranja, povezivanje na bazu itd itd
        private static ISessionFactory CreateSessionFactory()
        {
            try
            {
                var config = OracleManagedDataClientConfiguration.Oracle10
                    .ConnectionString(c =>
                    c.Is("DATA SOURCE=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;PERSIST SECURITY INFO=True;USER ID=S17432;Password=S17432"));
                //Connection String ka bazi

                return Fluently.Configure()
                    .Database(config.ShowSql()) //ShowSql ce prikazivati kako izgledaju naredbe ka bazi i lakse je za debagiranje
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ZatvorskaJedinicaMapiranja>())//Da pronadje sva mapiranja koja se nalaze u istom namespace-u kao i Zatvorska jedinica
                    .BuildSessionFactory();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }
        }
    }
}
