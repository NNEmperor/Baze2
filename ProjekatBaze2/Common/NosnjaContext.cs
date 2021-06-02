using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.Common
{
    public class NosnjaContext
    {
        public AKUDDbContext db = new AKUDDbContext();

        public List<Nosnja> GetNosnjai()
        {
            return db.Nosnje.ToList();
        }

        public void AddNosnja(Nosnja i)
        {
            db.Nosnje.Add(i);
            db.SaveChanges();
        }

        public void DeleteNosnja(int id)
        {
            var obrisan = db.Nosnje.Where(i => i.ID_NOS == id).Single();
            db.Nosnje.Remove(obrisan);
            db.SaveChanges();
        }

        public Nosnja GetNosnja(int id)
        {
            return db.Nosnje.Where(i => i.ID_NOS == id).Single();
        }

        public void UpdateNosnja(Nosnja i, int id)
        {
            Nosnja tr = GetNosnja(id);
            tr.NastupaIgracID_IG = i.NastupaIgracID_IG;
            tr.NastupaKoncertID_KC = i.NastupaKoncertID_KC;
            tr.IME_NOS = i.IME_NOS;
            db.SaveChanges();
        }
    }
}
