using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.Common
{
    public class KoreografContext
    {
        public AKUDDbContext db = new AKUDDbContext();
        public VodiContext dbVodi = new VodiContext();

        public List<Koreograf> GetKoreografi()
        {
            return db.Koreografi.ToList();
        }

        public void AddKoreograf(Koreograf i)
        {
            db.Koreografi.Add(i);
            db.SaveChanges();
        }

        public void DeleteKoreograf(int id)
        {
            var obrisan = db.Koreografi.Where(i => i.ID_KOR == id).Single();
            db.Koreografi.Remove(obrisan);
            foreach (Vodi v in dbVodi.GetVodii())
            {
                if (v.KoreografID_KOR == id)
                    dbVodi.DeleteVodi(v.KoreografID_KOR, v.SastavID_SS);
            }
            db.SaveChanges();
        }

        public Koreograf GetKoreograf(int id)
        {
            return db.Koreografi.Where(i => i.ID_KOR == id).Single();
        }

        public void UpdateKoreograf(Koreograf i, int id)
        {
            Koreograf tr = GetKoreograf(id);
            tr.IME_KOR = i.IME_KOR;
            tr.PR_KOR = i.PR_KOR;
            db.SaveChanges();
        }
    }
}
