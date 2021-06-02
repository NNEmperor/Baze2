using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.Common
{
    public class MuzikaContext
    {
        public AKUDDbContext db = new AKUDDbContext();
        public IgrackiKoncertContext dbIgracki = new IgrackiKoncertContext();

        public List<Muzika> GetMuzikai()
        {
            return db.Muzike.ToList();
        }

        public void AddMuzika(Muzika i)
        {
            db.Muzike.Add(i);
            db.SaveChanges();
        }

        public void DeleteMuzika(int id)
        {
            var obrisan = db.Muzike.Where(i => i.ID_MUZ == id).Single();
            db.Muzike.Remove(obrisan);
            foreach(IgrackiKoncert i in dbIgracki.GetIgrackiKoncerti())
            {
                if (i.MuzikaID_MUZ == id)
                    dbIgracki.DeleteIgrackiKoncert(i.ID_KC);
            }
            db.SaveChanges();
        }

        public Muzika GetMuzika(int id)
        {
            return db.Muzike.Where(i => i.ID_MUZ == id).Single();
        }

        public void UpdateMuzika(Muzika i, int id)
        {
            Muzika tr = GetMuzika(id);
            tr.IgrackiKoncerti = i.IgrackiKoncerti;
            tr.TIP_MUZ = i.TIP_MUZ;
            db.SaveChanges();
        }
    }
}
