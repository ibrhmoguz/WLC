using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public bool KullaniciYapilanApCikar(string id, string kullanici)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            var wlcId = Convert.ToInt32(id);
            var kullaniciYapilanAp = context.KullaniciYapilanApler.OrderByDescending(x => x.KullaniciApId).FirstOrDefault(x => x.ID.Equals(wlcId));
            context.KullaniciYapilanApler.Remove(kullaniciYapilanAp);
            context.SaveChanges();

            return true;
        }
    }
}
