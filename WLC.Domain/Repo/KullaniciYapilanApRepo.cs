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
    public class KullaniciYapilanApRepo : IKullaniciYapilanAp
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<KullaniciYapilanAp> KullaniciYapilanApler
        {
            get
            {
                return context.KullaniciYapilanApler.ToList();
            }
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
                    if (!wlcTanim.APSAYISI.Equals(wlcTanim.YAPILANAPSAYISI))
                    {
                        wlcTanim.YAPILANAPSAYISI = string.IsNullOrEmpty(wlcTanim.YAPILANAPSAYISI) ? "1" : (Convert.ToInt32(wlcTanim.YAPILANAPSAYISI) + 1).ToString();

                        if (wlcTanim.APSAYISI.Equals(wlcTanim.YAPILANAPSAYISI))
                        {
                            wlcTanim.DONE = true;
                        }
                    }

                    wlcTanim.KULLANICI = kullanici;
                    wlcTanim.TARIH = DateTime.Now;
                }
            }
            context.SaveChanges();
            return true;
        }


        public bool KullaniciYapilanApKaydet(string id, string kullanici)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            var kullaniciYapilanAp = new KullaniciYapilanAp()
            {
                ID = Convert.ToInt32(id),
                Tarih = DateTime.Now,
                Kullanici = kullanici
            };
            context.KullaniciYapilanApler.Add(kullaniciYapilanAp);
            context.SaveChanges();

            return true;
        }
    }
}
