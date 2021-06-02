using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.Common
{
    public class SastavContext
    {
        public AKUDDbContext db = new AKUDDbContext();
        public PripadaContext dbPripada = new PripadaContext();
        public VodiContext dbVodi = new VodiContext();
        public ProbaContext dbProba = new ProbaContext();

        public List<Sastav> GetSastavi()
        {
            return db.Sastavi.ToList();
        }

        public void AddSastav(Sastav i)
        {
            db.Sastavi.Add(i);
            db.SaveChanges();
        }

        public void DeleteSastav(int id)
        {
            var obrisan = db.Sastavi.Where(i => i.ID_SS == id).Single();
            db.Sastavi.Remove(obrisan);
            foreach (Pripada p in dbPripada.GetPripadai())
            {
                if (p.SastavID_SS == id)
                    dbPripada.DeletePripada(p.IgracID_IG, p.SastavID_SS);
            }
            foreach (Vodi v in dbVodi.GetVodii())
            {
                if (v.SastavID_SS == id)
                    dbVodi.DeleteVodi(v.KoreografID_KOR, id);
            }
            foreach(Proba p in dbProba.GetProbai())
            {
                if (p.SastavID_SS == id)
                    dbProba.DeleteProba(p.ID_PROB, id);
            }
            db.SaveChanges();
        }

        public Sastav GetSastav(int id)
        {
            return db.Sastavi.Where(i => i.ID_SS == id).Single();
        }

        public void UpdateSastav(Sastav i, int id)
        {
            Sastav tr = GetSastav(id);
            tr.IME_SS = i.IME_SS;
            db.SaveChanges();
        }
    }
}
