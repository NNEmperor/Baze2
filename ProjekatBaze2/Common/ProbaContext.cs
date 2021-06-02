using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.Common
{
    public class ProbaContext
    {
        public AKUDDbContext db = new AKUDDbContext();

        public List<Proba> GetProbai()
        {
            return db.Probe.ToList();
        }

        public void AddProba(Proba i)
        {
            db.Probe.Add(i);
            db.SaveChanges();
        }

        public void DeleteProba(int id, int idSastav)
        {
            var obrisan = db.Probe.Where(i => (i.ID_PROB == id && i.SastavID_SS == idSastav)).Single();
            db.Probe.Remove(obrisan);
            db.SaveChanges();
        }

        public Proba GetProba(int id, int idSastav)
        {
            return db.Probe.Where(i => (i.ID_PROB == id && i.SastavID_SS == idSastav)).Single();
        }

        public void UpdateProba(Proba i, int id, int idSastav)
        {
            Proba tr = GetProba(id, idSastav);
            tr.TIP_PROB = i.TIP_PROB;
            tr.VR_PROB = i.VR_PROB;
            db.SaveChanges();
        }
    }
}
