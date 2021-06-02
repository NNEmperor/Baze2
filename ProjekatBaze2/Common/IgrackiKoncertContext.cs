using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.Common
{
    public class IgrackiKoncertContext
    {
        public AKUDDbContext db = new AKUDDbContext();

        public List<IgrackiKoncert> GetIgrackiKoncerti()
        {
            List<IgrackiKoncert> temp = new List<IgrackiKoncert>();
            foreach(Koncert k in db.Koncerti.ToList())
            {
                if(k.TIP_KC == "Igracki" || k.TIP_KC == "Kombinovan")
                {
                    temp.Add(k as IgrackiKoncert);
                }
            }
            return temp;
        }

        public void AddIgrackiKoncert(IgrackiKoncert i)
        {
            db.Koncerti.Add(i);
            db.SaveChanges();
        }

        public void DeleteIgrackiKoncert(int id)
        {
            var obrisan = db.Koncerti.Where(i => i.ID_KC == id).Single();
            db.Koncerti.Remove(obrisan);
            db.SaveChanges();
        }

        public IgrackiKoncert GetIgrackiKoncert(int id)
        {
            return db.Koncerti.Where(i => i.ID_KC == id).Single() as IgrackiKoncert;
        }

        public void UpdateIgrackiKoncert(IgrackiKoncert i, int id)
        {
            IgrackiKoncert tr = GetIgrackiKoncert(id);
            tr.IG_KOR = i.IG_KOR;
            tr.MuzikaID_MUZ = i.MuzikaID_MUZ;
            db.SaveChanges();
        }
    }
}
