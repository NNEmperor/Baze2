using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.Common
{
    public class PevackiKoncertContext
    {
        public AKUDDbContext db = new AKUDDbContext();

        public List<PevackiKoncert> GetPevackiKoncerti()
        {
            List<PevackiKoncert> temp = new List<PevackiKoncert>();
            foreach (Koncert k in db.Koncerti.ToList())
            {
                if (k.TIP_KC == "Pevacki" || k.TIP_KC == "Kombinovan")
                {
                    temp.Add(k as PevackiKoncert);
                }
            }
            return temp;
        }

        public void AddPevackiKoncert(PevackiKoncert i)
        {
            db.Koncerti.Add(i);
            db.SaveChanges();
        }

        public void DeletePevackiKoncert(int id)
        {
            var obrisan = db.Koncerti.Where(i => i.ID_KC == id).Single();
            db.Koncerti.Remove(obrisan);
            db.SaveChanges();
        }

        public PevackiKoncert GetPevackiKoncert(int id)
        {
            return db.Koncerti.Where(i => i.ID_KC == id).Single() as PevackiKoncert;
        }

        public void UpdatePevackiKoncert(PevackiKoncert i, int id)
        {
            PevackiKoncert tr = GetPevackiKoncert(id);
            tr.PEV_TIP = i.PEV_TIP;
            db.SaveChanges();
        }
    }
}
