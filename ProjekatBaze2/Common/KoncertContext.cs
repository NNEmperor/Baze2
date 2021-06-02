using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.Common
{
    public class KoncertContext
    {
        public AKUDDbContext db = new AKUDDbContext();
        public NastupaContext dbNastupa = new NastupaContext();

        public List<Koncert> GetKoncerti()
        {
            return db.Koncerti.ToList();
        }

        public void AddKoncert(Koncert i)
        {
            db.Koncerti.Add(i);
            db.SaveChanges();
        }

        public void DeleteKoncert(int id)
        {
            var obrisan = db.Koncerti.Where(i => i.ID_KC == id).Single();
            db.Koncerti.Remove(obrisan);
            foreach (Nastupa n in dbNastupa.GetNastupai())
            {
                if (n.KoncertID_KC == id)
                    dbNastupa.DeleteNastupa(n.IgracID_IG, n.KoncertID_KC);
            }
            db.SaveChanges();
        }

        public Koncert GetKoncert(int id)
        {
            return db.Koncerti.Where(i => i.ID_KC == id).Single();
        }

        public void UpdateKoncert(Koncert i, int id)
        {
            Koncert tr = GetKoncert(id);
            tr.VR_KC = i.VR_KC;
            db.SaveChanges();
        }
    }
}
