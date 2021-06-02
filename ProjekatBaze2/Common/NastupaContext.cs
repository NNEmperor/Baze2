using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.Common
{
    public class NastupaContext
    {
        public AKUDDbContext db = new AKUDDbContext();
        public NosnjaContext dbNosnja = new NosnjaContext();

        public List<Nastupa> GetNastupai()
        {
            return db.Nastupaju.ToList();
        }

        public void AddNastupa(Nastupa i)
        {
            db.Nastupaju.Add(i);
            db.SaveChanges();
        }

        public void DeleteNastupa(int idIgraca, int idKoncerta)
        {
            var obrisan = db.Nastupaju.Where(i => (i.IgracID_IG == idIgraca && i.KoncertID_KC == idKoncerta)).Single();
            db.Nastupaju.Remove(obrisan);
            foreach(Nosnja n in dbNosnja.GetNosnjai())
            {
                if (n.NastupaIgracID_IG == idIgraca && n.NastupaKoncertID_KC == idKoncerta)
                    dbNosnja.DeleteNosnja(n.ID_NOS);
            }
            db.SaveChanges();
        }

        public Nastupa GetNastupa(int idIgraca, int idKoncerta)
        {
            return db.Nastupaju.Where(i => (i.IgracID_IG == idIgraca && i.KoncertID_KC == idKoncerta)).Single();
        }

        public void UpdateNastupa(Nastupa i, int stariIgrac, int stariKoncert)
        {
            DeleteNastupa(stariIgrac, stariKoncert);
            AddNastupa(i);
            db.SaveChanges();
        }
    }
}
