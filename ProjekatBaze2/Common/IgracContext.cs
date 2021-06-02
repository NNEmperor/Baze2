using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.Common
{
    public class IgracContext
    {
        public AKUDDbContext db = new AKUDDbContext();
        public PripadaContext dbPripada = new PripadaContext();
        public NastupaContext dbNastupa = new NastupaContext();

        public List<Igrac> GetIgraci()
        {
            return db.Igraci.ToList();
        }

        public void AddIgrac(Igrac i)
        {
            db.Igraci.Add(i);
            db.SaveChanges();
        }

        public void DeleteIgrac(int id)
        {
            var obrisan = db.Igraci.Where(i => i.ID_IG == id).Single();
            db.Igraci.Remove(obrisan);
            foreach (Pripada p in dbPripada.GetPripadai())
            {
                if (p.IgracID_IG == id)
                    dbPripada.DeletePripada(id, p.SastavID_SS);
            }
            foreach(Nastupa n in dbNastupa.GetNastupai())
            {
                if (n.IgracID_IG == id)
                    dbNastupa.DeleteNastupa(id, n.KoncertID_KC);
            }
            db.SaveChanges();
        }

        public Igrac GetIgrac(int id)
        {
            return db.Igraci.Where(i => i.ID_IG == id).Single();
        }

        public void UpdateIgrac(Igrac i, int id)
        {
            Igrac tr = GetIgrac(id);
            tr.IME_IG = i.IME_IG;
            tr.PR_IG = i.PR_IG;
            tr.VIS_IG = i.VIS_IG;
            tr.POL_IG = i.POL_IG;
            db.SaveChanges();
        }

    }
}
