using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WLC.Domain.Concrete;
using WLC.Domain.Entities;
using WLC.Domain.Interface;

namespace WLC.Domain.Repo
{
    public class WLCTanimRepo : IWLCTanimRepo
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<WLCTanim> WLCTanimlar
        {
            get { return context.WLCTanimlar.ToList(); }
        }

        public bool WLCKaydet(string id, string kullanici)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            else
            {
                var wlcTanim = context.WLCTanimlar.Find(Convert.ToInt32(id));
                if (wlcTanim != null)
                {
                    wlcTanim.DONE = true;
                    wlcTanim.KULLANICI = kullanici;
                    wlcTanim.TARIH = DateTime.Now;
                }
            }
            context.SaveChanges();
            return true;
        }
    }
}
