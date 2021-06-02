using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.Common
{
    public class PripadaContext
    {
        public AKUDDbContext db = new AKUDDbContext();

        public List<Pripada> GetPripadai()
        {
            return db.Pripadanje.ToList();
        }

        public void AddPripada(Pripada i)
        {
            db.Pripadanje.Add(i);
            db.SaveChanges();
        }

        public void DeletePripada(int idIgrac, int idSastava)
        {
            var obrisan = db.Pripadanje.Where(i => (i.IgracID_IG == idIgrac && i.SastavID_SS == idSastava)).Single();
            db.Pripadanje.Remove(obrisan);
            db.SaveChanges();
        }

        public Pripada GetPripada(int idIgrac, int idSastava)
        {
            return db.Pripadanje.Where(i => (i.IgracID_IG == idIgrac && i.SastavID_SS == idSastava)).Single();
        }

        public void UpdatePripada(Pripada i, int stariIgrac, int stariSastav)
        {
            DeletePripada(stariIgrac, stariSastav);
            AddPripada(i);
            db.SaveChanges();
        }
    }
}
