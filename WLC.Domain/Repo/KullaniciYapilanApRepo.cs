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
