using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.Common
{
    public class VodiContext
    {
        public AKUDDbContext db = new AKUDDbContext();

        public List<Vodi> GetVodii()
        {
            return db.Vodjenje.ToList();
        }

        public void AddVodi(Vodi i)
        {
            db.Vodjenje.Add(i);
            db.SaveChanges();
        }

        public void DeleteVodi(int idKoreografa, int idSastava)
        {
            var obrisan = db.Vodjenje.Where(i => (i.KoreografID_KOR == idKoreografa && i.SastavID_SS == idSastava)).Single();
            db.Vodjenje.Remove(obrisan);
            db.SaveChanges();
        }

        public Vodi GetVodi(int idKoreografa, int idSastava)
        {
            return db.Vodjenje.Where(i => (i.KoreografID_KOR == idKoreografa && i.SastavID_SS == idSastava)).Single();
        }

        public void UpdateVodi(Vodi i, int stariKoreograf, int stariSastav)
        {
            DeleteVodi(stariKoreograf, stariSastav);
            AddVodi(i);
            db.SaveChanges();
        }
    }
}
