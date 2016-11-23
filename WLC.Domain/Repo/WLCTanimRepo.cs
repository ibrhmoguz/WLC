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

        private IKullaniciYapilanAp kullaniciYapilanApRepo;

        public IEnumerable<WLCTanim> WLCTanimlar
        {
            get { return context.WLCTanimlar.ToList(); }
        }

        public WLCTanimRepo(IKullaniciYapilanAp kyr)
        {
            kullaniciYapilanApRepo = kyr;
        }

        public bool WLCKaydet(string id, string kullanici)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            var dbConext = context.Database.BeginTransaction();

            try
            {
                var wlcTanim = context.WLCTanimlar.Find(Convert.ToInt32(id));
                if (wlcTanim != null)
                {
                    //if (!wlcTanim.APSAYISI.Equals(wlcTanim.YAPILANAPSAYISI))
                    //{
                    wlcTanim.YAPILANAPSAYISI = string.IsNullOrEmpty(wlcTanim.YAPILANAPSAYISI) ? "1" : (Convert.ToInt32(wlcTanim.YAPILANAPSAYISI) + 1).ToString();

                    if (wlcTanim.APSAYISI.Equals(wlcTanim.YAPILANAPSAYISI))
                    {
                        wlcTanim.DONE = true;
                    }
                    //}

                    wlcTanim.KULLANICI = kullanici;
                    wlcTanim.TARIH = DateTime.Now;

                    kullaniciYapilanApRepo.KullaniciYapilanApKaydet(id, kullanici);

                    context.SaveChanges();
                    dbConext.Commit();
                }

                return true;
            }
            catch
            {
                dbConext.Rollback();
                return false;
            }
        }

        public bool WLCCikar(string id, string kullanici)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            var dbConext = context.Database.BeginTransaction();

            try
            {
                var wlcTanim = context.WLCTanimlar.Find(Convert.ToInt32(id));
                if (wlcTanim != null)
                {
                    var yapilanApSayi = Convert.ToInt32(wlcTanim.YAPILANAPSAYISI);
                    if (yapilanApSayi > 0)
                    {
                        wlcTanim.YAPILANAPSAYISI = (yapilanApSayi - 1).ToString();
                        wlcTanim.DONE = wlcTanim.APSAYISI.Equals(wlcTanim.YAPILANAPSAYISI);
                    }

                    wlcTanim.KULLANICI = kullanici;
                    wlcTanim.TARIH = DateTime.Now;

                    kullaniciYapilanApRepo.KullaniciYapilanApCikar(id, kullanici);

                    context.SaveChanges();
                    dbConext.Commit();
                }

                return true;
            }
            catch
            {
                dbConext.Rollback();
                return false;
            }
        }
    }
}
